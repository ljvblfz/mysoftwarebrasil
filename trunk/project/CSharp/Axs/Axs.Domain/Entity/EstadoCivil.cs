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
    /// Classe Modelo de EstadoCivil
    /// </summary>
    public class EstadoCivil 
    {  
        #region properties
    
        
            /// <summary>
            ///  idEstadoCivil 
            /// </summary>
            public virtual int idEstadoCivil { get; set; }

            /// <summary>
            ///  nameEstadoCivil 
            /// </summary>
            public virtual string nameEstadoCivil { get; set; }
                       

        #endregion
        
        #region constructors

            public EstadoCivil()
            {
            }
   
        #endregion
    }
}
