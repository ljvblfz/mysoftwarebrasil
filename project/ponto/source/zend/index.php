<?php
error_reporting(E_ALL|E_STRICT);

// Seta o timezone para Fortaleza (Requer PHP >= 5.1)
setlocale (LC_ALL, null);
date_default_timezone_set('America/Fortaleza');

// Adicionando library e models ao path do PHP para este aplicativo
set_include_path(
					'.' .
					PATH_SEPARATOR .'./zend/library'.
					PATH_SEPARATOR .'./sistemas/redesocial/models/'.
					PATH_SEPARATOR .'./sistemas/admin/models/'.
					PATH_SEPARATOR.get_include_path());
define('NO_PROXY',"localhost, {$_SERVER['HTTP_HOST']}, {$_SERVER['SERVER_NAME']}, {$_SERVER['SERVER_ADDR']}");

include '../zend/application/bootstrap.php';

include "../zend/library/Zend/Loader.php";
$bootstrap = new Bootstrap();
$bootstrap->runApp();
