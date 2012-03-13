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
    /// Classe de mapeamento de TipoContato
    /// </summary>
    public class TipoContatoMap : ClassMap<TipoContato>
    {
		public TipoContatoMap()
        {
		    Table("TipoContato");
                        Id(x => x.idTipoContato,"idTipoContato").GeneratedBy.Native("TipoContatoSeq");
            Map(x => x.nameTipoContato);
        }
    }
}
