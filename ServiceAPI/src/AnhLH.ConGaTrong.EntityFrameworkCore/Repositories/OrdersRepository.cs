using AnhLH.ConGaTrong.Dtos;
using AnhLH.ConGaTrong.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace AnhLH.ConGaTrong.Repositories
{
    public class OrdersRepository : ITransientDependency, IOrdersRepository
    {
        private readonly IConGaTrongDbContext _conGaTrongDbContext;
        public OrdersRepository(IConGaTrongDbContext conGaTrongDbContext) 
        { 
            _conGaTrongDbContext = conGaTrongDbContext;
        }

        public async Task<Orders> GetAsync(string customerCode)
        {
            try
            {
                var order =  await _conGaTrongDbContext.Orders.AsNoTracking().OrderBy(y => y.ID).LastOrDefaultAsync(x => x.CustomerCode.Equals(customerCode));
                if (order == null) { return null; }
                return order;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(message: "OrdersRepository-GetAsync {0}", ex.InnerException.Message);
            }
        }

        public async Task<List<Orders>> GetListAsync()
        {
            try
            {
                return await _conGaTrongDbContext.Orders.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(message: "OrdersRepository-GetListAsync {0}", ex.InnerException.Message);
            }
        }

        public async Task<bool> CreatedAsync(Orders orders)
        {
            try
            {
                if (orders == null)
                {
                    throw new ArgumentNullException(nameof(orders));
                }
                orders.CreatedDate = DateTime.Now;
                orders.UpdatedDate = DateTime.Now;
                orders.Status = 1;
                await _conGaTrongDbContext.Orders.AddAsync(orders);
                return await _conGaTrongDbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(message: "OrdersRepository-CreatedAsync {0}", ex.InnerException.Message);
            }
        }

        public async Task<bool> UpdatedAsync(Orders orders)
        {
            try
            {
                if (orders == null)
                {
                    throw new ArgumentNullException(nameof(orders));
                }

                orders.UpdatedDate = DateTime.Now;
                _conGaTrongDbContext.Orders.Update(orders);
                return await _conGaTrongDbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(message: "OrdersRepository-UpdatedAsync {0}", ex.InnerException.Message);
            }
        }
    }
}
