<?php
/**
 * Modelo da tabela cidade
 *
 * @name Cidade
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Cidade extends Axs_Db_Table
{
	/**
	 * Array de dados do modelo
	 *
	 * @name $_data
	 * @access public
	 * @var array
	 */
	public $_data = array(
		'nameCidade' => "",
		'idEstado' => "",
		'idCidade' => "",
		);
	/**
	 * Array de validação do modelo
	 *
	 * @name $_validators
	 * @access protected
	 * @var array
	 */
	protected $_validators = array(
		'nameCidade' => array( 'notEmpty','presence'=>'required'),
		'idEstado' => array( 'notEmpty','presence'=>'required'),
		'idCidade' => array( 'notEmpty','presence'=>'required'),
		);
	/**
	 * Array de descrição dos dados
	 *
	 * @name $descriptionFields
	 * @access public
	 * @var array
	 */
	public $descriptionFields = array(
		'nameCidade' => 'Nome',
		'idEstado' => 'Estado',
		'idCidade' => 'Código',
		);
	
	/**
	* Método para retorna dados para carregar um select.
	*
	* @name getCidade
	* @param void
	* @access public
	* @return array $dados
	*/
	public function getCidade($idEstado)
	{
		$resultArray = array();
		$select = $this->select()
			->order("nameCidade")
			->where("idEstado = ?",$idEstado);

		// Carrega o array de sexo
		$result = $this->fetchAll($select)->ToArray();
		foreach($result as $key){
			$resultArray[$key['idCidade']] = $key['nameCidade'];
		}
		return $resultArray;
	}
}

?>
