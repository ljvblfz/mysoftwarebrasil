<?php
/**
 * responsavel pela autenticação
 *
 * @name AuthController
 * @author Alexis Moura 1/4/2009 09:52:39
 * @package models
 * @version $Id$
 */
class AuthController extends Axs_Controller_Action {

	/**
	 * Array para validação dos campos
	 *
	 * @name $_validators
	 * @access protected
	 * @var array
	 */
	protected $_validators = array(
		'loginMembro' => array('Alnum', 'NotEmpty'),
		'senhaMembro' => array('allowEmpty' => true));
	/**
	 * Descrição dos campos a serem validados
	 *
	 * @name $_descricaoCampos
	 * @access public
	 * @var array
	 */
	public $_descricaoCampos = array(
		'loginMembro' => 'Nome de usuário',
		'senhaMembro' => 'Senha',
		'persistentCookie'=>'Continuar conectado'
		);

	/**
	 * Objeto do modelo Role
	 *
	 * @name $role
	 * @access protected
	 * @var object
	 */
	protected $role;

	/**
	    * Objeto do modelo Membro
	    *
	    * @name $role
	    * @access protected
	    * @var object
	    */
	protected $membro;

	/**
	 * Metodo chamado quando o controller é inicializado
	 *
	 * @name init
	 * @access public
	 * @return void
	 */
	function init()
	{
		$this->initView();
		$this->role = new Role();
		$this->membro = new Membro;

		// Seta valores pré-determinados para os campos da view
		$this->carregaValoresView();
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
		$this->view->descricaoCampos = $this->_descricaoCampos;
	}

	/**
	 * Action inicial do controller.
	 *
	 * @name indexAction
	 * @access public
	 * @return void
	 */
	function indexAction()
	{
		$this->_redirect('/');
	}

	/**
	 * Action responsavel por validar o login do usuario
	 *
	 * @name loginAction
	 * @access public
	 * @return void
	 */
	function loginAction()
	{
		$this->view->action = 'login';
		$this->view->title = "Login";

		$db = Zend_Registry::get('db');
		$this->view->message = '';
		$auth = Zend_Auth::getInstance();
		$passwd = $this->getRequest()->getParam('senhaMembro');

		if ($this->_request->isPost()) {

			if ($this->getRequest()->isPost() || ($this->getRequest()->isGet() && ($this->getRequest()->getParam('tipo') == 'get'))) {

				//Zend_Loader::loadClass('Zend_Filter_StripTags');
				$filter = new Zend_Filter_StripTags();
				$username = $filter->filter($this->_request->getParam('loginMembro'));
				$password = $filter->filter($this->_request->getParam('senhaMembro'));
				$data = $this->getRequest()->getParams();
				$input = new Axs_Filter_Input(null, $this->_validators, $data, null);

				if ($input->hasInvalid()) {
					$this->view->errors = $input->getInvalid();
					$this->view->assign($data);
				} else {
					$authAdapter = new Axs_Auth_Adapter_DbTable($db);
					$authAdapter->setTableName('membro');
					$authAdapter->setIdentityColumn('loginMembro');
					$authAdapter->setCredentialColumn('senhaMembro');

					// função criada para aceitar a clausula where na autenticação
					$authAdapter->setIdentity($username);
					$authAdapter->setCredential($password);

					// faz a autenticação
					$auth = Zend_Auth::getInstance();
					$result = $auth->authenticate($authAdapter);

					if ($result->isValid()) {

						// sucesso : guarda os dados do usuario, com excessao da senha
						$roleMembro = $this->role->select(array('R'=>'Role'),array("idRole","nameRole"))
							->setIntegrityCheck(false)
							->joinInner(
								array('M'=>'Membro'),
								"Role.idRole = M.idRole",
								array(
									"loginMembro",
									"idPessoa",
									"idMembro",
									"idRole"
									)
								)
							->joinInner(
								array('P'=>'Pessoa'),
								"M.idPessoa = P.idPessoa",
								array(
									"idPerfil"
									)
								)
							->where("loginMembro=?",$data['loginMembro']);
						$data = $db->fetchRow($roleMembro);

						if($data instanceof stdClass){
							$auth->getStorage()->write($data);
						}
						else{
							$data = $authAdapter->getResultRowObject(null, 'password');
							$auth->getStorage()->write($data);
						}

						// aumenta o session timeout para 1 hora
						$authSession = new Zend_Session_Namespace('Zend_Auth');
						$authSession->setExpirationSeconds(3600);
						
						if($data instanceof stdClass && $data->idRole == 1)
							$this->_redirect('/default/index/index');
						else
							$this->_redirect('/redesocial/index/index');
					} else {
						// falhou
						$this->view->errors = array('ops' => array("mensagem" => "Login falhou."));
						$this->view->assign($data);
					}
				}
			}
			$this->view->tipo = "form";
		}

		// Seta os botões à serem utilizados na view
		$this->view->botao_submit = array();
		$this->view->botao_submit['Login'] = array(
			'nome' => 'acao',
			'tipo' => 'submit'
			);
		$this->render();
	}

	/**
	 * Action responsavel por realizar o logout
	 *
	 * @name logoutAction
	 * @access public
	 * @return void
	 */
	function logoutAction()
	{
		Zend_Auth::getInstance()->clearIdentity();
		$this->_redirect($this->getRequest()->getModuleName().'/index');
	}
}
