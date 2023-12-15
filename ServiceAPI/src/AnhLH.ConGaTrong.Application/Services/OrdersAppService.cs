using AnhLH.ConGaTrong.Dtos;
using AnhLH.ConGaTrong.Repositories;
using AnhLH.ConGaTrong.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.ObjectMapping;

namespace AnhLH.ConGaTrong.Services
{
    public class OrdersAppService : ConGaTrongAPIAppService, IOrdersAppService
    {
        private readonly ILogger<CustomersAppService> _logger;
        private readonly IOrdersRepository _ordersRepository;

        public OrdersAppService(ILogger<CustomersAppService> logger, IOrdersRepository ordersRepository) 
        {
            _logger = logger;
            _ordersRepository = ordersRepository;
        }

        public async Task<OrderResponseDto> CreatedAsync(OrderDto orderDto)
        {
            try
            {
                string ticketCode = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.AddHours(1).Hour.ToString();

                var orderCheck = await _ordersRepository.GetAsync(orderDto.CustomerCode);
                //Check don hang gafn nhast
                if (orderCheck != null)
                {
                    if (orderCheck.TicketCode.Equals(ticketCode)) 
                    {
                        throw new BusinessException(ConGaTrongAPIErrorCodes.ERROR_Exist).WithData("Mỗi slot bạn chỉ được đặt 1 số!", orderDto);
                    }
                }

                DateTime specificDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddHours(1).Hour, 0, 0);
               
                var orderInput =  ObjectMapper.Map<OrderDto, Orders>(orderDto);
                orderInput.TicketCode = ticketCode;
                orderInput.ReleaseDate = specificDateTime;

                var resultOrder = await _ordersRepository.CreatedAsync(orderInput);

                return ObjectMapper.Map<Orders, OrderResponseDto>(orderInput); ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OrdersAppService-CreatedAsync {input}", System.Text.Json.JsonSerializer.Serialize(orderDto));
                throw;
            }
        }

        public async Task<List<OrderResponseDto>> GetListAsync()
        {
            try
            {
                var result = await _ordersRepository.GetListAsync();
                return ObjectMapper.Map<List<Orders>, List<OrderResponseDto>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OrdersAppService-GetAsync()");
                throw;
            }
        }
    }
}

