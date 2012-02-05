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
            Id(x => x.idPerfil, "idPerfil").GeneratedBy.Native("PerfilSeq");
            Map(x => x.idSexo);
            Map(x => x.idOlho);
            Map(x => x.idCabelo);
            Map(x => x.idEtinia);
            Map(x => x.idEstadoCivil);
            Map(x => x.idEndereco);

        }
    }
}
