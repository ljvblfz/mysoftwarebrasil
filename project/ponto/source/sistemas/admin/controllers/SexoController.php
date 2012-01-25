<?php
/**
 * Controle de Sexo
 *
 * @name _SexoController
 * @author Alexis Moura
 * @package _controllers
 * @version 1.0
 */
class SexoController extends Axs_Controller_Action
{

    /**
     * Objeto do modelo Sexo
     *
     * @name $sexo
     * @access protected
     * @var object
     */
     protected $sexo;


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
        
		$this->sexo = new Sexo;

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
        $this->view->descricaoCampos = $this->sexo->descriptionFields;

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
        $ajuda['idSexo']['msg'] = '';
		$ajuda['idSexo']['obrigatorio'] = 0;

        $ajuda['nameSexo']['msg'] = '';
		$ajuda['nameSexo']['obrigatorio'] = 0;

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
        $this->view->title = 'Cadastro de Sexo';

        // Verifica se a chamada do controller foi feita via POST
        if($this->_request->isPost()){

            // Recupera os dados do formul�rio postado pelo usu�rio
            $dados = $this->sexo->loadFields($this->_request->getParams());

            // Se todas as valida��es n�o contiverem erros
            if($this->sexo->validaInsert()){

                    // Realiza a inser��o dos dados na tabela validando novamente
                    $result = $this->sexo->insertValid($dados);

                    if($result){
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_CREATED);
						$this->setAction(parent::EDIT);
                    } else {
  						$this->view->mensagens = array(Axs_View_Message::ERROR_CREATING);
					}
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->sexo->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->sexo->getMensagens();
            }
			// Retorna os dados para a tela
            $this->view->assign($this->sexo->getData());
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
        $this->view->title = 'Edi��o de Sexo';
		
        // Recupera os dados do formul�rio postado pelo usu�rio
        $this->sexo->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::EDIT);
		
        // Verifica se a chamada do controller foi feita via POST
        if ($this->_request->isPost()){

            // Se todas as valida��es n�o contiverem erros
            if($this->sexo->validaUpdate()){

					// Realiza a atualiza��o dos dados na tabela validando novamente
                    $result = $this->sexo->updateValid();

                    if($result)	
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_EDITED);
					else 
						$this->view->mensagens = array(Axs_View_Message::ERROR_EDITING);
				
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->sexo->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->sexo->getMensagens();
            }

			// Retorna os dados para a tela
			$this->view->assign($this->sexo->getData());

        } else {
			// Retorna os dados para a tela
			$this->view->assign($this->sexo->loadData());
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
		$this->view->title = 'Exclus�o de Sexo';
		
        // Recupera os dados do formul�rio postado pelo usu�rio
        $this->sexo->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::DELETE);

	    // Se todas as valida��es n�o contiverem erros
	    if($this->sexo->validaDelete()){

		        // Realiza a exclus�o do registro na tabela
		        $result = $this->sexo->deleteValid($where);

		        if($result){
					// Redireciona para a tela de pesquisa
			    	$this->_redirect("sexo/pesquisa/mensagem/exclusao");
				} else {
					$this->view->mensagens = array(Axs_View_Message::ERROR_DELETING);
				}
		} else {
	        // Captura os erros e envia para a tela
	        $this->view->errors = $this->sexo->getErros();

	        // Captura as mensagens e envia para a tela
			$this->view->mensagens = $this->sexo->getMensagens();
	    }

		// Retorna os dados para a tela
	    $this->view->assign($this->sexo->getData());
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
        $this->view->title = 'Pesquisa de Sexo';

		// Seta o action da view
		$this->setAction(parent::SEARCH);
		
        // Verifica se o valor do parametro mensagem � igual a exclusao
		if($this->getRequest()->getParam('mensagem') == 'exclusao'){
			$this->view->mensagens = array('Registro exclu�do com sucesso.');
		}

        // Constru��o do filtro de pesquisa
        $filtros = array(
							'idSexo' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->sexo->descriptionFields['idSexo'],
                                                	),
							'nameSexo' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->sexo->descriptionFields['nameSexo'],
                                                	),
		                    );

        // Modelos relacionados na consulta
        $modelos = array('from' => array('sexo' => array('idSexo','nameSexo')));

        // Campos a serem exibidos na tela
        $camposTabulacao = array(
								 $this->sexo->descriptionFields['idSexo'] => array('idSexo','left'),
								 $this->sexo->descriptionFields['nameSexo'] => array('nameSexo','left'),
								);

        // Links dos registros da p�gina
        $linkRegistros = array(
                                'controle' => 'sexo',
                                'action'   => 'edit',
                                'params'   => array('chave' => 'Sexo')
                               );

        // Ordena��o padr�o
        $orderPadrao = array('idSexo');

				
        // Helper de pesquisa
        $pesquisa = $this->_helper->getHelper('Pesquisa');
        $pesquisa->Pesquisa($modelos, $filtros, $camposTabulacao, $linkRegistros, null, false, $orderPadrao);
    }
}
?>