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
using Paulovich.Data.Resources;

namespace Paulovich.Data.Dialect
{
    public static class SqlCSharpConverter
    {
        /// <summary>
        /// Converts a SQL Type into a .NET Type as string. 
        /// </summary>
        /// <param name="type">SQL Type from database.</param>
        /// <returns>String that represents the .NET Type.</returns>        
        public static string GetDotNetType(string type)
        {
            #region debug

            if (string.IsNullOrEmpty(type))
                throw new ArgumentNullException("type", Messages.InvalidArgumentValue);

            #endregion

            switch (type)
            {
                case "bit":
                    return "bool";
                case "smallint":
                case "tinyint":
                    return "Int16";
                case "bigint":
                case "int":
                    return "int";
                case "real":
                case "float":
                case "smallmoney":
                    return "float";
                case "money":
                case "numeric":
                case "decimal":
                    return "decimal";
                case "smalldatetime":
                case "datetime":
                    return "DateTime";
                case "ntext":
                case "nchar":
                case "nvarchar":
                case "text":
                case "varchar":
                case "char":
                    return "string";
                case "uniqueidentifier":
                    return "Guid";
                case "image":
                    return "byte[]";
                default:
                    return "object";
            }
        }
    }
}