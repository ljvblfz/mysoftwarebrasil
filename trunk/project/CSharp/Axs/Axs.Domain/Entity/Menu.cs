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
    /// Classe Modelo de Menu
    /// </summary>
    public class Menu 
    {  
        #region properties
    
        
            /// <summary>
            ///  idMenu 
            /// </summary>
            public virtual int idMenu { get; set; }

            /// <summary>
            ///  MenuIdPai 
            /// </summary>
            public virtual int MenuIdPai { get; set; }

            /// <summary>
            ///  nameMenu 
            /// </summary>
            public virtual string nameMenu { get; set; }

            /// <summary>
            ///  ordemMenu 
            /// </summary>
            public virtual int ordemMenu { get; set; }

            /// <summary>
            ///  pathMenu 
            /// </summary>
            public virtual string pathMenu { get; set; }
                       

        #endregion
        
        #region constructors

            public Menu()
            {
            }
   
        #endregion
    }
}
