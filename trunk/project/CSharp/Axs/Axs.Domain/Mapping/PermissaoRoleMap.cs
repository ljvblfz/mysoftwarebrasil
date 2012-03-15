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
    /// Classe de mapeamento de PermissaoRole
    /// </summary>
    public class PermissaoRoleMap : ClassMap<PermissaoRole>
    {
		public PermissaoRoleMap()
        {
		    Table("PermissaoRole");
            Id(x => x.idRole,"idRole").GeneratedBy.Native("PermissaoRoleSeq");
            Map(x => x.idPermissao,"idPermissao");
        }
    }
}
