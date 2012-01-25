<?php
/**
 * Controller Incial do sistema
 *
 * @name ProfileController.php
 * @author Alexis Moura 1/4/2009 10:39:36
 * @package Controller
 * @version $Id$
 */
class Redesocial_ProfileController extends Axs_Controller_Action {

	/**
	* Objeto interesse.
	*
	* @name $interesse
	* @access protected
	* @var object
	*/
	protected $interesse;

	/**
	* Objeto interesse.
		*
	* @name $interesse
	* @access protected
	* @var object
	*/
	protected $tipoInteresse;

	/**
	 * Descrição dos campos a serem validados
	 *
	 * @name $_descricaoCampos
	 * @access protected
	 * @var array
	 */
	protected $descricaoCampos = array(
		'idTipoInteresse' => 'Meus Interesses'
	);


	function init()
	{
		$this->initView();

		$this->interesse = new Interesse();
		$this->tipoInteresse = new Tipointeresse();

		// Seta valores pré-determinados para os campos da view
		$this->carregaValoresView();
	}


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
		$this->view->descricaoCampos = $this->descricaoCampos;
	}

	function indexAction()
	{

	}


	function fisicoAction()
	{

	}

	function interesseAction()
	{
		$this->view->action = 'interesse';

		$auth = Zend_Auth::getInstance();
		$user = $auth->getStorage()->read();

		// Verifica se a chamada do controller foi feita via POST
		if($this->_request->isPost()){

			// Recupera os dados do formulário postado pelo usuário
			$dados = $this->_request->getParams();

			$this->tipoInteresse->loadFields($dados);
			$this->interesse->loadFields($dados);
		}
		else{
			$this->view->arrayTipoInteresse = $this->tipoInteresse->getComboBox(false);
			$this->view->idTipoInteresse = $this->interesse->getMemberInteresses($user->idPerfil);
			$this->view->perfil = $user->idPerfil;
		}

		// Seta os botões à serem utilizados na view
		$this->view->botao_submit = array();
		$this->view->botao_submit['Salvar'] = array(
			'nome' => 'acao',
			'tipo' => 'submit'
			);

		$this->render();
	}
}
