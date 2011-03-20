using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for ConfigAmbiente
/// </summary>
public static class Config
{
    /// <summary>
    ///  Variavel statica contendo as informacoes de ambiente
    /// </summary>
    public static InformacoesAmbiente Ambiente
    {
        // Cast(conversão) em meu objeto instanciado e uso o método GetSection
        // Para recuperar os dados da seção ConfigAmbiente que foi criada no Web.Config
        get {
            return (InformacoesAmbiente)ConfigurationManager.GetSection("ConfigAmbiente");
        }
    }
}
