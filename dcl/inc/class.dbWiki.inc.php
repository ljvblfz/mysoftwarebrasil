<?php
/*
 * $Id: class.dbWiki.inc.php 45 2007-02-19 19:46:28Z mdean $
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

class dbWiki extends dclDB
{
	function dbWiki()
	{
		parent::dclDB();
		$this->TableName = 'dcl_wiki';
		LoadSchema($this->TableName);
		
		parent::Clear();
	}

	function Add()
	{
		$query  = 'INSERT INTO ' . $this->TableName . " (dcl_entity_type_id, dcl_entity_id, dcl_entity_id2, page_name, page_text, page_date, page_ip) Values (";
		$query .= $this->dcl_entity_type_id . ',';
		if ($this->dcl_entity_type_id == DCL_ENTITY_GLOBAL)
		{
			$this->dcl_entity_id = 0;
			$this->dcl_entity_id2 = 0;
		}
		else if ($this->dcl_entity_type_id != DCL_ENTITY_WORKORDER)
		{
			$this->dcl_entity_id2 = 0;
		}
		
		$this->page_date = DCL_NOW;
		
		return parent::Add();
	}

	function Edit()
	{
		if ($this->dcl_entity_type_id == DCL_ENTITY_GLOBAL)
		{
			$this->dcl_entity_id = 0;
			$this->dcl_entity_id2 = 0;
		}
		else if ($this->dcl_entity_type_id != DCL_ENTITY_WORKORDER)
		{
			$this->dcl_entity_id2 = 0;
		}
		
		$this->page_date = DCL_NOW;

		return parent::Edit();
	}

	function Delete()
	{
		$query = 'delete from ' . $this->TableName . " where page_name='";
		$query .= $this->DBAddSlashes($this->page_name);
		$query .= "' And dcl_entity_type_id = " . $this->dcl_entity_type_id;
		if ($this->dcl_entity_type_id != DCL_ENTITY_GLOBAL)
		{
			// Is specific to an entity, not global
			$query .= " And dcl_entity_id = " . $this->dcl_entity_id;

			// Work orders will have another ID
			if ($this->dcl_entity_type_id == DCL_ENTITY_WORKORDER)
				$query .= " And dcl_entity_id2 = " . $this->dcl_entity_id2;
		}

		$this->Execute($query);
	}

	function Load($iType = DCL_ENTITY_GLOBAL, $iID = 0, $iID2 = 0, $sName = 'FrontPage')
	{
		if ($iType != DCL_ENTITY_WORKORDER)
			$iID2 = 0;
			
		return parent::Load(array('dcl_entity_type_id' => $iType, 'dcl_entity_id' => $iID, 'dcl_entity_id2' => $iID2, 'page_name' => $sName));
	}

	function Exists($iType = DCL_ENTITY_GLOBAL, $iID = 0, $iID2 = 0, $sName = 'FrontPage')
	{
		if ($iType != DCL_ENTITY_WORKORDER)
			$iID2 = 0;
			
		return parent::Exists(array('dcl_entity_type_id' => $iType, 'dcl_entity_id' => $iID, 'dcl_entity_id2' => $iID2, 'page_name' => $sName));
	}

	function ListRecentChanges($iType = DCL_ENTITY_GLOBAL, $iID = 0, $iID2 = 0)
	{
		$query = sprintf('SELECT page_name, %s, page_ip FROM %s Where dcl_entity_type_id = %d',
							$this->ConvertTimestamp('page_date', 'page_date'), $this->TableName, $iType);
		if ($iType != DCL_ENTITY_GLOBAL)
		{
			$query .= " AND dcl_entity_id = $iID";
			if ($iType == DCL_ENTITY_WORKORDER)
				$query .= " AND dcl_entity_id2 = $iID2";
		}

		$query .= ' ORDER BY page_date DESC';
		return $this->Query($query);
	}
}
?>