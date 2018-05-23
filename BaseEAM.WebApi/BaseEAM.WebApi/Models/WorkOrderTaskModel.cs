/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using System;

namespace BaseEAM.WebApi.Models
{
    public class WorkOrderTaskModel : BaseEamEntityModel
    {
        public string SyncId { get; set; }
        public long? WorkOrderId { get; set; }
        public int? Sequence { get; set; }
        public string Description { get; set; }
        public long? AssignedUserId { get; set; }
        public bool Completed { get; set; }
        public long? CompletedUserId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public decimal? HoursSpent { get; set; }
        public int? Result { get; set; }
        public string CompletionNotes { get; set; }
    }
}