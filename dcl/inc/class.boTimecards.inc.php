<?php
/*
 * $Id: class.boTimecards.inc.php 129 2009-04-19 22:49:14Z mdean $
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

class boTimecards
{
	function add()
	{
		global $g_oSec;
		
		commonHeader();
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ACTION))
			return PrintPermissionDenied();

		if (($jcn = @DCL_Sanitize::ToInt($_REQUEST['jcn'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if (($seq = @DCL_Sanitize::ToInt($_REQUEST['seq'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		$obj =& CreateObject('dcl.htmlTimeCardForm');
		$obj->Show($jcn, $seq);

		$objWO =& CreateObject('dcl.htmlWorkOrderDetail');
		$objWO->Show($jcn, $seq);
	}
	
	function closeIncompleteTasks($wo_id, $seq)
	{
		$oTasks =& CreateObject('dcl.dbWorkOrderTask');
		if ($oTasks->CloseAllIncompleteTasksForWorkOrder($wo_id, $seq))
		{
			trigger_error('Remaining incomplete tasks have been marked as closed by you.', E_USER_WARNING);
		}
	}

	function dbadd()
	{
		global $dcl_info, $g_oSec;

		commonHeader();
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ACTION))
			return PrintPermissionDenied();

		$objTimecard =& CreateObject('dcl.dbTimeCards');
		$objWorkorder =& CreateObject('dcl.dbWorkorders');
		$oStatus =& CreateObject('dcl.dbStatuses');

		$objTimecard->InitFromGlobals();
		$objTimecard->actionby = $GLOBALS['DCLID'];
		if ($g_oSec->IsPublicUser())
			$objTimecard->is_public = 'Y';
		else
			$objTimecard->is_public = @DCL_Sanitize::ToYN($_REQUEST['is_public']);

		$objTimecard->inputon = DCL_NOW;
		if ($objWorkorder->Load($objTimecard->jcn, $objTimecard->seq) == -1)
		    return;
		    
		if (($targeted_version_id = @DCL_Sanitize::ToInt($_REQUEST['targeted_version_id'])) === null)
			$targeted_version_id = 0;
		
		if (($fixed_version_id = @DCL_Sanitize::ToInt($_REQUEST['fixed_version_id'])) === null)
			$fixed_version_id = 0;
		    
		$status = $objWorkorder->status;
		$objTimecard->Add($targeted_version_id, $fixed_version_id);
		$notify = '4';
		if ($status != $objTimecard->status)
		{
			$notify .= ',3';
			if ($oStatus->GetStatusType($objTimecard->status) == 2)
			{
				$notify .= ',2';
				
				// also need to close all incomplete tasks and warn user if it happens
				$this->closeIncompleteTasks($objTimecard->jcn, $objTimecard->seq);
			}
			elseif ($oStatus->GetStatusType($objTimecard->status) == 1 && $oStatus->GetStatusType($status) != 1)
				$notify .= ',1';
		}
		
		// See if we modified some work order items
		// * Tags
		if (isset($_REQUEST['tags']) && $g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_MODIFY))
		{
			$oTag =& CreateObject('dcl.dbEntityTag');
			$oTag->serialize(DCL_ENTITY_WORKORDER, $objWorkorder->jcn, $objWorkorder->seq, $_REQUEST['tags']);
		}

		// * Hotlists
		if (isset($_REQUEST['hotlist']) && $g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_MODIFY))
		{
			$oTag =& CreateObject('dcl.dbEntityHotlist');
			$oTag->serialize(DCL_ENTITY_WORKORDER, $objWorkorder->jcn, $objWorkorder->seq, $_REQUEST['hotlist']);
		}

		// * Organizations - only if multiple are allowed to improve workflow
		if ($g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_MODIFY) && $dcl_info['DCL_WO_SECONDARY_ACCOUNTS_ENABLED'] == 'Y')
		{
			$oWOA =& CreateObject('dcl.dbWorkOrderAccount');
			if (IsSet($_REQUEST['secaccounts']))
			{
				$aAccounts = @DCL_Sanitize::ToIntArray($_REQUEST['secaccounts']);
				if ($aAccounts === null)
					$aAccounts = array();
					
				$oWOA->DeleteByWorkOrder($objWorkorder->jcn, $objWorkorder->seq, join(',', $aAccounts));
				
				// Add the new ones
				if (count($aAccounts) > 0)
				{
					$oWOA->wo_id = $objWorkorder->jcn;
					$oWOA->seq = $objWorkorder->seq;
	
					for ($i = 0; $i < count($aAccounts); $i++)
					{
						if ($aAccounts[$i] > 0)
						{
							$oWOA->account_id = $aAccounts[$i];
							$oWOA->Add();
						}
					}
				}
			}
			else
				$oWOA->DeleteByWorkOrder($objWorkorder->jcn, $objWorkorder->seq);
		}

		// * Project
		if ($g_oSec->HasPerm(DCL_ENTITY_PROJECT, DCL_PERM_ADDTASK))
		{
			if (($iProjID = @DCL_Sanitize::ToInt($_REQUEST['projectid'])) !== null && $iProjID > 0)
			{
				$oProjectMap =& CreateObject('dcl.dbProjectmap');
				if ($oProjectMap->LoadByWO($objWorkorder->jcn, $objWorkorder->seq) == -1 || $oProjectMap->projectid != $iProjID)
				{
					$oProject = CreateObject('dcl.boProjects');
					$aSource = array();
					$aSource['selected'] = array($objWorkorder->jcn . '.' . $objWorkorder->seq);
					$aSource['projectid'] = $iProjID;
					
					$oProject->batchMove($aSource);
				}
			}
		}
		
		// * File attachment
		if (($sFileName = DCL_Sanitize::ToFileName('userfile')) !== null && $g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ATTACHFILE))
		{
			$o =& CreateObject('dcl.boFile');
			$o->iType = DCL_ENTITY_WORKORDER;
			$o->iKey1 = $objWorkorder->jcn;
			$o->iKey2 = $objWorkorder->seq;
			$o->sFileName = DCL_Sanitize::ToActualFileName('userfile');
			$o->sTempFileName = $sFileName;
			$o->sRoot = $dcl_info['DCL_FILE_PATH'] . '/attachments';
			$o->Upload();
		}

		$objWtch =& CreateObject('dcl.boWatches');
		// Reload before sending since time card modifies the work order
		$objWorkorder->Load($objTimecard->jcn, $objTimecard->seq);
		$objWtch->sendNotification($objWorkorder, $notify);

		// if BuildManager is used, find info on who submitted the WO
		if ($dcl_info['DCL_BUILD_MANAGER_ENABLED'] == 'Y')
		{
//			$oBM = CreateObject('dcl.dbBuildManager');
//			$oBM->CheckDepartmentSubmit($objTimecard->jcn, $objTimecard->seq, $objWorkorder->product);
		}

		$objWO =& CreateObject('dcl.htmlWorkOrderDetail');
		$objWO->Show($objTimecard->jcn, $objTimecard->seq);
	}

	function batchadd()
	{
		global $g_oSec;
		
		commonHeader();
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ACTION))
			return PrintPermissionDenied();

		if (IsSet($_REQUEST['selected']) && is_array($_REQUEST['selected']) && count($_REQUEST['selected']) > 0)
		{
			$aSelected = array();
			foreach ($_REQUEST['selected'] as $key => $val)
			{
				list($objTimecard->jcn, $objTimecard->seq) = explode('.', $val);
				
				$objTimecard->jcn = DCL_Sanitize::ToInt($objTimecard->jcn);
				$objTimecard->seq = DCL_Sanitize::ToInt($objTimecard->seq);
				if ($objTimecard->jcn === null || $objTimecard->seq === null)
					continue;

				$aSelected[] = $val;
			}
		}

		if (count($aSelected) > 0)
		{
			$objTC =& CreateObject('dcl.htmlTimeCardForm');
			$objTC->Show(-1, -1, '', $aSelected);

			$obj =& CreateObject('dcl.htmlTimeCards');
			$_REQUEST['selected'] = $aSelected;
			$obj->ShowBatchWO();

			return;
		}
			
		if (EvaluateReturnTo())
			return;

		$objView =& CreateObject('dcl.boView');
		$objView->SetFromURL();
		
		$objH =& CreateObject('dcl.htmlWorkOrderResults');
		$objH->Render($objView);
	}

	function dbbatchadd()
	{
   		global $g_oSec;
   		
		commonHeader();
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ACTION))
		{
			PrintPermissionDenied();
			return EvaluateReturnTo();
		}

		$objTimecard =& CreateObject('dcl.dbTimeCards');
		$objTimecard->InitFromGlobals();
		$objTimecard->actionby = $GLOBALS['DCLID'];
		if ($g_oSec->IsPublicUser())
			$objTimecard->is_public = 'Y';
		else
			$objTimecard->is_public = @DCL_Sanitize::ToYN($_REQUEST['is_public']);
			
		if (($targeted_version_id = @DCL_Sanitize::ToInt($_REQUEST['targeted_version_id'])) === null)
			$targeted_version_id = 0;
		
		if (($fixed_version_id = @DCL_Sanitize::ToInt($_REQUEST['fixed_version_id'])) === null)
			$fixed_version_id = 0;
		
		$objWorkorder =& CreateObject('dcl.dbWorkorders');
		$objWtch =& CreateObject('dcl.boWatches');
		if (IsSet($_REQUEST['selected']) && is_array($_REQUEST['selected']) && count($_REQUEST['selected']) > 0)
		{
    		$bProcessTags = (isset($_REQUEST['tags']) && trim($_REQUEST['tags']) != '' && $g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_MODIFY));
        	$oTag =& CreateObject('dcl.dbEntityTag');
    		$bProcessHotlist = (isset($_REQUEST['hotlist']) && trim($_REQUEST['hotlist']) != '' && $g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_MODIFY));
        	$oHotlist =& CreateObject('dcl.dbEntityHotlist');
        	foreach ($_REQUEST['selected'] as $key => $val)
			{
				list($objTimecard->jcn, $objTimecard->seq) = explode('.', $val);
				
				$objTimecard->jcn = DCL_Sanitize::ToInt($objTimecard->jcn);
				$objTimecard->seq = DCL_Sanitize::ToInt($objTimecard->seq);
				if ($objTimecard->jcn === null || $objTimecard->seq === null)
					continue;
					
				if ($objWorkorder->Load($objTimecard->jcn, $objTimecard->seq) == -1)
				    continue;
				    
				$status = $objWorkorder->status;
				$objTimecard->Add($targeted_version_id, $fixed_version_id);
				
    			// * Tags
    			if ($bProcessTags)
        		{
        			$oTag->serialize(DCL_ENTITY_WORKORDER, $objTimecard->jcn, $objTimecard->seq, $_REQUEST['tags'], true);
        		}
				
    			// * Hotlists
    			if ($bProcessHotlist)
        		{
        			$oHotlist->serialize(DCL_ENTITY_WORKORDER, $objTimecard->jcn, $objTimecard->seq, $_REQUEST['hotlist'], true);
        		}
				
        		$notify = '4';
				if ($status != $objTimecard->status)
				{
					$notify .= ',3';
					$oStatus =& CreateObject('dcl.dbStatuses');
					if ($oStatus->GetStatusType($objTimecard->status) == 2)
					{
						$notify .= ',2';
				
						// also need to close all incomplete tasks and warn user if it happens
						$this->closeIncompleteTasks($objTimecard->jcn, $objTimecard->seq);
					}
					else if ($oStatus->GetStatusType($objTimecard->status) == 1)
						$notify .= ',1';
				}

				// Reload before sending since time card modifies the work order
				if ($objWorkorder->Load($objTimecard->jcn, $objTimecard->seq) != -1)
					$objWtch->sendNotification($objWorkorder, $notify, false);
			}
		}

		if (EvaluateReturnTo())
			return;

		$objView =& CreateObject('dcl.boView');
		$objView->SetFromURL();
		
		$objH =& CreateObject('dcl.htmlWorkOrderResults');
		$objH->Render($objView);
	}

	function modify()
	{
		global $g_oSec;
		
		commonHeader();
		if (!$g_oSec->HasPerm(DCL_ENTITY_TIMECARD, DCL_PERM_MODIFY))
			return PrintPermissionDenied();

		if (($iID = @DCL_Sanitize::ToInt($_REQUEST['id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		$objTC =& CreateObject('dcl.dbTimeCards');
		if ($objTC->Load($iID) == -1)
			return;

		$obj =& CreateObject('dcl.htmlWorkOrderDetail');
		$obj->Show($objTC->jcn, $objTC->seq, $objTC->id);
	}

	function dbmodify()
	{
		global $dcl_info, $g_oSec;

		commonHeader();
		if (!$g_oSec->HasPerm(DCL_ENTITY_TIMECARD, DCL_PERM_MODIFY))
			return PrintPermissionDenied();

		$objTC =& CreateObject('dcl.dbTimeCards');
		$objOldTC =& CreateObject('dcl.dbTimeCards');
		$objTC->InitFromGlobals();

		if ($g_oSec->IsPublicUser())
			$objTC->is_public = 'Y';
		else
			$objTC->is_public = @DCL_Sanitize::ToYN($_REQUEST['is_public']);

		if ($objOldTC->Load($objTC->id) == -1)
			return;

		if ($g_oSec->IsPublicUser() && $objOldTC->is_public == 'N')
			return PrintPermissionDenied();

		// If the hours change, we'll need to adjust the workorder
		$hoursDiff = $objTC->hours - $objOldTC->hours;

		$objWO =& CreateObject('dcl.dbWorkorders');
		if ($objWO->Load($objTC->jcn, $objTC->seq) == -1)
			return;
		
		$woChanged = false;
		$notify = '4';

		// See if any time cards were issued after this one.  If not, assume
		// that this time card was the last one entered and affected the work order
		// status when input.  In other words, adjust as needed.
		if ($objTC->status != $objOldTC->status)
		{
			$notify .= ',3';

			$objQueryTC =& CreateObject('dcl.dbTimeCards');
			if ($objQueryTC->IsLastTimeCard($objTC->id, $objTC->jcn, $objTC->seq))
			{
				// We're the last one!  This does (of course) assume that time cards
				// are entered sequentially in correct chronological order.
				if ($objTC->status != $objWO->status)
				{
					$objWO->status = $objTC->status;
					$objWO->statuson = date($dcl_info['DCL_TIMESTAMP_FORMAT']);
					$woChanged = true;
					
					$oStatus =& CreateObject('dcl.dbStatuses');
					if ($oStatus->GetStatusType($objTC->status) == 2)
					{
						$objWO->closedby = $objTC->actionby;
						$objWO->closedon = $objTC->actionon;
						$objWO->etchours = 0.0;

						$notify .= ',2';
				
						// also need to close all incomplete tasks and warn user if it happens
						$this->closeIncompleteTasks($objTC->jcn, $objTC->seq);
					}
				}
			}
			else
			{
				// Don't allow status change if more are left.  Last time card controls status of WO
				$objTC->status = $objOldTC->status;
			}
		}

		if ($hoursDiff != 0)
		{
			$objWO->totalhours += $hoursDiff;
			$woChanged = true;
		}

		if ($woChanged)
			$objTC->BeginTransaction();

		$objTC->Edit();

		if ($woChanged)
		{
			$objWO->edit();
			$objTC->EndTransaction();
		}

		$objWtch =& CreateObject('dcl.boWatches');
		$objWtch->sendNotification($objWO, $notify);

		$obj =& CreateObject('dcl.htmlWorkOrderDetail');
		$obj->Show($objTC->jcn, $objTC->seq);
	}

	function delete()
	{
		global $g_oSec;
		
		commonHeader();
		if (($iID = @DCL_Sanitize::ToInt($_REQUEST['id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if (!$g_oSec->HasPerm(DCL_ENTITY_TIMECARD, DCL_PERM_DELETE))
			return PrintPermissionDenied();

		$objTC =& CreateObject('dcl.dbTimeCards');
		if ($objTC->Load($iID) == -1)
			return;

		$obj =& CreateObject('dcl.htmlWorkOrderDetail');
		$obj->Show($objTC->jcn, $objTC->seq, $objTC->id, true);
	}

	function dbdelete()
	{
		global $dcl_info, $g_oSec;

		commonHeader();

		if (($iID = @DCL_Sanitize::ToInt($_REQUEST['id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		$objTC =& CreateObject('dcl.dbTimeCards');
		if ($objTC->Load($iID) == -1)
			return;

		if (!$g_oSec->HasPerm(DCL_ENTITY_TIMECARD, DCL_PERM_DELETE))
			return PrintPermissionDenied();

		$objWO =& CreateObject('dcl.dbWorkorders');
		if ($objWO->Load($objTC->jcn, $objTC->seq) == -1)
			return;

		// Get the next time card issued after this one.  If not, assume
		// that this time card was the last one entered and affected the work order
		// status when input.
		$objQueryTC =& CreateObject('dcl.dbTimeCards');
		if (($iNextID = $objQueryTC->GetNextTimeCardID($objTC->id, $objTC->jcn, $objTC->seq)) === null)
		{
			// OK, we're the last time card input, therefore we control status.
			// See if any time cards were input before this one.  If so,
			// try to revert to the previous time card status.  Otherwise, open it.
			if (($iPrevID = $objQueryTC->GetPrevTimeCardID($objTC->id, $objTC->jcn, $objTC->seq)) !== null)
			{
				$objQueryTC->Load($iPrevID);
				if ($objQueryTC->status != $objWO->status)
				{
					$objWO->statuson = date($dcl_info['DCL_TIMESTAMP_FORMAT']);
					$oStatus =& CreateObject('dcl.dbStatuses');
					if ($oStatus->GetStatusType($objQueryTC->status) == 2 && $oStatus->GetStatusType($objWO->status) != 2)
					{
						$objWO->closedby = $objQueryTC->actionby;
						$objWO->closedon = $objQueryTC->actionon;
						$objWO->etchours = 0.0;
				
						// also need to close all incomplete tasks and warn user if it happens
						$this->closeIncompleteTasks($objTC->jcn, $objTC->seq);
					}
					else if ($oStatus->GetStatusType($objWO->status) == 2)
					{
						$objWO->closedby = 0;
						$objWO->closedon = '';
					}

					$objWO->status = $objQueryTC->status;
				}
			}
			else
			{
				// No other time cards, so default the status
				$objWO->status = $dcl_info['DCL_DEF_STATUS_ASSIGN_WO']; // Open it
				$objWO->statuson = date($dcl_info['DCL_TIMESTAMP_FORMAT']);
				$objWO->closedby = 0;
				$objWO->closedon = '';
				$objWO->lastactionon = '';
				$objWO->etchours = $objWO->esthours;
			}
		}
		else
		{
			$objQueryTC->Load($iNextID);
			$objWO->starton = $objQueryTC->actionon;
		}

		$objWO->totalhours -= $objTC->hours;

		$objTC->BeginTransaction();
		$objTC->Delete();
		$objWO->Edit();
		$objTC->EndTransaction();

		trigger_error(sprintf(STR_BO_TIMECARDDELETED, $objTC->id, $objWO->jcn, $objWO->seq), E_USER_NOTICE);

		$obj =& CreateObject('dcl.htmlWorkOrderDetail');
		$obj->Show($objTC->jcn, $objTC->seq);
	}
}
?>
