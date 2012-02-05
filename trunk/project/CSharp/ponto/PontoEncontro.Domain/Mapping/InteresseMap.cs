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
    /// Classe de mapeamento de Interesse
    /// </summary>
    public class InteresseMap : ClassMap<Interesse>
    {
        public InteresseMap()
        {
            Table("Interesse");
            Id(x => x.idInteresse, "idInteresse").GeneratedBy.Native("InteresseSeq");
            Map(x => x.Descricao);
            Map(x => x.idTipoInteresse);
            Map(x => x.idPerfil);
        }
    }
}
