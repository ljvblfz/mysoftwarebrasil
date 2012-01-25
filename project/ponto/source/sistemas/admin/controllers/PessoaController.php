<?php
/**
 * Controle de Pessoa
 *
 * @name _PessoaController
 * @author Alexis Moura
 * @package _controllers
 * @version 1.0
 */
class PessoaController extends Axs_Controller_Action
{

    /**
     * Objeto do modelo Pessoa
     *
     * @name $pessoa
     * @access protected
     * @var object
     */
     protected $pessoa;


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
        
		$this->pessoa = new Pessoa;

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
        $this->view->descricaoCampos = $this->pessoa->descriptionFields;

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
        $ajuda['nomePessoa']['msg'] = '';
		$ajuda['nomePessoa']['obrigatorio'] = 0;

        $ajuda['e_MailPessoa']['msg'] = '';
		$ajuda['e_MailPessoa']['obrigatorio'] = 0;

        $ajuda['nascimentoPessoa']['msg'] = '';
		$ajuda['nascimentoPessoa']['obrigatorio'] = 0;

        $ajuda['idPerfil']['msg'] = '';
		$ajuda['idPerfil']['obrigatorio'] = 0;

        $ajuda['idPessoa']['msg'] = '';
		$ajuda['idPessoa']['obrigatorio'] = 0;

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
        $this->view->title = 'Cadastro de Pessoa';

        // Verifica se a chamada do controller foi feita via POST
        if($this->_request->isPost()){

            // Recupera os dados do formulário postado pelo usuário
            $dados = $this->pessoa->loadFields($this->_request->getParams());

            // Se todas as validações não contiverem erros
            if($this->pessoa->validaInsert()){

                    // Realiza a inserção dos dados na tabela validando novamente
                    $result = $this->pessoa->insertValid($dados);

                    if($result){
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_CREATED);
						$this->setAction(parent::EDIT);
                    } else {
  						$this->view->mensagens = array(Axs_View_Message::ERROR_CREATING);
					}
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->pessoa->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->pessoa->getMensagens();
            }
			// Retorna os dados para a tela
            $this->view->assign($this->pessoa->getData());
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
        $this->view->title = 'Edição de Pessoa';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->pessoa->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::EDIT);
		
        // Verifica se a chamada do controller foi feita via POST
        if ($this->_request->isPost()){

            // Se todas as validações não contiverem erros
            if($this->pessoa->validaUpdate()){

					// Realiza a atualização dos dados na tabela validando novamente
                    $result = $this->pessoa->updateValid();

                    if($result)	
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_EDITED);
					else 
						$this->view->mensagens = array(Axs_View_Message::ERROR_EDITING);
				
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->pessoa->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->pessoa->getMensagens();
            }

			// Retorna os dados para a tela
			$this->view->assign($this->pessoa->getData());

        } else {
			// Retorna os dados para a tela
			$this->view->assign($this->pessoa->loadData());
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
		$this->view->title = 'Exclusão de Pessoa';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->pessoa->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::DELETE);

	    // Se todas as validações não contiverem erros
	    if($this->pessoa->validaDelete()){

		        // Realiza a exclusão do registro na tabela
		        $result = $this->pessoa->deleteValid($where);

		        if($result){
					// Redireciona para a tela de pesquisa
			    	$this->_redirect("pessoa/pesquisa/mensagem/exclusao");
				} else {
					$this->view->mensagens = array(Axs_View_Message::ERROR_DELETING);
				}
		} else {
	        // Captura os erros e envia para a tela
	        $this->view->errors = $this->pessoa->getErros();

	        // Captura as mensagens e envia para a tela
			$this->view->mensagens = $this->pessoa->getMensagens();
	    }

		// Retorna os dados para a tela
	    $this->view->assign($this->pessoa->getData());
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
        $this->view->title = 'Pesquisa de Pessoa';

		// Seta o action da view
		$this->setAction(parent::SEARCH);
		
        // Verifica se o valor do parametro mensagem é igual a exclusao
		if($this->getRequest()->getParam('mensagem') == 'exclusao'){
			$this->view->mensagens = array('Registro excluído com sucesso.');
		}

        // Construção do filtro de pesquisa
        $filtros = array(
							'nomePessoa' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->pessoa->descriptionFields['nomePessoa'],
                                                	),
							'e_MailPessoa' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->pessoa->descriptionFields['e_MailPessoa'],
                                                	),
							'nascimentoPessoa' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->pessoa->descriptionFields['nascimentoPessoa'],
                                                	),
							'idPerfil' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->pessoa->descriptionFields['idPerfil'],
                                                	),
							'idPessoa' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->pessoa->descriptionFields['idPessoa'],
                                                	),
		                    );

        // Modelos relacionados na consulta
        $modelos = array('from' => array('pessoa' => array('nomePessoa','e_MailPessoa','nascimentoPessoa','idPerfil','idPessoa')));

        // Campos a serem exibidos na tela
        $camposTabulacao = array(
								 $this->pessoa->descriptionFields['nomePessoa'] => array('nomePessoa','left'),
								 $this->pessoa->descriptionFields['e_MailPessoa'] => array('e_MailPessoa','left'),
								 $this->pessoa->descriptionFields['nascimentoPessoa'] => array('nascimentoPessoa','left'),
								 $this->pessoa->descriptionFields['idPerfil'] => array('idPerfil','left'),
								 $this->pessoa->descriptionFields['idPessoa'] => array('idPessoa','left'),
								);

        // Links dos registros da página
        $linkRegistros = array(
                                'controle' => 'pessoa',
                                'action'   => 'edit',
                                'params'   => array('chave' => 'Pessoa')
                               );

        // Ordenação padrão
        $orderPadrao = array('idPessoa');

										
        // Helper de pesquisa
        $pesquisa = $this->_helper->getHelper('Pesquisa');
        $pesquisa->Pesquisa($modelos, $filtros, $camposTabulacao, $linkRegistros, null, false, $orderPadrao);
    }
}
?>
