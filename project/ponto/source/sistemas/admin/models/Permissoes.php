<?php
/**
 * Modelo da tabela permissoes
 *
 * @name Permissoes
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Permissoes extends Axs_Db_Table
{
	/**
	 * Array de dados do modelo
	 *
	 * @name $_data
	 * @access public
	 * @var array
	 */
	public $_data = array(
		'namePermissao' => null,
		'idAction' => null,
		'idController' => null,
		'idPermissao' => null,
		);
	/**
	 * Array de validação do modelo
	 *
	 * @name $_validators
	 * @access protected
	 * @var array
	 */
	protected $_validators = array(
		'namePermissao' => array('allowEmpty'=>'true'),
		'idAction' => array( 'notEmpty','presence'=>'required'),
		'idController' => array( 'notEmpty','presence'=>'required'),
		'idPermissao' => array('allowEmpty'=>'true'),
		);
	/**
	 * Array de descrição dos dados
	 *
	 * @name $descriptionFields
	 * @access public
	 * @var array
	 */
	public $descriptionFields = array(
		'namePermissao' => 'Nome',
		'idAction' => 'Action',
		'idController' => 'Controller',
		'idPermissao' => 'Código',
		);
	
	
	/**
	 * Carrega os dados no banco.
	 *
	 * @name editAction
	 * @access public
	 * @return void
	 */			
	public function chageData(){
		$permissaorole = new Permissaorole();
		$data = $this->loadData();
		$data['idRole'] = $permissaorole->chageMultCheckbox($this->getWhere($data,2));
		return $data;
	}
	
	/**
	 * Atualização de dados no banco.
	 *
	 * @name editAction
	 * @access public
	 * @return void
	 */
	public function updatePermissoes(Permissaorole $permissaorole,array $dados)
	{
		$this->getAdapter()->beginTransaction();
		
		// Realiza a inserção dos dados na tabela validando novamente
		$result = $this->updateValid(false);
		
		if($result){
			$permissaorole->_data['idPermissao'] = $this->_data['idPermissao'];
			$roles= $permissaorole->chageData($this->getWhere($this->_data,2));
			foreach($dados['idRole'] as $idRole){
				$permissaorole->_data['idRole'] = $idRole;
				if(count($roles) > 0){
					foreach($roles as $arrayValues){
						if(array_search($idRole,$arrayValues))
							$result = $permissaorole->updateOrInsert(false);
						else
							$result = $permissaorole->delete($this->getWhere($arrayValues,2));
					}
				}
				else
					$result = $permissaorole->updateOrInsert(false);

				if(!$result)
					break;
			}
		}
		
		if($result)
			$this->getAdapter()->commit();
		else
			$this->getAdapter()->rollback();
		return $result;
	}
	
	/**
	* Atualização de dados no banco.
	*
	* @name editAction
	* @access public
	* @return void
	*/
	public function insertPermissoes(Permissaorole $permissaorole,array $dados)
	{
		$this->getAdapter()->beginTransaction();
		
		// Realiza a inserção dos dados na tabela validando novamente
		$result = $this->insertValid(false);
		
		if($result){
			$permissaorole->_data['idPermissao'] = $this->_data['idPermissao'];
			foreach($dados['idRole'] as $idRole){
				$permissaorole->_data['idRole'] = $idRole;
				$result = $permissaorole->insertValid(false,false);
				if(!$result)
					break;
			}
		}
		
		if($result)
			$this->getAdapter()->commit();
		else
			$this->getAdapter()->rollback();
		return $result;
	}
	
}

?>
