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
    /// Classe de mapeamento de Controller
    /// </summary>
    public class ControllerMap : ClassMap<Controller>
    {
		public ControllerMap()
        {
		    Table("Controller");
                        Id(x => x.idController,"idController").GeneratedBy.Native("ControllerSeq");
            Map(x => x.nameController);
        }
    }
}
