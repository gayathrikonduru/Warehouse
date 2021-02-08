using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Warehouse.BLL.Interfaces;
using Warehouse.Common.Models;
using System.Web;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productsService)
        {
            _productService = productsService;
        }
        
        [HttpGet]        
        public async Task<JsonResult> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return new JsonResult(products);
        }
        
        [HttpGet("{productId}")]        
        public async Task<IActionResult> GetProductById(int productId)
        {           
            var response = await _productService.GetProductById(productId);
            if(response == null)
            {
                return NotFound();
            }
            return  new JsonResult(response);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody]Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }                                  
            return Ok(_productService.AddNewProduct(product));
        }

        [HttpPut]        
        public ActionResult UpdateProduct([FromBody]Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = _productService.UpdateProduct(product);
            if(response == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{productId}")]
        public ActionResult DeleteProduct(int productId)
        {
            var response = _productService.DeleteProduct(productId);
            if(response == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}