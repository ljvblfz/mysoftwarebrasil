<?php
/**
 * Controle de Permissoes
 *
 * @name _PermissoesController
 * @author Alexis Moura
 * @package _controllers
 * @version 1.0
 */
class PermissoesController extends Axs_Controller_Action
{

	/**
	 * Objeto do modelo Permissoes
	 *
	 * @name $permissoes
	 * @access protected
	 * @var object
	 */
	public $permissoes;
	
	/**
	* Objeto do modelo Controller
	*
	* @name $controller
	* @access protected
	* @var object
	*/
	protected $controller;
	
	/**
	* Objeto do modelo Action
	*
	* @name $action
	* @access protected
	* @var object
	*/
	protected $action;
	
	/**
	* Objeto do modelo Role
	*
	* @name $role
	* @access protected
	* @var object
	*/
	protected $role;

	/**
	* Objeto do modelo Permissaorole
	*
	* @name $permissaorole
	* @access protected
	* @var object
	*/
	protected $permissaorole;

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
		
		$this->permissoes = new Permissoes();
		$this->controller = new Controller();
		$this->action = new Action();
		$this->role = new Role();
		$this->permissaorole = new Permissaorole();
		$this->buttons->dbTable = $this->permissoes;
		
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
		Axs_ACL::isIdentity();
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
		$this->view->descricaoCampos = array_merge(
			array("idRole"=>"Perfil"),
			$this->permissoes->descriptionFields
			);
		$this->view->controllerArray = $this->controller->getComboBox();
		$this->view->actionArray = $this->action->getComboBox();
		$this->view->roleArray = $this->role->getComboBox(false);
		
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
		$ajuda['namePermissao']['msg'] = '';
		$ajuda['namePermissao']['obrigatorio'] = 0;

		$ajuda['idAction']['msg'] = '';
		$ajuda['idAction']['obrigatorio'] = 0;

		$ajuda['idController']['msg'] = '';
		$ajuda['idController']['obrigatorio'] = 0;

		$ajuda['idPermissao']['msg'] = '';
		$ajuda['idPermissao']['obrigatorio'] = 0;

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
		$this->_forward("pesquisa");
	}

	/**
	 * Método responsável pela operação de inserção de dados no banco.
	 *
	 * @name addAction
	 * @access public
	 * @return void
	 */
	function addAction()
	{
		// Seta o action da view e o Título da página
		$this->setAction(parent::CREATE);
		$this->view->title = 'Cadastro de Permissoes';

		// Verifica se a chamada do controller foi feita via POST
		if($this->_request->isPost()){

			// Recupera os dados do formulário postado pelo usuário
			$dados = $this->_request->getParams();
			$this->permissoes->loadFields($dados);
			
			// Se todas as validações não contiverem erros
			if($this->permissoes->validaInsert()){
				
				// Realiza a inserção dos dados na tabela validando novamente
				$result = $this->permissoes->insertPermissoes($this->permissaorole,$dados);

				if($result){
					$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_CREATED);
					$this->setAction(parent::EDIT);
				} else 
					$this->view->mensagens = array(Axs_View_Message::ERROR_CREATING);
			} else {
				// Captura os erros e envia para a tela
				$this->view->errors = $this->permissoes->getErros();

				// Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->permissoes->getMensagens();
			}
			// Retorna os dados para a tela
			$this->view->assign($dados);
		}
		$this->render();
	}

	/**
	 * Método responsável pela operação de atualização de dados no banco.
	 *
	 * @name editAction
	 * @access public
	 * @return void
	 */
	function editAction()
	{
		// Seta o action da view e o Título da página
		$this->view->title = 'Edição de Permissoes';
		
		// Recupera os dados do formulário postado pelo usuário
		$dados = $this->_request->getParams();
		$this->permissoes->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::EDIT);
		
		// Verifica se a chamada do controller foi feita via POST
		if ($this->_request->isPost()){

			// Se todas as validações não contiverem erros
			if($this->permissoes->validaUpdate()){
				
				// Realiza a inserção dos dados na tabela validando novamente
				$result = $this->permissoes->updatePermissoes($this->permissaorole,$dados);

				if($result)
					$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_EDITED);
				else
					$this->view->mensagens = array(Axs_View_Message::ERROR_EDITING);
			} else {
				// Captura os erros e envia para a tela
				$this->view->errors = $this->permissoes->getErros();

				// Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->permissoes->getMensagens();
			}

			// Retorna os dados para a tela
			$this->view->assign($dados);

		} else {
			// Retorna os dados para a tela
			$this->view->assign($this->permissoes->chageData());
		}
		$this->render();
	}

	/**
	 * Método responsável pela operação de exclusão de dados no banco.
	 *
	 * @name deleteAction
	 * @access public
	 * @return void
	 */
	function deleteAction()
	{
		// Seta o action da view e o Título da página
		$this->view->title = 'Exclusão de Permissoes';
		
		// Recupera os dados do formulário postado pelo usuário
		$this->permissoes->loadData($this->_request->getParams());
		//$this->permissaorole->loadData($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::DELETE);

		// Se todas as validações não contiverem erros
		if($this->permissoes->validaDelete()){

			// Realiza a exclusão do registro na tabela
			//$result = $this->permissaorole->deleteValid();
			$result = $this->permissoes->deleteValid();

			if($result){
				// Redireciona para a tela de pesquisa
				$this->_redirect("permissoes/pesquisa/mensagem/exclusao");
			} else {
				$this->view->mensagens = array(Axs_View_Message::ERROR_DELETING);
			}
		} else {
			// Captura os erros e envia para a tela
			$this->view->errors = $this->permissoes->getErros();

			// Captura as mensagens e envia para a tela
			$this->view->mensagens = $this->permissoes->getMensagens();
		}

		// Retorna os dados para a tela
		$this->view->assign($this->permissoes->getData());
		$this->render();
	}

	/**
	 * Método responsável pela operação de pesquisa de dados no banco.
	 *
	 * @name pesquisaAction
	 * @access public
	 * @return void
	 */
	function pesquisaAction()
	{
		// Seta o título da pesquisa
		$this->view->title = 'Pesquisa de Permissoes';

		// Seta o action da view
		$this->setAction(parent::SEARCH);
		
		// Verifica se o valor do parametro mensagem é igual a exclusao
		if($this->getRequest()->getParam('mensagem') == 'exclusao'){
			$this->view->mensagens = array('Registro excluído com sucesso.');
		}

		// Construção do filtro de pesquisa
		$filtros = array(
			'namePermissao' => array('tipo_campo'=> 'text',
					'tipo_dado' => 'string',
					'descricao' => $this->permissoes->descriptionFields['namePermissao'],
					),
				'idAction' => array('tipo_campo'=> 'text',
					'tipo_dado' => 'string',
					'descricao' => $this->permissoes->descriptionFields['idAction'],
					),
				'idController' => array('tipo_campo'=> 'text',
					'tipo_dado' => 'string',
					'descricao' => $this->permissoes->descriptionFields['idController'],
					),
				'idPermissao' => array('tipo_campo'=> 'text',
					'tipo_dado' => 'string',
					'descricao' => $this->permissoes->descriptionFields['idPermissao'],
					),
				);

		// Modelos relacionados na consulta
		$modelos = array('from' => array('permissoes' => array('namePermissao','idAction','idController','idPermissao')));

		// Campos a serem exibidos na tela
		$camposTabulacao = array(
			$this->permissoes->descriptionFields['namePermissao'] => array('namePermissao','left'),
			$this->permissoes->descriptionFields['idAction'] => array('idAction','left'),
			$this->permissoes->descriptionFields['idController'] => array('idController','left'),
			$this->permissoes->descriptionFields['idPermissao'] => array('idPermissao','left'),
			);

		// Links dos registros da página
		$linkRegistros = array(
			'controle' => 'permissoes',
			'action'   => 'edit',
			'params'   => array('chave' => 'Permissoes')
			);

		// Ordenação padrão
		$orderPadrao = array('idPermissao');

		
		// Helper de pesquisa
		$pesquisa = $this->_helper->getHelper('Pesquisa');
		$pesquisa->Pesquisa($modelos, $filtros, $camposTabulacao, $linkRegistros, null, false, $orderPadrao);
	}
}
?>
