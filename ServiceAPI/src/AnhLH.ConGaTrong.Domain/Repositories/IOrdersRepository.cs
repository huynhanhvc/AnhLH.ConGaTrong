using AnhLH.ConGaTrong.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnhLH.ConGaTrong.Repositories
{
    public interface IOrdersRepository
    {
        Task<Orders> GetAsync(string customerCode);
        Task<List<Orders>> GetListAsync();
        Task<bool> CreatedAsync(Orders orders);
        Task<bool> UpdatedAsync(Orders orders);
    }
}
