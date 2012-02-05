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
    /// Classe Modelo de Bairro
    /// </summary>
    public class Bairro 
    {  
        #region properties
    
        
            /// <summary>
            ///  idBairro 
            /// </summary>
            public virtual int idBairro { get; set; }

            /// <summary>
            ///  nomeBairro 
            /// </summary>
            public virtual string nomeBairro { get; set; }
                       

        #endregion
        
        #region constructors

            public Bairro()
            {
            }
   
        #endregion
    }
}
