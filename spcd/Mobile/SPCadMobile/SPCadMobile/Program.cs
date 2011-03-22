using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using SPCadMobile;
using SPCadMobile.View;
using CommonHelpMobile;
using GDA;

namespace SPCadMobile
{
    static class Program
    {        
        [MTAThread]
        static void Main()
        {
            //conecta com a base de dados.
            ConnectionGDA.DataBaseConnect("SPcad.sdf", "velp2010");

            //new frmDadosImovel(1001, 112233).ShowDialog();
            new frmLogin().ShowDialog();
        }        
    }
}