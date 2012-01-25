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
 * @version    $Id: Float.php,v 1.1 2009/03/25 18:43:47 delano Exp $
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
class Axs_Validate_Float extends Zend_Validate_Abstract
{

    const NOT_FLOAT = 'notFloat';

    /**
     * @var array
     */
    protected $_messageTemplates = array(
        self::NOT_FLOAT => "'%value%' n�o parece ser um n�mero decimal."
    );

    /**
     * Op��es espec�ficas para o Float
     * - Op��es: 
     * validaLocalizacao -> especifica quando s� deve ser aceito valores que estejam de acordo com a localiza��o especificada
     * @var array
     * @access protected
     */ 
    protected $_opcoes = array(
                                'validaLocalizacao' => false,
                                'espacoAposMoeda'   => false
                            );
                            
    /**
     * Os dois caracteres que representam os separadores
     * - O 1� � o decimal, o segundo � o milhar
     * - Qualquer coisa al�m do segundo caracter ser� ignorada.
     * - Se os dois caracteres forem fornecidos, estes dever�o ser diferentes.
     * @var string
     * @access public
     */ 
    protected $_separadores = '.';                                

    /**
     * Defined by Zend_Validate_Interface
     *
     * Returns true if and only if $value is a floating-point value
     *
     * @param  string $value
     * @return boolean
     */
    public function isValid($value)
    {
        $valueString = (string) $value;
        
        $this->_setValue($valueString);
        
        $valorSetado = $this->setValor($valueString);
        if ($valorSetado === false) {
            $this->_error();
            return false;
        }
        else {
            return true;
        }
    }
    
    /**
     * Retorna todas as ocorr�ncias de uma string, em outra string
     * Possui as mesmas caracter�sticas do strpos(), fun��o criada por Ranulfo Netto
     * 
     * @name strmpos 
     * @param string $haystack 
     * @param string $needle
     * @param string $offset
     * @access public
     * @return string
     */
    public function strmpos($haystack, $needle, $offset = 0) {
        $pos = array();
        while (($nextPos = strpos($haystack, $needle, $offset)) !== false) {
            $pos[] = $nextPos;
            $offset = $nextPos + 1;
        }
        return $pos;
    }

    /**
     * Busca os separadores n�mericos, decimal e de milhar, utilizados pela localidade setada locale
     * 
     * @name _buscaSeparadores 
     * @access protected
     * @return string
     */
    protected function _buscaSeparadores()
    {
        $localeInfo = localeconv();
        if (empty($localeInfo['mon_decimal_point'])) {
            trigger_error('Configura��es regionais n�o encontradas na tentativa de buscar os separadores num�ricos da localiza��o!', E_USER_ERROR);
            return false;
        }
        return $localeInfo['mon_decimal_point'] .$localeInfo['mon_thousands_sep'];
    }

    /**
     * Atribui valor ao objeto.
     * 
     * @name setValor 
     * @param float/string $valor Valor que deve ser atribu�do/convertido. 
     * @access public
     * @return boolean/string
     */
    public function setValor($valor)
    {
        $separadores = $this->_buscaSeparadores();
        if ($this->_opcoes['validaLocalizacao']) { // verifica segundo localiza��o
            $valor = strval($valor);
            $posDecimal = strpos($valor,$separadores[0]);
            $posMilhar = strpos($valor,$separadores[1]);
            if (($posDecimal !== false) && ($posMilhar !== false)) {
                if ($posDecimal < $posMilhar) { // se o separador de decimal estiver antes do de milhar,... erro!
                    $this->valido = false;
                    return false;
                }
            }
        }
        else { // n�o requer valida��o pela localiza��o
            if (is_float($valor)) {
                $valorFinal = $valor;
                $this->valido = true;
                $this->_valor = $valorFinal;
                $this->_strValor = strval($valorFinal);
                return $valorFinal;
            }
            elseif (is_numeric($valor)) {
                $valorFinal = floatval($valor);
                $this->valido = true;
                $this->_valor = $valorFinal;
                $this->_strValor = $valor;
                return $valorFinal;
            }
        }
        if(isset($separadores) && is_string($valor)) { // se formato origem est� setado, o valor deve ser string
            $sepDecimal = $separadores[0];
            $sepMilhar  = $separadores[1];
            // deve haver 3 algarismos ap�s o separador de milhar

            // todas as ocorr�ncias de separadores
            $posSepDecimal = $this->strmpos($valor,$sepDecimal);
            if (count($posSepDecimal) > 1) { //se houver mais de um ponto decimal
                //trigger_error("N�mero inv�lido. Mais de um ponto decimal!", E_USER_WARNING);
                $this->valido = false;
                return false;
            }
            $posSepMilhar = $this->strmpos($valor,$sepMilhar);
            $posSeparadores = array_merge($posSepMilhar, $posSepDecimal);
            array_multisort($posSeparadores);
            for($i = 0; $i < count($posSeparadores); $i++) {// se a diferen�a entre cada um deles for menor que 3, est� errado
                if (isset($posSeparadores[$i+1])) {
                    if (($posSeparadores[$i+1] - $posSeparadores[$i]) != 4) { //verifica a dist�ncia entre separadores (quaisquer q sejam)
                        //trigger_error("N�mero inv�lido. N�o respeitada a dist�ncia entre separadores!", E_USER_WARNING);
                        $this->valido = false;
                        return false;
                    }
                }
                elseif (strrpos($valor, $sepMilhar) > strrpos($valor, $sepDecimal)) { // verifica se �ltimo milhar est� completo
                    if (((strlen($valor)-1) - $posSepMilhar[count($posSepMilhar)-1]) != 3)  { //dist�ncia at� o final
                        //trigger_error("N�mero inv�lido. Milhar n�o completado.", E_USER_WARNING);
                        $this->valido = false;
                        return false;
                    }
                }
            }

            // retira qualquer espa�o em branco da string. Ex.: 1 101,123 93
            // acontece quando o espa�o � utilizado para separar grupos de 3 algarismos
            $tempValor = ereg_replace (' +', '', $valor); 
            if (!empty($sepMilhar)) {
                // extraio o separador de milhar, seja qual for
                $tempValor = str_replace($sepMilhar, '', $tempValor);
            }
            
            // por fim substituo o separador de decimal pelo ponto (padr�o SQL/PHP)
            $tempValor = str_replace($sepDecimal, '.', $tempValor);
            // verifica se a vari�vel � num�rica depois de trocar o separador decimal
            if (!is_numeric($tempValor)) {
                $this->valido = false;
                return false;
            }
            else { // se for num�rico, verificar se ultrapassou o maior float poss�vel do PHP
                $this->_strValor = $tempValor;
                $valorConvertido = floatval($tempValor); // converter de string para float
                $valorFinal = $valorConvertido;
            }    
            $this->valido = true;
            $this->_valor = $valorFinal;
            return $valorFinal;
        }
        else {
            $this->valido = false;
            return false;
        }
    }    

}
