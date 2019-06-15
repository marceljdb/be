using be.business.Model;
using be.business.Repository;
using Newtonsoft.Json;
using Ninject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace be.Controllers
{
    public class MovimentoController : ApiController
    {
        [Inject]
        public MovimentoRepository MovimentoRepository;

        [Route("api/movimento")]
        public Movimento Get()
        {
            var a = MovimentoRepository.FindFirst();
            var movimento = JsonConvert.DeserializeObject<Movimento>(a.Movimento);
            return movimento; 

        }

        public HttpResponseMessage Put(Movimento movimento)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}
