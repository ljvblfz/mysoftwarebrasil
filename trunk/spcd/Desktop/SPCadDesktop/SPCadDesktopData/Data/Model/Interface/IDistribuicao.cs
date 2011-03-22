using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SPCadDesktopData.Data;

namespace SPCadDesktopData.Data.Model
{
    public interface IDistribuicao
    {

        StatusDistribuicoes StatusDistribuicoes { get; }

        DistribuicaoEnum StatusDistribuicao { get; }

        string StatusDistribuicaoString { get; }

        bool Selecao { get; set; }
    }
}
