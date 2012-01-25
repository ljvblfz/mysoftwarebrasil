<?php

require_once 'Zend/Controller/Front.php';
require_once 'Zend/Controller/Request/Http.php';


class Axs_Controller_Front extends Zend_Controller_Front
{
    /**
     * Singleton instance
     *
     * @return Zend_Controller_Front
     */
    public static function getInstance()
    {
        if (null === self::$_instance) {
            self::$_instance = new self();
        }

        return self::$_instance;
    }

    /**
     * Dispatch an HTTP request to a membrer/id.
     *
     * @return void|Zend_Controller_Response_Abstract Returns response object if returnResponse() is true
     */
    public function dispatchMember()
    {

        $request = new Zend_Controller_Request_Http();
		$this->setRequest($request);
		$membroNickName = explode("/",$request->get("REDIRECT_URL"));

		if(count($membroNickName)>1){
			if($membroNickName[1]=="favicon.ico")
				return 0;
			$db = Zend_Registry::get("db");
			$select = $db->select()
				->from(array('M'=>"membro"),array("idMembro"))
				->where("M.loginMembro = ?",$membroNickName[1]);
			$result = $db->fetchRow($select);

			if($result instanceof stdClass){
				$url = base64_encode("idMembro")."/".base64_encode($result->idmembro);
				header("Location: {$request->getBaseUrl()}membro/perfil/{$url}");
			}
		}
		$this->dispatch();
    }
	
	/**
	* Set controller directory
	*
	* @param array|string $directory
	* @return Zend_Controller_Dispatcher_Standard
	*/
	public function addModuleDirectory($directory)
	{
		$this->_controllerDirectory = array();
		
		foreach ((array) $directory as $module => $path) {
			$this->addControllerDirectory($GLOBALS["root"].$path, $module);
		}
		return $this;
	}
}
