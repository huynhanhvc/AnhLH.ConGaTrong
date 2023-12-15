using AnhLH.ConGaTrong.Dtos;
using AnhLH.ConGaTrong.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.ObjectMapping;

namespace AnhLH.ConGaTrong.Services
{
    public class CustomersAppService : ConGaTrongAPIAppService, ICustomersAppService
    {
        private readonly ILogger<CustomersAppService> _logger;
        private readonly ICustomersRepository _customersRepository;
        public CustomersAppService(ILogger<CustomersAppService> logger, ICustomersRepository customersRepository) 
        { 
            _logger = logger;
            _customersRepository = customersRepository;
        }

        public async Task<List<CustomersDto>> GetListAsync()
        {
            try
            {
                var result = await _customersRepository.GetListAsync();
                return ObjectMapper.Map<List<Customers>, List<CustomersDto>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CustomersAppService-GetAsync()");
                throw;
            }           
        }

        public async Task<CustomersDto> GetAsync(string phoneNumber)
        {
            try
            {
                var result = await _customersRepository.GetAsync(phoneNumber);
                return ObjectMapper.Map<Customers, CustomersDto>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CustomersAppService-GetAsync {input}", phoneNumber);
                throw;
            }           
        }

        public async Task<CustomersDto> CreatedAsync(CustomersDto customers)
        {
            try
            {
                var input =  ObjectMapper.Map<CustomersDto, Customers>(customers);
                var result = await _customersRepository.CreatedAsync(input);

                return ObjectMapper.Map<Customers, CustomersDto>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CustomersAppService-CreatedAsync {input}", System.Text.Json.JsonSerializer.Serialize(customers));
                throw;
            }
        }

        public async Task<CustomersDto> UpdatedAsync(CustomersDto customers)
        {
            try
            {
                var input = ObjectMapper.Map<CustomersDto, Customers>(customers);
                var result = await _customersRepository.UpdatedAsync(input);

                return ObjectMapper.Map<Customers, CustomersDto>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CustomersAppService-UpdatedAsync {input}", System.Text.Json.JsonSerializer.Serialize(customers));
                throw;
            }
        }
    }
}
