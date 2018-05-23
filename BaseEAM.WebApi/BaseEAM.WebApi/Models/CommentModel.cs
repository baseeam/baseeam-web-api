/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/

namespace BaseEAM.WebApi.Models
{
    public class CommentModel : BaseEamEntityModel
    {
        public long? EntityId { get; set; }
        public string EntityType { get; set; }
        public string Message { get; set; }
    }
}