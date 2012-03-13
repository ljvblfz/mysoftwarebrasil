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
    /// Classe Modelo de Olho
    /// </summary>
    public class Olho 
    {  
        #region properties
    
        
            /// <summary>
            ///  idOlho 
            /// </summary>
            public virtual int idOlho { get; set; }

            /// <summary>
            ///  nameOlho 
            /// </summary>
            public virtual string nameOlho { get; set; }
                       

        #endregion
        
        #region constructors

            public Olho()
            {
            }
   
        #endregion
    }
}
