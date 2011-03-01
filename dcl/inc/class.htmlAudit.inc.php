<?php
/*
 * $Id: class.htmlAudit.inc.php 12 2006-12-01 01:46:51Z mdean $
 *
 * Double Choco Latte - Source Configuration Management System
 * Copyright (C) 1999  Michael L. Dean & Tim R. Norman
 *
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
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

class htmlAudit
{
	var $aAudit;
	var $aAuditAccount;
	var $aAuditProject;
	var $aAuditWorkOrder;
	var $oMeta;

	function htmlAudit()
	{
		$this->aAudit = array();
		$this->aAuditAccount = array();
		$this->aAuditProject = array();
		$this->oMeta =& CreateObject('dcl.DCL_MetadataDisplay');
	}

	function show()
	{
		global $dcl_info, $g_oSec;

		commonHeader();

		if (!$g_oSec->HasPerm(DCL_ENTITY_WORKORDER, DCL_PERM_REPORT))
			return PrintPermissionDenied();
			
		if (($type = DCL_Sanitize::ToInt($_REQUEST['type'])) === null ||
		    ($id = DCL_Sanitize::ToInt($_REQUEST['id'])) === null)
		{
			trigger_error('Data sanitize failed.');
			return;
		}

		$oSmarty =& CreateSmarty();
		$oAudit =& CreateObject('dcl.boAudit');

		switch ($type)
		{
			case DCL_ENTITY_WORKORDER:
			    if (($id2 = DCL_Sanitize::ToInt($_REQUEST['id2'])) === null)
			    {
					trigger_error('Data sanitize failed.');
					return;
				}
				
				$this->aAudit = $oAudit->LoadDiff('dbWorkorders', array('jcn' => $id, 'seq' => $id2));
				$oSmarty->assign('VAL_ID', sprintf('%d-%d', $id, $id2));
				$oSmarty->assign('VAL_SUMMARY', $this->oMeta->GetWorkOrder($id, $id2));
				$oSmarty->assign('LNK_BACK', menuLink('', "menuAction=boWorkorders.viewjcn&jcn=$id&seq=$id2"));

				$oAccount =& CreateObject('dcl.dbWorkOrderAccount');
				$this->aAuditAccount = $oAccount->AuditWorkOrderList($id, $id2);

				$oProject =& CreateObject('dcl.dbProjectmap');
				$this->aAuditProject = $oProject->AuditWorkOrderList($id, $id2);
				break;
			case DCL_ENTITY_PROJECT:
				$this->aAudit = $oAudit->LoadDiff('dbProjects', array('projectid' => $id));
				$oSmarty->assign('VAL_ID', $id);
				$oSmarty->assign('VAL_SUMMARY', $this->oMeta->GetProject($id));
				$oSmarty->assign('LNK_BACK', menuLink('', "menuAction=boProjects.viewproject&wostatus=0&project=$id"));

				$oProject =& CreateObject('dcl.dbProjectmap');
				$this->aAuditWorkOrder = $oProject->AuditProjectList($id);
				break;
			case DCL_ENTITY_TICKET:
				$this->aAudit = $oAudit->LoadDiff('dbTickets', array('ticketid' => $id));
				$oSmarty->assign('VAL_ID', $id);
				$oSmarty->assign('VAL_SUMMARY', $this->oMeta->GetTicket($id));
				$oSmarty->assign('LNK_BACK', menuLink('', "menuAction=boTickets.view&ticketid=$id"));
				break;
		}

		$this->prepareForDisplay();

		$oSmarty->assign_by_ref('VAL_AUDITTRAIL', $this->aAudit);
		$oSmarty->assign_by_ref('VAL_AUDITACCOUNT', $this->aAuditAccount);
		$oSmarty->assign_by_ref('VAL_AUDITPROJECT', $this->aAuditProject);
		$oSmarty->assign_by_ref('VAL_AUDITWORKORDER', $this->aAuditWorkOrder);

		SmartyDisplay($oSmarty, 'htmlAuditTrail.tpl');
	}

	function prepareForDisplay()
	{
		foreach ($this->aAudit as $iVersion => $aDiff)
		{
			$this->aAudit[$iVersion]['audit_by'] = $this->oMeta->GetPersonnel($this->aAudit[$iVersion]['audit_by']);

			for ($i = 0; $i < count($this->aAudit[$iVersion]['changes']); $i++)
			{
				$sField = $this->aAudit[$iVersion]['changes'][$i]['field'];
				if ($sField == 'contact_id')
				{
					$aContactOld = $this->oMeta->GetContact($this->aAudit[$iVersion]['changes'][$i]['old']);
					$aContactNew = $this->oMeta->GetContact($this->aAudit[$iVersion]['changes'][$i]['new']);

					$this->aAudit[$iVersion]['changes'][$i]['old'] = $aContactOld['name'];
					$this->aAudit[$iVersion]['changes'][$i]['new'] = $aContactNew['name'];
					continue;
				}

				if ($sField == 'org_id' || $sField == 'account' || $sField == 'account_id')
				{
					$aOrgOld = $this->oMeta->GetOrganization($this->aAudit[$iVersion]['changes'][$i]['old']);
					$aOrgNew = $this->oMeta->GetOrganization($this->aAudit[$iVersion]['changes'][$i]['new']);

					$this->aAudit[$iVersion]['changes'][$i]['old'] = $aOrgOld['name'];
					$this->aAudit[$iVersion]['changes'][$i]['new'] = $aOrgNew['name'];
					continue;
				}

				$sDecodeFunction = '';
				switch ($sField)
				{
					case 'audit_by':
					case 'responsible':
					case 'closedby':
						$sDecodeFunction = 'GetPersonnel';
						break;
					case 'status':
						$sDecodeFunction = 'GetStatus';
						break;
					case 'wo_type_id':
						$sDecodeFunction = 'GetWorkOrderType';
						break;
					case 'severity':
					case 'type':
						$sDecodeFunction = 'GetSeverity';
						break;
					case 'priority':
						$sDecodeFunction = 'GetPriority';
						break;
					case 'product':
						$sDecodeFunction = 'GetProduct';
						break;
					case 'module_id':
						$sDecodeFunction = 'GetModule';
						break;
					case 'project':
					case 'projectid':
					case 'parentprojectid':
						$sDecodeFunction = 'GetProject';
						break;
					case 'entity_source_id':
						$sDecodeFunction = 'GetSource';
						break;
				}

				if ($sDecodeFunction != '')
				{
					$this->aAudit[$iVersion]['changes'][$i]['old'] = $this->oMeta->$sDecodeFunction($this->aAudit[$iVersion]['changes'][$i]['old']);
					$this->aAudit[$iVersion]['changes'][$i]['new'] = $this->oMeta->$sDecodeFunction($this->aAudit[$iVersion]['changes'][$i]['new']);
				}
			}
		}
	}
}
?>
