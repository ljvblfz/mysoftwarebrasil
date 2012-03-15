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
    /// Classe Modelo de PermissaoRole
    /// </summary>
    public class PermissaoRole 
    {  
        #region properties
    
        
            /// <summary>
            ///  idRole 
            /// </summary>
            public virtual int idRole { get; set; }

            /// <summary>
            ///  idPermissao 
            /// </summary>
            public virtual int idPermissao { get; set; }
                       

        #endregion
        
        #region constructors

            public PermissaoRole()
            {
            }
   
        #endregion
    }
}
