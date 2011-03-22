using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;
using SPCadDesktopData.Data.Model;

namespace SPCadDesktopData.Data.Model
{

    [PersistenceClass("TB_DISTRIBUICAO")]
    //[PersistenceBaseDAO(typeof(DistribuicaoDAO))]
    public class Distribuicao : AuditoriaSuper
    {
        //Id - Chave primária real // Codigo - Chave migrada do banco antigo
        [PersistenceProperty("COD_DISTRB", PersistenceParameterType.IdentityKey)]
        public long Id { get; set; }

        [PersistenceProperty("COD_DISTRT")]
        public int Distrito { get; set; }

        [PersistenceProperty("NUM_SETOR")]
        public int Setor { get; set; }

        [PersistenceProperty("COD_ROTA")]
        public int Rota { get; set; }

        [PersistenceProperty("COD_FUNCN")]
        [PersistenceForeignKey(typeof(Funcionario), "Id")]
        public int CodFuncionario { get; set; }

        [PersistenceForeignMember(typeof(Funcionario), "Nome")]
        public string NomeFuncionario { get; set; }

        [PersistenceProperty("SITUACAO_CARGA")]
        public string SituacaoCarga { get; set; }

        #region Propriedades extendidas

        public string SituacaoCargaString
        {
            get
            {
                return (SituacaoCarga == "1") ? "Distribuídos" :
                        (SituacaoCarga == "2") ? "Liberado" :
                        (SituacaoCarga == "3") ? "Carregado" :
                        (SituacaoCarga == "4") ? "Descarregado" :
                        (SituacaoCarga == "5") ? "Finalizado" : "";
            }
        }

        #endregion
    }
}
