/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using AutoMapper;
using BaseEAM.Core.Infrastructure;
using BaseEAM.Core.Infrastructure.Mapper;
using System;
using System.Collections.Generic;

namespace BaseEAM.WebApi.Infrastructure
{
    public class AutoMapperStartupTask : IStartupTask
    {
        public void Execute()
        {
            var mc = new Mapper.MapperConfiguration();
            //get configurations
            var configurationActions = new List<Action<IMapperConfigurationExpression>>();
            configurationActions.Add(mc.GetConfiguration());
            //register
            AutoMapperConfiguration.Init(configurationActions);
        }

        public int Order
        {
            get { return 0; }
        }
    }
}