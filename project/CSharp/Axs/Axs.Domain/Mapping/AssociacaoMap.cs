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
    /// Classe de mapeamento de Associacao
    /// </summary>
    public class AssociacaoMap : ClassMap<Associacao>
    {
        public AssociacaoMap()
        {
            Table("Associacao");
            Id(x => x.idAssociacao, "idAssociacao").GeneratedBy.Native("AssociacaoSeq");
            Map(x => x.idTipoAssociacao);
            Map(x => x.idMembro);
            Map(x => x.idPessoa);
        }
    }
}
