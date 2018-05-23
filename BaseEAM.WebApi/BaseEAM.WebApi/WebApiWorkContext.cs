/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using BaseEAM.Core;
using BaseEAM.Core.Data;
using BaseEAM.Core.Domain;
using BaseEAM.Core.Domain.Security;
using BaseEAM.Services;
using System.Web;

namespace BaseEAM.WebApi
{
    public class WebApiWorkContext : IWorkContext
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Language> _languageRepository;

        private User _cachedUser;
        private Language _cachedLanguage;

        public WebApiWorkContext(IRepository<User> userRepository,
            IRepository<Language> languageRepository)
        {
            this._userRepository = userRepository;
            this._languageRepository = languageRepository;
        }

        public User CurrentUser
        {
            get
            {
                if (_cachedUser != null)
                    return _cachedUser;
                var httpContext = HttpContext.Current;
                if (httpContext == null || httpContext.Request == null
                    || !httpContext.Request.IsAuthenticated || httpContext.User == null)
                    return null;

                var identity = httpContext.User.Identity as BaseEamIdentity;
                var user = _userRepository.GetById(identity.UserId);
                _cachedUser = user;
                return _cachedUser;
            }
            set
            {
                _cachedUser = value;
            }
        }
        public Currency WorkingCurrency { get; set; }

        public virtual Language WorkingLanguage
        {
            get
            {
                var language = new Language();
                var user = this.CurrentUser;

                //in case we don't have current user, like when login
                if (user == null)
                {
                    language = _languageRepository.GetById(1); //default to en_US
                }
                else
                {
                    language = _languageRepository.GetById(user.LanguageId.Value);
                }
                _cachedLanguage = language;
                return _cachedLanguage;
            }
            set
            {
                //reset cache
                _cachedLanguage = null;
            }
        }
    }
}