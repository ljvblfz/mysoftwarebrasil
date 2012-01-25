<?php
/**
 * Controle de Menurole
 *
 * @name _MenuroleController
 * @author Alexis Moura
 * @package _controllers
 * @version 1.0
 */
class MenuroleController extends Axs_Controller_Action
{

    /**
     * Objeto do modelo Menurole
     *
     * @name $menurole
     * @access protected
     * @var object
     */
     protected $menurole;


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
        
		$this->menurole = new Menurole;

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
        $this->view->descricaoCampos = $this->menurole->descriptionFields;

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
        $ajuda['idRole']['msg'] = '';
		$ajuda['idRole']['obrigatorio'] = 0;

        $ajuda['idMenu']['msg'] = '';
		$ajuda['idMenu']['obrigatorio'] = 0;

        $ajuda['menuRoleId']['msg'] = '';
		$ajuda['menuRoleId']['obrigatorio'] = 0;

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
        $this->view->title = 'Cadastro de Menurole';

        // Verifica se a chamada do controller foi feita via POST
        if($this->_request->isPost()){

            // Recupera os dados do formulário postado pelo usuário
            $dados = $this->menurole->loadFields($this->_request->getParams());

            // Se todas as validações não contiverem erros
            if($this->menurole->validaInsert()){

                    // Realiza a inserção dos dados na tabela validando novamente
                    $result = $this->menurole->insertValid($dados);

                    if($result){
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_CREATED);
						$this->setAction(parent::EDIT);
                    } else {
  						$this->view->mensagens = array(Axs_View_Message::ERROR_CREATING);
					}
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->menurole->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->menurole->getMensagens();
            }
			// Retorna os dados para a tela
            $this->view->assign($this->menurole->getData());
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
        $this->view->title = 'Edição de Menurole';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->menurole->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::EDIT);
		
        // Verifica se a chamada do controller foi feita via POST
        if ($this->_request->isPost()){

            // Se todas as validações não contiverem erros
            if($this->menurole->validaUpdate()){

					// Realiza a atualização dos dados na tabela validando novamente
                    $result = $this->menurole->updateValid();

                    if($result)	
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_EDITED);
					else 
						$this->view->mensagens = array(Axs_View_Message::ERROR_EDITING);
				
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->menurole->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->menurole->getMensagens();
            }

			// Retorna os dados para a tela
			$this->view->assign($this->menurole->getData());

        } else {
			// Retorna os dados para a tela
			$this->view->assign($this->menurole->loadData());
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
		$this->view->title = 'Exclusão de Menurole';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->menurole->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::DELETE);

	    // Se todas as validações não contiverem erros
	    if($this->menurole->validaDelete()){

		        // Realiza a exclusão do registro na tabela
		        $result = $this->menurole->deleteValid($where);

		        if($result){
					// Redireciona para a tela de pesquisa
			    	$this->_redirect("menurole/pesquisa/mensagem/exclusao");
				} else {
					$this->view->mensagens = array(Axs_View_Message::ERROR_DELETING);
				}
		} else {
	        // Captura os erros e envia para a tela
	        $this->view->errors = $this->menurole->getErros();

	        // Captura as mensagens e envia para a tela
			$this->view->mensagens = $this->menurole->getMensagens();
	    }

		// Retorna os dados para a tela
	    $this->view->assign($this->menurole->getData());
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
        $this->view->title = 'Pesquisa de Menurole';

		// Seta o action da view
		$this->setAction(parent::SEARCH);
		
        // Verifica se o valor do parametro mensagem é igual a exclusao
		if($this->getRequest()->getParam('mensagem') == 'exclusao'){
			$this->view->mensagens = array('Registro excluído com sucesso.');
		}

        // Construção do filtro de pesquisa
        $filtros = array(
							'idRole' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->menurole->descriptionFields['idRole'],
                                                	),
							'idMenu' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->menurole->descriptionFields['idMenu'],
                                                	),
							'menuRoleId' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->menurole->descriptionFields['menuRoleId'],
                                                	),
		                    );

        // Modelos relacionados na consulta
        $modelos = array('from' => array('menurole' => array('idRole','idMenu','menuRoleId')));

        // Campos a serem exibidos na tela
        $camposTabulacao = array(
								 $this->menurole->descriptionFields['idRole'] => array('idRole','left'),
								 $this->menurole->descriptionFields['idMenu'] => array('idMenu','left'),
								 $this->menurole->descriptionFields['menuRoleId'] => array('menuRoleId','left'),
								);

        // Links dos registros da página
        $linkRegistros = array(
                                'controle' => 'menurole',
                                'action'   => 'edit',
                                'params'   => array('chave' => 'Menurole')
                               );

        // Ordenação padrão
        $orderPadrao = array('idRole','idMenu','menuRoleId');

						
        // Helper de pesquisa
        $pesquisa = $this->_helper->getHelper('Pesquisa');
        $pesquisa->Pesquisa($modelos, $filtros, $camposTabulacao, $linkRegistros, null, false, $orderPadrao);
    }
}
?>