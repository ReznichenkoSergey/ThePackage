using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ThePackage.Models.Abstract;

namespace ThePackage.Models.Entities
{
    public class Package : ActionHistory
    {
        [Key,
            DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
                
        [Column(TypeName = "money")]
        public decimal SumDeliver { get; set; }

        [Column(TypeName = "money")]
        public decimal SumPayed { get; set; }

        public int StatusId { get; set; }

        [ForeignKey("StatusId")] 
        public Units Units { get; set; }

        public int? PointSourceId { get; set; }

        [ForeignKey("PointSourceId")] 
        public Point PointSource { get; set; }

        public int? PointDestinationId { get; set; }

        [ForeignKey("PointDestinationId")] 
        public Point PointDestination { get; set; }

        public int? ClientSenderId { get; set; }
        
        [ForeignKey("ClientSenderId")] 
        public Client ClientSender { get; set; }

        public int? ClientReceiverId { get; set; }

        [ForeignKey("ClientReceiverId")] 
        public Client ClientReceiver { get; set; }
    }
}
