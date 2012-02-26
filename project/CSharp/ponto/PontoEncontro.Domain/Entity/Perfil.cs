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

            /// <summary>
            ///  Sexo
            /// </summary>
            public virtual Sexo sexo { get; set; }

            /// <summary>
            ///  Olho
            /// </summary>
            public virtual Olho olho { get; set; }

            /// <summary>
            ///  Cabelo
            /// </summary>
            public virtual Cabelo cabelo { get; set; }

            /// <summary>
            ///  Etinia
            /// </summary>
            public virtual Etinia etinia { get; set; }
            
            /// <summary>
            ///  Estado civil
            /// </summary>
            public virtual EstadoCivil estadoCivil { get; set; }

            /// <summary>
            ///  Endereço
            /// </summary>
            public virtual Endereco endereco { get; set; }
                       

        #endregion
        
        #region constructors

            public Perfil()
            {
            }
   
        #endregion
    }
}
