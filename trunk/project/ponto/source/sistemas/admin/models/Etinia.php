<?php
/**
 * Modelo da tabela etinia
 *
 * @name Etinia
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Etinia extends Axs_Db_Table
{
    /**
     * Array de dados do modelo
     *
     * @name $_data
     * @access public
     * @var array
     */
    public $_data = array(
                   	                 'idEtinia' => "",
                   	                 'nameEtinia' => "",
                                  );
    /**
     * Array de validação do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                   	                 'idEtinia' => array( 'notEmpty','presence'=>'required'),
                   	                 'nameEtinia' => array( 'notEmpty','presence'=>'required'),
                                  );
    /**
     * Array de descrição dos dados
     *
     * @name $descriptionFields
     * @access public
     * @var array
     */
    public $descriptionFields = array(
                   	                 'idEtinia' => 'Código',
                   	                 'nameEtinia' => 'Nome',
                                  );
					

}

?>
