<?php
class Bootstrap {
    public function __construct()
    {
        include "Zend/Loader.php";

        Zend_Loader::loadClass('Zend_Controller_Front');
        Zend_Loader::loadClass('Zend_Config_Ini');
        Zend_Loader::loadClass('Zend_Registry');
        Zend_Loader::loadClass('Zend_Db');
        Zend_Loader::loadClass('Sabv_Db_Table');
        Zend_Loader::loadClass('Sabv_Util_Float');

        Zend_Loader::loadClass('Zend_Debug');
        Zend_Loader::loadClass('Zend_Auth');
        Zend_Loader::loadClass('Zend_View');
        Zend_Loader::loadClass('Zend_Session_Namespace');
        Zend_Loader::loadClass('Zend_Date');

        Zend_Loader::loadClass('Zend_Log');
        Zend_Loader::loadClass('Zend_Log_Writer_Stream');
        Zend_Loader::loadClass('Zend_Log_Formatter_Simple');

        Zend_Loader::loadClass('Sabv_Acl');
        Zend_Loader::loadClass('Sabv_Util_Permissao');


        //Carrega o arquivo de configurações
        //
        $config = new Zend_Config_Ini('./application/config.ini', 'general');
        $registry = Zend_Registry::getInstance();
        $registry->set('config', $config);

        //Inicia o arquivo de log
		$logFile = $config->logFiles->error;
        $log = new Zend_Log();
        $writer = new Zend_Log_Writer_Stream($logFile);
        $formatter = new Zend_Log_Formatter_Simple('%timestamp% %priorityName% (%priority%): %message%' . PHP_EOL);
        $writer->setFormatter($formatter);
        $log->addWriter($writer);
        $registry->set('log', $log);

        //Seta o path para o Action helper
        Zend_Controller_Action_HelperBroker::addPath('Sabv\Controller\Action\Helper', 'Sabv_Controller_Action_Helper');

        $a =  $config->db->config->toArray();
        $options = array(Zend_Db::CASE_FOLDING => Zend_Db::CASE_LOWER,
		                 Zend_Db::AUTO_QUOTE_IDENTIFIERS => true);
        $a['options']=$options;

		//die(phpinfo());
        // Setup database
        $db = Zend_Db::factory($config->db->adapter, $config->db->config->toArray());
        $db->setFetchMode(Zend_Db::FETCH_OBJ);
        Zend_Db_Table::setDefaultAdapter($db);
        Zend_Registry::set('db', $db);

		$ns = new Zend_Session_Namespace('sabv');
		Zend_Registry::set('ns', $ns);

//       $acl = new Sabv_ACL($db);
//       Zend_Registry::set('acl', $acl);
       //
        //aumenta o session timeout para 1 hora
		$authSession = new Zend_Session_Namespace('Zend_Auth');
        $authSession->setExpirationSeconds(7200);

		//cria sessao para guardar dados do safci e coloca timeou em 60 segundos
		$ns->setExpirationSeconds(7200);
  		$c = $db->fetchRow("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES");

    }

   public function runApp()
    {
        //
		// Setup controller
        $frontController = Zend_Controller_Front::getInstance();
        $frontController->setBaseUrl(substr($_SERVER['PHP_SELF'], 0, strpos($_SERVER['PHP_SELF'], '/index.php')));
        $frontController->throwExceptions(true);
        $frontController->setControllerDirectory('./application/controllers');

        try {
            $frontController->dispatch();
        }
        catch (Exception $exception) {
            // an exception has occurred after the ErrorController's postdispatch() has run
            if (Zend_Registry::get('config')->debug == 1) {
                $msg = $exception->getMessage();
                $trace = $exception->getTraceAsString();
                echo "<div>Error: $msg<p><pre>$trace</pre></p></div>";
            } else {
                try {
                    $log = Zend_Registry::get('log');
                    $log->debug($exception->getMessage() . "\n" . $exception->getTraceAsString() . "\n-----------------------------");
                }
                catch (Exception $e) {
                    // can't log it - display error message
                    die("<p>An error occurred with logging an error!");
                }
            }
        }
    }
}
