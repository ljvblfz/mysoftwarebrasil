<?php
error_reporting(E_ALL|E_STRICT);

// Seta o caminho da aplicação
$GLOBALS["root"] = $_SERVER["DOCUMENT_ROOT"];

// Seta o timezone para Fortaleza (Requer PHP >= 5.1)
setlocale (LC_ALL, null);
date_default_timezone_set('America/Fortaleza');

// Adicionando library e models ao path do PHP para este aplicativo
set_include_path(
	'.' .
	PATH_SEPARATOR .$GLOBALS["root"].'\zend\library'.
	PATH_SEPARATOR .$GLOBALS["root"].'\sistemas\redesocial\models'.
	PATH_SEPARATOR .$GLOBALS["root"].'\sistemas\admin\models'.
	PATH_SEPARATOR.get_include_path());
define('NO_PROXY',"localhost, {$_SERVER['HTTP_HOST']}, {$_SERVER['SERVER_NAME']}");

include $GLOBALS["root"].'/zend/application/bootstrap.php';
include $GLOBALS["root"]."/zend/library/Zend/Loader/Autoloader.php";

$autoloader = Zend_Loader_Autoloader::getInstance();
$autoloader->registerNamespace('Axs');
$autoloader->setFallbackAutoloader(true);
$bootstrap = new Bootstrap();
$bootstrap->runApp();
