/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using System;

namespace BaseEAM.WebApi.Models
{
    public class WorkOrderModel : BaseEamEntityModel
    {
        public string SyncId { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public int? Priority { get; set; }
        public long? AssignmentId { get; set; }
        public string AssignmentType { get; set; }
        public decimal? AssignmentAmount { get; set; }
        public long? CreatedUserId { get; set; }
        public string HierarchyIdPath { get; set; }
        public string HierarchyNamePath { get; set; }
        public long? ParentId { get; set; }
        public string ParentNumber { get; set; }
        public long? SiteId { get; set; }
        public long? AssetId { get; set; }
        public long? LocationId { get; set; }
        public long? WorkCategoryId { get; set; }
        public long? WorkTypeId { get; set; }
        public long? FailureGroupId { get; set; }
        public long? ServiceRequestId { get; set; }
        public string ServiceRequestNumber { get; set; }
        public long? PreventiveMaintenanceId { get; set; }
        public string PreventiveMaintenanceNumber { get; set; }
        public string RequestorName { get; set; }
        public string RequestorEmail { get; set; }
        public string RequestorPhone { get; set; }
        public DateTime? RequestedDateTime { get; set; }
        public long? SupervisorId { get; set; }
        public long? TaskGroupId { get; set; }
        public DateTime? ExpectedStartDateTime { get; set; }
        public DateTime? DueDateTime { get; set; }
        public DateTime? ActualStartDateTime { get; set; }
        public DateTime? ActualEndDateTime { get; set; }
        public long? ActualFailureGroupId { get; set; }
        public long? ActualProblemId { get; set; }
        public long? ActualCauseId { get; set; }
        public long? ResolutionId { get; set; }
        public string ResolutionNotes { get; set; }
    }
}