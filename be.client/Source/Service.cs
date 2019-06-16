using be.business.Model;
using be.client.Models;
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

        public void Put(HomeViewModel homeViewModel)
        {
            Invoke("/movimento", "PUT", homeViewModel);
        }
    }
}