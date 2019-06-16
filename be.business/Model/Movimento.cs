using System;
using System.Collections.Generic;
using System.Text;

namespace be.business.Model
{
    public class Movimento
    {
        public int Id { get; set; }

        public Cabeca Cabeca { get; set; }

        public List<Braco> Bracos { get; set; }
       
    }

}
