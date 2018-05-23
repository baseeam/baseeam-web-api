/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using BaseEAM.WebApi.Validators;
using FluentValidation.Attributes;

namespace BaseEAM.WebApi.Models
{
    [Validator(typeof(UserValidator))]
    public class UserModel : BaseEamEntityModel
    {
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public bool WebApiEnabled { get; set; }
        public string PublicKey { get; set; }
        public string SecretKey { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TimeZoneId { get; set; }
        public long? LanguageId { get; set; }
        public string LanguageName { get; set; }
        public long? SupervisorId { get; set; }
        public string SupervisorName { get; set; }
        public long? DefaultSiteId { get; set; }
        public string CurrencySymbol { get; set; }
    }
}