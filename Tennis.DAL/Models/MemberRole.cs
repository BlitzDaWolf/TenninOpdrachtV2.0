using System;
using Tennis.DAL.Attributes;
using Tennis.DTO.Create;
using Tennis.DTO.Read;

namespace Tennis.DAL.Models
{
    [ReadDTO(typeof(MemberRoleReadDTO))]
    [CreateDTO(typeof(MemberRoleCreateDTO))]
    public class MemberRole
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int MemberId { get; set; }
        public virtual Member Member { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
