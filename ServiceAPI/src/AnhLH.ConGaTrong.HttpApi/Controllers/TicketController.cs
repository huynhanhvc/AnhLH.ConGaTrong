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
[Route("api/ticket")]
public class TicketController : ConGaTrongController, ITicketAppService
{
    private readonly ITicketAppService _ticketAppService;

    public TicketController(ITicketAppService ticketAppService)
    {
        _ticketAppService = ticketAppService;
    }
   
    [HttpGet("created")]
    public async Task<int> CreatedAsync()
    {
        return await _ticketAppService.CreatedAsync();
    }

    [HttpGet]
    public async Task<List<TicketResultsDto>> GetListAsync()
    {
        return await _ticketAppService.GetListAsync();
    }
}
