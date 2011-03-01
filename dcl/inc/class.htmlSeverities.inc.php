<?php
/*
 * $Id: class.htmlSeverities.inc.php 12 2006-12-01 01:46:51Z mdean $
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

LoadStringResource('sev');

class htmlSeverities
{
	function GetCombo($default = 0, $cbName = 'severity', $longShort = 'name', $size = 0, $activeOnly = true, $setid = 0)
	{
		$query = "SELECT a.id,a.$longShort FROM severities a";

		if ($setid > 0)
		{
			$query .= ",attributesetsmap b WHERE a.id=b.keyid AND b.typeid=3 AND b.setid=$setid";

			if ($activeOnly)
				$query .= ' AND a.active=\'Y\'';

			$query .= ' ORDER BY b.weight';
		}
		else
		{
			if ($activeOnly)
				$query .= ' WHERE a.active=\'Y\'';

			$query .= ' ORDER BY a.name';
		}

		$oSelect = CreateObject('dcl.htmlSelect');
		$oSelect->vDefault = $default;
		$oSelect->sName = $cbName;
		$oSelect->iSize = $size;
		$oSelect->sZeroOption = STR_CMMN_SELECTONE;
		$oSelect->SetFromQuery($query);

		return $oSelect->GetHTML();
	}

	function PrintAll($orderBy = 'name')
	{
		global $dcl_info, $g_oSec;

		if (!$g_oSec->HasPerm(DCL_ENTITY_SEVERITY, DCL_PERM_VIEW))
			return PrintPermissionDenied();

		$objDBSeverity = CreateObject('dcl.dbSeverities');
		$objDBSeverity->Query("SELECT id,active,short,name,weight FROM severities ORDER BY $orderBy");
		$allRecs = $objDBSeverity->FetchAllRows();

		$oTable =& CreateObject('dcl.htmlTable');
		$oTable->setCaption(sprintf(STR_SEV_TABLETITLE, $orderBy));
		$oTable->addColumn(STR_SEV_ID, 'numeric');
		$oTable->addColumn(STR_SEV_ACTIVE, 'string');
		$oTable->addColumn(STR_SEV_SHORT, 'string');
		$oTable->addColumn(STR_SEV_NAME, 'string');
		$oTable->addColumn(STR_SEV_WEIGHT, 'numeric');

		if ($g_oSec->HasPerm(DCL_ENTITY_SEVERITY, DCL_PERM_ADD))
			$oTable->addToolbar(menuLink('', 'menuAction=boSeverities.add'), STR_CMMN_NEW);

		if ($g_oSec->HasPerm(DCL_ENTITY_ADMIN, DCL_PERM_VIEW))
			$oTable->addToolbar(menuLink('', 'menuAction=boAdmin.ShowSystemConfig'), DCL_MENU_SYSTEMSETUP);

		if (count($allRecs) > 0 && $g_oSec->HasAnyPerm(array(DCL_ENTITY_SEVERITY => array($g_oSec->PermArray(DCL_PERM_MODIFY), $g_oSec->PermArray(DCL_PERM_DELETE)))))
		{
			$oTable->addColumn(STR_CMMN_OPTIONS, 'html');
			for ($i = 0; $i < count($allRecs); $i++)
			{
				$options = '';
				if ($g_oSec->HasPerm(DCL_ENTITY_SEVERITY, DCL_PERM_MODIFY))
					$options = '<a href="' . menuLink('', 'menuAction=boSeverities.modify&id=' . $allRecs[$i][0]) . '">' . STR_CMMN_EDIT . '</a>';

				if ($g_oSec->HasPerm(DCL_ENTITY_SEVERITY, DCL_PERM_DELETE))
				{
					if ($options != '')
						$options .= '&nbsp;|&nbsp;';

					$options .= '<a href="' . menuLink('', 'menuAction=boSeverities.delete&id=' . $allRecs[$i][0]) . '">' . STR_CMMN_DELETE . '</a>';
				}

				$allRecs[$i][] = $options;
			}
		}
		
		$oTable->setData($allRecs);
		$oTable->setShowRownum(true);
		$oTable->render();
	}

	function ShowEntryForm($obj = '')
	{
		global $dcl_info, $g_oSec;

		$isEdit = is_object($obj);
		if (!$g_oSec->HasPerm(DCL_ENTITY_SEVERITY, $isEdit ? DCL_PERM_MODIFY : DCL_PERM_ADD))
			return PrintPermissionDenied();

		$t = CreateSmarty();

		if ($isEdit)
		{
			$t->assign('TXT_FUNCTION', STR_SEV_EDIT);
			$t->assign('menuAction', 'boSeverities.dbmodify');
			$t->assign('id', $obj->id);
			$t->assign('CMB_ACTIVE', GetYesNoCombo($obj->active, 'active', 0, false));
			$t->assign('VAL_SHORT', $obj->short);
			$t->assign('VAL_NAME', $obj->name);
			$t->assign('VAL_WEIGHT', $obj->weight);
		}
		else
		{
			$t->assign('TXT_FUNCTION', STR_SEV_ADD);
			$t->assign('menuAction', 'boSeverities.dbadd');
			$t->assign('CMB_ACTIVE', GetYesNoCombo('Y', 'active', 0, false));
		}

		SmartyDisplay($t, 'htmlSeveritiesForm.tpl');
	}
}
?>
