﻿using Newtonsoft.Json;

namespace TwitchLib.Models.API.v5.Videos
{
    public class VideoCreation
    {
        #region Upload
        [JsonProperty(PropertyName = "upload")]
        public VideoUpload Upload { get; protected set; }
        #endregion
        #region Video
        [JsonProperty(PropertyName = "video")]
        public Video Video { get; protected set; }
        #endregion
    }
}
