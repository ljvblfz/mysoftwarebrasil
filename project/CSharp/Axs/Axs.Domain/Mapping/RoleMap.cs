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
    /// Classe de mapeamento de Role
    /// </summary>
    public class RoleMap : ClassMap<Role>
    {
		public RoleMap()
        {
		    Table("Role");
                        Id(x => x.idRole,"idRole").GeneratedBy.Native("RoleSeq");
            Map(x => x.nameRole);
        }
    }
}
