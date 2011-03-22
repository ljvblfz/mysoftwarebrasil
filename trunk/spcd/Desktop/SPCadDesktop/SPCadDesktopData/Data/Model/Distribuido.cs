using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDA;
using SPCadDesktopData.Data;

namespace SPCadDesktopData.Data.Model
{
    public class Distribuido : IDistribuicao
    {
        [PersistenceProperty("COD_DISTRT", DirectionParameter.InputOptional)]
        public int Distrito { get; set; }

        [PersistenceProperty("NUM_SETOR", DirectionParameter.InputOptional)]
        public int Setor { get; set; }

        [PersistenceProperty("COD_ROTA", DirectionParameter.InputOptional)]
        public int Rota { get; set; }

        [PersistenceProperty("QT_PS", DirectionParameter.InputOptional)]
        public int QtPontoServico { get; set; }

        [PersistenceProperty("QT_EXECUTADO", DirectionParameter.InputOptional)]
        public int QtExecutado { get; set; }

        [PersistenceProperty("QT_DISTRIBUICAO", DirectionParameter.InputOptional)]
        public int QtDistribuicao { get; set; }

        #region IDistribuicao Members

        public StatusDistribuicoes StatusDistribuicoes
        {
            get
            {
                if (QtDistribuicao > 0 && QtPontoServico == QtExecutado)
                    return StatusDistribuicoes.ExecutadoTodos;
                if (QtDistribuicao == 0)
                    return StatusDistribuicoes.NaoDistribuido;
                else
                {
                    if (QtExecutado > 0 && QtExecutado < QtPontoServico)
                        return StatusDistribuicoes.ExecutadoParcial;
                    else
                        return StatusDistribuicoes.NaoExecutado;
                }
            }
        }

        DistribuicaoEnum IDistribuicao.StatusDistribuicao
        {
            get
            {
                DistribuicaoEnum dst = DistribuicaoEnum.NaoDistribuido;
                switch (StatusDistribuicoes)
                {
                    case StatusDistribuicoes.NaoDistribuido: dst = DistribuicaoEnum.NaoDistribuido;
                        break;
                    case StatusDistribuicoes.ExecutadoTodos: dst = DistribuicaoEnum.Concluido;
                        break;
                    case StatusDistribuicoes.ExecutadoParcial:
                    case StatusDistribuicoes.NaoExecutado: dst = DistribuicaoEnum.Pendente;
                        break;
                }
                return dst;
            }
        }

        public string StatusDistribuicaoString
        {
            get { return ""; }
        }

        public bool Selecao
        {
            get { return false; }
            set { }
        }

        #endregion



    }
}
