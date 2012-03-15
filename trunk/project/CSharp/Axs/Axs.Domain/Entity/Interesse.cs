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
    /// Classe Modelo de Interesse
    /// </summary>
    public class Interesse 
    {  
        #region properties
    
        
            /// <summary>
            ///  idInteresse 
            /// </summary>
            public virtual int idInteresse { get; set; }

            /// <summary>
            ///  Descricao 
            /// </summary>
            public virtual string Descricao { get; set; }

            /// <summary>
            ///  idTipoInteresse 
            /// </summary>
            public virtual int idTipoInteresse { get; set; }

            /// <summary>
            ///  idPerfil 
            /// </summary>
            public virtual int idPerfil { get; set; }
                       

        #endregion
        
        #region constructors

            public Interesse()
            {
            }
   
        #endregion
    }
}
