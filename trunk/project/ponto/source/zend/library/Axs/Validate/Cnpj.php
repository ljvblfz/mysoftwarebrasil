<?php
/**
 * Zend Framework
 *
 * LICENSE
 *
 * This source file is subject to the new BSD license that is bundled
 * with this package in the file LICENSE.txt.
 * It is also available through the world-wide-web at this URL:
 * http://framework.zend.com/license/new-bsd
 * If you did not receive a copy of the license and are unable to
 * obtain it through the world-wide-web, please send an email
 * to license@zend.com so we can send you a copy immediately.
 *
 * @category   Zend
 * @package    Zend_Validate
 * @copyright  Copyright (c) 2005-2008 Zend Technologies USA Inc. (http://www.zend.com)
 * @license    http://framework.zend.com/license/new-bsd     New BSD License
 * @version    $Id: value.php,v 1.1 2009/03/25 18:43:47 delano Exp $
 */


/**
 * @see Zend_Validate_Abstract
 */
require_once 'Zend/Validate/Abstract.php';


/**
 * @category   Zend
 * @package    Zend_Validate
 * @copyright  Copyright (c) 2005-2008 Zend Technologies USA Inc. (http://www.zend.com)
 * @license    http://framework.zend.com/license/new-bsd     New BSD License
 */
class Axs_Validate_Cnpj extends Zend_Validate_Abstract
{
    /**
     * Validation failure message key for when the value contains non-digit characters
     */
    const NAO_DIGITO = 'notDigits';

    /**
     * Validation failure message key for when the value does not fit the given dateformat or locale
     */
    const INVALIDO_CNPJ= 'invalidCNPJ';

    /**
     * Validation failure message key for when the value does not fit the given dateformat or locale
     */
    const CNPJ_VAZIO    = 'CnpjEmpty';

    /**
     * Digits filter used for validation
     *
     * @var Zend_Filter_Digits
     */
    protected static $_filter = null;

    /**
     * Validation failure message template definitions
     *
     * @var array
     */
    protected $_messageTemplates = array (
                  self::NAO_DIGITO => "O CNPJ deve conter apenas números",
                  self::INVALIDO_CNPJ => "O CNPJ '%value%' não é válido",
                  self::CNPJ_VAZIO      => "Um CNPJ deve ser informado."
            );


    /**
     * Defined by Zend_Validate_Interface
     *
     * Returns true if and only if $value only contains digit characters
     *
     * @param  string $value
     * @return boolean
     */
    public function isValid($value)
    {
        $valueString = (string) $value;

        $this->_setValue($valueString);

        if (empty($valueString)) {
            $this->_error(self::CNPJ_VAZIO);
            return false;
        }

        if (null === self::$_filter) {
            /**
             * @see Zend_Filter_Digits
             */
            require_once 'Zend/Filter/Digits.php';
            self::$_filter = new Zend_Filter_Digits();
        }

        $valueString = self::$_filter->filter($valueString);
        if (!$this->validaCNPJ($valueString)) {
            $this->_error(self::INVALIDO_CNPJ);
            return false;
        }

        return true;
    }

    /**
    * Validação do CNPJ
    *
    * @name validaCNPJ
    * @param $num_cnpj
    * @access protected
    * @return boleano
    */
	 public function validaCNPJ($num_cnpj)
	 {
	     if (!isset($num_cnpj) || empty($num_cnpj)) {
           $this->mensagem = "Informe um valor para o CNPJ";
		   return false;
         }

		 //filtra o cpf/cnpj passado para trabalhar somente com números.
//   	     $tamanho = strlen($num_cnpj);
//         for ($i = 0; $i <= $tamanho;$i++) {
//   	         if (is_numeric($num_cnpj[$i])) {
//      	         $temp.=$num_cnpj[$i];
//      		 }
//	     }
//         $num_cnpj = $temp;

         if (strlen($num_cnpj) <> 14) {
	         $this->mensagem = "O valor informado possui tamanho inválido";
		     return  false;
	     }

	     //Validação de CNPJ
	     if ($num_cnpj == '00000000000000') {
		     $this->mensagem = "CNPJ informado inválido";
	 	     return  false;
		 }
		 //Constantes para verificação do CNPJ
		 $constante = array(6,5,4,3,2,9,8,7,6,5,4,3,2);

		 //Validação
		 $soma = 0;
		 for ($i=0; $i<12; $i++){
             $soma = $soma + $num_cnpj[$i] * $constante[$i+1];
	     }
         $resto = $soma % 11;
		 if ($resto < 2) {
		     $digito[0] = 0;
		 }
		 else {
		     $digito[0] = 11 - $resto;
		 }
		 if ($digito[0] == $num_cnpj[12]) {
		     $soma = 0;
		     for ($i=0; $i<13; $i++){
                 $soma = $soma + $num_cnpj[$i] * $constante[$i];
	         }
             $resto = $soma % 11;
		     if ($resto < 2) {
		         $digito[1] = 0;
		     }
		     else {
		         $digito[1] = 11 - $resto;
		     }
			 if ($digito[1] == $num_cnpj[13]) {
			     $this->num_cnpj_cpf = $num_cnpj;
			     return true;
			 }
			 else {
			     $this->mensagem = "CNPJ informado inválido";
	 	         return  false;
			 }
		 }
		 else {
		     $this->mensagem = "CNPJ informado inválido";
	 	     return  false;
		 }

	 }

}