using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Warehouse.BLL.Interfaces;
using Warehouse.Common.Models;

namespace Warehouse.API.Controllers
{
    [Route("api/import")]
    public class ImportDataController : Controller
    {
        private readonly IImportDataService _importDataService;

        public ImportDataController(IImportDataService importDataService)
        {
            _importDataService = importDataService;
        }
        [HttpGet]
        public string Index()
        {
            return "success";
        }

        [Route("products")]
        [HttpPost]
        public async Task<IActionResult> ImportProductsData([FromBody]string fileData)
        {
            if(!string.IsNullOrEmpty(fileData))
            {
                var productTransactions = JsonConvert.DeserializeObject<ProductsTransactions>(fileData);

                _importDataService.ImportProductsData(productTransactions.Products);

                return Ok();
            }           
            return BadRequest();            
        }


        [Route("articles")]
        [HttpPost]
        public async Task<IActionResult> ImportArticlesData([FromBody]string fileData)
        {
            if(!string.IsNullOrEmpty(fileData))
            {
                var articlesTransactions = JsonConvert.DeserializeObject<ArticlesTransactions>(fileData);

                _importDataService.ImportArticlesData(articlesTransactions.inventory);

                return Ok();
            }            
            return BadRequest();
        }
    }
}