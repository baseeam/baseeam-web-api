/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using System;

namespace BaseEAM.WebApi.Models
{
    public class BaseEamEntityModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }
        public bool IsNew { get; set; }
        public bool IsDeleted { get; set; }
        public int Version { get; set; }
    }
}