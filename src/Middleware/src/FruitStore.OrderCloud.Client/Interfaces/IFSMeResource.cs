using FruitStore.OrderCloud.Common.Models.FSBuyerProduct;
using OrderCloud.SDK;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitStore.OrderCloud.Client.Interfaces
{
    public interface IFSMeResource
    {
        public Task<ListPageWithFacets<FSBuyerProduct>> ListProductsAsync(string accessToken);
    }
}
