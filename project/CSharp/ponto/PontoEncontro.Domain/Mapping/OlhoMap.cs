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
    /// Classe de mapeamento de Olho
    /// </summary>
    public class OlhoMap : ClassMap<Olho>
    {
		public OlhoMap()
        {
		    Table("Olho");
                        Id(x => x.idOlho,"idOlho").GeneratedBy.Native("OlhoSeq");
            Map(x => x.nameOlho);
        }
    }
}
