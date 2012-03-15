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
    /// Classe Modelo de Estado
    /// </summary>
    public class Estado 
    {  
        #region properties
    
        
            /// <summary>
            ///  idEstado 
            /// </summary>
            public virtual int idEstado { get; set; }

            /// <summary>
            ///  nameEstado 
            /// </summary>
            public virtual string nameEstado { get; set; }

            /// <summary>
            ///  SiglaEstado 
            /// </summary>
            public virtual string SiglaEstado { get; set; }
                       

        #endregion
        
        #region constructors

            public Estado()
            {
            }
   
        #endregion
    }
}
