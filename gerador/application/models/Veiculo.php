<?php
/**
 *  Modelo Tabala de veiculo
 *
 * @name veiculo.php
 * @author Alexis Moura 1/4/2009 09:52:39
 * @package models
 * @version $Id$
 */
class Veiculo extends Sabv_Db_Table
{

    /**
     * Nome da tabela.
     *
     * @name $_name
     * @access protected
     * @var string
     */
    protected $_name = 'veiculo';

    /**
     * Array de validação do modelo.
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
										'cod_veiculo'  =>   array ('Alnum','allowEmpty' => true),
                                        'nome_veiculo'  =>  array ('Alnum','presence'=>'required'),
                                        'tipo_veiculo'  =>  array ('Alnum','presence'=>'required'),
                                        'capacidade_tanque'  =>  array ('Float','presence'=>'required'),
                                        'abastecimento_max' =>  array ('Float','presence'=>'required'),
                                        'abastecimento_min' =>  array ('Float','presence'=>'required'),
                                        'cod_usuario'=> array ('notEmpty','allowEmpty' => true),
                                        'cod_entidade'=> array ('notEmpty','allowEmpty' => true),

                                  );
    /**
    *   Validação dos campos
    *
    * @name validaUpdate
    * @param $data - array
    * @access public
    * @return boleano
    */
    public function validaUpdate(array $data){

       //passa os dados de $data para $dataaux

        $dataAux = $data;
        //verifica se todos os campos são coerentes com o modelo
        $result[] = $this->isValid($dataAux);
        //verifica ser houveram erros nas validações
        if($this->validacaoCorreta($result)){
            return true;
        }else{
            return false;
        }
    }

	   /**
    *   Validação dos campos
    *
    * @name validaUpdate
    * @param $data - array
    * @access public
    * @return boleano
    */
    public function validaInsert(array $data){

       //passa os dados de $data para $dataaux

        $dataAux = $data;
        //verifica se todos os campos são coerentes com o modelo
        $result[] = $this->isValid($dataAux);
        //verifica ser houveram erros nas validações
        if($this->validacaoCorreta($result)){
            return true;
        }else{
            return false;
        }
    }


        /**
     *
     *
     * @name
     * @param
     * @access
     * @return
     */
     public function substiuirVirgula($data){

		$localeInfo = localeconv();
		$separadores = $localeInfo['mon_decimal_point'] .$localeInfo['mon_thousands_sep'];

		foreach($data as $key => $valor){

			if ($key == 'capacidade_tanque'||$key == 'abastecimento_max'||$key == 'abastecimento_min') {

				$tempValor = str_replace($localeInfo['mon_thousands_sep'], '', $data[$key]);
        		$data[$key] = str_replace($localeInfo['mon_decimal_point'] , '.', $tempValor);

			}
		}
		return $data;
     }

}
