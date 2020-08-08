using Abp.Application.Services;
using Abp.Dependency;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xyh.It.Helper;
using Xyh.It.Helper.Dto;

namespace Xyh.Portal.Helper
{
    public class SsoHttpClientHelper : ApplicationService, ITransientDependency
    {
        protected string _token;
        protected DateTime _tokenExpireTime;
        private string _tokenUrl = HelperConfig.Oauth.Server.Url;
        private string _clientId = HelperConfig.Oauth.Client.Id;
        private string _clientSecret = HelperConfig.Oauth.Client.Secret;
        private string _grantType = "client_credentials";// HelperConfig.Oauth.Client.GrantType;AsmConfigurations.AsmGrant.GrantType;//
        private string _scope = HelperConfig.Oauth.Client.Scope;

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

        #region httpClient
        /*
        /// <summary>
        /// post 请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="parameterts"></param>
        /// <param name="useJsonParameter"></param>
        /// <returns></returns>
        public Task<T> PostAsync<T>(string url, string parameterts, bool useJsonParameter = true)
        {
            return Task.Run(() =>
            {
                T result = default(T);
                string rspString = string.Empty;
                try
                {
                    using (var http = new HttpClient())
                    {
                        HttpContent formContent;
                        if (useJsonParameter)
                        {
                            formContent = new StringContent(parameterts)
                            {
                                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
                            };
                        }
                        else
                        {
                            formContent = new StringContent(parameterts)
                            {
                                Headers = { ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded") }
                            };
                        }

                        // 加入验证用TOKEN
                        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiToken);

                        var response = http.PostAsync(url, formContent).Result;
                        //确保HTTP成功状态值
                        response.EnsureSuccessStatusCode();
                        //await异步读取最后的JSON
                        rspString = response.Content.ReadAsStringAsync().Result;
                        //Logger.Info("Response message: " + rspString);

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
                }
                catch (Exception ex)
                {
                    Logger.Error("PostAsync", ex);
                }
                return result;
            });
        }


        /// <summary>
        /// 发送Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public async Task<string> PostAsync(string url, string content, Dictionary<string, string> headers, string contentType = "application/json")
        {
            string result = string.Empty;
            try
            {
                Logger.Info("Post url: " + url);
                if (url.StartsWith("https"))
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                HttpContent httpContent = new StringContent(content, Encoding.UTF8, contentType);//, "application/x-www-form-urlencoded");
                if (headers != null)
                {
                    foreach (var h in headers)
                    {
                        httpContent.Headers.Add(h.Key, h.Value);
                    }
                }

                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.PostAsync(url, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                    Logger.Info(result);
                }
                else
                {
                    Logger.Warn("Request post fail: " + response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.Error("PostAsync", ex);
            }
            return result;
        }

        public async Task<byte[]> PostAsync1(string url, string content, Dictionary<string, string> headers, string contentType = "application/json")
        {
            byte[] result = null;
            try
            {
                Logger.Info("Post url: " + url);
                if (url.StartsWith("https"))
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                HttpContent httpContent = new StringContent(content, Encoding.UTF8, contentType);//, "application/x-www-form-urlencoded");
                if (headers != null)
                {
                    foreach (var h in headers)
                    {
                        httpContent.Headers.Add(h.Key, h.Value);
                    }
                }

                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.PostAsync(url, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsByteArrayAsync();
                    Logger.Info(Convert.ToBase64String(result));
                }
                else
                {
                    Logger.Warn("Request post fail: " + response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.Error("PostAsync", ex);
            }
            return result;
        }
        */
        #endregion

        /// <summary>
        /// post 请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="parameterts"></param>
        /// <param name="useJsonParameter"></param>
        /// <returns></returns>
        public Task<T> PostAsync<T>(string url, string parameterts, bool useJsonParameter = true)
        {
            return Task.Run(() =>
            {
                Logger.Debug($"{url}\r\n{parameterts}\r\n{useJsonParameter}");

                T result = default(T);
                string rspString = string.Empty;
                try
                {
                    using (var http = new HttpClient())
                    {
                        HttpContent formContent;
                        if (useJsonParameter)
                        {
                            formContent = new StringContent(parameterts)
                            {
                                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
                            };
                        }
                        else
                        {
                            formContent = new StringContent(parameterts)
                            {
                                Headers = { ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded") }
                            };
                        }

                        // 加入验证用TOKEN
                        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiToken);

                        Logger.Debug($"url: {url}\r\nformContent :{formContent}");
                        var response = http.PostAsync(url, formContent).Result;
                        //确保HTTP成功状态值
                        response.EnsureSuccessStatusCode();
                        //await异步读取最后的JSON                        
                        rspString = response.Content.ReadAsStringAsync().Result;

                        Logger.Debug($"rspString :{rspString}");

                        if (typeof(T) == typeof(string))
                        {
                            result = (T)Convert.ChangeType(rspString, typeof(T));
                        }
                        else
                        {
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

                        //if (rspString.Contains("__abp"))
                        //{
                        //    AbpJsonResult<T> staffResult = JsonConvert.DeserializeObject<AbpJsonResult<T>>(rspString);
                        //    if (staffResult != null)
                        //        result = staffResult.Result;
                        //}
                        //else
                        //{
                        //    if (typeof(T) == typeof(string))
                        //        result = (T)Convert.ChangeType(rspString, typeof(T));
                        //    else
                        //        result = JsonConvert.DeserializeObject<T>(rspString);
                        //}
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"PostAsync \r\n{url} \r\n{typeof(T)} \r\n{rspString}", ex);
                }
                return result;
            });
        }
        /// <summary>
        /// 向OMS系统Post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="omsTenantId"></param>
        /// <param name="parameterts"></param>
        /// <param name="useJsonParameter"></param>
        /// <returns></returns>
        public Task<T> PostAsync<T>(string url, string omsTenantId, string parameterts, bool useJsonParameter = true)
        {
            return Task.Run(() =>
            {
                T result = default(T);
                string rspString = string.Empty;
                try
                {
                    if (string.IsNullOrWhiteSpace(parameterts)) parameterts = string.Empty;

                    using (var http = new HttpClient())
                    {
                        HttpContent formContent;

                        if (useJsonParameter)
                        {
                            formContent = new StringContent(parameterts)
                            {
                                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
                            };
                        }
                        else
                        {
                            formContent = new StringContent(parameterts)
                            {
                                Headers = { ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded") }
                            };
                        }

                        if (!string.IsNullOrWhiteSpace(omsTenantId))
                        {
                            formContent.Headers.Add("Oms-Tenant-Id", omsTenantId);
                        }

                        // 加入验证用TOKEN
                        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiToken);

                        var response = http.PostAsync(url, formContent).Result;
                        //确保HTTP成功状态值
                        response.EnsureSuccessStatusCode();
                        //await异步读取最后的JSON                        
                        rspString = response.Content.ReadAsStringAsync().Result;

                        if (typeof(T) == typeof(string))
                        {
                            result = (T)Convert.ChangeType(rspString, typeof(T));
                        }
                        else
                        {
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
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"PostAsync 出现异常, 但调用过程未终止: \r\n{url} \r\n{typeof(T)} \r\n{rspString}", ex);
                }
                return result;
            });
        }


        public T GetConfigs<T>(string defaultVaule)
        {
            T ret = (T)Convert.ChangeType(defaultVaule, typeof(T));

            return ret;
        }

        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        protected virtual async Task GetApiToken()
        {
            using (var http = new HttpClient())
            {
                try
                {
                    Logger.Info("Request Portal Token begin...");
                    // 要求返回JSON
                    http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //使用FormUrlEncodedContent做HttpContent
                    List<KeyValuePair<string, string>> cons = new List<KeyValuePair<string, string>>();
                    cons.Add(new KeyValuePair<string, string>("client_id", _clientId));
                    cons.Add(new KeyValuePair<string, string>("client_secret", _clientSecret));
                    cons.Add(new KeyValuePair<string, string>("grant_type", _grantType));
                    cons.Add(new KeyValuePair<string, string>("scope", _scope));

                    var formContent = new FormUrlEncodedContent(cons);

                    var response = await http.PostAsync(_tokenUrl + "/connect/token", formContent);
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
        /// post 请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="parameterts"></param>
        /// <param name="useJsonParameter"></param>
        /// <returns></returns>
        public Task<T> PostAsyncNoToken<T>(string url, string parameterts, bool useJsonParameter = true)
        {
            return Task.Run(() =>
            {
                T result = default(T);
                string rspString = string.Empty;
                try
                {
                    using (var http = new HttpClient())
                    {
                        HttpContent formContent;
                        if (useJsonParameter)
                        {
                            formContent = new StringContent(parameterts)
                            {
                                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
                            };
                        }
                        else
                        {
                            formContent = new StringContent(parameterts)
                            {
                                Headers = { ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded") }
                            };
                        }

                        // 加入验证用TOKEN
                        //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ApiToken);

                        var response = http.PostAsync(url, formContent).Result;
                        //确保HTTP成功状态值
                        response.EnsureSuccessStatusCode();
                        //await异步读取最后的JSON                        
                        rspString = response.Content.ReadAsStringAsync().Result;
                        //Logger.Info("Response message: " + rspString);

                        if (typeof(T) == typeof(string))
                        {
                            result = (T)Convert.ChangeType(rspString, typeof(T));
                        }
                        else
                        {
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
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error($"PostAsync \r\n{url} \r\n{typeof(T)} \r\n{rspString}", ex);
                }
                return result;
            });
        }
    }
}
