using System;
using Tennis.DTO.Attributes;
using Tennis.DTO.Read;

namespace Tennis.DTO.Create
{
    public class MemberRoleCreateDTO
    {
        [DropDown(typeof(RoleReadDTO), "Name", "Role")]
        public int RoleId { get; set; }
        [DropDown(typeof(MemberReadDTO), "FirstName", "Member")]
        public int MemberId { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
    }
}
