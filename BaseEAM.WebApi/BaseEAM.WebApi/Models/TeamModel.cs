/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/

namespace BaseEAM.WebApi.Models
{
    public class TeamModel : BaseEamEntityModel
    {
        public string Description { get; set; }
        public long? SiteId { get; set; }
    }
}