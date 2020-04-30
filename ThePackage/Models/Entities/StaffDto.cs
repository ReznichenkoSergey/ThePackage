
namespace ThePackage.Models.Entities
{
    public class StaffDto
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
        
        public string Phone { get; set; }

        public string EMail { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Comment { get; set; }
        
        public int UnitsId { get; set; }
        
        public string  UnitsCipher { get; set; }
    }
}
