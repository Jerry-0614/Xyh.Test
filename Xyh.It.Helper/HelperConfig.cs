using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Xyh.It.Helper
{
    public static class HelperConfig
    {
        public static class Oauth
        {
            public static bool IsEnabled { get; set; }
            public static class Server
            {
                public static bool IsEnabled { get; set; }
                public static string Url { get; set; }
            }
            public static class Client
            {
                public static bool IsEnabled { get; set; }
                public static string Id { get; set; }
                public static string Secret { get; set; }
                public static string ResponseType { get; set; }
                public static string Scope { get; set; }
            }
            public static class Resource
            {
                public static bool IsEnabled { get; set; }
                public static string Name { get; set; }
            }
        }

        public static class Swagger
        {
            public static bool IsEnabled { get; set; }
            public static string Version { get; set; }

            public static string Title { get; set; }

            public static string XmlFile { get; set; }
            public static string XmlOtherFile { get; set; }
        }

        private static class Dummy
        {
            public static bool IsEnabled { get; set; }

            public static string XyhMainUrl { get; set; }

   
        }

        public static class Sms
        {
            public static class Url
            {
                public static string SmsUrl { get; set; }
                public static string SmsVerifyUrl { get; set; }
                public static string SmsBatchUrl { get; set; }
                public static string VerifyUrl { get; set; }
            }

            public static class Sign
            {
                public static string Gongheyuan { get; set; }
            }
        }

        /// <summary>
        /// Redis Api
        /// </summary>
        public static class Redis
        {
            /// <summary>
            /// Redis开关
            /// </summary>
            public static bool RedisEnabled { get; set; }
            /// <summary>
            /// 缓存方法结果集开关
            /// </summary>
            public static bool CacheEnabled { get; set; }
            /// <summary>
            /// 链接地址
            /// </summary>
            public static string ConnectionString { get; set; }
            /// <summary>
            /// DatabaseId
            /// </summary>
            public static int DatabaseId { get; set; }
            /// <summary>
            /// 过期时间：分钟
            /// </summary>
            public static int ExpireTime { get; set; }
        }

        public static class JPush
        {
            public static string AppKey { get; set; }
            public static string MasterSecret { get; set; }
            public static bool IsApnsProduction { get; set; }
            public static bool IsEnabled { get; set; }
        }
        
        /// <summary>
        /// 百度翻译配置
        /// </summary>
        public static class TranslateApi
        {
            public static string AppId { get; set; }
            public static string AppSecret { get; set; }
            public static string Url { get; set; }
        }
        
        /// <summary>
        /// 其它相关配置
        /// </summary>
        public static class OtherApi
        {
            /// <summary>
            /// 域名
            /// </summary>
            public static string Domain { get; set; }
            /// <summary>
            /// 最大值
            /// </summary>
            public static string MaximumValue { get; set; }
            /// <summary>
            /// 最小值
            /// </summary>
            public static string MinimumValue { get; set; }

        }
        
        /// <summary>
        /// 加密安全相关配置
        /// </summary>
        public static class CryptApi
        {
            /// <summary>
            /// RSA非对称加密的公钥
            /// </summary>
            public static string RSA_PublicKey { get; set; }
            /// <summary>
            /// RSA非对称加密的私钥
            /// </summary>
            public static string RSA_PrivateKey { get; set; }
        }
        
        /// <summary>
        /// 微服务名称
        /// </summary>
        public static class MicroServiceName
        {
            /// <summary>
            /// 认证中心
            /// </summary>
            public static string Oauth
            {
                get
                {
                    return HelperConfig.Oauth.Server.Url ?? "Xyh.Oauth";
                }
            }
            /// <summary>
            /// 企业门户
            /// </summary>
            public static string XyhMain
            {
                get
                {
                    return HelperConfig.Dummy.XyhMainUrl ?? "Xyh.Main";
                }
            }
            
        }

        public static IConfiguration Configration { get; set; }
        
        public static void Load()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configration = builder.Build();
            if (Configration.GetSection("oauth") != null)
            {
                Oauth.IsEnabled = true;
                if (Configration.GetSection("oauth:server") != null)
                {
                    Oauth.Server.IsEnabled = true;
                    Oauth.Server.Url = Configration.GetValue<string>("oauth:server:url");
                }
                // 客户端配置（认证中心）
                if (Configration.GetSection("oauth:client") != null)
                {
                    Oauth.Client.IsEnabled = true;
                    Oauth.Client.Id = Configration.GetValue<string>("oauth:client:id");
                    Oauth.Client.Secret = Configration.GetValue<string>("oauth:client:secret");
                    Oauth.Client.ResponseType = Configration.GetValue<string>("oauth:client:responseType");
                    Oauth.Client.Scope = Configration.GetValue<string>("oauth:client:scope", "");
                }

                // 资源服务配置（认证中心）
                if (Configration.GetSection("oauth:resource") != null)
                {
                    Oauth.Resource.IsEnabled = true;
                    Oauth.Resource.Name = Configration.GetValue<string>("oauth:resource:name");
                }

            }
            if (Configration.GetSection("Sms") != null)
            {
                if (Configration.GetSection("Sms:Url") != null)
                {
                    Sms.Url.SmsUrl = Configration.GetValue<string>("Sms:Url:SmsUrl");
                    Sms.Url.SmsVerifyUrl = Configration.GetValue<string>("Sms:Url:SmsVerifyUrl");
                    Sms.Url.SmsBatchUrl = Configration.GetValue<string>("Sms:Url:SmsBatchUrl");
                    Sms.Url.VerifyUrl = Configration.GetValue<string>("Sms:Url:VerifyUrl");
                }

                if (Configration.GetSection("Sms:Sign") != null)
                {
                    Sms.Sign.Gongheyuan = Configration.GetValue<string>("Sms:Sign:Gongheyuan");
                }
            }
            // 文档自动生成 
            if (Configration.GetSection("swagger") != null)
            {
                Swagger.IsEnabled = true;
                Swagger.Version = Configration.GetValue<string>("swagger:version", "v1");
                Swagger.Title = Configration.GetValue<string>("swagger:title", "unknown");
                Swagger.XmlFile = Configration.GetValue<string>("swagger:xmlFile", "unknown");
                Swagger.XmlOtherFile = Configration.GetValue<string>("swagger:xmlOtherFile", "unknown");
            }

            // 微服务url 
            if (Configration.GetSection("dummy") != null)
            {
                Dummy.IsEnabled = true;
                Dummy.XyhMainUrl = Configration.GetValue<string>("dummy:xyh.main");
                
            }

            // jiguang推送 
            if (Configration.GetSection("JPush") != null)
            {
                JPush.AppKey = Configration.GetValue<string>("JPush:AppKey");
                JPush.MasterSecret = Configration.GetValue<string>("JPush:MasterSecret");
                JPush.IsApnsProduction = Configration.GetValue<bool>("JPush:IsApnsProduction");
                JPush.IsEnabled = Configration.GetValue<bool>("JPush:IsEnabled");
            }

            // Redis
            if (Configration.GetSection("Redis") != null)
            {
                Redis.CacheEnabled = Configration.GetValue<bool>("Redis:CacheEnabled");
                Redis.RedisEnabled = Configration.GetValue<bool>("Redis:RedisEnabled");
                Redis.ConnectionString = Configration.GetValue<string>("Redis:ConnectionString");
                Redis.DatabaseId = Configration.GetValue<int>("Redis:DatabaseId");
                Redis.ExpireTime = Configration.GetValue<int>("Redis:ExpireTime");
            }
            
            // 加密安全相关配置
            if (Configration.GetSection("CryptApi") != null)
            {
                CryptApi.RSA_PublicKey = Configration.GetValue<string>("CryptApi:RSA_PublicKey");
                CryptApi.RSA_PrivateKey = Configration.GetValue<string>("CryptApi:RSA_PrivateKey");
            }
            
            // 百度翻译
            if (Configration.GetSection("TranslateApi") != null)
            {
                TranslateApi.AppId = Configration.GetValue<string>("TranslateApi:AppId");
                TranslateApi.AppSecret = Configration.GetValue<string>("TranslateApi:AppSecret");
                TranslateApi.Url = Configration.GetValue<string>("TranslateApi:Url");
            }
            
        }
    }
}
