using System.Collections.Generic;
using System.Threading.Tasks;
using AnhLH.ConGaTrong.Dtos;
using AnhLH.ConGaTrong.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace AnhLH.ConGaTrong.Controllers;

[Area(ConGaTrongRemoteServiceConsts.ModuleName)]
[RemoteService(Name = ConGaTrongRemoteServiceConsts.RemoteServiceName)]
[Route("api/orders")]
public class OrdersController : ConGaTrongController, IOrdersAppService
{
    private readonly IOrdersAppService _ordersAppService;

    public OrdersController(IOrdersAppService ordersAppService)
    {
        _ordersAppService = ordersAppService;
    }
   
    [HttpPost("created")]
    public async Task<OrderResponseDto> CreatedAsync(OrderDto orderDto)
    {
        return await _ordersAppService.CreatedAsync(orderDto);
    }

    [HttpGet]
    public async Task<List<OrderResponseDto>> GetListAsync()
    {
        return await _ordersAppService.GetListAsync();
    }
}
