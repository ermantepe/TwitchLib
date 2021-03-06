﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using TwitchLib.Enums;

namespace TwitchLib.Common
{
    /// <summary>Static class of helper functions used around the project.</summary>
    public static class Helpers
    {
        /// <summary>
        /// Function that extracts just the token for consistency
        /// </summary>
        /// <param name="token">Full token string</param>
        /// <returns></returns>
        public static string FormatOAuth(string token)
        {
            return token.Contains(" ") ? token.Split(' ')[1] : token;
        }

        /// <summary>
        /// Function to check if a jtoken is null.
        /// Credits: http://stackoverflow.com/questions/24066400/checking-for-empty-null-jtoken-in-a-jobject
        /// </summary>
        /// <param name="token">JToken to check if null or not.</param>
        /// <returns>Boolean on whether true or not.</returns>
        public static bool JsonIsNullOrEmpty(JToken token)
        {
            return token == null ||
                   token.Type == JTokenType.Array && !token.HasValues ||
                   token.Type == JTokenType.Object && !token.HasValues ||
                   token.Type == JTokenType.String && token.ToString() == string.Empty ||
                   token.Type == JTokenType.Null;
        }

        /// <summary>Takes date time string received from Twitch API and converts it to DateTime object.</summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime DateTimeStringToObject(string dateTime)
        {
            return dateTime == null ? new DateTime() : Convert.ToDateTime(dateTime);
        }

        /// <summary>
        /// Parses out strings that have quotes, ideal for commands that use quotes for parameters
        /// </summary>
        /// <param name="message">Input string to attempt to parse.</param>
        /// <returns>List of contents of quotes from the input string</returns>
        public static List<string> ParseQuotesAndNonQuotes(string message)
        {
            var args = new List<string>();

            // Return if empty string
            if (message == "")
                return new List<string>();

            var previousQuoted = message[0] != '"';
            // Parse quoted text as a single argument
            foreach (var arg in message.Split('"'))
            {
                if (string.IsNullOrEmpty(arg))
                    continue;

                // This arg is a quoted arg, add it right away
                if (!previousQuoted)
                {
                    args.Add(arg);
                    previousQuoted = true;
                    continue;
                }

                if (!arg.Contains(" "))
                    continue;

                // This arg is non-quoted, iterate through each split and add it if it's not empty/whitespace
                foreach (var dynArg in arg.Split(' '))
                {
                    if (string.IsNullOrWhiteSpace(dynArg))
                        continue;

                    args.Add(dynArg);
                    previousQuoted = false;
                }
            }
            return args;
        }

        public static string AuthScopesToString(AuthScopes scope)
        {
            switch (scope)
            {
                case AuthScopes.Channel_Check_Subscription:
                    return "channel_check_subscription";
                case AuthScopes.Channel_Commercial:
                    return "channel_commercial";
                case AuthScopes.Channel_Editor:
                    return "channel_editor";
                case AuthScopes.Channel_Feed_Edit:
                    return "channel_feed_edit";
                case AuthScopes.Channel_Feed_Read:
                    return "channel_feed_read";
                case AuthScopes.Channel_Read:
                    return "channel_read";
                case AuthScopes.Channel_Stream:
                    return "channel_stream";
                case AuthScopes.Channel_Subscriptions:
                    return "channel_subscriptions";
                case AuthScopes.Chat_Login:
                    return "chat_login";
                case AuthScopes.Collections_Edit:
                    return "collections_edit";
                case AuthScopes.Communities_Edit:
                    return "communities_edit";
                case AuthScopes.Communities_Moderate:
                    return "communities_moderate";
                case AuthScopes.User_Blocks_Edit:
                    return "user_blocks_edit";
                case AuthScopes.User_Blocks_Read:
                    return "user_blocks_read";
                case AuthScopes.User_Follows_Edit:
                    return "user_follows_edit";
                case AuthScopes.User_Read:
                    return "user_read";
                case AuthScopes.User_Subscriptions:
                    return "user_subscriptions";
                case AuthScopes.Viewing_Activity_Read:
                    return "viewing_activity_read";
                case AuthScopes.OpenId:
                    return "openid";
                case AuthScopes.Helix_User_Edit:
                    return "user:edit";
                case AuthScopes.Helix_User_Read_Email:
                    return "user:read:email";
                default:
                    return "";
            }
        }

        public static AuthScopes StringToScope(string scope)
        {
            switch (scope)
            {
                case "user_read":
                    return AuthScopes.User_Read;
                case "user_blocks_edit":
                    return AuthScopes.User_Blocks_Edit;
                case "user_blocks_read":
                    return AuthScopes.User_Blocks_Read;
                case "user_follows_edit":
                    return AuthScopes.User_Follows_Edit;
                case "channel_read":
                    return AuthScopes.Channel_Read;
                case "channel_commercial":
                    return AuthScopes.Channel_Commercial;
                case "channel_stream":
                    return AuthScopes.Channel_Subscriptions;
                case "channel_subscriptions":
                    return AuthScopes.Channel_Subscriptions;
                case "user_subscriptions":
                    return AuthScopes.User_Subscriptions;
                case "channel_check_subscription":
                    return AuthScopes.Channel_Check_Subscription;
                case "chat_login":
                    return AuthScopes.Chat_Login;
                case "channel_feed_read":
                    return AuthScopes.Channel_Feed_Read;
                case "channel_feed_edit":
                    return AuthScopes.Channel_Feed_Edit;
                case "collections_edit":
                    return AuthScopes.Collections_Edit;
                case "communities_edit":
                    return AuthScopes.Communities_Edit;
                case "communities_moderate":
                    return AuthScopes.Communities_Moderate;
                case "viewing_activity_read":
                    return AuthScopes.Viewing_Activity_Read;
                default:
                    throw new Exception("Unknown scope");
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}