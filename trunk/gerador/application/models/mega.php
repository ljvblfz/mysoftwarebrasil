<?php
/**
 * Modelo da tabela mega
 *
 * @name mega
 * @author Nome
 * @package _models
 * @version $Id$
 */
class mega extends Sabv_Db_Table
{
    /**
     * Nome da tabela do Banco de Dados
     *
     * @name $_name
     * @access protected
     * @var string
     */
    protected $_name = 'mega';

    /**
     * Array de validação do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                     	             'Data' => array('allowEmpty'=>'true'),
                     	             'Dezena1' => array('allowEmpty'=>'true'),
                     	             'Dezena2' => array('allowEmpty'=>'true'),
                     	             'Dezena3' => array('allowEmpty'=>'true'),
                     	             'Dezena4' => array('allowEmpty'=>'true'),
                     	             'Dezena5' => array('allowEmpty'=>'true'),
                     	             'Dezena6' => array('allowEmpty'=>'true'),
                     	             'Arrecadacao_Total' => array('allowEmpty'=>'true'),
                     	             'Ganhadores_Sena' => array('allowEmpty'=>'true'),
                     	             'Rateio_Sena' => array('allowEmpty'=>'true'),
                     	             'Ganhadores_Quina' => array('allowEmpty'=>'true'),
                     	             'Rateio_Quina' => array('allowEmpty'=>'true'),
                     	             'Ganhadores_Quadra' => array('allowEmpty'=>'true'),
                     	             'Rateio_Quadra' => array('allowEmpty'=>'true'),
                     	             'Acumulado' => array('allowEmpty'=>'true'),
                     	             'Valor_Acumulado' => array('allowEmpty'=>'true'),
                     	             'Estimativa_Prêmio' => array('allowEmpty'=>'true'),
                     	             'Acumulado_Natal' => array('allowEmpty'=>'true'),
                   	                 'Concurso' => array( 'notEmpty','presence'=>'required')
                                  );

    /**
     * Array de filtros do modelo
     *
     * @name $_filters
     * @access protected
     * @var array
     */
    protected $_filters = array(
                                  'Data' => array('EmptyStringToNull'),
                                  '1_ Dezena' => array('EmptyStringToNull'),
                                  '2_ Dezena' => array('EmptyStringToNull'),
                                  '3_Dezena' => array('EmptyStringToNull'),
                                  '4_Dezena' => array('EmptyStringToNull'),
                                  '5_Dezena' => array('EmptyStringToNull'),
                                  '6_Dezena' => array('EmptyStringToNull'),
                                  'Arrecadacao_Total' => array('EmptyStringToNull'),
                                  'Ganhadores_Sena' => array('EmptyStringToNull'),
                                  'Rateio_Sena' => array('EmptyStringToNull'),
                                  'Ganhadores_Quina' => array('EmptyStringToNull'),
                                  'Rateio_Quina' => array('EmptyStringToNull'),
                                  'Ganhadores_Quadra' => array('EmptyStringToNull'),
                                  'Rateio_Quadra' => array('EmptyStringToNull'),
                                  'Acumulado' => array('EmptyStringToNull'),
                                  'Valor_Acumulado' => array('EmptyStringToNull'),
                                  'Estimativa_Prêmio' => array('EmptyStringToNull'),
                                  'Acumulado_Natal' => array('EmptyStringToNull'),
                                  'Concurso' => array('EmptyStringToNull')
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
     * Método que retorna a quantidade que a dezena saiu
	 * em todos os concursos independente da ordem.
     *
     * @name retornaQuatSorteada
     * @param int dezena
     * @access public
     * @return int quantidade
     */
    public function retornaQuatSorteada($dezena){

		$dados = array();
		$dados["valor"] = 0;

		$select = $this->select()
					   ->setIntegrityCheck(false)
					   ->from($this,array("count(*) as valor"))
					   ->where("Dezena1 = ? OR Dezena2 = ? OR Dezena3 = ? OR Dezena4 = ? OR Dezena5 = ? OR Dezena6 = ?",$dezena);
		$resultado = $this->fetchRow($select);

		if($resultado instanceof Zend_Db_Table_Row){
			$dados = $resultado->toArray();
		}

		return $dados["valor"];
	}

	/**
     * Método que retorna o intervalo de tempo entra cada dezena foi sorteada
     *
     * @name retornaDataIntervalo
     * @param int $dezena
     * @access public
     * @return array data
     */
	public function retornaDataIntervalo($indice,$dezena){

		// loader classa Zend Date
		Zend_loader::loadClass("Zend_Date");

		// Array de retorno
		$data = array();

		// Seleciona a data e o concusos
		$select = $this->select()
			   ->setIntegrityCheck(false)
			   ->from($this,array("Data","Concurso"))
			   ->where("Dezena{$indice} = ?",$dezena)
			   ->order(array("Data ASC"));
		$dataTodos = $this->fetchAll($select)->toArray();

		// Instancia Zend_Date (DATA MENOR)
		$dataMinima = new Zend_Date($dataTodos[0]["Data"]);

		// Clona o objeto
		$dataAnterior = clone $dataMinima;

		// Percorre as outras datas
		foreach($dataTodos as $concurso => $dataSorteio){

			// Instancia Zend_Date
			$dataPosterior = new Zend_Date($dataSorteio["Data"]);

			// Objeto auxiliar (o metodo subDate tem passagem por referencia)
			$dataPosteriorAUX = clone $dataPosterior;

			// Obtem a diferença entre as datas
			$data[$dataSorteio["Concurso"]] = $dataPosterior->subDate($dataAnterior);

			// Atualiza a data anterior
			$dataAnterior = clone $dataPosteriorAUX;
		}

		return $data;
	}

	/**
     * Método que cria uma istancia Zend_Date
     *
     * @name getData
     * @param string $data
     * @access public
     * @return Zend_Date $dataObj
     */
	public function getData($data){

		Zend_loader::loadClass("Zend_Date");

		// Pega o dia da variavel $data
		$dia = substr($data,8,2);

		// Pega o mês da variavel $data
		$mes = substr($data,5,2);

		// Pega o ano da variavel $data
		$ano = substr($data,0,4);

		$dataObj = new Zend_Date("{$dia}/{$mes}/{$ano}","dd/MM/YYYY");
		return $dataObj;
	}

	/**
     * Método que gera uma matriz estocastica
     *
     * @name getData
     * @param string $data
     * @access public
     * @return Zend_Date $dataObj
     */
	public function geraMatrizEstocastica($dezena1,$dezena2,$matriz,$totalConcursos){

		Zend_Loader::loadClass('Matrix2');
		$Matrix2 = new Matrix2();

		// Inicializa os dados do array
		if(empty($matriz[$dezena1][$dezena2])){
			$matriz[$dezena1][$dezena2] = 0;
		}

		// verifica se as dezenas são diferentes
		if($dezena1 != $dezena2){

			// Total de todas as dezenas sorteadas em todos os concursos
			$totalConcursos = $totalConcursos*6;

			// Objeto select
			$select = $this->select()
						   ->from($this,array("count(*) AS total"))
						   ;
			// Gera um condicional com todas as opçoes possiveis
			for($i=1;$i<=6;$i++){
				for($j=1;$j<=6;$j++){
					if($i != $j){
						$select->reset(Zend_Db_Select::WHERE);
						$select->Where("Dezena{$i} = ?",$dezena1);
						$select->Where("Dezena{$j} = ?",$dezena2);
						$dataObj = $this->fetchRow($select);
						if($dataObj instanceof Zend_Db_Table_Row){
							$dataArray = $dataObj->toArray();
							$matriz[$dezena1][$dezena2] += $dataArray["total"];
						}
					}
				}
			}
			$matriz[$dezena1][$dezena2] = $matriz[$dezena1][$dezena2]/$totalConcursos;
		}
		return $matriz;
	}

	/**
     * Método que gera uma matriz estocastica
     *
     * @name getData
     * @param string $data
     * @access public
     * @return Zend_Date $dataObj
     */
	public function geraMatrizEstocastica3($totalConcursos){

		$valorInicial[1] = 1;
		$valorInicial[2] = 15;
		$valorInicial[3] = 5;

		$continuar = true;

		Zend_Loader::loadClass('Matrix3');
		$Matrix3 = new Matrix3();

		// Total de todas as dezenas sorteadas em todos os concursos
		$totalConcursos = $totalConcursos*6;

		// Objeto select
		$select = $this->select()
					   ->from($this,array("count(*) AS total"))
					   ;
		// Gera um condicional com todas as opçoes possiveis
		for($dezena1=1;$dezena1<=60;$dezena1++){
			if($continuar){
				$dezena1 = $valorInicial[1];
			}
			for($dezena2=1;$dezena2<=60;$dezena2++){
				if($continuar){
					$dezena2 = $valorInicial[2];
				}
				for($dezena3=1;$dezena3<=60;$dezena3++){
					if($continuar){
						$dezena3 = $valorInicial[3];
					}
					// Inicializa os dados do array
					$matriz["Codigo1"] = $dezena1;
					$matriz["Codigo2"] = $dezena2;
					$matriz["Codigo3"] = $dezena3;
					if(($dezena1 != $dezena2 && $dezena1 != $dezena3 && $dezena2 != $dezena3)){
						for($i=1;$i<=6;$i++){
							for($j=1;$j<=6;$j++){
								for($z=1;$z<=6;$z++){
									if($i != $j && $z != $j && $z != $i){
										$select->reset(Zend_Db_Select::WHERE);
										$select->Where("Dezena{$i} = ?",$dezena1);
										$select->Where("Dezena{$j} = ?",$dezena2);
										$select->Where("Dezena{$z} = ?",$dezena3);
										$dataObj = $this->fetchRow($select);
										if($dataObj instanceof Zend_Db_Table_Row){
											$dataArray = $dataObj->toArray();
											$matriz["Valor"] += $dataArray["total"];
										}
									}
								}
							}
						}
					}else{
						$matriz["Valor"] = 0;
					}
					$matriz["Valor"] += $matriz["Valor"]/$totalConcursos;
					// inicia a transação
					$Matrix3->getAdapter()->beginTransaction();
					$resultado = $Matrix3->insert($matriz);
					if(!$resultado){
						$Matrix3->getAdapter()->rollback();
						throw new Zend_Exception("Falha ao inserir dados!!");
					}else{
						$Matrix3->getAdapter()->commit();
					}
					$continuar = false;
				}
			}
		}
		return true;
	}

}

?>
