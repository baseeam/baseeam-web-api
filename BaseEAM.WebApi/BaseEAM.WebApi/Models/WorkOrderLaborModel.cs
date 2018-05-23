/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/

namespace BaseEAM.WebApi.Models
{
    public class WorkOrderLaborModel : BaseEamEntityModel
    {
        public string SyncId { get; set; }
        public long? WorkOrderId { get; set; }
        public long? TeamId { get; set; }
        public long? TechnicianId { get; set; }
        public long? CraftId { get; set; }
        public decimal? PlanHours { get; set; }
        public decimal? StandardRate { get; set; }
        public decimal? OTRate { get; set; }
        public decimal? PlanTotal { get; set; }
        public decimal? ActualNormalHours { get; set; }
        public decimal? ActualOTHours { get; set; }
        public decimal? ActualTotal { get; set; }
    }
}