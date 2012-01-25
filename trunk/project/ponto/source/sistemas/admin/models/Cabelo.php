<?php
/**
 * Modelo da tabela cabelo
 *
 * @name Cabelo
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Cabelo extends Axs_Db_Table
{
    /**
     * Array de dados do modelo
     *
     * @name $_data
     * @access public
     * @var array
     */
    public $_data = array(
                   	                 'nameCabelo' => "",
                   	                 'idCabelo' => "",
                                  );
    /**
     * Array de validação do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                   	                 'nameCabelo' => array('allowEmpty'=>'true'),
                   	                 'idCabelo' => array( 'notEmpty','presence'=>'required'),
                                  );
    /**
     * Array de descrição dos dados
     *
     * @name $descriptionFields
     * @access public
     * @var array
     */
    public $descriptionFields = array(
                   	                 'nameCabelo' => 'Nome',
                   	                 'idCabelo' => 'Código',
                                  );
					

}

?>