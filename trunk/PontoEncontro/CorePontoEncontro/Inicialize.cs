using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Framework.Config;
using CorePontoEncontro.Model;

namespace CorePontoEncontro
{
    public class Inicialize
    {
        public static void Ini()
        {
            IConfigurationSource source = ActiveRecordSectionHandler.Instance;
            ActiveRecordStarter.Initialize(source
                                            , typeof(Amigo)
                                            , typeof(Anuncio)
                                            , typeof(Cabelo)
                                            , typeof(Cidade)
                                            , typeof(Comunidade)
                                            , typeof(ComunidadeMembro)
                                            , typeof(Encontro)
                                            , typeof(EncontroMembro)
                                            , typeof(Endereco)
                                            , typeof(Estado)
                                            , typeof(EstadoCivil)
                                            , typeof(Etinia)
                                            , typeof(Favorito)
                                            , typeof(Foto)
                                            , typeof(inretessePessoa)
                                            , typeof(Interess)
                                            , typeof(Membro)
                                            , typeof(MembroAmigo)
                                            , typeof(MembroFavorito)
                                            , typeof(Menu)
                                            , typeof(MenuRole)
                                            , typeof(Olho)
                                            , typeof(Pais)
                                            , typeof(Perfil)
                                            , typeof(Pessoa)
                                            , typeof(Post)
                                            , typeof(Role)
                                            , typeof(RoleMembro)
                                            , typeof(Sexo)
                                            );
            //ActiveRecordStarter.CreateSchema();
        }
    }
}
