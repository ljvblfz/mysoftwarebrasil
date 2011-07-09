using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Infrastructure;
using System;


using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using Infrastructure;
using System;

namespace Infrastructure.Model
{
    public class Amigos
    {
        #region properties

        [ScaffoldColumn(false)]
        public int amigoId { get; set; }

        #endregion

        #region constructors

        public Amigos()
        {
        }

        public Amigos(dynamic entity)
        {
            this.amigoId = entity.amigoId;
        }

        #endregion
    }
}

