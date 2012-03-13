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
    /// Classe Modelo de Contato
    /// </summary>
    public class Contato 
    {  
        #region properties
    
        
            /// <summary>
            ///  idContato 
            /// </summary>
            public virtual int idContato { get; set; }

            /// <summary>
            ///  valorContato 
            /// </summary>
            public virtual string valorContato { get; set; }

            /// <summary>
            ///  idPerfil 
            /// </summary>
            public virtual int idPerfil { get; set; }

            /// <summary>
            ///  idTipoContato 
            /// </summary>
            public virtual int idTipoContato { get; set; }
                       

        #endregion
        
        #region constructors

            public Contato()
            {
            }
   
        #endregion
    }
}
