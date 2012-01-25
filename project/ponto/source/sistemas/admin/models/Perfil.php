<?php
/**
 * Modelo da tabela perfil
 *
 * @name Perfil
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Perfil extends Axs_Db_Table
{
	/**
	 * Array de dados do modelo
	 *
	 * @name $_data
	 * @access public
	 * @var array
	 */
	public $_data = array(
		'idSexo' => null,
		'idOlho' => null,
		'idCabelo' => null,
		'idEtinia' => null,
		'idEstadoCivil' => null,
		'idEndereco' => null,
		'idPerfil' => null,
		);
	/**
	 * Array de validação do modelo
	 *
	 * @name $_validators
	 * @access protected
	 * @var array
	 */
	protected $_validators = array(
		'idSexo' => array( 'notEmpty','presence'=>'required'),
		'idOlho' => array( 'allowEmpty'=>'true'),
		'idCabelo' => array( 'allowEmpty'=>'true'),
		'idEtinia' => array( 'allowEmpty'=>'true'),
		'idEstadoCivil' => array( 'allowEmpty'=>'true'),
		'idEndereco' => array( 'notEmpty','presence'=>'required'),
		'idPerfil' => array( 'allowEmpty'=>'true'),
		);
	/**
	 * Array de descrição dos dados
	 *
	 * @name $descriptionFields
	 * @access public
	 * @var array
	 */
	public $descriptionFields = array(
		'idSexo' => 'Sexo',
		'idOlho' => 'Olho',
		'idCabelo' => 'Cabelo',
		'idEtinia' => 'Etinia',
		'idEstadoCivil' => 'Estado civil',
		'idEndereco' => 'Endereço',
		'idPerfil' => 'Código',
		);
	

}

?>
