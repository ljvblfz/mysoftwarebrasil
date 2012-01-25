<?php
/**
 * Controle de Erro
 *
 * @name ErroController
 * @author Alexis Moura
 * @package _controllers
 * @version 1.0
 */
class ErroController extends Axs_Controller_Action{
	
	/**
	* Metodo chamado quando o controller é inicializado
	*
	* @name init
	* @access public
	* @return void
	*/
	function init()
	{
		$this->initView();
	}
	
	public function errorAction() {
		
		$erroObj = new Axs_ExceptionFormatter();
		$this->oldHandler    = set_error_handler(array($this, "catchMyErrors"));

		// The ExpectionFormatter requires access to a couple of protected 
		// items so the must be passed in explicitly. The 3rd param 
		// controls wether or not the stack trace contains interactive source 
		// code. When enabled browser performance is degradded. It will default
		// to false if the 3rd param is not provided
		$erroObj->display(
			$this->_getParam('error_handler'),
			$this->_helper,
			true
			);
	}

}
