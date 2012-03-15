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
    /// Classe de mapeamento de Pessoa
    /// </summary>
    public class PessoaMap : ClassMap<Pessoa>
    {
        public PessoaMap()
        {
            Table("Pessoa");
            LazyLoad();
            Id(x => x.idPessoa, "idPessoa").GeneratedBy.Native("PessoaSeq");
            Map(x => x.idPerfil);
            Map(x => x.nomePessoa);
            Map(x => x.e_MailPessoa);
            Map(x => x.nascimentoPessoa);

            References(x => x.perfil)
                .Column("idPerfil")
                .Not.LazyLoad()
                .Not.Insert()
                .Not.Update()
                .Cascade.All();
        }
    }
}
