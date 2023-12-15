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
[Route("api/customers")]
public class CustomersController : ConGaTrongController, ICustomersAppService
{
    private readonly ICustomersAppService _customersAppService;

    public CustomersController(ICustomersAppService customersAppService)
    {
        _customersAppService = customersAppService;
    }

    [HttpGet]
    public async Task<List<CustomersDto>> GetListAsync()
    {
        return await _customersAppService.GetListAsync();
    }

    [HttpGet("{phoneNumber}")]
    public async Task<CustomersDto> GetAsync(string phoneNumber)
    {
        return await _customersAppService.GetAsync(phoneNumber);
    }

    [HttpPost("created")]
    public async Task<CustomersDto> CreatedAsync(CustomersDto customersDto)
    {
        return await _customersAppService.CreatedAsync(customersDto);
    }

    [HttpPut("updated")]
    public async Task<CustomersDto> UpdatedAsync(CustomersDto customersDto)
    {
        return await _customersAppService.UpdatedAsync(customersDto);
    }
}
