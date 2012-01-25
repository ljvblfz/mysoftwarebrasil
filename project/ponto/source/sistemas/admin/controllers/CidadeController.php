<?php
/**
 * Controle de Cidade
 *
 * @name _CidadeController
 * @author Alexis Moura
 * @package _controllers
 * @version 1.0
 */
class CidadeController extends Axs_Controller_Action
{

    /**
     * Objeto do modelo Cidade
     *
     * @name $cidade
     * @access protected
     * @var object
     */
     protected $cidade;


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
        
		$this->cidade = new Cidade;

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
		if($this->_request->getParam("action") != "getCidades")
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
        $this->view->descricaoCampos = $this->cidade->descriptionFields;

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
        $ajuda['nameCidade']['msg'] = '';
		$ajuda['nameCidade']['obrigatorio'] = 0;

        $ajuda['idEstado']['msg'] = '';
		$ajuda['idEstado']['obrigatorio'] = 0;

        $ajuda['idCidade']['msg'] = '';
		$ajuda['idCidade']['obrigatorio'] = 0;

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
        $this->view->title = 'Cadastro de Cidade';

        // Verifica se a chamada do controller foi feita via POST
        if($this->_request->isPost()){

            // Recupera os dados do formulário postado pelo usuário
            $dados = $this->cidade->loadFields($this->_request->getParams());

            // Se todas as validações não contiverem erros
            if($this->cidade->validaInsert()){

                    // Realiza a inserção dos dados na tabela validando novamente
                    $result = $this->cidade->insertValid($dados);

                    if($result){
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_CREATED);
						$this->setAction(parent::EDIT);
                    } else {
  						$this->view->mensagens = array(Axs_View_Message::ERROR_CREATING);
					}
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->cidade->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->cidade->getMensagens();
            }
			// Retorna os dados para a tela
            $this->view->assign($this->cidade->getData());
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
        $this->view->title = 'Edição de Cidade';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->cidade->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::EDIT);
		
        // Verifica se a chamada do controller foi feita via POST
        if ($this->_request->isPost()){

            // Se todas as validações não contiverem erros
            if($this->cidade->validaUpdate()){

					// Realiza a atualização dos dados na tabela validando novamente
                    $result = $this->cidade->updateValid();

                    if($result)	
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_EDITED);
					else 
						$this->view->mensagens = array(Axs_View_Message::ERROR_EDITING);
				
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->cidade->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->cidade->getMensagens();
            }

			// Retorna os dados para a tela
			$this->view->assign($this->cidade->getData());

        } else {
			// Retorna os dados para a tela
			$this->view->assign($this->cidade->loadData());
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
		$this->view->title = 'Exclusão de Cidade';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->cidade->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::DELETE);

	    // Se todas as validações não contiverem erros
	    if($this->cidade->validaDelete()){

		        // Realiza a exclusão do registro na tabela
		        $result = $this->cidade->deleteValid($where);

		        if($result){
					// Redireciona para a tela de pesquisa
			    	$this->_redirect("cidade/pesquisa/mensagem/exclusao");
				} else {
					$this->view->mensagens = array(Axs_View_Message::ERROR_DELETING);
				}
		} else {
	        // Captura os erros e envia para a tela
	        $this->view->errors = $this->cidade->getErros();

	        // Captura as mensagens e envia para a tela
			$this->view->mensagens = $this->cidade->getMensagens();
	    }

		// Retorna os dados para a tela
	    $this->view->assign($this->cidade->getData());
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
        $this->view->title = 'Pesquisa de Cidade';

		// Seta o action da view
		$this->setAction(parent::SEARCH);
		
        // Verifica se o valor do parametro mensagem é igual a exclusao
		if($this->getRequest()->getParam('mensagem') == 'exclusao'){
			$this->view->mensagens = array('Registro excluído com sucesso.');
		}

        // Construção do filtro de pesquisa
        $filtros = array(
							'nameCidade' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->cidade->descriptionFields['nameCidade'],
                                                	),
							'idEstado' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->cidade->descriptionFields['idEstado'],
                                                	),
							'idCidade' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->cidade->descriptionFields['idCidade'],
                                                	),
		                    );

        // Modelos relacionados na consulta
        $modelos = array('from' => array('cidade' => array('nameCidade','idEstado','idCidade')));

        // Campos a serem exibidos na tela
        $camposTabulacao = array(
								 $this->cidade->descriptionFields['nameCidade'] => array('nameCidade','left'),
								 $this->cidade->descriptionFields['idEstado'] => array('idEstado','left'),
								 $this->cidade->descriptionFields['idCidade'] => array('idCidade','left'),
								);

        // Links dos registros da página
        $linkRegistros = array(
                                'controle' => 'cidade',
                                'action'   => 'edit',
                                'params'   => array('chave' => 'Cidade')
                               );

        // Ordenação padrão
        $orderPadrao = array('idCidade');

						
        // Helper de pesquisa
        $pesquisa = $this->_helper->getHelper('Pesquisa');
        $pesquisa->Pesquisa($modelos, $filtros, $camposTabulacao, $linkRegistros, null, false, $orderPadrao);
    }
	
	/**
	* Método responsável pelo retorno das cidades.
	*
	* @name getCidadesAction
	* @access public
	* @return void
	*/
	public function getcidadesAction()
	{
		$dados = $this->_request->getParams();
		$result = $this->cidade->getCidade($dados['name']);
		echo Zend_Json::encode($result);
		$this->_helper->viewRenderer->setNoRender();
	}
	
}
?>
