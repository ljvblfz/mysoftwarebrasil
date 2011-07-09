
using System.Globalization;
using System.Web;

namespace Infrastructure
{
    /// <summary>
    /// Globaliza expressões
    /// </summary>
    public static class Globalizator
    {
        /// <summary>
        /// Localiza um texto para o idioma em execução da aplicação
        /// </summary>
        /// <param name="text">ID da mensagem a ser globalizada</param>
        /// <returns>String com o texto globalizado</returns>
        public static string Localize(string text)
        {
            string cacheKey = string.Format(CultureInfo.InvariantCulture, "expression_for_{0}", text);

            string expression = "E_" + text;

            HttpCookie cookie = HttpContext.Current.Request.Cookies["Ticket"];

            return expression;
        }

        public static string AnuncioanucioProficionalRequired
        {
            get
            {
                return Localize("anucioProficional é obrigatório");
            }
        }

        public static string AnuncioanuncioTextoStringLength
        {
            get
            {
                return Localize("O campo anuncioTexto aceita no máximo 2147483647 caracteres.");
            }
        }

        public static string AnuncioanuncioTextoRequired
        {
            get
            {
                return Localize("anuncioTexto é obrigatório");
            }
        }

        public static string AnuncioanuncioTituloStringLength
        {
            get
            {
                return Localize("O campo anuncioTitulo aceita no máximo 255 caracteres.");
            }
        }

        public static string AnuncioanuncioTituloRequired
        {
            get
            {
                return Localize("anuncioTitulo é obrigatório");
            }
        }

        public static string AnuncioanuncioValorHoraRequired
        {
            get
            {
                return Localize("anuncioValorHora é obrigatório");
            }
        }

        public static string AnunciomembroIdRequired
        {
            get
            {
                return Localize("membroId é obrigatório");
            }
        }

        public static string CidadeestadoIdRequired
        {
            get
            {
                return Localize("estadoId é obrigatório");
            }
        }

        public static string ComunidadecomunidadeDataCreateRequired
        {
            get
            {
                return Localize("comunidadeDataCreate é obrigatório");
            }
        }

        public static string ComunidadecomunidadeDescricaoStringLength
        {
            get
            {
                return Localize("O campo comunidadeDescricao aceita no máximo 2147483647 caracteres.");
            }
        }

        public static string ComunidadecomunidadeDescricaoRequired
        {
            get
            {
                return Localize("comunidadeDescricao é obrigatório");
            }
        }

        public static string ComunidadecomunidadeNameStringLength
        {
            get
            {
                return Localize("O campo comunidadeName aceita no máximo 255 caracteres.");
            }
        }

        public static string ComunidadecomunidadeNameRequired
        {
            get
            {
                return Localize("comunidadeName é obrigatório");
            }
        }

        public static string ComunidadeMembrocomunidadeIdRequired
        {
            get
            {
                return Localize("comunidadeId é obrigatório");
            }
        }

        public static string ComunidadeMembromembroIdRequired
        {
            get
            {
                return Localize("membroId é obrigatório");
            }
        }

        public static string EncontroencontroDataRequired
        {
            get
            {
                return Localize("encontroData é obrigatório");
            }
        }

        public static string EncontroencontroDescricaoStringLength
        {
            get
            {
                return Localize("O campo encontroDescricao aceita no máximo 2147483647 caracteres.");
            }
        }

        public static string EncontroencontroDescricaoRequired
        {
            get
            {
                return Localize("encontroDescricao é obrigatório");
            }
        }

        public static string EncontroencontroQuantPessoasRequired
        {
            get
            {
                return Localize("encontroQuantPessoas é obrigatório");
            }
        }

        public static string EncontroencontroTituloStringLength
        {
            get
            {
                return Localize("O campo encontroTitulo aceita no máximo 50 caracteres.");
            }
        }

        public static string EncontroencontroTituloRequired
        {
            get
            {
                return Localize("encontroTitulo é obrigatório");
            }
        }

        public static string EncontroenderecoIdRequired
        {
            get
            {
                return Localize("enderecoId é obrigatório");
            }
        }

        public static string EncontroMembroencontroIdRequired
        {
            get
            {
                return Localize("encontroId é obrigatório");
            }
        }

        public static string EncontroMembromembroIdRequired
        {
            get
            {
                return Localize("membroId é obrigatório");
            }
        }

        public static string EnderecoCEPStringLength
        {
            get
            {
                return Localize("O campo CEP aceita no máximo 20 caracteres.");
            }
        }
 
        public static string EnderecocidadeIdRequired
        {
            get
            {
                return Localize("cidadeId é obrigatório");
            }
        }

        public static string EstadoestadoNameStringLength
        {
            get
            {
                return Localize("O campo estadoName aceita no máximo 255 caracteres.");
            }
        }

        public static string EstadoestadoNameRequired
        {
            get
            {
                return Localize("estadoName é obrigatório");
            }
        }

        public static string EstadoestadoSiglaStringLength
        {
            get
            {
                return Localize("O campo estadoSigla aceita no máximo 2 caracteres.");
            }
        }

        public static string EstadoestadoSiglaRequired
        {
            get
            {
                return Localize("estadoSigla é obrigatório");
            }
        }

        public static string EstadopaisIdRequired
        {
            get
            {
                return Localize("paisId é obrigatório");
            }
        }

        public static string EstadoCivilestadoCivilNameStringLength
        {
            get
            {
                return Localize("O campo estadoCivilName aceita no máximo 255 caracteres.");
            }
        }

        public static string EstadoCivilestadoCivilNameRequired
        {
            get
            {
                return Localize("estadoCivilName é obrigatório");
            }
        }

        public static string EtiniaetiniaNameStringLength
        {
            get
            {
                return Localize("O campo etiniaName aceita no máximo 255 caracteres.");
            }
        }

        public static string EtiniaetiniaNameRequired
        {
            get
            {
                return Localize("etiniaName é obrigatório");
            }
        }

        public static string FotosfotoPathStringLength
        {
            get
            {
                return Localize("O campo fotoPath aceita no máximo 255 caracteres.");
            }
        }

        public static string FotosfotoPathRequired
        {
            get
            {
                return Localize("fotoPath é obrigatório");
            }
        }

        public static string FotosmembroIdRequired
        {
            get
            {
                return Localize("membroId é obrigatório");
            }
        }

        public static string inretessePessoainterresseIdRequired
        {
            get
            {
                return Localize("interresseId é obrigatório");
            }
        }

        public static string inretessePessoapessoaIdRequired
        {
            get
            {
                return Localize("pessoaId é obrigatório");
            }
        }

        public static string InteressesinterresseNameStringLength
        {
            get
            {
                return Localize("O campo interresseName aceita no máximo 255 caracteres.");
            }
        }

        public static string InteressesinterresseNameRequired
        {
            get
            {
                return Localize("interresseName é obrigatório");
            }
        }

        public static string MembromembroNickNameRequired
        {
            get
            {
                return Localize("membroNickName é obrigatório");
            }
        }

        public static string MembromembroSenhaStringLength
        {
            get
            {
                return Localize("O campo membroSenha aceita no máximo 50 caracteres.");
            }
        }

        public static string MembromembroSenhaRequired
        {
            get
            {
                return Localize("membroSenha é obrigatório");
            }
        }

        public static string MembromembroUltimoLoginRequired
        {
            get
            {
                return Localize("membroUltimoLogin é obrigatório");
            }
        }

        public static string MembropessoaIdRequired
        {
            get
            {
                return Localize("pessoaId é obrigatório");
            }
        }

        public static string MembroAmigoamigoIdRequired
        {
            get
            {
                return Localize("amigoId é obrigatório");
            }
        }

        public static string MembroAmigomembroIdRequired
        {
            get
            {
                return Localize("membroId é obrigatório");
            }
        }

        public static string MembroFavoritofavoritosIdRequired
        {
            get
            {
                return Localize("favoritosId é obrigatório");
            }
        }

        public static string MembroFavoritomembroIdRequired
        {
            get
            {
                return Localize("membroId é obrigatório");
            }
        }

        public static string MenuMenuIdPaiRequired
        {
            get
            {
                return Localize("MenuIdPai é obrigatório");
            }
        }

        public static string MenuMenuNameStringLength
        {
            get
            {
                return Localize("O campo MenuName aceita no máximo 255 caracteres.");
            }
        }

        public static string MenuMenuNameRequired
        {
            get
            {
                return Localize("MenuName é obrigatório");
            }
        }

        public static string MenuMenuOrdemRequired
        {
            get
            {
                return Localize("MenuOrdem é obrigatório");
            }
        }

        public static string MenuMenuPathStringLength
        {
            get
            {
                return Localize("O campo MenuPath aceita no máximo 255 caracteres.");
            }
        }

        public static string MenuMenuPathRequired
        {
            get
            {
                return Localize("MenuPath é obrigatório");
            }
        }

        public static string MenuRoleMenuIdRequired
        {
            get
            {
                return Localize("MenuId é obrigatório");
            }
        }

        public static string MenuRoleRoleIdRequired
        {
            get
            {
                return Localize("RoleId é obrigatório");
            }
        }

        public static string OlhosolhosNameStringLength
        {
            get
            {
                return Localize("O campo olhosName aceita no máximo 255 caracteres.");
            }
        }

        public static string OlhosolhosNameRequired
        {
            get
            {
                return Localize("olhosName é obrigatório");
            }
        }

        public static string PaispaisNameStringLength
        {
            get
            {
                return Localize("O campo paisName aceita no máximo 255 caracteres.");
            }
        }

        public static string PaispaisNameRequired
        {
            get
            {
                return Localize("paisName é obrigatório");
            }
        }

        public static string PerfilperfilAlturaRequired
        {
            get
            {
                return Localize("perfilAltura é obrigatório");
            }
        }

        public static string PerfilperfilBebeRequired
        {
            get
            {
                return Localize("perfilBebe é obrigatório");
            }
        }

        public static string PerfilperfilFumanteRequired
        {
            get
            {
                return Localize("perfilFumante é obrigatório");
            }
        }

        public static string PerfilperfilPesoRequired
        {
            get
            {
                return Localize("perfilPeso é obrigatório");
            }
        }

        public static string PerfilpessoaFantasiasSexuaisStringLength
        {
            get
            {
                return Localize("O campo pessoaFantasiasSexuais aceita no máximo 2147483647 caracteres.");
            }
        }
 
        public static string PerfilpessoaInteresseConhecerStringLength
        {
            get
            {
                return Localize("O campo pessoaInteresseConhecer aceita no máximo 2147483647 caracteres.");
            }
        }

        public static string PerfilpessoaOutrosInteressesStringLength
        {
            get
            {
                return Localize("O campo pessoaOutrosInteresses aceita no máximo 2147483647 caracteres.");
            }
        }

        public static string PessoacabelosIdRequired
        {
            get
            {
                return Localize("cabelosId é obrigatório");
            }
        }

        public static string PessoaenderecoIdRequired
        {
            get
            {
                return Localize("enderecoId é obrigatório");
            }
        }

        public static string PessoaestadoCivilIdRequired
        {
            get
            {
                return Localize("estadoCivilId é obrigatório");
            }
        }

        public static string PessoaetiniaIdRequired
        {
            get
            {
                return Localize("etiniaId é obrigatório");
            }
        }

        public static string PessoaolhosIdRequired
        {
            get
            {
                return Localize("olhosId é obrigatório");
            }
        }

        public static string PessoaperfilIdRequired
        {
            get
            {
                return Localize("perfilId é obrigatório");
            }
        }

        public static string PessoapessoaEmailStringLength
        {
            get
            {
                return Localize("O campo pessoaEmail aceita no máximo 255 caracteres.");
            }
        }

        public static string PessoapessoaEmailRequired
        {
            get
            {
                return Localize("pessoaEmail é obrigatório");
            }
        }

        public static string PessoapessoaMSNStringLength
        {
            get
            {
                return Localize("O campo pessoaMSN aceita no máximo 255 caracteres.");
            }
        }

        public static string PessoapessoaNameStringLength
        {
            get
            {
                return Localize("O campo pessoaName aceita no máximo 255 caracteres.");
            }
        }

        public static string PessoapessoaNameRequired
        {
            get
            {
                return Localize("pessoaName é obrigatório");
            }
        }

        public static string PessoapessoaNascimentoRequired
        {
            get
            {
                return Localize("pessoaNascimento é obrigatório");
            }
        }

        public static string PessoapessoaProfissaoStringLength
        {
            get
            {
                return Localize("O campo pessoaProfissao aceita no máximo 255 caracteres.");
            }
        }

        public static string PessoapessoaProfissaoRequired
        {
            get
            {
                return Localize("pessoaProfissao é obrigatório");
            }
        }

        public static string PessoasexoIdRequired
        {
            get
            {
                return Localize("sexoId é obrigatório");
            }
        }

        public static string PostfotoIdRequired
        {
            get
            {
                return Localize("fotoId é obrigatório");
            }
        }

        public static string PostmembroIdRequired
        {
            get
            {
                return Localize("membroId é obrigatório");
            }
        }

        public static string PostpostTextStringLength
        {
            get
            {
                return Localize("O campo postText aceita no máximo 2147483647 caracteres.");
            }
        }

        public static string PostpostTextRequired
        {
            get
            {
                return Localize("postText é obrigatório");
            }
        }

        public static string RoleRoleNameStringLength
        {
            get
            {
                return Localize("O campo RoleName aceita no máximo 255 caracteres.");
            }
        }

        public static string RoleRoleNameRequired
        {
            get
            {
                return Localize("RoleName é obrigatório");
            }
        }

        public static string RoleMembromembroIdRequired
        {
            get
            {
                return Localize("membroId é obrigatório");
            }
        }

        public static string RoleMembroRoleIdRequired
        {
            get
            {
                return Localize("RoleId é obrigatório");
            }
        }

        public static string SexosexoNameStringLength
        {
            get
            {
                return Localize("O campo sexoName aceita no máximo 255 caracteres.");
            }
        }

        public static string SexosexoNameRequired
        {
            get
            {
                return Localize("sexoName é obrigatório");
            }
        }

        public static string MembromembroNickNameStringLength
        {
            get
            {
                return Localize("MembromembroNickName é obrigatório");
            }
        }

    }
}
