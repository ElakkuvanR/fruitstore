using FruitStore.OrderCloud.Api.Interfaces;
using FruitStore.OrderCloud.Client.Interfaces;
using FruitStore.OrderCloud.Common;
using FruitStore.OrderCloud.Common.Models;
using FruitStore.OrderCloud.Common.Models.FSBuyerProduct;
using OrderCloud.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitStore.OrderCloud.Api.Services
{
    public class OCProductServices : IProductServices
    {
        private readonly IFSMeResource _fsClient;
        private readonly AppSettings _settings;
        public OCProductServices(AppSettings settings, IFSMeResource fsClient)
        {
            _fsClient = fsClient;
            _settings = settings;
        }

        public Task<SuperOCProduct> Get(string id, string token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="decodedToken"></param>
        /// <returns></returns>
        public async Task<ListPageWithFacets<FSBuyerProduct>> List(string decodedToken)
        {
            var meProducts = await _fsClient.ListProductsAsync(accessToken: decodedToken);
            return meProducts;
        }
    }
}
