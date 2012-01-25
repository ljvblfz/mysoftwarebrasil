<?php
class Bootstrap {
	
	/**
	* Construtor
	*	Utiliza o altoLoader
	*
	* @name __construct
	* @return void
	*/
    public function __construct()
    {
        //Carrega o arquivo de configurações
		$config = new Zend_Config_Ini($GLOBALS["root"].'/zend/application/config.ini', 'general');
		
        $registry = Zend_Registry::getInstance();
        $registry->set('config', $config);

        //Inicia o arquivo de log
		$logFile = $GLOBALS["root"].$config->logFiles->error;
        $log = new Zend_Log();
        $writer = new Zend_Log_Writer_Stream($logFile);
        $formatter = new Zend_Log_Formatter_Simple('%timestamp% %priorityName% (%priority%): %message%' . PHP_EOL);
        $writer->setFormatter($formatter);
        $log->addWriter($writer);
        $registry->set('log', $log);

        //Seta o path para o Action helper
        Zend_Controller_Action_HelperBroker::addPath('Axs/Controller/Action/Helper/', 'Axs_Controller_Action_Helper');

        $a =  $config->db->config->toArray();
        $options = array(Zend_Db::CASE_FOLDING => Zend_Db::CASE_NATURAL,
		                 Zend_Db::AUTO_QUOTE_IDENTIFIERS => true);
        $a['options']=$options;
        // Setup database
        $db = Zend_Db::factory($config->db->adapter, $a);
        $db->setFetchMode(Zend_Db::FETCH_OBJ);
        Zend_Db_Table::setDefaultAdapter($db);
        Zend_Registry::set('db', $db);

		$ns = new Zend_Session_Namespace('safci');
		Zend_Registry::set('ns', $ns);

        $acl = new Axs_ACL($db);
        Zend_Registry::set('acl', $acl);

        //aumenta o session timeout para 1 hora
		$authSession = new Zend_Session_Namespace('Zend_Auth');
        $authSession->setExpirationSeconds(3600);

		//cria sessao para guardar dados do safci e coloca timeou em 60 segundos
		$ns->setExpirationSeconds(3600);
    }

    public function runApp()
    {
    	// Setup controller
		$frontController = Axs_Controller_Front::getInstance();
        $cfg = Zend_Registry::get('config');
        $frontController->setBaseUrl($cfg->base->url);
		$frontController->throwExceptions(true);
		
		$frontController->setControllerDirectory($GLOBALS["root"].$cfg->system->default,"default");
		$frontController->addModuleDirectory($cfg->system->modulo->toArray());
		try {
			$frontController->dispatchMember();
        }
		catch (Zend_Exception $exception) {
			Axs_Controller_Erro::error($exception);
        }
    }
}
