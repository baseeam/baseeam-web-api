namespace BaseEAM.WebApi.Models
{
    public class AttachmentModel : BaseEamEntityModel
    {
        public long? EntityId { get; set; }
        public string EntityType { get; set; }
        public string ImageBase64String { get; set; }
    }
}