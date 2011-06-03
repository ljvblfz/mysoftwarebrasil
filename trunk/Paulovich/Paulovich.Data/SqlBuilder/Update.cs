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
using System.Data;
using Paulovich.Data.Resources;

namespace Paulovich.Data.SqlBuilder
{
    public static class Update
    {
        public static string Generate(object entity, Command command)
        {
            #region debug

            if (entity == null)
                throw new ArgumentNullException("entity", Messages.InvalidArgumentValue);

            if (command == null)
                throw new ArgumentNullException("command", Messages.InvalidArgumentValue);

            #endregion

            command.CommandType = CommandType.Text;
            command.ClearParameters();

            var builder = new UpdateBuilder {TableName = Mapper.GetTableName(entity, command.CurrentDialect)};

            var keys = new Dictionary<string, Property>();
            var columns = new Dictionary<string, Property>();
            var allColumns = new Dictionary<string, Property>();

            Mapper.LoadMetaData(entity, keys, columns, allColumns);

            foreach (var entry in columns)
            {
                if ((entry.Value.Field.AllowNulls || entry.Value.Value != null) && entry.Value.Field.IsUpdatable)
                {
                    builder.Set.Add(entry.Value.ColumnWithMatchCase(command.CurrentDialect),
                                    entry.Value.ParamName(command.CurrentDialect));


                    if (entry.Value.Value != null)
                    {

                        if (entry.Value.Value is string && entry.Value.Field.Size > 0)
                        {

                            string value = Convert.ToString(entry.Value.Value);

                            value = value.Substring(0, Math.Min(entry.Value.Field.Size, value.Length));

                            command.AddParameterInput(entry.Value.ParamName(command.CurrentDialect), entry.Value.DbType, value);

                        }
                        else
                        {
                            command.AddParameterInput(entry.Value.ParamName(command.CurrentDialect), entry.Value.DbType,
                                entry.Value.Value);
                        }

                    }
                    else
                    {
                        command.AddParameterInput(entry.Value.ParamName(command.CurrentDialect), entry.Value.DbType,
                                                  DBNull.Value);
                    }
                }
            }

            foreach (var entry in keys)
            {
                builder.Where.Add(entry.Value.ColumnWithMatchCase(command.CurrentDialect),
                                  entry.Value.ParamName(command.CurrentDialect));
                command.AddParameterInput(entry.Value.ParamName(command.CurrentDialect), entry.Value.DbType, entry.Value.Value);
            }

            return (builder.Set.Count == 0) ? string.Empty : builder.ToString();
        }
    }
}