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
    /// Classe de mapeamento de Foto
    /// </summary>
    public class FotoMap : ClassMap<Foto>
    {
        public FotoMap()
        {
            Table("Foto");
            Id(x => x.idFoto, "idFoto").GeneratedBy.Native("FotoSeq");
            Map(x => x.nameFoto);
            Map(x => x.pathFoto);
            Map(x => x.legendaFoto);
            Map(x => x.idMembro);
        }
    }
}
