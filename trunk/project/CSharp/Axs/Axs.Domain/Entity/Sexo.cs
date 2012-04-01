//
//  Copyright (c) 2012, AXS 
//  All rights reserved.
//
//  Authors: 
//          
//           * Alexis Moura
//           Generation
//           Messenger:
//
using System;  
using System.Collections.Generic;
 
namespace Axis.Domain 
{
    /// <summary>
    /// Classe Modelo de Sexo
    /// </summary>
    public class Sexo 
    {  
        #region properties
    
        
            /// <summary>
            ///  idSexo 
            /// </summary>
            public virtual int idSexo { get; set; }

            /// <summary>
            ///  nameSexo 
            /// </summary>
            public virtual string nameSexo { get; set; }
                       

        #endregion
        
        #region constructors

            public Sexo()
            {
            }
   
        #endregion

        /// <summary>
        ///  Lista os sexos
        /// </summary>
        /// <returns></returns>
        public static IList<Sexo> List()
        {
            return new List<Sexo>()
            {
                new Sexo()
                {
                    idSexo = 1,
                    nameSexo = "Masculino"
                },
                                new Sexo()
                {
                    idSexo = 2,
                    nameSexo = "Feminino"
                },
            };
        }
    }
}
