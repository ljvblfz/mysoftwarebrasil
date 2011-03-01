<?php
/*
 * $Id: schema.dcl_wo_account_audit.php 12 2006-12-01 01:46:51Z mdean $
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

$GLOBALS['phpgw_baseline']['dcl_wo_account_audit'] = array(
	'fd' => array(
		'wo_id' => array('type' => 'int', 'precision' => 4, 'nullable' => false),
		'seq' => array('type' => 'int', 'precision' => 4, 'nullable' => false),
		'account_id' => array('type' => 'int', 'precision' => 4, 'nullable' => false),
		'audit_on' => array('type' => 'timestamp', 'nullable' => false),
		'audit_by' => array('type' => 'int', 'precision' => 4, 'nullable' => false),
		'audit_type' => array('type' => 'int', 'precision' => 4, 'nullable' => false)
	),
	'pk' => array(),
	'fk' => array(),
	'ix' => array('ix_dcl_wo_account_audit' => array('wo_id', 'seq', 'account_id')),
	'uc' => array()
);
?>
