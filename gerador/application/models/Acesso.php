<?php
/**
 * Modelo da tabela ACESSO.
 *
 * @name Acesso.php
 * @author Alexis Moura 1/4/2009 10:39:36
 * @package models
 * @version $Id$
 */
class Acesso extends Sabv_Db_Table
{
	protected $_name = 'acesso';

    /**
     * Array de validação do modelo
     *
     * @name $_validators
     * @access protected
     * @var array
     */
    protected $_validators = array(
                                    'cod_ent'           => array ('Digits'),
                                    'cod_acesso'         => array ('Digits'),
                                    'id_role'            => array ('NotEmpty'),
                                    'id_resource'        => array ('NotEmpty'),
                                    'desc_privilegio'    => array ('allowEmpty' => true, 'presence' => 'optional'),
                                    'permissao'          => array ('Int', 'allowEmpty' => true, 'presence' => 'optional'),
                                    'flg_c'              => array ('Digits'),
                                    'flg_i'              => array ('Digits'),
                                    'flg_e'              => array ('Digits'),
                                    'flg_a'              => array ('Digits')
                                );

}