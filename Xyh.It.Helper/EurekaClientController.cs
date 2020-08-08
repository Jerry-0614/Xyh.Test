using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Steeltoe.Common.Discovery;
using Xyh.It.Helper.Dto;

namespace Xyh.It.Helper
{
    /// <summary>
    /// 通过Eureka服务器访问微服务
    /// </summary>
    public class EurekaClientController : AbpController
    {
        protected readonly IDiscoveryClient _client;
        protected readonly IConfiguration _configuration;
        protected string _token;
        protected DateTime _tokenExpireTime;

        /// <summary>
        /// Oauth认证取得的TOKEN
        /// </summary>
        public string ApiToken
        {
            get
            {
                if (_token == null || DateTime.Now.CompareTo(_tokenExpireTime) > 0)
                {
                    GetApiToken().Wait();
                }
                return _token;
            }
        }

        public EurekaClientController(IDiscoveryClient client)
        {
            _client = client;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            _configuration = builder.Build();
        }

        /// <summary>
        /// 发送Post请求(JSON做参数）
        /// </summary>
        /// <param name="url">网址</param>
        /// <param name="parameters">参数</param>
        /// <returns></returns>
        public async Task<T> JsonPostAsync<P, T>(string url, P parameters)
        {
            Logger.Debug("JsonPostAsync begin... url:" + url);
            T output = default(T);
            try
            {
                output = await PostAsync<T>(url, JsonConvert.SerializeObject(parameters), true);

            }
            catch (Exception ex)
            {
                Logger.Error("JsonPostAsync exception:", ex);
                throw ex;
            }
            Logger.Debug("JsonPostAsync end...");
            return output;
        }

        /// <summary>
        /// 发送Post请求
        /// </summary>
        /// <param name="url">网址</param>
        /// <param name="parameters">参数</param>
        /// <param name="useJsonParameter">参数是否是JSON，否则为Form形式</param>
        /// <returns></returns>
        protected virtual Task<T> PostAsync<T>(string url, string parameters, bool useJsonParameter = false)
        {
            Logger.Debug("Post url: " + url);
            return Task.Run(() =>
            {
                T result = default(T);
                string rspString = string.Empty;
                using (var http = GenerateHttpClient())
                {
                    try
                    {
                        Logger.Debug("Get http client successfully.");
                        // 要求返回JSON
                        http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));

                        HttpContent formContent;
                        if (useJsonParameter)
                        {
                            formContent = new StringContent(parameters)
                            {
                                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
                            };
                        }
                        else
                        {
                            formContent = new StringContent(parameters)
                            {
                                Headers = { ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded") }
                            };
                        }


                        // 加入验证用TOKEN
                        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiToken);

                        var response = http.PostAsync(url, formContent).Result;
                        //确保HTTP成功状态值
                        response.EnsureSuccessStatusCode();
                        //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                        rspString = response.Content.ReadAsStringAsync().Result;
                        //Logger.Info("Response message: " + rspString);
                        //abp封装的结果集返回 序列化
                        if (rspString.Contains("__abp"))
                        {
                            AbpJsonResult<T> staffResult = JsonConvert.DeserializeObject<AbpJsonResult<T>>(rspString);
                            if (staffResult != null)
                                result = staffResult.Result;
                        }
                        else
                        {
                            result = JsonConvert.DeserializeObject<T>(rspString);
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("PostAsync", ex);
                        throw ex;
                    }
                    return result;
                }
            });

        }

        /// <summary>
        /// 发送delete请求
        /// </summary>
        /// <param name="url">网址</param>
        /// <returns></returns>
        protected virtual Task<T> DeleteAsync<T>(string url)
        {
            Logger.Debug("Delete url: " + url);
            return Task.Run(() =>
            {
                T result = default(T);
                string rspString = string.Empty;
                using (var http = GenerateHttpClient())
                {
                    try
                    {
                        Logger.Debug("Get http client successfully.");
                        // 要求返回JSON
                        http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));

                        // 加入验证用TOKEN
                        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiToken);

                        var response = http.DeleteAsync(url).Result;
                        //确保HTTP成功状态值
                        response.EnsureSuccessStatusCode();
                        //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                        rspString = response.Content.ReadAsStringAsync().Result;
                        AbpJsonResult<T> staffResult = JsonConvert.DeserializeObject<AbpJsonResult<T>>(rspString);
                        result = staffResult.Result;
                        Logger.Info("Response message: " + rspString);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("DeleteAsync", ex);
                        throw ex;
                    }
                    return result;
                }
            });

        }

        /// <summary>
        /// 获取Portal访问Oauth的Token，header里传过来的Token并不是来自于Portal->Oauth
        /// </summary>
        /// <returns></returns>
        protected virtual async Task GetApiToken()
        {
            using (var http = GenerateHttpClient())
            {
                try
                {
                    Logger.Info("Request Portal Token begin...");
                    // 要求返回JSON
                    http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //使用FormUrlEncodedContent做HttpContent
                    List<KeyValuePair<string, string>> cons = new List<KeyValuePair<string, string>>();
                    cons.Add(new KeyValuePair<string, string>("client_id", HelperConfig.Oauth.Client.Id));
                    cons.Add(new KeyValuePair<string, string>("client_secret", HelperConfig.Oauth.Client.Secret));
                    cons.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                    cons.Add(new KeyValuePair<string, string>("scope", HelperConfig.Oauth.Client.Scope));

                    var formContent = new FormUrlEncodedContent(cons);

                    var response = await http.PostAsync(HelperConfig.Oauth.Server.Url + "/connect/token", formContent);
                    //确保HTTP成功状态值
                    response.EnsureSuccessStatusCode();
                    //await异步读取最后的JSON（注意此时gzip已经被自动解压缩了，因为上面的AutomaticDecompression = DecompressionMethods.GZip）
                    string rspString = await response.Content.ReadAsStringAsync();
                    //Logger.Info("Response full message " + rspString);
                    var tokenResult = JsonConvert.DeserializeObject<TokenResult>(rspString);
                    _token = tokenResult.Access_Token;
                    _tokenExpireTime = DateTime.Now.AddSeconds(tokenResult.Expires_In - 120);
                    Logger.Info("Request Portal Token: " + _token);
                }
                catch (Exception ex)
                {
                    Logger.Error("GetApiToken", ex);
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 生成HttpClient实例
        /// </summary>
        /// <returns></returns>
        protected virtual HttpClient GenerateHttpClient()
        {

            HttpClient client = null;
            try
            {
                // 设置HttpClientHandler的AutomaticDecompression
                var handler = new DiscoveryHttpClientHandler(_client);
                handler.AutomaticDecompression = DecompressionMethods.GZip;

                client = new HttpClient(handler);
            }
            catch (Exception ex)
            {
                Logger.Error("GenerateHttpClient", ex);
                throw ex;
            }
            return client;
        }

    }
}
