<?php
/**
 * Modelo da tabela estadocivil
 *
 * @name Estadocivil
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Estadocivil extends Axs_Db_Table
{
    /**
     * Array de dados do modelo
     *
     * @name $_data
     * @access public
     * @var array
     */
    public $_data = array(
                   	                 'idEstadoCivil' => "",
                   	                 'nameEstadoCivil' => "",
                                  );
    /**
     * Array de valida��o do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                   	                 'idEstadoCivil' => array( 'notEmpty','presence'=>'required'),
                   	                 'nameEstadoCivil' => array( 'notEmpty','presence'=>'required'),
                                  );
    /**
     * Array de descri��o dos dados
     *
     * @name $descriptionFields
     * @access public
     * @var array
     */
    public $descriptionFields = array(
                   	                 'idEstadoCivil' => 'C�digo',
                   	                 'nameEstadoCivil' => 'Nome',
                                  );
					

}

?>