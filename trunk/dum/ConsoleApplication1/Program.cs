using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Dum_Mobile;
using Dum_Mobile.Config;
using ConsoleApplication1.Model;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dum dum = new Dum();
            ONP_AGENTE agente = new ONP_AGENTE();
            dum.Insert(agente);
        }
    }
}
