<?php
/*
 * $Id: class.dbOrgUrl.inc.php 12 2006-12-01 01:46:51Z mdean $
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
class dbOrgUrl extends dclDB
{
	function dbOrgUrl()
	{
		parent::dclDB();
		$this->TableName = 'dcl_org_url';
		LoadSchema($this->TableName);
		
		parent::Clear();
	}
	
	function ListByOrg($org_id)
	{
		if (($org_id = DCL_Sanitize::ToInt($org_id)) === null)
		{
			trigger_error('Data sanitize failed.');
			return -1;
		}
		
		$sql = 'SELECT u.org_url_id, u.org_id, u.url_type_id, u.url_addr, u.preferred, t.url_type_name';
		$sql .= ' FROM ' . $this->TableName . ' u, dcl_url_type t WHERE u.org_id = ' . $org_id . ' AND t.url_type_id = u.url_type_id';
		$sql .= ' ORDER BY t.url_type_name';
		return $this->Query($sql);
	}

	function GetPrimaryUrl($iOrgID)
	{
		if (($iOrgID = DCL_Sanitize::ToInt($iOrgID)) === null)
		{
			trigger_error('Data sanitize failed.');
			return -1;
		}
		
		if ($this->Query("SELECT ut.url_type_name, u.url_addr FROM dcl_org_url u, dcl_url_type ut WHERE u.url_type_id = ut.url_type_id AND u.org_id = $iOrgID AND preferred = 'Y'") != -1)
		{
			return $this->next_record();
		}

		return false;
	}
}
?>