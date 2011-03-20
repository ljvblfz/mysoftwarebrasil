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

    [ConfigurationProperty("logoRelatorio", IsRequired = true)]
    public string logoRelatorio { get; set; }

    [ConfigurationProperty("bancoMovel", IsRequired = true)]
    public string bancoMovel { get; set; }

    [ConfigurationProperty("pastaTemporaria", IsRequired = true)]
    public string pastaTemporaria { get; set; }

    #region IConfigurationSectionHandler Members

    public object Create(object parent, object configContext, System.Xml.XmlNode section)
    {
        tempo = section.Attributes["tempo"].Value;
        versao = section.Attributes["versao"].Value;
        logoRelatorio = section.Attributes["logoRelatorio"].Value;
        bancoMovel = section.Attributes["bancoMovel"].Value;
        pastaTemporaria = section.Attributes["pastaTemporaria"].Value;
        return this;
    }

    #endregion
}
