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
using Paulovich.Data.Resources;

namespace Paulovich.Data
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public abstract class DbField : Attribute
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        protected DbField(params object[] constraints)
        {
            MatchCase = true;
            IsUpdatable = true;
            IsInsertable = true;
            IsSelectable = true;
            Column = string.Empty;
            Constraints = new List<Constraint>();

            for (int i = 0; i < constraints.Length; i += 2)
            {
                Constraints.Add(new Constraint(((Type) (constraints[i])), constraints[i + 1].ToString()));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsIdentity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSequence
        {
            get { return !string.IsNullOrEmpty(Sequence); }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Constraint> Constraints { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool MatchCase { get; set; }

        /// <summary>
        /// Database columnname.
        /// </summary>
        public string Column { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Sequence { get; set; }

        /// <summary>
        /// Se o campo permitir valores nulos
        /// </summary>
        public bool AllowNulls { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsUpdatable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsInsertable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSelectable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Tamanho do campo
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public bool InsertNeeded(Command command)
        {
            #region debug

            if (command == null)
                throw new ArgumentNullException("command", Messages.InvalidArgumentValue);

            #endregion

            bool flag;
            switch (command.DataBaseType)
            {
                case DataBaseType.OleDb:
                case DataBaseType.Sql:
                case DataBaseType.MySql:
                    flag = !IsIdentity;
                    break;
                default:
                    flag = true;
                    break;
            }

            return flag;
        }
    }
}