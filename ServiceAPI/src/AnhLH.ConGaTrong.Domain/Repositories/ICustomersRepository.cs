using AnhLH.ConGaTrong.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnhLH.ConGaTrong.Repositories
{
    public interface ICustomersRepository
    {
        Task<List<Customers>> GetListAsync();
        Task<Customers> GetAsync(string phoneNumber);
        Task<Customers> CreatedAsync(Customers customers);
        Task<Customers> UpdatedAsync(Customers customers);
    }
}
