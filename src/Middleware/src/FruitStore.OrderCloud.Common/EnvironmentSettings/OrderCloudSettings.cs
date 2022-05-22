using System;
using System.Collections.Generic;
using System.Text;

namespace FruitStore.OrderCloud.Common.EnvironmentSettings
{
	public class OrderCloudSettings
	{
		public string StorefrontClientID { get; set; }
		public string ApiUrl { get; set; } // 'https://api.ordercloud.io' or 'https://stagingapi.ordercloud.io' or 'https://sandboxapi.ordercloud.io'`
		public string MiddlewareClientID { get; set; } // Find this in the Ordercloud portal Api Client resource
		public string MiddlewareClientSecret { get; set; } // Find this in the Ordercloud portal Api Client resource
		public string WebhookHashKey { get; }  // Should match the HashKey configured on your webhook in the Ordercloud portal.
	}
}
