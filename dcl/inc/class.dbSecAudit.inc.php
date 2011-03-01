<?php
/*
 * $Id: class.dbSecAudit.inc.php 80 2007-03-23 05:12:00Z chavousc $
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

class dbSecAudit extends dclDB
{
	function dbSecAudit()
	{
		parent::dclDB();
		$this->TableName = 'dcl_sec_audit';
		$this->cacheEnabled = true;
		
		LoadSchema($this->TableName);
		
		parent::Clear();
	}

	function Add($action, $actparam = '')
	{
		$this->id=$GLOBALS['DCLID'];
		$this->actionon = DCL_NOW;
		$this->actiontxt = $action;
		$this->actionparam = $actparam;
		
		if (parent::Add() == -1)
			return -1;
	}
}
?>