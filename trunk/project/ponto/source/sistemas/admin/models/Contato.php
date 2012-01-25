<?php
/**
 * Modelo da tabela contato
 *
 * @name Contato
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Contato extends Axs_Db_Table
{
    /**
     * Array de dados do modelo
     *
     * @name $_data
     * @access public
     * @var array
     */
    public $_data = array(
                   	                 'idPerfil' => "",
                   	                 'idTipoContato' => "",
                   	                 'idContato' => "",
                   	                 'valorContato' => "",
                                  );
    /**
     * Array de validação do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                   	                 'idPerfil' => array( 'notEmpty','presence'=>'required'),
                   	                 'idTipoContato' => array( 'notEmpty','presence'=>'required'),
                   	                 'idContato' => array( 'notEmpty','presence'=>'required'),
                   	                 'valorContato' => array( 'notEmpty','presence'=>'required'),
                                  );
    /**
     * Array de descrição dos dados
     *
     * @name $descriptionFields
     * @access public
     * @var array
     */
    public $descriptionFields = array(
                   	                 'idPerfil' => 'Perfil',
                   	                 'idTipoContato' => 'Tipo de Contato',
                   	                 'idContato' => 'Código',
                   	                 'valorContato' => 'Valor',
                                  );
					

}

?>