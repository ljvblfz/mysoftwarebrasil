using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InformacoesAmbiente
/// </summary>
public class InformacoesAmbiente : IConfigurationSectionHandler
{
    [ConfigurationProperty("tempo", IsRequired = true)]
    public string tempo { get; set; }

    [ConfigurationProperty("versao", IsRequired = true)]
    public string versao { get; set; }

    #region IConfigurationSectionHandler Members

    public object Create(object parent, object configContext, System.Xml.XmlNode section)
    {
        tempo = section.Attributes["tempo"].Value;
        versao = section.Attributes["versao"].Value;
        return this;
    }

    #endregion
}
