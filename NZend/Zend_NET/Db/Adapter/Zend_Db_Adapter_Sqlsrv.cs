///////////////////////////////////////////////////////////
//  Zend_Db_Adapter_Sqlsrv.cs
//  Implementation of the Class Zend_Db_Adapter_Sqlsrv
//  Generated by Enterprise Architect
//  Created on:      08-jun-2011 22:13:25
//  Original author: alexis
///////////////////////////////////////////////////////////




using Zend.Db.Adapter;
namespace Zend.Db.Adapter {
	/// <summary>
	/// @category   Zend
	///        @package    Zend_Db
	///        @subpackage Adapter
	///        @copyright  Copyright (c) 2005-2010 Zend Technologies USA Inc. (http:
	/// //www.zend.com)
	///        @license    http://framework.zend.com/license/new-bsd     New BSD
	/// License
	/// </summary>
	public class Zend_Db_Adapter_Sqlsrv : Zend_Db_Adapter_Abstract {

		/// <summary>
		/// User-provided configuration.  Basic keys are:  username => (string) Connect to
		/// the database as this username. password => (string) Password associated with
		/// the username. dbname   => The name of the local SQL Server instance
		///          @var array
		/// </summary>
		protected var _config = array(
		                  'dbname'       => null,
		                  'username'     => null,
		                  'password'     => null,
		              );
		/// <summary>
		/// Default class name for a DB statement.
		///          @var string
		/// </summary>
		protected var _defaultStmtClass = 'Zend_Db_Statement_Sqlsrv';
		/// <summary>
		/// Last insert id from INSERT query
		///          @var int
		/// </summary>
		protected var _lastInsertId;
		/// <summary>
		/// Query used to fetch last insert id
		///          @var string
		/// </summary>
		protected var _lastInsertSQL = 'SELECT SCOPE_IDENTITY() as Current_Identity';
		/// <summary>
		/// Keys are UPPERCASE SQL datatypes or the constants Zend_Db::INT_TYPE, Zend_Db::
		/// BIGINT_TYPE, or Zend_Db::FLOAT_TYPE.  Values are: 0 = 32-bit integer 1 = 64-bit
		/// integer 2 = float or decimal
		///          @var array Associative array of datatypes to values 0, 1, or 2.
		/// </summary>
		protected var _numericDataTypes = array(
		                  Zend_Db::INT_TYPE    => Zend_Db::INT_TYPE,
		                  Zend_Db::BIGINT_TYPE => Zend_Db::BIGINT_TYPE,
		                  Zend_Db::FLOAT_TYPE  => Zend_Db::FLOAT_TYPE,
		                  'INT'                => Zend_Db::INT_TYPE,
		                  'SMALLINT'           => Zend_Db::INT_TYPE,
		                  'TINYINT'            => Zend_Db::INT_TYPE,
		                  'BIGINT'             => Zend_Db::BIGINT_TYPE,
		                  'DECIMAL'            => Zend_Db::FLOAT_TYPE,
		                  'FLOAT'              => Zend_Db::FLOAT_TYPE,
		                  'MONEY'              => Zend_Db::FLOAT_TYPE,
		                  'NUMERIC'            => Zend_Db::FLOAT_TYPE,
		                  'REAL'               => Zend_Db::FLOAT_TYPE,
		                  'SMALLMONEY'         => Zend_Db::FLOAT_TYPE,
		              );

		public Zend_Db_Adapter_Sqlsrv(){

		}

		~Zend_Db_Adapter_Sqlsrv(){

		}

		public override void Dispose(){

		}

		/// <summary>
		/// Leave autocommit mode and begin a transaction.
		/// </summary>
		/// void
		protected var _beginTransaction(){

			return null;
		}

		/// <summary>
		/// Check for config options that are mandatory. Throw exceptions if any are
		/// missing.
		/// </summary>
		/// <param>array $config</param>
		/// <param name="config"></param>
		protected var _checkRequiredOptions(array config){

			return null;
		}

		/// <summary>
		/// Commit a transaction and return to autocommit mode.
		/// </summary>
		/// void
		protected var _commit(){

			return null;
		}

		/// <summary>
		/// Creates a connection resource.
		/// </summary>
		/// void
		protected var _connect(){

			return null;
		}

		/// <summary>
		/// Quote a raw string.
		/// </summary>
		/// <param>string $value     Raw string</param>
		/// <param>string           Quoted string</param>
		/// <param name="value"></param>
		protected var _quote(var value){

			return null;
		}

		/// <summary>
		/// Roll back a transaction and return to autocommit mode.
		/// </summary>
		/// void
		protected var _rollBack(){

			return null;
		}

		/// <summary>
		/// Force the connection to close.
		/// </summary>
		/// void
		public var closeConnection(){

			return null;
		}

		/// <summary>
		/// Returns the column descriptions for a table.  The return value is an
		/// associative array keyed by the column name, as returned by the RDBMS.  The
		/// value of each array element is an associative array with the following keys:
		/// SCHEMA_NAME      => string; name of schema TABLE_NAME       => string;
		/// COLUMN_NAME      => string; column name COLUMN_POSITION  => number; ordinal
		/// position of column in table DATA_TYPE        => string; SQL datatype name of
		/// column DEFAULT          => string; default expression of column, null if none
		/// NULLABLE         => boolean; true if column can have nulls LENGTH           =>
		/// number; length of CHAR/VARCHAR SCALE            => number; scale of
		/// NUMERIC/DECIMAL PRECISION        => number; precision of NUMERIC/DECIMAL
		/// UNSIGNED         => boolean; unsigned property of an integer type PRIMARY
		///   => boolean; true if column is part of the primary key PRIMARY_POSITION =>
		/// integer; position of column in primary key IDENTITY         => integer; true if
		/// column is auto-generated with unique values
		///          @todo Discover integer unsigned property.
		///          @param string $tableName
		///          @param string $schemaName OPTIONAL
		///          @return array
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="schemaName"></param>
		public var describeTable(var tableName, var schemaName){

			return null;
		}

		/// <summary>
		/// Retrieve server version in PHP style
		/// </summary>
		/// string
		public var getServerVersion(){

			return null;
		}

		/// <summary>
		/// Inserts a table row with specified data.
		/// </summary>
		/// <param>mixed $table The table to insert data into.</param>
		/// <param>array $bind Column-value pairs.</param>
		/// <param>int The number of affected rows.</param>
		/// <param name="table"></param>
		/// <param name="bind"></param>
		public var insert(var table, array bind){

			return null;
		}

		/// <summary>
		/// Test if a connection is active
		/// </summary>
		/// boolean
		public var isConnected(){

			return null;
		}

		/// <summary>
		/// Gets the last ID generated automatically by an IDENTITY/AUTOINCREMENT column.
		/// As a convention, on RDBMS brands that support sequences (e.g. Oracle,
		/// PostgreSQL, DB2), this method forms the name of a sequence from the arguments
		/// and returns the last id generated by that sequence. On RDBMS brands that
		/// support IDENTITY/AUTOINCREMENT columns, this method returns the last value
		/// generated for such a column, and the table name argument is disregarded.
		/// </summary>
		/// <param>string $tableName   OPTIONAL Name of table.</param>
		/// <param>string $primaryKey  OPTIONAL Name of primary key column.</param>
		/// <param>string</param>
		/// <param name="tableName"></param>
		/// <param name="primaryKey"></param>
		public var lastInsertId(var tableName, var primaryKey){

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

		/// <summary>
		/// Returns an SQL statement for preparation.
		/// </summary>
		/// <param>string $sql The SQL statement with placeholders.</param>
		/// <param>Zend_Db_Statement_Sqlsrv</param>
		/// <param name="sql"></param>
		public var prepare(var sql){

			return null;
		}

		/// <summary>
		/// Set the fetch mode.
		///          @todo Support FETCH_CLASS and FETCH_INTO.
		///          @param integer $mode A fetch mode.
		///          @return void
		/// </summary>
		/// <param name="mode"></param>
		public var setFetchMode(var mode){

			return null;
		}

		/// <summary>
		/// Set the transaction isoltion level.
		/// </summary>
		/// <param>integer|null $level A fetch mode from SQLSRV_TXN_*.</param>
		/// <param>true</param>
		/// <param name="level"></param>
		public var setTransactionIsolationLevel(var level){

			return null;
		}

		/// <summary>
		/// Check if the adapter supports real SQL parameters.
		/// </summary>
		/// <param>string $type 'positional' or 'named'</param>
		/// <param>bool</param>
		/// <param name="type"></param>
		public var supportsParameters(var type){

			return null;
		}

	}//end Zend_Db_Adapter_Sqlsrv

}//end namespace Adapter