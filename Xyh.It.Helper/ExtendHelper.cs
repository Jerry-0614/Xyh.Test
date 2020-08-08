using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Pivotal.Discovery.Client;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Text;

namespace Xyh.It.Helper
{
    /// <summary>
    /// 扩展类
    /// </summary>
    public static class ExtendHelper
    {
        /// <summary>
        /// 添加信息服务扩展
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddIT(this IServiceCollection services)
        {
            // 加载配置文件
            //var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            //IConfiguration configuration = builder.Build();
            HelperConfig.Load();

            // 追加跨域支持配置
            services.AddCors(option => option.AddPolicy("cors", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials().AllowAnyOrigin()));

            // 追加MVC配置
            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            // 追加认证中心相关配置
            if (HelperConfig.Oauth.IsEnabled)
            {
                // 追加客户端配置（认证中心）
                if (HelperConfig.Oauth.Server.IsEnabled)
                {
                    if (HelperConfig.Oauth.Client.IsEnabled)
                    {
                        services.AddAuthentication(options =>
                        {
                            options.DefaultScheme = "Cookies";
                            options.DefaultChallengeScheme = "oidc";
                        })
                        .AddCookie("Cookies")
                        .AddOpenIdConnect("oidc", options =>
                        {
                            options.SignInScheme = "Cookies";

                            options.Authority = HelperConfig.Oauth.Server.Url;
                            options.RequireHttpsMetadata = false;

                            options.ClientId = HelperConfig.Oauth.Client.Id;
                            options.ClientSecret = HelperConfig.Oauth.Client.Secret;
                            options.ResponseType = HelperConfig.Oauth.Client.ResponseType;

                            options.SaveTokens = true;
                            options.GetClaimsFromUserInfoEndpoint = true;
                            //options.UseTokenLifetime = true;
                            var scops = HelperConfig.Oauth.Client.Scope.Split(" ");
                            foreach (var scope in scops)
                            {
                                if (!string.IsNullOrWhiteSpace(scope))
                                {
                                    options.Scope.Add(scope);
                                }
                            }
                        });
                    }


                    // 追加资源服务配置（认证中心）
                    if (HelperConfig.Oauth.Resource.IsEnabled)
                    {
                        services.AddAuthentication("Bearer")
                            .AddIdentityServerAuthentication(options =>
                            {
                                options.Authority = HelperConfig.Oauth.Server.Url;
                                options.RequireHttpsMetadata = false;
                                options.ApiName = HelperConfig.Oauth.Resource.Name;
                                //设置时间偏移量
                                options.JwtValidationClockSkew = TimeSpan.FromMinutes(5);
                            });
                    }
                }
            }


            // 追加接口文档自动生成 
            if (HelperConfig.Swagger.IsEnabled)
            {
                // 注册Swagger生成器，定义一个和多个Swagger 文档
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc(HelperConfig.Swagger.Version, new Info
                    {
                        Title = HelperConfig.Swagger.Title,
                        Version = HelperConfig.Swagger.Version
                    });
                    options.DocInclusionPredicate((docName, description) => true);

                    // Define the BearerAuth scheme that's in use
                    options.AddSecurityDefinition("bearerAuth", new ApiKeyScheme()
                    {
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = "header",
                        Type = "apiKey"
                    });

                    var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var commentsFileName = HelperConfig.Swagger.XmlFile;
                    if(commentsFileName.EndsWith(".xml"))
                    {
                        var commentsFile = System.IO.Path.Combine(baseDirectory, commentsFileName);
                        //将注释的XML文档添加到SwaggerUI中
                        options.IncludeXmlComments(commentsFile);
                    }
                    var commentsOtherFileName = HelperConfig.Swagger.XmlOtherFile;
                    if (commentsOtherFileName.EndsWith(".xml"))
                    {
                        var commentsOtherFile = System.IO.Path.Combine(baseDirectory, commentsOtherFileName);
                        //将注释的XML文档添加到SwaggerUI中
                        options.IncludeXmlComments(commentsOtherFile);
                    }

                });
            }

            // 追加微服务相关配置
            services.AddDiscoveryClient(HelperConfig.Configration);

            return services;
        }

        static List<string> XmlCommentsFilePath
        {
            get
            {
                var basePath = AppDomain.CurrentDomain.BaseDirectory; //PlatformServices.Default.Application.ApplicationBasePath;
                DirectoryInfo d = new DirectoryInfo(basePath);
                FileInfo[] files = d.GetFiles("*.xml");
                var xmls = files.Select(a => Path.Combine(basePath, a.FullName)).ToList();
                return xmls;
            }
        }

        /// <summary>
        /// 启动信息服务扩展
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseIT(this IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //启用中间件服务生成Swagger作为JSON终结点
                app.UseSwagger().UseSwaggerUI(c =>
                {
                    // 启用中间件服务对swagger-ui，指定Swagger JSON终结点
                    c.SwaggerEndpoint("/swagger/" + HelperConfig.Swagger.Version + "/swagger.json", HelperConfig.Swagger.Version);
                });

            }

            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = new FileExtensionContentTypeProvider(CommonClass.FileExtensionContentType)
            });

            app.UseAuthentication();

            app.UseCors("cors");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // 启动微服务支持
            app.UseDiscoveryClient();

            return app;
        }
    }
}
