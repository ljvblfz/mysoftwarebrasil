<?php
/**
 * Classe responsável pelas permissões de acesso aos recursos do sistema
 *
 * @name  Axs_ACL
 * @author Eduardo Delano, Michael MistaGee Ziegler
 * @package safciweb
 * @version $Id: Acl.php,v 1.1 2009/03/25 18:41:16 delano Exp $
 */
require_once 'Zend/Db.php';
require_once 'Zend/Acl.php';
require_once 'Zend/Acl/Role.php';
require_once 'Zend/Acl/Resource.php';
require_once 'Zend/Auth.php';

class Axs_ACL extends Zend_ACL {
	private $dbase;

	/**
	 * Método que realiza a verificação de login do usuário.
	 *
	 * @name isIdentity
	 * @access public
	 * @return void
	 */
	public static function isIdentity()
	{
		$request = new Zend_Controller_Request_Http();
		$auth = Zend_Auth::getInstance();
		if (!$auth->hasIdentity()) {
			//header("Location: {$request->getBaseUrl()}/{$request->getModuleName()}/auth/login");
			header("Location: http://{$_SERVER['HTTP_HOST']}/default/auth/login");
			//header("Location: {$request->getBaseUrl()}/auth/login");
		}
	}

	public function hasAllRolesOf(array &$searchRoles)
	{
		foreach($searchRoles as $theRole)
			if (!$this->hasRole($theRole))
				return false;
		return true;
	}

	/**
	 * Função que percorre o arrai de roles recursivamente e retorna todos
	 * os pais de uma determinada role.
	 *
	 * @param  $original array Array original com as roles e hierarquia de pais de apenas um nivel
	 * @param  $nome string Nome da role a ser pesquisada
	 */
	public function getPaisRole($original, $nome)
	{
		// se o pai existe como elemento no array original
		if (array_key_exists($nome, $original)) {
			$entrou = false;
			// percorre todos os pais da role passada em $nome
			foreach($original[$nome] as $val) {
				$entrou = true;
				// chama novamente a funçao para pesquisar todos os pais
				$t = $t . ',' . $this->getPaisRole($original, $val);
			}
			// se a role atual nao tem pais
			if ($entrou == false) {
				return $nome;
			} //concatena o nome da role e seus pais
			else {
				return $nome . $t;
			}
		}
	}

	public function __construct(Zend_Db_Adapter_Abstract &$db)
	{
		$this->dbase = &$db;
		$auth = Zend_Auth::getInstance();
		$cfg = Zend_Registry::get('config');
		$request = new Zend_Controller_Request_Http();
				
		if ($auth->hasIdentity() && $auth->getIdentity()) {
			
			$roleId = $auth->getIdentity()->idRole;
			$membroId = $auth->getIdentity()->idMembro;
			$urls = explode('/',$request->getRequestUri());
			$isModule = array_search(@$urls[1],$cfg->system->modulo->toArray()) || @$urls[1] == "default";
			$base = $urls[0];
			$controller = $isModule ? @$urls[2] : @$urls[1];
			$action = $isModule ? @$urls[3] : "index";
			
			if(!empty($controller) && $controller != "auth" 
				&& ($controller != "index" && $action != "index")
				&& ($controller != "register" && $action != "Register")
			){
				
				$select = $this->dbase->select(array('R'=>'Role'),array())
					->joinInner(
						array('M'=>'membro'),
						"Role.idRole = M.idRole",
						array()
						)
					->joinInner(
						array('PR'=>'permissaorole'),
						"M.idRole = PR.idRole",
						array()
						)
					->joinInner(
						array('P'=>'Permissoes'),
						"PR.idPermissao = P.idPermissao",
						array()
						)
					->joinInner(
						array('A'=>'Action'),
						"A.idAction = P.idAction",
						array("nameAction")
						)
					->joinInner(
						array('C'=>'Controller'),
						"C.idController = P.idController",
						array("nameController")
						)
					->where("M.idMembro=?",(is_null($membroId)? 0 : $membroId),Zend_Db::INT_TYPE)
					->where("C.nameController=?",$controller)
					->where("A.nameAction=?",(empty($action) ? "index": $action))
				;

				$data = $this->dbase->fetchAll($select);
				if(count((Array)$data) <= 0){
					header("Location: http://{$_SERVER['HTTP_HOST']}/default/auth/login");
				}
			}
		}
	}
}

