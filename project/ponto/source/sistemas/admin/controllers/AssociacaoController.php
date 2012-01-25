<?php
/**
 * Controle de Associacao
 *
 * @name _AssociacaoController
 * @author Alexis Moura
 * @package _controllers
 * @version 1.0
 */
class AssociacaoController extends Axs_Controller_Action
{

    /**
     * Objeto do modelo Associacao
     *
     * @name $associacao
     * @access protected
     * @var object
     */
     protected $associacao;


    /**
     * M�todo init da classe.
     *
     * @name init
     * @access public
     * @return void
     */
    function init()
	{
        $this->initView();
        
		$this->associacao = new Associacao;

        // Seta valores pr�-determinados para os campos da view
		$this->carregaValoresView();
    }

    /**
     * M�todo que realiza a verifica��o de login do usu�rio.
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
     * M�todo respons�vel pelo carregamento de todos os campos combobox, radio, checkbox e outros.
     *
     * @name carregaValoresView
     * @access public
     * @return void
     */
    function carregaValoresView()
    {
        // Carrega a descri��o dos campos
        $this->view->descricaoCampos = $this->associacao->descriptionFields;

        // Carrega a ajuda
        $this->carregaAjuda();
    }

    /**
	 * Fun��o respons�vel por carregar o texto das tooltips do formul�rio.
	 *
	 * @name carregaAjuda
	 * @access public
	 * @return void
	 */
	function carregaAjuda()
	{
        $ajuda['idTipoAssociacao']['msg'] = '';
		$ajuda['idTipoAssociacao']['obrigatorio'] = 0;

        $ajuda['idMembro']['msg'] = '';
		$ajuda['idMembro']['obrigatorio'] = 0;

        $ajuda['idPessoa']['msg'] = '';
		$ajuda['idPessoa']['obrigatorio'] = 0;

        $ajuda['idAssociacao']['msg'] = '';
		$ajuda['idAssociacao']['obrigatorio'] = 0;

	    $this->view->assign('ajuda', $ajuda);
	}

	/**
     * M�todo principal da classe.
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
     * M�todo respons�vel pela opera��o de inser��o de dados no banco.
     *
     * @name addAction
     * @access public
     * @return void
     */
    function addAction()
    {
        // Seta o action da view e o T�tulo da p�gina
        $this->setAction(parent::CREATE);
        $this->view->title = 'Cadastro de Associacao';

        // Verifica se a chamada do controller foi feita via POST
        if($this->_request->isPost()){

            // Recupera os dados do formul�rio postado pelo usu�rio
            $dados = $this->associacao->loadFields($this->_request->getParams());

            // Se todas as valida��es n�o contiverem erros
            if($this->associacao->validaInsert()){

                    // Realiza a inser��o dos dados na tabela validando novamente
                    $result = $this->associacao->insertValid($dados);

                    if($result){
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_CREATED);
						$this->setAction(parent::EDIT);
                    } else {
  						$this->view->mensagens = array(Axs_View_Message::ERROR_CREATING);
					}
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->associacao->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->associacao->getMensagens();
            }
			// Retorna os dados para a tela
            $this->view->assign($this->associacao->getData());
        }

        $this->render();
	}

    /**
     * M�todo respons�vel pela opera��o de atualiza��o de dados no banco.
     *
     * @name editAction
     * @access public
     * @return void
     */
    function editAction()
    {
        // Seta o action da view e o T�tulo da p�gina
        $this->view->title = 'Edi��o de Associacao';
		
        // Recupera os dados do formul�rio postado pelo usu�rio
        $this->associacao->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::EDIT);
		
        // Verifica se a chamada do controller foi feita via POST
        if ($this->_request->isPost()){

            // Se todas as valida��es n�o contiverem erros
            if($this->associacao->validaUpdate()){

					// Realiza a atualiza��o dos dados na tabela validando novamente
                    $result = $this->associacao->updateValid();

                    if($result)	
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_EDITED);
					else 
						$this->view->mensagens = array(Axs_View_Message::ERROR_EDITING);
				
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->associacao->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->associacao->getMensagens();
            }

			// Retorna os dados para a tela
			$this->view->assign($this->associacao->getData());

        } else {
			// Retorna os dados para a tela
			$this->view->assign($this->associacao->loadData());
        }
        $this->render();
    }

    /**
     * M�todo respons�vel pela opera��o de exclus�o de dados no banco.
     *
     * @name deleteAction
     * @access public
     * @return void
     */
    function deleteAction()
    {
        // Seta o action da view e o T�tulo da p�gina
		$this->view->title = 'Exclus�o de Associacao';
		
        // Recupera os dados do formul�rio postado pelo usu�rio
        $this->associacao->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::DELETE);

	    // Se todas as valida��es n�o contiverem erros
	    if($this->associacao->validaDelete()){

		        // Realiza a exclus�o do registro na tabela
		        $result = $this->associacao->deleteValid($where);

		        if($result){
					// Redireciona para a tela de pesquisa
			    	$this->_redirect("associacao/pesquisa/mensagem/exclusao");
				} else {
					$this->view->mensagens = array(Axs_View_Message::ERROR_DELETING);
				}
		} else {
	        // Captura os erros e envia para a tela
	        $this->view->errors = $this->associacao->getErros();

	        // Captura as mensagens e envia para a tela
			$this->view->mensagens = $this->associacao->getMensagens();
	    }

		// Retorna os dados para a tela
	    $this->view->assign($this->associacao->getData());
    	$this->render();
	}

    /**
     * M�todo respons�vel pela opera��o de pesquisa de dados no banco.
     *
     * @name pesquisaAction
     * @access public
     * @return void
     */
    function pesquisaAction()
    {
        // Seta o t�tulo da pesquisa
        $this->view->title = 'Pesquisa de Associacao';

		// Seta o action da view
		$this->setAction(parent::SEARCH);
		
        // Verifica se o valor do parametro mensagem � igual a exclusao
		if($this->getRequest()->getParam('mensagem') == 'exclusao'){
			$this->view->mensagens = array('Registro exclu�do com sucesso.');
		}

        // Constru��o do filtro de pesquisa
        $filtros = array(
							'idTipoAssociacao' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->associacao->descriptionFields['idTipoAssociacao'],
                                                	),
							'idMembro' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->associacao->descriptionFields['idMembro'],
                                                	),
							'idPessoa' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->associacao->descriptionFields['idPessoa'],
                                                	),
							'idAssociacao' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->associacao->descriptionFields['idAssociacao'],
                                                	),
		                    );

        // Modelos relacionados na consulta
        $modelos = array('from' => array('associacao' => array('idTipoAssociacao','idMembro','idPessoa','idAssociacao')));

        // Campos a serem exibidos na tela
        $camposTabulacao = array(
								 $this->associacao->descriptionFields['idTipoAssociacao'] => array('idTipoAssociacao','left'),
								 $this->associacao->descriptionFields['idMembro'] => array('idMembro','left'),
								 $this->associacao->descriptionFields['idPessoa'] => array('idPessoa','left'),
								 $this->associacao->descriptionFields['idAssociacao'] => array('idAssociacao','left'),
								);

        // Links dos registros da p�gina
        $linkRegistros = array(
                                'controle' => 'associacao',
                                'action'   => 'edit',
                                'params'   => array('chave' => 'Associacao')
                               );

        // Ordena��o padr�o
        $orderPadrao = array('idAssociacao');

								
        // Helper de pesquisa
        $pesquisa = $this->_helper->getHelper('Pesquisa');
        $pesquisa->Pesquisa($modelos, $filtros, $camposTabulacao, $linkRegistros, null, false, $orderPadrao);
    }
}
?>