using System;
using System.Collections.Generic;
using System.Text;

namespace AnhLH.ConGaTrong.Dtos
{
    public class OrderDto
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public int? TicketNumber { get; set; }
        public string Remark { get; set; }
    }
}
