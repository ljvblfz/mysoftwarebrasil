using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;

namespace GeraBase.Model
{
    [PersistenceClass("Coletor")]
    public class Coletor
    {
        [PersistenceProperty("id", PersistenceParameterType.Key)]
        public string Id { get; set; }

        [PersistenceProperty("modelo")]
        public string Modelo { get; set; }

        [PersistenceProperty("fabricante")]
        public string fabricante { get; set; }

        [PersistenceProperty("num_serie")]
        public string NumSerie { get; set; }

        [PersistenceProperty("codigo")]
        public int codigo { get; set; }


        public Coletor()
        { 
        }

        public Coletor(string id)
        {
            Id = id;
        }
    }
}
