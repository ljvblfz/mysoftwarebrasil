<?php
/**
 * Controle de Membro
 *
 * @name _MembroController
 * @author Alexis Moura
 * @package _controllers
 * @version 1.0
 */
class MembroController extends Axs_Controller_Action
{

    /**
     * Objeto do modelo Membro
     *
     * @name $membro
     * @access protected
     * @var object
     */
     protected $membro;


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
        
		$this->membro = new Membro;

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
        $this->view->descricaoCampos = $this->membro->descriptionFields;

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
        $ajuda['loginMembro']['msg'] = '';
		$ajuda['loginMembro']['obrigatorio'] = 0;

        $ajuda['senhaMembro']['msg'] = '';
		$ajuda['senhaMembro']['obrigatorio'] = 0;

        $ajuda['idPessoa']['msg'] = '';
		$ajuda['idPessoa']['obrigatorio'] = 0;

        $ajuda['idRole']['msg'] = '';
		$ajuda['idRole']['obrigatorio'] = 0;

        $ajuda['idMembro']['msg'] = '';
		$ajuda['idMembro']['obrigatorio'] = 0;

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
        $this->view->title = 'Cadastro de Membro';

        // Verifica se a chamada do controller foi feita via POST
        if($this->_request->isPost()){

            // Recupera os dados do formulário postado pelo usuário
            $dados = $this->membro->loadFields($this->_request->getParams());

            // Se todas as validações não contiverem erros
            if($this->membro->validaInsert()){

                    // Realiza a inserção dos dados na tabela validando novamente
                    $result = $this->membro->insertValid($dados);

                    if($result){
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_CREATED);
						$this->setAction(parent::EDIT);
                    } else {
  						$this->view->mensagens = array(Axs_View_Message::ERROR_CREATING);
					}
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->membro->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->membro->getMensagens();
            }
			// Retorna os dados para a tela
            $this->view->assign($this->membro->getData());
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
        $this->view->title = 'Edição de Membro';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->membro->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::EDIT);
		
        // Verifica se a chamada do controller foi feita via POST
        if ($this->_request->isPost()){

            // Se todas as validações não contiverem erros
            if($this->membro->validaUpdate()){

					// Realiza a atualização dos dados na tabela validando novamente
                    $result = $this->membro->updateValid();

                    if($result)	
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_EDITED);
					else 
						$this->view->mensagens = array(Axs_View_Message::ERROR_EDITING);
				
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->membro->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->membro->getMensagens();
            }

			// Retorna os dados para a tela
			$this->view->assign($this->membro->getData());

        } else {
			// Retorna os dados para a tela
			$this->view->assign($this->membro->loadData());
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
		$this->view->title = 'Exclusão de Membro';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->membro->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::DELETE);

	    // Se todas as validações não contiverem erros
	    if($this->membro->validaDelete()){

		        // Realiza a exclusão do registro na tabela
		        $result = $this->membro->deleteValid($where);

		        if($result){
					// Redireciona para a tela de pesquisa
			    	$this->_redirect("membro/pesquisa/mensagem/exclusao");
				} else {
					$this->view->mensagens = array(Axs_View_Message::ERROR_DELETING);
				}
		} else {
	        // Captura os erros e envia para a tela
	        $this->view->errors = $this->membro->getErros();

	        // Captura as mensagens e envia para a tela
			$this->view->mensagens = $this->membro->getMensagens();
	    }

		// Retorna os dados para a tela
	    $this->view->assign($this->membro->getData());
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
        $this->view->title = 'Pesquisa de Membro';

		// Seta o action da view
		$this->setAction(parent::SEARCH);
		
        // Verifica se o valor do parametro mensagem é igual a exclusao
		if($this->getRequest()->getParam('mensagem') == 'exclusao'){
			$this->view->mensagens = array('Registro excluído com sucesso.');
		}

        // Construção do filtro de pesquisa
        $filtros = array(
							'loginMembro' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->membro->descriptionFields['loginMembro'],
                                                	),
							'senhaMembro' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->membro->descriptionFields['senhaMembro'],
                                                	),
							'idPessoa' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->membro->descriptionFields['idPessoa'],
                                                	),
							'idRole' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->membro->descriptionFields['idRole'],
                                                	),
							'idMembro' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->membro->descriptionFields['idMembro'],
                                                	),
		                    );

        // Modelos relacionados na consulta
        $modelos = array('from' => array('membro' => array('loginMembro','senhaMembro','idPessoa','idRole','idMembro')));

        // Campos a serem exibidos na tela
        $camposTabulacao = array(
								 $this->membro->descriptionFields['loginMembro'] => array('loginMembro','left'),
								 $this->membro->descriptionFields['senhaMembro'] => array('senhaMembro','left'),
								 $this->membro->descriptionFields['idPessoa'] => array('idPessoa','left'),
								 $this->membro->descriptionFields['idRole'] => array('idRole','left'),
								 $this->membro->descriptionFields['idMembro'] => array('idMembro','left'),
								);

        // Links dos registros da página
        $linkRegistros = array(
                                'controle' => 'membro',
                                'action'   => 'edit',
                                'params'   => array('chave' => 'Membro')
                               );

        // Ordenação padrão
        $orderPadrao = array('idMembro');

										
        // Helper de pesquisa
        $pesquisa = $this->_helper->getHelper('Pesquisa');
        $pesquisa->Pesquisa($modelos, $filtros, $camposTabulacao, $linkRegistros, null, false, $orderPadrao);
    }
}
?>