using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CommonHelpMobile;
using SPCadMobileData.Data.Model;

namespace SPCadMobileData.Data
{
    /// <summary>
    /// valores possíveis para o status das abas da interface frmDadosImovel:
    /// NEX=Não executado, CNF=Confirmado, ALT=Alterado.
    /// </summary>
    public enum FlgAba
    {
        NEX = '0', CNF = '1', ALT = '2'//NEX=Não executado, CNF=Confirmado, ALT=Alterado.
    }

    public enum FlgLeitura
    {
        Obrigatoria = 0, Opcional = 1, Proibida = 2
    }

    public static class SituacaoCombo
    {
        public static List<ItemCombo> getList()
        {
            List<ItemCombo> lst = new List<ItemCombo>();

            lst.Add(new ItemCombo("TD", "Todos"));
            lst.Add(new ItemCombo("IE", "Imp execucão"));
            lst.Add(new ItemCombo("EX", "Executado"));
            lst.Add(new ItemCombo("NV", "Não executado"));

            return lst;
        }
    }

    public static class SituacaoBanco
    {
        public static List<ItemCombo> getList()
        {
            List<ItemCombo> lst = new List<ItemCombo>();

            lst.Add(new ItemCombo(2, "Imp de execucão"));
            lst.Add(new ItemCombo(1, "Executado"));
            lst.Add(new ItemCombo(0, "Não executado"));

            return lst;
        }
    }

    public static class ListCriterioApuracao
    {
        public static List<ItemCombo> getList()
        {
            List<ItemCombo> lst = new List<ItemCombo>();

            lst.Add(new ItemCombo(1, "REAL"));
            lst.Add(new ItemCombo(2, "REAL 1A.LEI/INST-ULT.LEI/RESID"));
            lst.Add(new ItemCombo(3, "REAL HID.ATUAL RESIDUO ANTERIO"));
            lst.Add(new ItemCombo(4, "REAL-QUE NAO COMPOE MEDIA"));
            lst.Add(new ItemCombo(5, "MEDIO ATE 06 MESES"));
            lst.Add(new ItemCombo(6, "MEDIO ATE 12 MESES"));
            lst.Add(new ItemCombo(7, "MEDIO NOVO HIDR.PER.>7DIAS"));
            lst.Add(new ItemCombo(8, "VOLUME FIXADO"));
            lst.Add(new ItemCombo(9, "VOLUME ESTIMADO"));
            lst.Add(new ItemCombo(10, "PS NAO HIDROMETRADO"));
            lst.Add(new ItemCombo(11, "VOLUME MEDIO LIMITE INFERIOR"));
            lst.Add(new ItemCombo(12, "FATURAMENTO MULTIMENSAL"));
            lst.Add(new ItemCombo(13, "VOLUME DEVOLUCAO MM"));
            lst.Add(new ItemCombo(14, "ANEL LIMITE MAXIMO VOL. MEDIDO"));
            lst.Add(new ItemCombo(15, "LEITURA ATUAL < ANTERIOR"));
            lst.Add(new ItemCombo(17, "FONTE ALTERN HIDROMETRADA-FARE"));
            lst.Add(new ItemCombo(18, "APURACAO NAO IDENTIFICADA"));
            lst.Add(new ItemCombo(19, "VOL. C/INDíCIO INCONSISTENCIA"));
            lst.Add(new ItemCombo(20, "VOL. NOVO HID+RESID ANT./MEDIA"));

            return lst;
        }
    }

    public static class ListExpectativaConsumo
    {
        public static List<ItemCombo> getList()
        {
            List<ItemCombo> lst = new List<ItemCombo>();

            lst.Add(new ItemCombo("0", ""));
            lst.Add(new ItemCombo("1", "Baixo Consumo"));
            lst.Add(new ItemCombo("2", "Potencial de consumo"));

            return lst;
        }
    }

    public static class ListResposta
    {
        /// <summary>
        /// recupera valores sim, não e vazio.
        /// </summary>
        /// <returns></returns>
        public static List<ItemCombo> getList()
        {
            List<ItemCombo> lst = new List<ItemCombo>();

            lst.Add(new ItemCombo("0", ""));
            lst.Add(new ItemCombo("1", "Sim"));
            lst.Add(new ItemCombo("2", "Não"));

            return lst;
        }

        /// <summary>
        /// Recupera apenas dois valores sim e não.
        /// </summary>
        /// <returns></returns>
        public static List<ItemCombo> getListSN()
        {
            List<ItemCombo> lst = new List<ItemCombo>();

            lst.Add(new ItemCombo("1", "Sim")); 
            lst.Add(new ItemCombo("2", "Não"));           

            return lst;
        }
    }


    public static class ListOcorrcImped
    {
        private static List<ItemCombo> listItemCombo = new List<ItemCombo>();
        /// <summary>
        /// retorna uma lista no formato itemCombo
        /// </summary>
        /// <returns></returns>
        /// 
        public static List<ItemCombo> getList()
        {
            try
            {
                listItemCombo.Clear();

                listItemCombo.Add(new ItemCombo("S", "Selecione o Impedimento"));

                List<Ocorrencia> listModel = SingletonFlow.ocorrenciaFlow.getListOcor();

                foreach (Ocorrencia oc in listModel)
                {
                    string cod = oc.Id.ToString().Trim();
                    if (oc.ImpedimentoBool)
                    {
                        listItemCombo.Add(new ItemCombo(cod, oc.Descricao));
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return listItemCombo;
        }
    }




    #region enumerações para interface frmDadosImovel

    public static class TipoAtividades
    {
        public static List<ItemCombo> GetList()
        {
            List<ItemCombo> lista = new List<ItemCombo>();
            lista.Add(new ItemCombo("R", "Residencial"));
            lista.Add(new ItemCombo("C", "Comercial"));
            lista.Add(new ItemCombo("I", "Industrial"));
            lista.Add(new ItemCombo("P", "Público"));

            return lista;
        }
    }

    public static class TiposSituacaoImovel
    {
        public static List<ItemCombo> GetList()
        {
            List<ItemCombo> lista = new List<ItemCombo>();
            lista.Add(new ItemCombo("R", "Real de Água"));
            lista.Add(new ItemCombo("F", "Factível de Água"));
            lista.Add(new ItemCombo("P", "Potencial de Água"));

            return lista;
        }
    }

    public static class ListFonteAlternativa
    {
        private static List<ItemCombo> lstFontAlt = new List<ItemCombo>();
        /// <summary>
        /// retorna uma lista no formato itemCombo(Value = id fonte alternativa, Description = Descrição fonte alternativa)
        /// </summary>
        /// <returns></returns>
        /// 
        public static List<ItemCombo> getList()
        {
            try
            {
                lstFontAlt.Clear();

                List<FonteAlternativa> fontalt = SingletonFlow.fonteAlternativaFlow.getListFontAltern();

                foreach (FonteAlternativa falt in fontalt)
                {
                    // Alterado tamanho da descrição
                    if (falt.Id == "O")
                        falt.Descricao = "ABAST P/OUTRA LIGACAO";

                    lstFontAlt.Add(new ItemCombo(falt.Id, falt.Descricao));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return lstFontAlt;
        }
    }

    public static class ListTipoComplemento
    {
        private static List<ItemCombo> tipoComplemento = new List<ItemCombo>();
        /// <summary>
        /// retorna uma lista no formato itemCombo(Value = id TipoComplemento, Description = Descrição TipoComplemento)
        /// </summary>
        /// <returns></returns>
        /// 
        public static List<ItemCombo> getList()
        {
            try
            {
                tipoComplemento.Clear();

                List<TipoComplemento> tipoCom = SingletonFlow.tipoComplementoFlow.getListTipoCompl();

                //inicia o primeiro item da lista com item em branco.
                tipoComplemento.Add(new ItemCombo("", ""));

                foreach (TipoComplemento tip in tipoCom)
                {
                    tipoComplemento.Add(new ItemCombo(tip.Tipo, tip.Descricao));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return tipoComplemento;
        }
    }

    public static class ListCondicaoImovel
    {
        private static List<ItemCombo> condicaoImovel = new List<ItemCombo>();
        /// <summary>
        /// retorna uma lista no formato itemCombo(Value = id condicao imovel, Description = Descrição condicao imovel)
        /// </summary>
        /// <returns></returns>
        /// 
        public static List<ItemCombo> getList()
        {
            try
            {
                condicaoImovel.Clear();

                List<CondicaoImovel> condImov = SingletonFlow.condicaoImovelFlow.getListCondicaoImovel();

                foreach (CondicaoImovel cond in condImov)
                {
                    condicaoImovel.Add(new ItemCombo(cond.Id, cond.Descricao));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return condicaoImovel;
        }
    }

    #endregion


    #region enumerações para interface frmPontoServHidrometro

    /// <summary>
    /// Situação ponto de serviço
    /// </summary>
    public static class ListSitPontServ
    {
        /// <summary>
        /// Enumeracao
        /// </summary>
        /// <returns></returns>
        public static List<ItemCombo> getList()
        {
            List<ItemCombo> lst = new List<ItemCombo>();

            lst.Add(new ItemCombo("A", "ATIVO"));
            lst.Add(new ItemCombo("B", "BLOQUEADO"));
            lst.Add(new ItemCombo("H", "TAMPONADO  SEM RETIRADA HIDROM"));
            lst.Add(new ItemCombo("S", "SUPRIMIDO"));
            lst.Add(new ItemCombo("T", "TAMPONADO"));

            return lst;
        }
    }

    /// <summary>
    /// Capacidade
    /// </summary>
    public static class ListCapacidade
    {
        /// <summary>
        /// Enumeracao
        /// </summary>
        /// <returns></returns>
        public static List<ItemCombo> getList()
        {
            List<ItemCombo> lst = new List<ItemCombo>();

            lst.Add(new ItemCombo("A", "3"));
            lst.Add(new ItemCombo("B", "5"));
            lst.Add(new ItemCombo("C", "7"));
            lst.Add(new ItemCombo("E", "20"));
            lst.Add(new ItemCombo("Y", "1,5"));

            return lst;
        }
    }

    /// <summary>
    /// Fabricante
    /// </summary>
    public static class ListFabricante
    {
        /// <summary>
        /// Enumeracao
        /// </summary>
        /// <returns></returns>
        public static List<ItemCombo> getList()
        {
            List<ItemCombo> lst = new List<ItemCombo>();

            lst.Add(new ItemCombo("A", "AAB"));
            lst.Add(new ItemCombo("D", "DANFOSS OU SIEMENS"));
            lst.Add(new ItemCombo("E", "ENDRESS + HAUSER"));
            lst.Add(new ItemCombo("F", "FISHER, ROSEMOUNT OU EMERSON"));
            lst.Add(new ItemCombo("T", "AICHI TOKEI"));

            return lst;
        }
    }

    public static class ListLocalPadrao
    {
        private static List<ItemCombo> localPadrao = new List<ItemCombo>();
        /// <summary>
        /// retorna uma lista no formato itemCombo(Value = id LocalizacaoPadrao, Description = Descrição LocalizacaoPadrao)
        /// </summary>
        /// <returns></returns>
        /// 
        public static List<ItemCombo> getList()
        {
            try
            {
                localPadrao.Clear();

                List<LocalizacaoPadrao> localP = SingletonFlow.localizacaoPadraoFlow.getList();

                foreach (LocalizacaoPadrao local in localP)
                {
                    localPadrao.Add(new ItemCombo(local.Id, local.Descricao));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return localPadrao;
        }
    }

    public static class ListTipoPadrao
    {
        private static List<ItemCombo> tipoPadrao = new List<ItemCombo>();
        /// <summary>
        /// retorna uma lista no formato itemCombo(Value = id TipoPadrao, Description = Descrição TipoPadrao)
        /// </summary>
        /// <returns></returns>
        /// 
        public static List<ItemCombo> getList()
        {
            try
            {
                tipoPadrao.Clear();

                List<TipoPadrao> tipoP = SingletonFlow.tipoPadraoFlow.getList();

                foreach (TipoPadrao tipo in tipoP)
                {
                    // Alterado tamanho da descrição
                    if (tipo.Id == 8)
                        tipo.Descricao = "REG.ESF./CAV. RAMAL";

                    tipoPadrao.Add(new ItemCombo(tipo.Id, tipo.Descricao));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return tipoPadrao;
        }
    }

    public static class ListClasseMetrologica
    {
        public static List<ItemCombo> getList()
        {
            List<ItemCombo> lst = new List<ItemCombo>();

            lst.Add(new ItemCombo("", ""));
            lst.Add(new ItemCombo("A", "A"));
            lst.Add(new ItemCombo("B", "B"));
            lst.Add(new ItemCombo("C", "C"));

            return lst;
        }
    }

    public static class ListDescLogradouro
    {
        public static List<ItemCombo> getList()
        {
            List<ItemCombo> lst = new List<ItemCombo>();

            lst.Add(new ItemCombo("AL", "ALAMEDA"));
            lst.Add(new ItemCombo("AT", "ALTO"));
            lst.Add(new ItemCombo("AV", "AVENIDA"));
            lst.Add(new ItemCombo("BC", "BECO"));
            lst.Add(new ItemCombo("C ", "CHACARA"));
            lst.Add(new ItemCombo("CE", "CENTRO EMPRESARIAL"));
            lst.Add(new ItemCombo("EC", "ESCADARIA"));
            lst.Add(new ItemCombo("EL", "ELEVADO"));
            lst.Add(new ItemCombo("EP", "ESPLANADA"));
            lst.Add(new ItemCombo("ET", "ESTRADA"));
            lst.Add(new ItemCombo("F ", "FAZENDA"));
            lst.Add(new ItemCombo("G ", "GRANJA"));
            lst.Add(new ItemCombo("IL", "ILHA"));
            lst.Add(new ItemCombo("LD", "LADEIRA"));
            lst.Add(new ItemCombo("LG", "LARGO"));
            lst.Add(new ItemCombo("MR", "MORRO"));
            lst.Add(new ItemCombo("PA", "PRAIA"));
            lst.Add(new ItemCombo("PQ", "PARQUE"));
            lst.Add(new ItemCombo("PR", "PRACA"));
            lst.Add(new ItemCombo("PS", "PASSAGEM"));
            lst.Add(new ItemCombo("R ", "RUA"));
            lst.Add(new ItemCombo("RD", "RODOVIA"));
            lst.Add(new ItemCombo("SI", "SITIO"));
            lst.Add(new ItemCombo("T ", "TRAVESSA"));
            lst.Add(new ItemCombo("V ", "VILA"));
            lst.Add(new ItemCombo("VD", "VIADUTO"));
            lst.Add(new ItemCombo("VE", "VIELA"));
            lst.Add(new ItemCombo("VI", "VIA"));
            lst.Add(new ItemCombo("VP", "VIA DE PEDESTRE"));

            return lst;
        }
    }

    #endregion

}
