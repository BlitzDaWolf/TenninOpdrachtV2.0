using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis.DTO.Create
{
    public class MemberRoleCreateDTO
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int MemberId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
