<?php
/**
 * Modelo da tabela menu
 *
 * @name Menu
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Menu extends Axs_Db_Table
{
	/**
	 * Array de dados do modelo
	 *
	 * @name $_data
	 * @access public
	 * @var array
	 */
	public $_data = array(
		'ordemMenu' => null,
		'pathMenu' => null,
		'MenuIdPai' => null,
		'idMenu' => null,
		'nameMenu' => null,
		);
	/**
	 * Array de validação do modelo
	 *
	 * @name $_validators
	 * @access protected
	 * @var array
	 */
	protected $_validators = array(
		'ordemMenu' => array( 'Int','presence'=>'required'),
		'pathMenu' => array( 'notEmpty','presence'=>'required'),
		'MenuIdPai' => array( 'Int','presence'=>'required'),
		'idMenu' => array( 'allowEmpty'=>'true'),
		'nameMenu' => array( 'notEmpty','presence'=>'required'),
		);
	/**
	 * Array de descrição dos dados
	 *
	 * @name $descriptionFields
	 * @access public
	 * @var array
	 */
	public $descriptionFields = array(
		'ordemMenu' => 'Ordem',
		'pathMenu' => 'URL',
		'MenuIdPai' => 'Menu pai',
		'idMenu' => 'Código',
		'nameMenu' => 'Nome',
		);
	

}

?>
