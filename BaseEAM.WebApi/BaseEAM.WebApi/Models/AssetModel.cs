/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using System;

namespace BaseEAM.WebApi.Models
{
    public class AssetModel : BaseEamEntityModel
    {
        public string HierarchyIdPath { get; set; }
        public string HierarchyNamePath { get; set; }
        public long? ParentId { get; set; }
        public long? SiteId { get; set; }
        public long? AssetTypeId { get; set; }
        public long? AssetStatusId { get; set; }
        public long? LocationId { get; set; }
        public string SerialNumber { get; set; }
        public long? ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public long? VendorId { get; set; }
        public string VendorName { get; set; }
        public DateTime? InstallationDate { get; set; }
        public decimal? InstallationCost { get; set; }
        public decimal? PurchasePrice { get; set; }
        public int? Period { get; set; }
        public DateTime? WarrantyStartDate { get; set; }
        public DateTime? WarrantyEndDate { get; set; }
    }
}