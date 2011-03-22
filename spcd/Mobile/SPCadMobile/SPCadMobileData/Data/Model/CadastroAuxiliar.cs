using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GDA;
using CommonHelpMobile;

namespace SPCadMobileData.Data.Model
{
    /// <summary>
    /// Classe auxiliar da classe Cadastro
    /// </summary>
    [PersistenceClass("Cadastro")]
    public class CadastroAuxiliar : AuditoriaSuper
    {
        [PersistenceProperty("ID_CADAST", PersistenceParameterType.Key)]
        public long Id { get; set; }

        [PersistenceProperty("COD_ROTA")]
        [PersistenceForeignKey(typeof(Rota), "CodigoRota")]
        public int CodigoRota { get; set; }

        [PersistenceProperty("COD_DISTRT")]
        [PersistenceForeignKey(typeof(Rota), "CodigoDistrito")]
        public int CodigoDistrito { get; set; }

        [PersistenceProperty("NUM_SEQ")]
        public int Sequencia { get; set; }

        [PersistenceProperty("NUM_FACE")]
        public int Face { get; set; }

        //0-Não executado; 1-Executado; 2-Impedido de Execução
        [PersistenceProperty("STATUS_EXEC")]
        public int? StatusExecucao { get; set; }

        [PersistenceProperty("NUM_MEDIDR")]
        public string NumeroMedidor { get; set; }

        [PersistenceProperty("NUM_MATRIC")]
        public long Matricula { get; set; }

        [PersistenceProperty("NOM_CLIENT")]
        public string NomeCliente { get; set; }

        [PersistenceProperty("NUM_PONTO_SERVC")]
        public string NumeroPontoServico { get; set; }

        //cada posição da string, ou cada posição de caractere, representa o estado de cada aba, respectivamente, na interface frmDadosImovel.cs 
        [PersistenceProperty("FLG_IMOABA")]
        public string FlagImovelAba { get; set; }

        [PersistenceProperty("SIT_PONTO_SERVC_ALTER")]
        public string SituacaoPontoServicoAlter { get; set; }

        [PersistenceProperty("COD_FUNCN")]
        public int CodigoFuncionario { get; set; }

        #region endereço imovel

        [PersistenceProperty("TIP_LOGRD")]
        public string TipoLogradouro { get; set; }

        public string DescTipoLogradouro
        {
            get
            {
                List<ItemCombo> lst = ListDescLogradouro.getList();

                ItemCombo valor = lst.Where(item => item.Value.ToString().Trim() == TipoLogradouro.Trim()).First<ItemCombo>();

                return valor.Description.ToString();
            }
        }

        [PersistenceProperty("NOM_LOGRD")]
        public string NomeLogradouro { get; set; }

        [PersistenceProperty("NUM_IMOV")]
        public int NumeroImovel { get; set; }

        [PersistenceProperty("NUM_IMOV_ALTER")]
        public int? NumeroImovelAlter { get; set; }

        [PersistenceProperty("NOM_BAIRR")]
        public string NomeBairro { get; set; }

        [PersistenceProperty("NOM_CIDAD")]
        public string NomeCidade { get; set; }

        [PersistenceProperty("OBS_COMPL")]
        public string Observacao_complementar { get; set; }

        [PersistenceProperty("OBS_VISITA")]
        public string ObservacaoVisita { get; set; }

        private string _vetorOcorrencia;

        [PersistenceProperty("VETOR_OCORRC")]
        public string VetorOcorrencia
        {
            get
            {
                return _vetorOcorrencia.Trim();
            }
            set
            {
                if (value != null)
                {
                    _vetorOcorrencia = value.Trim();
                }
                else
                {
                    _vetorOcorrencia = string.Empty;
                }
            }
        }

        public string DescVetorOcorrencia
        {
            get
            {
                List<ItemCombo> lst = ListOcorrcImped.getList();

                ItemCombo tipo = lst.Find(delegate(ItemCombo item)
                {
                    return item.Value.ToString() == VetorOcorrencia;
                }
                );
                
                return (string)tipo.Description;
            }
        }

        [PersistenceProperty("OBS_IMPDM")]
        public string ObservacaoImpedimento { get; set; }

        [PersistenceProperty("COORD_X")]
        public string CoordenadaX { get; set; }

        [PersistenceProperty("COORD_Y")]
        public string CoordenadaY { get; set; }

        [PersistenceProperty("DATAGPS")]
        public DateTime? DataGPS { get; set; }

        #endregion


        #region propriedades extendida

        [PersistenceProperty("DES_TIP_COMPL", DirectionParameter.InputOptional)]
        public string Complemento { get; set; }

        /// <summary>
        /// Exibe a descrição do campo StatusExecucao.
        /// </summary>
        public string DescricaoSituacao
        {
            get
            {
                List<ItemCombo> situacao = SituacaoBanco.getList();

                ItemCombo tipo = situacao.Find(delegate(ItemCombo item)
                {
                    return int.Parse(item.Value.ToString()) == StatusExecucao;
                }
                );

                return tipo.Description.ToString();
            }
        }

        /// <summary>
        /// Quantidade de ponto de serviço por matricula
        /// </summary>
        [PersistenceProperty("QtdPS", DirectionParameter.InputOptional)]
        public string QtdPS { get; set; }

        public string enderecoImovel
        {
            get
            {
                string endereco = string.Empty;

                endereco = DescTipoLogradouro + " " + NomeLogradouro + ", " + NumeroImovelAlter + "  " + NomeBairro + " - " + NomeCidade + "\r\n" + Observacao_complementar;

                return endereco;
            }
        }

        #endregion
    }
}
