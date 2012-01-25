<?php
/**
 * Controle de Menu
 *
 * @name _MenuController
 * @author Alexis Moura
 * @package _controllers
 * @version 1.0
 */
class MenuController extends Axs_Controller_Action
{

	/**
	 * Objeto do modelo Menu
	 *
	 * @name $menu
	 * @access protected
	 * @var object
	 */
	protected $menu;


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
		
		$this->menu = new Menu;

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
		if($this->_request->getActionName() != "gerar"){
			Axs_ACL::isIdentity();
		}
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
		$this->view->descricaoCampos = $this->menu->descriptionFields;

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
		$ajuda['ordemMenu']['msg'] = '';
		$ajuda['ordemMenu']['obrigatorio'] = 0;

		$ajuda['pathMenu']['msg'] = '';
		$ajuda['pathMenu']['obrigatorio'] = 0;

		$ajuda['MenuIdPai']['msg'] = '';
		$ajuda['MenuIdPai']['obrigatorio'] = 0;

		$ajuda['idMenu']['msg'] = '';
		$ajuda['idMenu']['obrigatorio'] = 0;

		$ajuda['nameMenu']['msg'] = '';
		$ajuda['nameMenu']['obrigatorio'] = 0;

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
		$this->view->title = 'Cadastro de Menu';

		// Verifica se a chamada do controller foi feita via POST
		if($this->_request->isPost()){

			// Recupera os dados do formulário postado pelo usuário
			$dados = $this->menu->loadFields($this->_request->getParams());

			// Se todas as validações não contiverem erros
			if($this->menu->validaInsert()){

				// Realiza a inserção dos dados na tabela validando novamente
				$result = $this->menu->insertValid($dados);

				if($result){
					$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_CREATED);
					$this->setAction(parent::EDIT);
				} else {
					$this->view->mensagens = array(Axs_View_Message::ERROR_CREATING);
				}
			} else {
				// Captura os erros e envia para a tela
				$this->view->errors = $this->menu->getErros();

				// Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->menu->getMensagens();
			}
			// Retorna os dados para a tela
			$this->view->assign($this->menu->getData());
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
		$this->view->title = 'Edição de Menu';
		
		// Recupera os dados do formulário postado pelo usuário
		$this->menu->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::EDIT);
		
		// Verifica se a chamada do controller foi feita via POST
		if ($this->_request->isPost()){

			// Se todas as validações não contiverem erros
			if($this->menu->validaUpdate()){

				// Realiza a atualização dos dados na tabela validando novamente
				$result = $this->menu->updateValid();

				if($result)	
					$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_EDITED);
				else 
					$this->view->mensagens = array(Axs_View_Message::ERROR_EDITING);
				
			} else {
				// Captura os erros e envia para a tela
				$this->view->errors = $this->menu->getErros();

				// Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->menu->getMensagens();
			}

			// Retorna os dados para a tela
			$this->view->assign($this->menu->getData());

		} else {
			// Retorna os dados para a tela
			$this->view->assign($this->menu->loadData());
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
		$this->view->title = 'Exclusão de Menu';
		
		// Recupera os dados do formulário postado pelo usuário
		$this->menu->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::DELETE);

		// Se todas as validações não contiverem erros
		if($this->menu->validaDelete()){

			// Realiza a exclusão do registro na tabela
			$result = $this->menu->deleteValid($where);

			if($result){
				// Redireciona para a tela de pesquisa
				$this->_redirect("menu/pesquisa/mensagem/exclusao");
			} else {
				$this->view->mensagens = array(Axs_View_Message::ERROR_DELETING);
			}
		} else {
			// Captura os erros e envia para a tela
			$this->view->errors = $this->menu->getErros();

			// Captura as mensagens e envia para a tela
			$this->view->mensagens = $this->menu->getMensagens();
		}

		// Retorna os dados para a tela
		$this->view->assign($this->menu->getData());
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
		$this->view->title = 'Pesquisa de Menu';

		// Seta o action da view
		$this->setAction(parent::SEARCH);
		
		// Verifica se o valor do parametro mensagem é igual a exclusao
		if($this->getRequest()->getParam('mensagem') == 'exclusao'){
			$this->view->mensagens = array('Registro excluído com sucesso.');
		}

		// Construção do filtro de pesquisa
		$filtros = array(
			'ordemMenu' => array('tipo_campo'=> 'text',
					'tipo_dado' => 'string',
					'descricao' => $this->menu->descriptionFields['ordemMenu'],
					),
				'pathMenu' => array('tipo_campo'=> 'text',
					'tipo_dado' => 'string',
					'descricao' => $this->menu->descriptionFields['pathMenu'],
					),
				'MenuIdPai' => array('tipo_campo'=> 'text',
					'tipo_dado' => 'string',
					'descricao' => $this->menu->descriptionFields['MenuIdPai'],
					),
				'idMenu' => array('tipo_campo'=> 'text',
					'tipo_dado' => 'string',
					'descricao' => $this->menu->descriptionFields['idMenu'],
					),
				'nameMenu' => array('tipo_campo'=> 'text',
					'tipo_dado' => 'string',
					'descricao' => $this->menu->descriptionFields['nameMenu'],
					),
				);

		// Modelos relacionados na consulta
		$modelos = array('from' => array('menu' => array('ordemMenu','pathMenu','MenuIdPai','idMenu','nameMenu')));

		// Campos a serem exibidos na tela
		$camposTabulacao = array(
			$this->menu->descriptionFields['ordemMenu'] => array('ordemMenu','left'),
			$this->menu->descriptionFields['pathMenu'] => array('pathMenu','left'),
			$this->menu->descriptionFields['MenuIdPai'] => array('MenuIdPai','left'),
			$this->menu->descriptionFields['idMenu'] => array('idMenu','left'),
			$this->menu->descriptionFields['nameMenu'] => array('nameMenu','left'),
			);

		// Links dos registros da página
		$linkRegistros = array(
			'controle' => 'menu',
			'action'   => 'edit',
			'params'   => array('chave' => 'Menu')
			);

		// Ordenação padrão
		$orderPadrao = array('idMenu');

		
		// Helper de pesquisa
		$pesquisa = $this->_helper->getHelper('Pesquisa');
		$pesquisa->Pesquisa($modelos, $filtros, $camposTabulacao, $linkRegistros, null, false, $orderPadrao);
	}
	
	
	/**
	* action responsavel por gerar o menu.
	* O menu gerado é buscado do banco e salvo na sessão.
	* @name gerarAction
	* @access public
	* @return void
	*/
	function gerarAction()
	{
		if(Zend_Auth::getInstance()->hasIdentity()){
			$idRole = Zend_Auth::getInstance()->getIdentity()->idRole;
			if($idRole == 1){
				$menu = $this->geraMenu("        ", 0);
				$this->view->menu = $menu;
			}
		}
		$this->render();
	}

	/**
	 * Função responsavel por gerar o menu a partir das tabelas do banco
	 *
	 * @name geraMenu
	 * @access public
	 * @return string menu gerado em html
	 */
	function geraMenu($tabs, $id_do_pai, $nivel = 1)
	{
		$idRole = Zend_Auth::getInstance()->getIdentity()->idRole;
	    $idRole = $idRole == null ? 0 : $idRole;
		$select = $this->menu->select()
			->setIntegrityCheck(false)
			->from(array('MN'=>"menu"),array("*"))
			->joinInner(array('MR'=>'menurole'),"MN.idMenu = MR.idMenu",array("*"))
			->order("MN.ordemMenu")
			->where("MN.MenuIdPai = ?",$id_do_pai,Zend_Db::INT_TYPE)
			->where("MR.idRole = ?",$idRole,Zend_Db::INT_TYPE);
		
		$recc = $this->menu->fetchAll($select);

		if ($id_do_pai == 0) {
			$ret = $tabs . "<ul class='menu' id='my_menu'>" . "\r\n";
		} else {
			$ret = "<ul> \r\n";
		}

		if ($recc instanceof Zend_Db_Table_Rowset) {

			foreach($recc as $key => $val) {

				$selectFilho = $this->menu->select()
					->setIntegrityCheck(false)
					->from(array('MN'=>"menu"),array("*"))
					->joinInner(array('MR'=>'menurole'),"MN.idMenu = MR.idMenu",array("*"))
					->order("MN.ordemMenu")
					->where("MN.MenuIdPai = ?",$val->idMenu,Zend_Db::INT_TYPE)
					->where("MR.idRole = ?",$idRole,Zend_Db::INT_TYPE);
				
				$recfilho = $this->menu->fetchAll($selectFilho);
				if(count($recfilho)>0) $class = " class=\"menuNodeFechado\" "; else $class = "class=\"menulink\"";

					if (!empty($val->pathMenu)) {
							$href = $this->_request->getBaseUrl()."/".$this->getRequest()->getModuleName().$val->pathMenu;
			$ret .= $tabs . "<div class=\"fieldLinha\">
								<li {$class} id=\"menu_{$val->idMenu}\">
									<a href='{$href}' class='menuNodeFim'>" . htmlentities($val->nameMenu) . "</a>
							</div>";
				} else {
					$ret .= $tabs . "<div class=\"fieldLinha\">
										<li {$class} id=\"menu_{$val->idMenu}\">
											<a href='javascript:void(0);' {$class}>" . htmlentities($val->nameMenu) . "</a>
									 </div>";
				}

				if (count($recfilho) > 0) {
					$ret .= "\r\n" . $tabs . "        " . $this->geraMenu($tabs . "        ", $val->id, $nivel + 1) . "    " . $tabs;
				}
				// fim filhos
				$ret .= "</li>\r\n";

			}
		}
		$ret .= $tabs . "</ul>\r\n";
		return $ret;
	}
}
?>
