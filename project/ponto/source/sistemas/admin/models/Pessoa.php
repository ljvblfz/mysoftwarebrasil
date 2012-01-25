<?php
/**
 * Modelo da tabela pessoa
 *
 * @name Pessoa
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Pessoa extends Axs_Db_Table
{
	/**
	 * Array de dados do modelo
	 *
	 * @name $_data
	 * @access public
	 * @var array
	 */
	public $_data = array(
		'nomePessoa' => null,
		'emailPessoa' => null,
		'nascimentoPessoa' => null,
		'idPerfil' => null,
		'idPessoa' => null,
		);
	/**
	 * Array de validação do modelo
	 *
	 * @name $_validators
	 * @access protected
	 * @var array
	 */
	protected $_validators = array(
		'nomePessoa' => array( 'notEmpty','presence'=>'required'),
		'emailPessoa' => array( 'notEmpty','presence'=>'required'),
		'nascimentoPessoa' => array( 'Date','presence'=>'required'),
		'idPerfil' => array( 'allowEmpty'=>'true'),
		'idPessoa' => array( 'allowEmpty'=>'true'),
		);
	/**
	 * Array de descrição dos dados
	 *
	 * @name $descriptionFields
	 * @access public
	 * @var array
	 */
	public $descriptionFields = array(
		'nomePessoa' => 'Nome',
		'emailPessoa' => 'Email',
		'nascimentoPessoa' => 'Data de Nascimento',
		'idPerfil' => 'Perfil',
		'idPessoa' => 'Código',
		);
	
	/**
	 * Valida os termos de uso
	 *
	 * @name $validUserTerms
	 * @access public
	 * @return Boolean
	 */
	public function validUserTerms($acept)
	{
		if(!$acept)
		{
			$erro["userTerms"] = array("Por favor aceite os termos de uso.");
			$this->setErros($erro);
		}
		return $acept;
	}
}

?>
