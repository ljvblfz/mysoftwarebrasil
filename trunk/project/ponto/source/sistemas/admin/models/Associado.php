<?php
/**
 * Modelo da tabela associado
 *
 * @name Associado
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Associado extends Axs_Db_Table
{
    /**
     * Array de dados do modelo
     *
     * @name $_data
     * @access public
     * @var array
     */
    public $_data = array(
                   	                 'idMembro' => "",
                   	                 'idAssociacao' => "",
                   	                 'idAssociado' => "",
                                  );
    /**
     * Array de validação do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                   	                 'idMembro' => array( 'notEmpty','presence'=>'required'),
                   	                 'idAssociacao' => array( 'notEmpty','presence'=>'required'),
                   	                 'idAssociado' => array( 'notEmpty','presence'=>'required'),
                                  );
    /**
     * Array de descrição dos dados
     *
     * @name $descriptionFields
     * @access public
     * @var array
     */
    public $descriptionFields = array(
                   	                 'idMembro' => 'Membro',
                   	                 'idAssociacao' => 'Associado',
                   	                 'idAssociado' => 'Código',
                                  );
					

}

?>