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
 
namespace PontoEncontro.Domain 
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
    }
}
