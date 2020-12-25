using System;
using Tennis.DTO.Attributes;
using Tennis.DTO.Interface;
using Tennis.DTO.Read;

namespace Tennis.DTO.Create
{
    public class MemberCreateDTO : IDTO
    {
        public string FederationNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;
        [DropDown(typeof(GenderReadDTO), "Name", "Gender")]
        public int GenderId { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Addition { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string PhoneNr { get; set; }
    }
}
