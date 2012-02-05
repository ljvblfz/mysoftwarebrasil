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
    /// Classe Modelo de Cidade
    /// </summary>
    public class Cidade 
    {  
        #region properties
    
        
            /// <summary>
            ///  idCidade 
            /// </summary>
            public virtual int idCidade { get; set; }

            /// <summary>
            ///  nameCidade 
            /// </summary>
            public virtual string nameCidade { get; set; }

            /// <summary>
            ///  idEstado 
            /// </summary>
            public virtual int idEstado { get; set; }
                       

        #endregion
        
        #region constructors

            public Cidade()
            {
            }
   
        #endregion
    }
}