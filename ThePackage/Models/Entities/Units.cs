using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThePackage.Models.Entities
{
    public class Units
    {
        [Key,
            DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required, 
            Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public int TypeId { get; set; }

        List<Staff> Staff { get; set; }

        List<Package> Package { get; set; }
    }
}
