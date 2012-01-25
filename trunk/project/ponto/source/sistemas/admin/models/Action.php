<?php
/**
 * Modelo da tabela action
 *
 * @name Action
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Action extends Axs_Db_Table
{
	/**
	 * Array de dados do modelo
	 *
	 * @name $_data
	 * @access public
	 * @var array
	 */
	public $_data = array(
		'nameAction' => "",
		'idAction' => "",
		);
	/**
	 * Array de validação do modelo
	 *
	 * @name $_validators
	 * @access protected
	 * @var array
	 */
	protected $_validators = array(
		'nameAction' => array('allowEmpty'=>'true'),
		'idAction' => array('allowEmpty'=>'true'),
		);
	/**
	 * Array de descrição dos dados
	 *
	 * @name $descriptionFields
	 * @access public
	 * @var array
	 */
	public $descriptionFields = array(
		'nameAction' => 'Nome',
		'idAction' => 'Código',
		);
	

}

?>
