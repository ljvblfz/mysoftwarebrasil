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
    /// Classe Modelo de Foto
    /// </summary>
    public class Foto 
    {  
        #region properties
    
        
            /// <summary>
            ///  idFoto 
            /// </summary>
            public virtual int idFoto { get; set; }

            /// <summary>
            ///  nameFoto 
            /// </summary>
            public virtual string nameFoto { get; set; }

            /// <summary>
            ///  pathFoto 
            /// </summary>
            public virtual string pathFoto { get; set; }

            /// <summary>
            ///  legendaFoto 
            /// </summary>
            public virtual string legendaFoto { get; set; }

            /// <summary>
            ///  idMembro 
            /// </summary>
            public virtual int idMembro { get; set; }
                       

        #endregion
        
        #region constructors

            public Foto()
            {
            }
   
        #endregion
    }
}
