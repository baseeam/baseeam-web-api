/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/

namespace BaseEAM.WebApi.Models
{
    public class CraftModel : BaseEamEntityModel
    {
        public string Description { get; set; }
        public decimal? StandardRate { get; set; }
        public decimal? OvertimeRate { get; set; }
    }
}