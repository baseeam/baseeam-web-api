/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
namespace BaseEAM.WebApi.Models
{
    public class LocationModel : BaseEamEntityModel
    {
        public string HierarchyIdPath { get; set; }
        public string HierarchyNamePath { get; set; }
        public long? ParentId { get; set; }
        public long? SiteId { get; set; }
        public long? LocationTypeId { get; set; }
        public long? LocationStatusId { get; set; }
        public long? AddressId { get; set; }
        public string AddressCountry { get; set; }
        public string AddressStateProvince { get; set; }
        public string AddressCity { get; set; }
        public string AddressAddress1 { get; set; }
        public string AddressAddress2 { get; set; }
        public string AddressZipPostalCode { get; set; }
        public string AddressPhoneNumber { get; set; }
        public string AddressFaxNumber { get; set; }
        public string AddressEmail { get; set; }
    }
}