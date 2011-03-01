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

class htmlHotlistForm
{
	var $public;

	function htmlHotlistForm()
	{
		$this->public = array('add', 'modify', 'delete', 'submitAdd', 'submitModify', 'submitDelete');
	}

	function add()
	{
		global $g_oSec;
		
		commonHeader();
		if (!$g_oSec->HasPerm(DCL_ENTITY_HOTLIST, DCL_PERM_ADD))
			return PrintPermissionDenied();

		$this->ShowEntryForm();
	}

	function copy()
	{
		global $g_oSec;
		
		commonHeader();
		
		if (($id = DCL_Sanitize::ToInt($_REQUEST['hotlist_id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if (!$g_oSec->HasPerm(DCL_ENTITY_HOTLIST, DCL_PERM_ADD))
			return PrintPermissionDenied();

		$obj = CreateObject('dcl.dbHotlist');
		$obj->hotlist_id = $id;
		$this->ShowEntryForm($obj, true);
	}

	function modify()
	{
		global $g_oSec;
		
		commonHeader();
		if (($id = DCL_Sanitize::ToInt($_REQUEST['hotlist_id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if (!$g_oSec->HasPerm(DCL_ENTITY_HOTLIST, DCL_PERM_MODIFY))
			return PrintPermissionDenied();

		$obj = CreateObject('dcl.dbHotlist');
		if ($obj->Load($id) == -1)
			return;
			
		$this->ShowEntryForm($obj);
	}

	function delete()
	{
		global $g_oSec;
		
		commonHeader();
		if (($id = DCL_Sanitize::ToInt($_REQUEST['hotlist_id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if (!$g_oSec->HasPerm(DCL_ENTITY_HOTLIST, DCL_PERM_DELETE))
			return PrintPermissionDenied();

		$obj = CreateObject('dcl.dbHotlist');
		if ($obj->Load($id) == -1)
			return;
			
		ShowDeleteYesNo('Hotlist', 'htmlHotlistForm.submitDelete', $obj->hotlist_id, $obj->hotlist_tag);
	}

	function submitAdd()
	{
		global $g_oSec;
		
		commonHeader();
		if (!$g_oSec->HasPerm(DCL_ENTITY_HOTLIST, DCL_PERM_ADD))
			return PrintPermissionDenied();

		$obj = CreateObject('dcl.boHotlist');
		CleanArray($_REQUEST);
		$active = @DCL_Sanitize::ToYN($_REQUEST['active']);
		$obj->add(array(
					'hotlist_tag' => $_REQUEST['hotlist_tag'],
					'active' => $active,
					'hotlist_desc' => $_REQUEST['hotlist_desc'],
					'created_by' => $GLOBALS['DCLID'],
					'created_on' => DCL_NOW
				)
			);

		$oWS = createObject('dcl.htmlHotlistBrowse');
		$oWS->show();
	}

	function submitModify()
	{
		global $g_oSec;
		
		commonHeader();
		if (($id = DCL_Sanitize::ToInt($_REQUEST['hotlist_id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if (!$g_oSec->HasPerm(DCL_ENTITY_HOTLIST, DCL_PERM_MODIFY))
			return PrintPermissionDenied();

		$obj = CreateObject('dcl.boHotlist');
		CleanArray($_REQUEST);
		$active = @DCL_Sanitize::ToYN($_REQUEST['active']);
		$obj->modify(array(
					'hotlist_id' => $id,
					'hotlist_tag' => $_REQUEST['hotlist_tag'],
					'active' => $active,
					'hotlist_desc' => $_REQUEST['hotlist_desc'],
					'closed_by' => $active == 'Y' ? null : $GLOBALS['DCLID'],
					'closed_on' => $active == 'Y' ? null : DCL_NOW
				)
			);

		$oWS = createObject('dcl.htmlHotlistBrowse');
		$oWS->show();
	}

	function submitDelete()
	{
		global $g_oSec;
		
		commonHeader();
		if (($id = DCL_Sanitize::ToInt($_REQUEST['id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if (!$g_oSec->HasPerm(DCL_ENTITY_HOTLIST, DCL_PERM_DELETE))
			return PrintPermissionDenied();

		$obj = CreateObject('dcl.boHotlist');
		$obj->delete(array('hotlist_id' => $id));

		$oWS = createObject('dcl.htmlHotlistBrowse');
		$oWS->show();
	}

	function ShowEntryForm($obj = '', $bCopy = false)
	{
		global $g_oSec;

		$isEdit = is_object($obj) && !$bCopy;
		if (!$g_oSec->HasPerm(DCL_ENTITY_HOTLIST, $isEdit ? DCL_PERM_MODIFY : DCL_PERM_ADD))
			return PrintPermissionDenied();

		$Template = CreateSmarty();

		if ($isEdit)
		{
			$Template->assign('menuAction', 'htmlHotlistForm.submitModify');
			$Template->assign('VAL_TITLE', 'Edit Hotlist');
			$Template->assign('VAL_ID', $obj->hotlist_id);
			$Template->assign('VAL_NAME', $obj->hotlist_tag);
			$Template->assign('VAL_DESCRIPTION', $obj->hotlist_desc);
			$Template->assign('VAL_ACTIVE', $obj->active);
		}
		else
		{
			$Template->assign('menuAction', 'htmlHotlistForm.submitAdd');
			$Template->assign('VAL_TITLE', 'Add New Hotlist');
			$Template->assign('VAL_ACTIVE', 'Y');
		}

		SmartyDisplay($Template, 'htmlHotlistForm.tpl');
	}
}
?>