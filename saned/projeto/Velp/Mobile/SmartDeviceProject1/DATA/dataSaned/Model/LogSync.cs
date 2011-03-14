using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DeviceProject.DATA.dataSaned.Model
{
    /// <summary>
    ///  Classe de mapeamento da tabela tblogsync
    /// </summary>
    public class LogSync
    {
        /// <summary>
        ///  Campos
        /// </summary>
        public long Matricula { get; set; }

        public DateTime DataSync { get; set; }

        public string TipoSync { get; set; }
    }
}
