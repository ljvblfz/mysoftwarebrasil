<?php
/**
 * Modelo da tabela role
 *
 * @name Role
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Role extends Axs_Db_Table
{
    /**
     * Array de dados do modelo
     *
     * @name $_data
     * @access public
     * @var array
     */
    public $_data = array(
                   	                 'idRole' => "",
                   	                 'nameRole' => "",
                                  );
    /**
     * Array de validação do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                   	                 'idRole' => array( 'notEmpty','presence'=>'required'),
                   	                 'nameRole' => array( 'notEmpty','presence'=>'required'),
                                  );
    /**
     * Array de descrição dos dados
     *
     * @name $descriptionFields
     * @access public
     * @var array
     */
    public $descriptionFields = array(
                   	                 'idRole' => 'Código',
                   	                 'nameRole' => 'Nome',
                                  );
					

}

?>