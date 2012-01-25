<?php
/**
 * Classe utilizada para realizar a autenticação do usuario no sistema
 * 
 * @name Axs_Auth_Adapter_DbTable
 * @author Eduardo Delano 01/6/2008 08:30:00
 * @package _sicof
 */
require_once 'Zend/Auth/Adapter/DbTable.php';

class Axs_Auth_Adapter_DbTable extends Zend_Auth_Adapter_DbTable {

    /**
     * Array com os campos adicionais do where
     * @acess protected
     * @var array 
     */
    protected $_where = null;

    /**
    * Metodo para adicionar parametros adicionais a clausula where para autenticação do usuario
    * 
    * @name setWhere
    * @param  array $value Array onde a chave é o nome do campo e o valor e o valor do campo 
    * @access public 
    * @return object this
    */
    public function setWhere($value)
    {
	    $this->_where = $value;
        return $this;
	}
	
    /**
    * Metodo que cria a query responsavel por autenticar o usuario
    * 
    * @name _authenticateCreateSelect
    * @access protected
    * @see Axs_Auth_Adapter_DbTable::_authenticateCreateSelect()
    * @return object $dbSelect
    */
    protected function _authenticateCreateSelect()
    {
        // build credential expression
        if (empty($this->_credentialTreatment) || (strpos($this->_credentialTreatment, "?") === false)) {
            $this->_credentialTreatment = '?';
        }

        $credentialExpression = new Zend_Db_Expr(
            '(CASE WHEN ' . 
            $this->_zendDb->quoteInto(
                $this->_zendDb->quoteIdentifier($this->_credentialColumn, true)
                . ' = ' . $this->_credentialTreatment, $this->_credential
                )
            . ' THEN 1 ELSE 0 END) AS '
            . $this->_zendDb->quoteIdentifier('zend_auth_credential_match')
            );

        // get select
        $dbSelect = $this->_zendDb->select();
        $dbSelect->from($this->_tableName, array('*', $credentialExpression))
                 ->where($this->_zendDb->quoteIdentifier($this->_identityColumn, true) . ' = ?', $this->_identity);
		
		//quando $_where possui elementos, adiciona os elementos a clausula where
		if (is_array($this->_where)) {
		    foreach( $this->_where as $key => $value){
		        if (!is_array($value)) {
		        	$dbSelect->where($this->_zendDb->quoteIdentifier($key, true) . ' = ?', $value);
		        }
		        else {
				    $dbSelect->where("'$key'" . ' = ?', $value);
				}
			}
		}		 

        return $dbSelect;
    }

}