using FruitStore.OrderCloud.Client.Interfaces;
using FruitStore.OrderCloud.Common;
using FruitStore.OrderCloud.Common.Models;
using FruitStore.OrderCloud.Common.Models.FSBuyerProduct;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OrderCloud.Catalyst;
using OrderCloud.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitStore.OrderCloud.Api.Controllers
{
    [Route("products")]
    public class ProductController : CatalystController
    {
        private readonly IFSMeResource _fsMeResource;

        public ProductController(AppSettings settings, IFSMeResource fsMeResource)
        {
            this._fsMeResource = fsMeResource;
        }
        /// <summary>
        /// GET List of all Me Products.
        /// </summary>
        [HttpGet, Route("list")]
        [OrderCloudUserAuth(ApiRole.Shopper, ApiRole.FullAccess)]
        public async Task<ListPageWithFacets<FSBuyerProduct>> List()
        {
            return await _fsMeResource.ListProductsAsync(UserContext.AccessToken);
        }
    }
}
