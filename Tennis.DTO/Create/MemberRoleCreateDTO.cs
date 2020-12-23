using System;
using System.Collections.Generic;
using System.Text;
using Tennis.DTO.Read;

namespace Tennis.DTO.Create
{
    public class MemberRoleCreateDTO
    {
        public int Id { get; set; }
        [DropDown(typeof(RoleReadDTO), "Name", "Role")]
        public int RoleId { get; set; }
        [DropDown(typeof(MemberReadDTO), "FirstName", "Member")]
        public int MemberId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
