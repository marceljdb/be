using be.business.Facade;
using be.business.Model;
using be.business.Repository;
using be.business.Utils;
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
        public MovimentoRepository MovimentoRepository;

        public MovimentoController()
        {
            MovimentoRepository = new StandardKernel().Get<MovimentoRepository>();
        }

        [Route("api/movimento")]
        public Movimento Get()
        {
            return MovimentoRepository.FindFirst();
        }


        [HttpPut]
        [Route("api/movimento")]
        public HttpResponseMessage Put(Movimento movimento)
        {
            try
            {
                MovimentoRepository.Update(movimento);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new Error(e.Message));
            }
        }


    }
}
