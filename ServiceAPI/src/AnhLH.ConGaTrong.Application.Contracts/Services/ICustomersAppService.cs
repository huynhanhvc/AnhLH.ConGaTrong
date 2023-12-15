using AnhLH.ConGaTrong.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnhLH.ConGaTrong.Services
{
    public interface ICustomersAppService
    {
        Task<List<CustomersDto>> GetListAsync();
        Task<CustomersDto> GetAsync(string phoneNumber);
        Task<CustomersDto> CreatedAsync(CustomersDto customers);
        Task<CustomersDto> UpdatedAsync(CustomersDto customers);
    }
}
