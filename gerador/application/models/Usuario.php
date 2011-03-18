<?php
/**
 *  Modelo Tabala de usuario
 *
 * @name usuario.php
 * @author Alexis Moura 1/4/2009 09:52:39
 * @package models
 * @version $Id$
 */
class Usuario extends Sabv_Db_Table
{

    /**
     * Nome da tabela.
     *
     * @name $_name
     * @access protected
     * @var string
     */
    protected $_name = 'usuario';

    /**
     * Array de valida��o do modelo.
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
										'id'  =>   array ('notEmpty'),
                                        'username'  =>  array ('notEmpty','presence'=>'required'),
                                        'password'  =>  array ('Alnum','presence'=>'required'),
                                        'nome_login'  =>  array ('notEmpty'),
                                        'desc_senha' =>  array ('notEmpty'),
                                        'cod_ent' =>  array ('notEmpty'),
                                        'usuario'=> array ('notEmpty'),
                                        'cargo'=> array ('notEmpty'),

                                  );
    /**
    *   Valida��o dos campos
    *
    * @name validaUpdate
    * @param $data - array
    * @access public
    * @return boleano
    */
    public function validaUpdate(array $data){

       //passa os dados de $data para $dataaux

        $dataAux = $data;
        //verifica se todos os campos s�o coerentes com o modelo
        $result[] = $this->isValid($dataAux);
        //verifica ser houveram erros nas valida��es
        if($this->validacaoCorreta($result)){
            return true;
        }else{
            return false;
        }
    }

}
