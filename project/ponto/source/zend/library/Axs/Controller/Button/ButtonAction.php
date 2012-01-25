<?php
/**
 * Classe que atualiza o bot�o com a modifica��o da action
 *
 * @name Axs_Controller_Button_ButtonAction
 * @author Alexis Moura
 * @package Axs_Controller_Button
 * @version 1.0
 */
class Axs_Controller_Button_ButtonAction implements Axs_Controller_Button_IButtonObserver
{
	/**
	* Bot�o salvar
	* @var array
	*/
	private $saveButton = array(
		'nome' => 'acao',
		'tipo' => 'submit'
		);
	
	/**
	* Bot�o deletar
	* @var array
	*/
	private $deleteButton = array(
		'nome'      => 'acao',
		'tipo'      => 'button',
		);
	
	/**
	* Bot�o pesquisar
	* @var array
	*/
	private $searchButton = array(
		'nome'    => 'acao',
		'tipo'    => 'button',
		);
	
	/**
	* Bot�o criar
	* @var array
	*/
	private $createButton = array(
		'nome'    => 'acao',
		'tipo'    => 'button',
		);
	
	/**
	* Fun��o respons�vel por setar os links de destino dos botoes.
	*
	* @name loadButtonDestination
	* @access private
	* @return void
	*/
	private function loadButtonDestination(Axs_Controller_Button_IButtonObservable $subject)
	{
		$url = '|module|/|controller|/|action|';
		$param = "";
		
		// link de redirecionamento
		$link = str_replace("|module|",$subject->controller->getRequest()->getModuleName(),
				str_replace("|controller|",$subject->controller->getRequest()->getControllerName(),$url));
		
		// parametros da url no formato do zend
		if($subject->dbTable != null){
			$param = $subject->dbTable->getWhere($subject->dbTable->getData(),1);
		}
		
		// adiciona o link de destino a cada um do botoes
		$this->deleteButton["destino"] = str_replace("|action|",Axs_Controller_Action::DELETE, $link).$param;
		$this->createButton["destino"] = str_replace("|action|",Axs_Controller_Action::CREATE,$link);
		$this->searchButton["destino"] = str_replace("|action|",Axs_Controller_Action::SEARCH,$link);
	}
	
	/**
	* Fun��o respons�vel por atualizaro os botoes.
	*
	* @name update
	* @access public
	* @return void
	*/
	public function update(Axs_Controller_Button_IButtonObservable $subject)
	{
		//array de botoes
		$button = array();
		$this->loadButtonDestination($subject);
		
		// adiciona os botoes de acordo com a action
		if(strtolower($subject->status) == "pesquisa"){
			$button["Novo"] = $this->createButton;
		}
		else if(strtolower($subject->status) == "add"){
			$button["Salvar"] = $this->saveButton;
			$button["Pesquisar"] = $this->searchButton;
		}
		else if(strtolower($subject->status) == "edit" || strtolower($subject->status) == "delete"){
			$button["Salvar"] = $this->saveButton;
			$button["Excluir"] = $this->deleteButton;
			$button["Pesquisar"] = $this->searchButton;
			$button["Novo"] = $this->createButton;
		}
		
		// seta o bot�o na view
		$subject->controller->view->botao_submit = $button;
	}
	
}
