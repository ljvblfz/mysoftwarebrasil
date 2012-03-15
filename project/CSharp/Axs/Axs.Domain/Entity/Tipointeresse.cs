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
    /// Classe Modelo de TipoInteresse
    /// </summary>
    public class TipoInteresse 
    {  
        #region properties
    
        
            /// <summary>
            ///  idTipoInteresse 
            /// </summary>
            public virtual int idTipoInteresse { get; set; }

            /// <summary>
            ///  nameTipoInteresse 
            /// </summary>
            public virtual string nameTipoInteresse { get; set; }
                       

        #endregion
        
        #region constructors

            public TipoInteresse()
            {
            }
   
        #endregion
    }
}
