﻿using be.business.Model;
using be.client.Models;
using be.client.Source;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private Service Service;


        public HomeController()
        {
            Service = ServiceFactory.GetService<Service>();
            Service.Controller = this;
        }

        public ActionResult Index(Movimento movimento)
        {
            if (movimento.Cabeca == null)
            {
                try
                {
                    movimento = Service.Get();
                } catch (Exception e)
                {
                    return RedirectToAction("Index", "Error");
                }
            }
            return View(movimento);
        }


        [HttpPost]
        public string Atualizar(Movimento movimento)
        {
            Service.Put(movimento);
            return "Alterado!";
        }


    }
}