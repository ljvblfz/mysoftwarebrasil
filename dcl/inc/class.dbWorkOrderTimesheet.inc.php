<?php
/*
 * $Id: class.dbWorkOrderAccount.inc.php 46 2007-02-19 19:58:12Z mdean $
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
class dbWorkOrderTimesheet extends dclDB
{
	function dbWorkOrderTimesheet()
	{
		parent::dclDB();
		$this->TableName = 'dcl_wo_timesheet';
		LoadSchema($this->TableName);
		parent::Clear();
	}

	function Add()
	{
		if (!$this->Exists(array('personnel_id' => $this->personnel_id, 'wo_id' => $this->wo_id, 'seq' => $this->seq)))
		{
			$sValues = $this->personnel_id;
			$sValues .= $this->wo_id . ', ';
			$sValues .= $this->seq . ', ';

			$query  = 'INSERT INTO dcl_wo_account (personnel_id, wo_id, seq) Values (' . $sValues . ')';
			if ($this->Insert($query) == -1)
			{
				trigger_error(sprintf('Error updating timesheet for work order.  %s', $query), E_USER_ERROR);
			}
		}
	}

	function Edit()
	{
		// nothing to do here - the whole thing is the key!
	}

	function Delete($personnel_id, $wo_id, $seq)
	{
		parent::Delete(array('personnel_id' => $personnel_id, 'wo_id' => $wo_id, 'seq' => $seq));
	}
}
?>