using be.business.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace be.client.Source
{
    public class Service : ServiceBase
    {
        protected HttpWebRequest HttpWebRequest { get; set; }

        public Service(String baseUrl)
        {
            base.BaseUrl = baseUrl;
        }

        public Movimento Get()
        {
            return Get<Movimento>("/api/movimento");
        }

    }
}