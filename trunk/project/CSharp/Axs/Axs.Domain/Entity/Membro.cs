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
    /// Classe Modelo de Membro
    /// </summary>
    public class Membro 
    {  
        #region properties
    
        
            /// <summary>
            ///  idMembro 
            /// </summary>
            public virtual int idMembro { get; set; }

            /// <summary>
            ///  loginMembro 
            /// </summary>
            public virtual string loginMembro { get; set; }

            /// <summary>
            ///  senhaMembro 
            /// </summary>
            public virtual string senhaMembro { get; set; }

            /// <summary>
            ///  idPessoa 
            /// </summary>
            public virtual int idPessoa { get; set; }

            /// <summary>
            ///  idRole 
            /// </summary>
            public virtual int idRole { get; set; }

            /// <summary>
            ///  Pessoa
            /// </summary>
            public virtual Pessoa pessoa { get; set; }
                       

        #endregion
        
        #region constructors

            public Membro()
            {
            }
   
        #endregion
    }
}
