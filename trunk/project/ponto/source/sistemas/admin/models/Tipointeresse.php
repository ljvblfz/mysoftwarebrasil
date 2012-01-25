<?php
/**
 * Modelo da tabela tipointeresse
 *
 * @name Tipointeresse
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Tipointeresse extends Axs_Db_Table
{
    /**
     * Array de dados do modelo
     *
     * @name $_data
     * @access public
     * @var array
     */
    public $_data = array(
                   	                 'idTipoInteresse' => "",
                   	                 'nameTipoInteresse' => "",
                                  );
    /**
     * Array de validação do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                   	                 'idTipoInteresse' => array( 'notEmpty','presence'=>'required'),
                   	                 'nameTipoInteresse' => array( 'notEmpty','presence'=>'required'),
                                  );
    /**
     * Array de descrição dos dados
     *
     * @name $descriptionFields
     * @access public
     * @var array
     */
    public $descriptionFields = array(
                   	                 'idTipoInteresse' => 'Código',
                   	                 'nameTipoInteresse' => 'Nome',
                                  );
					

}

?>
