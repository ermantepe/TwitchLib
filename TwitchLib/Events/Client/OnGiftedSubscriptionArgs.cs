﻿using System;
using TwitchLib.Models.Client;

namespace TwitchLib.Events.Client
{
    public class OnGiftedSubscriptionArgs : EventArgs
    {
        public GiftedSubscription GiftedSubscription;
    }
}
