using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dum_Mobile;
using System.Configuration;
using ConsoleApplication1.Model;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Dum dum = new Dum();
            ONP_AGENTE onp_agente= new ONP_AGENTE();
            onp_agente.cod_agente = 1001;
            onp_agente.nom_agente = "teste";
            onp_agente.des_senha = "sdsdsds";

            Primary p = GetAttribute(typeof(ONP_AGENTE));

            dum.Insert(onp_agente);
        }

        public static Primary GetAttribute(Type t)
        {
            //Get instance of the attribute.  
            Primary primary = (Primary)Attribute.GetCustomAttribute(t, typeof(Primary));
            return primary;
        }
    }
}
