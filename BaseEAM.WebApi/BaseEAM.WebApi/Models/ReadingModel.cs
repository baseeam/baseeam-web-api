using System;

namespace BaseEAM.WebApi.Models
{
    public class ReadingModel : BaseEamEntityModel
    {
        public long? PointMeterLineItemId { get; set; }
        public decimal? ReadingValue { get; set; }
        public DateTime? DateOfReading { get; set; }
        public int? ReadingSource { get; set; }
        public long? WorkOrderId { get; set; }
    }
}