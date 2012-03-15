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
    /// Classe de mapeamento de Bairro
    /// </summary>
    public class BairroMap : ClassMap<Bairro>
    {
		public BairroMap()
        {
		    Table("Bairro");
                        Id(x => x.idBairro,"idBairro").GeneratedBy.Native("BairroSeq");
            Map(x => x.nomeBairro);
        }
    }
}
