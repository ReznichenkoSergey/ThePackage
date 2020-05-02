using System;
using ThePackage.Models.Abstract;

namespace ThePackage.Models.DtoClasses
{
    public class PackageDto : ActionHistory
    {
        public int Number { get; set; }
        
        public DateTime DateCreate { get; set; }

        public decimal SumDelivery { get; set; }

        public decimal SumPayed { get; set; }

        public string StatusName { get; set; }

        public string  PointSourceName { get; set; }
        public string PointSourceAddress { get; set; }

        public string PointDestinationName { get; set; }

        public string PointDestinationAddress { get; set; }

        public string ClientSenderName { get; set; }

        public string ClientSenderPhone { get; set; }

        public string ClientReceiverName { get; set; }

        public string ClientReceiverPhone { get; set; }
    }
}
