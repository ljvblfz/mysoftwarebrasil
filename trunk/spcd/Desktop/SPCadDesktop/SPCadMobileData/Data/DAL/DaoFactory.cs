using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileData.Data.Model;
using GDA;

namespace SPCadMobileData.Data.DAL
{
    public class DaoFactory
    {
        public static Dao<Funcionario> getFuncionario()
        {
            return new Dao<Funcionario>();
        }

        public static Dao<Cadastro> getCadastro()
        {
            return new Dao<Cadastro>();
        }
      
        public static Dao<Distrito> getDistrito()
        {
            return new Dao<Distrito>();
        }
        
        public static Dao<Rota> getRota()
        {
            return new Dao<Rota>();
        }

        public static Dao<RamoAtividade> getRamoAtividade()
        {
            return new Dao<RamoAtividade>();
        }

        public static Dao<FonteAlternativa> getFonteAlternativa()
        {
            return new Dao<FonteAlternativa>();
        }

        public static Dao<CondicaoImovel> getCondicaoImovel()
        {
            return new Dao<CondicaoImovel>();
        }

        public static Dao<Ocorrencia> getOcorrencia()
        {
            return new Dao<Ocorrencia>();
        }

        public static Dao<Foto> getFoto()
        {
            return new Dao<Foto>();
        }

        public static Dao<TipoComplemento> getTipoComplemento()
        {
            return new Dao<TipoComplemento>();
        }

        public static Dao<LocalizacaoPadrao> getLocalizacaoPadrao()
        {
            return new Dao<LocalizacaoPadrao>();
        }

        public static Dao<TipoPadrao> getTipoPadrao()
        {
            return new Dao<TipoPadrao>();
        }

        public static Dao<HistoricoConsumo> getHistoricoConsumo()
        {
            return new Dao<HistoricoConsumo>();
        }
    }
}
