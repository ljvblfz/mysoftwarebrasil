<?php

/**
 *
 *
 * @version $Id$
 * @copyright 2011
 */

/** Zend_Controller_Action */
require_once 'Zend/Controller/Action.php';


/**
 * @category   Axs
 * @package    Axs_Controller
 * @copyright
 * @license
 */
class Axs_Controller_Action extends Zend_Controller_Action
{
	/**
	 * Consts for actions
	 */
	const CREATE = "add";
	const EDIT = "edit";
	const DELETE = "delete";
	const SEARCH = "pesquisa";
	
	/**
	* Objeto que define os botoes da tela
	* @var array
	*/
	public $buttons;
	
	
	/**
	    * Initialize View object
	    *
	    * Initializes {@link $view} if not otherwise a Zend_View_Interface.
	    *
	    * If {@link $view} is not otherwise set, instantiates a new Zend_View
	    * object, using the 'views' subdirectory at the same level as the
	    * controller directory for the current module as the base directory.
	    * It uses this to set the following:
	    * - script path = views/scripts/
	    * - helper path = views/helpers/
	    * - filter path = views/filters/
	    *
	    * @return Zend_View_Interface
	    * @throws Zend_Controller_Exception if base view directory does not exist
	    */
	public function initView()
	{
		require_once 'Zend/View/Interface.php';
		require_once 'Zend/View.php';
		$this->view->setLfiProtection(false);
		$this->view->baseUrl = $this->_request->getBaseUrl();
		$this->view->modulo  = $this->getRequest()->getModuleName();
		$this->view->controller  = $this->getRequest()->getControllerName();
		if(!(!$this->getInvokeArg('noViewRenderer') && $this->_helper->hasHelper('viewRenderer'))
				&&
				!(isset($this->view) && ($this->view instanceof Zend_View_Interface))
			){
			$request = $this->getRequest();
			$module  = $request->getModuleName();
			$dirs    = $this->getFrontController()->getControllerDirectory();
			if (empty($module) || !isset($dirs[$module])) {
				$module = $this->getFrontController()->getDispatcher()->getDefaultModule();
			}
			$baseDir = dirname($dirs[$module]) . DIRECTORY_SEPARATOR . 'views';
			if (!file_exists($baseDir) || !is_dir($baseDir)) {
				require_once 'Zend/Controller/Exception.php';
				throw new Zend_Controller_Exception('Missing base view directory ("' . $baseDir . '")');
			}
			$this->view = new Zend_View(array('basePath' => $baseDir));
		}
		$this->addHelpersPath();
		$this->setButton();
		return $this->view;
	}
	
	/**
	* Set controller directory
	*
	* @param array|string $directory
	* @return Zend_Controller_Dispatcher_Standard
	*/
	public function addHelpersPath()
	{
		$cfg = Zend_Registry::get('config');
		foreach ((array) $cfg->resources->view->helperPath->toArray() as $helper => $path) {
			$this->view->addHelperPath($path,$helper);
		}
	}
	
	/**
	* Carrega o objeto que define os botoes da tela
	*
	* @return void
	*/
	private function setButton()
	{
		$this->buttons = new Axs_Controller_Button_ButtonAccount($this);
	}
	
	/**
	* Carrega a action
	*
	* @return void
	*/
	public function setAction($action)
	{
		$this->view->action = $action;
		$this->buttons->status = $action;
		
		if($this->buttons->dbTable == null)
			$this->buttons->dbTable = Axs_Db_Table::getModel($this);
		$this->buttons->save();
	}
}

?>