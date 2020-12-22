using System;
using System.Collections.Generic;
using System.Text;
using Tennis.DTO.Interface;

namespace Tennis.DTO.Read
{
    public class FineReadDTO : IDTO
    {
        public int FineNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime handOutDate { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
