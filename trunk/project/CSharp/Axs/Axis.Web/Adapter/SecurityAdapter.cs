using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Axis.Domain;
using Axis.Infrastructure;
using System.Web.Mvc;

namespace Axis.Adapter
{
    /// <summary>
    ///  Adaptador de segurança
    /// </summary>
    public class SecurityAdapter
    {
        /// <summary>
        ///  Armazena o dados de membro para registro
        /// </summary>
        /// <param name="member">objeto membro</param>
        public static void RegisterMember(Membro member)
        {
            member.idRole = 2;
            Aplication.AddCookie(member, "Member");
        }

        /// <summary>
        ///  Armazena o dados pessoais para registro
        /// </summary>
        /// <param name="member">objeto membro</param>
        public static void RegisterPerson(Pessoa person, FormCollection form)
        {
            var idCidade = 1;
            var idestado = 1;
            int.TryParse(form["Idcidade"], out idCidade);
            int.TryParse(form["Idestado"], out idestado);

            var address = new Endereco()
            {
                idCidade = idCidade,
                idBairro = 1
            };
            Aplication.AddCookie(address, "Address");
            Aplication.AddCookie(person, "Person");
        }

        /// <summary>
        ///  Armazena o dados de perfil para registro
        /// </summary>
        /// <param name="member">objeto membro</param>
        public static void RegisterProfile(FormCollection form)
        {
            var profile = new Perfil()
            {
                idCabelo = int.Parse(form["idCabelo"]),
                idEndereco = 0,
                idEstadoCivil = int.Parse(form["idEstadoCivil"]),
                idEtinia = int.Parse(form["idEtinia"]),
                idOlho = int.Parse(form["idOlho"]),
                idSexo = int.Parse(form["idSexo"]),
            };
            Aplication.AddCookie(profile, "Profile");
        }

        /// <summary>
        ///  Realiza o registro de usuario
        /// </summary>
        /// <returns>true se o usuario foi registrado</returns>
        public static bool CompleteRecordUser()
        {
            var address = Aplication.GetCookie(typeof(Endereco), "Address") as Endereco;
            var member = Aplication.GetCookie(typeof(Membro), "Member") as Membro;
            var person = Aplication.GetCookie(typeof(Pessoa), "Person") as Pessoa;
            var profile = Aplication.GetCookie(typeof(Perfil), "Profile") as Perfil;
            return new MembroRepository().Register(member, profile, address, person);
        }

        /// <summary>
        ///  Atualiza os dados de mebro
        /// </summary>
        /// <param name="model">modelo</param>
        public static void UpdateMember(Membro model)
        {
            var member = Aplication.GetUser<Membro>(typeof(Membro)) as Membro;
            member.loginMembro = model.loginMembro;
            new MembroRepository().Update(member);
            Aplication.UpdaterUser(member);
        }
        
        /// <summary>
        ///  Retorna todos os dados do membro logado
        /// </summary>
        /// <returns></returns>
        public static Membro GetMember()
        {
            var membroCookie = Aplication.GetUser<Membro>(typeof(Membro)) as Membro;
            return new MembroRepository().GetMemberLogin(membroCookie.loginMembro);
        }
    }
}