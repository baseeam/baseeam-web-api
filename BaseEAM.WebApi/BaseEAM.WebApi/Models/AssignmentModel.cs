/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using System;

namespace BaseEAM.WebApi.Models
{
    public class AssignmentModel : BaseEamEntityModel
    {
        public long? EntityId { get; set; }
        public string EntityType { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public int? Priority { get; set; }
        public string AssignmentType { get; set; }
        public decimal? AssignmentAmount { get; set; }
        public string Comment { get; set; }
        public string AvailableActions { get; set; }
        public string TriggeredAction { get; set; }
        public DateTime? ExpectedStartDateTime { get; set; }
        public DateTime? DueDateTime { get; set; }
        public string WorkflowInstanceId { get; set; }
        public int? WorkflowVersion { get; set; }
    }
}