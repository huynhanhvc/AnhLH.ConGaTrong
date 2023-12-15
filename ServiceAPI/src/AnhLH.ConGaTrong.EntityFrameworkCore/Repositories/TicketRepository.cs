using AnhLH.ConGaTrong.Dtos;
using AnhLH.ConGaTrong.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace AnhLH.ConGaTrong.Repositories
{
    public class TicketRepository : ITransientDependency, ITicketRepository
    {
        private readonly IConGaTrongDbContext _conGaTrongDbContext;
        public TicketRepository(IConGaTrongDbContext conGaTrongDbContext)
        {
            _conGaTrongDbContext = conGaTrongDbContext;
        }

        public async Task<TicketResults> GetAsync(string ticketCode)
        {
            try
            {
                var ticket = await _conGaTrongDbContext.TicketResults.AsNoTracking().FirstOrDefaultAsync(x => x.TicketCode.Equals(ticketCode));
                if (ticket == null) { return null; }
                return ticket;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(message: "TicketRepository-GetAsync {0}", ex.InnerException.Message);
            }
        }

        public async Task<List<TicketResults>> GetListAsync()
        {
            try
            {
                return await _conGaTrongDbContext.TicketResults.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(message: "TicketRepository-GetListAsync {0}", ex.InnerException.Message);
            }
        }

        public async Task<bool> CreatedAsync(TicketResults ticket)
        {
            try
            {
                if (ticket == null)
                {
                    throw new ArgumentNullException(nameof(ticket));
                }
                ticket.CreatedDate = DateTime.Now;
                ticket.UpdatedDate = DateTime.Now;
                await _conGaTrongDbContext.TicketResults.AddAsync(ticket);
                return await _conGaTrongDbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(message: "TicketRepository-CreatedAsync {0}", ex.InnerException.Message);
            }
        }

        public async Task<bool> UpdatedAsync(TicketResults ticket)
        {
            try
            {
                if (ticket == null)
                {
                    throw new ArgumentNullException(nameof(ticket));
                }

                ticket.UpdatedDate = DateTime.Now;
                _conGaTrongDbContext.TicketResults.Update(ticket);
                return await _conGaTrongDbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(message: "TicketRepository-UpdatedAsync {0}", ex.InnerException.Message);
            }
        }
    }
}
