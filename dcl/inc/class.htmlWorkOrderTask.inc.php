<?php
/*
 * $Id: class.htmlWorkOrderTask.inc.php 170 2010-06-05 02:42:18Z mdean $
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

LoadStringResource('wo');

class htmlWorkOrderTask
{
	var $public;

	function htmlWorkOrderTask()
	{
		$this->public = array('add', 'modify', 'delete', 'submitAdd', 'submitModify', 'submitDelete');
	}
	
	function add()
	{
		global $g_oSec;
		
		commonHeader();
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ACTION))
			return PrintPermissionDenied();

		if (($wo_id = DCL_Sanitize::ToInt($_REQUEST['jcn'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if (($seq = DCL_Sanitize::ToInt($_REQUEST['seq'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}

		$this->ShowEntryForm();
	}

	function modify()
	{
		global $g_oSec;
		
		commonHeader();
		if (($wo_task_id = DCL_Sanitize::ToInt($_REQUEST['wo_task_id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ACTION))
			return PrintPermissionDenied();

		$obj = CreateObject('dcl.dbWorkOrderTask');
		if ($obj->Load($wo_task_id) == -1)
			return;
			
		$this->ShowEntryForm($obj);
	}

	function delete()
	{
		global $g_oSec;
		
		commonHeader();
		if (($wo_task_id = DCL_Sanitize::ToInt($_REQUEST['wo_task_id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ACTION))
			return PrintPermissionDenied();

		$obj = CreateObject('dcl.dbWorkOrderTask');
		if ($obj->Load($wo_task_id) == -1)
			return;
			
		ShowDeleteYesNo('Work Order Task', 'htmlWorkOrderTask.submitDelete', $obj->wo_task_id, $obj->task_summary);
	}
	
	function reorder()
	{
		global $g_oSec;
		
		commonHeader();
		if (($wo_id = DCL_Sanitize::ToInt($_REQUEST['jcn'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if (($seq = DCL_Sanitize::ToInt($_REQUEST['seq'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ACTION))
			return PrintPermissionDenied();

		$oSmarty =& CreateSmarty();
		$oTasks =& CreateObject('dcl.dbWorkOrderTask');
		$oSmarty->assign('VAL_TASKS', $oTasks->GetTasksForWorkOrder($wo_id, $seq, false));
		$oSmarty->assign('VAL_JCN', $wo_id);
		$oSmarty->assign('VAL_SEQ', $seq);
		
		SmartyDisplay($oSmarty, 'htmlWorkOrderTaskReorder.tpl');
	}

	function submitAdd()
	{
		global $g_oSec;
		
		commonHeader();
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ACTION))
			return PrintPermissionDenied();

		CleanArray($_REQUEST);
		if (($wo_id = DCL_Sanitize::ToInt($_REQUEST['wo_id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if (($seq = DCL_Sanitize::ToInt($_REQUEST['seq'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		$obj = CreateObject('dcl.boWorkOrderTask');
		$iOrder = $obj->oDB->ExecuteScalar("SELECT MAX(task_order) FROM dcl_wo_task WHERE wo_id = $wo_id AND seq = $seq");
		if ($iOrder === null)
			$iOrder = 0;

		$aSource = array();
		$aSource['wo_id'] = $wo_id;
		$aSource['seq'] = $seq;
		foreach ($_REQUEST['task_summary'] as $iKey => $sSummary)
		{
			$sSummary = substr(trim($sSummary), 0, 255);
			if ($sSummary != '')
			{
				$aSource['task_order'] = ++$iOrder;
				$aSource['task_summary'] = $sSummary;
				$obj->add($aSource, $iKey);
			}
		}

		$objWO =& CreateObject('dcl.htmlWorkOrderDetail');
		$objWO->Show($wo_id, $seq);
	}

	function submitModify()
	{
		global $g_oSec;
		
		commonHeader();
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ACTION))
			return PrintPermissionDenied();

		if (($wo_task_id = DCL_Sanitize::ToInt($_REQUEST['wo_task_id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}

		$obj = CreateObject('dcl.boWorkOrderTask');
		CleanArray($_REQUEST);
		$obj->modify($_REQUEST);

		$objWO =& CreateObject('dcl.htmlWorkOrderDetail');
		$objWO->Show($obj->oDB->wo_id, $obj->oDB->seq);
	}
	
	function submitToggle()
	{
		global $g_oSec;
		
		commonHeader();
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ACTION))
			return PrintPermissionDenied();

		if (($wo_task_id = DCL_Sanitize::ToInt($_REQUEST['wo_task_id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		$task_complete = @DCL_Sanitize::ToYN($_REQUEST['task_complete']);

		$obj = CreateObject('dcl.boWorkOrderTask');
		$aSource = array('wo_task_id' => $wo_task_id, 'task_complete' => $task_complete);
		$obj->toggleComplete($aSource);

		$objWO =& CreateObject('dcl.htmlWorkOrderDetail');
		$objWO->Show($obj->oDB->wo_id, $obj->oDB->seq);
	}

	function submitDelete()
	{
		global $g_oSec;
		
		commonHeader();
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ACTION))
			return PrintPermissionDenied();

		CleanArray($_REQUEST);
		if (($wo_task_id = DCL_Sanitize::ToInt($_REQUEST['id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		$obj = CreateObject('dcl.boWorkOrderTask');
		if ($obj->oDB->Load($wo_task_id) != -1)
		{
			$obj->delete(array('wo_task_id' => $wo_task_id));
	
			$objWO =& CreateObject('dcl.htmlWorkOrderDetail');
			$objWO->Show($obj->oDB->wo_id, $obj->oDB->seq);
		}
	}
	
	function submitReorder()
	{
		global $g_oSec;

		// this is done as a XMLHTTP request
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ACTION))
			return PrintPermissionDenied();

		if (($wo_id = DCL_Sanitize::ToInt($_REQUEST['wo_id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}
		
		if (($seq = DCL_Sanitize::ToInt($_REQUEST['seq'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}

		$aTaskList = @DCL_Sanitize::ToIntArray($_REQUEST['task']);
		$oDB =& CreateObject('dcl.dbWorkOrderTask');
		$iOrder = 1;
		for ($i = 0; $i < count($aTaskList); $i++)
		{
			$iID = $aTaskList[$i];
			$oDB->Execute("UPDATE dcl_wo_task SET task_order = $iOrder WHERE wo_task_id = $iID AND wo_id = $wo_id AND seq = $seq");
			$iOrder++;
		}

		exit;
	}

	function ShowEntryForm($obj = '')
	{
		global $dcl_info, $g_oSec;

		$isEdit = is_object($obj);
		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_ACTION))
			return PrintPermissionDenied();
			
		$t = CreateSmarty();
		$t->assign('IS_EDIT', $isEdit);

		// Data
		if ($isEdit)
		{
			$t->assign('VAL_WO_TASK_ID', $obj->wo_task_id);
			$t->assign('URL_BACK', menuLink('', 'menuAction=boWorkorders.viewjcn&jcn=' . $obj->wo_id . '&seq=' . $obj->seq));
			$t->assign('VAL_COMPLETE', $obj->task_complete);
			$t->assign('VAL_SUMMARY', $obj->task_summary);
		}
		else
		{
			if (($wo_id = DCL_Sanitize::ToInt($_REQUEST['jcn'])) === null)
			{
				trigger_error('Data sanitize failed.');
				return;
			}
			
			if (($seq = DCL_Sanitize::ToInt($_REQUEST['seq'])) === null)
			{
				trigger_error('Data sanitize failed.');
				return;
			}

			$t->assign('URL_BACK', menuLink('', 'menuAction=boWorkorders.viewjcn&jcn=' . $wo_id . '&seq=' . $seq));
			$t->assign('VAL_WO_ID', $wo_id);
			$t->assign('VAL_SEQ', $seq);
			$t->assign('VAL_SUMMARY', '');
		}

		SmartyDisplay($t, 'htmlWorkOrderTaskForm.tpl');
	}
}
?>