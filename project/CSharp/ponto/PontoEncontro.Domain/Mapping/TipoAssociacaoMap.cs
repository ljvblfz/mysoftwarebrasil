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
    /// Classe de mapeamento de TipoAssociacao
    /// </summary>
    public class TipoAssociacaoMap : ClassMap<TipoAssociacao>
    {
		public TipoAssociacaoMap()
        {
		    Table("TipoAssociacao");
                        Id(x => x.idTipoAssociacao,"idTipoAssociacao").GeneratedBy.Native("TipoAssociacaoSeq");
            Map(x => x.nomeTipoAssociacao);
        }
    }
}
