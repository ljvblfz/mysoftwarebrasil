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
    /// Classe Modelo de Action
    /// </summary>
    public class Action 
    {  
        #region properties
    
        
            /// <summary>
            ///  idAction 
            /// </summary>
            public virtual int idAction { get; set; }

            /// <summary>
            ///  nameAction 
            /// </summary>
            public virtual string nameAction { get; set; }
                       

        #endregion
        
        #region constructors

            public Action()
            {
            }
   
        #endregion
    }
}
