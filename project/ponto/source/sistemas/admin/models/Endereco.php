<?php
/**
 * Modelo da tabela endereco
 *
 * @name Endereco
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Endereco extends Axs_Db_Table
{
	/**
	 * Array de dados do modelo
	 *
	 * @name $_data
	 * @access public
	 * @var array
	 */
	public $_data = array(
		'CEP' => null,
		'idCidade' => null,
		'idBairro' => null,
		'idEndereco' => null,
		);
	/**
	 * Array de validação do modelo
	 *
	 * @name $_validators
	 * @access protected
	 * @var array
	 */
	protected $_validators = array(
		'CEP' => array('allowEmpty'=>'true'),
		'idCidade' => array( 'notEmpty','presence'=>'required'),
		'idBairro' => array( 'allowEmpty'=>'true'),
		'idEndereco' => array( 'allowEmpty'=>'true'),
		);
	/**
	 * Array de descrição dos dados
	 *
	 * @name $descriptionFields
	 * @access public
	 * @var array
	 */
	public $descriptionFields = array(
		'CEP' => 'CEP',
		'idCidade' => 'Cidade',
		'idBairro' => 'Bairro',
		'idEndereco' => 'Código',
		);
	

}

?>
