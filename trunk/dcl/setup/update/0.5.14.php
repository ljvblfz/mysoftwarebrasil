<?php
function dcl_upgrade0_5_14()
{
	global $phpgw_setup, $setup_info;

	$phpgw_setup->oProc->Query("UPDATE dcl_config SET dcl_config_varchar='20020215' WHERE dcl_config_name='DCL_VERSION'");

	$setup_info['dcl']['currentver'] = '0.5.15';
	return $setup_info['dcl']['currentver'];
}
