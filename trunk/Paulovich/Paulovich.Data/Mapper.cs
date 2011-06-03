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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using Paulovich.Data.Resources;

namespace Paulovich.Data
{
    public class Mapper
    {
        public static void InitializeCollections(Persist entity)
        {
            #region debug

            if (entity == null)
                throw new ArgumentNullException("entity", Messages.InvalidArgumentValue);

            #endregion

            PropertyInfo[] properties =
                entity.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            object[] attributes;

            foreach (PropertyInfo property in properties)
            {
                attributes = property.GetCustomAttributes(typeof (ListTo), true);

                if (attributes != null && attributes.Length > 0)
                {
                    Type genericType = typeof (Collection<>);
                    Type[] parameters = {property.PropertyType.GetGenericArguments()[0]};
                    Type closedType = genericType.MakeGenericType(parameters);

                    property.SetValue(entity, Activator.CreateInstance(closedType), null);
                }

                attributes = property.GetCustomAttributes(typeof (ManyToMany), true);

                if (attributes != null && attributes.Length > 0)
                {
                    Type genericType = typeof (Collection<>);
                    Type[] parameters = {property.PropertyType.GetGenericArguments()[0]};
                    Type closedType = genericType.MakeGenericType(parameters);

                    property.SetValue(entity, Activator.CreateInstance(closedType), null);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="keys"></param>
        /// <param name="columns"></param>
        /// <param name="allColumns"></param>
        public static void LoadMetaData(object entity, Dictionary<string, Property> keys,
                                        Dictionary<string, Property> columns, Dictionary<string, Property> allColumns)
        {
            #region debug

            if (entity == null)
                throw new ArgumentNullException("entity", Messages.InvalidArgumentValue);

            if (keys == null)
                throw new ArgumentNullException("keys", Messages.InvalidArgumentValue);

            if (columns == null)
                throw new ArgumentNullException("columns", Messages.InvalidArgumentValue);

            if (allColumns == null)
                throw new ArgumentNullException("allColumns", Messages.InvalidArgumentValue);

            #endregion

            PropertyInfo[] properties =
                entity.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

            #region Loads metadata into dictionaries

            object[] attributes;

            foreach (PropertyInfo propertyInfo in properties)
            {
                attributes = propertyInfo.GetCustomAttributes(typeof (DbField), true);

                if (attributes != null && attributes.Length > 0)
                {
                    allColumns.Add(propertyInfo.Name, new Property(entity, propertyInfo, (DbField) attributes[0]));
                }

                attributes = propertyInfo.GetCustomAttributes(typeof (PrimaryKeyField), true);

                if (attributes != null && attributes.Length > 0)
                {
                    keys.Add(propertyInfo.Name, new Property(entity, propertyInfo, (DbField) attributes[0]));
                }

                attributes = propertyInfo.GetCustomAttributes(typeof (Field), true);

                if (attributes != null && attributes.Length > 0)
                {
                    columns.Add(propertyInfo.Name, new Property(entity, propertyInfo, (DbField) attributes[0]));
                }
            }

            #endregion
        }

        /// <summary>
        /// Carrega as chaves primárias
        /// </summary>
        public static Dictionary<string, Property> ExtractKeys(Persist entity)
        {
            #region debug

            if (entity == null)
                throw new ArgumentNullException("entity", Messages.InvalidArgumentValue);

            #endregion

            PropertyInfo[] properties =
                entity.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var keys = new Dictionary<string, Property>();

            #region Loads metadata into dictionaries

            object[] attributes;

            foreach (PropertyInfo propertyInfo in properties)
            {
                attributes = propertyInfo.GetCustomAttributes(typeof (PrimaryKeyField), true);

                if (attributes != null && attributes.Length > 0)
                {
                    keys.Add(propertyInfo.Name, new Property(entity, propertyInfo, (DbField) attributes[0]));
                }
            }

            #endregion

            return keys;
        }

        /// <summary>
        /// Carrega as colunas
        /// </summary>
        public static Dictionary<string, Property> ExtractColumns(Persist entity)
        {
            #region debug

            if (entity == null)
                throw new ArgumentNullException("entity", Messages.InvalidArgumentValue);

            #endregion

            PropertyInfo[] properties =
                entity.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var columns = new Dictionary<string, Property>();

            #region Loads metadata into dictionaries

            object[] attributes;

            foreach (PropertyInfo propertyInfo in properties)
            {
                attributes = propertyInfo.GetCustomAttributes(typeof (Field), true);

                if (attributes != null && attributes.Length > 0)
                {
                    columns.Add(propertyInfo.Name, new Property(entity, propertyInfo, (DbField) attributes[0]));
                }
            }

            #endregion

            return columns;
        }

        /// <summary>
        /// Carrega todos os campos
        /// </summary>
        public static Dictionary<string, Property> ExtractAllColumns(Persist entity)
        {
            #region debug

            if (entity == null)
                throw new ArgumentNullException("entity", Messages.InvalidArgumentValue);

            #endregion

            PropertyInfo[] properties =
                entity.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var allColumns = new Dictionary<string, Property>();

            #region Loads metadata into dictionaries

            object[] attributes;

            foreach (PropertyInfo propertyInfo in properties)
            {
                attributes = propertyInfo.GetCustomAttributes(typeof (DbField), true);

                if (attributes != null && attributes.Length > 0)
                {
                    allColumns.Add(propertyInfo.Name, new Property(entity, propertyInfo, (DbField) attributes[0]));
                }
            }

            #endregion

            return allColumns;
        }

        public static string GetTableName(object entity, Dialect.Dialect dialect)
        {
            #region debug

            if (entity == null)
                throw new ArgumentNullException("entity", Messages.InvalidArgumentValue);

            if (dialect == null)
                throw new ArgumentNullException("dialect", Messages.InvalidArgumentValue);

            #endregion

            object[] attributes = entity.GetType().GetCustomAttributes(typeof (Table), true);

            #region debug

            if (attributes == null)
                throw new NullReferenceException("attributes");

            #endregion

            string name = (attributes.Length == 1)
                              ? ((Table) attributes[0]).TableName
                              : entity.GetType().Name;

            if (attributes.Length == 0)
            {
                return dialect.GetOpenBracketString() + name + dialect.GetCloseBracketString();
            }

            return (((Table) attributes[0]).MatchCase)
                       ? dialect.GetOpenBracketString() + name + dialect.GetCloseBracketString()
                       : name;
        }
    }
}