using System.Collections.Generic;

namespace BaseEAM.WebApi.Models
{
    public class MyUpdatedWOData
    {
        public List<WorkOrderModel> WorkOrder { get; set; }
        public List<WorkOrderLaborModel> WorkOrderLabor { get; set; }
        public List<WorkOrderTaskModel> WorkOrderTask { get; set; }
        public List<WorkOrderItemModel> WorkOrderItem { get; set; }
        public List<WorkOrderServiceItemModel> WorkOrderServiceItem { get; set; }
        public List<WorkOrderMiscCostModel> WorkOrderMiscCost { get; set; }
        public List<ReadingModel> Reading { get; set; }
        public List<CommentModel> Comment { get; set; }
        public List<AttachmentModel> Attachment { get; set; }

        public MyUpdatedWOData()
        {
            WorkOrder = new List<WorkOrderModel>();
            WorkOrderLabor = new List<WorkOrderLaborModel>();
            WorkOrderTask = new List<WorkOrderTaskModel>();
            WorkOrderItem = new List<WorkOrderItemModel>();
            WorkOrderServiceItem = new List<WorkOrderServiceItemModel>();
            WorkOrderMiscCost = new List<WorkOrderMiscCostModel>();
            Reading = new List<ReadingModel>();
            Comment = new List<CommentModel>();
            Attachment = new List<AttachmentModel>();
        }
    }
}