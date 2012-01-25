<?php
/**
 * Modelo da tabela estado
 *
 * @name Estado
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Estado extends Axs_Db_Table
{
    /**
     * Array de dados do modelo
     *
     * @name $_data
     * @access public
     * @var array
     */
    public $_data = array(
                   	                 'idEstado' => "",
                   	                 'nameEstado' => "",
                   	                 'SiglaEstado' => "",
                                  );
    /**
     * Array de valida��o do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                   	                 'idEstado' => array( 'notEmpty','presence'=>'required'),
                   	                 'nameEstado' => array( 'notEmpty','presence'=>'required'),
                   	                 'SiglaEstado' => array( 'notEmpty','presence'=>'required'),
                                  );
    /**
     * Array de descri��o dos dados
     *
     * @name $descriptionFields
     * @access public
     * @var array
     */
    public $descriptionFields = array(
                   	                 'idEstado' => 'C�digo',
                   	                 'nameEstado' => 'Nome',
                   	                 'SiglaEstado' => 'Sigla',
                                  );
					

}

?>