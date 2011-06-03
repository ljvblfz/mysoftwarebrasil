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

using Paulovich.Data.NetBuilder;
using Paulovich.Data.SqlBuilder;

namespace Paulovich.Data
{
    public static class CodeGenerator
    {
        /// <summary>
        /// Generates a string that represents a .NET Persistent Class.
        /// </summary>
        /// <param name="tableName">Name of the table in the database.</param>
        /// <param name="className">Friendly name of the .NET Persistent Class.</param>
        /// <param name="depth"></param>
        /// <param name="insertHeader"></param>
        /// <param name="insertProperties"></param>
        /// <param name="insertConstructors"></param>
        /// <returns>String that represents the .NET Persistent Class.</returns>
        public static string Generate(string tableName, string className, int depth, bool insertHeader,
                                      bool insertProperties, bool insertConstructors)
        {
            return CSharpClass.Generate(tableName, className, 0, insertHeader, insertProperties, insertConstructors,
                                        depth, true);
        }

        /// <summary>
        /// Returns a SQL statement based in the System.Type and operation argument.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="operation">Operation</param>
        /// <returns>String with generated SQL statement if success else string.Empty</returns>
        public static string Generate(object obj, Persist.Operation operation)
        {
            var command = new Command();

            return Generate(obj, command, operation);
        }

        /// <summary>
        /// Returns a SQL statement based in the System.Type and operation argument.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="command"></param>
        /// <param name="operation">Operation</param>
        /// <returns>String with generated SQL statement if success else string.Empty</returns>
        public static string Generate(object obj, Command command, Persist.Operation operation)
        {
            switch (operation)
            {
                case Persist.Operation.Get:

                    //GENERATES "GET METHOD"

                    return Get.Generate(obj, command);

                case Persist.Operation.Insert:

                    //GENERATES "INSERT METHOD"

                    return Insert.Generate(obj, command);

                case Persist.Operation.Update:

                    //GENERATES "UPDATE METHOD"

                    return Update.Generate(obj, command);

                case Persist.Operation.Delete:

                    //GENERATES "DELETE METHOD"

                    return Delete.Generate(obj, command);

                default:
                    return string.Empty;
            }
        }
    }
}