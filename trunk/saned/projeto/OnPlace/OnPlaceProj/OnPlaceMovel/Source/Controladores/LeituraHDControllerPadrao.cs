using System;
using System.Collections.Generic;
using System.Text;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Forms;

namespace OnPlaceMovel.Source.Controladores {
	public class LeituraHDControllerPadrao: OnPlaceMovel.Source.Controladores.ILeituraHDController {
		#region Atributos e Propriedades
		protected FormLeituraHD _formLeitura;
		private FormDigitosHD _formDigitos;
		private int _numeroDigitosHD;

		protected bool _cancelar;
		public bool Cancelar {
			get { return _cancelar; }
			set { _cancelar = value; }
		}

		protected bool _retida;
		public bool Retida {
			get { return _retida; }
			set { _retida = value; }
		}

		protected OnpMatricula _matricula;
		public virtual OnpMatricula Matricula {
			get { return _matricula; }
			set { _matricula = value; }
		}
		#endregion

		public LeituraHDControllerPadrao() {
		}

		public void FazerLeitura(OnpMatricula matricula, TipoLeitura tipoLeitura, bool mostraTelaDigito) {
			_matricula = matricula;
			_matricula.Movimento.resetLeitura();

			if (matricula.Movimento.Hidrometro.ValNumeroDigitos.HasValue)
				_numeroDigitosHD = matricula.Movimento.Hidrometro.ValNumeroDigitos.Value;

			if (mostraTelaDigito)
				FazerLeituraDigitos();
			else
				_numeroDigitosHD = matricula.Movimento.Hidrometro.ValNumeroDigitos.GetValueOrDefault(4);

			FazerLeituraHidrometro(tipoLeitura);
		}

		public void FazerLeitura(OnpMatricula matricula, TipoLeitura tipoLeitura) {
			FazerLeitura(matricula, tipoLeitura, true);
		}

		#region Metodos publicos
		/// <summary>
		/// Devolve o número de digitos do HD
		/// </summary>
		/// <returns>Número de digitos do HD</returns>
		public virtual int getNumeroDigitosHD() {
			return _numeroDigitosHD;
		}

		/// <summary>
		/// Define o número de digitos do HD
		/// </summary>
		/// <param name="value">Número de digitos do HD</param>
		public virtual void setNumeroDigitosHD(int value) {
			// Se for alterado a quantidade de digitos do hidrometro
			if (value != _matricula.Movimento.Hidrometro.ValNumeroDigitos.Value) {
				// Gera alteração cadastral
				OnpMatriculaAlteracao matriculaAlteracao = new OnpMatriculaAlteracao();
				matriculaAlteracao.SeqMatricula = _matricula.SeqMatricula;
				matriculaAlteracao.SeqItem = 1;
				matriculaAlteracao.IndDadoAlterado = "DG";
				matriculaAlteracao.DesConteudoAnterior = _matricula.Movimento.Hidrometro.ValNumeroDigitos.Value.ToString();
				matriculaAlteracao.DesConteudoNovo = value.ToString();
				matriculaAlteracao.Persist();
			}
			//Define o número de digitos
			_numeroDigitosHD = value;
		}

		/// <summary>
		/// Define o valor da leitura obtida
		/// </summary>
		/// <param name="leitura"></param>
		/// <returns></returns>
		public virtual bool setLeitura(int leitura) {
            _formLeitura.MostraMensagem("Repita a leitura.");
            bool result = _matricula.Movimento.ProcessaLeitura(leitura);

            if (result) {
                _matricula.IndProcessado = "S";
                Retida = ConfigXML.GetClasseAnaliseConta().RetemParaAnalise(_matricula.Movimento);
                //Tem de persistir para que se o coletor for desligado nas proximas 
                //mensagens antes do persist no final, nao perca os dados.
                _matricula.Persist();
            } else {

                // Inicializa
                int consumoMedio  = _matricula.Movimento.ValConsumoMedio.GetValueOrDefault(0);
                int consumoMedido = _matricula.Movimento.calculaConsumoLeitura(leitura, false);

                string tipoVariacao = _matricula.Movimento.verificaVariacaoConsumo(consumoMedio, consumoMedido);

                if (tipoVariacao == "ExcessoConsumo") {
                    _formLeitura.MostraMensagem("Excesso de consumo!");
                } else if (tipoVariacao == "ConsumoAcima") {
                    _formLeitura.MostraMensagem("Consumo acima do normal!");
                } else if (tipoVariacao == "ConsumoRedusido") {
                    _formLeitura.MostraMensagem("Redução no consumo");
                } else if (tipoVariacao == "ConsumoAbaixo") {
                    _formLeitura.MostraMensagem("Consumo abaixo do normal");
				} else if (tipoVariacao != "SemVariar")
                    _formLeitura.MostraMensagem("Repita a leitura.");
            }

			return result;
		}

		/// <summary>
		/// Monta mensagem quando conta retida para analise
		/// </summary>
		/// <returns>Mensagem</returns>
		public virtual string MsgRetidaParaAnalise() {
			string mensagem = "Esta conta ficará retida para análise!";
			string leituraAtual = _matricula.Movimento.ValLeituraReal.ToString();
			string leituraAnterior = _matricula.Movimento.ValLeituraAnterior.ToString();
			double valConsumo = _matricula.Movimento.ValConsumoMedido.GetValueOrDefault(0);
			double valMedia = _matricula.Movimento.ValConsumoMedio.Value;

			return string.Format("{0}\n\nLeitura Atual: {1}\nLeitura Anterior: {2}\nMedia : {3}\nConsumo: {4}\nVariacao: {5}%",
				mensagem, leituraAtual, leituraAnterior, valMedia.ToString(), valConsumo.ToString(),
				ConfigXML.GetClasseAnaliseConta().VariacaoConsumo(_matricula.Movimento).ToString());
		}


		public void Dispose() {
			if (_formLeitura != null)
				_formLeitura.Dispose();
			if (_formDigitos != null)
				_formDigitos.Dispose();
		}
		#endregion

		#region Metodos privados
		/// <summary>
		/// Le o numero de digitos do HD
		/// </summary>
		protected void FazerLeituraDigitos() {
			_formDigitos = new FormDigitosHD(this);
			_formDigitos.ShowDialog();
		}

		/// <summary>
		/// Le o valor da leitura do HD
		/// </summary>
		/// <param name="aceitaLeituraVazia">Indica se deve aceitar leitura vazia ou não</param>
		protected void FazerLeituraHidrometro(TipoLeitura tipoLeitura) {
			_matricula.Movimento.resetLeitura();

			_formLeitura = new FormLeituraHD(this, tipoLeitura);
			_formLeitura.resetValues();
			_formLeitura.ShowDialog();
		}
		#endregion
	}
}