<?php
/**
 * Controle de Bairro
 *
 * @name _BairroController
 * @author Alexis Moura
 * @package _controllers
 * @version 1.0
 */
class BairroController extends Axs_Controller_Action
{

    /**
     * Objeto do modelo Bairro
     *
     * @name $bairro
     * @access protected
     * @var object
     */
     protected $bairro;


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
        
		$this->bairro = new Bairro;

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
        $this->view->descricaoCampos = $this->bairro->descriptionFields;

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
        $ajuda['nomeBairro']['msg'] = '';
		$ajuda['nomeBairro']['obrigatorio'] = 0;

        $ajuda['idBairro']['msg'] = '';
		$ajuda['idBairro']['obrigatorio'] = 0;

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
        $this->view->title = 'Cadastro de Bairro';

        // Verifica se a chamada do controller foi feita via POST
        if($this->_request->isPost()){

            // Recupera os dados do formulário postado pelo usuário
            $dados = $this->bairro->loadFields($this->_request->getParams());

            // Se todas as validações não contiverem erros
            if($this->bairro->validaInsert()){

                    // Realiza a inserção dos dados na tabela validando novamente
                    $result = $this->bairro->insertValid($dados);

                    if($result){
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_CREATED);
						$this->setAction(parent::EDIT);
                    } else {
  						$this->view->mensagens = array(Axs_View_Message::ERROR_CREATING);
					}
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->bairro->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->bairro->getMensagens();
            }
			// Retorna os dados para a tela
            $this->view->assign($this->bairro->getData());
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
        $this->view->title = 'Edição de Bairro';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->bairro->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::EDIT);
		
        // Verifica se a chamada do controller foi feita via POST
        if ($this->_request->isPost()){

            // Se todas as validações não contiverem erros
            if($this->bairro->validaUpdate()){

					// Realiza a atualização dos dados na tabela validando novamente
                    $result = $this->bairro->updateValid();

                    if($result)	
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_EDITED);
					else 
						$this->view->mensagens = array(Axs_View_Message::ERROR_EDITING);
				
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->bairro->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->bairro->getMensagens();
            }

			// Retorna os dados para a tela
			$this->view->assign($this->bairro->getData());

        } else {
			// Retorna os dados para a tela
			$this->view->assign($this->bairro->loadData());
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
		$this->view->title = 'Exclusão de Bairro';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->bairro->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::DELETE);

	    // Se todas as validações não contiverem erros
	    if($this->bairro->validaDelete()){

		        // Realiza a exclusão do registro na tabela
		        $result = $this->bairro->deleteValid($where);

		        if($result){
					// Redireciona para a tela de pesquisa
			    	$this->_redirect("bairro/pesquisa/mensagem/exclusao");
				} else {
					$this->view->mensagens = array(Axs_View_Message::ERROR_DELETING);
				}
		} else {
	        // Captura os erros e envia para a tela
	        $this->view->errors = $this->bairro->getErros();

	        // Captura as mensagens e envia para a tela
			$this->view->mensagens = $this->bairro->getMensagens();
	    }

		// Retorna os dados para a tela
	    $this->view->assign($this->bairro->getData());
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
        $this->view->title = 'Pesquisa de Bairro';

		// Seta o action da view
		$this->setAction(parent::SEARCH);
		
        // Verifica se o valor do parametro mensagem é igual a exclusao
		if($this->getRequest()->getParam('mensagem') == 'exclusao'){
			$this->view->mensagens = array('Registro excluído com sucesso.');
		}

        // Construção do filtro de pesquisa
        $filtros = array(
							'nomeBairro' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->bairro->descriptionFields['nomeBairro'],
                                                	),
							'idBairro' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->bairro->descriptionFields['idBairro'],
                                                	),
		                    );

        // Modelos relacionados na consulta
        $modelos = array('from' => array('bairro' => array('nomeBairro','idBairro')));

        // Campos a serem exibidos na tela
        $camposTabulacao = array(
								 $this->bairro->descriptionFields['nomeBairro'] => array('nomeBairro','left'),
								 $this->bairro->descriptionFields['idBairro'] => array('idBairro','left'),
								);

        // Links dos registros da página
        $linkRegistros = array(
                                'controle' => 'bairro',
                                'action'   => 'edit',
                                'params'   => array('chave' => 'Bairro')
                               );

        // Ordenação padrão
        $orderPadrao = array('idBairro');

				
        // Helper de pesquisa
        $pesquisa = $this->_helper->getHelper('Pesquisa');
        $pesquisa->Pesquisa($modelos, $filtros, $camposTabulacao, $linkRegistros, null, false, $orderPadrao);
    }
}
?>