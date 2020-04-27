using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ThePackage.Models.Abstract;

namespace ThePackage.Models.Entities
{
    public class Package
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] public int Id { get; set; }

        public DateTime DateInsert { get; set; }

        public int StatusId { get; set; }

        //public Units Status { get; set; }

        [ForeignKey("StatusId")] public Units Units { get; set; }

        /* public int PointSourceId { get; set; }

        public int PointDestinationId { get; set; }

        public int ClientSenderId { get; set; }

        public int ClientReceiverId { get; set; }

        [Column(TypeName ="money")]
        public decimal SumDeliver { get; set; }

        [Column(TypeName = "money")]
        public decimal SumPayed { get; set; }

        public int StatusId { get; set; }

        public References StatusName { get; set; }

        public int PackageTypeId { get; set; }
              
        [ForeignKey("PointSourceId")] public Point pointSource { get; set; }

        Point PointSourceId

        [ForeignKey("PointDestinationId")] public Point pointDestination { get; set; }

        [ForeignKey("ClientSenderId")] public Client clientSender { get; set; }

        [ForeignKey("ClientReceiverId")] public Client clientReceiver { get; set; }

        [ForeignKey("PackageTypeId")] public PackageType packageType { get; set; }
        */
    }
}
