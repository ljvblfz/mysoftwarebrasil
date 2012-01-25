<?php
/**
 * Modelo da tabela olho
 *
 * @name Olho
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Olho extends Axs_Db_Table
{
    /**
     * Array de dados do modelo
     *
     * @name $_data
     * @access public
     * @var array
     */
    public $_data = array(
                   	                 'idOlho' => "",
                   	                 'nameOlho' => "",
                                  );
    /**
     * Array de validação do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                   	                 'idOlho' => array( 'notEmpty','presence'=>'required'),
                   	                 'nameOlho' => array( 'notEmpty','presence'=>'required'),
                                  );
    /**
     * Array de descrição dos dados
     *
     * @name $descriptionFields
     * @access public
     * @var array
     */
    public $descriptionFields = array(
                   	                 'idOlho' => 'Código',
                   	                 'nameOlho' => 'Nome',
                                  );
					

}

?>