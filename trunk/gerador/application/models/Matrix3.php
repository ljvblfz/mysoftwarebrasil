<?php
/**
 * Modelo da tabela matrix_3
 *
 * @name Matrix3
 * @author Nome
 * @package _models
 * @version $Id$
 */
class Matrix3 extends Sabv_Db_Table
{
    /**
     * Nome da tabela do Banco de Dados
     *
     * @name $_name
     * @access protected
     * @var string
     */
    protected $_name = 'matrix_3';

    /**
     * Array de validação do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                     	             'Codigo1' => array('allowEmpty'=>'true'),
                     	             'Codigo2' => array('allowEmpty'=>'true'),
                     	             'Codigo3' => array('allowEmpty'=>'true'),
                     	             'Valor' => array('allowEmpty'=>'true'),
                                  );

    /**
     * Array de filtros do modelo
     *
     * @name $_filters
     * @access protected
     * @var array
     */
    protected $_filters = array(
                                  'Codigo2' => array('EmptyStringToNull'),
                                  'Num1' => array('EmptyStringToNull'),
                                  'Codigo3' => array('EmptyStringToNull'),
                                  'Codigo1' => array('EmptyStringToNull')
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


    	public function insereMatrix3($matriz)
    {
		// inicia a transação
		$this->getAdapter()->beginTransaction();

		$saida = true;
		foreach($matriz as $chave => $valor)
		{
			$insert = array();
			$insert["Codigo1"] = $chave;
			foreach($valor as $chave2 => $valor2){
				$insert["Codigo2"] = $chave2;
				foreach($valor2 as $chave3 => $valor3){
					$insert["Num{$key}"] = $valor3;
				}
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
