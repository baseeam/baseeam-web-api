using System;

namespace BaseEAM.WebApi.Models
{
    public class PointMeterLineItemModel : BaseEamEntityModel
    {
        public int DisplayOrder { get; set; }
        public long? PointId { get; set; }
        public long? MeterId { get; set; }

        //cache the last reading
        public decimal? LastReadingValue { get; set; }
        public DateTime? LastDateOfReading { get; set; }
        public string LastReadingUser { get; set; }
    }
}