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
class Axs_Validate_Cpf extends Zend_Validate_Abstract
{
    /**
     * Validation failure message key for when the value contains non-digit characters
     */
    const NAO_DIGITO = 'notDigits';

    /**
     * Validation failure message key for when the value does not fit the given dateformat or locale
     */
    const INVALIDO_CPF= 'invalidCPF';

    /**
     * Validation failure message key for when the value does not fit the given dateformat or locale
     */
    const CPF_VAZIO    = 'cpfEmpty';

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
                  self::NAO_DIGITO => "O CPF deve conter apenas números",
                  self::INVALIDO_CPF => "O CPF '%value%' não é válido",
                  self::CPF_VAZIO      => "Um CPF deve ser informado."
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
            $this->_error(self::CPF_VAZIO);
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
        if (!$this->validaCPF($valueString)) {
            $this->_error(self::INVALIDO_CPF);
            return false;
        }

        return true;
    }

    /**
    * Validação do CPF
    *
    * @name validaCPF
    * @param $num_cpf
    * @access protected
    * @return boleano
    */
	 protected function validaCPF($num_cpf)
	 {
	     if (!isset($num_cpf) || empty($num_cpf)) {
           $this->mensagem = "Informe um valor para o CPF";
		   return false;
         }

		 //filtra o cpf/cnpj passado para trabalhar somente com números.
//   	     $tamanho = strlen($num_cpf);
//         for ($i = 0; $i <= $tamanho;$i++) {
//   	         if (is_numeric($num_cpf[$i])) {
//      	         $temp.=$num_cpf[$i];
//      		 }
//	     }
//         $num_cpf = $temp;

         if (strlen($num_cpf) <> 11) {
	         $this->mensagem = "O valor informado possui tamanho inválido";
		     return false;
	     }

	     if ($num_cpf == '00000000000' || $num_cpf == '99999999999') {
		     $this->mensagem = "CPF informado inválido";
	 	     return false;
		 }

		 //validação
		 $soma = 0;
		 for ($j = 0; $j < 9; $j++) {
		     $soma = $soma + (10 - $j) * intval($num_cpf[$j]);
		 }
		 $resto = $soma % 11;
		 if ($resto < 2) {
		     $digito[0] = 0;
		 }
		 else {
		     $digito[0] = 11 - $resto;
		 }
		 if ($digito[0] == intval($num_cpf[9])) {
		     $soma = 0;
		     for ($j = 0; $j < 10; $j++) {
		         $soma = $soma + (11 - $j) * intval($num_cpf[$j]);
		     }
		     $resto = $soma % 11;
			 if ($resto < 2) {
		         $digito[1] = 0;
		     }
		     else {
		         $digito[1] = 11 - $resto;
		     }
			 if ($digito[1] == intval($num_cpf[10])) {
			     //o CPF é válido
				 $this->num_cnpj_cpf = $num_cpf;
			     return true;
			 }
			 else {
			     //o CPF é inválido
				 $this->mensagem = "O número de CPF informado é inválido";
				 return  false;
			 }
		 }
		 else {
		     //o CPF é inválido
			 $this->mensagem = "O número de CPF informado é inválido";
			 return  false;
		 }
		 return true;
	 }
}
