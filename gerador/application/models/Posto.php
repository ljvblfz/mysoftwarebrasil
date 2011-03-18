<?php
/**
 * modelo do posto
 *
 * @name posto.php
 * @author Alexis Moura 1/4/2009 10:39:36
 * @package Controller
 * @version $Id$
 */
class posto extends Sabv_Db_Table
{

	/**
     * Array de validação do modelo.
     *
     * @name $_validators
     * @access protected
     * @var array
     */

	protected $_name = 'posto';


	/**
     * Array de validação do modelo.
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
										'cod_posto'  =>   array ('allowEmpty' => true),
                                        'nome'  =>  array ('notEmpty','presence'=>'required'),
                                        'data_cadastro'  =>  array ('Date','allowEmpty' => true),
                                        'data_vencimento_contrato'  =>  array ('Date','allowEmpty' => true),
                                        'num_cnpj' => array ('Cnpj','presence'=>'required'),
                                        'desc_email'  => array ('allowEmpty' => true),
                                        'desc_endereco'  =>array ('allowEmpty' => true),
                                        'nome_bairro'  => array ('allowEmpty' => true),
                                        'nome_cidade'  => array ('allowEmpty' => true),
                                        'sgl_uf'  =>array ('allowEmpty' => true),
                                        'num_cep'  =>array ('allowEmpty' => true),
                                        'num_fax'  => array ('Alnum','allowEmpty' => true),
                                        'telefone	'  => array ('Alnum','allowEmpty' => true),

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
