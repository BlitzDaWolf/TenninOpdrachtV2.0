using Tennis.DAL.Attributes;
using Tennis.DTO.Read;

namespace Tennis.DAL.Models
{
    [ReadDTO(typeof(GenderReadDTO))]
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
