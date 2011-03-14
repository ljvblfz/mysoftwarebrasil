using System;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using OnPlaceMovel.Source.Banco;
using OnPlaceMovel.Source.Controladores;

namespace OnPlaceMovel.Source.Forms {

    public struct sTabela {
        public string categoria;
        public string taxa;
        public string situacao;
        public string economias;
        public int indice;
        public bool altCat;
        public bool altTaxa;
        public bool altSit;
        public bool altEcon;
    };

    public partial class FormAlteracaoCadastral : Form {
        #region Atributos
        private string _imovel, _hd, _nome, _complemento, _digitos;
        private Collection<OnpMatriculaAlteracao> _listaAlteracoes;
        private Collection<sTabela> _tabelaAtual;
        private Collection<sTabela> _tabela;
        private OnpMatricula _matricula;
        private AlteracaoCadastralController _alteracaoControl;

        private sTabela _registro;
        public sTabela Registro {
            get {
                return _registro;
            }
            set {
                _registro = value;
            }
        }
        #endregion

        public FormAlteracaoCadastral(AlteracaoCadastralController alteracaoControl, OnpMatricula matricula) {
            InitializeComponent();

            _matricula = matricula;
            _alteracaoControl = alteracaoControl;

            _tabela = new Collection<sTabela>();
            _tabelaAtual = new Collection<sTabela>();

            _registro = new sTabela();
            _registro.indice = -1;

            _listaAlteracoes = new Collection<OnpMatriculaAlteracao>();
        }

        #region Ações
        private void AlteracaoCadastral_Activated(object sender, EventArgs e) {
            Controlador.ActiveForm = this;
        }

        private void btnLimpar_Click(object sender, EventArgs e) {
            while (_tabela.Count > 0)
                _tabela.RemoveAt(0);

            while (lstLigacaoCategoria.Items.Count > 0)
                lstLigacaoCategoria.Items.RemoveAt(0);

            _registro.indice = -1;
        }

        private void btnInclui_Click(object sender, EventArgs e) {
            // Verifica se ja existe categoria com a mesma taxa na lista
            foreach (sTabela tabItem in _tabela)
                if (_registro.categoria.Equals(tabItem.categoria) && _registro.taxa.Equals(tabItem.taxa)) {
                    System.Windows.Forms.MessageBox.Show("Já existe está categoria com esta mesma taxa.");
                    return;
                }

            // Verifica se os campos estão preenchidos
            if (cboxListaCategorias.SelectedItem == null || string.IsNullOrEmpty(txtEconomias.Text) ||
                cboxListaSituacao.SelectedItem == null || cboxListaTaxas.SelectedItem == null) {
                System.Windows.Forms.MessageBox.Show("Preencha todos os campos.");
                return;
            }

            ListViewItem item = new ListViewItem();

            item.Text = _registro.categoria;
            item.SubItems.Add(_registro.taxa);
            item.SubItems.Add(_registro.situacao);
            item.SubItems.Add(_registro.economias);

            if (_registro.indice > -1) {
                lstLigacaoCategoria.Items.RemoveAt(_registro.indice);

                int indice = BuscaRegistro(_registro, _tabela);
                if (indice > -1)
                    _tabela.RemoveAt(indice);
            }

            lstLigacaoCategoria.Items.Add(item);

            _registro.indice = -1;
            _tabela.Add(_registro);
        }

        private void btnGravar_Click(object sender, EventArgs e) {

            #region CODIGO DO HD
            if (!txtNHD.Text.Equals(_hd)) {
                OnpMatriculaAlteracao aux = new OnpMatriculaAlteracao();
                aux.SeqMatricula = _alteracaoControl.Matricula.SeqMatricula;
                aux.IndDadoAlterado = "HD";
                aux.SeqItem = 1;
                aux.DesConteudoAnterior = _hd;
                aux.DesConteudoNovo = txtNHD.Text;
                _listaAlteracoes.Add(aux);
            }
            #endregion

            #region NUMERO DO IMOVEL
            if (!txtNImovel.Text.Equals(_imovel)) {
                OnpMatriculaAlteracao aux = new OnpMatriculaAlteracao();
                aux.SeqMatricula = _alteracaoControl.Matricula.SeqMatricula;
                aux.IndDadoAlterado = "NI";
                aux.SeqItem = 1;
                aux.DesConteudoAnterior = _imovel;
                aux.DesConteudoNovo = txtNImovel.Text;
                _listaAlteracoes.Add(aux);
            }
            #endregion

            #region NOME
            if (!txtNome.Text.Equals(_nome)) {
                OnpMatriculaAlteracao aux = new OnpMatriculaAlteracao();
                aux.SeqMatricula = _alteracaoControl.Matricula.SeqMatricula;
                aux.IndDadoAlterado = "NM";
                aux.SeqItem = 1;
                aux.DesConteudoAnterior = _nome;
                aux.DesConteudoNovo = txtNome.Text;
                _listaAlteracoes.Add(aux);
            }
            #endregion

            #region COMPLEMENTO DO ENDERECO
            if (!txtComplemento.Text.Equals(_complemento)) {
                OnpMatriculaAlteracao aux = new OnpMatriculaAlteracao();
                aux.SeqMatricula = _alteracaoControl.Matricula.SeqMatricula;
                aux.IndDadoAlterado = "CP";
                aux.SeqItem = 1;
                aux.DesConteudoAnterior = _complemento;
                aux.DesConteudoNovo = txtComplemento.Text;
                _listaAlteracoes.Add(aux);
            }
            #endregion

            #region NUMERO DE DIGITOS DO HD
            if (!txtDigitos.Text.Equals(_digitos)) {
                if (string.IsNullOrEmpty(txtDigitos.Text) || int.Parse(txtDigitos.Text) < 4 || int.Parse(txtDigitos.Text) > 7) {
                    System.Windows.Forms.MessageBox.Show("Campo: \"Dígitos\" aceita valores de 4 a 7.");
                    _listaAlteracoes.Clear();
                    return;
                }

                OnpMatriculaAlteracao aux = new OnpMatriculaAlteracao();
                aux.SeqMatricula = _alteracaoControl.Matricula.SeqMatricula;
                aux.IndDadoAlterado = "DG";
                aux.SeqItem = 1;
                aux.DesConteudoAnterior = _digitos;
                aux.DesConteudoNovo = txtDigitos.Text;
                _listaAlteracoes.Add(aux);
            }
            #endregion

            #region LOGRADOURO
            if (_matricula.Logradouro != null && !cboxLogradouro.Text.Equals(_matricula.Logradouro.DesLogradouro)) {
                OnpMatriculaAlteracao aux = new OnpMatriculaAlteracao();
                aux.SeqMatricula = _alteracaoControl.Matricula.SeqMatricula;
                aux.IndDadoAlterado = "LG";
                aux.SeqItem = 1;
                aux.DesConteudoAnterior = _matricula.SeqLogradouro.ToString();

                int seqLog = 0;
                OnpLogradouro log = new OnpLogradouro();
                Collection<OnpLogradouro> listaLog = log.SelectCollection();
                for (int i = 0; i < listaLog.Count; i++)
                    if (cboxLogradouro.Text == listaLog[i].DesLogradouro)
                        seqLog = listaLog[i].SeqLogradouro.Value;

                aux.DesConteudoNovo = seqLog.ToString();
                _listaAlteracoes.Add(aux);
            }
            #endregion

            #region LOCALIZACAO DO HIDROMETRO
            string localHD = _matricula.Movimento.Hidrometro.LocalHidrometro.DesLocal;
            if (!cboxLocalizacao.Text.Trim().Equals("")) {
                if (string.IsNullOrEmpty(localHD) || !cboxLocalizacao.Text.Equals(localHD)) {
                    OnpMatriculaAlteracao aux = new OnpMatriculaAlteracao();

                    aux.SeqMatricula = _alteracaoControl.Matricula.SeqMatricula;
                    aux.IndDadoAlterado = "LH";
                    aux.SeqItem = 1;
                    aux.DesConteudoAnterior = _matricula.Movimento.Hidrometro.SeqLocal.ToString();

                    OnpLocalizacaoHidrometro loc = new OnpLocalizacaoHidrometro();
                    Collection<OnpLocalizacaoHidrometro> listaLoc = loc.SelectCollection();
                    for (int i = 0; i < listaLoc.Count; i++)
                        if (cboxLocalizacao.Text.Equals(listaLoc[i].DesLocal)) {
                            aux.DesConteudoNovo = listaLoc[i].SeqLocal.Value.ToString();
                            break;
                        }

                    _listaAlteracoes.Add(aux);
                }
            }
            #endregion

            #region CATEGORIAS
            // Formato: CATEGORIA#TAXA#SITUACAO#ECONOMIAS
            // Situacao: 1 = ligado, 0 = desligado

            // Gerando o OnpMatriculaAlteracao para categorias alteradas ou novas categorias
            int seqItem = 0;
            foreach (sTabela tabItem in _tabela) {
                int indice = BuscaRegistroCatTaxa(tabItem, _tabelaAtual);
                OnpMatriculaAlteracao aux;

                // Verificando se ja existe esta categoria
                if (indice > -1) {
                    if (tabItem.altTaxa || tabItem.altSit || tabItem.altEcon) {
                        aux = new OnpMatriculaAlteracao();

                        aux.SeqMatricula = _alteracaoControl.Matricula.SeqMatricula;
                        aux.IndDadoAlterado = "CT";
                        aux.SeqItem = ++seqItem;
                        aux.DesConteudoAnterior = _tabelaAtual[indice].categoria + "#" + _tabelaAtual[indice].taxa + "#" + _tabelaAtual[indice].situacao + "#" + _tabelaAtual[indice].economias;

                        string estadoLigacao;
                        if (tabItem.situacao.Equals("Ligado"))
                            estadoLigacao = "1";
                        else
                            estadoLigacao = "0";

                        aux.DesConteudoNovo = tabItem.categoria + "#" + tabItem.taxa + "#" + estadoLigacao + "#" + tabItem.economias;

                        _listaAlteracoes.Add(aux);
                    }
                } else { // ou se é uma nova categoria
                    aux = new OnpMatriculaAlteracao();

                    aux.SeqMatricula = _alteracaoControl.Matricula.SeqMatricula;
                    aux.IndDadoAlterado = "CT";
                    aux.SeqItem = ++seqItem;
                    aux.DesConteudoAnterior = string.Empty;
                    aux.DesConteudoNovo = tabItem.categoria + "#" + tabItem.taxa + "#" + tabItem.situacao + "#" + tabItem.economias;

                    _listaAlteracoes.Add(aux);
                }
            }

            // Verificando por remoção de categorias
            foreach (sTabela tabItem in _tabelaAtual) {
                int indice = BuscaRegistroCatTaxa(tabItem, _tabela);

                // Se não achou, quer dizer que a categoria deve ser removida
                if (indice == -1) {
                    OnpMatriculaAlteracao aux;
                    aux = new OnpMatriculaAlteracao();

                    aux.SeqMatricula = _alteracaoControl.Matricula.SeqMatricula;
                    aux.IndDadoAlterado = "CT";
                    aux.SeqItem = ++seqItem;
                    aux.DesConteudoAnterior = tabItem.categoria + "#" + tabItem.taxa + "#" + tabItem.situacao + "#" + tabItem.economias;
                    aux.DesConteudoNovo = string.Empty;

                    _listaAlteracoes.Add(aux);
                }
            }
            #endregion

            #region OBSERVACAO
            if (!string.IsNullOrEmpty(txtObservacao.Text)) {
                OnpMatriculaAlteracao obs = new OnpMatriculaAlteracao();

                obs.SeqMatricula = _alteracaoControl.Matricula.SeqMatricula;
                obs.IndDadoAlterado = "OB";
                obs.SeqItem = ++seqItem;
                obs.DesConteudoAnterior = string.Empty;
                obs.DesConteudoNovo = txtObservacao.Text;

                _listaAlteracoes.Add(obs);
            }
            #endregion

            _alteracaoControl.GravarDadosAlteracao(_listaAlteracoes);

            Close();
        }

        private void lvLigacaoCategoria_ItemCheck(object sender, ItemCheckEventArgs e) {

            for (int i = 0; i < lstLigacaoCategoria.Items.Count; i++)
                if (i != e.Index)
                    lstLigacaoCategoria.Items[i].Checked = false;

            _registro.categoria = ((ListView)sender).Items[e.Index].SubItems[0].Text;
            _registro.taxa = ((ListView)sender).Items[e.Index].SubItems[1].Text;
            _registro.situacao = ((ListView)sender).Items[e.Index].SubItems[2].Text;
            _registro.economias = ((ListView)sender).Items[e.Index].SubItems[3].Text;

            if (e.NewValue != CheckState.Checked)
                _registro.indice = -1;
            else
                _registro.indice = e.Index;

            for (int i = 0; i < cboxListaCategorias.Items.Count; i++)
                if (_registro.categoria.Equals(cboxListaCategorias.Items[i].ToString())) {
                    cboxListaCategorias.SelectedIndex = i;
                    break;
                }

            for (int i = 0; i < cboxListaTaxas.Items.Count; i++)
                if (_registro.taxa.Equals(cboxListaTaxas.Items[i].ToString())) {
                    cboxListaTaxas.SelectedIndex = i;
                    break;
                }

            for (int i = 0; i < cboxListaSituacao.Items.Count; i++)
                if (_registro.situacao.Equals(cboxListaSituacao.Items[i].ToString())) {
                    cboxListaSituacao.SelectedIndex = i;
                    break;
                }

            txtEconomias.Text = _registro.economias;
        }

        #endregion

        #region Gets e Sets
        public void SetNome(string nom) {
            if (!string.IsNullOrEmpty(nom))
                txtNome.Text = _nome = nom;
            else
                txtNome.Text = _nome = string.Empty;
        }

        public void SetComplemento(string comp) {
            if (!string.IsNullOrEmpty(comp))
                txtComplemento.Text = _complemento = comp;
            else
                txtComplemento.Text = _complemento = string.Empty;
        }

        public void SetDigitos(string digit) {
            if (!string.IsNullOrEmpty(digit))
                txtDigitos.Text = _digitos = digit;
            else
                txtDigitos.Text = _digitos = string.Empty;
        }

        public void SetNHD(string nHD) {
            if (!string.IsNullOrEmpty(nHD))
                txtNHD.Text = _hd = nHD;
            else
                txtNHD.Text = _hd = string.Empty;
        }

        public void SetNImovel(int nimovel) {
            if (nimovel > 0)
                txtNImovel.Text = _imovel = nimovel.ToString();
            else
                txtNImovel.Text = _imovel = "0";
        }

        public void SetListaLogradouro(Collection<OnpLogradouro> lista) {
            for (int i = 0; i < lista.Count; i++) {
                cboxLogradouro.Items.Add(lista[i].DesLogradouro);
                if (_matricula.SeqLogradouro == lista[i].SeqLogradouro)
                    cboxLogradouro.SelectedIndex = i;
            }
        }

        public void SetListaLocalizacao(Collection<OnpLocalizacaoHidrometro> lista) {
            for (int i = 0; i < lista.Count; i++) {
                cboxLocalizacao.Items.Add(lista[i].DesLocal);
                if (_matricula.Movimento.Hidrometro.SeqLocal == lista[i].SeqLocal)
                    cboxLocalizacao.SelectedIndex = i;
            }
        }

        public void SetListaTaxas(Collection<OnpTaxa> lista) {
            for (int i = 0; i < lista.Count; i++)
                cboxListaTaxas.Items.Add(lista[i].DesTaxa);
            cboxListaTaxas.SelectedIndex = 0;
        }

        public void SetListaCategorias(Collection<OnpCategoria> lista) {
            for (int i = 0; i < lista.Count; i++)
                cboxListaCategorias.Items.Add(lista[i].DesCategoria);
            cboxListaCategorias.SelectedIndex = 0;
        }

        public void SetMovimentoCategoria(Collection<OnpMovimentoCategoria> lista) {
            sTabela aux;
            ListViewItem item;

            for (int i = 0; i < lista.Count; i++) {
                for (int j = 0; j < lista[i].Taxas.Count; j++) {
                    aux = new sTabela();
                    item = new ListViewItem();

                    item.Text = lista[i].Categoria.DesCategoria;
                    item.SubItems.Add(lista[i].Taxas[j].Taxa.DesTaxa);

                    if (lista[i].Taxas[j].IndSituacao.Equals("1"))
                        item.SubItems.Add("Ligado");
                    else
                        item.SubItems.Add("Desligado");

                    item.SubItems.Add(lista[i].ValNumeroEconomia.ToString());
                    item.Checked = false;
                    lstLigacaoCategoria.Items.Add(item);

                    aux.categoria = lista[i].Categoria.DesCategoria;
                    aux.taxa = lista[i].Taxas[j].Taxa.DesTaxa;
                    aux.situacao = lista[i].Taxas[j].IndSituacao;
                    aux.economias = lista[i].ValNumeroEconomia.ToString();

                    _tabelaAtual.Add(aux);
                    _tabela.Add(aux);
                }
            }
        }
        #endregion

        #region Validações
        private void tbNImovel_TextChanged(object sender, EventArgs e) {
            try {
                int.Parse(txtNImovel.Text);
            } catch {
                txtNImovel.Text = _imovel;
            }
        }
        private void tbNHD_LostFocus(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtNHD.Text))
                txtNHD.Text = _hd;
        }
        private void tbEconomias_TextChanged(object sender, EventArgs e) {
            try {
                int.Parse(txtEconomias.Text);
                _registro.economias = txtEconomias.Text;
                _registro.altEcon = true;
            } catch {
                txtEconomias.Text = "0";
            }
        }
        private void tbDigitos_TextChanged(object sender, EventArgs e) {
            try {
                int.Parse(txtDigitos.Text);
            } catch {
                txtDigitos.Text = _digitos;
            }
        }
        private void cbListaCategorias_SelectedIndexChanged(object sender, EventArgs e) {
            _registro.categoria = cboxListaCategorias.Text;
            _registro.altCat = true;
        }
        private void cbListaTaxas_SelectedIndexChanged(object sender, EventArgs e) {
            _registro.taxa = cboxListaTaxas.Text;
            _registro.altTaxa = true;
        }
        private void cbListaSituacao_SelectedIndexChanged(object sender, EventArgs e) {
            _registro.situacao = cboxListaSituacao.Text;
            _registro.altSit = true;
        }
        #endregion

        #region Metodos Privados
        private int BuscaRegistro(sTabela registro, Collection<sTabela> lista) {
            for (int i = 0; i < lista.Count; i++)
                if (registro.categoria.Equals(lista[i].categoria) && registro.economias.Equals(lista[i].economias) &&
                     registro.situacao.Equals(lista[i].situacao) && registro.taxa.Equals(lista[i].taxa))
                    return i;

            return -1;
        }

        private int BuscaRegistroCatTaxa(sTabela registro, Collection<sTabela> lista) {
            for (int i = 0; i < lista.Count; i++)
                if ((registro.categoria == lista[i].categoria) && (registro.taxa == lista[i].taxa))
                    return i;

            return -1;
        }

        private void FormAlteracaoCadastral_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyData == Keys.Escape)
                btnCancelar_Click(sender, null);
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            Close();
        }
        #endregion // Metodos Privados
    }
}