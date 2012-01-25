<?php
/**
 * Controle de Contato
 *
 * @name _ContatoController
 * @author Alexis Moura
 * @package _controllers
 * @version 1.0
 */
class ContatoController extends Axs_Controller_Action
{

    /**
     * Objeto do modelo Contato
     *
     * @name $contato
     * @access protected
     * @var object
     */
     protected $contato;


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
        
		$this->contato = new Contato;

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
        $this->view->descricaoCampos = $this->contato->descriptionFields;

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
        $ajuda['idPerfil']['msg'] = '';
		$ajuda['idPerfil']['obrigatorio'] = 0;

        $ajuda['idTipoContato']['msg'] = '';
		$ajuda['idTipoContato']['obrigatorio'] = 0;

        $ajuda['idContato']['msg'] = '';
		$ajuda['idContato']['obrigatorio'] = 0;

        $ajuda['valorContato']['msg'] = '';
		$ajuda['valorContato']['obrigatorio'] = 0;

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
        $this->view->title = 'Cadastro de Contato';

        // Verifica se a chamada do controller foi feita via POST
        if($this->_request->isPost()){

            // Recupera os dados do formulário postado pelo usuário
            $dados = $this->contato->loadFields($this->_request->getParams());

            // Se todas as validações não contiverem erros
            if($this->contato->validaInsert()){

                    // Realiza a inserção dos dados na tabela validando novamente
                    $result = $this->contato->insertValid($dados);

                    if($result){
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_CREATED);
						$this->setAction(parent::EDIT);
                    } else {
  						$this->view->mensagens = array(Axs_View_Message::ERROR_CREATING);
					}
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->contato->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->contato->getMensagens();
            }
			// Retorna os dados para a tela
            $this->view->assign($this->contato->getData());
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
        $this->view->title = 'Edição de Contato';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->contato->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::EDIT);
		
        // Verifica se a chamada do controller foi feita via POST
        if ($this->_request->isPost()){

            // Se todas as validações não contiverem erros
            if($this->contato->validaUpdate()){

					// Realiza a atualização dos dados na tabela validando novamente
                    $result = $this->contato->updateValid();

                    if($result)	
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_EDITED);
					else 
						$this->view->mensagens = array(Axs_View_Message::ERROR_EDITING);
				
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->contato->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->contato->getMensagens();
            }

			// Retorna os dados para a tela
			$this->view->assign($this->contato->getData());

        } else {
			// Retorna os dados para a tela
			$this->view->assign($this->contato->loadData());
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
		$this->view->title = 'Exclusão de Contato';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->contato->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::DELETE);

	    // Se todas as validações não contiverem erros
	    if($this->contato->validaDelete()){

		        // Realiza a exclusão do registro na tabela
		        $result = $this->contato->deleteValid($where);

		        if($result){
					// Redireciona para a tela de pesquisa
			    	$this->_redirect("contato/pesquisa/mensagem/exclusao");
				} else {
					$this->view->mensagens = array(Axs_View_Message::ERROR_DELETING);
				}
		} else {
	        // Captura os erros e envia para a tela
	        $this->view->errors = $this->contato->getErros();

	        // Captura as mensagens e envia para a tela
			$this->view->mensagens = $this->contato->getMensagens();
	    }

		// Retorna os dados para a tela
	    $this->view->assign($this->contato->getData());
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
        $this->view->title = 'Pesquisa de Contato';

		// Seta o action da view
		$this->setAction(parent::SEARCH);
		
        // Verifica se o valor do parametro mensagem é igual a exclusao
		if($this->getRequest()->getParam('mensagem') == 'exclusao'){
			$this->view->mensagens = array('Registro excluído com sucesso.');
		}

        // Construção do filtro de pesquisa
        $filtros = array(
							'idPerfil' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->contato->descriptionFields['idPerfil'],
                                                	),
							'idTipoContato' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->contato->descriptionFields['idTipoContato'],
                                                	),
							'idContato' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->contato->descriptionFields['idContato'],
                                                	),
							'valorContato' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->contato->descriptionFields['valorContato'],
                                                	),
		                    );

        // Modelos relacionados na consulta
        $modelos = array('from' => array('contato' => array('idPerfil','idTipoContato','idContato','valorContato')));

        // Campos a serem exibidos na tela
        $camposTabulacao = array(
								 $this->contato->descriptionFields['idPerfil'] => array('idPerfil','left'),
								 $this->contato->descriptionFields['idTipoContato'] => array('idTipoContato','left'),
								 $this->contato->descriptionFields['idContato'] => array('idContato','left'),
								 $this->contato->descriptionFields['valorContato'] => array('valorContato','left'),
								);

        // Links dos registros da página
        $linkRegistros = array(
                                'controle' => 'contato',
                                'action'   => 'edit',
                                'params'   => array('chave' => 'Contato')
                               );

        // Ordenação padrão
        $orderPadrao = array('idContato');

								
        // Helper de pesquisa
        $pesquisa = $this->_helper->getHelper('Pesquisa');
        $pesquisa->Pesquisa($modelos, $filtros, $camposTabulacao, $linkRegistros, null, false, $orderPadrao);
    }
}
?>