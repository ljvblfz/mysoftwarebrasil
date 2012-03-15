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
    /// Classe de mapeamento de EstadoCivil
    /// </summary>
    public class EstadoCivilMap : ClassMap<EstadoCivil>
    {
		public EstadoCivilMap()
        {
		    Table("EstadoCivil");
                        Id(x => x.idEstadoCivil,"idEstadoCivil").GeneratedBy.Native("EstadoCivilSeq");
            Map(x => x.nameEstadoCivil);
        }
    }
}
