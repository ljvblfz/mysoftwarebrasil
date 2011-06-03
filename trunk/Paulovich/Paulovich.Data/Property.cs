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
using System.Data;
using System.Reflection;
using Paulovich.Data.Resources;

namespace Paulovich.Data
{
    /// <summary>
    /// Propriedade que associa o campo mapeado à propriedade refletida do objeto
    /// </summary>
    public struct Property
    {
        /// <summary>
        /// Cria uma nova propriedade
        /// </summary>
        /// <param name="persist">Objeto persistente</param>
        /// <param name="info">Propriedade refletida</param>
        /// <param name="field">Campo mapeado</param>
        public Property(object persist, PropertyInfo info, DbField field)
            : this()
        {
            #region debug

            if (persist == null)
                throw new ArgumentNullException("persist", Messages.InvalidArgumentValue);

            if (info == null)
                throw new ArgumentNullException("info", Messages.InvalidArgumentValue);

            if (field == null)
                throw new ArgumentNullException("field", Messages.InvalidArgumentValue);

            #endregion

            Persist = persist;
            Info = info;
            Field = field;
        }

        /// <summary>
        /// Objeto persistente associado a essa propriedade
        /// </summary>
        public object Persist { get; set; }

        /// <summary>
        /// Propriedade do objeto persistente
        /// </summary>
        public PropertyInfo Info { get; set; }

        /// <summary>
        /// Campo mapeado
        /// </summary>
        public DbField Field { get; set; }

        /// <summary>
        /// Retorna o valor do campo
        /// </summary>
        public object Value
        {
            get { return Info.GetValue(Persist, null); }
        }

        /// <summary>
        /// Gets the object System.Type, if is a GenericType gets the first System.Type
        /// </summary>
        public Type Type
        {
            get
            {
                return Info.PropertyType.IsGenericType
                           ?
                               Info.PropertyType.GetGenericArguments()[0]
                           :
                               Info.PropertyType;
            }
        }

        /// <summary>
        /// Gets the System.Data.DbType
        /// </summary>
        public DbType DbType
        {
            get { return SingletonTypeConverter.Instance().DbTypeOf(Type); }
        }

        /// <summary>
        /// Nome da coluna
        /// </summary>
        /// <returns>Por padrão é usado o nome da propriedade do objeto, e caso o nome da coluna esteja definino passamos a usar esse valor</returns>
        public string ColumnName()
        {
            //
            // Retorna o nome da propriedade ou o nome da coluna definido no mapeamento
            //
            return string.IsNullOrEmpty(Field.Column) ? Info.Name : Field.Column; //field.Column || info.Name
        }

        /// <summary>
        /// Nome da coluna com aspas simples ou colchetes se necessário
        /// ex.: [columnName] for SQL Server, 'columnName' for Oracle
        /// </summary>
        /// <param name="dialect">Dialeto atual sendo usado</param>
        /// <returns>Nome da coluna com aspas simples ou colchetes se necessário</returns>
        public string ColumnWithMatchCase(Dialect.Dialect dialect)
        {
            #region debug

            if (dialect == null)
                throw new ArgumentNullException("dialect", Messages.InvalidArgumentValue);

            #endregion

            string name = ColumnName();

            if (Field.MatchCase)
            {
                //
                // Se o campo necessita de colchetes nós
                // ajustamos o nome da coluna de acordo com o dialeto usado.
                // ex.: [columnName]
                //
                return Mapper.GetTableName(Persist, dialect) + "." + dialect.GetOpenBracketString() + name +
                       dialect.GetCloseBracketString();
            }
            
            //
            // Aqui pode chegar um dos casos a seguir:
            // [columnName] || columnName
            //
            return Mapper.GetTableName(Persist, dialect) + "." + name;
        }

        /// <summary>
        /// Nome da coluna com aspas simples ou colchetes se necessário
        /// ex.: [columnName] for SQL Server, 'columnName' for Oracle
        /// </summary>
        /// <param name="dialect">Dialeto atual sendo usado</param>
        /// <returns>Nome da coluna com aspas simples ou colchetes se necessário</returns>
        public string ColumnNameWithMatchCase(Dialect.Dialect dialect)
        {
            #region debug

            if (dialect == null)
                throw new ArgumentNullException("dialect", Messages.InvalidArgumentValue);

            #endregion

            string name = ColumnName();

            if (Field.MatchCase)
            {
                //
                // Se o campo necessita de colchetes nós
                // ajustamos o nome da coluna de acordo com o dialeto usado.
                // ex.: [columnName]
                //
                return dialect.GetOpenBracketString() + name +
                       dialect.GetCloseBracketString();
            }

            //
            // Aqui pode chegar um dos casos a seguir:
            // [columnName] || columnName
            //
            return name;
        }

        /// <summary>
        /// Alias do nome da coluna
        /// </summary>
        /// <returns>Com o Alias definido retorna o Alias, caso contrário retorna o nome da coluna</returns>
        public string Alias()
        {
            return !string.IsNullOrEmpty(Field.Alias) ? Field.Alias : ColumnName();
        }

        /// <summary>
        /// ColumnWithMatchCase ou Alias se necessário
        /// </summary>
        /// <param name="dialect">Dialeto atual sendo usado</param>
        /// <returns>ColumnWithMatchCase ou Alias se necessário</returns>
        public string ColumnWithAlias(Dialect.Dialect dialect)
        {
            #region debug

            if (dialect == null)
                throw new ArgumentNullException("dialect", Messages.InvalidArgumentValue);

            #endregion

            string name = ColumnWithMatchCase(dialect);

            if (!string.IsNullOrEmpty(Field.Alias))
            {
                //
                // Aqui pode chegar um dos casos a seguir:
                // [columnName] As newColumnName || columnName As newColumnName
                //
                name += " AS " + Field.Alias;
            }

            return name;
        }

        /// <summary>
        /// Nome do campo parametrizado
        /// </summary>
        /// <param name="dialect">Dialeto atual sendo usado</param>
        /// <returns>Nome do parâmetro ex.: @column, :column</returns>
        public string ParamName(Dialect.Dialect dialect)
        {
            #region debug

            if (dialect == null)
                throw new ArgumentNullException("dialect", Messages.InvalidArgumentValue);

            #endregion

            return dialect.GetParamString() + Alias();
        }

        /// <summary>
        /// Define o valor do campo
        /// </summary>
        /// <param name="value">Valor a ser definido</param>
        public void SetValue(object value)
        {
            #region debug

            if (value == null)
                throw new ArgumentNullException("value", Messages.InvalidArgumentValue);

            #endregion

            try
            {
                if (Type.IsSubclassOf(typeof (Enum)))
                    Info.SetValue(Persist,
                                  Convert.ChangeType(Convert.ChangeType(Enum.ToObject(Type, Convert.ChangeType(value, typeof(int))), Type), Type), null);
                else
                    Info.SetValue(Persist, Convert.ChangeType(Convert.ChangeType(value, Type), Type), null);
            }
            catch (InvalidCastException ex)
            {
                throw new SetPropertyException(string.Format(Messages.MSG_00014, Info.Name, GetType().Name), ex);
            }
        }
    }
}