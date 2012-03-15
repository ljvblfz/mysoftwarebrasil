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
    /// Classe de mapeamento de Perfil
    /// </summary>
    public class PerfilMap : ClassMap<Perfil>
    {
        public PerfilMap()
        {
            Table("Perfil");
            LazyLoad();
            Id(x => x.idPerfil, "idPerfil").GeneratedBy.Native("PerfilSeq");
            Map(x => x.idSexo);
            Map(x => x.idOlho);
            Map(x => x.idCabelo);
            Map(x => x.idEtinia);
            Map(x => x.idEstadoCivil);
            Map(x => x.idEndereco);

            References(x => x.sexo)
                .Column("idSexo")
                .Not.LazyLoad()
                .Not.Insert()
                .Not.Update();

            References(x => x.olho)
                .Column("idOlho")
                .Not.LazyLoad()
                .Not.Insert()
                .Not.Update();

            References(x => x.cabelo)
                .Column("idCabelo")
                .Not.LazyLoad()
                .Not.Insert()
                .Not.Update();

            References(x => x.etinia)
                .Column("idEtinia")
                .Not.LazyLoad()
                .Not.Insert()
                .Not.Update();

            References(x => x.estadoCivil)
                .Column("idEstadoCivil")
                .Not.LazyLoad()
                .Not.Insert()
                .Not.Update();

            References(x => x.endereco)
                .Column("idEndereco")
                .Not.LazyLoad()
                .Not.Insert()
                .Not.Update();
        }
    }
}
