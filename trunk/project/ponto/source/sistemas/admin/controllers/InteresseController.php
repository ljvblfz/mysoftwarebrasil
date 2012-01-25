<?php
/**
 * Controle de Interesse
 *
 * @name _InteresseController
 * @author Alexis Moura
 * @package _controllers
 * @version 1.0
 */
class InteresseController extends Axs_Controller_Action
{

    /**
     * Objeto do modelo Interesse
     *
     * @name $interesse
     * @access protected
     * @var object
     */
     protected $interesse;


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
        
		$this->interesse = new Interesse;

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
        $this->view->descricaoCampos = $this->interesse->descriptionFields;

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
        $ajuda['Descricao']['msg'] = '';
		$ajuda['Descricao']['obrigatorio'] = 0;

        $ajuda['idTipoInteresse']['msg'] = '';
		$ajuda['idTipoInteresse']['obrigatorio'] = 0;

        $ajuda['idPerfil']['msg'] = '';
		$ajuda['idPerfil']['obrigatorio'] = 0;

        $ajuda['idInteresse']['msg'] = '';
		$ajuda['idInteresse']['obrigatorio'] = 0;

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
        $this->view->title = 'Cadastro de Interesse';

        // Verifica se a chamada do controller foi feita via POST
        if($this->_request->isPost()){

            // Recupera os dados do formulário postado pelo usuário
            $dados = $this->interesse->loadFields($this->_request->getParams());

            // Se todas as validações não contiverem erros
            if($this->interesse->validaInsert()){

                    // Realiza a inserção dos dados na tabela validando novamente
                    $result = $this->interesse->insertValid($dados);

                    if($result){
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_CREATED);
						$this->setAction(parent::EDIT);
                    } else {
  						$this->view->mensagens = array(Axs_View_Message::ERROR_CREATING);
					}
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->interesse->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->interesse->getMensagens();
            }
			// Retorna os dados para a tela
            $this->view->assign($this->interesse->getData());
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
        $this->view->title = 'Edição de Interesse';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->interesse->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::EDIT);
		
        // Verifica se a chamada do controller foi feita via POST
        if ($this->_request->isPost()){

            // Se todas as validações não contiverem erros
            if($this->interesse->validaUpdate()){

					// Realiza a atualização dos dados na tabela validando novamente
                    $result = $this->interesse->updateValid();

                    if($result)	
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_EDITED);
					else 
						$this->view->mensagens = array(Axs_View_Message::ERROR_EDITING);
				
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->interesse->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->interesse->getMensagens();
            }

			// Retorna os dados para a tela
			$this->view->assign($this->interesse->getData());

        } else {
			// Retorna os dados para a tela
			$this->view->assign($this->interesse->loadData());
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
		$this->view->title = 'Exclusão de Interesse';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->interesse->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::DELETE);

	    // Se todas as validações não contiverem erros
	    if($this->interesse->validaDelete()){

		        // Realiza a exclusão do registro na tabela
		        $result = $this->interesse->deleteValid($where);

		        if($result){
					// Redireciona para a tela de pesquisa
			    	$this->_redirect("interesse/pesquisa/mensagem/exclusao");
				} else {
					$this->view->mensagens = array(Axs_View_Message::ERROR_DELETING);
				}
		} else {
	        // Captura os erros e envia para a tela
	        $this->view->errors = $this->interesse->getErros();

	        // Captura as mensagens e envia para a tela
			$this->view->mensagens = $this->interesse->getMensagens();
	    }

		// Retorna os dados para a tela
	    $this->view->assign($this->interesse->getData());
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
        $this->view->title = 'Pesquisa de Interesse';

		// Seta o action da view
		$this->setAction(parent::SEARCH);
		
        // Verifica se o valor do parametro mensagem é igual a exclusao
		if($this->getRequest()->getParam('mensagem') == 'exclusao'){
			$this->view->mensagens = array('Registro excluído com sucesso.');
		}

        // Construção do filtro de pesquisa
        $filtros = array(
							'Descricao' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->interesse->descriptionFields['Descricao'],
                                                	),
							'idTipoInteresse' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->interesse->descriptionFields['idTipoInteresse'],
                                                	),
							'idPerfil' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->interesse->descriptionFields['idPerfil'],
                                                	),
							'idInteresse' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->interesse->descriptionFields['idInteresse'],
                                                	),
		                    );

        // Modelos relacionados na consulta
        $modelos = array('from' => array('interesse' => array('Descricao','idTipoInteresse','idPerfil','idInteresse')));

        // Campos a serem exibidos na tela
        $camposTabulacao = array(
								 $this->interesse->descriptionFields['Descricao'] => array('Descricao','left'),
								 $this->interesse->descriptionFields['idTipoInteresse'] => array('idTipoInteresse','left'),
								 $this->interesse->descriptionFields['idPerfil'] => array('idPerfil','left'),
								 $this->interesse->descriptionFields['idInteresse'] => array('idInteresse','left'),
								);

        // Links dos registros da página
        $linkRegistros = array(
                                'controle' => 'interesse',
                                'action'   => 'edit',
                                'params'   => array('chave' => 'Interesse')
                               );

        // Ordenação padrão
        $orderPadrao = array('idInteresse');

								
        // Helper de pesquisa
        $pesquisa = $this->_helper->getHelper('Pesquisa');
        $pesquisa->Pesquisa($modelos, $filtros, $camposTabulacao, $linkRegistros, null, false, $orderPadrao);
    }
}
?>
