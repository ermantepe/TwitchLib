﻿using Newtonsoft.Json;

namespace TwitchLib.Models.API.v5.Users
{
    public class UserNotifications
    {
        #region Email
        [JsonProperty(PropertyName = "email")]
        public bool Email { get; protected set; }
        #endregion
        #region Push
        [JsonProperty(PropertyName = "push")]
        public bool Push { get; protected set; }
        #endregion
    }
}
