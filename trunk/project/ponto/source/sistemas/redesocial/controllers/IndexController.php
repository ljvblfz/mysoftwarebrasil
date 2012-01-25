<?php
/**
 * Controller Incial do sistema
 *
 * @name IndexController.php
 * @author Alexis Moura 1/4/2009 10:39:36
 * @package Controller
 * @version $Id$
 */
class Redesocial_IndexController extends Axs_Controller_Action {


    /**
     * Descrição dos campos a serem validados
     *
     * @name $_descricaoCampos
     * @access protected
     * @var array
     */
    protected $_descricaoCampos = array('cod_ent' => 'Entidade',
        							    'username' => 'Matrícula',
        								'password' => 'Senha');


    function init()
    {
    	$this->initView();
    }


    function preDispatch()
    {
		Axs_ACL::isIdentity();
    }


    function indexAction()
    {
		//$this->_redirect('/redesocial/profile/index');
    }
}
