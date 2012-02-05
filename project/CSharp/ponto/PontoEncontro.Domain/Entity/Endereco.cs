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
    /// Classe Modelo de Endereco
    /// </summary>
    public class Endereco 
    {  
        #region properties
    
        
            /// <summary>
            ///  idEndereco 
            /// </summary>
            public virtual int idEndereco { get; set; }

            /// <summary>
            ///  CEP 
            /// </summary>
            public virtual string CEP { get; set; }

            /// <summary>
            ///  idCidade 
            /// </summary>
            public virtual int idCidade { get; set; }

            /// <summary>
            ///  idBairro 
            /// </summary>
            public virtual int idBairro { get; set; }
                       

        #endregion
        
        #region constructors

            public Endereco()
            {
            }
   
        #endregion
    }
}
