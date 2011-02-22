using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Reflection;
using System.Web.Mvc;


public class DbTable<Model> where Model : new()
{
    /// <summary>
    ///  Carrega os valores postados no formulario na model
    /// </summary>
    /// <param name="Form">Formulario postado (retona na view com Request.Form)</param>
    /// <returns>Model carregada</returns>
    public static Model getCamposUteis(FormCollection Form)
    {
        // Model
        Model m = new Model();

        // Retorna as propriedades da model
        Type type = typeof(Model);
        PropertyInfo[] propertys = type.GetProperties();

        // Percorre todas as propriedades da model setando os valores
        foreach (PropertyInfo prop in propertys)
        {
            // Verifica se o valor existe no formulario
            if (!String.IsNullOrEmpty(Form[prop.Name]))
            {
                // retorna o tipo na model
                string t = m.GetType().GetProperty(prop.Name).PropertyType.Name;

                // converte o valor
                object value = ConvertString(t, Form[prop.Name]);

                // seta o valor
                m.GetType().GetProperty(prop.Name).SetValue(m, value, null);
            }
        }//foreach

        return m;
    }

    /// <summary>
    /// Converte uma string para o tipo desejado
    /// </summary>
    /// <param name="type">Tipo de saída</param>
    /// <param name="value">Valor de entrada</param>
    /// <returns>Objeto convertido com o tipo de saída</returns>
    public static object ConvertString(string type, string value)
    {

        #region Vars Tipos long, int .. Int64
        long tlong = 0;
        int tint = 0;
        Int16 tint16 = 0;
        Int32 tint32 = 0;
        Int64 tint64 = 0;
        #endregion

        #region Vars Tipos ulong, uint .. UInt64
        ulong utlong = 0;
        uint utint = 0;
        UInt16 utint16 = 0;
        UInt32 utint32 = 0;
        UInt64 utint64 = 0;
        #endregion

        #region Vars Tipos decimal, double e float
        decimal tdec = 0;
        double tdoub = 0;
        float tfloat = 0;
        bool tbool = false;
        #endregion

        DateTime tdatetime = DateTime.Now;

        switch (type)
        {

            case "Byte[]":
                return Convert.FromBase64String(value);

            case "string":
            case "String":
                return value.Trim();

            case "DateTime":
                try { tdatetime = DateTime.Parse(value); }
                catch (Exception) { /*sem tratamento*/ }
                return tdatetime;

            #region Case Tipos long, int .. Int64
            case "long":
                try { tlong = long.Parse(value); }
                catch (Exception) { /*sem tratamento*/ }
                return (long)tlong;
            case "int":
                try { tint = int.Parse(value); }
                catch (Exception) { /*sem tratamento*/ }
                return (int)tint;
            case "Int16":
                try { tint16 = Int16.Parse(value); }
                catch (Exception) { /*sem tratamento*/ }
                return (Int16)tint16;
            case "Int32":
                try { tint32 = Int32.Parse(value); }
                catch (Exception) { /*sem tratamento*/ }
                return (Int32)tint32;
            case "Int64":
                try { tint64 = Int64.Parse(value); }
                catch (Exception) { /*sem tratamento*/ }
                return (Int64)tint64;
            #endregion

            #region Case Tipos ulong, uint .. UInt64
            case "ulong":
                try { utlong = ulong.Parse(value); }
                catch (Exception) { /*sem tratamento*/ }
                return (ulong)utlong;
            case "uint":
                try { utint = uint.Parse(value); }
                catch (Exception) { /*sem tratamento*/ }
                return utint;
            case "UInt16":
                try { utint16 = UInt16.Parse(value); }
                catch (Exception) { /*sem tratamento*/ }
                return utint16;
            case "UInt32":
                try { utint32 = UInt32.Parse(value); }
                catch (Exception) { /*sem tratamento*/ }
                return utint32;
            case "UInt64":
                try { utint64 = UInt64.Parse(value); }
                catch (Exception) { /*sem tratamento*/ }
                return utint64;
            #endregion

            #region Case Tipos decimal, double e float
            case "decimal":
            case "Decimal":
                try { tdec = decimal.Parse(value); }
                catch (Exception) { /*sem tratamento*/ }
                return (decimal)tdec;
            case "double":
            case "Double":
                try { tdoub = double.Parse(value); }
                catch (Exception) { /*sem tratamento*/ }
                return (double)tdoub;
            case "float":
            case "Single":
                try { tfloat = float.Parse(value); }
                catch (Exception) { /*sem tratamento*/ }
                return (float)tfloat;
            case "Boolean":
                try { if (value == "on") { tbool = true; } }
                catch (Exception) { /*sem tratamento*/ }
                return (bool)tbool;
            #endregion


            default: return value;

        }

    }
}

