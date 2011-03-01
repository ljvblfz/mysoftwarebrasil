<?php
/*
 * $Id: class.dbWorkOrderTask.inc.php 12 2006-12-01 01:46:51Z mdean $
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
class dbWorkOrderTask extends dclDB
{
	function dbWorkOrderTask()
	{
		parent::dclDB();
		$this->TableName = 'dcl_wo_task';
		LoadSchema($this->TableName);

		parent::Clear();
	}
	
	function DeleteByWorkOrder($wo_id, $seq)
	{
		if (($wo_id = DCL_Sanitize::ToInt($wo_id)) === null || ($seq = DCL_Sanitize::ToInt($seq)) === null)
		{
			trigger_error('Data sanitize failed.', E_USER_ERROR);
			return;
		}
		
		return $this->Execute("DELETE FROM dcl_wo_task WHERE wo_id = $wo_id AND seq = $seq");
	}
	
	function GetTasksForWorkOrder($wo_id, $seq, $bForDisplay = true)
	{
		if (($wo_id = DCL_Sanitize::ToInt($wo_id)) === null || ($seq = DCL_Sanitize::ToInt($seq)) === null)
		{
			trigger_error('Data sanitize failed.', E_USER_ERROR);
			return;
		}
		
		if ($bForDisplay)
			$sOrder = 'task_complete, task_order, wo_task_id';
		else
			$sOrder= 'task_order, wo_task_id';
			
		$this->Query('SELECT ' . $this->SelectAllColumns() . " FROM dcl_wo_task WHERE wo_id = $wo_id AND seq = $seq ORDER BY $sOrder");

		$aRetVal = $this->ResultToArray();
		for ($i = 0; $i < count($aRetVal); $i++)
		{
			$aRetVal[$i]['task_create_dt'] = $this->FormatTimeStampForDisplay($aRetVal[$i]['task_create_dt']);
			if ($aRetVal[$i]['task_complete_dt'] !== null)
				$aRetVal[$i]['task_complete_dt'] = $this->FormatTimeStampForDisplay($aRetVal[$i]['task_complete_dt']);
		}
		
		return $aRetVal;
	}
	
	function GetCountIncompleteTasksForWorkOrder($wo_id, $seq)
	{
		if (($wo_id = DCL_Sanitize::ToInt($wo_id)) === null || ($seq = DCL_Sanitize::ToInt($seq)) === null)
		{
			trigger_error('Data sanitize failed.', E_USER_ERROR);
			return;
		}
		
		return $this->ExecuteScalar("SELECT COUNT(*) FROM dcl_wo_task WHERE wo_id = $wo_id AND seq = $seq AND task_complete = 'N'");
	}
	
	function CloseAllIncompleteTasksForWorkOrder($wo_id, $seq)
	{
		global $DCLID;
		
		if (($wo_id = DCL_Sanitize::ToInt($wo_id)) === null || ($seq = DCL_Sanitize::ToInt($seq)) === null)
		{
			trigger_error('Data sanitize failed.', E_USER_ERROR);
			return;
		}
		
		if ($this->GetCountIncompleteTasksForWorkOrder($wo_id, $seq) > 0)
		{
			$this->Execute("UPDATE dcl_wo_task SET task_complete = 'Y', task_complete_by = $DCLID, task_complete_dt = " . $this->GetDateSQL() . " WHERE wo_id = $wo_id AND seq = $seq AND task_complete = 'N'");
			return true;
		}
		
		return false;
	}
}
?>