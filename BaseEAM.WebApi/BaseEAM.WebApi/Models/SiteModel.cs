/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
namespace BaseEAM.WebApi.Models
{
    public class SiteModel : BaseEamEntityModel
    {
        public string Description { get; set; }
        public long? OrganizationId { get; set; }
        public string OrganizationName { get; set; }
    }
}