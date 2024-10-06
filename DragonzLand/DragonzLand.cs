using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DragonzLandBot
{

    public class DragonzLandQuery
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Auth { get; set; }
    }

    public class DragonzLandAuthRequest
    {
        [JsonPropertyName("initData")]
        public string InitData { get; set; }
    }

    public class DragonzLandAuthResponse
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }

    public class DragonzLandMeResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("telegramUserId")]
        public long TelegramUserId { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("diamonds")]
        public int Diamonds { get; set; }
        [JsonPropertyName("coins")]
        public int Coins { get; set; }
        [JsonPropertyName("power")]
        public int Power { get; set; }
        [JsonPropertyName("feedCoins")]
        public int FeedCoins { get; set; }
        [JsonPropertyName("level")]
        public int Level { get; set; }
        [JsonPropertyName("energy")]
        public int Energy { get; set; }
        [JsonPropertyName("energyLimit")]
        public int EnergyLimit { get; set; }
        [JsonPropertyName("tasks")]
        public List<DragonzLandMeTask> Tasks { get; set; }
        [JsonPropertyName("boosts")]
        public List<DragonzLandMeBoost> Boosts { get; set; }
        [JsonPropertyName("cards")]
        public List<DragonzLandMeCard> Cards { get; set; }
    }

    public class DragonzLandMeTask
    {
        [JsonPropertyName("taskId")]
        public string TaskId { get; set; }
        [JsonPropertyName("level")]
        public int Level { get; set; }
        [JsonPropertyName("attempts")]
        public int Attempts { get; set; }
        [JsonPropertyName("attemptedAt")]
        public DateTime? AttemptedAt { get; set; }
        [JsonPropertyName("activeAt")]
        public DateTime? ActiveAt { get; set; }
    }

    public class DragonzLandMeBoost
    {
        [JsonPropertyName("boostId")]
        public string BoostId { get; set; }
        [JsonPropertyName("level")]
        public int Level { get; set; }
        [JsonPropertyName("attempts")]
        public int Attempts { get; set; }
        [JsonPropertyName("attemptedAt")]
        public DateTime? AttemptedAt { get; set; }
        [JsonPropertyName("activeAt")]
        public DateTime? ActiveAt { get; set; }
    }

    public class DragonzLandMeCard
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("cardId")]
        public string CardId { get; set; }
        [JsonPropertyName("level")]
        public int Level { get; set; }
        [JsonPropertyName("attemptedAt")]
        public DateTime? AttemptedAt { get; set; }
        [JsonPropertyName("activeAt")]
        public DateTime? ActiveAt { get; set; }
    }

    public class DragonzLandTaskResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("recurrence")]
        public string Recurrence { get; set; }
        [JsonPropertyName("attemptsLimit")]
        public int AttemptsLimit { get; set; }
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        [JsonPropertyName("featured")]
        public bool Featured { get; set; }
        [JsonPropertyName("pinned")]
        public bool Pinned { get; set; }
        [JsonPropertyName("listed")]
        public bool Listed { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public class DragonzLandTaskDoneRequest
    {
        [JsonPropertyName("taskId")]
        public string TaskId { get; set; }
    }

    public class DragonzLandFeedRequest
    {
        [JsonPropertyName("feedCount")]
        public int FeedCount { get; set; }
    }

    public class DragonzLandBoostResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        [JsonPropertyName("comingSoon")]
        public bool ComingSoon { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("attemptsLimit")]
        public int AttemptsLimit { get; set; }
        [JsonPropertyName("recurrence")]
        public string Recurrence { get; set; }
    }

    public class DragonzLandBoostBuyRequest
    {
        [JsonPropertyName("boostId")]
        public string BoostId { get; set; }
    }

    public class DragonzLandCardResponse
    {

    }
}
