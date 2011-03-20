using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Reporting.WebForms;

/// <summary>
/// Summary description for Relatorio
/// </summary>
public static class Relatorio
{
    /// <summary>
    ///     Gerar o relatorio
    /// </summary>
    /// <param name="context"></param>
    /// <param name="nomeRelatorio"></param>
    /// <param name="report"></param>
    /// <param name="tipo"></param>
    public static void geraRelatorio(HttpContext context, string nomeRelatorio, LocalReport report, string tipo)
    {
        // Instancia as variaveis
        Warning[] warnings;
        string[] streamids;
        string mimeType;
        string encoding;
        string extension;

        // Gera codigo binario do relatorio
        byte[] bytes = report.Render(tipo, null, out mimeType, out encoding, out extension, out streamids, out warnings);

        try
        {
            // Cria o HEDER (para abrir para download)
            context.Response.ContentType = mimeType;
            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + nomeRelatorio + "." + extension);
            context.Response.AddHeader("Content-Length", bytes.Length.ToString());
            context.Response.OutputStream.Write(bytes, 0, bytes.Length);
        }
        catch (Exception ex)
        {
            Mail.SendErro(ex,"");
            
            ex.Data["warnings"] = warnings;
            ex.Data["streamids"] = streamids;
            ex.Data["mimetype"] = mimeType;
            ex.Data["encoding"] = encoding;
            ex.Data["extension"] = extension;
            throw ex;
        }

    }


    /// <summary>
    /// Retorna o nome do arquivo usado como logotipo no relatório.
    /// </summary>
    /// <param name="contexto">
    /// O contexto de HTTP que será usado para retornar o caminho da pasta.
    /// </param>
    /// <returns></returns>
    public static string GetReportLogo(HttpContext contexto)
    {
        return "file:///" + contexto.Request.PhysicalApplicationPath.Replace('\\', '/') + Config.Ambiente.logoRelatorio.Replace('\\', '/');
    }

}
