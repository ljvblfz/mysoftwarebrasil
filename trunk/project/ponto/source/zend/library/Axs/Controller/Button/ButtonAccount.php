<?php
/**
 * Classe que atualiza o botão
 *
 * @name Axs_Controller_Button_ButtonAccount
 * @author Alexis Moura
 * @package Axs_Controller_Button
 * @version 1.0
 */
class Axs_Controller_Button_ButtonAccount implements Axs_Controller_Button_IButtonObservable {

	/**
	* Status do button
	* @var string
	*/
	public $status;
	
	/**
	* Objeto controller corrente
	* @var Axs_Controller_Action
	*/
	public $controller;
	
	/**
	* Objeto modelo corrente
	* @var Axs_Db_Table
	*/
	public $dbTable;
	
	/**
	* Observers
	* @var array
	*/
	private $_observers = array();

	/**
	* Construtor
	*
	*/
	public function __construct(Axs_Controller_Action $controller)
	{
		$this->attachObserver(new Axs_Controller_Button_ButtonAction());
		$this->controller = $controller;
	}

	/**
	* Adiciona o objeto
	*
	* @name attachObserver
	* @access public
	* @param Axs_Controller_Button_IButtonObserver 
	* @return void
	*/
	public function attachObserver(Axs_Controller_Button_IButtonObserver $object)
	{
		$this->_observers[] = $object;
	}

	/**
	* Remove o objeto
	*
	* @name detachObserver
	* @access public
	* @param Axs_Controller_Button_IButtonObserver 
	* @return void
	*/
	public function detachObserver(Axs_Controller_Button_IButtonObserver $object)
	{
		foreach ($this->_observers as $index => $observer) {
			if ($object == $observer) {
				unset($this->_observers[$index]);
			}
		}
	}

	/**
	* Notifica os objetos da alteraçao
	*
	* @name notify
	* @access public
	* @return void
	*/
	public function notify()
	{
		foreach ($this->_observers as $observer) {
			$observer->update($this);
		}
	}

	/**
	* Salva as alterações
	*
	* @name save
	* @access public
	* @return void
	*/
	public function save()
	{
		$this->notify($this);
		$this->notify();
	}
	
}