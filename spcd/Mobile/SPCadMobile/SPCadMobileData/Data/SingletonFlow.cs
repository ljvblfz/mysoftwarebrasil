using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileData.Data.BFL;
using SPCadMobileData.Data.Model;

namespace SPCadMobileData.Data
{
    public static class SingletonFlow
    {
        public static readonly FuncionarioFlow funcionarioFlow = new FuncionarioFlow();
        public static readonly DistritoFlow distritoFlow = new DistritoFlow();
        public static readonly RotaFlow rotaFlow = new RotaFlow();
        public static readonly CadastroFlow cadastroFlow = new CadastroFlow();
        public static readonly RamoAtividadeFlow ramoAtividadeFlow = new RamoAtividadeFlow();
        public static readonly FonteAlternativaFlow fonteAlternativaFlow = new FonteAlternativaFlow();
        public static readonly CondicaoImovelFlow condicaoImovelFlow = new CondicaoImovelFlow();
        public static readonly OcorrenciaFlow ocorrenciaFlow = new OcorrenciaFlow();
        public static readonly FotoFlow fotoFlow = new FotoFlow();
        public static readonly TipoComplementoFlow tipoComplementoFlow = new TipoComplementoFlow();
        public static readonly LocalizacaoPadraoFlow localizacaoPadraoFlow = new LocalizacaoPadraoFlow();
        public static readonly TipoPadraoFlow tipoPadraoFlow = new TipoPadraoFlow();
        public static readonly HistoricoConsumoFlow historicoConsumoFlow = new HistoricoConsumoFlow();
    }
}
