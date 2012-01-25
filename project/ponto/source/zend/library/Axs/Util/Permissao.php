<?php
/**
 * Classe para controle de permiss�es das rotinas do sistema
 * 
 * @name Axs_Util_Permissao
 * @author Eduardo Delano 19/09/2008 15:30:00
 * @package Axs
 * $Id: Permissao.php,v 1.1 2009/03/25 18:43:17 delano Exp $
 */
class Axs_Util_Permissao {

	/**
     * Fun��o para retornar a Url base
     * 
     * @name getBaseUrl
     * @access private
     * @return string
     */
    private static function getBaseUrl() {
        return substr($_SERVER['PHP_SELF'], 0, strpos($_SERVER['PHP_SELF'], '/index.php'));
    } 

	/**
     * Fun��o para retornar o diretorio padr�o das views
     * 
     * @name getViewPath
     * @access private
     * @return string
     * @todo fazer testes e verifica se esta fun��o sempre funcionar� em outros ambientes
     */    
    private static function getViewPath() {
	    return substr($_SERVER['SCRIPT_FILENAME'], 0, strpos($_SERVER['SCRIPT_FILENAME'], '/index.php')).'/application/views/';
	}
	
    /**
     * Fun��o para retornar o objeto da Access control list
     * 
     * @name getAcl
     * @access private
     * @return string
     */
    private static function getAcl() {
        return Zend_Registry::get('acl');
    } 

    /**
     * Fun��o para retornar o nome da role(grupo) atual
     * 
     * @name getRole
     * @access private
     * @return string
     */
    private static function getRole() {
        return Zend_Auth::getInstance()->getIdentity()->US_ROLE;
    } 

    /**
     * Fun��o para retornar a matricula do usu�rio
     * 
     * @name getMatricula
     * @access private
     * @return string
     */
    private static function getMatricula() {
        return Zend_Auth::getInstance()->getIdentity()->US_MATRICULA;
    }
        
    /**
     * Verifica se tem permiss�o de Leitura na rotina 
     * 
     * @name verificaLeitura
     * @param string $rotina
     * @access protected
     * @return string
     */
    public static function verificaLeitura($rotina, $destino="") {             
        if (self::getAcl()->isAllowed(self::getRole(), $rotina, 'consultar')) {
            return true;
        }
        else {
            $msg = 'O usu�rio <b>'.self::getMatricula().'</b> n�o tem permiss�o de leitura para a Rotina <b>'.$rotina.'</b>!';
            Zend_Loader::loadClass('Zend_View');
            $view = new Zend_View();
            $view->setBasePath(self::getViewPath());
            $view->assign('baseUrl',self::getBaseUrl());
            $view->assign('dialogo',true);
            $view->assign('destino',self::getBaseUrl().$destino);                        
            $view->assign('tipoMsg','erro');
            $view->assign('botoes',$view->formSubmit('confirma','Ok',array('class'=>'btn')));
            $view->assign('mensagemDialogo',$msg);
            $view->assign('title','Permiss�o Negada');
            echo $view->render('dialogopermissao.phtml');
            die();        
        }
    }

    /**
     * Verifica se tem permiss�o de Inclusao na rotina 
     * 
     * @name verificaInclusao
     * @param string $rotina
     * @access protected
     * @return string
     */    
    public static function verificaInclusao($rotina, $destino="") {
        if (self::getAcl()->isAllowed(self::getRole(), $rotina, 'incluir')) {
            return true;
        }
        else {
            $msg = 'O usu�rio <b>'.self::getMatricula().'</b> n�o tem permiss�o de inclus�o para a Rotina <b>'.$rotina.'</b>!';
            Zend_Loader::loadClass('Zend_View');
            $view = new Zend_View();
            $view->setBasePath(self::getViewPath());
            $view->assign('baseUrl',self::getBaseUrl());
            $view->assign('dialogo',true);
            $view->assign('destino',self::getBaseUrl().$destino);                        
            $view->assign('tipoMsg','erro');
            $view->assign('botoes',$view->formSubmit('confirma','Ok',array('class'=>'btn')));
            $view->assign('mensagemDialogo',$msg);
            $view->assign('title','Permiss�o Negada');            
            echo $view->render('dialogopermissao.phtml');
            die();        
        }
    }
    
    /**
     * Verifica se tem permiss�o de Exclusao na rotina 
     * 
     * @name verificaExclusao
     * @param string $rotina
     * @access protected
     * @return string
     */    
    public static function verificaExclusao($rotina, $destino="") {
        if (self::getAcl()->isAllowed(self::getRole(), $rotina, 'excluir')) {
            return true;
        }
        else {
            $msg = 'O usu�rio <b>'.self::getMatricula().'</b> n�o tem permiss�o de exclus�o para a Rotina <b>'.$rotina.'</b>!';
            Zend_Loader::loadClass('Zend_View');
            $view = new Zend_View();
            $view->setBasePath(self::getViewPath());
            $view->assign('baseUrl',self::getBaseUrl());
            $view->assign('dialogo',true);
            $view->assign('destino',self::getBaseUrl().$destino);                        
            $view->assign('tipoMsg','erro');
            $view->assign('botoes',$view->formSubmit('confirma','Ok',array('class'=>'btn')));
            $view->assign('mensagemDialogo',$msg);
            $view->assign('title','Permiss�o Negada');            
            echo $view->render('dialogopermissao.phtml');
            die();        
        }
    }

    /**
     * Verifica se tem permiss�o de Atualizacao na rotina 
     * 
     * @name verificaAtualizacao
     * @param string $rotina
     * @access protected
     * @return string
     */
    public static function verificaAtualizacao($rotina, $destino="") {
        if (self::getAcl()->isAllowed(self::getRole(), $rotina, 'atualizar')) {
            return true;
        }
        else {
            $msg = 'O usu�rio <b>'.self::getMatricula().'</b> n�o tem permiss�o de atualiza��o para a Rotina <b>'.$rotina.'</b>!';
            Zend_Loader::loadClass('Zend_View');
            $view = new Zend_View();
            $view->setBasePath(self::getViewPath());
            $view->assign('baseUrl',self::getBaseUrl());
            $view->assign('dialogo',true);
            $view->assign('destino',self::getBaseUrl().$destino);                        
            $view->assign('tipoMsg','erro');
            $view->assign('botoes',$view->formSubmit('confirma','Ok',array('class'=>'btn')));
            $view->assign('mensagemDialogo',$msg);
            $view->assign('title','Permiss�o Negada');            
            echo $view->render('dialogopermissao.phtml');
            die();        
        }
    }
}