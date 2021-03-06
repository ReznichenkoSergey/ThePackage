﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThePackage.Models.Abstract;

namespace ThePackage.Models.Entities
{
    /// <summary>
    /// Отделение
    /// </summary>
    public class Point : ActionHistory
    {
        [Key,
            DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false),
            Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false),
            Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Comment { get; set; }

        List<Package> Package { get; set; }
    }
}
