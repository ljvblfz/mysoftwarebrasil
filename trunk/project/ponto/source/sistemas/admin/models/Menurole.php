<?php
/**
 * Modelo da tabela menurole
 *
 * @name Menurole
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Menurole extends Axs_Db_Table
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
                   	                 'idMenu' => "",
                   	                 'menuRoleId' => "",
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
                   	                 'idMenu' => array( 'notEmpty','presence'=>'required'),
                   	                 'menuRoleId' => array( 'notEmpty','presence'=>'required'),
                                  );
    /**
     * Array de descrição dos dados
     *
     * @name $descriptionFields
     * @access public
     * @var array
     */
    public $descriptionFields = array(
                   	                 'idRole' => 'Role',
                   	                 'idMenu' => 'Menu',
                   	                 'menuRoleId' => 'Código',
                                  );
					

}

?>