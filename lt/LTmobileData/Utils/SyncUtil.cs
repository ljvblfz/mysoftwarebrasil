using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace LTmobileData.Utils
{

    public class SyncUtil<T, T2>
        where T : new()
        where T2 : new()
    {

        /// <summary>
        /// Carrega um tipo da sistema.
        /// </summary>
        /// <param name="assemblyName">Assembly onde o tipo está incluído.</param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static Type LoadType(string assemblyName, string typeName)
        {
            // Carrega o tipo do cliente
            Type type1 = System.Reflection.Assembly.Load(assemblyName).GetType(typeName, false);

            int pos = 0;

            // Verifica se os dados do cliente não foram carregados
            if (type1 == null)
            {
                string assemblyFileName = null;

                while (true)
                {
                    // Recupera a posição do próximo ponto no nome 
                    pos = typeName.IndexOf(".", pos);

                    if (pos < 0) break;

                    string fileSearch = typeName.Substring(0, pos) + "*.dll";

                    // Pula o nome
                    pos++;

                    // Recupera os arquivo do diretório raíz
                    string[] files = System.IO.Directory.GetFiles(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName), fileSearch);

                    if (files.Length == 0)
                        break;

                    // Recupera o primeiro arquivo
                    assemblyFileName = files[0];

                    // Recupera o arquivo com menor nome
                    for (int i = 1; i < files.Length; i++)
                        if (files[i].Length < assemblyFileName.Length)
                            assemblyFileName = files[i];
                }

                // Verifica se um possível arquivo de biblioteca foi carregado
                if (assemblyFileName == null)
                    throw new Exception("Type \"" + typeName + "\" not load.");
                else
                {
                    try
                    {
                        // Carrega o arquivo do assembly
                        return System.Reflection.Assembly.LoadFrom(assemblyFileName).GetType(typeName, true);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Type \"" + typeName + "\" not load.", ex);
                    }
                }
            }

            return type1;
        }

        /// <summary>
        /// Converte uma string para o tipo desejado
        /// </summary>
        /// <param name="type">Tipo de saída</param>
        /// <param name="value">Valor de entrada</param>
        /// <returns>Objeto convertido com o tipo de saída</returns>
        static public object ConvertString(string type, string value)
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
                #endregion


                default: return value;

            }

        }

        /// <summary>
        /// Converte um vetor de WSObject para uma lista de Model
        /// </summary>
        /// <param name="model"></param>
        static public List<T> ConvertWSObjectToModel(ref T2[] lstEntrada)
        {
            // T = tipo local - T2 = tipo do WS

            List<T> lstRetorno = new List<T>();

            // Se lstEntrada estiver vazia sai imediatamente do método para evitar erro
            if (lstEntrada == null)
                lstEntrada = new T2[0];
            if (lstEntrada.Length == 0)
                return lstRetorno;

            //Percorre todos os registros
            foreach (T2 obj in lstEntrada)
            {
                T retorno = new T();
                T2 env = new T2();
                //Percorre todas as propriedades
                foreach (PropertyInfo prop in typeof(T2).GetProperties())
                {
                    string nome = prop.Name;
                    string nomeLow = prop.Name;
                    nome = char.ToUpper(nome[0]) + nome.Substring(1);

                    nomeLow = char.ToLower(nome[0]) + nome.Substring(1);

                    PropertyInfo property = retorno.GetType().GetProperty(nome);

                    bool tipoNulo = false;
                    if (property != null)
                    {
                        PropertyInfo envproperty = retorno.GetType().GetProperty(nome);
                        string teste = property.PropertyType.Name;
                        if (envproperty.PropertyType.Name == "Nullable`1")
                        {
                            teste = NullableType(envproperty);
                        }
                        switch (teste)
                        {
                            case "DateTime":
                            case "long":
                            case "Int64":
                                envproperty = env.GetType().GetProperty(nomeLow + "Specified");

                                if (envproperty != null)
                                    tipoNulo = !(bool)envproperty.GetValue(obj, null);
                                break;
                        }

                        if (property.PropertyType.Name == "Nullable`1")
                        {
                            //if (prop.GetValue(obj, null) == null)
                            //property.SetValue(retorno, ConvertString(NullableType(property), ""), null);
                            if (!tipoNulo)
                            {
                                object valor = (prop.GetValue(obj, null) == null) ? null : ConvertString(NullableType(property), prop.GetValue(obj, null).ToString());
                                property.SetValue(retorno, valor, null);
                            }
                            else
                            {
                                property.SetValue(retorno, null, null);
                            }
                            //                            property.SetValue(obj, ConvertString(NullableType(property), ""), null);
                        }
                        else
                        {
                            try
                            {
                                property.SetValue(retorno, ConvertString(property.PropertyType.Name, prop.GetValue(obj, null).ToString()), null);
                            }
                            catch (Exception)
                            {
                                property.SetValue(retorno, "", null);
                            }
                        }

                    }
                }
                lstRetorno.Add(retorno);
            }

            return lstRetorno;
        }

        /// <summary>
        /// Converte uma lista de Model para um vetor de WSObject
        /// </summary>
        /// <param name="model"></param>
        static public T2[] ConvertModelToWSObject(List<T> lstEntrada)
        {
            // T = tipo local - T2 = tipo do WS

            List<T2> lstRetorno = new List<T2>();

            //Percorre todos os registros
            foreach (T obj in lstEntrada)
            {
                T2 retorno = new T2();
                //Percorre todas as propriedades
                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    string nome = prop.Name;
                    //nome = char.ToLower(nome[0]) + nome.Substring(1);

                    PropertyInfo property = retorno.GetType().GetProperty(nome);

                    if (property != null)
                    {
                        //if (property.PropertyType.Name == "Nullable`1")
                        bool tipoNulo = false;
                        if (prop.GetValue(obj, null) == null)
                        {
                            tipoNulo = true;
                            string nullo = NullableType(property);
                            property.SetValue(retorno, ConvertString(nullo, ""), null);
                        }
                        //                            property.SetValue(obj, ConvertString(NullableType(property), ""), null);
                        else
                        {
                            if (property.PropertyType.Name == "Boolean")
                                property.SetValue(retorno, prop.GetValue(obj, null), null);

                            else if (property.PropertyType.Name == "Nullable`1")
                                property.SetValue(retorno, ConvertString(NullableType(property), prop.GetValue(obj, null).ToString()), null);
                            else
                                property.SetValue(retorno, ConvertString(property.PropertyType.Name, prop.GetValue(obj, null).ToString()), null);
                        }
                        switch (property.PropertyType.Name)
                        {
                            case "DateTime":
                            case "long":
                            case "Int64":
                                property = retorno.GetType().GetProperty(nome + "Specified");

                                if (property != null)
                                    property.SetValue(retorno, !tipoNulo, null);
                                break;
                        }
                    }
                }
                lstRetorno.Add(retorno);
            }
            return lstRetorno.ToArray();
        }

        /// <summary>
        /// Converte um vetor de XMLNode para uma lista de Model
        /// </summary>
        /// <param name="model"></param>
        /// <param name="xmlNodes"></param>
        /*static public List<object> ConvertXMLNodeToModel(Type model, List<object> xmlNodes)
         {
             return ConvertXMLNodeToModel(model, xmlNodes.ToArray());

         }*/

        /// <summary>
        /// Retorna o Tipo da variável declarada Nullable.
        /// </summary>
        /// <param name="property">Propriedades da variável nullable</param>
        /// <returns></returns>
        static string NullableType(PropertyInfo property)
        {
            string str = property.PropertyType.FullName.Replace("System.", "");
            str = str.Replace("Nullable`1[[", "");
            //string[] vetor = property.PropertyType.FullName.Split('.', ',');
            string[] vetor = str.Split('.', ',');

            return vetor[0];
        }


    }
}
