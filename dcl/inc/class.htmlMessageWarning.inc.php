<?php
/*
 * $Id: class.htmlMessageWarning.inc.php 138 2009-11-16 07:02:22Z mdean $
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

import('htmlMessage');
class htmlMessageWarning extends htmlMessage
{
	function htmlMessageWarning()
	{
		parent::htmlMessage();
		
		if (!defined('STR_CMMN_WARNING'))
			define('STR_CMMN_WARNING', 'Warning');
		
		$this->sTitle = STR_CMMN_WARNING;
		$this->sTemplate = 'htmlMessageWarning.tpl';
	}
	
	function &GetInstance()
	{
		static $oInstance;
		
		if (!isset($oInstance) || !is_object($oInstance))
		{
			$oInstance = new htmlMessageWarning();
		}
		
		return $oInstance;
	}
}
?>
