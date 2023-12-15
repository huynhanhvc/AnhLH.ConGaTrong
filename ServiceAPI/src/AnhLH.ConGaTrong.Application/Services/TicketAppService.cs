using AnhLH.ConGaTrong.Dtos;
using AnhLH.ConGaTrong.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace AnhLH.ConGaTrong.Services
{
    public class TicketAppService : ConGaTrongAPIAppService, ITicketAppService
    {
        private readonly ILogger<CustomersAppService> _logger;
        private readonly ITicketRepository _ticketRepository;

        public TicketAppService(ILogger<CustomersAppService> logger, ITicketRepository ticketRepository)
        {
            _logger = logger;
            _ticketRepository = ticketRepository;
        }

        public async Task<int> CreatedAsync()
        {
            try
            {
                string ticketCode = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.Hour.ToString();
                DateTime specificDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddHours(1).Hour, 0, 0);
                int ticketNumber = GetRandomNumber(1, 9);

                TicketResults ticketResults = new TicketResults()
                { 
                    TicketCode = ticketCode,
                    TicketNumber = ticketNumber,
                    ReleaseDate = specificDateTime
                };

                await _ticketRepository.CreatedAsync(ticketResults);
                return ticketNumber;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OrdersAppService-TicketAppService {input}", "");
                throw;
            }
        }

        public async Task<List<TicketResultsDto>> GetListAsync()
        {
            try
            {
                var result = await _ticketRepository.GetListAsync();
                return ObjectMapper.Map<List<TicketResults>, List<TicketResultsDto>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OrdersAppService-GetAsync()");
                throw;
            }
        }

        //Function to get random number
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom) // synchronize
            {
                return getrandom.Next(min, max);
            }
        }
    }
}
