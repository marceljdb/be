using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace be.client.Source
{
    public abstract class ServiceFactory
    {
        private static readonly String SERVICE_URL_PATTERN = "{0}.URL";

        public static T GetService<T>()
        {
            var type = typeof(T).Name;
            //var url = ConfigurationManager.AppSettings[String.Format(SERVICE_URL_PATTERN, type)];
            var url = "http://localhost:49872/api";
            return (T)Activator.CreateInstance(typeof(T), new object[] { url });
        }
    }
}