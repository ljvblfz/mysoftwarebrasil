<?php
/*
 * $Id: class.dbSession.inc.php 120 2009-03-29 23:03:19Z mdean $
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

//LoadStringResource('db');
class dbSession extends dclDB
{
	var $m_IsValidSession;

	function dbSession()
	{
		parent::dclDB();
		$this->TableName = 'dcl_session';
		LoadSchema($this->TableName);

		$this->session_data = array();
		$this->m_IsValidSession = false;

		parent::Clear();
	}

	function Add()
	{
		global $dcl_info;

		srand((double)microtime() * 1000000);
		$this->dcl_session_id = md5(uniqid(rand()));
		$this->create_date = DCL_NOW;
		$this->update_date = DCL_NOW;
		$this->session_data = serialize($this->session_data);

		if (parent::Add() == -1)
		{
			trigger_error('Could not start session!', E_USER_ERROR);
			exit;
		}

		$this->session_data = unserialize($this->session_data);
		$this->m_IsValidSession = true;
	}

	function Edit()
	{
		$this->update_date = DCL_NOW;
		$aSessionDataCopy = $this->session_data;
		$this->session_data = serialize($this->session_data);
		parent::Edit(array('create_date'));
		$this->session_data = $aSessionDataCopy;
	}

	function Delete()
	{
		parent::Delete(array('dcl_session_id' => $this->dcl_session_id));
	}

	function Load($id)
	{
		global $dcl_info, $dcl_domain, $dcl_domain_info;

		$this->Clear();

		$sql = 'SELECT dcl_session_id, personnel_id, ';
		$sql .= $this->ConvertTimestamp('create_date', 'create_date');
		$sql .= ', ' . $this->ConvertTimestamp('update_date', 'update_date');
		$sql .= ', session_data, ';
		$sql .= $this->GetMinutesElapsedSQL('update_date', $this->GetDateSQL(), 'minutes_elapsed');
		$sql .= ' FROM dcl_session WHERE dcl_session_id=' . $this->Quote($id);

		if ($this->Query($sql) == -1 || !$this->next_record())
		{
			return -1;
		}

		$retVal = ($this->GetRow() != -1);
		$iMinutesElapsed = $this->f('minutes_elapsed');

		$this->session_data = unserialize($this->session_data);

		$this->GlobalValue('DCLID');
		$this->GlobalValue('DCLNAME');
		$this->GlobalValue('USEREMAIL');
		$this->GlobalValue('LANG');
		$this->GlobalValue('DCLUI');
		$this->GlobalValue('dcl_info');
		$this->GlobalValue('dcl_preferences');

		$this->create_date = $this->FormatTimeStampForDisplay($this->f('create_date'));
		$this->FreeResult();

		// Did session expire?
		if ($iMinutesElapsed > $dcl_info['DCL_SESSION_TIMEOUT'])
			return -2;

		// Check for config refresh
		global $dcl_info;
		$o = CreateObject('dcl.dbConfig');
		if (!isset($dcl_info) || !is_array($dcl_info) || !isset($dcl_info['LAST_CONFIG_UPDATE']) || $o->Value('LAST_CONFIG_UPDATE') != $dcl_info['LAST_CONFIG_UPDATE'])
		{
			$o->Load();
			$this->Register('dcl_info', $dcl_info);
			$this->Edit();
		}

		$query = 'UPDATE dcl_session SET ';
		$query .= 'update_date = ' . $this->GetDateSQL();
		$query .= ' WHERE dcl_session_id=\'' . $this->dcl_session_id . '\'';

		srand((double)microtime() * 1000000);
		$pct = rand(1, 100);
		if ($pct <= 20)
		{
			// 20% chance to call session purge - called after this session has updated timestamp
			// Purging on every request is too much traffic and unnecessary since this is really
			// doing housekeeping
			$this->Purge();
		}

		$this->m_IsValidSession = $retVal && ($this->Execute($query) != -1);

		return $this->m_IsValidSession;
	}

	function Register($sName, $sValue)
	{
		$this->session_data[$sName] = $sValue;
	}

	function Unregister($sName)
	{
		if (isset($this->session_data[$sName]))
			unset($this->session_data[$sName]);
	}

	function IsRegistered($sName)
	{
		return isset($this->session_data[$sName]);
	}

	function Value($sName)
	{
		if (isset($this->session_data[$sName]))
			return $this->session_data[$sName];

		return null;
	}
	
	function ValueRef($sName, &$oRetVal)
	{
		if (isset($this->session_data[$sName]))
		{
			$oRetVal = $this->session_data[$sName];
			return;
		}

		return null;
	}

	function GlobalValue($sName)
	{
		$GLOBALS[$sName] = $this->Value($sName);
	}

	function Purge()
	{
		global $dcl_info;

		$query = sprintf('DELETE FROM dcl_session WHERE (%s) > %s',
						$this->GetMinutesElapsedSQL('update_date', $this->GetDateSQL(), ''),
						$dcl_info['DCL_SESSION_TIMEOUT']);

		return $this->Execute($query);
	}

	function IsValidSession()
	{
		return $this->m_IsValidSession;
	}
	
	function IsInWorkspace()
	{
		return $this->IsRegistered('workspace_products');
	}
	
	function GetProductFilter()
	{
		global $g_oSec;
		
		$aProducts = array();
		if ($g_oSec->IsOrgUser())
			$aProducts = split(',', $this->Value('org_products'));
		
		if ($this->IsInWorkspace())
		{
			if (count($aProducts) > 0)
				$aProducts = array_intersect($aProducts, split(',', $this->Value('workspace_products')));
			else
				$aProducts = split(',', $this->Value('workspace_products'));
		}
		
		return $aProducts;
	}

	function Clear()
	{
		parent::Clear();
		$this->session_data = array();
	}
}
?>
