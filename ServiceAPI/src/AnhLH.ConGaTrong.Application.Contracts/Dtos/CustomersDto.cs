using System;
using System.Collections.Generic;
using System.Text;

namespace AnhLH.ConGaTrong.Dtos
{
    public class CustomersDto
    {
        public int ID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public bool? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
