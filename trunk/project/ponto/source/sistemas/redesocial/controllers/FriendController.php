<?php
/**
 * Controller de amigos
 *
 * @name FriendController.php
 * @author Alexis Moura 10/1/2012 22:31:36
 * @package Controller
 * @version $Id$
 */
class Redesocial_FriendController extends Axs_Controller_Action {


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
		
	}
}
