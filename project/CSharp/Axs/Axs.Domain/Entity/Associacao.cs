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
    /// Classe Modelo de Associacao
    /// </summary>
    public class Associacao 
    {  
        #region properties
    
        
            /// <summary>
            ///  idAssociacao 
            /// </summary>
            public virtual int idAssociacao { get; set; }

            /// <summary>
            ///  idTipoAssociacao 
            /// </summary>
            public virtual int idTipoAssociacao { get; set; }

            /// <summary>
            ///  idMembro 
            /// </summary>
            public virtual int idMembro { get; set; }

            /// <summary>
            ///  idPessoa 
            /// </summary>
            public virtual int idPessoa { get; set; }
                       

        #endregion
        
        #region constructors

            public Associacao()
            {
            }
   
        #endregion
    }
}
