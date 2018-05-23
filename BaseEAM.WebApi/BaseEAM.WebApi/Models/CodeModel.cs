/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
namespace BaseEAM.WebApi.Models
{
    public class CodeModel : BaseEamEntityModel
    {
        public string Description { get; set; }
        public string HierarchyIdPath { get; set; }
        public string HierarchyNamePath { get; set; }
        public long? ParentId { get; set; }
        public string CodeType { get; set; }
    }
}