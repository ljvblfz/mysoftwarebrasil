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
    /// Classe Modelo de Pessoa
    /// </summary>
    public class Pessoa 
    {  
        #region properties
    
        
            /// <summary>
            ///  idPessoa 
            /// </summary>
            public virtual int idPessoa { get; set; }

            /// <summary>
            ///  idPerfil 
            /// </summary>
            public virtual int idPerfil { get; set; }

            /// <summary>
            ///  nomePessoa 
            /// </summary>
            public virtual string nomePessoa { get; set; }

            /// <summary>
            ///  e_MailPessoa 
            /// </summary>
            public virtual string e_MailPessoa { get; set; }

            /// <summary>
            ///  nascimentoPessoa 
            /// </summary>
            public virtual DateTime nascimentoPessoa { get; set; }

            /// <summary>
            ///  Perfil
            /// </summary>
            public virtual Perfil perfil { get; set; }
                       

        #endregion
        
        #region constructors

            public Pessoa()
            {
            }
   
        #endregion
    }
}
