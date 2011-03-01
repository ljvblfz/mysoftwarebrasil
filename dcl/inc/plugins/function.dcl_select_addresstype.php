<?php
/*
 * $Id: function.dcl_select_addresstype.php 12 2006-12-01 01:46:51Z mdean $
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

function smarty_function_dcl_select_addresstype($params, &$smarty)
{
	if (!isset($params['name']))
		$params['name'] = 'addr_type_id';

	if (!isset($params['id']))
		$params['id'] = $params['name'];

	if (!isset($params['default']))
		$params['default'] = '';

	if (!isset($params['size']))
		$params['size'] = 1;

	$sSQL = 'SELECT addr_type_id, addr_type_name FROM dcl_addr_type ORDER BY addr_type_name';

	$oSelect =& CreateObject('dcl.htmlSelect');
	$oSelect->vDefault = $params['default'];
	$oSelect->sName = $params['name'];
	$oSelect->iSize = $params['size'];
	$oSelect->sZeroOption = STR_CMMN_SELECTONE;
	$oSelect->SetFromQuery($sSQL);

	return $oSelect->GetHTML();
}
?>