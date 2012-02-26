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
    /// Classe de mapeamento de Cidade
    /// </summary>
    public class CidadeMap : ClassMap<Cidade>
    {
        public CidadeMap()
        {
            Table("Cidade");
            Id(x => x.idCidade, "idCidade").GeneratedBy.Native("CidadeSeq");
            Map(x => x.nameCidade);
            Map(x => x.idEstado);

            References(x => x.estado)
                .Column("idEstado")
                .Not.LazyLoad()
                .Not.Insert()
                .Not.Update();
        }
    }
}
