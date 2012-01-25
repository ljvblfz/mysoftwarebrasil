<?php
/**
* Classe de valores das propriedades da model
* 
* @name Axs_Db_PropertyInfo
* @author 
* @see Axs_Db_Table
* @package 
* 
*/
class Axs_Db_PropertyInfo {
	
	/**
	* Descrição da propriedade
	*
	* @name $description
	* @access public
	* @var string
	*/
	protected $description;
	
	/**
	* Valor da propriedade
	*
	* @name $value
	* @access public
	* @var mixed
	*/
	protected $value;
	
	/**
	* Validador da propriedade
	*  Default: sem validaçaõ.
	* @name $validator
	* @access public
	* @var array
	*/
	protected $validator;
	
	/**
	* Construtor
	* @name __construct
	* @return void
	*/
	public function __construct($description,$validator=array( 'allowEmpty'=>'true'),$value=null)
	{
		$this->description = $description;
		$this->validator = $validator;
		$this->value = $value;
	}
	
	/**
	 * Retorna o validator da propriedade.
	 * 
	 * @name getValidaitor 
	 * @access public
	 * @return array
	 */
	public function getValidaitor(){
		return $this->validator;
	}
	
	/**
	 * Retorna a descrição da propriedade.
	 * 
	 * @name getDescription 
	 * @access public
	 * @return string
	 */
	public function getDescription(){
		return $this->description;
	}
	
	/**
	 * Retorna o valor da propriedade.
	 * 
	 * @name getValue 
	 * @access public
	 * @return mixed
	 */
	public function getValue(){
		return $this->value;
	}
	
	/**
	* Seta o valor da propriedade.
	* 
	* @name setName 
	* @access public
	* @return void
	*/
	public function setValue($value){
		$this->value = $value;
	}
}

