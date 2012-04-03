using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using Axis.Domain;
using System.Web.Mvc;
using Axis.Infrastructure.Linq;
using Telerik.Web.Mvc;
using Axis.Infrastructure.Filter;
using Axis.Infrastructure.Order;
using Axis.Infrastructure.MVC.Helper.Grid;

namespace Axis.Adapter
{
    public class MemberAdapter
    {
        /// <summary>
        /// Lista os dados
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static GridModel<Membro> List(GridCommand command)
        {
            int total = 0;
            var repo = new MembroRepository();
            var data = repo.List(
                            command.Page - 1,
                            (command.PageSize > 0 ? command.PageSize : 10),
                            OrderTelerik.ChangeOrder(command).ToArray(),
                            FilterTelerik.ChangeFilter(command).ToArray(),
                            out total);

            return GridTelerik<Membro>.MountGrid(data.ToArray(), total);
        }

        public static Dynamic ListMember(FormCollection form)
        {
            var idCidade = 0;
            var idEstado = 0;
            int.TryParse(form["Idcidade"], out idCidade);
            int.TryParse(form["Idestado"], out idEstado);
            var loginMembro = form["loginMembro"];
            var age = (
                        from a in form["Age"].Split('|') 
                        select DateTime.Now.AddYears(-int.Parse(String.IsNullOrEmpty(a) ? "0" : a)).Year
                      ).ToArray<int>();
            var lastUpdate = bool.Parse(form["lastUpdate"]);
            var lastAccessed = bool.Parse(form["LastAccessed"]);
            var list = new MembroRepository().ListAll();
            return new MembroRepository().ListMember(idEstado, idCidade, loginMembro, age, lastUpdate, lastAccessed);
        }

        /// <summary>
        ///  Recupera os dados o usuario
        /// </summary>
        /// <param name="loginMembro">nome do membro</param>
        /// <returns></returns>
        public static Dynamic Get(string loginMembro)
        {
            return new MembroRepository().GetMember(loginMembro);
        }

        /// <summary>
        ///  Retorna um select de idade
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> GetAge()
        {
            return new List<SelectListItem>()
                        {
                            new SelectListItem(){
                                Text = "Entre 18 e 24 anos"
                                ,Value = "18|24"
                                ,Selected = false
                            },
                            new SelectListItem(){
                                Text = "Entre 25 e 30 anos"
                                ,Value = "25|30"
                                ,Selected = false
                            },
                            new SelectListItem(){
                                Text = "Entre 30 e 40 anos"
                                ,Value = "30|40"
                                ,Selected = false
                            },
                            new SelectListItem(){
                                Text = "Entre 40 e 50 anos"
                                ,Value = "40|50"
                                ,Selected = false
                            },
                            new SelectListItem(){
                                Text = "Acima de 50 anos"
                                ,Value = "50"
                                ,Selected = false
                            },
                        };
        }
    }
}