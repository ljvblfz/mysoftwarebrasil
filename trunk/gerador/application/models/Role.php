<?php
/**
 * Modelo da tabela ROLE.
 *
 * @name Role.php
 * @author Alexis Moura 1/4/2009 10:39:36
 * @package models
 * @version $Id$
 */
class Role extends Sabv_Db_Table
{
	protected $_name = 'role';

	protected $_primary = 'id';

    protected $_validators = array( 'id'       => array('NotEmpty'),
	                                'id_pai'   => array('allowEmpty' => true),
									'cod_ent'  => array('NotEmpty'));
}