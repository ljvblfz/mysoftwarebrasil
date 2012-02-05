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
    /// Classe de mapeamento de Menu
    /// </summary>
    public class MenuMap : ClassMap<Menu>
    {
		public MenuMap()
        {
		    Table("Menu");
                        Id(x => x.idMenu,"idMenu").GeneratedBy.Native("MenuSeq");
            Map(x => x.MenuIdPai);
            HasMany(x => x.MenuIdPai);
            Map(x => x.nameMenu);
            Map(x => x.ordemMenu);
            Map(x => x.pathMenu);
        }
    }
}
