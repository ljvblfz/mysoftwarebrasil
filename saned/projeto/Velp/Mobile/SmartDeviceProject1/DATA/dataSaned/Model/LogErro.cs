using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DeviceProject.DATA.dataSaned.Model
{
    /// <summary>
    ///  Classe de mapeamento da tabela TBLOGERRO
    /// </summary>
    public class LogErro
    {
        /// <summary>
        ///  Nome da tabela no banco de dados
        /// </summary>
        protected string TableName = "TBLOGERRO";

        /// <summary>
        ///  Campos 
        /// </summary>
        public int id { get; set; }
        public DateTime data { get; set; }
        public string tabela { get; set; }
        public string rotina { get; set; }
        public string erro { get; set; }

        /// <summary>
        ///  Metodo responsavel por retorna o nome da tabela
        /// </summary>
        /// <returns>string nome da tabela</returns>
        public string GetTable()
        {
            return TableName;
        }
    }
}
