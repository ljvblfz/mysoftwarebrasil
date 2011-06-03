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
//           * Rigel (rigel.octaviano@gmail.com)
//           Blog: http://rigel-aguilar.blogspot.com/
//           Messenger: rigelaguilar@hotmail.com 
//


using System;
using System.Collections.Generic;
using System.Data;
using Paulovich.Data.Resources;
using System.Text;
using System.ComponentModel;

namespace Paulovich.Data.SqlBuilder
{
    public static class Select
    {
        public static string Generate<T>(object entity,
                                         string select, string from, string where, string groupBy, string having,
                                         string orderBy,
                                         Command command, params string[] parameters)
            where T : new()
        {
            #region debug

            if (command == null)
                throw new ArgumentNullException("command", Messages.InvalidArgumentValue);

            #endregion

            if (entity == null)
            {
                entity = new T();
            }

            command.CommandType = CommandType.Text;
            command.ClearParameters();

            var builder = new SelectBuilder
                              {
                                  TableName =
                                      (string.IsNullOrEmpty(from) ? Mapper.GetTableName(entity, command.CurrentDialect) : from)
                              };

            var keys = new Dictionary<string, Property>();
            var columns = new Dictionary<string, Property>();
            var allColumns = new Dictionary<string, Property>();

            Mapper.LoadMetaData(entity, keys, columns, allColumns);

            if (string.IsNullOrEmpty(select))
            {
                foreach (var entry in allColumns)
                {
                    if (entry.Value.Field.IsSelectable)
                    {
                        builder.Select.Add(entry.Value.ColumnWithMatchCase(command.CurrentDialect));
                    }
                }
            }
            else
            {
                builder.Select.Add(select);
            }

            if (string.IsNullOrEmpty(where))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    Property prop;

                    foreach (string param in parameters)
                    {
                        prop = allColumns[param];

                        builder.Where.Add(new ValuePairItem
                                              {
                                                  Key = prop.ColumnWithMatchCase(command.CurrentDialect),
                                                  Separator = string.Empty,
                                                  Value = prop.ParamName(command.CurrentDialect)
                                              });
                        command.AddParameterInput(prop.ParamName(command.CurrentDialect), prop.DbType, prop.Value);
                    }
                }
            }
            else
            {
                builder.Where.Add(new ValuePairItem {Key = where, Separator = string.Empty, Value = string.Empty});

                Property prop;

                foreach (string param in parameters)
                {
                    prop = allColumns[param];

                    command.AddParameterInput(prop.ParamName(command.CurrentDialect), prop.DbType, prop.Value);
                }
            }

            builder.Having = having;
            builder.OrderBy = orderBy;

            return builder.ToString();
        }

        public static string Join(
            string from,
            Type entityType,
            Persist relationShip,
            Command command,
            params string[] parameters)
        {
            var persist = (Persist) Activator.CreateInstance(entityType);

            var keys = new Dictionary<string, Property>();
            var columns = new Dictionary<string, Property>();
            var allColumns = new Dictionary<string, Property>();

            Mapper.LoadMetaData(persist, keys, columns, allColumns);

            var relationShipKeys = new Dictionary<string, Property>();
            var relationShipColumns = new Dictionary<string, Property>();
            var relationShipAllColumns = new Dictionary<string, Property>();

            Mapper.LoadMetaData(relationShip, relationShipKeys, relationShipColumns, relationShipAllColumns);

            command.CommandType = CommandType.Text;
            command.ClearParameters();

            var builder = new SelectBuilder
                              {
                                  TableName = from
                              };


            foreach (var entry in allColumns)
            {
                if (entry.Value.Field.IsSelectable)
                {
                    builder.Select.Add(entry.Value.ColumnWithMatchCase(command.CurrentDialect));
                }
            }

            if (parameters != null && parameters.Length > 0)
            {
                Property prop;

                foreach (string param in parameters)
                {
                    prop = relationShipAllColumns[param];

                    builder.Where.Add(new ValuePairItem
                                          {
                                              Key = prop.ColumnWithMatchCase(command.CurrentDialect),
                                              Separator = string.Empty,
                                              Value = prop.ParamName(command.CurrentDialect)
                                          });
                    command.AddParameterInput(prop.ParamName(command.CurrentDialect), prop.DbType, prop.Value);
                }
            }

            return builder.ToString();
        }

        public static string Paging<T>(Filter[] parameters, OrderBy[] orderBy, Command command, int pageSize, int pageNumber)
            where T : new()
        {
            command.CommandType = CommandType.Text;
            command.ClearParameters();

            var keys = new Dictionary<string, Property>();
            var columns = new Dictionary<string, Property>();
            var allColumns = new Dictionary<string, Property>();

            var filter = new T();

            Mapper.LoadMetaData(filter, keys, columns, allColumns);

            var innerQuery = new SelectBuilder();

            innerQuery.Select.Add("*");

            if (orderBy != null && orderBy.Length > 0)
            {
                StringBuilder order = new StringBuilder();

                for (int i = 0; i < orderBy.Length; i++)
                {
                    if (i > 0)
                        order.Append(", ");

                    order.Append(orderBy[i].Member + " " + (orderBy[i].SortDirection == ListSortDirection.Ascending ? "ASC" : "DESC"));
                }
                innerQuery.Select.Add(string.Format("ROW_NUMBER() OVER(ORDER BY {0}) AS row", order.ToString()));
            }
            else
            {
                var enumerator = allColumns.GetEnumerator();
                enumerator.MoveNext();
                innerQuery.Select.Add(string.Format("ROW_NUMBER() OVER(ORDER BY {0}) AS row", enumerator.Current.Value.ColumnName()));
            }

            innerQuery.TableName = Mapper.GetTableName(filter, command.CurrentDialect);

            if (parameters != null && parameters.Length > 0)
            {
                Property prop;

                int index = 0;

                foreach (var param in parameters)
                {
                    prop = allColumns[param.Name];

                    innerQuery.Where.Add(new ValuePairItem
                    {
                        Key = prop.ColumnWithMatchCase(command.CurrentDialect),
                        Separator = param.Operator(),
                        Value = prop.ParamName(command.CurrentDialect) + "_" + index
                    });

                    command.AddParameterInput(prop.ParamName(command.CurrentDialect) + "_" + index, prop.DbType, param.GetValue(command.CurrentDialect));
                    
                    index++;
                }
            }

            var innerQueryString = innerQuery.ToString();

            var outterQuery = new SelectBuilder();

            foreach (var entry in allColumns)
            {
                if (entry.Value.Field.IsSelectable)
                {
                    outterQuery.Select.Add(entry.Value.ColumnNameWithMatchCase(command.CurrentDialect));
                }
            }

            outterQuery.From.Append("( " + innerQueryString + " ) AS tbl");

            outterQuery.Where.Add(new ValuePairItem
            {
                Key = "row",
                Separator = " >= ",
                Value = "@First"
            });

            outterQuery.Where.Add(new ValuePairItem
            {
                Key = "row",
                Separator = " <= ",
                Value = "@Last"
            });

            var first = (pageNumber * pageSize) + 1;
            var last = first + pageSize - 1;

            command.AddWithValue("First", first);
            command.AddWithValue("Last", last);

            var outterQueryString = outterQuery.ToString();

            return outterQueryString;
        }


        public static string Paging(Persist filter, string[] parameters, string orderBy, Command command,
            int pageSize, int pageNumber)
        {

            #region debug

            if (filter == null)
                throw new ArgumentNullException("filter", Messages.InvalidArgumentValue);

            if (string.IsNullOrEmpty(orderBy))
                throw new ArgumentNullException("orderBy", Messages.InvalidArgumentValue);

            #endregion            

            command.CommandType = CommandType.Text;
            command.ClearParameters();            

            var keys = new Dictionary<string, Property>();
            var columns = new Dictionary<string, Property>();
            var allColumns = new Dictionary<string, Property>();

            Mapper.LoadMetaData(filter, keys, columns, allColumns);

            var innerQuery = new SelectBuilder();

            innerQuery.Select.Add("*");
            innerQuery.Select.Add(string.Format("ROW_NUMBER() OVER(ORDER BY {0}) AS row", orderBy));
            innerQuery.TableName = Mapper.GetTableName(filter, command.CurrentDialect);

            if (parameters != null && parameters.Length > 0)
            {
                Property prop;

                int index = 0;

                foreach (var param in parameters)
                {
                    prop = allColumns[param];

                    if (prop.Type == typeof(string))
                    {

                        innerQuery.Where.Add(new ValuePairItem
                        {
                            Key = prop.ColumnWithMatchCase(command.CurrentDialect),
                            Separator = " LIKE ",
                            Value = prop.ParamName(command.CurrentDialect)
                        });

                    }
                    else
                    {
                        innerQuery.Where.Add(new ValuePairItem
                                                 {
                                                     Key = prop.ColumnWithMatchCase(command.CurrentDialect),
                                                     Separator = string.Empty,
                                                     Value = prop.ParamName(command.CurrentDialect) + "_" + index
                                                 });
                    }

                    command.AddParameterInput(prop.ParamName(command.CurrentDialect) + "_" + index, prop.DbType, prop.Value);

                    index++;
                }
            }

            var innerQueryString = innerQuery.ToString();

            var outterQuery = new SelectBuilder();

            foreach (var entry in allColumns)
            {
                if (entry.Value.Field.IsSelectable)
                {
                    outterQuery.Select.Add(entry.Value.ColumnNameWithMatchCase(command.CurrentDialect));
                }
            }

            outterQuery.From.Append("( " + innerQueryString + " ) AS tbl");

            outterQuery.Where.Add(new ValuePairItem
            {
                Key = "row",
                Separator = " >= ",
                Value = "@First"
            });

            outterQuery.Where.Add(new ValuePairItem
            {
                Key = "row",
                Separator = " <= ",
                Value = "@Last"
            });

            var first = (pageNumber * pageSize) + 1;
            var last = first + pageSize + 1;

            command.AddWithValue("First", first);                     
            command.AddWithValue("Last", last);

            var outterQueryString = outterQuery.ToString();

            return outterQueryString;

        }

        public static string Count(Persist filter, string[] parameters, Command command)
        {

            command.CommandType = CommandType.Text;
            command.ClearParameters();

            var keys = new Dictionary<string, Property>();
            var columns = new Dictionary<string, Property>();
            var allColumns = new Dictionary<string, Property>();

            Mapper.LoadMetaData(filter, keys, columns, allColumns);

            var query = new SelectBuilder();

            query.Select.Add("Count(*)");
            query.TableName = Mapper.GetTableName(filter, command.CurrentDialect);

            if (filter != null && parameters != null && parameters.Length > 0)
            {

                Property prop;

                foreach (var param in parameters)
                {
                    prop = allColumns[param];

                    if (prop.Type == typeof(string))
                    {

                        query.Where.Add(new ValuePairItem
                                            {
                                                Key = prop.ColumnWithMatchCase(command.CurrentDialect),
                                                Separator = " LIKE ",
                                                Value = prop.ParamName(command.CurrentDialect)
                                            });

                    }
                    else
                    {
                        query.Where.Add(new ValuePairItem
                                            {
                                                Key = prop.ColumnWithMatchCase(command.CurrentDialect),
                                                Separator = string.Empty,
                                                Value = prop.ParamName(command.CurrentDialect)
                                            });
                    }

                    command.AddParameterInput(prop.ParamName(command.CurrentDialect), prop.DbType, prop.Value);
                }

            }

            var queryString = query.ToString();

            return queryString;

        }

        public static string Count(Persist filter, Filter[] parameters, Command command)
        {

            command.CommandType = CommandType.Text;
            command.ClearParameters();

            var keys = new Dictionary<string, Property>();
            var columns = new Dictionary<string, Property>();
            var allColumns = new Dictionary<string, Property>();

            Mapper.LoadMetaData(filter, keys, columns, allColumns);

            var query = new SelectBuilder();

            query.Select.Add("Count(*)");
            query.TableName = Mapper.GetTableName(filter, command.CurrentDialect);

            int index = 0;

            if (filter != null && parameters != null && parameters.Length > 0)
            {

                Property prop;

                foreach (var param in parameters)
                {
                    prop = allColumns[param.Name];

                    query.Where.Add(new ValuePairItem
                    {
                        Key = prop.ColumnWithMatchCase(command.CurrentDialect),
                        Separator = param.Operator(),
                        Value = prop.ParamName(command.CurrentDialect) + "_" + index
                    });

                    command.AddParameterInput(prop.ParamName(command.CurrentDialect) + "_" + index, prop.DbType, param.GetValue(command.CurrentDialect));

                    index++;
                }

            }

            var queryString = query.ToString();

            return queryString;

        }

    }
}