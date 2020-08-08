using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Xyh.Portal.Helper
{
    public class HttpClientHelper:PortalAppServiceBase
    {
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
                Logger.Debug("Post url: " + url);
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
                    Logger.Debug(result);
                }
                else
                {
                    Logger.Warn("Request post fail: " + response.StatusCode.ToString());
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("PostAsync", ex);
            }
            return result;
        }

        public async Task<string> PostFilesAsync(string url, MultipartFormDataContent multiContent)
        {
            string result = string.Empty;
            try
            {
                Logger.Debug("Post url: " + url);
                if (url.StartsWith("https"))
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.PostAsync(url, multiContent);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                    Logger.Debug(result);
                }
                else
                {
                    Logger.Warn("Request post fail: " + response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.Error("PostFilesAsync", ex);
            }
            Logger.Debug("Post files result:" + result);
            return result;
        }


        /// <summary>
        /// 发送Put请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public async Task<string> PutAsync(string url, string content, Dictionary<string, string> headers, string contentType = "application/json")
        {
            string result = string.Empty;
            try
            {
                Logger.Debug("Put url: " + url);
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
                HttpResponseMessage response = await httpClient.PutAsync(url, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                    Logger.Debug(result);
                }
                else
                {
                    Logger.Warn("Request put fail: " + response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.Error("PostAsync", ex);
            }
            return result;
        }
        /// <summary>
        /// 发送Delete请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        //public async Task<string> DeleteAsync(string url, string content, Dictionary<string, string> headers, string contentType = "application/json")
        public async Task<string> DeleteAsync(string url)
        {
            string result = string.Empty;
            try
            {
                Logger.Debug("Delete url: " + url);
                if (url.StartsWith("https"))
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                //HttpContent httpContent = new StringContent(content, Encoding.UTF8, contentType);//, "application/x-www-form-urlencoded");
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                    Logger.Debug(result);
                }
                else
                {
                    Logger.Warn("Request delete fail: " + response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.Error("DeleteAsync", ex);
            }
            return result;
        }
        /// <summary>
        /// 发送Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<string> GetAsync(string url)
        {
            string result = string.Empty;
            try
            {
                Logger.Debug("Get url: " + url);
                if (url.StartsWith("https"))
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                    Logger.Debug(result);
                }
                else
                {
                    Logger.Warn("Request get fail: " + response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.Error("GetAsync", ex);
            }
            return result;
        }
    }
}
