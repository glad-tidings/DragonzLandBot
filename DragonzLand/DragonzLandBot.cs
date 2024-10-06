using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DragonzLandBot
{

    public class DragonzLandBot
    {

        private readonly DragonzLandQuery PubQuery;
        private readonly string AccessToken;
        public readonly bool HasError;
        public readonly string ErrorMessage;

        public DragonzLandBot(DragonzLandQuery Query)
        {
            PubQuery = Query;
            var GetToken = DragonzLandGetToken().Result;
            if (GetToken is not null)
            {
                AccessToken = GetToken.AccessToken;
                HasError = false;
                ErrorMessage = "";
            }
            else
            {
                HasError = true;
                ErrorMessage = "get token failed";
            }
        }

        private async Task<DragonzLandAuthResponse> DragonzLandGetToken()
        {
            var DLAPI = new DragonzLandApi(0, PubQuery.Auth, PubQuery.Index);
            var request = new DragonzLandAuthRequest() { InitData = PubQuery.Auth };
            string serializedRequest = JsonSerializer.Serialize(request);
            var serializedRequestContent = new StringContent(serializedRequest, Encoding.UTF8, "application/json");
            var httpResponse = await DLAPI.DLAPIPost("https://bot.dragonz.land/api/auth/telegram", serializedRequestContent);
            if (httpResponse is not null)
            {
                if (httpResponse.IsSuccessStatusCode)
                {
                    var responseStream = await httpResponse.Content.ReadAsStreamAsync();
                    var responseJson = await JsonSerializer.DeserializeAsync<DragonzLandAuthResponse>(responseStream);
                    return responseJson;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<DragonzLandMeResponse> DragonzLandUserDetail()
        {
            var rDLAPI = new DragonzLandApi(1, AccessToken, PubQuery.Index);
            var rewardResponse = await rDLAPI.DLAPIGet("https://bot.dragonz.land/api/tasks/welcome-reward");
            Thread.Sleep(3000);
            var DLAPI = new DragonzLandApi(1, AccessToken, PubQuery.Index);
            var httpResponse = await DLAPI.DLAPIGet("https://bot.dragonz.land/api/me");
            if (httpResponse is not null)
            {
                if (httpResponse.IsSuccessStatusCode)
                {
                    var responseStream = await httpResponse.Content.ReadAsStreamAsync();
                    var responseJson = await JsonSerializer.DeserializeAsync<DragonzLandMeResponse>(responseStream);
                    return responseJson;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<List<DragonzLandTaskResponse>> DragonzLandTasks()
        {
            var DLAPI = new DragonzLandApi(1, AccessToken, PubQuery.Index);
            var httpResponse = await DLAPI.DLAPIGet("https://bot.dragonz.land/api/tasks");
            if (httpResponse is not null)
            {
                if (httpResponse.IsSuccessStatusCode)
                {
                    var responseStream = await httpResponse.Content.ReadAsStreamAsync();
                    var responseJson = await JsonSerializer.DeserializeAsync<List<DragonzLandTaskResponse>>(responseStream);
                    return responseJson;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DragonzLandTasksVerify(string taskId)
        {
            var DLAPI = new DragonzLandApi(1, AccessToken, PubQuery.Index);
            var request = new DragonzLandTaskDoneRequest() { TaskId = taskId };
            string serializedRequest = JsonSerializer.Serialize(request);
            var serializedRequestContent = new StringContent(serializedRequest, Encoding.UTF8, "application/json");
            var httpResponse = await DLAPI.DLAPIPost("https://bot.dragonz.land/api/me/tasks/verify", serializedRequestContent);
            if (httpResponse is not null)
            {
                if (httpResponse.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DragonzLandFeed(int feedCount)
        {
            var DLAPI = new DragonzLandApi(1, AccessToken, PubQuery.Index);
            var request = new DragonzLandFeedRequest() { FeedCount = feedCount };
            string serializedRequest = JsonSerializer.Serialize(request);
            var serializedRequestContent = new StringContent(serializedRequest, Encoding.UTF8, "application/json");
            var httpResponse = await DLAPI.DLAPIPost("https://bot.dragonz.land/api/me/feed", serializedRequestContent);
            if (httpResponse is not null)
            {
                if (httpResponse.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DragonzLandBuyBoost(string boostId)
        {
            var DLAPI = new DragonzLandApi(1, AccessToken, PubQuery.Index);
            var request = new DragonzLandBoostBuyRequest() { BoostId = boostId };
            string serializedRequest = JsonSerializer.Serialize(request);
            var serializedRequestContent = new StringContent(serializedRequest, Encoding.UTF8, "application/json");
            var httpResponse = await DLAPI.DLAPIPost("https://bot.dragonz.land/api/me/boosts/buy", serializedRequestContent);
            if (httpResponse is not null)
            {
                if (httpResponse.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}