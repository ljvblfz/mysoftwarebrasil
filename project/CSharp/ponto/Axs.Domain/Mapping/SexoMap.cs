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
    /// Classe de mapeamento de Sexo
    /// </summary>
    public class SexoMap : ClassMap<Sexo>
    {
		public SexoMap()
        {
		    Table("Sexo");
                        Id(x => x.idSexo,"idSexo").GeneratedBy.Native("SexoSeq");
            Map(x => x.nameSexo);
        }
    }
}
