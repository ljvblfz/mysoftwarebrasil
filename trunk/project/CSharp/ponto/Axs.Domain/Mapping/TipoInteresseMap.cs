//
//  Copyright (c) 2012, AXS 
//  All rights reserved.
//
//  Authors: 
//          
//           * Alexis Moura
//           Generation
//           Messenger:
//
using System.Collections.Generic;
using System.Text;
using System;
using FluentNHibernate.Mapping;

namespace PontoEncontro.Domain.Mapping
{
    /// <summary>
    /// Classe de mapeamento de TipoInteresse
    /// </summary>
    public class TipoInteresseMap : ClassMap<TipoInteresse>
    {
		public TipoInteresseMap()
        {
		    Table("TipoInteresse");
                        Id(x => x.idTipoInteresse,"idTipoInteresse").GeneratedBy.Native("TipoInteresseSeq");
            Map(x => x.nameTipoInteresse);
        }
    }
}
