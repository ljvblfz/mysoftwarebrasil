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

namespace Paulovich.Data
{
    /// <summary>
    /// Classe singleton para a conversão entre os tipos managed e os tipos usados em SQL
    /// </summary>
    public class SingletonTypeConverter
    {
        [ThreadStatic] private static SingletonTypeConverter instance;

        private Dictionary<Type, DbType> typeDbType;

        /// <summary>
        /// Cria a instância
        /// </summary>
        protected SingletonTypeConverter()
        {
            Initialize();
        }

        /// <summary>
        /// Única instância desse objeto
        /// </summary>
        /// <returns>Retorna a instância</returns>
        public static SingletonTypeConverter Instance()
        {
            if (instance == null)
            {
                instance = new SingletonTypeConverter();
            }

            return instance;
        }

        /// <summary>
        /// Inicializa o dicionário de convesão
        /// </summary>
        public void Initialize()
        {
            typeDbType = new Dictionary<Type, DbType>(20);

            RegisterType(typeof (Byte[]), DbType.Binary);
            RegisterType(typeof (Boolean), DbType.Boolean);
            RegisterType(typeof (Byte), DbType.Byte);
            RegisterType(typeof (DateTime), DbType.DateTime);
            RegisterType(typeof (Decimal), DbType.Decimal);
            RegisterType(typeof (Double), DbType.Double);
            RegisterType(typeof (Guid), DbType.Guid);
            RegisterType(typeof (Int16), DbType.Int16);
            RegisterType(typeof (Int32), DbType.Int32);
            RegisterType(typeof (Int64), DbType.Int64);
            RegisterType(typeof (SByte), DbType.SByte);
            RegisterType(typeof (Single), DbType.Single);
            RegisterType(typeof (String), DbType.String);
            RegisterType(typeof (UInt16), DbType.UInt16);
            RegisterType(typeof (UInt32), DbType.UInt32);
            RegisterType(typeof (UInt64), DbType.UInt64);
            RegisterType(typeof (Char), DbType.String);
            RegisterType(typeof (Enum), DbType.Int32);
        }

        /// <summary>
        /// Registra o tipo managed e o tipo SQL
        /// </summary>
        /// <param name="type">Tipo .NET</param>
        /// <param name="dbType">Tipo SQL</param>
        private void RegisterType(Type type, DbType dbType)
        {
            #region debug

            if (type == null)
                throw new ArgumentNullException("type", Messages.InvalidArgumentValue);

            #endregion

            if (!typeDbType.ContainsKey(type))
            {
                typeDbType.Add(type, dbType);
            }
        }

        /// <summary>
        /// Procura pelo respectivo tipo SQL
        /// </summary>
        /// <param name="type">Tipo .NET</param>
        /// <returns>Tipo SQL</returns>
        public DbType DbTypeOf(Type type)
        {
            #region debug

            if (type == null)
                throw new ArgumentNullException("type", Messages.InvalidArgumentValue);

            #endregion

            if (type.IsSubclassOf(typeof (Enum)))
                type = typeof (Enum);

            return typeDbType[type];
        }
    }
}