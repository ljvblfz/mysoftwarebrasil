using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;
using CommonHelpDesktop;

namespace SPCadDesktopData.Data.Model
{
    [PersistenceClass("TB_HISTORICO_CONSUMO")]
    //[PersistenceBaseDAO(typeof(RotaDAO))]
    public class HistoricoConsumo : AuditoriaSuper
    {
        [PersistenceProperty("ID_HIST_CONSM", PersistenceParameterType.IdentityKey)]
        public long Id { get; set; }

        [PersistenceProperty("NUM_MATRIC")]        
        public long Matricula { get; set; }

        [PersistenceProperty("ID_CADAST")]
        [PersistenceForeignKey(typeof(Cadastro), "Id")]
        public long Cadastro { get; set; }

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

        public string DescCriterio
        {
            get
            {
                List<ItemCombo> lst = ListCriterioApuracao.getList();

                ItemCombo valor = lst.Find(delegate(ItemCombo item)
                {
                    return item.Value.ToString() == Criterio;                    
                });

                return valor.Description.ToString();
            }
        }

        [PersistenceProperty("VOL_MEDDO")]
        public int VolumeMedido { get; set; }

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

        public string DescExpectativaConsu
        {
            get 
            {
                List<ItemCombo> lst = ListExpectativaConsumo.getList();

                ItemCombo vlr = lst.Find(delegate(ItemCombo item)
                {
                    return item.Value.ToString() == ExpectativaConsu;
                });

                return vlr.Description.ToString();
            }
        }

        [PersistenceProperty("Incompatibilidade", DirectionParameter.InputOptional)]
        public string Incompatibilidade { get; set; }

        [PersistenceProperty("ObsNaoConf", DirectionParameter.InputOptional)]
        public string ObsNaoConf { get; set; }

        

        #endregion
    }
}
