using AnhLH.ConGaTrong.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnhLH.ConGaTrong.Services
{
    public interface ITicketAppService
    {
        Task<int> CreatedAsync();
        Task<List<TicketResultsDto>> GetListAsync();
    }
}
