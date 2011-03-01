<?php
/*
 * $Id: class.boBuildManager.inc.php 120 2009-03-29 23:03:19Z mdean $
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

LoadStringResource('bm');

class boBuildManager
{
	function modifyReleaseInfo()
	{	
		commonHeader();
		if (($id = @DCL_Sanitize::ToInt($_REQUEST['product_version_id'])) === null)
		{
		    trigger_error('Data sanitize failed.', E_USER_ERROR);
		    return;
		}
		
		$obj = CreateObject('dcl.dbBuildManager');
		$obj->Connect();
		
		$query = "SELECT * FROM dcl_product_version where product_version_id = $id";
		$obj->Query($query);
		$allRecs = $obj->FetchAllRows();
		
		$obj = CreateObject('dcl.htmlBuildManager');
		$obj->ModifyReleasePage($allRecs);
	}
	
	
	function add()
	{	
		// Determines if the user is trying to add a RELEASE or to add a BUILD
		commonHeader();
		$obj = CreateObject('dcl.htmlBuildManager');
		SWITCH ($_REQUEST['which'])
		{
			case "release":
				$obj->ShowAddReleasePage();
				break;
			case "build":
				$obj->ShowAddBuildPage();
				break;
		}
	}
	
	function addRelease()
	{
		commonHeader();
		
		if (($product_id = @DCL_Sanitize::ToInt($_REQUEST['product_id'])) === null)
			return PrintPermissionDenied();
		
		$oDB = CreateObject('dcl.dbProductVersion');
		$oDB->InitFrom_POST();
		$oDB->active = (isset($_REQUEST['active']) && $_REQUEST['active'] == 'Y' ? 'Y' : 'N');
		$oDB->Add();
		
		$obj = CreateObject('dcl.htmlProductDetail');
		$obj->Show($product_id, 'release');
	}
	
	function modifyRelease()
	{
		commonHeader();
		if (($product_id = @DCL_Sanitize::ToInt($_REQUEST['product_id'])) === null)
			return PrintPermissionDenied();
		
		if (($product_version_id = @DCL_Sanitize::ToInt($_REQUEST['product_version_id'])) === null)
			return PrintPermissionDenied();
		
		$oDB = CreateObject('dcl.dbProductVersion');
		$oDB->InitFrom_POST();
		$oDB->active = (isset($_REQUEST['active']) && $_REQUEST['active'] == 'Y' ? 'Y' : 'N');
		$oDB->Edit();
		
		$obj = CreateObject('dcl.htmlProductDetail');
		$obj->Show($product_id, 'release');
	}
	
	function GetBuildInfoSubmit()
	{
		commonHeader();
		
		global $init;
		
		$oDB = CreateObject('dcl.dbProductBuild');
		$oDB->InitFrom_Post();
		if ($init == 0)
		{
			$oDB->objDate->time = time();
			$oDB->product_build_on = $oDB->objDate->ToDisplay();
			$oDB->Add();
		}
		else
			$oDB->Edit();

		$obj = CreateObject('dcl.htmlProductDetail');
		$obj->Show($_POST['product_id'], $_POST['which'], $_POST['product_version_id']);
	}
	
	function SubmitWO()
	{		
		global $dcl_info, $g_oSession, $product_version_id, $product;
		
		commonHeader();
			
		$obj = CreateObject('dcl.htmlBuildManager');
		if (IsSet($_REQUEST['selected']) && is_array($_REQUEST['selected']) && count($_REQUEST['selected']) > 0)
		{
			// Select a version to associate with
			$g_oSession->Register('BMselected', $_REQUEST['selected']);
			$g_oSession->Edit();
			
			$obj->AddWOForm($product);
		}
		else
		{
			if (!$g_oSession->IsRegistered('BMselected') || !is_array($g_oSession->Value('BMselected')) || count($g_oSession->Value('BMselected')) == 0)
			{
				trigger_error('Could not find selected items to add to version.', E_USER_ERROR);
				return;
			}
			
			// Add items to version
			$oVersionItem = CreateObject('dcl.dbProductVersionItem');
			$oVersionItem->product_version_id = $product_version_id;
			$oVersionItem->entity_type_id = DCL_ENTITY_WORKORDER;
			$oVersionItem->version_status_id = 1;
			$oVersionItem->version_item_submit_on = DCL_NOW;
			
			$aSelected = $g_oSession->Value('BMselected');
			foreach ($aSelected as $woidseq)
			{
				list($woid, $seq) = explode('.', $woidseq);
				
				if ($oVersionItem->Exists(array('product_version_id' => $product_version_id, 'entity_type_id' => DCL_ENTITY_WORKORDER, 'entity_id' => $woid, 'entity_id2' => $seq)))
					continue;
					
				$oVersionItem->entity_id = $woid;
				$oVersionItem->entity_id2 = $seq;
				$oVersionItem->Add();
			}

			// Pick a build
			$obj->AddWOForm($product, $product_version_id, $_REQUEST['init']);
			$obj->ShowBatchWO();
		}
	}
	
	function InsertBM()
	{
		commonHeader();
		global $g_oSession;
		
		$g_oSession->ValueRef('BMselected', $selected);
		$env = $GLOBALS['env'];
		//Writing Buildid into session
		$buildid = $GLOBALS['product_build_id'];
		$g_oSession->Register('buildid', $buildid);
		$g_oSession->Register('env', $env);
		$g_oSession->Edit();
		
		$obj = CreateObject('dcl.dbBuildManager');
		$obj->Connect();
		$obj->CheckBM($selected);		
	}
	
	function ShowWorkOrders()
	{
		global $dcl_info;
		commonHeader();
		$obj = CreateObject('dcl.htmlBuildManager');
		switch ($_REQUEST['from'])
		{
			case 'version':
			    if (($version_id = @DCL_Sanitize::ToInt($_REQUEST['product_version_id'])) === null)
			    {
			        trigger_error('Data sanitize failed.', E_USER_ERROR);
			        return;
			    }
			    
				$objView = CreateObject('dcl.boView');

				$objView->title = sprintf(STR_PROD_RELEASEINFO, 'Version');
				$objView->style = 'report';
				$objView->table = 'dcl_product_version_item';
				$objView->AddDef('columns', '', array('product_version_id','entity_id','entity_id2','workorders.summary'));
				$objView->AddDef('columnhdrs', '', array('ID', 'jcn', 'seq', 'Summary', 'Target Date', 'Actual Date'));

				$objView->AddDef('filter', 'product_version_id', $version_id);
				$objView->AddDef('order', '', array('entity_id,entity_id2'));
				
				$objHV = CreateObject('dcl.htmlBuildManagerVersionView');
				$objHV->ModNav = 'WO';
				$objHV->id = $GLOBALS['product_id'];
				break;				
			case 'build':
			    if (($version_id = @DCL_Sanitize::ToInt($_REQUEST['product_version_id'])) === null)
			    {
			        trigger_error('Data sanitize failed.', E_USER_ERROR);
			        return;
			    }
			    
			    if (($product_build_id = @DCL_Sanitize::ToInt($_REQUEST['product_build_id'])) === null)
			    {
			        trigger_error('Data sanitize failed.', E_USER_ERROR);
			        return;
			    }
			    
			    $objView = CreateObject('dcl.boView');

				$objView->title = sprintf(STR_PROD_RELEASEINFO, 'Version');
				$objView->style = 'report';
				$objView->table = 'dcl_product_build_item';
				$objView->AddDef('columns', '', array('dcl_product_build.product_version_id','product_build_id','entity_id','entity_id2','workorders.summary'));
				$objView->AddDef('columnhdrs', '', array('ID', 'Build ID', 'wo#', 'seq', 'Summary', 'Target Date', 'Actual Date'));

				$objView->AddDef('filter', 'dcl_product_build.product_version_id', $versionid);
				$objView->AddDef('filter', 'product_build_id', $product_build_id);
				$objView->AddDef('order', '', array('entity_id,entity_id2'));

				$objHV = CreateObject('dcl.htmlBuildManagerBuildView');
				$objHV->ModNav = 'WO';
				$objHV->product_version_id = $GLOBALS['versionid'];
				$objHV->productid = $GLOBALS['product_id'];
				
				break;	
			case 'default':
			 	echo "<BR><center><b>This will show the total work orders applied by Version-Build, Coming Soon.</b></center>";		
		}
		$objHV->Render($objView);
	}
	
	function ShowFiles()
	{
		global $dcl_info;
		
		commonHeader();
		if (!$GLOBALS['g_oSec']->HasPerm(DCL_ENTITY_BUILDMANAGER, DCL_PERM_VIEWFILE))
			return PrintPermissionDenied();
	
		$obj = CreateObject('dcl.htmlBuildManager');
		switch ($GLOBALS['from'])
		{
			case 'version':	
			    if (($version_id = @DCL_Sanitize::ToInt($_REQUEST['product_version_id'])) === null)
			    {
			        trigger_error('Data sanitize failed.', E_USER_ERROR);
			        return;
			    }
			    
			    if (($product_id = @DCL_Sanitize::ToInt($_REQUEST['product_id'])) === null)
			    {
			        trigger_error('Data sanitize failed.', E_USER_ERROR);
			        return;
			    }
			    
			    $objView = CreateObject('dcl.boView');

				$objView->title = sprintf(STR_PROD_RELEASEINFO, 'Version');
				$objView->style = 'report';
				$objView->table = 'dcl_product_version_item';
				$objView->AddDef('columns', '', array('product_version_id','dcl_sccs_xref.dcl_sccs_xref_id','dcl_sccs_xref.sccs_project_path','dcl_sccs_xref.sccs_file_name'));
				$objView->AddDef('columnhdrs', '', array('ID', 'Product Version ID', 'SCCS Project Path', 'File Name', 'Target Date', 'Actual Date'));

				$objView->AddDef('filter', 'product_version_id', $version_id);
				$objView->AddDef('order', '', array('dcl_sccs_xref.sccs_project_path,dcl_sccs_xref.sccs_file_name '));

				$objHV = CreateObject('dcl.htmlBuildManagerVersionView');
				$objHV->ModNav = 'showfiles';
				$objHV->id = $product_id; 
				break;			
			case 'build':
				$objView = CreateObject('dcl.boView');
				$objView->title = sprintf(STR_PROD_RELEASEINFO, 'Build');
				$objView->style = 'report';
				$objView->table = 'dcl_product_version_item';
				$objView->AddDef('columns', '', array('product_version_id','dcl_product_build_item.product_build_id','dcl_sccs_xref.dcl_sccs_xref_id','dcl_sccs_xref.sccs_project_path','dcl_sccs_xref.sccs_file_name'));
				$objView->AddDef('columnhdrs', '', array('VersionID', 'Build ID', 'SCCS ID','SCCS Project Path','File Name'));

				$objView->AddDef('filter', 'dcl_product_build_item.product_build_id', $GLOBALS['build_id']);
				$objView->AddDef('order', '', array('dcl_sccs_xref.sccs_project_path,dcl_sccs_xref.sccs_file_name '));

				$objHV = CreateObject('dcl.htmlBuildManagerBuildView');
				$objHV->ModNav = 'showfiles';
				$objHV->productid = $GLOBALS['product_id'];
				$objHV->product_version_id = $GLOBALS['product_version_id'];
				break;
			case 'default':
			 	echo "<BR><center><b>This will show the files applied for Version-Build in Source Safe, Coming Soon.</b></center>";	
				break;
		}
		$objHV->Render($objView);
	}
}
?>
