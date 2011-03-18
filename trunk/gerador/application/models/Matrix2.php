<?php
/**
 * Modelo da tabela matrix_2
 *
 * @name Matrix_2
 * @author Nome
 * @package sistema_models
 * @version $Id$
 */
class Matrix2 extends Sabv_Db_Table
{

    /**
     * Nome da tabela do Banco de Dados
     *
     * @name $_name
     * @access protected
     * @var string
     */
    protected $_name = 'matrix_2';

    /**
     * Array de validação do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                     	             'Num1' => array('allowEmpty'=>'true'),
                     	             'Num2' => array('allowEmpty'=>'true'),
                     	             'Num3' => array('allowEmpty'=>'true'),
                     	             'Num4' => array('allowEmpty'=>'true'),
                     	             'Num5' => array('allowEmpty'=>'true'),
                     	             'Num6' => array('allowEmpty'=>'true'),
                     	             'Num7' => array('allowEmpty'=>'true'),
                     	             'Num8' => array('allowEmpty'=>'true'),
                     	             'Num9' => array('allowEmpty'=>'true'),
                     	             'Num10' => array('allowEmpty'=>'true'),
                     	             'Num11' => array('allowEmpty'=>'true'),
                     	             'Num12' => array('allowEmpty'=>'true'),
                     	             'Num13' => array('allowEmpty'=>'true'),
                     	             'Num14' => array('allowEmpty'=>'true'),
                     	             'Num15' => array('allowEmpty'=>'true'),
                     	             'Num16' => array('allowEmpty'=>'true'),
                     	             'Num17' => array('allowEmpty'=>'true'),
                     	             'Num18' => array('allowEmpty'=>'true'),
                     	             'Num19' => array('allowEmpty'=>'true'),
                     	             'Num20' => array('allowEmpty'=>'true'),
                     	             'Num21' => array('allowEmpty'=>'true'),
                     	             'Num22' => array('allowEmpty'=>'true'),
                     	             'Num23' => array('allowEmpty'=>'true'),
                     	             'Num24' => array('allowEmpty'=>'true'),
                     	             'Num25' => array('allowEmpty'=>'true'),
                     	             'Num26' => array('allowEmpty'=>'true'),
                     	             'Num27' => array('allowEmpty'=>'true'),
                     	             'Num28' => array('allowEmpty'=>'true'),
                     	             'Num29' => array('allowEmpty'=>'true'),
                     	             'Num30' => array('allowEmpty'=>'true'),
                     	             'Num31' => array('allowEmpty'=>'true'),
                     	             'Num32' => array('allowEmpty'=>'true'),
                     	             'Num33' => array('allowEmpty'=>'true'),
                     	             'Num34' => array('allowEmpty'=>'true'),
                     	             'Num35' => array('allowEmpty'=>'true'),
                     	             'Num36' => array('allowEmpty'=>'true'),
                     	             'Num37' => array('allowEmpty'=>'true'),
                     	             'Num38' => array('allowEmpty'=>'true'),
                     	             'Num39' => array('allowEmpty'=>'true'),
                     	             'Num40' => array('allowEmpty'=>'true'),
                     	             'Num41' => array('allowEmpty'=>'true'),
                     	             'Num42' => array('allowEmpty'=>'true'),
                     	             'Num43' => array('allowEmpty'=>'true'),
                     	             'Num44' => array('allowEmpty'=>'true'),
                     	             'Num45' => array('allowEmpty'=>'true'),
                     	             'Num46' => array('allowEmpty'=>'true'),
                     	             'Num47' => array('allowEmpty'=>'true'),
                     	             'Num48' => array('allowEmpty'=>'true'),
                     	             'Num49' => array('allowEmpty'=>'true'),
                     	             'Num50' => array('allowEmpty'=>'true'),
                     	             'Num51' => array('allowEmpty'=>'true'),
                     	             'Num52' => array('allowEmpty'=>'true'),
                     	             'Num53' => array('allowEmpty'=>'true'),
                     	             'Num54' => array('allowEmpty'=>'true'),
                     	             'Num55' => array('allowEmpty'=>'true'),
                     	             'Num56' => array('allowEmpty'=>'true'),
                     	             'Num57' => array('allowEmpty'=>'true'),
                     	             'Num58' => array('allowEmpty'=>'true'),
                     	             'Num59' => array('allowEmpty'=>'true'),
                     	             'Num60' => array('allowEmpty'=>'true'),
                   	                 'Codigo' => array( 'notEmpty','presence'=>'required')
                                  );

    /**
     * Array de filtros do modelo
     *
     * @name $_filters
     * @access protected
     * @var array
     */
    protected $_filters = array(
                                  'Num1' => array('EmptyStringToNull'),
                                  'Num2' => array('EmptyStringToNull'),
                                  'Num3' => array('EmptyStringToNull'),
                                  'Num4' => array('EmptyStringToNull'),
                                  'Num5' => array('EmptyStringToNull'),
                                  'Num6' => array('EmptyStringToNull'),
                                  'Num7' => array('EmptyStringToNull'),
                                  'Num8' => array('EmptyStringToNull'),
                                  'Num9' => array('EmptyStringToNull'),
                                  'Num10' => array('EmptyStringToNull'),
                                  'Num11' => array('EmptyStringToNull'),
                                  'Num12' => array('EmptyStringToNull'),
                                  'Num13' => array('EmptyStringToNull'),
                                  'Num14' => array('EmptyStringToNull'),
                                  'Num15' => array('EmptyStringToNull'),
                                  'Num16' => array('EmptyStringToNull'),
                                  'Num17' => array('EmptyStringToNull'),
                                  'Num18' => array('EmptyStringToNull'),
                                  'Num19' => array('EmptyStringToNull'),
                                  'Num20' => array('EmptyStringToNull'),
                                  'Num21' => array('EmptyStringToNull'),
                                  'Num22' => array('EmptyStringToNull'),
                                  'Num23' => array('EmptyStringToNull'),
                                  'Num24' => array('EmptyStringToNull'),
                                  'Num25' => array('EmptyStringToNull'),
                                  'Num26' => array('EmptyStringToNull'),
                                  'Num27' => array('EmptyStringToNull'),
                                  'Num28' => array('EmptyStringToNull'),
                                  'Num29' => array('EmptyStringToNull'),
                                  'Num30' => array('EmptyStringToNull'),
                                  'Num31' => array('EmptyStringToNull'),
                                  'Num32' => array('EmptyStringToNull'),
                                  'Num33' => array('EmptyStringToNull'),
                                  'Num34' => array('EmptyStringToNull'),
                                  'Num35' => array('EmptyStringToNull'),
                                  'Num36' => array('EmptyStringToNull'),
                                  'Num37' => array('EmptyStringToNull'),
                                  'Num38' => array('EmptyStringToNull'),
                                  'Num39' => array('EmptyStringToNull'),
                                  'Num40' => array('EmptyStringToNull'),
                                  'Num41' => array('EmptyStringToNull'),
                                  'Num42' => array('EmptyStringToNull'),
                                  'Num43' => array('EmptyStringToNull'),
                                  'Num44' => array('EmptyStringToNull'),
                                  'Num45' => array('EmptyStringToNull'),
                                  'Num46' => array('EmptyStringToNull'),
                                  'Num47' => array('EmptyStringToNull'),
                                  'Num48' => array('EmptyStringToNull'),
                                  'Num49' => array('EmptyStringToNull'),
                                  'Num50' => array('EmptyStringToNull'),
                                  'Num51' => array('EmptyStringToNull'),
                                  'Num52' => array('EmptyStringToNull'),
                                  'Num53' => array('EmptyStringToNull'),
                                  'Num54' => array('EmptyStringToNull'),
                                  'Num55' => array('EmptyStringToNull'),
                                  'Num56' => array('EmptyStringToNull'),
                                  'Num57' => array('EmptyStringToNull'),
                                  'Num58' => array('EmptyStringToNull'),
                                  'Num59' => array('EmptyStringToNull'),
                                  'Num60' => array('EmptyStringToNull'),
                                  'Codigo' => array('EmptyStringToNull')
                                );

    /**
     * Método para validações especificas do modelo utilizado para inserção.
     *
     * @name validaInsert
     * @param array $data
     * @access public
     * @return boolean
     */
    public function validaInsert($dados)
    {
        // Verifica se os campos são coerentes com o modelo.
        if(!$this->isValid($dados)) {
        	Rps_Db_Table::setErrosStatic($this->getErros());
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
    public function validaUpdate($dados)
    {
        // Verifica se os campos são coerentes com o modelo.
        if(!$this->isValid($dados)) {
        	Rps_Db_Table::setErrosStatic($this->getErros());
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
    public function validaDelete($dados)
    {
        // Verifica se os campos são coerentes com o modelo.
        if(!$this->isValid($dados)) {
        	Rps_Db_Table::setErrosStatic($this->getErros());
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
    public function retornaSena($inicial)
    {
    	$sena[1] = $inicial;
		$evitarRepetir[] = $inicial;
    	for($i=2;$i<=6;$i++){

			$select = $this->select()
						   ->setIntegrityCheck(false)
						   ->from($this,array("*"))
						   ->where("Codigo = ?",$inicial)
						   ;

			$resultado = $this->fetchRow($select);

			if($resultado instanceof Zend_Db_Table_Row){

				$resultadoArray = $resultado->toArray();
				$valorMaximo = 0;
				$keyMaximo = null;
				foreach((Array)$resultadoArray as $key => $value){
					$sairLoop = false;
					if($key != "Codigo"){
						foreach($evitarRepetir as $key2 => $value2){
							if($value2 == substr($key,3,3)){
								$sairLoop = true;
							}
						}
						if($sairLoop){
							$sairLoop = false;
							continue;
						}
						if($valorMaximo<$value){
							$valorMaximo = $value;
							$keyMaximo = $key;
						}
					}
				}
				$sena[$i] = substr($keyMaximo,3,3);
				$inicial = $sena[$i];
				$evitarRepetir[] = $inicial;
			}
		}
		return $sena;
    }

    public function insereMatrix($matriz)
    {
		// inicia a transação
		$this->getAdapter()->beginTransaction();

		$saida = true;
		foreach($matriz as $chave => $valor)
		{
			$insert = array();
			$insert["Codigo"] = $chave;
			foreach($valor as $key => $value){
				$insert["Num{$key}"] = $value;
			}
			$resultado = $this->insert($insert);
			if($resultado){
				continue;
			}else{
				$this->getAdapter()->rollback();
				$saida = false;
				break;
			}
		}

		if($saida){
			// Finaliza a transação realizando o commit ou o rollback
			$this->getAdapter()->commit();
		}
		return $saida;
	}


}

?>
