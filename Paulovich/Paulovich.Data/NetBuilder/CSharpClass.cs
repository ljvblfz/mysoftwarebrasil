//
//  Copyright (c) 2008, Ivan Paulovich
//  All rights reserved.
//
//  Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//
//  * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//
//  * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other 
//  materials provided with the distribution.
//
//  * Neither the name of Paulovich nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior 
//  written permission.
//
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
//  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT 
//  OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT 
//  LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON 
//  ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
//  USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
//  Authors: 
//           
//           * Ivan Paulovich (ivan@100loop.com)
//           Blog: http://www.100loop.com/blogs/           
//           Messenger: ivanpaulovich@hotmail.com 
//

using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using Paulovich.Data.Dialect;
using Paulovich.Data.Resources;
using Paulovich.Data.SqlBuilder.SqlServer;

namespace Paulovich.Data.NetBuilder
{
    public static class CSharpClass
    {
        public static string Generate(string tableName, string className, int depth, bool cSharp35)
        {
            return Generate(tableName, className, 0, true, true, true, depth, cSharp35);
        }

        private static string GetSpaces(int tabs)
        {
            #region debug

            if (tabs < 0)
                throw new ArgumentNullException("tabs", Messages.InvalidArgumentValue);

            #endregion

            string result = string.Empty;

            for (int i = 0; i < tabs; i++)
            {
                result += "\t";
            }

            return result;
        }

        /// <summary>
        /// Generate a string that represents a .NET Persistent class.
        /// </summary>
        /// <param name="tableName">Name of the table in the database.</param>
        /// <param name="className">Friendly name of the .NET Prsistent Class.</param>
        /// <param name="tabs"></param>
        /// <param name="insertHeader"></param>
        /// <param name="insertProperties"></param>
        /// <param name="insertConstructors"></param>
        /// <param name="cSharp35"></param>
        /// <returns>String that represents the .NET Persistent Class.</returns>
        public static string Generate(string tableName, string className, int tabs, bool insertHeader,
                                      bool insertProperties, bool insertConstructors, bool cSharp35)
        {
            #region debug

            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName", Messages.InvalidArgumentValue);

            if (string.IsNullOrEmpty(className))
                throw new ArgumentNullException("className", Messages.InvalidArgumentValue);

            #endregion

            return Generate(tableName, className, tabs, insertHeader, insertProperties, insertConstructors, 3, cSharp35);
        }

        /// <summary>
        /// Transfom a text into a friendly lowered url
        /// </summary>
        /// <param name="userInput">Text to be transformed</param>
        /// <param name="lower"></param>
        /// <param name="separator"></param>
        /// <returns>Friendly url if succeded, string.Empty if fails</returns>
        public static string Filter(string userInput, bool lower, string separator)
        {
            #region debug

            if (string.IsNullOrEmpty(userInput))
                throw new ArgumentNullException("userInput", Messages.InvalidArgumentValue);

            if (string.IsNullOrEmpty(separator))
                throw new ArgumentNullException("separator", Messages.InvalidArgumentValue);

            #endregion

            string text = string.IsNullOrEmpty(userInput) ? string.Empty : (lower ? userInput.ToLower() : userInput);

            var re = new Regex("[aáàãâä]");
            text = re.Replace(text, "a");

            re = new Regex("[eéèêë]");
            text = re.Replace(text, "e");

            re = new Regex("[iíìîï]");
            text = re.Replace(text, "i");

            re = new Regex("[oóòõôö]");
            text = re.Replace(text, "o");

            re = new Regex("[uúùûü]");
            text = re.Replace(text, "u");

            re = new Regex("[ç]");
            text = re.Replace(text, "c");

            re = new Regex("[ñ]");
            text = re.Replace(text, "n");

            re = new Regex("( )");
            text = re.Replace(text, separator);

            re = new Regex("[^A-Za-z0-9'_-]");
            text = re.Replace(text, string.Empty);

            re = new Regex("--");
            text = re.Replace(text, separator);

            return text;
        }

        public static string Generate(string tableName, string className, int tabs, bool insertHeader,
                                      bool insertProperties, bool insertConstructors, int depth, bool cSharp35)
        {
            #region debug

            if (string.IsNullOrEmpty(tableName))
                throw new ArgumentNullException("tableName", Messages.InvalidArgumentValue);

            if (string.IsNullOrEmpty(className))
                throw new ArgumentNullException("className", Messages.InvalidArgumentValue);

            #endregion

            if (depth - 1 < -1)
            {
                return string.Empty;
            }

            if (string.IsNullOrEmpty(className))
            {
                className = tableName;
            }

            var command = new Command();

            className = Filter(className, false, "_");
            className = className.Substring(0, 1).ToUpper() + className.Substring(1);

            var column = new Column {TableName = tableName};

            Collection<Column> Columns = Persist.Select(column, "TableName");

            var primaryKey = new PrimaryKey {TableName = tableName};

            Collection<PrimaryKey> primaryKeys = Persist.Select(primaryKey, "TableName");

            var identity = new Identity {TableName = tableName, IsIdentity = 1};

            Collection<Identity> identities = new Collection<Identity>();//Persist.Select(identity, "TableName", "IsIdentity");

            var relationship = new Relationship {ReferenceTableName = tableName, TableName = tableName};

            Collection<Relationship> childrenRelationships = new Collection<Relationship>();//Persist.Select(relationship, "ReferenceTableName");
            Collection<Relationship> parentRelationships = new Collection<Relationship>();//Persist.Select(relationship, "TableName");

            var sb = new StringBuilder();

            if (insertHeader)
            {
                sb.AppendLine("using System;");
                sb.AppendLine("using System.Collections.Generic;");
                sb.AppendLine("using Paulovich.Data;");
                sb.AppendLine("using System.Collections.ObjectModel;");
                sb.AppendLine();
                sb.AppendLine(
                    string.Format("namespace {0}.Business ",
                                  string.IsNullOrEmpty(command.DbCommand.Connection.Database)
                                      ? "Paulovich"
                                      : command.DbCommand.Connection.Database) + "{");
            }

            sb.AppendLine();

            sb.AppendLine(GetSpaces(tabs) +
                          string.Format(GetSpaces(tabs) + "\t[Table(\"{0}\"{1})]", tableName,
                                        tableName != Filter(tableName, false, " ") ? ", MatchCase=true" : string.Empty));

            sb.AppendLine(GetSpaces(tabs) + string.Format(GetSpaces(tabs) + "\tpublic class {0}: Persist ", className) +
                          " {");
            sb.AppendLine();

            if (insertProperties)
            {
                sb.AppendLine(GetSpaces(tabs) + "\t\t#region fields & properties");
                sb.AppendLine();
            }

            string fieldName;
            string parentClassName;

            foreach (Column field in Columns)
            {
                fieldName = field.ColumnName;
                bool isPrimaryKey = false;
                bool isIdentity = false;

                foreach (PrimaryKey key in primaryKeys)
                {
                    if (fieldName != key.ColumnName) continue;

                    isPrimaryKey = true;
                    break;
                }

                if (identities != null)
                foreach (Identity identityField in identities)
                {
                    if (fieldName != identityField.ColumnName) continue;

                    isIdentity = true;
                    break;
                }

                bool braketNeeded;
                bool commaNeeded = braketNeeded = false;
                string constraints = string.Empty;

                if (parentRelationships.Count > 0 || isIdentity)
                {
                    if (isIdentity)
                    {
                        constraints += "(";
                        braketNeeded = true;
                    }

                    if (parentRelationships != null)
                    foreach (Relationship constraint in parentRelationships)
                    {
                        if (fieldName != constraint.ColumnName) continue;

                        if (!braketNeeded)
                        {
                            constraints += "(";
                        }

                        if (commaNeeded)
                        {
                            constraints += ", ";
                        }

                        parentClassName = Filter(constraint.ReferenceTableName, false, "_");
                        parentClassName = parentClassName.Substring(0, 1).ToUpper() + parentClassName.Substring(1);

                        constraints += "typeof(" +
                                       (string.IsNullOrEmpty(command.DbCommand.Connection.Database)
                                            ? "Paulovich"
                                            : command.DbCommand.Connection.Database) + ".Business." + parentClassName +
                                       "), \"" + constraint.ReferenceColumnName + "\"";

                        commaNeeded = true;
                        braketNeeded = true;
                    }

                    if (isIdentity)
                    {
                        if (commaNeeded)
                        {
                            constraints += ", ";
                        }

                        constraints += "IsIdentity=true";
                    }

                    if (braketNeeded)
                    {
                        constraints += ")";
                    }
                }

                string netType = SqlCSharpConverter.GetDotNetType(field.DataType);
                bool isGeneric = field.IsNullable == "YES";

                if (netType == "string" || netType == "byte[]")
                    isGeneric = false;

                if (insertProperties)
                {
                    if (!cSharp35)
                    {
                        //new field
                        sb.AppendLine(GetSpaces(tabs) + "\t\tprivate {0}{4} {2};");
                        sb.AppendLine();
                        sb.AppendLine(GetSpaces(tabs) + "\t\t[{3}{5}]");

                        sb.AppendLine(GetSpaces(tabs) + "\t\tpublic {0}{4} {1} {");
                        sb.AppendLine(GetSpaces(tabs) + "\t\t\tget { return {2}; }");
                        sb.AppendLine(GetSpaces(tabs) + "\t\t\tset { {2} = value; }");
                        sb.AppendLine(GetSpaces(tabs) + "\t\t}");
                    }
                    else
                    {
                        sb.AppendLine(GetSpaces(tabs) + "\t\t[{3}{5}]");
                        sb.AppendLine(GetSpaces(tabs) + "\t\tpublic {0}{4} {1} { get; set; } ");
                    }

                    sb.AppendLine();
                }

                sb = new StringBuilder(
                    sb.ToString().Replace("{0}", netType).Replace("{1}",
                                                                  (Convert.ToString(fieldName[0])).ToUpper() +
                                                                  fieldName.Substring(1)).Replace("{2}",
                                                                                                  (Convert.ToString(
                                                                                                      fieldName[0])).
                                                                                                      ToLower() +
                                                                                                  fieldName.Substring(1))
                        .Replace("{3}", !isPrimaryKey ? "Field" : "PrimaryKeyField").Replace("{4}",
                                                                                             isGeneric
                                                                                                 ? "?"
                                                                                                 : string.Empty).Replace
                        ("{5}", constraints)
                    );

            }

            if (insertProperties)
            {
                //finishes a field region
                sb.AppendLine(GetSpaces(tabs) + "\t\t#endregion");
                sb.AppendLine();
            }

            if (insertConstructors)
            {
                sb.AppendLine(GetSpaces(tabs) + "\t\t#region constructors");
                sb.AppendLine();

                sb.AppendLine(GetSpaces(tabs) + "\t\tpublic " + className + "()");
                sb.AppendLine(GetSpaces(tabs) + "\t\t\t: base() {");
                sb.AppendLine(GetSpaces(tabs) + "\t\t}");
                sb.AppendLine();

                sb.AppendLine(GetSpaces(tabs) + "\t\tpublic " + className + "(params object[] keys)");
                sb.AppendLine(GetSpaces(tabs) + "\t\t\t: base(keys) {");
                sb.AppendLine(GetSpaces(tabs) + "\t\t}");
                sb.AppendLine();

                //sb.AppendLine(GetSpaces(tabs) + "\t\tpublic " + className + "(" + parameters + ")");
                //sb.AppendLine(GetSpaces(tabs) + "\t\t\t: base() {");
                //sb.Append(setParameters);

                //sb.AppendLine(GetSpaces(tabs) + "\t\t}");

                sb.AppendLine(GetSpaces(tabs) + "\t\t#endregion");
                sb.AppendLine();
            }

            if (childrenRelationships.Count > 0)
            {
                sb.AppendLine(GetSpaces(tabs) + "\t\t#region related tables");
                sb.AppendLine();

                foreach (Relationship constraint in childrenRelationships)
                {
                    if (!cSharp35)
                    {
                        sb.AppendLine(GetSpaces(tabs) + "\t\tprivate Collection<{0}> {1};");
                        sb.AppendLine();
                        sb.AppendLine(GetSpaces(tabs) + "\t\t[ListToSave]");

                        sb.AppendLine(GetSpaces(tabs) + "\t\tpublic Collection<{0}> {0} {");
                        sb.AppendLine(GetSpaces(tabs) + "\t\t\tget { return {1}; }");
                        sb.AppendLine(GetSpaces(tabs) + "\t\t\tset { {1} = value; }");
                        sb.AppendLine(GetSpaces(tabs) + "\t\t}");
                    }
                    else
                    {
                        sb.AppendLine(GetSpaces(tabs) + "\t\t[ListToSave]");
                        sb.AppendLine(GetSpaces(tabs) + "\t\tpublic Collection<{0}> {0} { get; set; }");
                    }

                    sb.AppendLine();

                    string tbl = Filter(constraint.TableName, false, "_");

                    sb = new StringBuilder(
                        sb.ToString().Replace("{0}", tbl.Substring(0, 1).ToUpper() + tbl.Substring(1)).Replace("{1}",
                                                                                                               tbl.
                                                                                                                   Substring
                                                                                                                   (0, 1)
                                                                                                                   .
                                                                                                                   ToLower
                                                                                                                   () +
                                                                                                               tbl.
                                                                                                                   Substring
                                                                                                                   (1))
                        );
                }

                sb.AppendLine(GetSpaces(tabs) + "\t\t#endregion");
            }

            sb.AppendLine(GetSpaces(tabs) + "\t}");

            if (childrenRelationships.Count > 0)
            {
                foreach (Relationship constraint in childrenRelationships)
                {
                    sb.AppendLine(Generate(constraint.TableName, constraint.TableName, tabs, false, insertProperties,
                                           insertConstructors, depth - 1, cSharp35));
                }
            }

            if (insertHeader)
            {
                sb.AppendLine(GetSpaces(tabs) + "}");
            }

            //return class as string
            return sb.ToString();
        }

        /// <summary>
        /// Generate a string that represents a .NET Persistent class.
        /// </summary>
        /// <param name="tableName">Name of the table in the database.</param>
        /// <param name="className">Friendly name of the .NET Prsistent Class.</param>
        /// <returns>String that represents the .NET Persistent Class.</returns>
        public static string Generate(string tableName, string className)
        {
            return Generate(tableName, className, false);
        }

        /// <summary>
        /// Generate a string that represents a .NET Persistent class.
        /// </summary>
        /// <param name="tableName">Name of the table in the database.</param>
        /// <param name="className">Friendly name of the .NET Prsistent Class.</param>
        /// <returns>String that represents the .NET Persistent Class.</returns>
        /// <param name="cSharp35"></param>
        /// <returns>String that represents the .NET Persistent Class.</returns>
        public static string Generate(string tableName, string className, bool cSharp35)
        {
            return Generate(tableName, className, 0, true, true, true, cSharp35);
        }
    }
}