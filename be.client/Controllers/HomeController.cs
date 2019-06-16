using be.business.Model;
using be.client.Models;
using be.client.Source;
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
        }

        public ActionResult Index(HomeViewModel homeViewModel)
        {
            
            return View(homeViewModel);
        }

        public ActionResult RotacionarCabeca(HomeViewModel rotacaoStatus)
        {
            Service.Put(rotacaoStatus);
            return RedirectToAction("Index");
        }

        public ActionResult InclinarCabeca(string inclinacao)
        {
            return RedirectToAction("Index");
        }

        public ActionResult MoverBracoDireito(HomeViewModel homeViewModel)
        {
            return RedirectToAction("Index");
        }

        public ActionResult MoverBracoEsquerdo(HomeViewModel homeViewModel)
        {
            return RedirectToAction("Index");
        }



        public ActionResult MoverCotovelo(Lado lado, CotoveloStatus cotoveloStatus)
        {
            return View();
        }

        public ActionResult MoverPulso(Lado lado, PulsoStatus pulsoStatus)
        {
            return View();
        }


    }
}