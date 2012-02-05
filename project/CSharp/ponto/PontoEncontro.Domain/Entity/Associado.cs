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
    /// Classe Modelo de Associado
    /// </summary>
    public class Associado 
    {  
        #region properties
    
        
            /// <summary>
            ///  idAssociado 
            /// </summary>
            public virtual int idAssociado { get; set; }

            /// <summary>
            ///  idMembro 
            /// </summary>
            public virtual int idMembro { get; set; }

            /// <summary>
            ///  idAssociacao 
            /// </summary>
            public virtual int idAssociacao { get; set; }
                       

        #endregion
        
        #region constructors

            public Associado()
            {
            }
   
        #endregion
    }
}
