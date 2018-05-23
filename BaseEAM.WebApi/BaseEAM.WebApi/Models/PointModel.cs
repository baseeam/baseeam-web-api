namespace BaseEAM.WebApi.Models
{
    public class PointModel : BaseEamEntityModel
    {
        public long? LocationId { get; set; }
        public long? AssetId { get; set; }
        public long? MeterGroupId { get; set; }
    }
}