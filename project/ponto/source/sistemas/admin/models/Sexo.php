<?php
/**
 * Modelo da tabela sexo
 *
 * @name Sexo
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Sexo extends Axs_Db_Table
{
    /**
     * Array de dados do modelo
     *
     * @name $_data
     * @access public
     * @var array
     */
    public $_data = array(
                   	                 'idSexo' => "",
                   	                 'nameSexo' => "",
                                  );
    /**
     * Array de validação do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                   	                 'idSexo' => array( 'notEmpty','presence'=>'required'),
                   	                 'nameSexo' => array( 'notEmpty','presence'=>'required'),
                                  );
    /**
     * Array de descrição dos dados
     *
     * @name $descriptionFields
     * @access public
     * @var array
     */
    public $descriptionFields = array(
                   	                 'idSexo' => 'Código',
                   	                 'nameSexo' => 'Nome',
                                  );
}

?>
