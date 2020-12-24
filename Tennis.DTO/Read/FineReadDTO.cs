using System;
using Tennis.DTO.Attributes;
using Tennis.DTO.Interface;

namespace Tennis.DTO.Read
{
    public class FineReadDTO : IDTO
    {
        [Filter]
        public int FineNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime handOutDate { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
