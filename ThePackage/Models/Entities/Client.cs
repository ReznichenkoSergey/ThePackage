using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThePackage.Models.Abstract;

namespace ThePackage.Models.Entities
{
    public class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public int Id { get; set; }
        [Required,
            Column(TypeName = "nvarchar(30)")]
        public string Code { get; set; }

        [Required,
            Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        
        [Required,
            Column(TypeName = "nvarchar(30)")]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string EMail { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Comment { get; set; }
    }
}
