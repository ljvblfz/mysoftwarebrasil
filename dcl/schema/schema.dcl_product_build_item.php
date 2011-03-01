<?php
/*
 * $Id$
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

$GLOBALS['phpgw_baseline']['dcl_product_build_item'] = array(
	'fd' => array(
		'product_build_id' => array('type' => 'int', 'precision' => 4, 'nullable' => false),
		'entity_type_id' => array('type' => 'int', 'precision' => 4, 'nullable' => false),
		'entity_id' => array('type' => 'int', 'precision' => 4, 'nullable' => false),
		'entity_id2' => array('type' => 'int', 'precision' => 4, 'nullable' => false),
		'created_on' => array('type' => 'timestamp', 'nullable' => true)
	),
	'pk' => array('product_build_id', 'entity_type_id', 'entity_id', 'entity_id2'),
	'fk' => array(),
	'ix' => array(),
	'uc' => array()
);

$GLOBALS['phpgw_baseline']['dcl_product_build_item']['joins'] = array(
	'dcl_product_build' => 'dcl_product_build.product_build_id = dcl_product_build_item.product_build_id',
    'workorders' => 'dcl_product_build_item.entity_type_id = ' . DCL_ENTITY_WORKORDER . ' AND dcl_product_build_item.entity_id = workorders.jcn AND dcl_product_build_item.entity_id2 = workorders.seq',
    'statuses' => 'workorders.status = statuses.id'
);