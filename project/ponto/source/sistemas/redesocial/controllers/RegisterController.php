<?php
/**
 * Controle de Registro
 *
 * @name Redesocial_RegisterController
 * @author Alexis Moura
 * @package _controllers
 * @version 1.0
 */
class Redesocial_RegisterController extends Axs_Controller_Action
{
	/**
	* Objeto pessoa.
	*
	* @name $pessoa
	* @access protected
	* @var object
	*/
	protected $pessoa;
	
	/**
	* Objeto perfil.
	*
	* @name $perfil
	* @access protected
	* @var object
	*/
	protected $perfil;
	
	/**
	* Objeto membro.
	*
	* @name $membro
	* @access protected
	* @var object
	*/
	protected $membro;

	/**
	 * Objeto endereco.
	 *
	 * @name $endereco
	 * @access protected
	 * @var object
	 */
	protected $endereco;

	/**
	 * Objeto estado.
	 *
	 * @name $estado
	 * @access protected
	 * @var object
	 */
	protected $estado;
	
	/**
	* Objeto estado.
	*
	* @name $estado
	* @access protected
	* @var object
	*/
	protected $cidade;
	
	/**
	* Objeto interesse.
	*
	* @name $interesse
	* @access protected
	* @var object
	*/
	protected $interesse;
	
	/**
	* Objeto sexo.
	*
	* @name $sexo
	* @access protected
	* @var object
	*/
	protected $sexo;
	
	/**
	* Descrição dos campos a serem validados
	*
	* @name $_descricaoCampos
	* @access protected
	* @var array
	*/
	protected $descricaoCampos = array(
		'loginMembro' => 'Nome de Usuario',
		'senhaMembro' => 'Senha',
		'nomePessoa' => 'Seu nome',
		'nascimentoPessoa' => 'Data Nascimento',
		'idSexo' => 'Você é',
		'emailPessoa' => 'Email',
		'idCidade' => 'Cidade',
		'idEstado' => 'Estado',
		'idTipoInteresse' => 'Interesses',
		'userTerms' => 'Termos de uso'
		);
	
	/**
	 * Método init da classe.
	 *
	 * @name init
	 * @access public
	 * @return void
	 */
	function init()
	{
		$this->initView();
		$this->membro = new Membro();
		$this->pessoa = new Pessoa();
		$this->perfil = new Perfil();
		$this->endereco = new Endereco();
		$this->estado = new Estado();
		$this->cidade = new Cidade();
		$this->sexo = new Sexo();
		$this->interesse = new Interesse();
		
		// Seta valores pré-determinados para os campos da view
		$this->carregaValoresView();
	}

	/**
	 * Método que realiza a verificação de login do usuário.
	 *
	 * @name preDispatch
	 * @access public
	 * @return void
	 */
	function preDispatch()
	{

	}

	/**
	 * Método responsável pelo carregamento de todos os campos combobox, radio, checkbox e outros.
	 *
	 * @name carregaValoresView
	 * @access public
	 * @return void
	 */
	function carregaValoresView()
	{
		// Carrega a descrição dos campos
		$this->view->descricaoCampos = $this->descricaoCampos;
		
		// Carrega a ajuda
		$this->carregaAjuda();
	}

	/**
	* Função responsável por carregar o texto das tooltips do formulário.
		 *
	* @name carregaAjuda
	* @access public
	* @return void
		 */
	function carregaAjuda()
	{
		$ajuda['nameAction']['msg'] = '';
		$ajuda['nameAction']['obrigatorio'] = 0;

		$ajuda['idAction']['msg'] = '';
		$ajuda['idAction']['obrigatorio'] = 0;

		$this->view->assign('ajuda', $ajuda);
	}

	/**
	    * Método principal da classe.
	    *
	    * @name indexAction
	    * @access public
	    * @return void
	    */
	function indexAction()
	{

	}
	
	
	function registerAction()
	{
		$this->view->action = 'register';
		if($this->_request->isPost()){
			
			// Recupera os dados do formulário postado pelo usuário
			$dados = $this->_request->getParams();
			
			// adiciona a role de usuario
			$dados['idRole'] = 2;
			
			$this->pessoa->loadFields($dados);
			$this->membro->loadFields($dados);
			$this->endereco->loadFields($dados);
			$this->perfil->loadFields($dados);
			
			$valid = array(
				$this->pessoa->validaInsert(),
				$this->membro->validaInsert(),
				$this->endereco->validaInsert(),
				$this->pessoa->validUserTerms($dados['userTerms'])
			);
			
			if($this->pessoa->validacaoCorreta($valid))
			{
				$this->pessoa->getAdapter()->beginTransaction();
				
				// Realiza a inserção dos dados na tabela validando novamente
				$result = $this->endereco->insertValid(false);
				$this->perfil->_data['idEndereco'] = $result;
				$result = $this->perfil->insertValid(false);
				$this->pessoa->_data['idPerfil'] = $result;
				$result = $this->pessoa->insertValid(false);
				$this->membro->_data['idPessoa'] = $result;
				$result = $this->membro->insertValid(false);

				if($result){
					$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_CREATED);
					$this->pessoa->getAdapter()->commit();
				} else {
					$this->view->mensagens = array(Axs_View_Message::ERROR_CREATING);
					$this->pessoa->getAdapter()->rollback();
				}
				
			}else {
				// Captura os erros e envia para a tela
				$this->view->errors = array_merge(
					$this->pessoa->getErros(),
					$this->membro->getErros(),
					$this->endereco->getErros(),
					$this->perfil->getErros()
				);

				// Captura as mensagens e envia para a tela
				$this->view->mensagens = array_merge(
					$this->pessoa->getMensagens(),
					$this->membro->getMensagens(),
					$this->endereco->getMensagens(),
					$this->perfil->getMensagens()
				);
			}
			
			// Retorna os dados para a tela
			$this->view->assign($dados);
		}
		
		$this->view->sexoArray = $this->sexo->getComboBox();
		$this->view->estadoArray = $this->estado->getComboBox();
		$this->view->interesseArray = $this->interesse->getInteresses();
		
		// Seta os botões à serem utilizados na view
		$this->view->botao_submit = array();
		$this->view->botao_submit['Finalizar cadastro'] = array(
			'nome' => 'acao',
			'tipo' => 'submit'
			);

		$this->render();
	}
	
	/**
	* Método de edição de perfil.
	*
	* @name editAction
	* @access public
	* @return void
	*/
	function editAction()
	{
		$this->view->action = 'edit';
		
		// Recupera os dados do formulário
		$dados = $this->_request->getParams();
		
		if($this->_request->isPost()){
			
			$this->pessoa->loadFields($dados);
			$this->membro->loadFields($dados);
			$this->endereco->loadFields($dados);
			$this->perfil->loadFields($dados);
			
			$valid = array(
				$this->pessoa->validaInsert(),
				$this->membro->validaInsert(),
				$this->endereco->validaInsert()
				);
		}
		else{
			$auth = Zend_Auth::getInstance();
			$dados = array_merge(
				$this->pessoa->loadData(array("idPessoa"=>$auth->getIdentity()->idPessoa)),
				$this->membro->loadData(array("idMembro"=>$auth->getIdentity()->idMembro)),
				$this->perfil->loadData(array("idPerfil"=>$this->pessoa->_data['idPerfil'])),
				$this->endereco->loadData(array("idEndereco"=>$this->perfil->_data['idEndereco'])),
				$this->cidade->loadData(array("idCidade"=>$this->endereco->_data['idCidade'])),
				$this->estado->loadData(array("idEstado"=>$this->cidade->_data['idEstado']))
				);
		}
		
		// Retorna os dados para a tela
		$this->view->assign($dados);
		
		$this->view->cidadeArray = $this->cidade->getCidade($this->estado->_data['idEstado']);
		$this->view->sexoArray = $this->sexo->getComboBox();
		$this->view->estadoArray = $this->estado->getComboBox();
		$this->view->interesseArray = $this->interesse->getInteresses();
		
		// Seta os botões à serem utilizados na view
		$this->view->botao_submit = array();
		$this->view->botao_submit['Salvar'] = array(
			'nome' => 'acao',
			'tipo' => 'button',
			'javascript' => "submitData('{$this->view->baseUrl}/{$this->view->modulo}/register/edit','frmregister')"
			);
		
		$this->render();
	}
	
}
?>
