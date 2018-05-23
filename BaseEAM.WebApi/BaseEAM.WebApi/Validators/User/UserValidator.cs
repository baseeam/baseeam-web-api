/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using BaseEAM.WebApi.Models;
using FluentValidation;

namespace BaseEAM.WebApi.Validators
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.LoginName).NotEmpty().WithMessage("LoginName is required.");
            RuleFor(x => x.LoginPassword).NotEmpty().WithMessage("LoginPassword is required.");
        }
    }
}