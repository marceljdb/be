using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace be.business.Utils
{
    public class Error
    {
        public String Mensagem { get; set; }
        public String ExceptionMessage { get; set; }

        public Error(String mensagem)
        {
            this.Mensagem = mensagem;
        }

        public Error(String Mensagem, String ExceptionMessage)
        {
            this.Mensagem = Mensagem;
            this.ExceptionMessage = ExceptionMessage;
        }
    }
}
