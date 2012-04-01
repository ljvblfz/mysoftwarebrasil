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
    /// Classe Modelo de EstadoCivil
    /// </summary>
    public class EstadoCivil
    {
        #region properties


        /// <summary>
        ///  idEstadoCivil 
        /// </summary>
        public virtual int idEstadoCivil { get; set; }

        /// <summary>
        ///  nameEstadoCivil 
        /// </summary>
        public virtual string nameEstadoCivil { get; set; }


        #endregion

        #region constructors

        public EstadoCivil()
        {
        }

        #endregion

        /// <summary>
        ///  Lista os dados
        /// </summary>
        /// <returns>lista de todos os dados</returns>
        public static IList<EstadoCivil> List()
        {
            return new List<EstadoCivil>()
            {
                new EstadoCivil()
                {
                    idEstadoCivil = 1,
                    nameEstadoCivil = "Solteiro",
                },
                new EstadoCivil()
                {
                    idEstadoCivil = 2,
                    nameEstadoCivil = "Casado",
                }
            };
        }
    }
}
