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
    /// Classe de mapeamento de Cabelo
    /// </summary>
    public class CabeloMap : ClassMap<Cabelo>
    {
		public CabeloMap()
        {
		    Table("Cabelo");
                        Id(x => x.idCabelo,"idCabelo").GeneratedBy.Native("CabeloSeq");
            Map(x => x.nameCabelo);
        }
    }
}
