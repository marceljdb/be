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
                var mov = MovimentoRepository.FindById(movimento.Id);    
                var a = JsonConvert.DeserializeObject<Movimento>(mov.Movimento);
                a.Cabeca.IsValid(movimento.Cabeca);
                foreach (var item in a.Bracos)
                {
                    var braco = movimento.Bracos.Find(u => u.Lado.Equals(item.Lado));
                    item.IsValid(braco);
                }              
                mov.Movimento = JsonConvert.SerializeObject(movimento);                
                MovimentoRepository.UpdateAndFlush(mov);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new Error(e.Message));
            }
        }


    }
}
