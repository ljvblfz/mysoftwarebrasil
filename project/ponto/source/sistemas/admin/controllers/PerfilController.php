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
     * Método init da classe.
     *
     * @name init
     * @access public
     * @return void
     */
    function init()
	{
        $this->initView();
        
		$this->perfil = new Perfil;

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
        $this->view->descricaoCampos = $this->perfil->descriptionFields;

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
        $this->view->title = 'Cadastro de Perfil';

        // Verifica se a chamada do controller foi feita via POST
        if($this->_request->isPost()){

            // Recupera os dados do formulário postado pelo usuário
            $dados = $this->perfil->loadFields($this->_request->getParams());

            // Se todas as validações não contiverem erros
            if($this->perfil->validaInsert()){

                    // Realiza a inserção dos dados na tabela validando novamente
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
     * Método responsável pela operação de atualização de dados no banco.
     *
     * @name editAction
     * @access public
     * @return void
     */
    function editAction()
    {
        // Seta o action da view e o Título da página
        $this->view->title = 'Edição de Perfil';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->perfil->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::EDIT);
		
        // Verifica se a chamada do controller foi feita via POST
        if ($this->_request->isPost()){

            // Se todas as validações não contiverem erros
            if($this->perfil->validaUpdate()){

					// Realiza a atualização dos dados na tabela validando novamente
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
     * Método responsável pela operação de exclusão de dados no banco.
     *
     * @name deleteAction
     * @access public
     * @return void
     */
    function deleteAction()
    {
        // Seta o action da view e o Título da página
		$this->view->title = 'Exclusão de Perfil';
		
        // Recupera os dados do formulário postado pelo usuário
        $this->perfil->loadFields($this->_request->getParams());
		
		// Seta o action da view
		$this->setAction(parent::DELETE);

	    // Se todas as validações não contiverem erros
	    if($this->perfil->validaDelete()){

		        // Realiza a exclusão do registro na tabela
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
     * Método responsável pela operação de pesquisa de dados no banco.
     *
     * @name pesquisaAction
     * @access public
     * @return void
     */
    function pesquisaAction()
    {
        // Seta o título da pesquisa
        $this->view->title = 'Pesquisa de Perfil';

		// Seta o action da view
		$this->setAction(parent::SEARCH);
		
        // Verifica se o valor do parametro mensagem é igual a exclusao
		if($this->getRequest()->getParam('mensagem') == 'exclusao'){
			$this->view->mensagens = array('Registro excluído com sucesso.');
		}

        // Construção do filtro de pesquisa
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

        // Links dos registros da página
        $linkRegistros = array(
                                'controle' => 'perfil',
                                'action'   => 'edit',
                                'params'   => array('chave' => 'Perfil')
                               );

        // Ordenação padrão
        $orderPadrao = array('idPerfil');

														
        // Helper de pesquisa
        $pesquisa = $this->_helper->getHelper('Pesquisa');
        $pesquisa->Pesquisa($modelos, $filtros, $camposTabulacao, $linkRegistros, null, false, $orderPadrao);
    }
}
?>
