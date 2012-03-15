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

namespace Axis.Domain.Mapping
{
    /// <summary>
    /// Classe de mapeamento de Associado
    /// </summary>
    public class AssociadoMap : ClassMap<Associado>
    {
        public AssociadoMap()
        {
            Table("Associado");
            Id(x => x.idAssociado, "idAssociado").GeneratedBy.Native("AssociadoSeq");
            Map(x => x.idMembro);
            Map(x => x.idAssociacao);
        }
    }
}
