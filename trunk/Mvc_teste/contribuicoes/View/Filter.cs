using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ViewHelper
{
    public class Filter<Model> where Model : new() 
    {
        /// <summary>
        ///  Model name field and table
        /// </summary>
        /// <typeparam name="field">string</typeparam>
        private string field { get; set; }

        /// <summary>
        ///  Field type
        /// </summary>
        /// <typeparam name="fieldType">string</typeparam>
        private string fieldType { get; set; }

        /// <summary>
        ///  Type of data
        /// </summary>
        /// <typeparam name="fieldType">string</typeparam>
        private string dataType { get; set; }

        /// <summary>
        ///  Field description
        /// </summary>
        /// <typeparam name="fieldType">string</typeparam>
        private string descricao { get; set; }

        /// <summary>
        ///  Dictionary with the filter set
        /// </summary>
        /// <typeparam name="filters">Dictionary</typeparam>
        private Dictionary<string, Dictionary<string, object>> filters { get; set; }

        /// <summary>
        ///  Constructor
        /// </summary>
        public Filter()
        {
            filters = new Dictionary<string, Dictionary<string, object>>();
        }

        /// <summary>
        /// Get Dictionary with the filter
        /// </summary>
        /// <returns>Dictionary filters</returns>
        public Dictionary<string, Dictionary<string, object>> GetFilters()
        {
            return filters;
        }

        /// <summary>
        ///  Add filters manually search
        /// </summary>
        /// <param name="field">Model name field and table</param>
        /// <param name="fieldType">Field type</param>
        /// <param name="dataType">Type of data</param>
        /// <param name="description">Field description</param>
        public void addManual(string field, string fieldType, string dataType, string description)
        {
            Dictionary<string, object> filter = new Dictionary<string, object>();
            filter.Add("tipo_campo", fieldType);
            filter.Add("tipo_dado", dataType);
            filter.Add("descricao", description);
            filters.Add(field, filter);
        }

        /// <summary>
        ///  Adds filters according to the model
        /// </summary>
        /// <param name="fields">Model names fields and table</param>
        public void add(params String[] fields)
        {
            // list fields
            List<String> listField = new List<string>(fields);
            
            // Model
            Model m = new Model();

            // Returns the properties of the model
            Type type = typeof(Model);
            List<PropertyInfo> propertys = new List<PropertyInfo>(type.GetProperties());

            // Checks if fields have been told if it was not creating a filter with all fields
            if (listField.Count > 0)
            {
                foreach (String field in listField)
                {
                    PropertyInfo propertyAUX = propertys.Find(delegate(PropertyInfo p) { return p.Name == field; });
                    filters.Add(propertyAUX.Name, Getfilter(propertyAUX, m));
                }
            }
            else
            {
                foreach (PropertyInfo prop in propertys)
                {
                    filters.Add(prop.Name, Getfilter(prop, m));
                }
            }
        }

        /// <summary>
        ///  Identifies the filter property of the model
        /// </summary>
        /// <param name="property">property of the model</param>
        /// <param name="m">model</param>
        /// <returns>Dictionary of the filters </returns>
        private Dictionary<string, object> Getfilter(PropertyInfo property,Model m)
        {
            // instantiates the filter dictionary
            Dictionary<string, object> filter = new Dictionary<string, object>();

            // return the type
            string typeName = m.GetType().GetProperty(property.Name).PropertyType.Name;
            
            switch (typeName)
            {

                case "Byte[]":
                case "Boolean":
                    filter.Add("tipo_campo", "radio");
                    filter.Add("tipo_dado", "string");
                    filter.Add("descricao", property.Name);
                    break;
                case "DateTime":
                    filter.Add("tipo_campo", "data");
                    filter.Add("tipo_dado", "string");
                    filter.Add("descricao", property.Name);
                    break;
                case "int":
                case "Int16":
                case "Int32":
                case "Int64":
                case "uint":
                case "UInt16":
                case "UInt32":
                case "UInt64":
                    filter.Add("tipo_campo", "text_numerico");
                    filter.Add("tipo_dado", "numerico");
                    filter.Add("descricao", property.Name);
                    break;
                case "decimal":
                case "Decimal":
                case "double":
                case "Double":
                case "float":
                case "Single":
                case "long":
                case "ulong":
                    filter.Add("tipo_campo", "text_monetario");
                    filter.Add("tipo_dado", "numerico");
                    filter.Add("descricao", property.Name);
                    break;
                default: 
                    filter.Add("tipo_campo", "text");
                    filter.Add("tipo_dado", "string");
                    filter.Add("descricao", property.Name);
                    break;
            }

            return filter;
        }

    }
}
