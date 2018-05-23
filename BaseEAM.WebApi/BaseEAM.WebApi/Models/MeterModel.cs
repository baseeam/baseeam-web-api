namespace BaseEAM.WebApi.Models
{
    public class MeterModel : BaseEamEntityModel
    {
        public string Description { get; set; }
        public long? MeterTypeId { get; set; }
        public long? UnitOfMeasureId { get; set; }
    }
}