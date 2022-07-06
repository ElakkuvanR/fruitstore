﻿using OrderCloud.SDK;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace FruitStore.OrderCloud.Api
{
    /// <summary>
    /// Represents data inside a specific OrderCloud json web token 
    /// </summary>
    public class DecodedToken
    {
        /// <summary>
        /// The raw jwt access token 
        /// </summary>
        public string AccessToken { get; }
        /// <summary>
        /// The signing key ID of the token. "mpid" claim. Null when Portal issued the token. 
        /// </summary>
        public string KeyID { get; }
        /// <summary>
        /// Anonymous order ID on the token. "orderid" claim. Null unless the user is anonymous.
        /// </summary>
        public string AnonOrderID { get; }
        /// <summary>
        /// Username on the token. "usr" claim. Always non-null.
        /// </summary>
        public string Username { get; }
        /// <summary>
        /// OrderCloud roles on the token. "role" claim. Always non-null.
        /// </summary>
        public List<string> Roles { get; } = new List<string>();
        /// <summary>
        /// The authentication Url on the token. "iss" claim. Always non-null.
        /// </summary>
        public string AuthUrl { get; }
        /// <summary>
        /// The api Url on the token. "aud" claim. Always non-null.
        /// </summary>
        public string ApiUrl { get; }
        /// <summary>
        /// The user type ("buyer", "supplier", "admin") on the token. "usrtype" claim. Always non-null.
        /// </summary>
        public CommerceRole CommerceRole { get; }
        /// <summary>
        /// The client ID on the token. "cid" claim. Always non-null.
        /// </summary>
        public string ClientID { get; }
        /// <summary>
        /// The expiry time of the token. "exp" claim. Always non-null.
        /// </summary>
        public DateTime ExpiresUTC { get; }
        /// <summary>
        /// The time the token is not valid before. "nbf" claim. Always non-null.
        /// </summary>
        public DateTime NotValidBeforeUTC { get; }
        /// <summary>
        /// The internal database ID of the user. "u" claim from plateform, "uid" claim from portal. Always non-null.
        /// </summary>
        public string UserDatabaseID { get; }
        /// <summary>
        /// The internal database ID of the user who requested an impersonation token. "imp" claim. Null unless token is from impersonation.
        /// </summary>
        public string ImpersonatingUserDatabaseID { get; }

        public DecodedToken() { }

        /// <summary>
        /// Create a UserContext from a raw json web token.
        /// </summary>
        public DecodedToken(string token)
        {
            var jwt = new JwtSecurityToken(token);
            var lookup = jwt.Claims.ToLookup(c => c.Type, c => c.Value);

            AccessToken = token;
            KeyID = GetHeader(jwt, "kid");

            AnonOrderID = lookup["orderid"].FirstOrDefault();
            Username = lookup["usr"].FirstOrDefault();
            Roles = lookup["role"].ToList();
            AuthUrl = lookup["iss"].FirstOrDefault();
            ApiUrl = lookup["aud"].FirstOrDefault();
            var type = lookup["usrtype"].FirstOrDefault();
            CommerceRole = GetCommerceRole(type);
            ClientID = lookup["cid"].FirstOrDefault();
            ExpiresUTC = int.Parse(lookup["exp"].FirstOrDefault() ?? throw new ArgumentNullException("Token must contain \"exp\" claim")).FromUnixEpoch();
            NotValidBeforeUTC = int.Parse(lookup["nbf"].FirstOrDefault() ?? throw new ArgumentNullException("Token must contain \"nbf\" claim")).FromUnixEpoch();
            UserDatabaseID = lookup["u"].FirstOrDefault() ?? lookup["uid"].FirstOrDefault();
            ImpersonatingUserDatabaseID = lookup["imp"].FirstOrDefault();
        }

        /// <summary>
        /// Create a new IOrderCloudClient with the context of this json web token
        /// </summary>
        public IOrderCloudClient BuildClient()
        {
            var client = new OrderCloudClient(new OrderCloudClientConfig()
            {
                ApiUrl = ApiUrl,
                AuthUrl = AuthUrl,
                ClientId = ClientID,
                Roles = new[] { ApiRole.FullAccess }
            })
            {
                TokenResponse = new TokenResponse()
                {
                    AccessToken = AccessToken,
                    ExpiresUtc = ExpiresUTC
                }
            };
            return client;
        }

        private static string GetHeader(JwtSecurityToken jwt, string key)
        {
            return jwt.Header.FirstOrDefault(t => t.Key == key).Value?.ToString();
        }

        public static CommerceRole GetCommerceRole(string userType)
        {
            switch (userType?.ToLower())
            {
                case "buyer":
                    return CommerceRole.Buyer;
                case "seller":
                case "admin":
                    return CommerceRole.Seller;
                case "supplier":
                    return CommerceRole.Supplier;
                default:
                    throw new Exception("unknown user type: " + userType);
            }
        }

        public static string GetUserType(CommerceRole commerceRole)
        {
            switch (commerceRole)
            {
                case CommerceRole.Buyer:
                    return "buyer";
                case CommerceRole.Seller:
                    return "admin";
                case CommerceRole.Supplier:
                    return "supplier";
                default:
                    throw new Exception("null or bad parameter: " + commerceRole);
            }
        }
    }


    public static class ExtensionMethods
    {
        public static DateTime FromUnixEpoch(this int unix)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dtDateTime.AddSeconds(unix);
        }

        public static int ToUnixEpoch(this DateTime utc)
        {
            var span = utc - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return (int)span.TotalSeconds;
        }
    }
}
