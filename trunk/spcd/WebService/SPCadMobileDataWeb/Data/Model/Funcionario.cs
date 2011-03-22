using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;
using SPCadMobileDataWeb.Data.DAL;
namespace SPCadMobileDataWeb.Data.Model
{
    /// <summary>
    /// Classe Funcionário.
    /// </summary>
    [PersistenceClass("TB_FUNCIONARIO")]
    public class Funcionario: AuditoriaSuper
    {
        [PersistenceProperty("COD_FUNCN", PersistenceParameterType.Key)]
        public int Id { get; set; }

        [PersistenceProperty("NOM_FUNCN")]
        public string Nome { get; set; }

        [PersistenceProperty("TEL_FUNCN")]
        public string Telefone { get; set; }

        [PersistenceProperty("TIP_FUNCN")]
        public string Tipo { get; set; }

        [PersistenceProperty("LOGIN_FUNCN")]
        public string Login { get; set; }

        [PersistenceProperty("SENHA_FUNCN")]
        public string Senha { get; set; }
    }
}
