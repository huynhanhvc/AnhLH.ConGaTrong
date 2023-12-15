using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnhLH.ConGaTrong.Dtos
{
    public class Orders
    {
        [Key]
        public int ID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string TicketCode { get; set; }
        public int? TicketNumber { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Remark { get; set; }
        public int? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
