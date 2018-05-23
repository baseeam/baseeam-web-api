/*******************************************************
 * Copyright 2016 (C) BaseEAM Systems, Inc
 * All Rights Reserved
*******************************************************/
using BaseEAM.Core.Data;
using BaseEAM.Core.Domain;
using BaseEAM.Core.WebApi;
using System;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace BaseEAM.WebApi.Framework
{
    public static class WebApiCachingControllingData
    {
        private static object _lock = new object();

        public static string Key { get { return "WebApiControllingData"; } }

        public static void Remove()
        {
            try
            {
                HttpRuntime.Cache.Remove(Key);
            }
            catch { }
        }

        public static WebApiControllingCacheData Data()
        {
            var data = HttpRuntime.Cache[Key] as WebApiControllingCacheData;
            if (data == null)
            {
                lock (_lock)
                {
                    data = HttpRuntime.Cache[Key] as WebApiControllingCacheData;

                    if (data == null)
                    {
                        var settingRepository = WebApiEngineContext.Resolve<IRepository<Setting>>();

                        data = new WebApiControllingCacheData
                        {
                            ValidMinutePeriod = Convert.ToInt32(settingRepository.GetAll().Where(s => s.Name == "generalsettings.validminuteperiod").FirstOrDefault().Value),
                            NoRequestTimestampValidation = Convert.ToBoolean(settingRepository.GetAll().Where(s => s.Name == "generalsettings.norequesttimestampvalidation").FirstOrDefault().Value),
                            AllowEmptyMd5Hash = Convert.ToBoolean(settingRepository.GetAll().Where(s => s.Name == "generalsettings.allowemptymd5hash").FirstOrDefault().Value),
                            LogUnauthorized = Convert.ToBoolean(settingRepository.GetAll().Where(s => s.Name == "generalsettings.logunauthorized").FirstOrDefault().Value)
                        };

                        HttpRuntime.Cache.Add(Key, data, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, null);
                    }
                }
            }
            return data;
        }
    }

    public partial class WebApiControllingCacheData
    {
        public int ValidMinutePeriod { get; set; }
        public bool NoRequestTimestampValidation { get; set; }
        public bool AllowEmptyMd5Hash { get; set; }
        public bool LogUnauthorized { get; set; }
    }
}