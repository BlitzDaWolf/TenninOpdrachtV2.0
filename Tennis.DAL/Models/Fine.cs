using System;
using Tennis.DAL.Attributes;
using Tennis.DTO.Read;

namespace Tennis.DAL.Models
{
    [ReadDTO(typeof(FineReadDTO))]
    public class Fine
    {
        public int Id { get; set; }
        public int FineNumber { get; set; }
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }
        public decimal Amount { get; set; }
        public DateTime handOutDate { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
