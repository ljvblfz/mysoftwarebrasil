<?php
/**
* Classe de acesso a banco de dados
* 
* @name Axs_Db_Table
* @author 
* @see Zend_Db_Table
* @package 
* 
*/

require_once 'Zend/Db/Table.php';
require_once 'Axs/Filter/Input.php';
require_once 'Zend/Filter/StripTags.php';
require_once 'Axs/Db/PropertyInfo.php';

class Axs_Db_Table extends Zend_Db_Table {

	/**
	* Nome da tabela do Banco de Dados
	*
	* @name $_name
	* @access protected
	* @var string
	*/
	protected $_name = '';
	
	/**
	* Dados a ser manipulado
	*
	* @name $_data
	* @access protected
	* @var array
	*/
	protected $_data = array();
	
	/**
	 * Array de validação do modelo
	 *
	 * @name $_validators
	 * @access protected
	 * @var array
	 */
	protected $_validators = array();
	
	/**
	 * Filter array for insert/update methods
	 * 
	 * @var array 
	 */
	protected $_filters = null;

	/**
	 * Variável que conterá o array de erros.
	 * 
	 * @name  $_erros
	 * @access protected
	 * @var array
	 */
	protected $_erros = array();
	
	/**
	 * Variável que conterá o array de mensagens.
	 * 
	 * @name  $_mensagens
	 * @access protected
	 * @var array
	 */
	protected $_mensagens = array();
	
	
	/**
	* Descrição dos campos.
	*
	* @name $descricaoCampos
	* @access protected
	* @var array
	*/
	public $descriptionFields = array ();
	
	/**
	 * Construtor
	 *
	 */
	function __construct() {
		parent::__construct();
		
		// Carrega o nome da tabela
		$this->_name = strtolower(get_class($this));
	} 

	/**
	 * Seta as propriedades da Model.
	 * 
	 * @name getMensagens 
	 * @param string $name nome da propriedade (Identico ao da tabela)
	 * @param string $description descrição do campo a ser apresentado na view
	 * @param array $validator validador da propriedade
	 * @param mixed $value valor default para a propriedade
	 * @access public
	 * @return Axs_Db_PropertyInfo
	 */
	public static function setPropertyInfo($description,$validator,$value=null)
	{
		return new Axs_Db_PropertyInfo($description,$validator,$value);
	}
	
	/**
	* Método para validações especificas do modelo utilizado para inserção.
	*
	* @name validaInsert
	* @param array $data
	* @access public
	* @return boolean
	*/
	public function validaInsert()
	{
		// Verifica se os campos são coerentes com o modelo.
		if(!$this->isValid($this->_data)) {
			return false;
		} else {
			return true;
		}
	}
	
	/**
	* Método para validações especificas do modelo utilizado para atualização.
	*
	* @name validaUpdate
	* @param array $dados
	* @access public
	* @return boolean
	*/
	public function validaUpdate()
	{
		// Verifica se os campos são coerentes com o modelo.
		if(!$this->isValid($this->_data)) {
			return false;
		} else {
			return true;
		}
	}
	
	/**
	 * Método para validações especificas do modelo utilizado para exclusão.
	 *
	 * @name validaDelete
	 * @param array $dados
	 * @access public
	 * @return boolean
	 */
	public function validaDelete()
	{
		// Verifica se os campos são coerentes com o modelo.
		if(!$this->isValid($this->_data)) {
			return false;
		} else {
			return true;
		}
	}
	
	/**
	 * Funcao que recebe os parametros vindos do post ou get e atraves de um filtro retorna apenas campos que estão presentes
	 * na tabela do modelo
	 * 
	 * @name loadFields
	 * @param array $paramans Parametros do POST ou GET ($this->_request->getParams()) 
	 * @acess public 
	 * @return void
	 */    
	public function loadFields($paramans)
	{
		$filter = new Zend_Filter_StripTags();
		foreach((array)$paramans as $key => $value){
			if (array_key_exists($key,$this->_data)) {
				$this->_data[$key] = $filter->filter($value);
				$this->$key = $this->_data[$key];
			} 
		}
	}
	
	/**
	 * Retorna o array de erros.
	 * 
	 * @name getErros  
	 * @access public
	 * @return array
	 */
	public function getErros(){
		return $this->_erros;
	}
	
	/**
	 * Retorna o array de mensagens.
	 * 
	 * @name getMensagens 
	 * @access public
	 * @return array
	 */
	public function getMensagens(){
		return $this->_mensagens;
	}

	/**
	 * Seta o array de erros dentro da variável _erros
	 * 
	 * @name setErros 
	 * @param array $erros
	 * <code>
	 * Configuração do array $erros:
	 * array(nome_do_campo => Mensagem de erro para o campo);
	 * </code>
	 * @access public
	 * @return void
	 */
	public function setErros($erros){
		foreach($erros as $campo => $arrayErros){
			foreach($arrayErros as $indiceErro => $descricaoErro){
				$this->_erros[$campo][] = $descricaoErro;               
			}
		}
	}
	
	/**
	 * Seta o array de erros dentro da variável _mensagens
	 * 
	 * @name setMensagens 
	 * @param array $mensagens
	 * <code>
	 * Configuração do array $mensagens:
	 * array(Mensagem de erro para o campo);
	 * </code>
	 * @access public
	 * @return void
	 */
	public function setMensagens($mensagens){
		$this->_mensagens = $this->_mensagens + $mensagens;    
	}
	
	/**
	 * Verifica se não houveram erros.
	 * 
	 * @name validacaoCorreta 
	 * @param array $result
	 * @access public
	 * @return boolean
	 */
	public function validacaoCorreta($resultado)
	{
		// Iniciando var
		$operacao_ok = false;
		if (is_array($resultado)) {
			if (array_search(false, $resultado) === false && array_search(true, $resultado) !== false) {
				$operacao_ok = true;
			}
		}
		return $operacao_ok;
	}    
	
	/**
	 * Valida e filtra os dados do array
	 * 
	 * @name isValid
	 * @param array $data 
	 * @param array $filters 
	 * @param array $validators 
	 * @acess protected
	 * @return boolean
	 */
	protected function isValid(array &$data, $options = null)
	{
		$input = new Axs_Filter_Input($this->_filters, $this->_validators, $data, $options);
		if ($input->hasInvalid()) {
			$this->setErros($input->getInvalid());
			return false;
		} else if ($input->hasMissing()) {
			$this->setErros($input->getMissing());
			return false;
		} else {
			$data = $input->getUnescaped();
			return true;
		} 
	} 
	
	/**
	 * Retorna true caso exista a string dentro do array.
	 * 
	 * @name array_isearch 
	 * @param string $str string a ser pesquisada dentro de um array
	 * @param array $array array em que será pesquisada a string 
	 * @access protected
	 * @return boolean
	 */
	protected function array_isearch($str, $array){
		foreach ($array as $k => $v){
			if (strtolower($v) == strtolower($str)){
				return true;
			} 
		} 
		return false;
	}

	/**
	 * Convert os dados para o banco de dados.
	 * 
	 * @name convertData 
	 * @param array $data array de dados de entrada no banco.
	 * @access protected
	 * @return array $dataAux array de dados já tratado.
	 */
    protected function convertData($data)
    {
		if(!empty($this->_validators) && count((Array)$data) > 0){

            foreach($data as $key => $value){
                if(isset($this->_validators[$key])){
                    if($this->array_isearch('Float', $this->_validators[$key])){
                        $dataAux[$key] = $this->converteLocaleFloat($value);
                    }
					else if($this->array_isearch('Date', $this->_validators[$key])){
                        $dataAux[$key] = $this->converteLocaleDate($value);
                    }
					else {
                        $dataAux[$key] = $value;
                    }
                } else {
                    $dataAux[$key] = $value;
                }
            }
        } else {
            $dataAux = $data;
        }

        return $dataAux;
	}

    /**
     * Substitui as virgulas por ponto para inserção dos dados no banco.
     *
     * @name converteLocaleFloat
     * @param array $data array de dados de entrada no banco.
     * @access protected
     * @return array $dataAux array de dados já tratado.
     */
    private function converteLocaleFloat($value){

        return str_replace('.', '', $value);
    }

    /**
     * Converte a data
     *
     * @name converteLocaleDate
     * @param date $valor data em qualquer formato.
     * @access protected
     * @return data no formato univarsal
     */
    private function converteLocaleDate($value){

		Zend_Loader::loadClass("Zend_Date");
		$date = new Zend_Date($value.date(' H:i:s'),false);
        return $date->toString("yyyy-MM-dd H:mm:ss");
    }
	
	/**
	* Método para carregar um combobox com dados de chave e nome.
	*
	* @name getComboBox
	* @param void
	* @access public
	* @return array $dados
	    */
	public function getComboBox($isSelecione=true)
	{
		$resultArray =  $isSelecione ? array(0 => "Selecione") : array();
		$select = $this->select()
			->order("name{$this->_name}");
		
		// Carrega o array contendo chave e nome
		$Array = $this->fetchAll($select)->toArray();
		foreach((Array)$Array as $key){
			$id = strtolower("id".$this->_name);
			$name = strtolower("name".$this->_name);
			$keys = array_change_key_case($key);
			if (array_key_exists($id,$keys) && array_key_exists($name,$keys))
			{
				$resultArray[$keys[$id]] = $keys[$name];
			}
		}
		return $resultArray;
	}
	
	/**
	* Retorna o proximo identificador a ser inserido
	* 
	* @name lastInsertId
	* @acess public
	* @return int valor do proximo id
	*/
	public function lastInsertId()
	{
		$keys = (array)$this->info('primary');
		$select = $this->select()
			->from($this->_name, array(new Zend_Db_Expr("max({$keys[1]})+1 as {$keys[1]}")));
		$result = $this->fetchRow($select);
		
		if($result instanceof Zend_Db_Table_Row && empty($this->_data[$keys[1]]))
		{
			$array = (array)$result->toArray();
			$this->_data[$keys[1]] = $array[$keys[1]];
			$this->$keys[1] = $array[$keys[1]];
			return true;
		}
	}
	
	/**
	 * Insere no banco validando os dados de acordo com a validação do modelo
	 * 
	 * @name insertValid
	 * @param array $data User input
	 * @acess public
	 * @return mixed LastInsertId / Error messages
	 */
	public function insertValid($isTransaction=true,$isSequence=true)
	{
		$result = false;
		if($isSequence)
			$this->lastInsertId();
		
		if (!empty($this->_data)) {
			
			$data = $this->convertData($this->_data);
			
			if($isTransaction)
				$this->getAdapter()->beginTransaction();
			$result = parent::insert($data);
			
			if($isTransaction)
				if($result)
					$this->getAdapter()->commit();
				else
					$this->getAdapter()->rollback();
		} 
		return $result;
	}
	
	/**
	 * Atualiza os dados e valida de acordo com a validação do modelo
	 * 
	 * @name updateValid
	 * @param array $data User input
	 * @param mixed $where 
	 * @acess public
	 * @return mixed Number of rows updated / Error messages
	 */
	public function updateOrInsert($isTransaction=true)
	{
		if (!empty($this->_data)) {
			
			if($isTransaction)
				$this->getAdapter()->beginTransaction();
			$where = $this->getWhere($this->_data);
			$data = $this->convertData($this->_data);
			if($this->fetchRow($where) instanceof Zend_Db_Table_Row)
				$result = parent::update($data,$where);
			else
				$result = parent::insert($data);
			
			if($isTransaction)
				if($result)
					$this->getAdapter()->commit();
				else
					$this->getAdapter()->rollback();
		} 
		return $result == 0 ? true : $result;
	}

	/**
	 * Atualiza os dados e valida de acordo com a validação do modelo
	 * 
	 * @name updateValid
	 * @param array $data User input
	 * @param mixed $where 
	 * @acess public
	 * @return mixed Number of rows updated / Error messages
	 */
	public function updateValid($isTransaction=true)
	{
		if (!empty($this->_data)) {
			
			if($isTransaction)
				$this->getAdapter()->beginTransaction();
			
			$result = parent::update($this->convertData($this->_data), $this->getWhere($this->_data));
			
			if($isTransaction)
				if($result)
					$this->getAdapter()->commit();
				else
					$this->getAdapter()->rollback();
		} 
		return $result == 0 ? true : $result;
	}
	
	/**
	* Atualiza os dados e valida de acordo com a validação do modelo
	* 
	* @name updateValid
	* @param array $data User input
	* @param mixed $where 
	* @acess public
	* @return mixed Number of rows updated / Error messages
	*/
	public function deleteValid()
	{
		$this->getAdapter()->beginTransaction();
		$result = parent::delete($this->getWhere($this->_data));
		
		if($result)
			$this->getAdapter()->commit();
		else
			$this->getAdapter()->rollback();
		return $result;
	}
	
	/**
	* Retorna os dados do objeto
	* 
	* @name loadData
	* @acess public
	* @return array
	*/
	public function loadData($paramans = null,$where=null)
	{
		$this->loadFields($paramans);
		if($where == null)
			$where = $this->getWhere($this->_data,2);
		if($where){
			$result = $this->fetchRow($where);
			if($result instanceof Zend_Db_Table_Row)
			{
				$data = $result->toArray();
				$this->loadFields($data);
				return $data;
			}
		}
		return array();
	} 
	
	
	/**
	* Retorna os dados do objeto
	* 
	* @name getData
	* @acess public
	* @return array
	*/
	public function getData()
	{
		return $this->_data;
	}
	
	/**
	* Retorna o Objeto Model da aplicação
	* 
	* @name getModel
	* @acess public
	* @return Axs_Db_Table
	*/
	public static function getModel($object)
	{
		// Carrega as propriedades
		foreach ($object as $name => $value)
		{
			if($object->$name instanceof Zend_Db_Table)
			{
				return $object->$name;
			}
		}
	}
	
	/**
	 * Retorna um objeto vazio do modelo instanciado
	 * 
	 * @name getObjetoVazio
	 * @acess public
	 * @return object Objeto vazio do modelo
	 */
	public function getObjetoVazio()
	{
		$cols = $this->info('cols');
		$obj = new stdClass();
		foreach($cols as $col) {
			$obj->{$col} = null;
		} 
		return $obj;
	}

	/**
	 * Funcao que recebe os parametros vindos do post ou get e atraves de um filtro retorna apenas campos que estão presentes
	 * na tabela do modelo
	 * 
	 * @name getCamposUteis
	 * @param array $parametros Parametros do POST ou GET ($this->_request->getParams()) 
	 * @param boolean $retorno True para retorno em array e False para retorno em objeto
	* @acess public 
	 * @return mixed Array ou Objeto com compos uteis filtrados
	 */    
	public function getCamposUteis($parametros, $retorno = true)
	{
		if (is_array($parametros)) {
			$filter = new Zend_Filter_StripTags();
			$valido = $this->info('metadata');
			if (!$retorno) {
				$data = new stdClass();
				foreach($parametros as $key => $value) {
					if (isset($valido[$key])) {
						$data->$key = $filter->filter($value);
					} 
				} 
				$result[0] = $data;
				return $result; 
			}
			else {
				$data = array();
				foreach($parametros as $key => $value) {
					if (isset($valido[$key])) {
						$data[$key] = $filter->filter($value);
					} 
				}			    
			} 
			return $data;
		} else {
			return false;
		} 
	} 
	

	/**
	 * Funcao que retorna a clausula where do modelo, apenas com suas chaves
	 * 
	 * @name getWhere
	 * @param array $campos Array com os campos uteis do modelo. 
	 * @param boolean $modo 0 - para retornar array no formato array(0 => 'campo = valor') - (padrão)
	* 				        1 - para retornar parâmetros para URIs
	* 						2 - para retornar where string para queries com campos da chave primaria
	*                      3 - para retornar where string de um array qualquer vindo do request
	* @acess public 
	 * @return array|string
	 */    
	public function getWhere($campos,$modo=0)
	{
		$resposta = true;
		$chaves = $this->info('primary');
		if ($modo!=0) {
			$where = '';
		}
		if ($modo != 3) {
			foreach($chaves as $key => $value) {
				if (empty($campos[$value])) {
					$resposta = false;
				} else {
					if ($modo==0) {
						$where[] = "{$value} = '{$campos[$value]}'";
					} elseif($modo==1) {
						$where = $where.'/'.$value.'/'.$campos[$value];
					} elseif($modo==2) {
						$where .= $this->getAdapter()->quoteInto("{$value} = ?", $campos[$value])." AND ";
					}
				}
			}
		}
		else {
			foreach($campos as $key => $value){
				$where .= $this->getAdapter()->quoteInto("{$key} = ?", $value)." AND ";
			}
		}
		if ($modo==2 || $modo==3) {
			$where = rtrim($where, " AND ");
		} 
		return ($resposta?$where:$resposta);
	}
	
	public function isPrimaryKey(array $array){
		$pk = $this->info('primary');
		if(count($array) == count($pk)){
			for($i=1;$i<=count($pk);$i++){
				if(isset($result[$pk[$i]])){
					if(is_array($result[$pk[$i]])){
						foreach($result[$pk[$i]] as $erro => $descricao){
							return false;
						}
					} 
				}
				return true;
			}
		} else {
			return false;
		}
	} 
} 
