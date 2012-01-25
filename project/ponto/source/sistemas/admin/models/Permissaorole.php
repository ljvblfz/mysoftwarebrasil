<?php
/**
 * Modelo da tabela permissaorole
 *
 * @name Permissaorole
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Permissaorole extends Axs_Db_Table
{
	/**
	 * Array de dados do modelo
	 *
	 * @name $_data
	 * @access public
	 * @var array
	 */
	public $_data = array(
		'idRole' => "",
		'idPermissao' => "",
		);
	/**
	 * Array de validação do modelo
	 *
	 * @name $_validators
	 * @access protected
	 * @var array
	 */
	protected $_validators = array(
		'idRole' => array( 'notEmpty','presence'=>'required'),
		'idPermissao' => array( 'notEmpty','presence'=>'required'),
		);
	/**
	 * Array de descrição dos dados
	 *
	 * @name $descriptionFields
	 * @access public
	 * @var array
	 */
	public $descriptionFields = array(
		'idRole' => 'Role',
		'idPermissao' => 'Permissão',
		);
	
	/**
	* Retorna os dados
	* 
	* @name ChageData
	* @acess public
	* @return array
	*/				
	public function chageData($where){
		return $this->fetchAll($where)->toArray();
	}
	
	/**
	* Retorna os dados para multickebox
	* 
	* @name ChageMultCheckbox
	* @acess public
	* @return array
	*/				
	public function chageMultCheckbox($where){
		$data = $this->chageData($where);
		foreach($data as $value){
			$result[] = $value["idRole"];
		}
		return $result;
	}
}

?>
