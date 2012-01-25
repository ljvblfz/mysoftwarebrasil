<?php
/**
 * Modelo da tabela tipoassociacao
 *
 * @name Tipoassociacao
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Tipoassociacao extends Axs_Db_Table
{
    /**
     * Array de dados do modelo
     *
     * @name $_data
     * @access public
     * @var array
     */
    public $_data = array(
                   	                 'nomeTipoAssociacao' => "",
                   	                 'idTipoAssociacao' => "",
                                  );
    /**
     * Array de validação do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                   	                 'nomeTipoAssociacao' => array( 'notEmpty','presence'=>'required'),
                   	                 'idTipoAssociacao' => array( 'notEmpty','presence'=>'required'),
                                  );
    /**
     * Array de descrição dos dados
     *
     * @name $descriptionFields
     * @access public
     * @var array
     */
    public $descriptionFields = array(
                   	                 'nomeTipoAssociacao' => 'Nome',
                   	                 'idTipoAssociacao' => 'Código',
                                  );
					

}

?>