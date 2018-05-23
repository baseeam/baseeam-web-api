/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using log4net;
using System.Web.Http.ExceptionHandling;

namespace BaseEAM.WebApi.Framework
{
    public class UnhandledExceptionLogger : ExceptionLogger
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(UnhandledExceptionLogger));
        public override void Log(ExceptionLoggerContext context)
        {
            var log = context.Exception.ToString();
            logger.Error(log);
        }
    }
}