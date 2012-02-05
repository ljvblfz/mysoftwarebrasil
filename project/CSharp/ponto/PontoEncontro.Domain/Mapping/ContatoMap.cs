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
    /// Classe de mapeamento de Contato
    /// </summary>
    public class ContatoMap : ClassMap<Contato>
    {
		public ContatoMap()
        {
		    Table("Contato");
                        Id(x => x.idContato,"idContato").GeneratedBy.Native("ContatoSeq");
            Map(x => x.valorContato);
            Map(x => x.idPerfil);
            HasMany(x => x.idPerfil);
            Map(x => x.idTipoContato);
            HasMany(x => x.idTipoContato);
        }
    }
}
