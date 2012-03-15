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
    /// Classe Modelo de Role
    /// </summary>
    public class Role 
    {  
        #region properties
    
        
            /// <summary>
            ///  idRole 
            /// </summary>
            public virtual int idRole { get; set; }

            /// <summary>
            ///  nameRole 
            /// </summary>
            public virtual string nameRole { get; set; }
                       

        #endregion
        
        #region constructors

            public Role()
            {
            }
   
        #endregion
    }
}
