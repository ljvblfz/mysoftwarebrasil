<?php
/*
 * $Id: class.dbAttributesets.inc.php 12 2006-12-01 01:46:51Z mdean $
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

class dbAttributesets extends dclDB
{
	function dbAttributesets()
	{
		parent::dclDB();
		$this->TableName = 'attributesets';
		$this->cacheEnabled = true;
		
		LoadSchema($this->TableName);

		$this->foreignKeys = array(
				'attributesetsmap' => 'setid',
				'products' => array('wosetid' , 'tcksetid'));
		
		parent::Clear();
	}

	function Delete()
	{
		return parent::Delete(array('id' => $this->id));
	}

	function Load($id)
	{
		return parent::Load(array('id' => $id));
	}
}
?>
