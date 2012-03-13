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
    /// Classe Modelo de TipoContato
    /// </summary>
    public class TipoContato 
    {  
        #region properties
    
        
            /// <summary>
            ///  idTipoContato 
            /// </summary>
            public virtual int idTipoContato { get; set; }

            /// <summary>
            ///  nameTipoContato 
            /// </summary>
            public virtual string nameTipoContato { get; set; }
                       

        #endregion
        
        #region constructors

            public TipoContato()
            {
            }
   
        #endregion
    }
}
