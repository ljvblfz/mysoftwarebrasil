using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;
using CommonHelpMobile;

namespace SPCadMobileData.Data.Model
{
    [PersistenceClass("TB_HISTORICO_CONSUMO")]
    public class HistoricoConsumo : AuditoriaSuper
    {
        [PersistenceProperty("ID_HIST_CONSM", PersistenceParameterType.Key)]
        public long Id { get; set; }

        [PersistenceProperty("NUM_MATRIC")]        
        public long? Matricula { get; set; }

        [PersistenceProperty("ID_CADAST")]
        [PersistenceForeignKey(typeof(Cadastro), "Id")]
        public long? Cadastro { get; set; }

        [PersistenceProperty("MES_REFER")]
        public DateTime? MesReferencia { get; set; }

        [PersistenceProperty("COD_OCORRC1")]
        [PersistenceForeignKey(typeof(Ocorrencia), "Id")]
        public int? Ocorrencia1 { get; set; }

        [PersistenceProperty("COD_OCORRC2")]
        [PersistenceForeignKey(typeof(Ocorrencia), "Id")]
        public int? Ocorrencia2 { get; set; }

        [PersistenceProperty("CRITR")]
        public string Criterio { get; set; }

        [PersistenceProperty("VOL_MEDDO")]
        public int? VolumeMedido { get; set; }

        [PersistenceProperty("FLG_HISTCONSUMO")]
        public string FlgHistconsumo { get; set; }

        [PersistenceProperty("LEITURA_FAT")]
        public long? LeituraApuracao { get; set; }

        [PersistenceProperty("DAT_LEITURA_FAT")]
        public DateTime? DatLeituraFat { get; set; }

        #region propriedade extendida

        [PersistenceProperty("DataInstalacao", DirectionParameter.InputOptional)]
        public DateTime DataInstalacao { get; set; }

        //exibe o campo DataInstalacao como texto
        public string DataInstalacaoText { get { return DataInstalacao.ToString("dd/MM/yyyy"); } }

        [PersistenceProperty("DescOcorrencia1", DirectionParameter.InputOptional)]
        public string DescOcorrencia1 { get; set; }

        [PersistenceProperty("DescOcorrencia2", DirectionParameter.InputOptional)]
        public string DescOcorrencia2 { get; set; }

        [PersistenceProperty("ExpectativaConsu", DirectionParameter.InputOptional)]
        public string ExpectativaConsu { get; set; }

        [PersistenceProperty("Incompatibilidade", DirectionParameter.InputOptional)]
        public string Incompatibilidade { get; set; }

        [PersistenceProperty("ObsNaoConf", DirectionParameter.InputOptional)]
        public string ObsNaoConf { get; set; }

        /// <summary>
        ///  Campo "CA" do grid de comsumo
        /// </summary>
        public string DescCriterio
        {
            get
            {
                List<ItemCombo> lst = ListCriterioApuracao.getList();
                int criteirio = 0;
                ItemCombo valor = new ItemCombo("0", "");

                // Verifica se o criterio e nulo
                if (!String.IsNullOrEmpty(Criterio))
                {
                    // Converte o criterio para numerico
                    criteirio = int.Parse(Criterio);

                    // carrega o item combo correspondente
                    valor = lst.Find(item => criteirio.Equals(item.Value));
                }
                return valor.Description.ToString();
            }
        }

        

        #endregion
    }
}
