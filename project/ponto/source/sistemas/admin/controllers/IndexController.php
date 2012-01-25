<?php
/**
 * Controller Incial do sistema
 *
 * @name IndexController.php
 * @author Alexis Moura 1/4/2009 10:39:36
 * @package Controller
 * @version $Id$
 */
class IndexController extends Axs_Controller_Action {


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
		$this->view->baseUrl = $this->_request->getBaseUrl();
        $this->view->modulo  = $this->getRequest()->getModuleName();
    }


    function preDispatch()
    {
		//Axs_ACL::isIdentity();
    }


    function indexAction()
    {
		$menu = new Menu();
    }
}
