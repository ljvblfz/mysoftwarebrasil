<?php
/*
 * $Id: class.dbOrgProduct.inc.php 66 2007-02-27 07:20:51Z mdean $
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

LoadStringResource('db');
class dbOrgProduct extends dclDB
{
	function dbOrgProduct()
	{
		parent::dclDB();
		$this->TableName = 'dcl_org_product_xref';
		LoadSchema($this->TableName);
		
		parent::Clear();
	}
	
	function updateProducts($org_id, &$aProductID)
	{
		if (($org_id = DCL_Sanitize::ToInt($org_id)) === null)
			return PrintPermissionDenied();
			
		$aProductID = DCL_Sanitize::ToIntArray($aProductID);
		if ($aProductID === null || count($aProductID) == 0)
			$aProductID = array("-1");
			
		$sProductID = join(',', $aProductID);
		
		$this->Execute("DELETE FROM dcl_org_product_xref WHERE org_id = $org_id AND product_id NOT IN ($sProductID)");
		$this->Execute("INSERT INTO dcl_org_product_xref (org_id, product_id) SELECT $org_id, id FROM products WHERE id IN ($sProductID) AND id NOT IN (SELECT product_id FROM dcl_org_product_xref WHERE org_id = $org_id)");
	}
	
	function ListByOrg($org_id)
	{
		if (($org_id = DCL_Sanitize::ToInt($org_id)) === null)
		{
			trigger_error('Data sanitize failed.');
			return -1;
		}
		
		$sql = 'SELECT p.id, op.org_id, p.name';
		$sql .= ' FROM dcl_org_product_xref op, products p WHERE op.org_id = ' . $org_id . ' AND p.id = op.product_id';
		$sql .= ' ORDER BY p.name';
		
		return $this->Query($sql);
	}
}
?>
