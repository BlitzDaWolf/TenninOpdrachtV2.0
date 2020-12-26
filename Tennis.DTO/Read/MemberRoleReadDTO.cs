using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis.DTO.Read
{
    public class MemberRoleReadDTO
    {
        public int Id { get; set; }
        public virtual RoleReadDTO Role { get; set; }
        public virtual MemberReadDTO Member { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool Active => EndDate > DateTime.Now;
    }
}
