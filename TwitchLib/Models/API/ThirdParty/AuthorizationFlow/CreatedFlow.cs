﻿using Newtonsoft.Json;

namespace TwitchLib.Models.API.ThirdParty.AuthorizationFlow
{
    public class CreatedFlow
    {
        [JsonProperty(PropertyName = "message")]
        public string Url { get; protected set; }
        [JsonProperty(PropertyName = "id")]
        public string Id { get; protected set; }
    }
}
