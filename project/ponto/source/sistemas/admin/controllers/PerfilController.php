<?php
/**
 * Controle de Perfil
 *
 * @name _PerfilController
 * @author Alexis Moura
 * @package _controllers
 * @version 1.0
 */
class PerfilController extends Axs_Controller_Action
{

    /**
     * Objeto do modelo Perfil
     *
     * @name $perfil
     * @access protected
     * @var object
     */
     protected $perfil;


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
        
		$this->perfil = new Perfil;

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
        $this->view->descricaoCampos = $this->perfil->descriptionFields;

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

        $ajuda['idOlho']['msg'] = '';
		$ajuda['idOlho']['obrigatorio'] = 0;

        $ajuda['idCabelo']['msg'] = '';
		$ajuda['idCabelo']['obrigatorio'] = 0;

        $ajuda['idEtinia']['msg'] = '';
		$ajuda['idEtinia']['obrigatorio'] = 0;

        $ajuda['idEstadoCivil']['msg'] = '';
		$ajuda['idEstadoCivil']['obrigatorio'] = 0;

        $ajuda['idEndereco']['msg'] = '';
		$ajuda['idEndereco']['obrigatorio'] = 0;

        $ajuda['idPerfil']['msg'] = '';
		$ajuda['idPerfil']['obrigatorio'] = 0;

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
        $this->view->title = 'Cadastro de Perfil';

        // Verifica se a chamada do controller foi feita via POST
        if($this->_request->isPost()){

            // Recupera os dados do formul�rio postado pelo usu�rio
            $dados = $this->perfil->loadFields($this->_request->getParams());

            // Se todas as valida��es n�o contiverem erros
            if($this->perfil->validaInsert()){

                    // Realiza a inser��o dos dados na tabela validando novamente
                    $result = $this->perfil->insertValid($dados);

                    if($result){
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_CREATED);
						$this->setAction(parent::EDIT);
                    } else {
  						$this->view->mensagens = array(Axs_View_Message::ERROR_CREATING);
					}
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->perfil->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->perfil->getMensagens();
            }
			// Retorna os dados para a tela
            $this->view->assign($this->perfil->getData());
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
        $this->view->title = 'Edi��o de Perfil';
		
        // Recupera os dados do formul�rio postado pelo usu�rio
        $this->perfil->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::EDIT);
		
        // Verifica se a chamada do controller foi feita via POST
        if ($this->_request->isPost()){

            // Se todas as valida��es n�o contiverem erros
            if($this->perfil->validaUpdate()){

					// Realiza a atualiza��o dos dados na tabela validando novamente
                    $result = $this->perfil->updateValid();

                    if($result)	
						$this->view->mensagens = array(Axs_View_Message::SUCCESSFULLY_EDITED);
					else 
						$this->view->mensagens = array(Axs_View_Message::ERROR_EDITING);
				
            } else {
                // Captura os erros e envia para a tela
                $this->view->errors = $this->perfil->getErros();

                // Captura as mensagens e envia para a tela
				$this->view->mensagens = $this->perfil->getMensagens();
            }

			// Retorna os dados para a tela
			$this->view->assign($this->perfil->getData());

        } else {
			// Retorna os dados para a tela
			$this->view->assign($this->perfil->loadData());
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
		$this->view->title = 'Exclus�o de Perfil';
		
        // Recupera os dados do formul�rio postado pelo usu�rio
        $this->perfil->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::DELETE);

	    // Se todas as valida��es n�o contiverem erros
	    if($this->perfil->validaDelete()){

		        // Realiza a exclus�o do registro na tabela
		        $result = $this->perfil->deleteValid($where);

		        if($result){
					// Redireciona para a tela de pesquisa
			    	$this->_redirect("perfil/pesquisa/mensagem/exclusao");
				} else {
					$this->view->mensagens = array(Axs_View_Message::ERROR_DELETING);
				}
		} else {
	        // Captura os erros e envia para a tela
	        $this->view->errors = $this->perfil->getErros();

	        // Captura as mensagens e envia para a tela
			$this->view->mensagens = $this->perfil->getMensagens();
	    }

		// Retorna os dados para a tela
	    $this->view->assign($this->perfil->getData());
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
        $this->view->title = 'Pesquisa de Perfil';

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
                                                	'descricao' => $this->perfil->descriptionFields['idSexo'],
                                                	),
							'idOlho' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->perfil->descriptionFields['idOlho'],
                                                	),
							'idCabelo' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->perfil->descriptionFields['idCabelo'],
                                                	),
							'idEtinia' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->perfil->descriptionFields['idEtinia'],
                                                	),
							'idEstadoCivil' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->perfil->descriptionFields['idEstadoCivil'],
                                                	),
							'idEndereco' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->perfil->descriptionFields['idEndereco'],
                                                	),
							'idPerfil' => array('tipo_campo'=> 'text',
                                                 	'tipo_dado' => 'string',
                                                	'descricao' => $this->perfil->descriptionFields['idPerfil'],
                                                	),
		                    );

        // Modelos relacionados na consulta
        $modelos = array('from' => array('perfil' => array('idSexo','idOlho','idCabelo','idEtinia','idEstadoCivil','idEndereco','idPerfil')));

        // Campos a serem exibidos na tela
        $camposTabulacao = array(
								 $this->perfil->descriptionFields['idSexo'] => array('idSexo','left'),
								 $this->perfil->descriptionFields['idOlho'] => array('idOlho','left'),
								 $this->perfil->descriptionFields['idCabelo'] => array('idCabelo','left'),
								 $this->perfil->descriptionFields['idEtinia'] => array('idEtinia','left'),
								 $this->perfil->descriptionFields['idEstadoCivil'] => array('idEstadoCivil','left'),
								 $this->perfil->descriptionFields['idEndereco'] => array('idEndereco','left'),
								 $this->perfil->descriptionFields['idPerfil'] => array('idPerfil','left'),
								);

        // Links dos registros da p�gina
        $linkRegistros = array(
                                'controle' => 'perfil',
                                'action'   => 'edit',
                                'params'   => array('chave' => 'Perfil')
                               );

        // Ordena��o padr�o
        $orderPadrao = array('idPerfil');

														
        // Helper de pesquisa
        $pesquisa = $this->_helper->getHelper('Pesquisa');
        $pesquisa->Pesquisa($modelos, $filtros, $camposTabulacao, $linkRegistros, null, false, $orderPadrao);
    }
}
?>
