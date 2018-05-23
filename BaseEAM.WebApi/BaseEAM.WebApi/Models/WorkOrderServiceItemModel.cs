/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/

namespace BaseEAM.WebApi.Models
{
    public class WorkOrderServiceItemModel : BaseEamEntityModel
    {
        public string SyncId { get; set; }
        public long? WorkOrderId { get; set; }
        public long? ServiceItemId { get; set; }
        public string ServiceItemName { get; set; }

        public string Description { get; set; }
        public decimal? PlanUnitPrice { get; set; }
        public decimal? PlanQuantity { get; set; }
        public decimal? PlanTotal { get; set; }

        public decimal? ActualUnitPrice { get; set; }
        public decimal? ActualQuantity { get; set; }
        public decimal? ActualTotal { get; set; }
    }
}