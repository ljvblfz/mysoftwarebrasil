<?php
/**
 * Controle de Tipointeresse
 *
 * @name _TipointeresseController
 * @author Alexis Moura
 * @package _controllers
 * @version 1.0
 */
class TipointeresseController extends Axs_Controller_Action
{

    /**
     * Objeto do modelo Tipointeresse
     *
     * @name $tipointeresse
     * @access protected
     * @var object
     */
     protected $tipointeresse;


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
        
		$this->tipointeresse = new Tipointeresse;

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
        $this->view->descricaoCampos = $this->tipointeresse->descriptionFields;

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
        $ajuda['idTipoInteresse']['msg'] = '';
		$ajuda['idTipoInteresse']['obrigatorio'] = 0;

        $ajuda['nameTipoInteresse']['msg'] = '';
		$ajuda['nameTipoInteresse']['obrigatorio'] = 0;

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
        $this->view->title = 'Cadastro de Tipointeresse';

        // Verifica se a chamada do controller foi feita via POST
        if($this->_request->isPost()){

            // Recupera os dados do formulário postado pelo usuário
            $dados = $this->tipointeresse->loadFields($this->_request->getParams());

            // Se todas as validações não contiverem erros
            if($this->tipointeresse->validaInsert()){

                    // Realiza a inserção dos dados na tabela validando novamente
                    $result = $this->tipointeresse->insertValid($dados);

                    if($result){
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_CREATED);
						$this->setAction(parent::EDIT);
                    } else {
  						$this->view->mensagens = array(Axs_View_Message::ERROR_CREATING);
					}
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->tipointeresse->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->tipointeresse->getMensagens();
            }
			// Retorna os dados para a tela
            $this->view->assign($this->tipointeresse->getData());
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
        $this->view->title = 'Edição de Tipointeresse';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->tipointeresse->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::EDIT);
		
        // Verifica se a chamada do controller foi feita via POST
        if ($this->_request->isPost()){

            // Se todas as validações não contiverem erros
            if($this->tipointeresse->validaUpdate()){

					// Realiza a atualização dos dados na tabela validando novamente
                    $result = $this->tipointeresse->updateValid();

                    if($result)	
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_EDITED);
					else 
						$this->view->mensagens = array(Axs_View_Message::ERROR_EDITING);
				
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->tipointeresse->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->tipointeresse->getMensagens();
            }

			// Retorna os dados para a tela
			$this->view->assign($this->tipointeresse->getData());

        } else {
			// Retorna os dados para a tela
			$this->view->assign($this->tipointeresse->loadData());
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
		$this->view->title = 'Exclusão de Tipointeresse';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->tipointeresse->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::DELETE);

	    // Se todas as validações não contiverem erros
	    if($this->tipointeresse->validaDelete()){

		        // Realiza a exclusão do registro na tabela
		        $result = $this->tipointeresse->deleteValid($where);

		        if($result){
					// Redireciona para a tela de pesquisa
			    	$this->_redirect("tipointeresse/pesquisa/mensagem/exclusao");
				} else {
					$this->view->mensagens = array(Axs_View_Message::ERROR_DELETING);
				}
		} else {
	        // Captura os erros e envia para a tela
	        $this->view->errors = $this->tipointeresse->getErros();

	        // Captura as mensagens e envia para a tela
			$this->view->mensagens = $this->tipointeresse->getMensagens();
	    }

		// Retorna os dados para a tela
	    $this->view->assign($this->tipointeresse->getData());
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
        $this->view->title = 'Pesquisa de Tipointeresse';

		// Seta o action da view
		$this->setAction(parent::SEARCH);
		
        // Verifica se o valor do parametro mensagem é igual a exclusao
		if($this->getRequest()->getParam('mensagem') == 'exclusao'){
			$this->view->mensagens = array('Registro excluído com sucesso.');
		}

        // Construção do filtro de pesquisa
        $filtros = array(
							'idTipoInteresse' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->tipointeresse->descriptionFields['idTipoInteresse'],
                                                	),
							'nameTipoInteresse' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->tipointeresse->descriptionFields['nameTipoInteresse'],
                                                	),
		                    );

        // Modelos relacionados na consulta
        $modelos = array('from' => array('tipointeresse' => array('idTipoInteresse','nameTipoInteresse')));

        // Campos a serem exibidos na tela
        $camposTabulacao = array(
								 $this->tipointeresse->descriptionFields['idTipoInteresse'] => array('idTipoInteresse','left'),
								 $this->tipointeresse->descriptionFields['nameTipoInteresse'] => array('nameTipoInteresse','left'),
								);

        // Links dos registros da página
        $linkRegistros = array(
                                'controle' => 'tipointeresse',
                                'action'   => 'edit',
                                'params'   => array('chave' => 'Tipointeresse')
                               );

        // Ordenação padrão
        $orderPadrao = array('idTipoInteresse');

				
        // Helper de pesquisa
        $pesquisa = $this->_helper->getHelper('Pesquisa');
        $pesquisa->Pesquisa($modelos, $filtros, $camposTabulacao, $linkRegistros, null, false, $orderPadrao);
    }
}
?>
