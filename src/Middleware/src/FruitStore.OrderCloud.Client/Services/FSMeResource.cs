using FruitStore.OrderCloud.Client.Interfaces;
using FruitStore.OrderCloud.Common.Models.FSBuyerProduct;
using OrderCloud.SDK;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.OrderCloud.Client.Services
{
    public class FSMeResource : IFSMeResource
    {
        protected IOrderCloudClient _client;

        public FSMeResource(IOrderCloudClient client)
        {
            _client = client;
        }
        public async Task<ListPageWithFacets<FSBuyerProduct>> ListProductsAsync(string accessToken)
        {
            var result = await _client.Me.ListProductsAsync<FSBuyerProduct>(accessToken: accessToken);
            return result;
        }
    }
}
