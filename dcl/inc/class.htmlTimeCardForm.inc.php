<?php
/*
 * $Id: class.htmlTimeCardForm.inc.php 165 2010-06-01 00:05:40Z mdean $
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

LoadStringResource('tc');

class htmlTimeCardForm
{
	function Show($jcn, $seq, $obj = '', $selected = '')
	{
		echo $this->GetForm($jcn, $seq, $obj, $selected);
	}

	function GetForm($jcn, $seq, $obj = '', $selected = '')
	{
		global $dcl_info, $g_oSec, $dcl_preferences;

		$isBatch = is_array($selected) && count($selected) > 0;
		$isEdit = is_object($obj) && !$isBatch; // Don't allow batch updates for now...

		if ($isEdit && !$g_oSec->HasPerm(DCL_ENTITY_TIMECARD, DCL_PERM_MODIFY))
			return PrintPermissionDenied();
		else if (!$isEdit && !$g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ACTION))
			return PrintPermissionDenied();

		$objStatuses =& CreateObject('dcl.htmlStatuses');
		$objActions =& CreateObject('dcl.htmlActions');
		$objPersonnel =& CreateObject('dcl.htmlPersonnel');

		$oSmarty =& CreateSmarty();

		$oSmarty->assign('IS_BATCH', $isBatch);
		$oSmarty->assign('IS_EDIT', $isEdit);
		$oSmarty->assign('VAL_JSDATEFORMAT', GetJSDateFormat());

		$setid = 0;
		if ($isBatch)
		{
			$oView =& CreateObject('dcl.boView');
			$oView->SetFromURL();
			$oSmarty->assign('VAL_VIEWFORM', $oView->GetForm());

			$oSmarty->assign('VAL_SELECTED', $selected);
			$oSmarty->assign('CMB_STATUS', $objStatuses->GetCombo(1, 'status', 'name', 0, true, $setid));
			$oSmarty->assign('VAL_WOETCHOURS', '0');
			$oSmarty->assign('VAL_UPDATEWOETCHOURS', 'false');
			$oSmarty->assign('VAL_ENABLEPUBLIC', 'N');
		}
		else
		{
			$oWO = CreateObject('dcl.dbWorkorders');
			$oWO->Load($jcn, $seq);

			$oProduct = CreateObject('dcl.dbProducts');
			$oProduct->Load($oWO->product);
			$setid = $oProduct->wosetid;

			$oSmarty->assign('VAL_PRODUCT', $oWO->product);
			$oSmarty->assign('VAL_WOETCHOURS', $oWO->etchours);
			$oSmarty->assign('VAL_UPDATEWOETCHOURS', 'true');
			$oSmarty->assign('CMB_STATUS', $objStatuses->GetCombo($oWO->status, 'status', 'name', 0, true, $setid));
			$oSmarty->assign('VAL_ISPUBLIC', $oWO->is_public);
			$oSmarty->assign('VAL_ENABLEPUBLIC', $oWO->is_public);
			$oSmarty->assign('VAL_ISVERSIONED', $oProduct->is_versioned == 'Y');
		}

		if ($isEdit)
		{
			$oSmarty->assign('VAL_ID', $obj->id);
			$oSmarty->assign('VAL_ACTIONON', $obj->actionon);
			$oSmarty->assign('VAL_HOURS', $obj->hours);
			$oSmarty->assign('VAL_SUMMARY', $obj->summary);
			$oSmarty->assign('VAL_DESCRIPTION', $obj->description);
			$oSmarty->assign('VAL_ISPUBLIC', $obj->is_public);
			$oSmarty->assign('CMB_STATUS', $objStatuses->GetCombo($obj->status, 'status', 'name', 0, false, $setid));
			$oSmarty->assign('CMB_ACTION', $objActions->GetCombo($obj->action, 'action', 'name', 0, false, $setid));
		}
		else
		{
			$oSmarty->assign('VAL_ACTIONON', date($dcl_info['DCL_DATE_FORMAT']));
			$oSmarty->assign('CMB_ACTION', $objActions->GetCombo(0, 'action', 'name', 0, true, $setid));

			if ($g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ASSIGN))
			{
				$oSmarty->assign('CMB_REASSIGN', $objPersonnel->GetCombo(0, 'reassign_to_id', 'lastfirst', 0, true, DCL_ENTITY_WORKORDER));
			}
		}

		$oSmarty->assign('VAL_JCN', $jcn);
		$oSmarty->assign('VAL_SEQ', $seq);
		$oSmarty->assign('VAL_NOTIFYDEFAULT', isset($dcl_preferences['DCL_PREF_NOTIFY_DEFAULT']) ? $dcl_preferences['DCL_PREF_NOTIFY_DEFAULT'] : 'N');
		
		$oSmarty->assign('PERM_REASSIGN', $g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ASSIGN));
		$oSmarty->assign('PERM_ADDTASK', $g_oSec->HasPerm(DCL_ENTITY_PROJECT, DCL_PERM_ADDTASK, IsSet($_REQUEST['projectid']) ? (int)$_REQUEST['projectid'] : 0));
		$oSmarty->assign('PERM_ATTACHFILE', $g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ATTACHFILE) && $dcl_info['DCL_MAX_UPLOAD_FILE_SIZE'] > 0);
		$oSmarty->assign('VAL_MAXUPLOADFILESIZE', $dcl_info['DCL_MAX_UPLOAD_FILE_SIZE']);
		$oSmarty->assign('VAL_MULTIORG', $dcl_info['DCL_WO_SECONDARY_ACCOUNTS_ENABLED'] == 'Y');
		$oSmarty->assign('PERM_MODIFYWORKORDER', $g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_MODIFY));
		$oSmarty->assign('PERM_ISPUBLIC', $g_oSec->IsPublicUser());
		
		if (!$isEdit && !$isBatch)
		{
			$aOrgID = array();
			$aOrgName = array();
			$objPM = CreateObject('dcl.dbProjectmap');
			if ($objPM->LoadByWO($jcn, $seq) != -1)
			{
				$objDBPrj = CreateObject('dcl.dbProjects');
	
				if ($objPM->projectid > 0)
					$objDBPrj->Load($objPM->projectid);
	
				$oSmarty->assign('VAL_PROJECT', $objDBPrj->name);
				$oSmarty->assign('VAL_PROJECTS', $objPM->projectid);
			}

			$oOrgs =& CreateObject('dcl.boOrg');
			$oOrgs->ListSelectedByWorkOrder($jcn, $seq);
			while ($oOrgs->oDB->next_record())
			{
				$aOrgID[] = $oOrgs->oDB->f(0);
				$aOrgName[] = $oOrgs->oDB->f(1);
			}
			
			$oTag =& CreateObject('dcl.dbEntityTag');
			$oSmarty->assign('VAL_TAGS', $oTag->getTagsForEntity(DCL_ENTITY_WORKORDER, $jcn, $seq));

			$oHotlist =& CreateObject('dcl.dbEntityHotlist');
			$oSmarty->assign('VAL_HOTLISTS', $oHotlist->getTagsForEntity(DCL_ENTITY_WORKORDER, $jcn, $seq));

			$oSmarty->assign_by_ref('VAL_ORGID', $aOrgID);
			$oSmarty->assign_by_ref('VAL_ORGNAME', $aOrgName);
		}
		
		if (isset($_REQUEST['return_to']))
			$oSmarty->assign('VAL_RETURNTO', $_REQUEST['return_to']);

		if (isset($_REQUEST['project']))
			$oSmarty->assign('VAL_PROJECT', $_REQUEST['project']);

		return SmartyFetch($oSmarty, 'htmlTimeCardForm.tpl');
	}
}
?>
