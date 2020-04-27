using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThePackage.Models.Entities
{
    public class PackageType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] 
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings = false),
            Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Comment { get; set; }
    }
}
