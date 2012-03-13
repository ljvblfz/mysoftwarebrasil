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
    /// Classe Modelo de Cabelo
    /// </summary>
    public class Cabelo 
    {  
        #region properties
    
        
            /// <summary>
            ///  idCabelo 
            /// </summary>
            public virtual int idCabelo { get; set; }

            /// <summary>
            ///  nameCabelo 
            /// </summary>
            public virtual string nameCabelo { get; set; }
                       

        #endregion
        
        #region constructors

            public Cabelo()
            {
            }
   
        #endregion
    }
}
