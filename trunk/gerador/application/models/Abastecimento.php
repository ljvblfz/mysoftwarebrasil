<?php
/**
 * abastecimento
 *
 * @name abastecimento.php
 * @author Alexis Moura 1/4/2009 10:39:36
 * @package models
 * @version $Id$
 */
class abastecimento extends Sabv_Db_Table
{

	/**
     * Array de validação do modelo.
     *
     * @name $_validators
     * @access protected
     * @var array
     */

	protected $_name = 'abastecimento';


	/**
     * Array de validação do modelo.
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
										'cod_abastecimento'  =>   array ('allowEmpty' => true),
                                        'cod_usuario'  =>  array ('Alnum','presence'=>'required'),
                                        'cod_entidade'  =>  array ('Alnum','allowEmpty' => true),
                                        'cod_posto'  =>  array ('Alnum','allowEmpty' => true),
                                        'cod_veiculo'  =>  array ('Alnum','allowEmpty' => true),
                                        'quantidade_litros'  =>  array ('Float','presence'=>'required'),
                                        'valor_litro'  =>  array ('Float','presence'=>'required'),
                                        'valor_total'  =>  array ('Float','presence'=>'required'),
                                        'data_abastecimento'  =>  array ('allowEmpty' => true),
                                        'tipo_combustivel'  =>  array ('allowEmpty' => true),


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
}