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
    /// Classe Modelo de Cabelo
    /// </summary>
    public class Cabelo
    {
        #region properties


        /// <summary>
        ///  idCabelo 
        /// </summary>
        public virtual int idCabelo { get; set; }

        /// <summary>
        ///  nameCabelo 
        /// </summary>
        public virtual string nameCabelo { get; set; }


        #endregion

        #region constructors

        public Cabelo()
        {
        }

        #endregion

        /// <summary>
        ///  Lista os dados
        /// </summary>
        /// <returns>lista de todos os dados</returns>
        public static IList<Cabelo> List()
        {
            return new List<Cabelo>()
            {
                new Cabelo()
                {
                    idCabelo = 1,
                    nameCabelo = "Preto",
                },
                new Cabelo()
                {
                    idCabelo = 2,
                    nameCabelo = "Loiro",
                }
            };
        }
    }
}
