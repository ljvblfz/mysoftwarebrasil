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
    /// Classe Modelo de Etinia
    /// </summary>
    public class Etinia
    {
        #region properties


        /// <summary>
        ///  idEtinia 
        /// </summary>
        public virtual int idEtinia { get; set; }

        /// <summary>
        ///  nameEtinia 
        /// </summary>
        public virtual string nameEtinia { get; set; }


        #endregion

        #region constructors

        public Etinia()
        {
        }

        #endregion

        /// <summary>
        ///  Lista os dados
        /// </summary>
        /// <returns>lista de todos os dados</returns>
        public static IList<Etinia> List()
        {
            return new List<Etinia>()
            {
                new Etinia()
                {
                    idEtinia = 1,
                    nameEtinia = "Negro",
                },
                new Etinia()
                {
                    idEtinia = 2,
                    nameEtinia = "Branco",
                }
            };
        }
    }
}
