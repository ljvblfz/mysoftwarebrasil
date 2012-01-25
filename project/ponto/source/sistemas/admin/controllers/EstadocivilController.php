<?php
/**
 * Controle de Estadocivil
 *
 * @name _EstadocivilController
 * @author Alexis Moura
 * @package _controllers
 * @version 1.0
 */
class EstadocivilController extends Axs_Controller_Action
{

    /**
     * Objeto do modelo Estadocivil
     *
     * @name $estadocivil
     * @access protected
     * @var object
     */
     protected $estadocivil;


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
        
		$this->estadocivil = new Estadocivil;

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
        $this->view->descricaoCampos = $this->estadocivil->descriptionFields;

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
        $ajuda['idEstadoCivil']['msg'] = '';
		$ajuda['idEstadoCivil']['obrigatorio'] = 0;

        $ajuda['nameEstadoCivil']['msg'] = '';
		$ajuda['nameEstadoCivil']['obrigatorio'] = 0;

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
        $this->view->title = 'Cadastro de Estadocivil';

        // Verifica se a chamada do controller foi feita via POST
        if($this->_request->isPost()){

            // Recupera os dados do formulário postado pelo usuário
            $dados = $this->estadocivil->loadFields($this->_request->getParams());

            // Se todas as validações não contiverem erros
            if($this->estadocivil->validaInsert()){

                    // Realiza a inserção dos dados na tabela validando novamente
                    $result = $this->estadocivil->insertValid($dados);

                    if($result){
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_CREATED);
						$this->setAction(parent::EDIT);
                    } else {
  						$this->view->mensagens = array(Axs_View_Message::ERROR_CREATING);
					}
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->estadocivil->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->estadocivil->getMensagens();
            }
			// Retorna os dados para a tela
            $this->view->assign($this->estadocivil->getData());
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
        $this->view->title = 'Edição de Estadocivil';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->estadocivil->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::EDIT);
		
        // Verifica se a chamada do controller foi feita via POST
        if ($this->_request->isPost()){

            // Se todas as validações não contiverem erros
            if($this->estadocivil->validaUpdate()){

					// Realiza a atualização dos dados na tabela validando novamente
                    $result = $this->estadocivil->updateValid();

                    if($result)	
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_EDITED);
					else 
						$this->view->mensagens = array(Axs_View_Message::ERROR_EDITING);
				
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->estadocivil->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->estadocivil->getMensagens();
            }

			// Retorna os dados para a tela
			$this->view->assign($this->estadocivil->getData());

        } else {
			// Retorna os dados para a tela
			$this->view->assign($this->estadocivil->loadData());
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
		$this->view->title = 'Exclusão de Estadocivil';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->estadocivil->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::DELETE);

	    // Se todas as validações não contiverem erros
	    if($this->estadocivil->validaDelete()){

		        // Realiza a exclusão do registro na tabela
		        $result = $this->estadocivil->deleteValid($where);

		        if($result){
					// Redireciona para a tela de pesquisa
			    	$this->_redirect("estadocivil/pesquisa/mensagem/exclusao");
				} else {
					$this->view->mensagens = array(Axs_View_Message::ERROR_DELETING);
				}
		} else {
	        // Captura os erros e envia para a tela
	        $this->view->errors = $this->estadocivil->getErros();

	        // Captura as mensagens e envia para a tela
			$this->view->mensagens = $this->estadocivil->getMensagens();
	    }

		// Retorna os dados para a tela
	    $this->view->assign($this->estadocivil->getData());
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
        $this->view->title = 'Pesquisa de Estadocivil';

		// Seta o action da view
		$this->setAction(parent::SEARCH);
		
        // Verifica se o valor do parametro mensagem é igual a exclusao
		if($this->getRequest()->getParam('mensagem') == 'exclusao'){
			$this->view->mensagens = array('Registro excluído com sucesso.');
		}

        // Construção do filtro de pesquisa
        $filtros = array(
							'idEstadoCivil' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->estadocivil->descriptionFields['idEstadoCivil'],
                                                	),
							'nameEstadoCivil' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->estadocivil->descriptionFields['nameEstadoCivil'],
                                                	),
		                    );

        // Modelos relacionados na consulta
        $modelos = array('from' => array('estadocivil' => array('idEstadoCivil','nameEstadoCivil')));

        // Campos a serem exibidos na tela
        $camposTabulacao = array(
								 $this->estadocivil->descriptionFields['idEstadoCivil'] => array('idEstadoCivil','left'),
								 $this->estadocivil->descriptionFields['nameEstadoCivil'] => array('nameEstadoCivil','left'),
								);

        // Links dos registros da página
        $linkRegistros = array(
                                'controle' => 'estadocivil',
                                'action'   => 'edit',
                                'params'   => array('chave' => 'Estadocivil')
                               );

        // Ordenação padrão
        $orderPadrao = array('idEstadoCivil');

				
        // Helper de pesquisa
        $pesquisa = $this->_helper->getHelper('Pesquisa');
        $pesquisa->Pesquisa($modelos, $filtros, $camposTabulacao, $linkRegistros, null, false, $orderPadrao);
    }
}
?>