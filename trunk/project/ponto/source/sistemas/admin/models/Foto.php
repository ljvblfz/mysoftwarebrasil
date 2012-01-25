<?php
/**
 * Modelo da tabela foto
 *
 * @name Foto
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Foto extends Axs_Db_Table
{
	/**
	 * Array de dados do modelo
	 *
	 * @name $_data
	 * @access public
	 * @var array
	 */
	public $_data = array(
		'idFoto' => 0,
		'nameFoto' => null,
		'pathFoto' => null,
		'tipoFoto' => null,
		'idMembro' => 0,
		);
	/**
	 * Array de validação do modelo
	 *
	 * @name $_validators
	 * @access protected
	 * @var array
	 */
	protected $_validators = array(
		'idFoto' => array( 'Int','allowEmpty'=>'true'),
		'nameFoto' => array( 'notEmpty','presence'=>'required'),
		'pathFoto' => array( 'notEmpty','presence'=>'required'),
		'tipoFoto' => array( 'notEmpty','presence'=>'required'),
		'idMembro' => array( 'Int','presence'=>'required'),
		"isAvatarFoto"  => array('allowEmpty'=>'true'),
		"legendaFoto"  => array('allowEmpty'=>'true'),
		);
	/**
	 * Array de descrição dos dados
	 *
	 * @name $descriptionFields
	 * @access public
	 * @var array
	 */
	public $descriptionFields = array(
		'idFoto' => 'Código',
		'nameFoto' => 'Nome',
		'pathFoto' => 'Diretorio',
		'tipoFoto' => 'Tipo',
		'idMembro' => 'Codigo Membro',
		"legendaFoto" => 'Legenda',
		);
	
	/**
	* Método para retorna o avatar do usuario.
	*
	* @name getCidade
	* @param void
	* @access public
	* @return array $dados
	*/
	public function getAvatar($membroId)
	{
		$request = new Zend_Controller_Request_Http();
		$html = "";
		$select = $this->select()
			->where("idMembro = ?",$membroId)
			->where("isAvatarFoto = 1")
		;
		
		$result = $this->fetchRow($select);

		if($result instanceof Zend_Db_Table_Row){
			$result = $result->ToArray();
		}
		return (array)$result;
	}

	/**
	    * Método para retorna todas as fotos do usuario.
	    *
	    * @name getCidade
	    * @param void
	    * @access public
	    * @return array $dados
	    */
	public function getFotos($membroId)
	{
		$select = $this->select()
			->where("idMembro = ?",$membroId)
			->where("isAvatarFoto <> 1")
		;
		$result = $this->fetchAll($select)->ToArray();
		return $result;
	}


	/**
	    * Método para retorna a fotos do usuario.
	    *
	    * @name getCidade
	    * @param void
	    * @access public
	    * @return array $dados
	    */
	public function getFoto($fotoId,$membroId)
	{
		$select = $this->select()
			->where("idMembro = ?",$membroId)
			->where("idFoto = ?",$fotoId)
		;
		$result = $this->fetchRow($select);

		if($result instanceof Zend_Db_Table_Row){
			$result = $result->ToArray();
		}
		else{
			$result = null;
		}
		return $result;
	}

}

?>
