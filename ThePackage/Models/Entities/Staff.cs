﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThePackage.Models.Entities
{
    public class Staff
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        [Key] 
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false),
            Column(TypeName = "nvarchar(20)")]
        public string Code { get; set; }

        [Required(AllowEmptyStrings = false),
            Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        
        [Required(AllowEmptyStrings = false),
            Column(TypeName = "nvarchar(15)")]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string EMail { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Comment { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public int UnitsId { get; set; }

        /// <summary>
        /// Должность
        /// </summary>
        public Units Units { get; set; }
    }
}