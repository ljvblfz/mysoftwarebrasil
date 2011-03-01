<?php
/*
 * $Id: class.DCL_DB_pgsql.inc.php 138 2009-11-16 07:02:22Z mdean $
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

include_once(DCL_ROOT . 'inc/class.DCL_DB_Core.inc.php');

/**
 * API - All Classes Relating to DCL API
 * @package api
 * @subpackage database
 * @copyright Copyright &copy; 1999-2004 Free Software Foundation
 * @version $Id: class.DCL_DB_pgsql.inc.php 138 2009-11-16 07:02:22Z mdean $
 */
   
/**
 * Provides support for PostgreSQL SQL server
 * @package api
 * @subpackage database
 * @copyright Copyright &copy; 1999-2004 Free Software Foundation
 * @version $Id: class.DCL_DB_pgsql.inc.php 138 2009-11-16 07:02:22Z mdean $
 */
class dclDB extends DCL_DB_Core
{
	function dclDB()
	{
		parent::DCL_DB_Core();
		$this->JoinKeyword = 'JOIN';
	}

	function Connect($conn = '')
	{
		global $dcl_domain_info, $dcl_domain;

		if ($conn == '')
		{
			if (!defined('DCL_DB_CONN'))
			{
				$this->conn = @pg_connect(sprintf('dbname=%s port=%s host=%s user=%s password=%s',
							$dcl_domain_info[$dcl_domain]['dbName'],
							$dcl_domain_info[$dcl_domain]['dbPort'],
							$dcl_domain_info[$dcl_domain]['dbHost'],
							$dcl_domain_info[$dcl_domain]['dbUser'],
							$dcl_domain_info[$dcl_domain]['dbPassword']));

				define('DCL_DB_CONN', $this->conn);
			}
			else
				$this->conn = DCL_DB_CONN;
		}
		//else
			//$this->conn = $conn;

		return $this->conn;
	}

	function CanConnectServer()
	{
		global $dcl_domain_info, $dcl_domain;

		$conn = @pg_connect(sprintf('dbname=template1 port=%s host=%s user=%s password=%s',
					$dcl_domain_info[$dcl_domain]['dbPort'],
					$dcl_domain_info[$dcl_domain]['dbHost'],
					$dcl_domain_info[$dcl_domain]['dbUser'],
					$dcl_domain_info[$dcl_domain]['dbPassword']));

		$bConnect = ($conn > 0);
		pg_close($conn);

		return $bConnect;
	}

	function CanConnectDatabase()
	{
		global $dcl_domain_info, $dcl_domain;

		$conn = @pg_connect(sprintf('dbname=%s port=%s host=%s user=%s password=%s',
							$dcl_domain_info[$dcl_domain]['dbName'],
							$dcl_domain_info[$dcl_domain]['dbPort'],
							$dcl_domain_info[$dcl_domain]['dbHost'],
							$dcl_domain_info[$dcl_domain]['dbUser'],
							$dcl_domain_info[$dcl_domain]['dbPassword']));

		if ($conn > 0)
		{
			pg_close($conn);

			return true;
		}

		return false;
	}

	function CreateDatabase()
	{
		global $dcl_domain_info, $dcl_domain;

		$conn = @pg_connect(sprintf('dbname=template1 port=%s host=%s user=%s password=%s',
					$dcl_domain_info[$dcl_domain]['dbPort'],
					$dcl_domain_info[$dcl_domain]['dbHost'],
					$dcl_domain_info[$dcl_domain]['dbUser'],
					$dcl_domain_info[$dcl_domain]['dbPassword']));

		$query = sprintf('CREATE DATABASE %s', $dcl_domain_info[$dcl_domain]['dbName']);

		return (pg_exec($conn, $query) > 0);
	}

	function TableExists($sTableName)
	{
		return ($this->ExecuteScalar("select count(*) from pg_class where relname='$sTableName' and relkind='r'") > 0);
	}

	function Query($query)
	{
		$this->res = 0;
		$this->oid = 0;
		$this->cur = -1;
		$this->Record = array();

		if ($this->conn)
		{
			@$this->res = pg_Exec($this->conn, $query);
			if ($this->res)
			{
				$this->cur = 0;
				return $this->res;
			}
			else
			{
				trigger_error(pg_ErrorMessage() . " " . $query, E_USER_ERROR);
				return -1;
			}
		}
		else
			return -1;

		return 1;
	}

	function LimitQuery($query, $offset, $rows)
	{
		$this->res = 0;
		$this->oid = 0;
		$this->cur = -1;
		$this->Record = array();

		if ($this->conn)
		{
			@$this->res = pg_Exec($this->conn, $query . ' LIMIT ' . $rows . ' OFFSET ' . $offset);
			if ($this->res)
			{
				$this->cur = 0;
				return $this->res;
			}
			else
			{
				trigger_error(pg_ErrorMessage() . " " . $query, E_USER_ERROR);
				return -1;
			}
		}
		else
			return -1;
	}

	function Execute($query)
	{
		if ($this->conn)
		{
			if (!pg_Exec($this->conn, $query))
			{
				trigger_error(pg_ErrorMessage() . " " . $query, E_USER_ERROR);
				return -1;
			}
			return 1;
		}

		return -1;
	}

	// Execute row returning query and return first row, first field
	function ExecuteScalar($sql)
	{
		$retVal = null;

		$res = pg_Exec($this->conn, $sql);
		if ($res)
		{
			$Record = @pg_fetch_array($res, 0);
			$retVal = $Record[0];
			pg_freeresult($res);
		}

		return $retVal;
	}

	function Insert($query)
	{
		$this->res = 0;
		$this->oid = 0;
		$this->cur = -1;
		$this->Record = array();

		if ($this->conn)
		{
			$this->res = pg_Exec($this->conn, $query);
			if ($this->res)
				return $this->oid = pg_GetLastOid($this->res);
			else
			{
				trigger_error(pg_ErrorMessage() . " " . $query, E_USER_ERROR);
				return -1;
			}
		}
		else
		{
			trigger_error('No connection!');
			return -1;
		}
	}

	function FreeResult()
	{
		$this->Record = array();
		if ($this->res != 0)
			@pg_freeresult($this->res);

		$this->res = 0;
	}

	function BeginTransaction()
	{
		return $this->Execute('BEGIN');
	}

	function EndTransaction()
	{
		return $this->Execute('COMMIT');
	}

	function RollbackTransaction()
	{
		return $this->Execute('ROLLBACK');
	}

	function NumFields()
	{
		if ($this->res)
			return pg_NumFields($this->res);
		else
			return -1;
	}

	// from phpGW/phpLib db classes - sort of
	function next_record()
	{
		// bump up if just ran query
		if ($this->cur == -1)
			$this->cur = 0;

		$this->Record = @pg_fetch_array($this->res, $this->cur++);

		$stat = is_array($this->Record);
		if (!$stat)
			$this->FreeResult();

		return $stat;
	}

	function GetFieldName($fieldIndex)
	{
		if ($this->res)
			return pg_fieldname($this->res, $fieldIndex);

		return '';
	}

	function IsFieldNull($thisField)
	{
		if ($this->res)
		{
			if (count($this->Record) > 0)
				return $this->Record[$thisField] == NULL;

			return pg_FieldIsNULL($this->res, $this->cur, $thisField);
		}
		else
			return -1;
	}

	function FetchAllRows()
	{
		$retVal = array();
		$i = 0;
		// bump up if just ran query
		if ($this->cur == -1)
			$this->cur = 0;

		while ($a = @pg_fetch_row($this->res, $this->cur++))
			$retVal[$i++] = $a;

		return $retVal;
	}

	function GetNewIDSQLForTable($tableName)
	{
		return "nextval('seq_" . $tableName . "')";
	}

	function GetDateSQL()
	{
        // From Urmet Janes for MSSQL support
		return 'now()';
	}

	function GetRTrimSQL($text)
	{
		return "trim(trailing ' ' from $text)";
	}

	function GetUpperSQL($text)
	{
		return sprintf('upper(%s)', $text);
	}

	function GetLastInsertID($sTable)
	{
		@$res = pg_Exec($this->conn, "select currval('seq_$sTable')");
		if ($res)
		{
			$Record = @pg_fetch_array($res, 0);
			@pg_FreeResult($res);
			return $Record[0];
		}

		trigger_error("Error getting last insert ID for table $sTable! " . pg_ErrorMessage());
		return -1;
	}

	function ConvertDate($sExpression, $sField)
	{
		if ($sExpression == $sField)
			return $sField;

		return "$sExpression AS $sField";
	}

	function ConvertTimestamp($sExpression, $sField)
	{
		if ($sExpression == $sField)
			return $sField;

		return "$sExpression AS $sField";
	}

	function IsDate($vField)
	{
		return ($this->res > 0 && pg_fieldtype($this->res, $vField) == 'date');
	}

	function IsTimestamp($vField)
	{
		// substr because it could be timestamp or timestamptz
		return ($this->res > 0 && substr(pg_fieldtype($this->res, $vField), 0, 9) == 'timestamp');
	}

	function index_names()
	{
		global $dcl_domain, $dcl_domain_info;

		$this->query("SELECT relname FROM pg_class WHERE NOT relname ~ 'pg_.*' AND relkind ='i' ORDER BY relname");
		$i = 0;
		$return = array();
		while ($this->next_record())
		{
			$return[$i] = array();
			$return[$i]['index_name']		= $this->f(0);
			$return[$i]['tablespace_name']	= $dcl_domain_info[$dcl_domain]['dbName'];
			$return[$i++]['database']		= $dcl_domain_info[$dcl_domain]['dbName'];
		}

		return $return;
	}

	function FieldExists($sTable, $sField)
	{
		return ($this->ExecuteScalar("select count(*) from pg_attribute a join pg_class b on a.attrelid = b.oid where b.relname = '$sTable' and a.attname = '$sField'") == 1);
	}

	function GetMinutesElapsedSQL($sBeginDateSQL, $sEndDateSQL, $sAsField)
	{
		$sRetVal = "extract(epoch from age($sEndDateSQL, $sBeginDateSQL)) / 60";

		if ($sAsField == '')
			return $sRetVal;

		return "$sRetVal AS $sAsField";
	}

	function DBAddSlashes($thisString)
	{
		if (!IsSet($thisString) || $thisString == '')
			return '';

		return str_replace("'", "''", str_replace("\\", "\\\\", $thisString));
	}
}
?>
