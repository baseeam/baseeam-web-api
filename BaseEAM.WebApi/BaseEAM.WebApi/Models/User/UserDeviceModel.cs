/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
namespace BaseEAM.WebApi.Models
{
    public class UserDeviceModel
    {
        public string Platform { get; set; }
        public string DeviceType { get; set; }
        public string DeviceToken { get; set; }
    }
}