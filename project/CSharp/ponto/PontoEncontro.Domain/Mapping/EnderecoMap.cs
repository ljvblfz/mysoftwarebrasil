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
    /// Classe de mapeamento de Endereco
    /// </summary>
    public class EnderecoMap : ClassMap<Endereco>
    {
        public EnderecoMap()
        {
            Table("Endereco");
            LazyLoad();
            Id(x => x.idEndereco, "idEndereco").GeneratedBy.Native("EnderecoSeq");
            Map(x => x.CEP);
            Map(x => x.idCidade);
            Map(x => x.idBairro);

            References(x => x.bairro)
                .Column("idBairro")
                .Not.LazyLoad()
                .Not.Insert()
                .Not.Update();

            References(x => x.cidade)
                .Column("idCidade")
                .Not.LazyLoad()
                .Not.Insert()
                .Not.Update();
        }
    }
}
