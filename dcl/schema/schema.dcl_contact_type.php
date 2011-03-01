<?php
/*
 * $Id: schema.dcl_contact_type.php 12 2006-12-01 01:46:51Z mdean $
 *
 * This file is part of Double Choco Latte.
 * Copyright (C) 1999-2004 Free Software Foundation
 *
 * Double Choco Latte is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 *
 * Double Choco Latte is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 *
 * Select License Info from the Help menu to view the terms and conditions of this license.
 */

$GLOBALS['phpgw_baseline']['dcl_contact_type'] = array(
	'fd' => array(
		'contact_type_id' => array('type' => 'auto', 'precision' => 4, 'nullable' => false),
		'contact_type_name' => array('type' => 'varchar', 'precision' => 30, 'nullable' => false),
		'contact_type_is_main' => array('type' => 'char', 'precision' => 1, 'nullable' => false, 'default' => 'N')
	),
	'pk' => array('contact_type_id'),
	'fk' => array(),
	'ix' => array(),
	'uc' => array()
);
?>