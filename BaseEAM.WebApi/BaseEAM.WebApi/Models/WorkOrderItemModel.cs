/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/

namespace BaseEAM.WebApi.Models
{
    public class WorkOrderItemModel : BaseEamEntityModel
    {
        public string SyncId { get; set; }
        public long? WorkOrderId { get; set; }
        public long? StoreId { get; set; }
        public string StoreName { get; set; }

        public long? ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemCategoryText { get; set; }

        public long? StoreLocatorId { get; set; }
        public string StoreLocatorName { get; set; }

        public decimal? UnitPrice { get; set; }
        public decimal? PlanQuantity { get; set; }
        public decimal? PlanTotal { get; set; }
        public decimal? ActualQuantity { get; set; }
        public decimal? ActualTotal { get; set; }

        public decimal? PlanToolHours { get; set; }
        public decimal? ToolRate { get; set; }
        public decimal? ActualToolHours { get; set; }
    }
}