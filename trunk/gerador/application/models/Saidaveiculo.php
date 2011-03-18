<?php
/**
 * Controle dos Parametros da usuario
 *
 * @name saidaveiculo.php
 * @author Alexis Moura 1/4/2009 10:39:36
 * @package Controller
 * @version $Id$
 */
class Saidaveiculo extends Sabv_Db_Table
{

	/**
     * Array de validação do modelo.
     *
     * @name $_validators
     * @access protected
     * @var array
     */

	protected $_name = 'saida_veiculo';


	/**
     * Array de validação do modelo.
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
										'cod_saida'  =>   array ('allowEmpty' => true),
                                        'cod_usuario'  =>  array ('Alnum','presence'=>'required'),
                                        'data_saida'  =>  array ('Date','allowEmpty' => true),
                                        'cod_veiculo'  =>  array ('Alnum','allowEmpty' => true),



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