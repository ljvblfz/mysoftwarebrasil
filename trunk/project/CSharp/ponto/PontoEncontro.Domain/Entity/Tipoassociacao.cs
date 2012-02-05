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
    /// Classe Modelo de TipoAssociacao
    /// </summary>
    public class TipoAssociacao 
    {  
        #region properties
    
        
            /// <summary>
            ///  idTipoAssociacao 
            /// </summary>
            public virtual int idTipoAssociacao { get; set; }

            /// <summary>
            ///  nomeTipoAssociacao 
            /// </summary>
            public virtual string nomeTipoAssociacao { get; set; }
                       

        #endregion
        
        #region constructors

            public TipoAssociacao()
            {
            }
   
        #endregion
    }
}
