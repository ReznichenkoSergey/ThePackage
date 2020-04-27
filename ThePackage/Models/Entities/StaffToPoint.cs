using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThePackage.Models.Entities
{
    public class StaffToPoint
    {
        [Key,
            DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int? StaffId { get; set; }

        [ForeignKey("StaffId")] public Staff Staff { get; set; }

        [Required]
        public int? PointId { get; set; }

        [ForeignKey("PointId")] public Point Point { get; set; }
    }
}
