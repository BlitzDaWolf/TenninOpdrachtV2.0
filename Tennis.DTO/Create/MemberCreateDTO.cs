﻿using System;
using System.Collections.Generic;
using System.Text;
using Tennis.DTO.Interface;

namespace Tennis.DTO.Create
{
    public class MemberCreateDTO : IDTO
    {
        public string FederationNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int GenderId { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Addition { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string PhoneNr { get; set; }
    }
}
