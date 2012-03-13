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
    /// Classe Modelo de Controller
    /// </summary>
    public class Controller 
    {  
        #region properties
    
        
            /// <summary>
            ///  idController 
            /// </summary>
            public virtual int idController { get; set; }

            /// <summary>
            ///  nameController 
            /// </summary>
            public virtual string nameController { get; set; }
                       

        #endregion
        
        #region constructors

            public Controller()
            {
            }
   
        #endregion
    }
}
