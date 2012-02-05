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
    /// Classe Modelo de Permissoes
    /// </summary>
    public class Permissoes 
    {  
        #region properties
    
        
            /// <summary>
            ///  idPermissao 
            /// </summary>
            public virtual int idPermissao { get; set; }

            /// <summary>
            ///  namePermissao 
            /// </summary>
            public virtual string namePermissao { get; set; }

            /// <summary>
            ///  idAction 
            /// </summary>
            public virtual int idAction { get; set; }

            /// <summary>
            ///  idController 
            /// </summary>
            public virtual int idController { get; set; }
                       

        #endregion
        
        #region constructors

            public Permissoes()
            {
            }
   
        #endregion
    }
}
