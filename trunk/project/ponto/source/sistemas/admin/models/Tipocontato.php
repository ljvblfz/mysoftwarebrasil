<?php
/**
 * Modelo da tabela tipocontato
 *
 * @name Tipocontato
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Tipocontato extends Axs_Db_Table
{
    /**
     * Array de dados do modelo
     *
     * @name $_data
     * @access public
     * @var array
     */
    public $_data = array(
                   	                 'idTipoContato' => "",
                   	                 'nameTipoContato' => "",
                                  );
    /**
     * Array de validação do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                   	                 'idTipoContato' => array( 'notEmpty','presence'=>'required'),
                   	                 'nameTipoContato' => array( 'notEmpty','presence'=>'required'),
                                  );
    /**
     * Array de descrição dos dados
     *
     * @name $descriptionFields
     * @access public
     * @var array
     */
    public $descriptionFields = array(
                   	                 'idTipoContato' => 'Código',
                   	                 'nameTipoContato' => 'Nome',
                                  );
					

}

?>