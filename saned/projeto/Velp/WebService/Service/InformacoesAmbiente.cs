using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SANEDWebService
{
    public class InformacoesAmbiente : IConfigurationSectionHandler
    {
        /// <summary>
        ///  Codigo universal do PDA
        /// </summary>
        [ConfigurationProperty("usuario", IsRequired = true)]
        public string usuario { get; set; }

        /// <summary>
        ///  Senha universal do PDA
        /// </summary>
        [ConfigurationProperty("senha", IsRequired = true)]
        public string senha { get; set; }

        /// <summary>
        /// Intervalo de tempo entre cada sincronização automática de envio
        /// </summary>
        [ConfigurationProperty("intervaloSinc", IsRequired = true)]
        public string intervaloSinc { get; set; }

        #region IConfigurationSectionHandler Members

        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            usuario = section.Attributes["usuario"].Value;
            senha = section.Attributes["senha"].Value;
            intervaloSinc = section.Attributes["intervaloSinc"].Value;

            return this;
        }

        #endregion
    }
}
