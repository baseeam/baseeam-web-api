namespace BaseEAM.WebApi.Models
{
    public class MeterLineItemModel : BaseEamEntityModel
    {
        public int DisplayOrder { get; set; }

        public long? MeterGroupId { get; set; }

        public long? MeterId { get; set; }
    }
}