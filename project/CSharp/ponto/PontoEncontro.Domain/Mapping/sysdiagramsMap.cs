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
    /// Classe de mapeamento de sysdiagrams
    /// </summary>
    public class sysdiagramsMap : ClassMap<sysdiagrams>
    {
		public sysdiagramsMap()
        {
		    Table("sysdiagrams");
                        Map(x => x.name);
            Map(x => x.principal_id);
            Id(x => x.diagram_id,"diagram_id").GeneratedBy.Native("sysdiagramsSeq");
            Map(x => x.version);
            Map(x => x.definition);
        }
    }
}
