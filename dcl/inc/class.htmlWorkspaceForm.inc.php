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

class htmlWorkspaceForm
{
	var $public;

	function htmlWorkspaceForm()
	{
		$this->public = array('add', 'modify', 'delete', 'submitAdd', 'submitModify', 'submitDelete');
	}

	function add()
	{
		global $g_oSec;
		
		commonHeader();
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKSPACE, DCL_PERM_ADD))
			return PrintPermissionDenied();

		$this->ShowEntryForm();
	}

	function copy()
	{
		global $g_oSec;
		
		commonHeader();
		
		if (($id = DCL_Sanitize::ToInt($_REQUEST['workspace_id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKSPACE, DCL_PERM_ADD))
			return PrintPermissionDenied();

		$obj = CreateObject('dcl.dbWorkspace');
		$obj->workspace_id = $id;
		$this->ShowEntryForm($obj, true);
	}

	function modify()
	{
		global $g_oSec;
		
		commonHeader();
		if (($id = DCL_Sanitize::ToInt($_REQUEST['workspace_id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKSPACE, DCL_PERM_MODIFY))
			return PrintPermissionDenied();

		$obj = CreateObject('dcl.dbWorkspace');
		if ($obj->Load($id) == -1)
			return;
			
		$this->ShowEntryForm($obj);
	}

	function delete()
	{
		global $g_oSec;
		
		commonHeader();
		if (($id = DCL_Sanitize::ToInt($_REQUEST['workspace_id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKSPACE, DCL_PERM_DELETE))
			return PrintPermissionDenied();

		$obj = CreateObject('dcl.dbWorkspace');
		if ($obj->Load($id) == -1)
			return;
			
		ShowDeleteYesNo('Workspace', 'htmlWorkspaceForm.submitDelete', $obj->workspace_id, $obj->workspace_name);
	}

	function submitAdd()
	{
		global $g_oSec;
		
		commonHeader();
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKSPACE, DCL_PERM_ADD))
			return PrintPermissionDenied();

		$obj = CreateObject('dcl.boWorkspace');
		CleanArray($_REQUEST);
		$aUsers = @DCL_Sanitize::ToIntArray($_REQUEST['users']);
		$aProducts = @DCL_Sanitize::ToIntArray($_REQUEST['products']);
		$obj->add(array(
					'workspace_name' => $_REQUEST['workspace_name'],
					'active' => $_REQUEST['active'],
					'users' => $aUsers != null ? $aUsers : array(),
					'products' => $aProducts != null ? $aProducts : array()
				)
			);

		$oWS = createObject('dcl.htmlWorkspaceBrowse');
		$oWS->show();
	}

	function submitModify()
	{
		global $g_oSec;
		
		commonHeader();
		if (($id = DCL_Sanitize::ToInt($_REQUEST['workspace_id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKSPACE, DCL_PERM_MODIFY))
			return PrintPermissionDenied();

		$obj = CreateObject('dcl.boWorkspace');
		CleanArray($_REQUEST);
		$aUsers = @DCL_Sanitize::ToIntArray($_REQUEST['users']);
		$aProducts = @DCL_Sanitize::ToIntArray($_REQUEST['products']);
		$obj->modify(array(
					'workspace_id' => $id,
					'workspace_name' => $_REQUEST['workspace_name'],
					'active' => $_REQUEST['active'],
					'users' => $aUsers != null ? $aUsers : array(),
					'products' => $aProducts != null ? $aProducts : array()
						)
			);

		$oWS = createObject('dcl.htmlWorkspaceBrowse');
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
		
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKSPACE, DCL_PERM_DELETE))
			return PrintPermissionDenied();

		$obj = CreateObject('dcl.boWorkspace');
		$obj->delete(array('workspace_id' => $id));

		$oWS = createObject('dcl.htmlWorkspaceBrowse');
		$oWS->show();
	}

	function changeWorkspace()
	{
		ob_start();
		global $g_oSec, $g_oSession;
		
		commonHeader();
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKSPACE, DCL_PERM_VIEW))
		{
			ob_end_flush();
			return PrintPermissionDenied();
		}
		
		if (($id = DCL_Sanitize::ToInt($_REQUEST['workspace_id'])) === null)
		{
			ob_end_flush();
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if ($id > 0)
		{
			$oWS = CreateObject('dcl.dbWorkspace');
			$aProducts = $oWS->GetProducts($id);
			
			if (count($aProducts) == 0)
			{
				$g_oSession->Unregister('workspace');
				$g_oSession->Unregister('workspace_products');
			}
			else
			{
				$sProducts = '';
				foreach ($aProducts as $row)
				{
					if ($sProducts != '')
						$sProducts .= ',';
						
					$sProducts .= $row[0];
				}
				
				$g_oSession->Register('workspace', $id);
				$g_oSession->Register('workspace_products', $sProducts);
			}
		}
		else
		{
			$g_oSession->Unregister('workspace');
			$g_oSession->Unregister('workspace_products');
		}
		
		$g_oSession->Edit();

		$menuAction = 'menuAction=htmlMyDCL.show';
		if ($g_oSec->IsPublicUser())
			$menuAction = 'menuAction=htmlPublicMyDCL.show';

		ob_end_clean();
		header("Location: main.php?$menuAction");
		exit;
	}

	function ShowEntryForm($obj = '', $bCopy = false)
	{
		global $g_oSec;

		$isEdit = is_object($obj) && !$bCopy;
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKSPACE, $isEdit ? DCL_PERM_MODIFY : DCL_PERM_ADD))
			return PrintPermissionDenied();

		$Template = CreateSmarty();

		$oWS = CreateObject('dcl.dbWorkspace');
		$aProductID = array();
		$aProductName = array();
		if ($isEdit || $bCopy)
		{
			$aList = $oWS->GetProducts($obj->workspace_id);
			foreach ($aList as $row)
			{
				$aProductID[] = $row[0];
				$aProductName[] = $row[1];
			}
		}
		
		if ($isEdit)
		{
			$Template->assign('menuAction', 'htmlWorkspaceForm.submitModify');
			$Template->assign('VAL_TITLE', 'Edit Workspace');
			$Template->assign('VAL_ID', $obj->workspace_id);
			$Template->assign('VAL_NAME', $obj->workspace_name);
			$Template->assign('VAL_ACTIVE', $obj->active);
			$Template->assign('users', $oWS->GetUsers($obj->workspace_id));
			$Template->assign('VAL_PRODUCTS', $aProductID);
			$Template->assign('VAL_PRODUCTNAMES', $aProductName);
		}
		else
		{
			$Template->assign('menuAction', 'htmlWorkspaceForm.submitAdd');
			$Template->assign('VAL_TITLE', 'Add New Workspace');
			$Template->assign('VAL_ACTIVE', 'Y');
			$Template->assign('users', $oWS->GetUsers($bCopy ? $obj->workspace_id : -1));
			$Template->assign('VAL_PRODUCTS', $aProductID);
			$Template->assign('VAL_PRODUCTNAMES', $aProductName);
		}

		SmartyDisplay($Template, 'htmlWorkspaceForm.tpl');
	}
}
?>