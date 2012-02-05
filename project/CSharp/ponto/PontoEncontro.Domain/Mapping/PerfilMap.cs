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
    /// Classe de mapeamento de Perfil
    /// </summary>
    public class PerfilMap : ClassMap<Perfil>
    {
		public PerfilMap()
        {
		    Table("Perfil");
                        Map(x => x.idSexo);
            HasMany(x => x.idSexo);
            Map(x => x.idOlho);
            HasMany(x => x.idOlho);
            Map(x => x.idCabelo);
            HasMany(x => x.idCabelo);
            Map(x => x.idEtinia);
            HasMany(x => x.idEtinia);
            Map(x => x.idEstadoCivil);
            HasMany(x => x.idEstadoCivil);
            Map(x => x.idEndereco);
            HasMany(x => x.idEndereco);
            Id(x => x.idPerfil,"idPerfil").GeneratedBy.Native("PerfilSeq");
        }
    }
}
