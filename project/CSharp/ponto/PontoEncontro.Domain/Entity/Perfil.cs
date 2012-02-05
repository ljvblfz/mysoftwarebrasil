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
    /// Classe Modelo de Perfil
    /// </summary>
    public class Perfil 
    {  
        #region properties
    
        
            /// <summary>
            ///  idSexo 
            /// </summary>
            public virtual int idSexo { get; set; }

            /// <summary>
            ///  idOlho 
            /// </summary>
            public virtual int idOlho { get; set; }

            /// <summary>
            ///  idCabelo 
            /// </summary>
            public virtual int idCabelo { get; set; }

            /// <summary>
            ///  idEtinia 
            /// </summary>
            public virtual int idEtinia { get; set; }

            /// <summary>
            ///  idEstadoCivil 
            /// </summary>
            public virtual int idEstadoCivil { get; set; }

            /// <summary>
            ///  idEndereco 
            /// </summary>
            public virtual int idEndereco { get; set; }

            /// <summary>
            ///  idPerfil 
            /// </summary>
            public virtual int idPerfil { get; set; }
                       

        #endregion
        
        #region constructors

            public Perfil()
            {
            }
   
        #endregion
    }
}
