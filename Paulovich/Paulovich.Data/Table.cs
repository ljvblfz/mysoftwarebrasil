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
//           * André Paulovich (paulovich@100loop.com)     
//           Blog: http://www.100loop.com/blogs/           
//           Messenger: andrepaulovich@hotmail.com
//

using System;
using Paulovich.Data.Resources;

namespace Paulovich.Data
{
    /// <summary>
    /// Tabela associada a essa classe
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class Table : Attribute
    {
        #region properties

        /// <summary>
        /// Objeto associado a essa tabela
        /// </summary>
        public Persist Persist { get; set; }

        /// <summary>
        /// Nome da tabela no banco de dados
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// Se o nome da tabela contém algum espaço ou caractere especial
        /// marque essa propriedade com "true" que o gerador de comando SQL irá adicionar
        /// aspas simples ou colchetes na chamada da tabela
        /// </summary>
        public bool MatchCase { get; set; }

        #endregion

        #region constructors

        /// <summary>
        /// Cria uma tabela já definindo o seu nome
        /// </summary>
        /// <param name="table">Tablename</param>
        public Table(string table)
        {
            #region debug

            if (string.IsNullOrEmpty(table))
                throw new ArgumentNullException("table", Messages.InvalidArgumentValue);

            #endregion

            TableName = table;
        }

        public Table()
        {
            TableName = string.Empty;
            MatchCase = true;
        }

        #endregion
    }
}