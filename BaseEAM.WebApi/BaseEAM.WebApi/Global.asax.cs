/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using BaseEAM.Data.Interceptors;
using BaseEAM.WebApi.Infrastructure;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Web.Http;

namespace BaseEAM.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //we don't use SoftDeleteInterceptor in WebApi
            //so we replaced it here
            DbConfiguration.Loaded += (_, a) =>
            {
                a.ReplaceService<IDbCommandTreeInterceptor>((s, k) => new NullInterceptor());
            };

            GlobalConfiguration.Configure(WebApiConfig.Register);

            //start StartupTask manually
            var autoMapperStartupTask = new AutoMapperStartupTask();
            autoMapperStartupTask.Execute();
        }
    }
}
