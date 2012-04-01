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
    /// Classe Modelo de Olho
    /// </summary>
    public class Olho
    {
        #region properties


        /// <summary>
        ///  idOlho 
        /// </summary>
        public virtual int idOlho { get; set; }

        /// <summary>
        ///  nameOlho 
        /// </summary>
        public virtual string nameOlho { get; set; }


        #endregion

        #region constructors

        public Olho()
        {
        }

        #endregion

        /// <summary>
        ///  Lista os dados
        /// </summary>
        /// <returns>lista de todos os dados</returns>
        public static IList<Olho> List()
        {
            return new List<Olho>()
            {
                new Olho()
                {
                    idOlho = 1,
                    nameOlho = "Claro"
                },
                new Olho()
                {
                    idOlho = 2,
                    nameOlho = "Escuro"
                }
            };
        }
    }
}
