<?php

require_once 'Zend/Db.php';
require_once 'Zend/Acl.php';
require_once 'Zend/Acl/Role.php';
require_once 'Zend/Acl/Resource.php';
require_once 'Zend/Auth.php';

class Sabv_ACL extends Zend_ACL{
     private $dbase;

     public function hasAllRolesOf(array & $searchRoles)
    {
         foreach($searchRoles as $theRole)
         if (!$this -> hasRole($theRole))
             return false;
         return true;
         }


     public function getPaisRole($original, $nome)
    {
         if (array_key_exists($nome, $original)){
             $entrou = false;
             foreach($original[$nome] as $val){
                 $entrou = true;
                 $t = $t . ',' . $this -> getPaisRole($original, $val);
                 }
             if ($entrou == false){
                 return $nome;
                 } //concatena o nome da role e seus pais
             else{
                 return $nome . $t;
                 }
             }
         }

     public function __construct(Zend_Db_Adapter_Abstract & $db)
    {
         $this -> dbase = & $db;

         $auth = Zend_Auth :: getInstance();
         if ($auth -> hasIdentity()){
             $entidade = Zend_Auth :: getInstance() -> getIdentity() -> US_ENTIDADE;
             $role = Zend_Auth :: getInstance() -> getIdentity() -> US_ROLE;
             if (is_null(Zend_Auth :: getInstance() -> getIdentity() -> US_ROLE)){
                 $role = Zend_Auth :: getInstance() -> getIdentity() -> US_ANO . '_' . Zend_Auth :: getInstance() -> getIdentity() -> US_MATRICULA;
                 }
             $resources = $db -> fetchAll($db -> select() -> distinct() -> from('SOT_RESOURCES', array('ID', 'ID_PAI')) -> where('ENTIDADE = ?', $entidade));

             $resCount = count($resources);
             $addCount = 0;

             $allResources = array();
             foreach($resources as $theRes){
                 $allResources[] = $theRes -> ID;
                 }
             foreach($resources as $theRes){
                 if ($theRes -> ID_PAI !== null && !in_array($theRes -> ID_PAI, $allResources)){
                     require_once 'Zend/Acl/Exception.php';
                     throw new Zend_Acl_Exception("O Resource id '" . $theRes -> ID_PAI . "' nao existe");
                     }
                 }
             while ($resCount > $addCount){
                 foreach($resources as $theRes){
                     if (!$this -> has($theRes -> ID) && ($theRes -> ID_PAI === null || $this -> has($theRes -> ID_PAI))){
                         $this -> add(new Zend_Acl_Resource($theRes -> ID), $theRes -> ID_PAI);
                         $addCount++;
                         }
                     }
                 }
             $roles1 = $db -> fetchAll($db -> select() -> from(array('R' => 'SOT_ROLES'), array('R.ID', 'I.ID_PAI')) -> joinRight(array('I' => 'SOT_ROLES'), 'I.ID_PAI=R.ID') -> where("I.ENTIDADE = {$entidade} AND I.ID='{$role}'"));

             $select = $db -> select();
             $select -> from(array('R' => 'SOT_ROLES'), array('R.ENTIDADE as ENTIDADE_R', 'R.ID as ID_R', 'R.ID_PAI as ID_PAI_R'));
             $select -> joinLeft(array('I' => 'SOT_ROLES'), 'I.ENTIDADE=R.ENTIDADE AND I.ID_PAI=R.ID');
             $select -> where("R.ENTIDADE = $entidade AND R.ID='{$role}'");

             $roles = $db -> fetchAll($select);

             $dbElements = array();
             foreach($roles as $theRole){
                 if (!isset($dbElements[ $theRole -> ID_R ])){
                     $dbElements[ $theRole -> ID_R ] = array();
                     }
                 if ($theRole -> ID_PAI_R !== null){
                     $dbElements[ $theRole -> ID_R ][] = $theRole -> ID_PAI_R;
                     }
                 }
             foreach($dbElements as $key => $value){
                 if (is_array($value) && count($value) > 0){
                     foreach($value as $val1){
                         $a = $this -> getPaisRole($dbElements, $val1);
                         $b[$key] = explode(',', $a);
                         }
                     }
                else{
                     $b[$key] = array();
                     }
                 }
             $dbElements = array_merge($dbElements, $b);

             $dbElemCount = count($dbElements);
             $aclElemCount = 0;
             while ($dbElemCount > $aclElemCount){
                 foreach($dbElements as $theDbElem => $theDbElemParents){
                     foreach($theDbElemParents as $theParent){
                         if (!array_key_exists($theParent, $dbElements)){
                             require_once 'Zend/Acl/Exception.php';
                             throw new Zend_Acl_Exception("A Role de id '$theParent' não existe");
                             }
                         }
                     if (!$this -> hasRole($theDbElem) && (empty($theDbElemParents) || $this -> hasAllRolesOf($theDbElemParents))){
                         $this -> addRole(new Zend_Acl_Role($theDbElem), $theDbElemParents);
                         $aclElemCount++;
                         }
                     }
                 }
             $select = $db -> select();
             $select -> from('SOT_ACESSO', array('ID_ROLE', 'ID_RESOURCE', 'DESC_PRIVILEGIO', 'PERMISSAO', 'FLG_C', 'FLG_I', 'FLG_E', 'FLG_A'));
             $select -> where("ENTIDADE = $entidade AND ID_ROLE = '{$role}'");
             $access = $db -> fetchAll($select);
             foreach($access as $theRule){
                 if (!is_null($theRule -> DESC_PRIVILEGIO) && substr_count($theRule -> DESC_PRIVILEGIO, '|') > 0){
                     $privilegios = explode('|', $theRule -> DESC_PRIVILEGIO);
                     }
                 if ($theRule -> FLG_C == true){
                     $this -> allow($theRule -> ID_ROLE, $theRule -> ID_RESOURCE, "consultar");
                     }
                 if ($theRule -> FLG_I == true){
                     $this -> allow($theRule -> ID_ROLE, $theRule -> ID_RESOURCE, "incluir");
                     }
                 if ($theRule -> FLG_E == true){
                     $this -> allow($theRule -> ID_ROLE, $theRule -> ID_RESOURCE, "excluir");
                     }
                 if ($theRule -> FLG_A == true){
                     $this -> allow($theRule -> ID_ROLE, $theRule -> ID_RESOURCE, "atualizar");
                     }


                 }
             $access = $db -> fetchAll($db -> select() -> from('SOT_ACESSO_MENU', array('ID_ROLE', 'ID_RESOURCE', 'ID_MENU', 'PERMISSAO')) -> where("ENTIDADE = $entidade AND ID_ROLE='{$role}'"));
             foreach($access as $theRule){
                 if ($theRule -> PERMISSAO == true){
                     $this -> allow($theRule -> ID_ROLE, $theRule -> ID_RESOURCE, $theRule -> ID_MENU);
                     }else{
                     $this -> deny($theRule -> ID_ROLE, $theRule -> ID_RESOURCE, $theRule -> ID_MENU);
                     }
                 }
             }
         }
    }

