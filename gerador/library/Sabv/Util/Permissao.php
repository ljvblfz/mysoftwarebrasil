<?php

class Sabv_Util_Permissao{


     private static function getBaseUrl(){
         return substr($_SERVER['PHP_SELF'], 0, strpos($_SERVER['PHP_SELF'], '/index.php'));
         }


     private static function getViewPath(){
         return substr($_SERVER['SCRIPT_FILENAME'], 0, strpos($_SERVER['SCRIPT_FILENAME'], '/index.php')) . '/application/views/';
         }


     private static function getAcl(){
         return Zend_Registry :: get('acl');
         }


     private static function getRole(){
         return Zend_Auth :: getInstance() -> getIdentity() -> US_ROLE;
         }


     private static function getMatricula(){
         return Zend_Auth :: getInstance() -> getIdentity() -> US_MATRICULA;
         }


     public static function verificaLeitura($rotina, $destino = ""){
         if (self :: getAcl() -> isAllowed(self :: getRole(), $rotina, 'consultar')){
             return true;
             }
        else{
             $msg = 'O usuário <b>' . self :: getMatricula() . '</b> não tem permissão de leitura para a Rotina <b>' . $rotina . '</b>!';
             Zend_Loader :: loadClass('Zend_View');
             $view = new Zend_View();
             $view -> setBasePath(self :: getViewPath());
             $view -> assign('baseUrl', self :: getBaseUrl());
             $view -> assign('dialogo', true);
             $view -> assign('destino', self :: getBaseUrl() . $destino);
             $view -> assign('tipoMsg', 'erro');
             $view -> assign('botoes', $view -> formSubmit('confirma', 'Ok', array('class' => 'btn')));
             $view -> assign('mensagemDialogo', $msg);
             $view -> assign('title', 'Permissão Negada');
             echo $view -> render('dialogopermissao.phtml');
             die();
             }
         }


     public static function verificaInclusao($rotina, $destino = ""){
         if (self :: getAcl() -> isAllowed(self :: getRole(), $rotina, 'incluir')){
             return true;
             }
        else{
             $msg = 'O usuário <b>' . self :: getMatricula() . '</b> não tem permissão de inclusão para a Rotina <b>' . $rotina . '</b>!';
             Zend_Loader :: loadClass('Zend_View');
             $view = new Zend_View();
             $view -> setBasePath(self :: getViewPath());
             $view -> assign('baseUrl', self :: getBaseUrl());
             $view -> assign('dialogo', true);
             $view -> assign('destino', self :: getBaseUrl() . $destino);
             $view -> assign('tipoMsg', 'erro');
             $view -> assign('botoes', $view -> formSubmit('confirma', 'Ok', array('class' => 'btn')));
             $view -> assign('mensagemDialogo', $msg);
             $view -> assign('title', 'Permissão Negada');
             echo $view -> render('dialogopermissao.phtml');
             die();
             }
         }


     public static function verificaExclusao($rotina, $destino = ""){
         if (self :: getAcl() -> isAllowed(self :: getRole(), $rotina, 'excluir')){
             return true;
             }
        else{
             $msg = 'O usuário <b>' . self :: getMatricula() . '</b> não tem permissão de exclusão para a Rotina <b>' . $rotina . '</b>!';
             Zend_Loader :: loadClass('Zend_View');
             $view = new Zend_View();
             $view -> setBasePath(self :: getViewPath());
             $view -> assign('baseUrl', self :: getBaseUrl());
             $view -> assign('dialogo', true);
             $view -> assign('destino', self :: getBaseUrl() . $destino);
             $view -> assign('tipoMsg', 'erro');
             $view -> assign('botoes', $view -> formSubmit('confirma', 'Ok', array('class' => 'btn')));
             $view -> assign('mensagemDialogo', $msg);
             $view -> assign('title', 'Permissão Negada');
             echo $view -> render('dialogopermissao.phtml');
             die();
             }
         }


     public static function verificaAtualizacao($rotina, $destino = ""){
         if (self :: getAcl() -> isAllowed(self :: getRole(), $rotina, 'atualizar')){
             return true;
             }
        else{
             $msg = 'O usuário <b>' . self :: getMatricula() . '</b> não tem permissão de atualização para a Rotina <b>' . $rotina . '</b>!';
             Zend_Loader :: loadClass('Zend_View');
             $view = new Zend_View();
             $view -> setBasePath(self :: getViewPath());
             $view -> assign('baseUrl', self :: getBaseUrl());
             $view -> assign('dialogo', true);
             $view -> assign('destino', self :: getBaseUrl() . $destino);
             $view -> assign('tipoMsg', 'erro');
             $view -> assign('botoes', $view -> formSubmit('confirma', 'Ok', array('class' => 'btn')));
             $view -> assign('mensagemDialogo', $msg);
             $view -> assign('title', 'Permissão Negada');
             echo $view -> render('dialogopermissao.phtml');
             die();
             }
         }
    }
