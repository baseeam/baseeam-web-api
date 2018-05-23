/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using BaseEAM.Core;
using BaseEAM.Core.Data;
using BaseEAM.Core.Domain;
using BaseEAM.Services;
using BaseEAM.WebApi.Framework;
using BaseEAM.WebApi.Models;
using BaseEAM.WebApi.Security;
using System.Linq;
using System.Web.Http;

namespace BaseEAM.WebApi.Controllers.v1
{
    public class UserController : ApiController
    {
        #region Fields

        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserDevice> _userDeviceRepository;
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly ILocalizationService _localizationService;
        private readonly IWorkContext _workContext;
        private readonly IRepository<Currency> _currencyRepository;
        private readonly CurrencySettings _currencySettings;

        #endregion

        #region Constructors

        public UserController(IRepository<User> userRepository,
            IRepository<UserDevice> userDeviceRepository,
            IUserRegistrationService userRegistrationService,
            ILocalizationService localizationService,
            IWorkContext workContext,
            IRepository<Currency> currencyRepository,
            CurrencySettings currencySettings)
        {
            this._userRepository = userRepository;
            this._userDeviceRepository = userDeviceRepository;
            this._userRegistrationService = userRegistrationService;
            this._localizationService = localizationService;
            this._workContext = workContext;
            this._currencyRepository = currencyRepository;
            this._currencySettings = currencySettings;
        }

        #endregion

        #region Methods

        [HttpPost]
        [Route("v1/user/login")]
        public UserModel Login([FromBody]UserModel model)
        {
            if (!ModelState.IsValid)
                throw this.ExceptionInvalidModelState();

            var loginResult = _userRegistrationService.ValidateUser(model.LoginName, model.LoginPassword);
            switch (loginResult)
            {
                case UserLoginResults.Successful:
                    {
                        var primarySystemCurrency = _currencyRepository.GetById(_currencySettings.PrimarySystemCurrencyId);
                        var user = _userRepository.GetAll().Where(u => u.LoginName == model.LoginName).FirstOrDefault();
                        return new UserModel
                        {
                            Id = user.Id,
                            Name = user.Name,
                            PublicKey = user.PublicKey,
                            SecretKey = user.SecretKey,
                            DefaultSiteId = user.DefaultSiteId,
                            CurrencySymbol = primarySystemCurrency.CurrencySymbol
                        };
                    }
                case UserLoginResults.UserNotExist:
                    throw this.ExceptionUnauthorized(_localizationService.GetResource("User.Login.WrongCredentials.UserNotExist"));
                case UserLoginResults.Deleted:
                    throw this.ExceptionUnauthorized(_localizationService.GetResource("User.Login.WrongCredentials.Deleted"));
                case UserLoginResults.NotActive:
                    throw this.ExceptionUnauthorized(_localizationService.GetResource("User.Login.WrongCredentials.NotActive"));
                case UserLoginResults.NotRegistered:
                    throw this.ExceptionUnauthorized(_localizationService.GetResource("User.Login.WrongCredentials.NotRegistered"));
                case UserLoginResults.WrongPassword:
                default:
                    throw this.ExceptionUnauthorized(_localizationService.GetResource("User.Login.WrongCredentials"));
            }
        }

        [WebApiAuthenticate]
        [HttpPost]
        [Route("v1/user/registerdevice")]
        public UserDeviceModel RegisterDevice([FromBody]UserDeviceModel model)
        {
            var device = _userDeviceRepository.GetAll()
                .Where(u => u.UserId == _workContext.CurrentUser.Id && u.Platform == model.Platform && u.DeviceType == model.DeviceType)
                .FirstOrDefault();
            if (device != null)
            {
                if (device.DeviceToken != model.DeviceToken)
                    device.DeviceToken = model.DeviceToken;
                _userDeviceRepository.UpdateAndCommit(device);
            }
            else
            {
                device = new UserDevice
                {
                    UserId = _workContext.CurrentUser.Id,
                    Platform = model.Platform,
                    DeviceType = model.DeviceType,
                    DeviceToken = model.DeviceToken
                };
                _userDeviceRepository.InsertAndCommit(device);
            }
            return model;
        }

        [HttpGet]
        [Route("v1/user/heartbeat")]
        public string HeartBeat()
        {
            return "I'm doing awesome!";
        }

        #endregion
    }
}
