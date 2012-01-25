<?php
/**
 * Modelo da tabela membro
 *
 * @name Membro
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Membro extends Axs_Db_Table
{
	/**
	 * Array de dados do modelo
	 *
	 * @name $_data
	 * @access public
	 * @var array
	 */
	public $_data = array(
		'loginMembro' => null,
		'senhaMembro' => null,
		'idPessoa' => null,
		'idRole' => null,
		'idMembro' => null,
		);
	/**
	 * Array de validação do modelo
	 *
	 * @name $_validators
	 * @access protected
	 * @var array
	 */
	protected $_validators = array(
		'loginMembro' => array( 'notEmpty','presence'=>'required'),
		'senhaMembro' => array( 'notEmpty','presence'=>'required'),
		'idPessoa' => array( 'allowEmpty'=>'true'),
		'idRole' => array( 'notEmpty','presence'=>'required'),
		'idMembro' => array( 'allowEmpty'=>'true'),
		);
	/**
	 * Array de descrição dos dados
	 *
	 * @name $descriptionFields
	 * @access public
	 * @var array
	 */
	public $descriptionFields = array(
		'loginMembro' => 'Login',
		'senhaMembro' => 'Senha',
		'idPessoa' => 'Pessoa',
		'idRole' => 'Role',
		'idMembro' => 'Código',
		);
	

}

?>
