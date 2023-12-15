using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnhLH.ConGaTrong.Client.Dtos
{
    public class TicketResultsDto
    {
        public string TicketCode { get; set; }
        public int? TicketNumber { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
