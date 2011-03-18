<?php
/**
 * Modelo da tabela quantidade
 *
 * @name Quantidadequantidade
 * @author Nome
 * @package quantidade_models
 * @version $Id$
 */
class Quantidade extends SABV_Db_Table
{
    /**
     * Nome do esquema
     *
     * @name $_schema
     * @access protected
     * @var string
     */
    protected $_schema = '';

    /**
     * Nome da tabela do Banco de Dados
     *
     * @name $_name
     * @access protected
     * @var string
     */
    protected $_name = 'quantidade';

    /**
     * Array de validação do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                     	             'Quantidade' => array( 'notEmpty','presence'=>'required'),
                   	                 'Dezena' => array( 'notEmpty','presence'=>'required')
                                  );

    /**
     * Array de filtros do modelo
     *
     * @name $_filters
     * @access protected
     * @var array
     */
    protected $_filters = array(
                                  'Quantidade' => array('EmptyStringToNull'),
                                  'Dezena' => array('EmptyStringToNull')
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

    public function insereQuantidade($quantidade){

		// inicia a transação
		$this->getAdapter()->beginTransaction();
		$saida = true;
		foreach($quantidade as $key =>$value){
			$insertT["Dezena"] = $key;
			$insertT["Quantidade"] = $value;
			$resultado = $this->insert($insertT);
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
