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
    /// Classe de mapeamento de Permissoes
    /// </summary>
    public class PermissoesMap : ClassMap<Permissoes>
    {
        public PermissoesMap()
        {
            Table("Permissoes");
            Id(x => x.idPermissao, "idPermissao").GeneratedBy.Native("PermissoesSeq");
            Map(x => x.namePermissao);
            Map(x => x.idAction);
            Map(x => x.idController);
        }
    }
}
