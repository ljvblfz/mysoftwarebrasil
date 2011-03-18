using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GDA;
using LTmobileData.Data.DAL;

namespace LTmobileData.Data.Model
{
    /// <summary>
    /// Usuário
    /// </summary>
    [PersistenceClass("LTTB_FUNCIONARIOS")]
    [PersistenceBaseDAO(typeof(UsuarioDAO))]
    public class Usuario
    {
        [PersistenceProperty("MATRIC_FUNC", PersistenceParameterType.Key)]
        public int MATRIC_FUNC { get; set; }

        [PersistenceProperty("SENHA_FUNC")]
        public string SENHA_FUNC { get; set; }
        
        [PersistenceProperty("NOME_FUNC")]
        public string NOME_FUNC{ get; set; }

        [PersistenceProperty("COD_LOCAL_TRAB")]
        public int COD_LOCAL_TRAB { get; set; }

        [PersistenceProperty("SITUAC_FUNC")]
        public int SITUAC_FUNC { get; set; }

        [PersistenceProperty("NUM_COLETR")]
        public int NUM_COLETR { get; set; }

        [PersistenceProperty("COD_EMPRT")]
        public int COD_EMPRT { get; set; }

    }
}
