<?php
/**
 * Modelo da tabela controller
 *
 * @name Controller
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Controller extends Axs_Db_Table
{
	/**
	 * Array de dados do modelo
	 *
	 * @name $_data
	 * @access public
	 * @var array
	 */
	public $_data = array(
		'nameController' => "",
		'idController' => "",
		);
	/**
	 * Array de validação do modelo
	 *
	 * @name $_validators
	 * @access protected
	 * @var array
	 */
	protected $_validators = array(
		'nameController' => array('allowEmpty'=>'true'),
		'idController' => array('allowEmpty'=>'true'),
		);
	/**
	 * Array de descrição dos dados
	 *
	 * @name $descriptionFields
	 * @access public
	 * @var array
	 */
	public $descriptionFields = array(
		'nameController' => 'Nome',
		'idController' => 'Código',
		);
	

}

?>
