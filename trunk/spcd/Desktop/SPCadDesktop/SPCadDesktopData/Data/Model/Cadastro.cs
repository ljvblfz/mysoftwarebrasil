using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;
using CommonHelpDesktop;

namespace SPCadDesktopData.Data.Model
{
    [PersistenceClass("TB_CADASTRO")]
    //[PersistenceBaseDAO(typeof(RotaDAO))]
    public class Cadastro : AuditoriaSuper
    {
        #region Identificadores
        [PersistenceProperty("ID_CADAST", PersistenceParameterType.Key)]
        public long Id { get; set; }

        [PersistenceProperty("COD_ROTA")]
        [PersistenceForeignKey(typeof(Rota), "CodigoRota")]
        public int CodigoRota { get; set; }

        [PersistenceProperty("COD_DISTRT")]
        [PersistenceForeignKey(typeof(Rota), "CodigoDistrito")]
        public int CodigoDistrito { get; set; }

        [PersistenceProperty("NUM_SETOR")]
        [PersistenceForeignKey(typeof(Rota), "Setor")]
        public int Setor { get; set; }

        [PersistenceProperty("NUM_MATRIC")]
        public long Matricula { get; set; }

        #endregion

        #region Imóvel

        [PersistenceProperty("NOM_CLIENT")]
        public string NomeCliente { get; set; }

        [PersistenceProperty("TIP_LOGRD")]
        public string TipoLogradouro { get; set; }

        [PersistenceProperty("NOM_LOGRD")]
        public string NomeLogradouro { get; set; }

        [PersistenceProperty("NUM_IMOV")]
        public int NumeroImovel { get; set; }

        [PersistenceProperty("NUM_IMOV_ALTER")]
        public int? NumeroImovelAlter { get; set; }

        [PersistenceProperty("TIP_COMPL")]
        [PersistenceForeignKey(typeof(TipoComplemento), "Tipo")]
        public string TipoComplemento { get; set; }

        [PersistenceProperty("TIP_COMPL_ALTER")]
        [PersistenceForeignKey(typeof(TipoComplemento), "Tipo")]
        public string TipoComplementoAlter { get; set; }

        public string DescricaoTipoComplementoAlter //exibe a descrição do campo TipoComplementoAlter
        {
            get
            {
                return TipoComplementoAlter;
            }
        }

        [PersistenceProperty("INF_COMPL")]
        public string InformacaoComplementar { get; set; }

        [PersistenceProperty("INF_COMPL_ALTER")]
        public string InformacaoComplementarAlter { get; set; }

        [PersistenceProperty("NOM_BAIRR")]
        public string NomeBairro { get; set; }

        [PersistenceProperty("NOM_CIDAD")]
        public string NomeCidade { get; set; }

        [PersistenceProperty("COND_IMOV")]
        [PersistenceForeignKey(typeof(CondicaoImovel), "Id")]
        public int CondicaoImovel { get; set; }

        [PersistenceProperty("COND_IMOV_ALTER")]
        [PersistenceForeignKey(typeof(CondicaoImovel), "Id")]
        public int? CondicaoImovelAlter { get; set; }

        [PersistenceProperty("PREVS_FIM_OBRA")]
        public DateTime? PrevisaoFimObra { get; set; }

        [PersistenceProperty("NUM_FACE")]
        public int Face { get; set; }

        [PersistenceProperty("NUM_SEQ")]
        public int Sequencia { get; set; }

        [PersistenceProperty("OBS_COMPL")]
        public string Observacao_complementar { get; set; }

        #endregion

        #region Economias
        [PersistenceProperty("QTD_ECONOM_RES")]
        public int QtdeEconomiasResidencial { get; set; }

        [PersistenceProperty("QTD_ECONOM_COM")]
        public int QtdeEconomiasComercial { get; set; }

        [PersistenceProperty("QTD_ECONOM_IND")]
        public int QtdeEconomiasIndustrial { get; set; }

        [PersistenceProperty("QTD_ECONOM_PUB")]
        public int QtdeEconomiasPublica { get; set; }

        [PersistenceProperty("QTD_ECONOM_RES_ALTER")]
        public int? QtdeEconomiasResidencialAlter { get; set; }

        [PersistenceProperty("QTD_ECONOM_COM_ALTER")]
        public int? QtdeEconomiasComercialAlter { get; set; }

        [PersistenceProperty("QTD_ECONOM_IND_ALTER")]
        public int? QtdeEconomiasIndustrialAlter { get; set; }

        [PersistenceProperty("QTD_ECONOM_PUB_ALTER")]
        public int? QtdeEconomiasPublicaAlter { get; set; }

        [PersistenceProperty("RAMO_ATIVD_1")]
        public int? RamoAtividade1 { get; set; }

        [PersistenceProperty("RAMO_ATIVD_2")]
        public int? RamoAtividade2 { get; set; }

        [PersistenceProperty("RAMO_ATIVD_3")]
        public int? RamoAtividade3 { get; set; }

        [PersistenceProperty("RAMO_ATIVD_4")]
        public int? RamoAtividade4 { get; set; }

        [PersistenceProperty("RAMO_ATIVD_1_ALTER")]
        public int? RamoAtividade1Alter { get; set; }

        [PersistenceProperty("RAMO_ATIVD_2_ALTER")]
        public int? RamoAtividade2Alter { get; set; }

        [PersistenceProperty("RAMO_ATIVD_3_ALTER")]
        public int? RamoAtividade3Alter { get; set; }

        [PersistenceProperty("RAMO_ATIVD_4_ALTER")]
        public int? RamoAtividade4Alter { get; set; }
        #endregion

        #region Caracterícicas

        [PersistenceProperty("TARF_SOCIAL")]
        public string TarifaSocial { get; set; }

        //configura o valor da propriedade TarifaSocial
        public bool StatusTarifaSocial
        {
            get
            {
                if (TarifaSocial == "1")
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                {
                    TarifaSocial = "1";
                }
                else
                {
                    TarifaSocial = "0";
                }
            }
        }

        public string TarifaSocialText
        {
            get
            {
                return (StatusTarifaSocial) ? "Sim" : "Não";
            }
        }

        [PersistenceProperty("TARF_SOCIAL_IMCOMP")]
        public string TarifaSocialIncompativel { get; set; }

        [PersistenceProperty("OBS_TARFC_SOCIAL_IMCOMP")]
        public string TarifaSocialIncompativelObs { get; set; }

        [PersistenceProperty("FONTE_ALTERN")]
        [PersistenceForeignKey(typeof(FonteAlternativa), "Id")]
        public string FonteAlternativa { get; set; }

        [PersistenceProperty("FONTE_ALTERN_ALTER")]
        [PersistenceForeignKey(typeof(FonteAlternativa), "Id")]
        public string FonteAlternativaAlter { get; set; }

        public string StatusFonteAlternativaAlter
        {
            get
            {
                //    List<ItemCombo> lst = ListFonteAlternativa.getList();

                //    ItemCombo valor = lst.Find(delegate(ItemCombo item)
                //    {
                //        return (string)item.Value == FonteAlternativaAlter;
                //    });

                //    return valor.Description.ToString();
                return FonteAlternativaAlter;
            }
            set
            {
                if (string.IsNullOrEmpty((string)value))
                {
                    FonteAlternativaAlter = null;
                }
                else
                {
                    FonteAlternativaAlter = (string)value;
                }
            }
        }

        [PersistenceProperty("FLG_PISCIN")]
        public string Piscina { get; set; }

        [PersistenceProperty("FLG_PISCIN_ALTER")]
        public string PiscinaAlter { get; set; }

        [PersistenceProperty("FLG_RESERT")]
        public string Reservatorio { get; set; }

        [PersistenceProperty("FLG_RESERT_ALTER")]
        public string ReservatorioAlter { get; set; }

        [PersistenceProperty("SIT_IMOVEL")]
        public string SituacaoImovel { get; set; }

        [PersistenceProperty("SIT_IMOVEL_ALTER")]
        public string SituacaoImovelAlter { get; set; }

        public string StatusSituacaoImovelAlter
        {
            get
            {
                List<ItemCombo> lst = TiposSituacaoImovel.getList();

                ItemCombo valor = lst.Find(delegate(ItemCombo item)
                {
                    return item.Value.ToString() == SituacaoImovelAlter;
                });

                return valor.Description.ToString();
            }
            set
            {
                SituacaoImovelAlter = value.ToString();
            }
        }

        [PersistenceProperty("SIT_PONTO_SERVC")]
        public string SituacaoPontoServico { get; set; }

        [PersistenceProperty("SIT_PONTO_SERVC_ALTER")]
        public string SituacaoPontoServicoAlter { get; set; }

        #endregion

        [PersistenceProperty("OBS_VISITA")]
        public string ObservacaoVisita { get; set; }

        #region P.S. / Hidrômetro (Padrão)

        [PersistenceProperty("NUM_PONTO_SERVC")]
        public string NumeroPontoServico { get; set; }

        [PersistenceProperty("LOCLZ_PADRAO")]
        [PersistenceForeignKey(typeof(LocalizacaoPadrao), "Id")]
        public int LocalizacaoPadrao { get; set; }

        [PersistenceProperty("LOCLZ_PADRAO_ALTER")]
        [PersistenceForeignKey(typeof(LocalizacaoPadrao), "Id")]
        public int? LocalizacaoPadraoAlter { get; set; }

        [PersistenceProperty("TIP_PADRAO")]
        [PersistenceForeignKey(typeof(TipoPadrao), "Id")]
        public int TipoPadrao { get; set; }

        [PersistenceProperty("TIP_PADRAO_ALTER")]
        [PersistenceForeignKey(typeof(TipoPadrao), "Id")]
        public int? TipoPadraoAlter { get; set; }


        [PersistenceProperty("PADRAO_LACRADO")]
        public string PadraoLacrado { get; set; }

        [PersistenceProperty("ELIMND_AR")]
        public string EliminadorAr { get; set; }


        [PersistenceProperty("POSSUI_TORNR_PADRAO")]
        public string PossuiTorneiraPadrao { get; set; }


        #endregion

        #region P.S. / Hidrômetro (Medidor)

        /// <summary>
        /// "1" para sim, "2" para não
        /// </summary>
        [PersistenceProperty("EXISTE_MEDIDR")]
        public string ExisteMedidor { get; set; }

        public string StatusExisteMedidor
        {
            get
            {
                if (string.IsNullOrEmpty(ExisteMedidor) || ExisteMedidor == "0")
                {
                    return "1";
                }
                return ExisteMedidor;
            }
        }

        [PersistenceProperty("NUM_MEDIDR")]
        public string NumeroMedidor { get; set; }

        [PersistenceProperty("NUM_MEDIDR_ALTER")]
        public string NumeroMedidorAlter { get; set; }

        [PersistenceProperty("LEITURA")]
        public long? Leitura { get; set; }

        [PersistenceProperty("QTD_DIGIT_MEDIDR")]
        public int QtdeDigitosMedidor { get; set; }

        [PersistenceProperty("QTD_DIGIT_MEDIDR_ALTER")]
        public int? QtdeDigitosMedidorAlter { get; set; }

        [PersistenceProperty("CLASS_METRLG")]
        public string ClasseMetrologica { get; set; }

        [PersistenceProperty("CLASS_METRLG_ALTER")]
        public string ClasseMetrologicaAlter { get; set; }

        [PersistenceProperty("MEDIDR_LACRADO")]
        public string MedidorLacrado { get; set; }

        [PersistenceProperty("FLG_SEGND_LIGAC")]
        public string SegundaLigacao { get; set; }


        #endregion

        #region P.S. / Hidrômetro (2ª Ligação)

        [PersistenceProperty("NUM_MEDIDR_2")]
        public string NumeroMedidor2 { get; set; }

        [PersistenceProperty("LEITURA_2")]
        public long? Leitura2 { get; set; }

        [PersistenceProperty("QTD_DIGIT_MEDIDR_2")]
        public int? QtdeDigitosMedidor2 { get; set; }

        [PersistenceProperty("CLASS_METRLG_2")]
        public string ClasseMetrologica2 { get; set; }

        [PersistenceProperty("MEDIDR_LACRADO_2")]
        public string MedidorLacrado2 { get; set; }

        #endregion

        #region Histórico Consumo
        [PersistenceProperty("DAT_INSTAL")]
        public DateTime DataInstalacao { get; set; }

        [PersistenceProperty("VETOR_OCORRC")]
        public string VetorOcorrencia
        {
            get
            {
                return _vetorOcorrencia;
            }
            set
            {
                if (value != null)
                {
                    _vetorOcorrencia = value;
                }
                else
                {
                    _vetorOcorrencia = string.Empty;
                }
            }
        }

        private string _vetorOcorrencia;

        [PersistenceProperty("OBS_IMPDM")]
        public string ObservacaoImpedimento { get; set; }

        [PersistenceProperty("SUSPEI_FRAUDE")]
        public string SuspeitaFraude { get; set; }

        [PersistenceProperty("OBS_SUSPEI_FRAUDE")]
        public string SuspeitaFraudeObs { get; set; }

        [PersistenceProperty("EXPCTV_CONSM")]
        public string ExpectativaConsumo { get; set; }


        #endregion

        #region Campos de Controle
        [PersistenceProperty("COD_FUNCN")]
        [PersistenceForeignKey(typeof(Funcionario), "Id")]
        public int? CodigoFuncionario { get; set; }

        [PersistenceProperty("COORD_X")]
        public string CoordenadaX { get; set; }

        [PersistenceProperty("COORD_Y")]
        public string CoordenadaY { get; set; }

        [PersistenceProperty("DAT_VISITA")]
        public DateTime? DataVisita { get; set; }

        [PersistenceProperty("STATUS_EXEC")]
        public int? StatusExecucao { get; set; }

        [PersistenceProperty("DATAGPS")]
        public DateTime? DataGPS { get; set; }

        [PersistenceProperty("COD_LOTE_EXP")]
        public int CodigoLoteExportacao { get; set; }

        #endregion

        #region Propriedade Extendida

        [PersistenceProperty("Nome", DirectionParameter.InputOptional)]
        public string Nome { get; set; }

        [PersistenceProperty("RamoAtivDesc1", DirectionParameter.InputOptional)]
        public string RamoAtivDesc1 { get; set; }

        [PersistenceProperty("RamoAtivDesc2", DirectionParameter.InputOptional)]
        public string RamoAtivDesc2 { get; set; }

        [PersistenceProperty("RamoAtivDesc3", DirectionParameter.InputOptional)]
        public string RamoAtivDesc3 { get; set; }

        [PersistenceProperty("RamoAtivDesc4", DirectionParameter.InputOptional)]
        public string RamoAtivDesc4 { get; set; }

        [PersistenceProperty("RamoAtivDescOrig1", DirectionParameter.InputOptional)]
        public string RamoAtivDescOrig1 { get; set; }

        [PersistenceProperty("RamoAtivDescOrig2", DirectionParameter.InputOptional)]
        public string RamoAtivDescOrig2 { get; set; }

        [PersistenceProperty("RamoAtivDescOrig3", DirectionParameter.InputOptional)]
        public string RamoAtivDescOrig3 { get; set; }

        [PersistenceProperty("RamoAtivDescOrig4", DirectionParameter.InputOptional)]
        public string RamoAtivDescOrig4 { get; set; }

        [PersistenceProperty("DES_TIP_COMPL", DirectionParameter.InputOptional)]
        public string Complemento { get; set; }

        [PersistenceProperty("SIGLA_DISTRT", DirectionParameter.InputOptional)]
        public string SiglaDistrito { get; set; }

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
        /// Exibe Campos tipo logradouro, nome logradouro, e numero concatenados.
        /// </summary>
        public string Endereco
        {
            get
            {
                return this.TipoLogradouro + " " + this.NomeLogradouro + ", " + this.NumeroImovel;
            }
        }

        /// <summary>
        /// Exibe tipo complemento concatenado a inforcomplemento.
        /// </summary>
        public string ComplementoConcat
        {
            get
            {
                List<ItemCombo> items = ListTipoComplemento.getList();
                return items.First(t => t.Value.ToString() == this.TipoComplemento).Description.ToString() + ": " + this.InformacaoComplementar;
            }
        }

        /// <summary>
        /// Quantidade de ponto de serviço por matricula
        /// </summary>
        [PersistenceProperty("QtdPS", DirectionParameter.InputOptional)]
        public string QtdPS { get; set; }

        [PersistenceProperty("Fabricante", DirectionParameter.InputOptional)]
        public string Fabricante1
        {
            get
            {
                string nome = NumeroMedidorAlter.Substring(0, 1);
                List<ItemCombo> lst = ListFabricante.getList();

                ItemCombo vlr = lst.Find(delegate(ItemCombo item)
                {
                    return item.Value.ToString() == nome;
                });

                return vlr.Description.ToString();
            }
        }

        [PersistenceProperty("Capacidade", DirectionParameter.InputOptional)]
        public string Capacidade1
        {
            get
            {
                string nome = NumeroMedidorAlter.Substring(3, 1);
                List<ItemCombo> lst = ListCapacidade.getList();

                ItemCombo vlr = lst.Find(delegate(ItemCombo item)
                {
                    return item.Value.ToString() == nome;
                });

                return vlr.Description.ToString();
            }
        }

        [PersistenceProperty("Fabricante2", DirectionParameter.InputOptional)]
        public string Fabricante2
        {
            get
            {
                string nome = NumeroMedidor2.Substring(0, 1);
                List<ItemCombo> lst = ListFabricante.getList();

                ItemCombo vlr = lst.Find(delegate(ItemCombo item)
                {
                    return item.Value.ToString() == nome;
                });

                return vlr.Description.ToString();
            }
        }

        [PersistenceProperty("Capacidade2", DirectionParameter.InputOptional)]
        public string Capacidade2
        {
            get
            {
                string nome = NumeroMedidor2.Substring(3, 1);
                List<ItemCombo> lst = ListCapacidade.getList();

                ItemCombo vlr = lst.Find(delegate(ItemCombo item)
                {
                    return item.Value.ToString() == nome;
                });

                return vlr.Description.ToString();
            }
        }

        public string PiscinaText
        {
            get
            {
                return Piscina == "0" ? "" :
                    Piscina == "1" ? "Sim" :
                    Piscina == "2" ? "Não" : "";
            }
        }

        public string ReservatorioText
        {
            get
            {
                return Reservatorio == "0" ? "" :
                    Reservatorio == "1" ? "Sim" :
                    Reservatorio == "2" ? "Não" : "";
            }
        }

        public string CondicaoImovelText
        {
            get
            {
                return ListCondicaoImovel.getList().First(t => (int)t.Value == this.CondicaoImovel).Description.ToString();
            }
        }

        public string FonteAlternativaText
        {
            get
            {
                if (this.FonteAlternativa == null)
                    return "";
                return ListFonteAlternativa.getList().First(t => t.Value.ToString() == this.FonteAlternativa).Description.ToString();
            }
        }

        public string FonteAlternativaAlterText
        {
            get
            {
                if (this.FonteAlternativaAlter == null)
                    return "";
                return ListFonteAlternativa.getList().First(t => t.Value.ToString() == this.FonteAlternativaAlter).Description.ToString();
            }
        }

        public string SituacaoImovelText
        {
            get
            {
                return TiposSituacaoImovel.getList().First(t => t.Value.ToString() == this.SituacaoImovel).Description.ToString();
            }
        }

        public string SituacaoPontoServicoText
        {
            get
            {
                return ListSitPontServ.getList().First(t => t.Value.ToString() == this.SituacaoPontoServico).Description.ToString();
            }
        }

        public string LocalizacaoPadraoText
        {
            get
            {
                return ListLocalPadrao.getList().First(t => (int)t.Value == this.LocalizacaoPadrao).Description.ToString();
            }
        }

        public string TipoPadraoText
        {
            get
            {
                return ListTipoPadrao.getList().First(t => (int)t.Value == this.TipoPadrao).Description.ToString();
            }
        }


        #endregion

        #region Check alterações em imóvel

        /// <summary>
        /// Verifica se houve alterações em imoveis
        /// </summary>
        public bool checkAltImovel
        {
            get
            {
                if (NumeroImovel != NumeroImovelAlter) return true;
                if (TipoComplemento != TipoComplementoAlter) return true;
                if (InformacaoComplementar != InformacaoComplementarAlter) return true;
                if (CondicaoImovel != CondicaoImovelAlter) return true;
                if (PrevisaoFimObra != null) return true;

                return false;
            }
        }

        public bool checkAltEconomia
        {
            get
            {
                if (QtdeEconomiasComercial != QtdeEconomiasComercialAlter) return true;
                if (QtdeEconomiasIndustrial != QtdeEconomiasIndustrialAlter) return true;
                if (QtdeEconomiasPublica != QtdeEconomiasPublicaAlter) return true;
                if (QtdeEconomiasResidencial != QtdeEconomiasResidencialAlter) return true;
                if (RamoAtividade1 != RamoAtividade1Alter) return true;
                if (RamoAtividade2 != RamoAtividade2Alter) return true;
                if (RamoAtividade3 != RamoAtividade3Alter) return true;
                if (RamoAtividade4 != RamoAtividade4Alter) return true;

                return false;
            }
        }

        public bool checkAltCaracteristica
        {
            get
            {
                if (FonteAlternativa != FonteAlternativaAlter) return true;
                if (Reservatorio != ReservatorioAlter) return true;
                if (Piscina != PiscinaAlter) return true;
                if (SituacaoImovel != SituacaoImovelAlter) return true;
                return false;
            }
        }

        #endregion
    }
}
