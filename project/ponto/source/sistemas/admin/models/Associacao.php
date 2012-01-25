<?php
/**
 * Modelo da tabela associacao
 *
 * @name Associacao
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Associacao extends Axs_Db_Table
{
    /**
     * Array de dados do modelo
     *
     * @name $_data
     * @access public
     * @var array
     */
    public $_data = array(
                   	                 'idTipoAssociacao' => "",
                   	                 'idMembro' => "",
                   	                 'idPessoa' => "",
                   	                 'idAssociacao' => "",
                                  );
    /**
     * Array de valida��o do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                   	                 'idTipoAssociacao' => array( 'notEmpty','presence'=>'required'),
                   	                 'idMembro' => array( 'notEmpty','presence'=>'required'),
                   	                 'idPessoa' => array( 'notEmpty','presence'=>'required'),
                   	                 'idAssociacao' => array( 'notEmpty','presence'=>'required'),
                                  );
    /**
     * Array de descri��o dos dados
     *
     * @name $descriptionFields
     * @access public
     * @var array
     */
    public $descriptionFields = array(
                   	                 'idTipoAssociacao' => 'Tipo de associa��o',
                   	                 'idMembro' => 'Membro',
                   	                 'idPessoa' => 'Pessoa',
                   	                 'idAssociacao' => 'C�digo',
                                  );
					

}

?>