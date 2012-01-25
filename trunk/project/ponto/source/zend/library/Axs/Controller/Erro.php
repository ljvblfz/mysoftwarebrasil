<?php

class Axs_Controller_Erro {
	
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
	
	/**
	* Metodo de erro
	*
	* @name error
	* @access public
	* @param Zend_Exception
	* @return void
	*/
	public static function error($exception) {
		
		// Formata o erro
		$erro = Axs_ExceptionFormatter::display($exception);
		
		// Verifica se o erro e gravavel no log ou não
		// CODIGO:
		// 0 = Produção grava o erro no log.
		// 1 = Desenvolvivento mostra a mensagem de erro
		// 2 = Hibrido grava o erro no log e mostra a mensagem de erro.
		if (Zend_Registry::get('config')->debug == 1) {
			echo($erro);
		} elseif(Zend_Registry::get('config')->debug == 2){
			self::writeLog($erro);
			echo($erro);
		}else {
			self::writeLog($erro);
			echo("<p>An error occurred with an error!");
		}
	}
	
	/**
	* Metodo de gravar o log de erro
	*
	* @name writeLog
	* @access public
	* @param string
	* @return void
	*/
	private static function writeLog($erro)
	{
		try {
			$log = Zend_Registry::get('log');
			$log->debug($erro);
		}
		catch (Exception $e) {
			// can't log it - display error message
			die("<p>An error occurred with logging an error!");
		}
	}

}
