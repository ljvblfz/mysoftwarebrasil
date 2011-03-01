<?php
/*
 * $Id: class.dbOrgPhone.inc.php 12 2006-12-01 01:46:51Z mdean $
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
class dbOrgPhone extends dclDB
{
	function dbOrgPhone()
	{
		parent::dclDB();
		$this->TableName = 'dcl_org_phone';
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
		
		$sql = 'SELECT p.org_phone_id, p.org_id, p.phone_type_id, p.phone_number, p.preferred, t.phone_type_name';
		$sql .= ' FROM ' . $this->TableName . ' p, dcl_phone_type t WHERE p.org_id = ' . $org_id . ' AND t.phone_type_id = p.phone_type_id';
		$sql .= ' ORDER BY t.phone_type_name';
		return $this->Query($sql);
	}

	function GetPrimaryPhone($iOrgID)
	{
		if (($iOrgID = DCL_Sanitize::ToInt($iOrgID)) === null)
		{
			trigger_error('Data sanitize failed.');
			return -1;
		}
		
		if ($this->Query("SELECT pt.phone_type_name, p.phone_number FROM dcl_org_phone p, dcl_phone_type pt WHERE p.phone_type_id = pt.phone_type_id AND p.org_id = $iOrgID AND preferred = 'Y'") != -1)
		{
			return $this->next_record();
		}

		return false;
	}
}
?>