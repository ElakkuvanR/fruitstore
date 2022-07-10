using FruitStore.OrderCloud.Api.Interfaces;
using FruitStore.OrderCloud.Common;
using FruitStore.OrderCloud.Common.Models;
using FruitStore.OrderCloud.Common.Models.FSBuyerProduct;
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
        private readonly IProductServices _productService;

        public ProductController(AppSettings settings, IProductServices productService)
        {
            this._productService = productService;
        }
        /// <summary>
        /// GET List of all Me Products.
        /// </summary>
        [HttpGet, Route("List")]
        [OrderCloudUserAuth(ApiRole.Shopper, ApiRole.FullAccess)]
        public async Task<ListPageWithFacets<FSBuyerProduct>> List()
        {
            return await _productService.List(UserContext.AccessToken);
        }
    }
}
