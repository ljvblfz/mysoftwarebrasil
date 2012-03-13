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
    /// Classe de mapeamento de Estado
    /// </summary>
    public class EstadoMap : ClassMap<Estado>
    {
		public EstadoMap()
        {
		    Table("Estado");
                        Id(x => x.idEstado,"idEstado").GeneratedBy.Native("EstadoSeq");
            Map(x => x.nameEstado);
            Map(x => x.SiglaEstado);
        }
    }
}
