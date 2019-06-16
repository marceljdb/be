using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be.business.Utils
{
    public class Error : Exception
    {
        public String Mensagem { get; set; }
        public String ExceptionMessage { get; set; }

        public Error()
        {

        }

        public Error(string message)
           : base(message)
        {
        }
      
    }
}
