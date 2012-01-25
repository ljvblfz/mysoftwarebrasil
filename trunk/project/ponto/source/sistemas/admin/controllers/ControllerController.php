<?php
/**
 * Controle de Controller
 *
 * @name _ControllerController
 * @author Alexis Moura
 * @package _controllers
 * @version 1.0
 */
class ControllerController extends Axs_Controller_Action
{

    /**
     * Objeto do modelo Controller
     *
     * @name $controller
     * @access protected
     * @var object
     */
     protected $controller;


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
        
		$this->controller = new Controller;

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
        $this->view->descricaoCampos = $this->controller->descriptionFields;

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
        $ajuda['nameController']['msg'] = '';
		$ajuda['nameController']['obrigatorio'] = 0;

        $ajuda['idController']['msg'] = '';
		$ajuda['idController']['obrigatorio'] = 0;

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
        $this->view->title = 'Cadastro de Controller';

        // Verifica se a chamada do controller foi feita via POST
        if($this->_request->isPost()){

            // Recupera os dados do formulário postado pelo usuário
            $dados = $this->controller->loadFields($this->_request->getParams());

            // Se todas as validações não contiverem erros
            if($this->controller->validaInsert()){

                    // Realiza a inserção dos dados na tabela validando novamente
                    $result = $this->controller->insertValid($dados);

                    if($result){
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_CREATED);
						$this->setAction(parent::EDIT);
                    } else {
  						$this->view->mensagens = array(Axs_View_Message::ERROR_CREATING);
					}
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->controller->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->controller->getMensagens();
            }
			// Retorna os dados para a tela
            $this->view->assign($this->controller->getData());
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
        $this->view->title = 'Edição de Controller';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->controller->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::EDIT);
		
        // Verifica se a chamada do controller foi feita via POST
        if ($this->_request->isPost()){

            // Se todas as validações não contiverem erros
            if($this->controller->validaUpdate()){

					// Realiza a atualização dos dados na tabela validando novamente
                    $result = $this->controller->updateValid();

                    if($result)	
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_EDITED);
					else 
						$this->view->mensagens = array(Axs_View_Message::ERROR_EDITING);
				
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->controller->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->controller->getMensagens();
            }

			// Retorna os dados para a tela
			$this->view->assign($this->controller->getData());

        } else {
			// Retorna os dados para a tela
			$this->view->assign($this->controller->loadData());
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
		$this->view->title = 'Exclusão de Controller';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->controller->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::DELETE);

	    // Se todas as validações não contiverem erros
	    if($this->controller->validaDelete()){

		        // Realiza a exclusão do registro na tabela
		        $result = $this->controller->deleteValid($where);

		        if($result){
					// Redireciona para a tela de pesquisa
			    	$this->_redirect("controller/pesquisa/mensagem/exclusao");
				} else {
					$this->view->mensagens = array(Axs_View_Message::ERROR_DELETING);
				}
		} else {
	        // Captura os erros e envia para a tela
	        $this->view->errors = $this->controller->getErros();

	        // Captura as mensagens e envia para a tela
			$this->view->mensagens = $this->controller->getMensagens();
	    }

		// Retorna os dados para a tela
	    $this->view->assign($this->controller->getData());
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
        $this->view->title = 'Pesquisa de Controller';

		// Seta o action da view
		$this->setAction(parent::SEARCH);
		
        // Verifica se o valor do parametro mensagem é igual a exclusao
		if($this->getRequest()->getParam('mensagem') == 'exclusao'){
			$this->view->mensagens = array('Registro excluído com sucesso.');
		}

        // Construção do filtro de pesquisa
        $filtros = array(
							'nameController' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->controller->descriptionFields['nameController'],
                                                	),
							'idController' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->controller->descriptionFields['idController'],
                                                	),
		                    );

        // Modelos relacionados na consulta
        $modelos = array('from' => array('controller' => array('nameController','idController')));

        // Campos a serem exibidos na tela
        $camposTabulacao = array(
								 $this->controller->descriptionFields['nameController'] => array('nameController','left'),
								 $this->controller->descriptionFields['idController'] => array('idController','left'),
								);

        // Links dos registros da página
        $linkRegistros = array(
                                'controle' => 'controller',
                                'action'   => 'edit',
                                'params'   => array('chave' => 'Controller')
                               );

        // Ordenação padrão
        $orderPadrao = array('idController');

				
        // Helper de pesquisa
        $pesquisa = $this->_helper->getHelper('Pesquisa');
        $pesquisa->Pesquisa($modelos, $filtros, $camposTabulacao, $linkRegistros, null, false, $orderPadrao);
    }
}
?>
