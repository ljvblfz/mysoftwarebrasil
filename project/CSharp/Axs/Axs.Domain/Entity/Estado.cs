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
using System.Linq;
 
namespace Axis.Domain 
{
    /// <summary>
    /// Classe Modelo de Estado
    /// </summary>
    public class Estado 
    {
 
        #region properties
    
        
            /// <summary>
            ///  idEstado 
            /// </summary>
            public virtual int idEstado { get; set; }

            /// <summary>
            ///  nameEstado 
            /// </summary>
            public virtual string nameEstado { get; set; }

            /// <summary>
            ///  SiglaEstado 
            /// </summary>
            public virtual string SiglaEstado { get; set; }
                       

        #endregion
        
        #region constructors

            public Estado()
            {
            }

            public Estado(int idEstado, string nameEstado, string siglaEstado)
            {
                this.idEstado = idEstado;
                this.nameEstado = nameEstado;
                this.SiglaEstado = siglaEstado;
            }
   
        #endregion

        #region public metodos

            /// <summary>
            ///  Retorna o estado
            /// </summary>
            /// <param name="idEstado">codigo do estado</param>
            /// <returns></returns>
            public static Estado Get(int idEstado)
            {
                var list = (from l in List()
                            where l.idEstado == idEstado
                            select l).ToList<Estado>();
                return list.Count() > 0 ? list[0] :  null;
            }

            /// <summary>
            ///  Metodo que retorna uma lista de estados
            /// </summary>
            /// <returns>lista de estados</returns>
            public static IList<Estado> List()
            {
                var list = new List<Estado>();
                list.Add(new Estado(01, "Acre", "AC"));
                list.Add(new Estado(02, "Alagoas", "AL"));
                list.Add(new Estado(03, "Amazonas", "AM"));
                list.Add(new Estado(04, "Amapá", "AP"));
                list.Add(new Estado(05, "Bahia", "BA"));
                list.Add(new Estado(06, "Ceará", "CE"));
                list.Add(new Estado(07, "Distrito Federal", "DF"));
                list.Add(new Estado(08, "Espírito Santo", "ES"));
                list.Add(new Estado(09, "Goiás", "GO"));
                list.Add(new Estado(10, "Maranhão", "MA"));
                list.Add(new Estado(11, "Minas Gerais", "MG"));
                list.Add(new Estado(12, "Mato Grosso do Sul", "MS"));
                list.Add(new Estado(13, "Mato Grosso", "MT"));
                list.Add(new Estado(14, "Pará", "PA"));
                list.Add(new Estado(15, "Paraíba", "PB"));
                list.Add(new Estado(16, "Pernambuco", "PE"));
                list.Add(new Estado(17, "Piauí", "PI"));
                list.Add(new Estado(18, "Paraná", "PR"));
                list.Add(new Estado(19, "Rio de Janeiro", "RJ"));
                list.Add(new Estado(20, "Rio Grande do Norte", "RN"));
                list.Add(new Estado(21, "Rondônia", "RO"));
                list.Add(new Estado(22, "Roraima", "RR"));
                list.Add(new Estado(23, "Rio Grande do Sul", "RS"));
                list.Add(new Estado(24, "Santa Catarina", "SC"));
                list.Add(new Estado(25, "Sergipe", "SE"));
                list.Add(new Estado(26, "São Paulo", "SP"));
                list.Add(new Estado(27, "Tocantins", "TO"));
                return list;
            }

        #endregion
    }
}
