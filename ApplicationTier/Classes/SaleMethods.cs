using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationTier.Interfaces;

using IndustryConnect_Week_Microservices.Models;
using ApplicationTier.Dtos;
using Microsoft.EntityFrameworkCore;


namespace ApplicationTier.Classes
{
    public class SaleMethods : ISaleMethods
    {
        public SaleMethods() { }

        public async Task<SaleDto> AddSale(int customerId, int productId, int storeId)
        {
            var context = new IndustryConnectWeek2Context();

            var sale = new Sale
            {
                CustomerId = customerId,
                ProductId = productId,
                StoreId = storeId,
            };

            context.Add(sale);

            await context.SaveChangesAsync();

            return Mapper(sale);
        }


        private static SaleDto Mapper(Sale? sale)
        {
            if (sale != null)
            {
                var saleDto = new SaleDto
                {
                    Id = sale.Id,
                    CustomerId = sale?.CustomerId,
                    ProductId = sale?.ProductId,
                    StoreId = sale?.StoreId,
                };

                return saleDto;
            }
            else
            {
                return null;
            }

        }


    }
}
