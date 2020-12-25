using System;
using Tennis.DTO.Attributes;
using Tennis.DTO.Interface;

namespace Tennis.DTO.Read
{
    public class MemberReadDTO : IDTO
    {
        public int Id { get; set; }
        public string FederationNr { get; set; }
        [Filter]
        public string FirstName { get; set; } = "";
        [Filter]
        public string LastName { get; set; } = "";
        public GenderReadDTO Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Addition { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string PhoneNr { get; set; }
    }
}
