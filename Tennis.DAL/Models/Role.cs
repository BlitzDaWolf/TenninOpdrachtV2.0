using Tennis.DAL.Attributes;
using Tennis.DTO.Read;

namespace Tennis.DAL.Models
{
    [ReadDTO(typeof(RoleReadDTO))]
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
