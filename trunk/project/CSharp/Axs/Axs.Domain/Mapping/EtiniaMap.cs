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
    /// Classe de mapeamento de Etinia
    /// </summary>
    public class EtiniaMap : ClassMap<Etinia>
    {
		public EtiniaMap()
        {
		    Table("Etinia");
                        Id(x => x.idEtinia,"idEtinia").GeneratedBy.Native("EtiniaSeq");
            Map(x => x.nameEtinia);
        }
    }
}
