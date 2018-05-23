/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using Autofac;
using Autofac.Integration.WebApi;
using BaseEAM.Core.Domain;
using BaseEAM.Core.WebApi;
using BaseEAM.WebApi.Framework;
using Microsoft.OData.Edm;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace BaseEAM.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.MessageHandlers.Add(new ResponseFormatHandler());

            config.EnableCors();

            // Web API configuration and services
            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            //DI setup
            var builder = new ContainerBuilder();

            AutofacConfig.RegisterServices(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            WebApiEngineContext.Initialize(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.MapODataServiceRoute("ODataRoute", "odata", GenerateEntityDataModel());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static IEdmModel GenerateEntityDataModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<WorkOrder>("WorkOrder");

            return builder.GetEdmModel();
        }
    }
}