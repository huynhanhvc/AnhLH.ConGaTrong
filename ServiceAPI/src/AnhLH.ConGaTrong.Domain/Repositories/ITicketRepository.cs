using AnhLH.ConGaTrong.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnhLH.ConGaTrong.Repositories
{
    public interface ITicketRepository
    {
        Task<TicketResults> GetAsync(string ticketCode);
        Task<List<TicketResults>> GetListAsync();
        Task<bool> CreatedAsync(TicketResults ticket);
        Task<bool> UpdatedAsync(TicketResults ticket);
    }
}
