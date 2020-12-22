using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis.DTO.Read
{
    public class MemberRoleReadDTO
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public virtual RoleReadDTO Role { get; set; }
        public int MemberId { get; set; }
        public virtual MemberReadDTO Member { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
