using ApplicationTier.Classes;
using ApplicationTier.Dtos;
using ApplicationTier.Interfaces;
using IndustryConnect_Week_Microservices.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SaleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleMethods _saleMethods;

        public SaleController(ISaleMethods saleMethods)
        {
            _saleMethods = saleMethods;

        }

        [HttpPost(Name = "AddSale")]
        public async Task<JsonResult> AddSale(int customerId, int productId, int storeId)
        {
            var sale = await _saleMethods.AddSale(customerId, productId, storeId);

            return new JsonResult(sale);
        }
    }
}
