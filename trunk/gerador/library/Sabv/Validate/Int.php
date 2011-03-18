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
 * @version    $Id: Int.php,v 1.3 2008/09/03 17:35:09 gabriel Exp $
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
class Sabv_Validate_Int extends Zend_Validate_Abstract
{

    const NOT_INT = 'notInt';

    /**
     * Validation failure message key for when the value does not fit the given dateformat or locale
     */
    const NOT_EMPTY    = 'intNotEmpty';
    
    /**
     * @var array
     */
    protected $_messageTemplates = array(
        self::NOT_INT => "'%value%' não parece ser um número inteiro",
        self::NOT_EMPTY => "Um valor inteiro deve ser informado"
    );

    /**
     * Defined by Zend_Validate_Interface
     *
     * Returns true if and only if $value is a valid integer
     *
     * @param  string $value
     * @return boolean
     */
    public function isValid($value)
    {
        $valueString = (string) $value;

        $this->_setValue($valueString);

        $locale = localeconv();

        $valueFiltered = str_replace($locale['decimal_point'], '.', $valueString);
        $valueFiltered = str_replace($locale['thousands_sep'], '', $valueFiltered);

        if (empty($valueString) && $valueString != '0') {
            $this->_error(self::NOT_EMPTY);
            return false;
        }
            
        if (strval(intval($valueFiltered)) != $valueFiltered) {
            $this->_error();
            return false;
        }

        return true;
    }

}
