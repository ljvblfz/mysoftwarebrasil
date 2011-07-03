///////////////////////////////////////////////////////////
//  Zend_Db_Adapter_Pdo_Mysql.cs
//  Implementation of the Class Zend_Db_Adapter_Pdo_Mysql
//  Generated by Enterprise Architect
//  Created on:      08-jun-2011 22:13:15
//  Original author: alexis
///////////////////////////////////////////////////////////




using Zend.Db.Adapter.Pdo;
namespace Zend.Db.Adapter.Pdo {
	/// <summary>
	/// Class for connecting to MySQL databases and performing common operations.
	///          @category   Zend
	///          @package    Zend_Db
	///          @subpackage Adapter
	///          @copyright  Copyright (c) 2005-2010 Zend Technologies USA Inc. (http:
	/// //www.zend.com)
	///          @license    http://framework.zend.com/license/new-bsd     New BSD
	/// License
	/// </summary>
	public class Zend_Db_Adapter_Pdo_Mysql : Zend_Db_Adapter_Pdo_Abstract {

		/// <summary>
		/// Keys are UPPERCASE SQL datatypes or the constants Zend_Db::INT_TYPE, Zend_Db::
		/// BIGINT_TYPE, or Zend_Db::FLOAT_TYPE.  Values are: 0 = 32-bit integer 1 = 64-bit
		/// integer 2 = float or decimal
		///            @var array Associative array of datatypes to values 0, 1, or 2.
		/// </summary>
		protected var _numericDataTypes = array(
		                    Zend_Db::INT_TYPE    => Zend_Db::INT_TYPE,
		                    Zend_Db::BIGINT_TYPE => Zend_Db::BIGINT_TYPE,
		                    Zend_Db::FLOAT_TYPE  => Zend_Db::FLOAT_TYPE,
		                    'INT'                => Zend_Db::INT_TYPE,
		                    'INTEGER'            => Zend_Db::INT_TYPE,
		                    'MEDIUMINT'          => Zend_Db::INT_TYPE,
		                    'SMALLINT'           => Zend_Db::INT_TYPE,
		                    'TINYINT'            => Zend_Db::INT_TYPE,
		                    'BIGINT'             => Zend_Db::BIGINT_TYPE,
		                    'SERIAL'             => Zend_Db::BIGINT_TYPE,
		                    'DEC'                => Zend_Db::FLOAT_TYPE,
		                    'DECIMAL'            => Zend_Db::FLOAT_TYPE,
		                    'DOUBLE'             => Zend_Db::FLOAT_TYPE,
		                    'DOUBLE PRECISION'   => Zend_Db::FLOAT_TYPE,
		                    'FIXED'              => Zend_Db::FLOAT_TYPE,
		                    'FLOAT'              => Zend_Db::FLOAT_TYPE
		                );
		/// <summary>
		/// PDO type.
		///            @var string
		/// </summary>
		protected var _pdoType = 'mysql';

		public Zend_Db_Adapter_Pdo_Mysql(){

		}

		~Zend_Db_Adapter_Pdo_Mysql(){

		}

		public override void Dispose(){

		}

		/// <summary>
		/// Creates a PDO object and connects to the database.
		/// </summary>
		/// void
		protected var _connect(){

			return null;
		}

		/// <summary>
		/// Returns the column descriptions for a table.  The return value is an
		/// associative array keyed by the column name, as returned by the RDBMS.  The
		/// value of each array element is an associative array with the following keys:
		/// SCHEMA_NAME      => string; name of database or schema TABLE_NAME       =>
		/// string; COLUMN_NAME      => string; column name COLUMN_POSITION  => number;
		/// ordinal position of column in table DATA_TYPE        => string; SQL datatype
		/// name of column DEFAULT          => string; default expression of column, null
		/// if none NULLABLE         => boolean; true if column can have nulls LENGTH
		///    => number; length of CHAR/VARCHAR SCALE            => number; scale of
		/// NUMERIC/DECIMAL PRECISION        => number; precision of NUMERIC/DECIMAL
		/// UNSIGNED         => boolean; unsigned property of an integer type PRIMARY
		///   => boolean; true if column is part of the primary key PRIMARY_POSITION =>
		/// integer; position of column in primary key IDENTITY         => integer; true if
		/// column is auto-generated with unique values
		/// </summary>
		/// <param>string $tableName</param>
		/// <param>string $schemaName OPTIONAL</param>
		/// <param>array</param>
		/// <param name="tableName"></param>
		/// <param name="schemaName"></param>
		public var describeTable(var tableName, var schemaName){

			return null;
		}

		/// <summary>
		/// @return string
		/// </summary>
		public var getQuoteIdentifierSymbol(){

			return null;
		}

		/// <summary>
		/// Adds an adapter-specific LIMIT clause to the SELECT statement.
		/// </summary>
		/// <param>string $sql</param>
		/// <param>integer $count</param>
		/// <param>integer $offset OPTIONAL</param>
		/// <param>string</param>
		/// <param name="sql"></param>
		/// <param name="count"></param>
		/// <param name="offset"></param>
		public var limit(var sql, var count, var offset){

			return null;
		}

		/// <summary>
		/// Returns a list of the tables in the database.
		/// </summary>
		/// array
		public var listTables(){

			return null;
		}

	}//end Zend_Db_Adapter_Pdo_Mysql

}//end namespace Pdo