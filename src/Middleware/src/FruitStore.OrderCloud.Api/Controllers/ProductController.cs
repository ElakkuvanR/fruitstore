using FruitStore.OrderCloud.Api.Interfaces;
using FruitStore.OrderCloud.Common;
using FruitStore.OrderCloud.Common.Models;
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
        /// GET Super Product.
        /// </summary>
        [HttpGet, Route("{id}"), OrderCloudUserAuth(ApiRole.ProductAdmin, ApiRole.ProductReader)]
        public async Task<SuperOCProduct> Get(string id)
        {
            return await _productService.Get(id, UserContext.AccessToken);
        }
    }
}
