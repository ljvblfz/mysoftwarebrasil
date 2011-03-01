<?php
/*
 * $Id: schema.personnel.php 128 2009-04-19 18:30:24Z mdean $
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

$GLOBALS['phpgw_baseline']['personnel'] = array(
	'fd' => array(
		'id' => array('type' => 'auto', 'precision' => 4, 'nullable' => false),
		'short' => array('type' => 'varchar', 'precision' => 25, 'nullable' => false),
		'reportto' => array('type' => 'int', 'precision' => 4),
		'department' => array('type' => 'int', 'precision' => 4),
		'pwd' => array('type' => 'varchar', 'precision' => 50, 'nullable' => false),
		'active' => array('type' => 'char', 'precision' => 1, 'default' => 'Y', 'nullable' => false),
		'contact_id' => array('type' => 'int', 'precision' => 4, 'nullable' => false)
	),
	'pk' => array('id'),
	'fk' => array(),
	'ix' => array(),
	'uc' => array('uc_personnel_short' => array('short'))
);

$GLOBALS['phpgw_baseline']['personnel']['joins'] = array(
	'departments' => 'personnel.department = departments.id',
	'personnel a' => 'personnel.reportto = a.id',
	'dcl_contact' => 'personnel.contact_id = dcl_contact.contact_id',
	'dcl_contact_addr' => "dcl_contact.contact_id = dcl_contact_addr.contact_id AND dcl_contact_addr.preferred = 'Y'",
	'dcl_contact_email' => "dcl_contact.contact_id = dcl_contact_email.contact_id AND dcl_contact_email.preferred = 'Y'",
	'dcl_contact_phone' => "dcl_contact.contact_id = dcl_contact_phone.contact_id AND dcl_contact_phone.preferred = 'Y'",
	'dcl_contact_url' => "dcl_contact.contact_id = dcl_contact_url.contact_id AND dcl_contact_url.preferred = 'Y'"
);