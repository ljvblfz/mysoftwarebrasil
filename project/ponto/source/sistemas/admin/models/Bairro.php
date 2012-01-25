<?php
/**
 * Modelo da tabela bairro
 *
 * @name Bairro
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Bairro extends Axs_Db_Table
{
    /**
     * Array de dados do modelo
     *
     * @name $_data
     * @access public
     * @var array
     */
    public $_data = array(
                   	                 'nomeBairro' => "",
                   	                 'idBairro' => "",
                                  );
    /**
     * Array de validação do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                   	                 'nomeBairro' => array( 'notEmpty','presence'=>'required'),
                   	                 'idBairro' => array( 'notEmpty','presence'=>'required'),
                                  );
    /**
     * Array de descrição dos dados
     *
     * @name $descriptionFields
     * @access public
     * @var array
     */
    public $descriptionFields = array(
                   	                 'nomeBairro' => 'Nome',
                   	                 'idBairro' => 'Código',
                                  );
					

}

?>