using FruitStore.OrderCloud.Common.Models;
using FruitStore.OrderCloud.Common.Models.FSBuyerProduct;
using OrderCloud.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitStore.OrderCloud.Api.Interfaces
{
    public interface IProductServices
    {
        Task<SuperOCProduct> Get(string id, string token);

        Task<ListPageWithFacets<FSBuyerProduct>> List(string decodedToken);
    }
}