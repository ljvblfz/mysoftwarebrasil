<?php
/*
 * $Id: class.boOrgContact.inc.php 45 2007-02-19 19:46:28Z mdean $
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

LoadStringResource('bo');

import('boAdminObject');
class boOrgContact extends boAdminObject
{
	function boOrgContact()
	{
		parent::boAdminObject();
		
		$this->oDB =& CreateObject('dcl.dbOrgContact');
		$this->Entity = DCL_ENTITY_ORG;
		$this->sKeyField = '';
		
		$this->sCreatedDateField = 'created_on';
		$this->sCreatedByField = 'created_by';
	}
	
	function add($aSource)
	{
		global $g_oSec;

		if (!$g_oSec->HasPerm(DCL_ENTITY_ORG, DCL_PERM_ADD) && !$g_oSec->HasPerm(DCL_ENTITY_CONTACT, DCL_PERM_ADD) && !$g_oSec->HasPerm(DCL_ENTITY_ORG, DCL_PERM_MODIFY) && !$g_oSec->HasPerm(DCL_ENTITY_CONTACT, DCL_PERM_MODIFY))
			return PrintPermissionDenied();
			
		$this->oDB->InitFromArray($aSource);
		if ($this->oDB->Add() == -1)
			return -1;
			
		if (isset($this->sKeyField) && $this->sKeyField != '')
			return $this->oDB->{$this->sKeyField};
		
		return 1;
	}
	
	function modify(&$aSource)
	{
		trigger_error('boOrgContact::modify unsupported');
	}
	
	function delete(&$aSource)
	{
		trigger_error('boOrgContact::delete unsupported');
	}
	
	function deleteByOrg($org_id)
	{
	}
}
?>
