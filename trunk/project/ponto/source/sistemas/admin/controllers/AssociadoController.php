<?php
/**
 * Controle de Associado
 *
 * @name _AssociadoController
 * @author Alexis Moura
 * @package _controllers
 * @version 1.0
 */
class AssociadoController extends Axs_Controller_Action
{

    /**
     * Objeto do modelo Associado
     *
     * @name $associado
     * @access protected
     * @var object
     */
     protected $associado;


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
        
		$this->associado = new Associado;

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
        $this->view->descricaoCampos = $this->associado->descriptionFields;

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
        $ajuda['idMembro']['msg'] = '';
		$ajuda['idMembro']['obrigatorio'] = 0;

        $ajuda['idAssociacao']['msg'] = '';
		$ajuda['idAssociacao']['obrigatorio'] = 0;

        $ajuda['idAssociado']['msg'] = '';
		$ajuda['idAssociado']['obrigatorio'] = 0;

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
        $this->view->title = 'Cadastro de Associado';

        // Verifica se a chamada do controller foi feita via POST
        if($this->_request->isPost()){

            // Recupera os dados do formulário postado pelo usuário
            $dados = $this->associado->loadFields($this->_request->getParams());

            // Se todas as validações não contiverem erros
            if($this->associado->validaInsert()){

                    // Realiza a inserção dos dados na tabela validando novamente
                    $result = $this->associado->insertValid($dados);

                    if($result){
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_CREATED);
						$this->setAction(parent::EDIT);
                    } else {
  						$this->view->mensagens = array(Axs_View_Message::ERROR_CREATING);
					}
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->associado->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->associado->getMensagens();
            }
			// Retorna os dados para a tela
            $this->view->assign($this->associado->getData());
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
        $this->view->title = 'Edição de Associado';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->associado->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::EDIT);
		
        // Verifica se a chamada do controller foi feita via POST
        if ($this->_request->isPost()){

            // Se todas as validações não contiverem erros
            if($this->associado->validaUpdate()){

					// Realiza a atualização dos dados na tabela validando novamente
                    $result = $this->associado->updateValid();

                    if($result)	
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_EDITED);
					else 
						$this->view->mensagens = array(Axs_View_Message::ERROR_EDITING);
				
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->associado->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->associado->getMensagens();
            }

			// Retorna os dados para a tela
			$this->view->assign($this->associado->getData());

        } else {
			// Retorna os dados para a tela
			$this->view->assign($this->associado->loadData());
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
		$this->view->title = 'Exclusão de Associado';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->associado->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::DELETE);

	    // Se todas as validações não contiverem erros
	    if($this->associado->validaDelete()){

		        // Realiza a exclusão do registro na tabela
		        $result = $this->associado->deleteValid($where);

		        if($result){
					// Redireciona para a tela de pesquisa
			    	$this->_redirect("associado/pesquisa/mensagem/exclusao");
				} else {
					$this->view->mensagens = array(Axs_View_Message::ERROR_DELETING);
				}
		} else {
	        // Captura os erros e envia para a tela
	        $this->view->errors = $this->associado->getErros();

	        // Captura as mensagens e envia para a tela
			$this->view->mensagens = $this->associado->getMensagens();
	    }

		// Retorna os dados para a tela
	    $this->view->assign($this->associado->getData());
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
        $this->view->title = 'Pesquisa de Associado';

		// Seta o action da view
		$this->setAction(parent::SEARCH);
		
        // Verifica se o valor do parametro mensagem é igual a exclusao
		if($this->getRequest()->getParam('mensagem') == 'exclusao'){
			$this->view->mensagens = array('Registro excluído com sucesso.');
		}

        // Construção do filtro de pesquisa
        $filtros = array(
							'idMembro' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->associado->descriptionFields['idMembro'],
                                                	),
							'idAssociacao' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->associado->descriptionFields['idAssociacao'],
                                                	),
							'idAssociado' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->associado->descriptionFields['idAssociado'],
                                                	),
		                    );

        // Modelos relacionados na consulta
        $modelos = array('from' => array('associado' => array('idMembro','idAssociacao','idAssociado')));

        // Campos a serem exibidos na tela
        $camposTabulacao = array(
								 $this->associado->descriptionFields['idMembro'] => array('idMembro','left'),
								 $this->associado->descriptionFields['idAssociacao'] => array('idAssociacao','left'),
								 $this->associado->descriptionFields['idAssociado'] => array('idAssociado','left'),
								);

        // Links dos registros da página
        $linkRegistros = array(
                                'controle' => 'associado',
                                'action'   => 'edit',
                                'params'   => array('chave' => 'Associado')
                               );

        // Ordenação padrão
        $orderPadrao = array('idAssociado');

						
        // Helper de pesquisa
        $pesquisa = $this->_helper->getHelper('Pesquisa');
        $pesquisa->Pesquisa($modelos, $filtros, $camposTabulacao, $linkRegistros, null, false, $orderPadrao);
    }
}
?>