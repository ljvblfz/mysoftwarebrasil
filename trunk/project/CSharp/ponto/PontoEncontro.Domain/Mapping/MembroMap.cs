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
    /// Classe de mapeamento de Membro
    /// </summary>
    public class MembroMap : ClassMap<Membro>
    {
        public MembroMap()
        {
            Table("Membro");
            Id(x => x.idMembro, "idMembro").GeneratedBy.Native("MembroSeq");
            Map(x => x.loginMembro);
            Map(x => x.senhaMembro);
            Map(x => x.idPessoa);
            Map(x => x.idRole);
            References(x => x.pessoa)
                .Column("idPessoa")
                .Not.Insert()
                .Not.Update()
                .Cascade.All();
        }
    }
}
