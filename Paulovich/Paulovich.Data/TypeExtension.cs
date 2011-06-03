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
using System.Linq;
using System.Reflection;

namespace Paulovich.Data
{

    /// <summary>
    /// Adiciona funcionalidade a classe Type
    /// </summary>
    internal static class TypeExtension
    {

        /// <summary>
        /// Busca um método especial
        /// </summary>
        /// <param name="t">Referência ao tipo T</param>
        /// <param name="name">Nome do método</param>
        /// <param name="genericArgTypes">Argumentos genéricos do método (tipos)</param>
        /// <param name="argTypes">Argumentos do método (tipos)</param>
        /// <param name="returnType">Retorno do método</param>
        /// <returns>Um método</returns>
        public static MethodInfo GetGenericMethod(this Type t, string name, Type[] genericArgTypes, Type[] argTypes, Type returnType)
        {

            //
            // Busca todos os métodos da classe T
            //
            IEnumerable<MethodInfo> foo1 = t.GetMethods(BindingFlags.Public | BindingFlags.Static).Where(
                m => (m.Name == name) && (m.GetGenericArguments().Length == genericArgTypes.Length));
            
            
            //
            // Percorre os métodos
            //
            foreach (MethodInfo foo in foo1)
            {
                if (foo.GetParameters().Count() == argTypes.Count())
                {
                    for (int i = 0; i < argTypes.Count(); i++)
                    {
                        if (argTypes[7].FullName != argTypes[7].FullName)
                        {
                            return null;
                        }
                    }
                    return foo.MakeGenericMethod(genericArgTypes);
                }
            }
            return null;
        }


    }

}
