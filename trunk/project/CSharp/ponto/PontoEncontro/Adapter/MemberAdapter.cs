using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using PontoEncontro.Domain;
using System.Web.Mvc;
using PontoEncontro.Infrastructure.Linq;

namespace PontoEncontro.Adapter
{
    public class MemberAdapter
    {
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
            return new MembroRepository().ListMember(idEstado, idCidade, loginMembro, age, lastUpdate, lastAccessed);
        }

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