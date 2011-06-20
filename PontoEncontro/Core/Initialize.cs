using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;
using Core.Model;
using Castle.ActiveRecord.Framework;
using System.Collections;


namespace Core
{
    public class Initialize
    {
        public static void Ini()
        {
            IConfigurationSource source = ActiveRecordSectionHandler.Instance;
            //XmlConfigurationSource source = new XmlConfigurationSource(stream);
            //IDictionary<string, string> properties = new Dictionary<string, string>();
            //properties.Add("hibernate.connection.driver_class", "NHibernate.Driver.SqlClientDriver");
            //properties.Add("hibernate.dialect", "NHibernate.Dialect.MsSql2005Dialect");
            //properties.Add("hibernate.connection.provider", "NHibernate.Connection.DriverConnectionProvider");
            //properties.Add("hibernate.connection.connection_string", "Data Source=ZEUS;Initial Catalog=pontoencontro;Integrated Security=SSPI");
            //InPlaceConfigurationSource source = new InPlaceConfigurationSource();
            //source.Add(typeof(ActiveRecordBase), properties);
            ActiveRecordStarter.Initialize(
                                            source
                                            //, typeof(Core.Model.Amigo)
                                            //, typeof(Core.Model.Amigo)
                                            //, typeof(Anuncio)
                                            //, typeof(Cabelo)
                                            //, typeof(Cidade)
                                            //, typeof(Comunidade)
                                            //, typeof(ComunidadeMembro)
                                            //, typeof(Encontro)
                                            //, typeof(EncontroMembro)
                                            //, typeof(Endereco)
                                            //, typeof(Estado)
                                            //, typeof(EstadoCivil)
                                            //, typeof(Etinia)
                                            //, typeof(Favorito)
                                            //, typeof(Foto)
                                            //, typeof(inretessePessoa)
                                            //, typeof(Interess)
                                            //, typeof(Membro)
                                            //, typeof(Core.Model.MembroAmigo)
                                            //, typeof(MembroFavorito)
                                            , typeof(Core.Model.Menu)
                                            //, typeof(MenuRole)
                                            //, typeof(Olho)
                                            //, typeof(Pais)
                                            //, typeof(Perfil)
                                            //, typeof(Pessoa)
                                            //, typeof(Post)
                                            //, typeof(Role)
                                            //, typeof(RoleMembro)
                                            //, typeof(Sexo)
                                          );

            //ActiveRecordStarter.CreateSchema(); // Metodo que cria as tabelas no banco
        }
    }
}
