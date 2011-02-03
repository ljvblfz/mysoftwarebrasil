using System;
using System.Collections.Generic;

namespace View
{
    /// <summary>
    /// Class for create XHTML elements
    /// </summary>
    public class XForm<Model> where Model : new()
    {


        public static string Textarea(string name, object value,int? row,int? col, string[] attribs)
        {
            string rows = "24";
            string cols = "80";
            if (row.HasValue && row.GetType() == typeof(Int32))
                rows = row.ToString();
            if (col.HasValue && col.GetType() == typeof(Int32))
                cols = col.ToString();
            string xhtml = String.Format(@"<textarea name=""{0}"" id=""{0}"" value=""{1}"" ", name, value);
            if (attribs != null)
            {
                for (int i = 0; i < attribs.Length; i++)
                {
                    xhtml += attribs[i];
                }
            }
            return xhtml + " > </textarea>";
        }

        /// <summary>
        ///     Helper to generate "select" list of options
        /// </summary>
        /// <param name="name">name If a string, the element name</param>
        /// <param name="value">value fields</param>
        /// <param name="label">label fields</param>
        /// <param name="listModel">List of data to select the Peech</param>
        /// <param name="selected">value The option value to mark as 'selected'</param>
        /// <param name="attribs">Attributes added to the 'select' tag</param>
        /// <returns>string The element XHTML</returns>
        public static string Selectbox(string name, string value, string label, List<Model> listModel, object selected, string[] attribs)
        {
            // Build the surrounding select element first.
            string xhtml = @"<select name=""{0}"" id=""{0}"" ";
            xhtml = String.Format(xhtml, name);

            if (attribs != null)
            {
                int total = attribs.Length;
                for (int i = 0; i < total; i++)
                {
                    xhtml += attribs[i];
                }
            }
            xhtml += " >";

            foreach (Model itemModel in listModel)
            {
                object valueOption = itemModel.GetType().GetProperty(value).GetValue(itemModel, null);
                object labelOption = itemModel.GetType().GetProperty(label).GetValue(itemModel, null);
                string opt = String.Format(@"<option value=""{0}"" label=""{1}"" ", valueOption, labelOption);
                if (valueOption == selected)
                    opt += @"selected=""selected""";
                xhtml += String.Format(@"{0} > {1} </option>", opt, labelOption);
            }

            xhtml += " </select>";
            return xhtml;
        }

        /// <summary>
        ///  Helper to generate a "text" element
        /// </summary>
        /// <param name="name">The element name and id</param>
        /// <param name="value">The element value</param>
        /// <param name="attribs">Attributes for the element tag</param>
        /// <returns>string The element XHTML</returns>
        public static string Texbox(string name, object value, string[] attribs)
        {
            string xhtml = @"<input type=""text"" name=""{0}"" id=""{0}"" value=""{1}"" ";
            xhtml = String.Format(xhtml, name, value);
            if (attribs != null)
            {
                int total = attribs.Length;
                for (int i = 0; i < total; i++)
                {
                    xhtml += attribs[i];
                }
            }
            xhtml += " />";
            return xhtml;
        }

        /// <summary>
        ///  Helper to generate a "hidden" element
        /// </summary>
        /// <param name="name">The element name and id</param>
        /// <param name="value">The element value</param>
        /// <param name="attribs">Attributes for the element tag</param>
        /// <returns>string The element XHTML</returns>
        public static string Hidden(string name, object value, string[] attribs)
        {
            string xhtml = @"<input type=""hidden"" name=""{0}"" id=""{0}"" value=""{1}"" ";
            xhtml = String.Format(xhtml, name, value);
            if (attribs != null)
            {
                int total = attribs.Length;
                for (int i = 0; i < total; i++)
                {
                    xhtml += attribs[i];
                }
            }
            xhtml += " />";
            return xhtml;
        }

        /// <summary>
        ///  Helper to generate a "checkbox" element
        /// </summary>
        /// <param name="name">The element name and id</param>
        /// <param name="isChecked">checked/unchecked options</param>
        /// <param name="attribs">Attributes for the element tag</param>
        /// <returns>string The element XHTML</returns>
        public static string Checkbox(string name, bool isChecked, string[] attribs)
        {
            string xhtml = @"<input type=""checkbox"" name=""{0}"" id=""{0}"" ";
            xhtml = String.Format(xhtml, name);
            if (isChecked)
                xhtml += @"checked= ""checked""";
            if (attribs != null)
            {
                int total = attribs.Length;
                for (int i = 0; i < total; i++)
                {
                    xhtml += attribs[i];
                }
            }
            xhtml += " />";
            return xhtml;
        }

    }
}
