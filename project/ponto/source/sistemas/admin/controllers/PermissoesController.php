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
	 * M�todo init da classe.
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
		
		// Seta valores pr�-determinados para os campos da view
		$this->carregaValoresView();
	}

	/**
	 * M�todo que realiza a verifica��o de login do usu�rio.
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
	 * M�todo respons�vel pelo carregamento de todos os campos combobox, radio, checkbox e outros.
	 *
	 * @name carregaValoresView
	 * @access public
	 * @return void
	 */
	function carregaValoresView()
	{
		// Carrega a descri��o dos campos
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
	* Fun��o respons�vel por carregar o texto das tooltips do formul�rio.
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
	    * M�todo principal da classe.
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
	 * M�todo respons�vel pela opera��o de inser��o de dados no banco.
	 *
	 * @name addAction
	 * @access public
	 * @return void
	 */
	function addAction()
	{
		// Seta o action da view e o T�tulo da p�gina
		$this->setAction(parent::CREATE);
		$this->view->title = 'Cadastro de Permissoes';

		// Verifica se a chamada do controller foi feita via POST
		if($this->_request->isPost()){

			// Recupera os dados do formul�rio postado pelo usu�rio
			$dados = $this->_request->getParams();
			$this->permissoes->loadFields($dados);
			
			// Se todas as valida��es n�o contiverem erros
			if($this->permissoes->validaInsert()){
				
				// Realiza a inser��o dos dados na tabela validando novamente
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
	 * M�todo respons�vel pela opera��o de atualiza��o de dados no banco.
	 *
	 * @name editAction
	 * @access public
	 * @return void
	 */
	function editAction()
	{
		// Seta o action da view e o T�tulo da p�gina
		$this->view->title = 'Edi��o de Permissoes';
		
		// Recupera os dados do formul�rio postado pelo usu�rio
		$dados = $this->_request->getParams();
		$this->permissoes->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::EDIT);
		
		// Verifica se a chamada do controller foi feita via POST
		if ($this->_request->isPost()){

			// Se todas as valida��es n�o contiverem erros
			if($this->permissoes->validaUpdate()){
				
				// Realiza a inser��o dos dados na tabela validando novamente
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
	 * M�todo respons�vel pela opera��o de exclus�o de dados no banco.
	 *
	 * @name deleteAction
	 * @access public
	 * @return void
	 */
	function deleteAction()
	{
		// Seta o action da view e o T�tulo da p�gina
		$this->view->title = 'Exclus�o de Permissoes';
		
		// Recupera os dados do formul�rio postado pelo usu�rio
		$this->permissoes->loadData($this->_request->getParams());
		//$this->permissaorole->loadData($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::DELETE);

		// Se todas as valida��es n�o contiverem erros
		if($this->permissoes->validaDelete()){

			// Realiza a exclus�o do registro na tabela
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
	 * M�todo respons�vel pela opera��o de pesquisa de dados no banco.
	 *
	 * @name pesquisaAction
	 * @access public
	 * @return void
	 */
	function pesquisaAction()
	{
		// Seta o t�tulo da pesquisa
		$this->view->title = 'Pesquisa de Permissoes';

		// Seta o action da view
		$this->setAction(parent::SEARCH);
		
		// Verifica se o valor do parametro mensagem � igual a exclusao
		if($this->getRequest()->getParam('mensagem') == 'exclusao'){
			$this->view->mensagens = array('Registro exclu�do com sucesso.');
		}

		// Constru��o do filtro de pesquisa
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

		// Links dos registros da p�gina
		$linkRegistros = array(
			'controle' => 'permissoes',
			'action'   => 'edit',
			'params'   => array('chave' => 'Permissoes')
			);

		// Ordena��o padr�o
		$orderPadrao = array('idPermissao');

		
		// Helper de pesquisa
		$pesquisa = $this->_helper->getHelper('Pesquisa');
		$pesquisa->Pesquisa($modelos, $filtros, $camposTabulacao, $linkRegistros, null, false, $orderPadrao);
	}
}
?>
