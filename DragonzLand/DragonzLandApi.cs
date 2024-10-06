using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DragonzLandBot
{

    public class DragonzLandApi
    {
        private readonly HttpClient client;

        public DragonzLandApi(int Mode, string queryId, int queryIndex)
        {
            client = new HttpClient() { Timeout = new TimeSpan(0, 0, 30) };
            if (Mode == 1)
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {queryId}");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US");
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            client.DefaultRequestHeaders.Add("Pragma", "no-cache");
            client.DefaultRequestHeaders.Add("Priority", "u=1, i");
            client.DefaultRequestHeaders.Add("Origin", "https://bot.dragonz.land");
            client.DefaultRequestHeaders.Add("Referer", "https://bot.dragonz.land/");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
            client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-site");
            client.DefaultRequestHeaders.Add("Sec-Ch-Ua", "\"Google Chrome\";v=\"125\", \"Chromium\";v=\"125\", \"Not.A/Brand\";v=\"24\"");
            client.DefaultRequestHeaders.Add("User-Agent", Tools.getUserAgents(queryIndex));
            client.DefaultRequestHeaders.Add("accept", "*/*");
            client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0");
            client.DefaultRequestHeaders.Add("sec-ch-ua-platform", $"\"{Tools.getUserAgents(queryIndex, true)}\"");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        }

        public async Task<HttpResponseMessage> DLAPIGet(string requestUri)
        {
            try
            {
                return await client.GetAsync(requestUri);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.ExpectationFailed, ReasonPhrase = ex.Message };
            }
        }

        public async Task<HttpResponseMessage> DLAPIPost(string requestUri, HttpContent content)
        {
            try
            {
                return await client.PostAsync(requestUri, content);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.ExpectationFailed, ReasonPhrase = ex.Message };
            }
        }
    }
}