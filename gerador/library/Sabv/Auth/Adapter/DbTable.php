<?php

require_once 'Zend/Auth/Adapter/DbTable.php';

class Sabv_Auth_Adapter_DbTable extends Zend_Auth_Adapter_DbTable{


     protected $_where = null;



     protected $_expiracao = null;


     public function setExpiracao($value)
    {
         $this -> _expiracao = $value;
         return $this;
         }


     public function setWhere($value)
    {
         $this -> _where = $value;
         return $this;
         }


     protected function _authenticateCreateSelect()
    {
         if (empty($this -> _credentialTreatment) || (strpos($this -> _credentialTreatment, "?") === false)){
             $this -> _credentialTreatment = '?';
             }

         $credentialExpression = new Zend_Db_Expr(
            '(CASE WHEN ' .
             $this -> _zendDb -> quoteInto(
                $this -> _zendDb -> quoteIdentifier($this -> _credentialColumn, true)
                 . ' = ' . $this -> _credentialTreatment, $this -> _credential
                )
             . ' THEN 1 ELSE 0 END) AS '
             . $this -> _zendDb -> quoteIdentifier('zend_auth_credential_match')
            );

         $dbSelect = $this -> _zendDb -> select();
         $dbSelect -> from($this -> _tableName, array('*', $credentialExpression))
         -> where($this -> _zendDb -> quoteIdentifier($this -> _identityColumn, true) . ' = ?', $this -> _identity);

         if (is_array($this -> _where)){
             foreach($this -> _where as $key => $value){
                 if (!is_array($value)){
                     $dbSelect -> where($this -> _zendDb -> quoteIdentifier($key, true) . ' = ?', $value);
                     }
                else{
                     $dbSelect -> where("'$key'" . ' = ?', $value);
                     }
                 }
             }
         if (!is_null($this -> _expiracao)){
             $dbSelect -> where("coalesce(US_DATA_EXPIRACAO,to_date('31/12/9999'))" . ' >= ?', $this -> _expiracao);
             }

         return $dbSelect;
         }

    }
