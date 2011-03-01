<?php
/*
 * $Id: schema.dcl_chklst.php 45 2007-02-19 19:46:28Z mdean $
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

$GLOBALS['phpgw_baseline']['dcl_chklst'] = array(
	'fd' => array(
		'dcl_chklst_id' => array('type' => 'auto', 'precision' => 4, 'nullable' => false),
		'dcl_chklst_tpl_id' => array('type' => 'int', 'precision' => 4, 'nullable' => false),
		'dcl_chklst_summary' => array('type' => 'varchar', 'precision' => 255, 'nullable' => false),
		'dcl_chklst_createby' => array('type' => 'int', 'precision' => 4, 'nullable' => false),
		'dcl_chklst_createon' => array('type' => 'timestamp', 'nullable' => false),
		'dcl_chklst_modifyby' => array('type' => 'int', 'precision' => 4),
		'dcl_chklst_modifyon' => array('type' => 'timestamp'),
		'dcl_chklst_status' => array('type' => 'varchar', 'precision' => 255, 'nullable' => false)
	),
	'pk' => array('dcl_chklst_id'),
	'fk' => array(),
	'ix' => array(),
	'uc' => array()
);
?>
