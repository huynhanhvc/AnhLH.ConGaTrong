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
    public class CustomersRepository : ITransientDependency, ICustomersRepository
    {
        private readonly IConGaTrongDbContext _conGaTrongDbContext;
        public CustomersRepository(IConGaTrongDbContext conGaTrongDbContext) 
        { 
            _conGaTrongDbContext = conGaTrongDbContext;       
        }

        public async Task<Customers> GetAsync(string phoneNumber)
        {
            try
            {
                return await _conGaTrongDbContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.PhoneNumber.Equals(phoneNumber));
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(message: "CustomersRepository-GetAsync {0}", ex.InnerException.Message);
            }
        }

        public async Task<List<Customers>> GetListAsync()
        {
            try
            {
                return await _conGaTrongDbContext.Customers.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(message: "CustomersRepository-GetListAsync {0}", ex.InnerException.Message);
            }
        }

        public async Task<Customers> CreatedAsync(Customers customers)
        {
            try
            {
                if (customers == null)
                {
                    throw new ArgumentNullException(nameof(customers));
                }
                customers.CreatedDate = DateTime.Now;
                customers.UpdatedDate = DateTime.Now;
                customers.Status = 1;
                await _conGaTrongDbContext.Customers.AddAsync(customers);
                await _conGaTrongDbContext.SaveChangesAsync();

                return customers;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(message: "CustomersRepository-CreatedAsync {0}", ex.InnerException.Message);
            }
        }

        public async Task<Customers> UpdatedAsync(Customers customers)
        {
            try
            {
                if (customers == null)
                {
                    throw new ArgumentNullException(nameof(customers));
                }

                customers.UpdatedDate = DateTime.Now;
                _conGaTrongDbContext.Customers.Update(customers);
                await _conGaTrongDbContext.SaveChangesAsync();

                return customers;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(message: "CustomersRepository-UpdatedAsync {0}", ex.InnerException.Message);
            }
        }
    }
}
