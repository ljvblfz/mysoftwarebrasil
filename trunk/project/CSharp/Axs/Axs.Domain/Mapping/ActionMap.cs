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
    /// Classe de mapeamento de Action
    /// </summary>
    public class ActionMap : ClassMap<PontoEncontro.Domain.Action>
    {
		public ActionMap()
        {
		    Table("Action");
                        Id(x => x.idAction,"idAction").GeneratedBy.Native("ActionSeq");
            Map(x => x.nameAction);
        }
    }
}
