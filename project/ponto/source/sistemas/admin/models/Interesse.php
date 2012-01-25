<?php
/**
 * Modelo da tabela interesse
 *
 * @name Interesse
 * @author Alexis Moura
 * @package _models
 * @version 1.0
 */
class Interesse extends Axs_Db_Table
{
    /**
     * Array de dados do modelo
     *
     * @name $_data
     * @access public
     * @var array
     */
    public $_data = array(
                   	                 'Descricao' => "",
                   	                 'idTipoInteresse' => "",
                   	                 'idPerfil' => "",
                   	                 'idInteresse' => "",
                                  );
    /**
     * Array de validação do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                   	                 'Descricao' => array( 'notEmpty','presence'=>'required'),
                   	                 'idTipoInteresse' => array( 'notEmpty','presence'=>'required'),
                   	                 'idPerfil' => array( 'notEmpty','presence'=>'required'),
                   	                 'idInteresse' => array( 'notEmpty','presence'=>'required'),
                                  );
    /**
     * Array de descrição dos dados
     *
     * @name $descriptionFields
     * @access public
     * @var array
     */
    public $descriptionFields = array(
                   	                 'Descricao' => 'Descrição',
                   	                 'idTipoInteresse' => 'Tipo interesse',
                   	                 'idPerfil' => 'Perfil',
                   	                 'idInteresse' => 'Código',
                                  );
	/**
	* Método para retorna dados para carregar um select.
	*
	* @name getSexo
	* @param void
	* @access public
	* @return array $dados
	*/
	public function getInteresses()
	{
		$result =  array();
		$select = $this->select()
			->from(array('I'=>'Interesse'),array())
			->setIntegrityCheck(false)
			->joinInner(
				array('T'=>'TipoInteresse'),
				"T.idTipoInteresse = I.idTipoInteresse",
				array("*")
				)
			->order("nameTipoInteresse");
		
		// Carrega o array de sexo
		$arrayAux = $this->fetchAll($select)->toArray();
		foreach((array)$arrayAux as $key){
			if (array_key_exists("idTipoInteresse",$key) && array_key_exists("nameTipoInteresse",$key)){
				$result["idTipoInteresse"] = $key["nameTipoInteresse"];
			}
		}
		return $result;
	}				

	/**
	* Método para retorna os interesses do usuario.
	*
	* @name getMemberInteresses
	* @param void
	* @access public
	* @return array $dados
	*/
	public function getMemberInteresses($idPerfil=0)
	{
		$result =  array();
		$select = $this->select()
			->from(array('I'=>'Interesse'),array())
			->setIntegrityCheck(false)
			->joinInner(
				array('T'=>'TipoInteresse'),
				"T.idTipoInteresse = I.idTipoInteresse",
				array("*")
				)
			->where("idPerfil = ?",$idPerfil)
			->order("nameTipoInteresse");
		
		// Carrega o array de sexo
		$arrayAux = $this->fetchAll($select)->toArray();
		foreach((array)$arrayAux as $key){
			if (array_key_exists("idTipoInteresse",$key) && array_key_exists("nameTipoInteresse",$key)){
				$result[] = $key["idTipoInteresse"];
			}
		}
		return $result;
	}	

}

?>
