using FruitStore.OrderCloud.Api.Interfaces;
using FruitStore.OrderCloud.Common;
using FruitStore.OrderCloud.Common.Models;
using OrderCloud.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitStore.OrderCloud.Api.Services
{
    public class OCProductServices : IProductServices
    {
        private readonly IOrderCloudClient _oc;
        private readonly AppSettings _settings;
        public OCProductServices(AppSettings settings, IOrderCloudClient elevatedOc)
        {
            _oc = elevatedOc;
            _settings = settings;
        }
        public async Task<SuperOCProduct> Get(string id, string token)
        {
            var product = await _oc.Products.GetAsync<OCProduct>(id, token);
            var variants = _oc.Products.ListVariantsAsync<OCVariant>(id, null, null, null, 1, 100, null, token);
            try
            {
                return new SuperOCProduct
                {
                    Product = product,
                    Variants = (await variants).Items,
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
