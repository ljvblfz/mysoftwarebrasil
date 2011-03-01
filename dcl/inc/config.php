<?php
/*
 * $Id: config.php.default 161 2010-05-31 01:20:18Z mdean $
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

/***********************************************************************************************
 * DO NOT EDIT THIS SECTION!!!!!!!!!!!!!!!!!!!!!  SKIP TO NEXT SECTION...                      *
 ***********************************************************************************************/
if (ini_get('register_globals') == 0)
{
	// Too many support requests - this should take care of it until CVS HEAD is ready
	// These are set *BEFORE* any work is done to avoid overwriting what we build
	if (!empty($_GET))
		extract($_GET);

	if (!empty($_POST))
		extract($_POST);

	if (!empty($_FILES))
		extract($_FILES);

	if (!empty($_COOKIE))
		extract($_COOKIE);
}

/***********************************************************************************************
 * Edit this section                                                                           *
 ***********************************************************************************************/
// Database connection info - see INSTALL for help
$dcl_domain_info = array();
$dcl_domain_info['default'] = array(
		'name' => 'Default',
		'dbType' => 'mysql',
		'dbHost' => 'localhost',
		'dbPort' => '7188',
		'dbName' => 'dcl',
		'dbUser' => 'root',
		'dbPassword' => '',
		'dbVersionMjr' => 7,
		'dbVersionMnr' => 3,
		'dbVersionRev' => 2,
		'dbVersionExt' => ''
	);

// Should match one of the indexes specified in $dcl_domain_info
$dcl_domain = 'default';

// Fully qualified path to DCL doc root
define('DCL_ROOT', 'D:/Velp/Sistemas/dcl/');

// Path to DCL from web root
define('DCL_WWW_ROOT', '/dcl/');

// Method used to redirect browser to different URL
// Valid options: meta (use meta http-equiv refresh) or php (php header function)
// Note: if cookieMethod is meta, it will override a redir of php with meta.
define('DCL_REDIR_METHOD', 'php');

// Method used to set cookies
// Valid options: meta (use meta http-equiv setcookie), php (php setcookie function), or header (php header function)
define('DCL_COOKIE_METHOD', 'php');

/***********************************************************************************************
 * Do NOT edit this section!!!  This sets up the environment for DCL.                          *
 ***********************************************************************************************/
// Force magic_quotes_runtime to be off - DO NOT CHANGE OR YOUR DATA MAY GET EXTRA \'s IN IT!
@set_magic_quotes_runtime(0);

if (function_exists('date_default_timezone_set'))
	@date_default_timezone_set(@date_default_timezone_get());

$reg = array();
if (IsSet($_REQUEST['DCLINFO']) && !IsSet($_REQUEST['UID']))
{
	if (ereg('([[:alnum:]]{32})/(.+)', $_REQUEST['DCLINFO'], $reg))
		$dcl_domain = $reg[2];
}
elseif (IsSet($_REQUEST['UID']) && IsSet($_REQUEST['DOMAIN']))
{
	$dcl_domain = $_REQUEST['DOMAIN'];
}

include_once(sprintf('%sinc/class.DCL_DB_%s.inc.php', DCL_ROOT, $dcl_domain_info[$dcl_domain]['dbType']));
include_once(sprintf('%sinc/class.DCL_Sanitize.inc.php', DCL_ROOT));
