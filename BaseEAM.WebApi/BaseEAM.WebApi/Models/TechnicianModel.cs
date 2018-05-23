/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/

namespace BaseEAM.WebApi.Models
{
    public class TechnicianModel : BaseEamEntityModel
    {
        public long? UserId { get; set; }
        public long? CalendarId { get; set; }
        public string CalendarName { get; set; }
        public long? ShiftId { get; set; }
        public string ShiftName { get; set; }
        public long? CraftId { get; set; }
    }
}