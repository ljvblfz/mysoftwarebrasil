///////////////////////////////////////////////////////////
//  Zend_Db_Select.cs
//  Implementation of the Class Zend_Db_Select
//  Generated by Enterprise Architect
//  Created on:      07-jun-2011 20:05:13
//  Original author: alexis
///////////////////////////////////////////////////////////




using Zend.Db.Adapter;
namespace Zend.Db {
	/// <summary>
	/// Class for SQL SELECT generation and results.
	///      @category   Zend
	///      @package    Zend_Db
	///      @subpackage Select
	///      @copyright  Copyright (c) 2005-2010 Zend Technologies USA Inc. (http://www.
	/// zend.com)
	///      @license    http://framework.zend.com/license/new-bsd     New BSD License
	/// </summary>
	public class Zend_Db_Select {

		/// <summary>
		/// Zend_Db_Adapter_Abstract object.
		///        @var Zend_Db_Adapter_Abstract
		/// </summary>
		protected var _adapter;
		/// <summary>
		/// Bind variables for query
		///        @var array
		/// </summary>
		protected var _bind = array();
		/// <summary>
		/// Specify legal join types.
		///        @var array
		/// </summary>
		protected static var _joinTypes = array(
		                self::INNER_JOIN,
		                self::LEFT_JOIN,
		                self::RIGHT_JOIN,
		                self::FULL_JOIN,
		                self::CROSS_JOIN,
		                self::NATURAL_JOIN,
		            );
		/// <summary>
		/// The component parts of a SELECT statement. Initialized to the $_partsInit array
		/// in the constructor.
		///        @var array
		/// </summary>
		protected var _parts = array();
		/// <summary>
		/// The initial values for the $_parts array. NOTE: It is important for the
		/// 'FOR_UPDATE' part to be last to ensure meximum compatibility with database
		/// adapters.
		///        @var array
		/// </summary>
		protected static var _partsInit = array(
		                self::DISTINCT     => false,
		                self::COLUMNS      => array(),
		                self::UNION        => array(),
		                self::FROM         => array(),
		                self::WHERE        => array(),
		                self::GROUP        => array(),
		                self::HAVING       => array(),
		                self::ORDER        => array(),
		                self::LIMIT_COUNT  => null,
		                self::LIMIT_OFFSET => null,
		                self::FOR_UPDATE   => false
		            );
		/// <summary>
		/// Tracks which columns are being select from each table and join.
		///        @var array
		/// </summary>
		protected var _tableCols = array();
		/// <summary>
		/// Specify legal union types.
		///        @var array
		/// </summary>
		protected static var _unionTypes = array(
		                self::SQL_UNION,
		                self::SQL_UNION_ALL
		            );
		private readonly var COLUMNS = 'columns';
		private readonly var CROSS_JOIN = 'cross join';
		private readonly var DISTINCT = 'distinct';
		private readonly var FOR_UPDATE = 'forupdate';
		private readonly var FROM = 'from';
		private readonly var FULL_JOIN = 'full join';
		private readonly var GROUP = 'group';
		private readonly var HAVING = 'having';
		private readonly var INNER_JOIN = 'inner join';
		private readonly var LEFT_JOIN = 'left join';
		private readonly var LIMIT_COUNT = 'limitcount';
		private readonly var LIMIT_OFFSET = 'limitoffset';
		private readonly var NATURAL_JOIN = 'natural join';
		private readonly var ORDER = 'order';
		private readonly var RIGHT_JOIN = 'right join';
		private readonly var SQL_AND = 'AND';
		private readonly var SQL_AS = 'AS';
		private readonly var SQL_ASC = 'ASC';
		private readonly var SQL_DESC = 'DESC';
		private readonly var SQL_DISTINCT = 'DISTINCT';
		private readonly var SQL_FOR_UPDATE = 'FOR UPDATE';
		private readonly var SQL_FROM = 'FROM';
		private readonly var SQL_GROUP_BY = 'GROUP BY';
		private readonly var SQL_HAVING = 'HAVING';
		private readonly var SQL_ON = 'ON';
		private readonly var SQL_OR = 'OR';
		private readonly var SQL_ORDER_BY = 'ORDER BY';
		private readonly var SQL_SELECT = 'SELECT';
		private readonly var SQL_UNION = 'UNION';
		private readonly var SQL_UNION_ALL = 'UNION ALL';
		private readonly var SQL_WHERE = 'WHERE';
		private readonly var SQL_WILDCARD = '*';
		private readonly var UNION = 'union';
		private readonly var WHERE = 'where';

		public Zend_Db_Select(){

		}

		~Zend_Db_Select(){

		}

		public virtual void Dispose(){

		}

		/// <summary>
		/// Turn magic function calls into non-magic function calls for joinUsing syntax
		/// </summary>
		/// <param>string $method</param>
		/// <param>array $args OPTIONAL Zend_Db_Table_Select query modifier</param>
		/// <param>Zend_Db_Select</param>
		/// <param name="method"></param>
		/// <param name="args"></param>
		public var __call(var method, array args){

			return null;
		}

		/// <summary>
		/// Class constructor
		/// </summary>
		/// <param>Zend_Db_Adapter_Abstract $adapter</param>
		/// <param name="adapter"></param>
		public var __construct(Zend_Db_Adapter_Abstract adapter){

			return null;
		}

		/// <summary>
		/// Implements magic method.
		/// </summary>
		/// string This object as a SELECT string.
		public var __toString(){

			return null;
		}

		/// <summary>
		/// @return array
		/// </summary>
		protected var _getDummyTable(){

			return null;
		}

		/// <summary>
		/// Return a quoted schema name
		/// </summary>
		/// <param>string   $schema  The schema name OPTIONAL</param>
		/// <param>string|null</param>
		/// <param name="schema"></param>
		protected var _getQuotedSchema(var schema){

			return null;
		}

		/// <summary>
		/// Return a quoted table name
		/// </summary>
		/// <param>string   $tableName        The table name</param>
		/// <param>string   $correlationName  The correlation name OPTIONAL</param>
		/// <param>string</param>
		/// <param name="tableName"></param>
		/// <param name="correlationName"></param>
		protected var _getQuotedTable(var tableName, var correlationName){

			return null;
		}

		/// <summary>
		/// Populate the {@link $_parts} 'join' key  Does the dirty work of populating the
		/// join key.  The $name and $cols parameters follow the same logic as described in
		/// the from() method.
		///        @param  null|string $type Type of join; inner, left, and null are
		/// currently supported
		///        @param  array|string|Zend_Db_Expr $name Table name
		///        @param  string $cond Join on this condition
		///        @param  array|string $cols The columns to select from the joined table
		///        @param  string $schema The database name to specify, if any.
		///        @return Zend_Db_Select This Zend_Db_Select object
		/// </summary>
		/// <param name="type"></param>
		/// <param name="name"></param>
		/// <param name="cond"></param>
		/// <param name="cols"></param>
		/// <param name="schema"></param>
		protected var _join(var type, var name, var cond, var cols, var schema){

			return null;
		}

		/// <summary>
		/// Handle JOIN... USING... syntax  This is functionality identical to the existing
		/// JOIN methods, however the join condition can be passed as a single column name.
		/// This method then completes the ON condition by using the same field for the
		/// FROM table and the JOIN table.
		///        <code> $select = $db->select()->from('table1') ->joinUsing('table2',
		/// 'column1');  SELECT * FROM table1 JOIN table2 ON table1.column1 = table2.
		/// column2
		///        </code>  These joins are called by the developer simply by adding
		/// 'Using' to the method name. E.g. joinUsing joinInnerUsing joinFullUsing
		/// joinRightUsing joinLeftUsing
		/// </summary>
		/// Zend_Db_Select This Zend_Db_Select object.
		/// <param name="type"></param>
		/// <param name="name"></param>
		/// <param name="cond"></param>
		/// <param name="cols"></param>
		/// <param name="schema"></param>
		public var _joinUsing(var type, var name, var cond, var cols, var schema){

			return null;
		}

		/// <summary>
		/// Render DISTINCT clause
		/// </summary>
		/// <param>string   $sql SQL query</param>
		/// <param>string|null</param>
		/// <param name="sql"></param>
		protected var _renderColumns(var sql){

			return null;
		}

		/// <summary>
		/// Render DISTINCT clause
		/// </summary>
		/// <param>string   $sql SQL query</param>
		/// <param>string</param>
		/// <param name="sql"></param>
		protected var _renderDistinct(var sql){

			return null;
		}

		/// <summary>
		/// Render FOR UPDATE clause
		/// </summary>
		/// <param>string   $sql SQL query</param>
		/// <param>string</param>
		/// <param name="sql"></param>
		protected var _renderForupdate(var sql){

			return null;
		}

		/// <summary>
		/// Render FROM clause
		/// </summary>
		/// <param>string   $sql SQL query</param>
		/// <param>string</param>
		/// <param name="sql"></param>
		protected var _renderFrom(var sql){

			return null;
		}

		/// <summary>
		/// Render GROUP clause
		/// </summary>
		/// <param>string   $sql SQL query</param>
		/// <param>string</param>
		/// <param name="sql"></param>
		protected var _renderGroup(var sql){

			return null;
		}

		/// <summary>
		/// Render HAVING clause
		/// </summary>
		/// <param>string   $sql SQL query</param>
		/// <param>string</param>
		/// <param name="sql"></param>
		protected var _renderHaving(var sql){

			return null;
		}

		/// <summary>
		/// Render LIMIT OFFSET clause
		/// </summary>
		/// <param>string   $sql SQL query</param>
		/// <param>string</param>
		/// <param name="sql"></param>
		protected var _renderLimitoffset(var sql){

			return null;
		}

		/// <summary>
		/// Render ORDER clause
		/// </summary>
		/// <param>string   $sql SQL query</param>
		/// <param>string</param>
		/// <param name="sql"></param>
		protected var _renderOrder(var sql){

			return null;
		}

		/// <summary>
		/// Render UNION query
		/// </summary>
		/// <param>string   $sql SQL query</param>
		/// <param>string</param>
		/// <param name="sql"></param>
		protected var _renderUnion(var sql){

			return null;
		}

		/// <summary>
		/// Render WHERE clause
		/// </summary>
		/// <param>string   $sql SQL query</param>
		/// <param>string</param>
		/// <param name="sql"></param>
		protected var _renderWhere(var sql){

			return null;
		}

		/// <summary>
		/// Adds to the internal table-to-column mapping array.
		/// </summary>
		/// <param>string $tbl The table/join the columns come from.</param>
		/// <param>array|string $cols The list of columns; preferably as an array, but
		/// possibly as a string containing one column.</param>
		/// <param>bool|string True if it should be prepended, a correlation name if it
		/// should be inserted</param>
		/// <param>void</param>
		/// <param name="correlationName"></param>
		/// <param name="cols"></param>
		/// <param name="afterCorrelationName"></param>
		protected var _tableCols(var correlationName, var cols, var afterCorrelationName){

			return null;
		}

		/// <summary>
		/// Generate a unique correlation name
		/// </summary>
		/// <param>string|array $name A qualified identifier.</param>
		/// <param>string A unique correlation name.</param>
		/// <param name="name"></param>
		private var _uniqueCorrelation(var name){

			return null;
		}

		/// <summary>
		/// Internal function for creating the where clause
		/// </summary>
		/// <param>string   $condition</param>
		/// <param>mixed    $value  optional</param>
		/// <param>string   $type   optional</param>
		/// <param>boolean  $bool  true = AND, false = OR</param>
		/// <param>string  clause</param>
		/// <param name="condition"></param>
		/// <param name="value"></param>
		/// <param name="type"></param>
		/// <param name="bool"></param>
		protected var _where(var condition, var value, var type, var bool){

			return null;
		}

		/// <summary>
		/// Converts this object to an SQL SELECT string.
		/// </summary>
		/// string|null This object as a SELECT string. (or null if a string cannot be
		/// produced.)
		public var assemble(){

			return null;
		}

		/// <summary>
		/// Set bind variables
		/// </summary>
		/// <param>mixed $bind</param>
		/// <param>Zend_Db_Select</param>
		/// <param name="bind"></param>
		public var bind(var bind){

			return null;
		}

		/// <summary>
		/// Specifies the columns used in the FROM clause.  The parameter can be a single
		/// string or Zend_Db_Expr object, or else an array of strings or Zend_Db_Expr
		/// objects.
		/// </summary>
		/// <param>array|string|Zend_Db_Expr $cols The columns to select from this table.
		/// </param>
		/// <param>string $correlationName Correlation name of target table.
		/// OPTIONAL</param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <param name="cols"></param>
		/// <param name="correlationName"></param>
		public var columns(var cols, var correlationName){

			return null;
		}

		/// <summary>
		/// Makes the query SELECT DISTINCT.
		/// </summary>
		/// <param>bool $flag Whether or not the SELECT is DISTINCT (default true).
		/// </param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <param name="flag"></param>
		public var distinct(var flag){

			return null;
		}

		/// <summary>
		/// Makes the query SELECT FOR UPDATE.
		/// </summary>
		/// <param>bool $flag Whether or not the SELECT is FOR UPDATE (default true).
		/// </param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <param name="flag"></param>
		public var forUpdate(var flag){

			return null;
		}

		/// <summary>
		/// Adds a FROM table and optional columns to the query.  The first parameter $name
		/// can be a simple string, in which case the correlation name is generated
		/// automatically.  If you want to specify the correlation name, the first
		/// parameter must be an associative array in which the key is the physical table
		/// name, and the value is the correlation name.  For example, array('table' =>
		/// 'alias'). The correlation name is prepended to all columns fetched for this
		/// table.  The second parameter can be a single string or Zend_Db_Expr object, or
		/// else an array of strings or Zend_Db_Expr objects.  The first parameter can be
		/// null or an empty string, in which case no correlation name is generated or
		/// prepended to the columns named in the second parameter.
		/// </summary>
		/// <param>array|string|Zend_Db_Expr $name The table name or an associative array
		/// relating table name to correlation name.</param>
		/// <param>array|string|Zend_Db_Expr $cols The columns to select from this table.
		/// </param>
		/// <param>string $schema The schema name to specify, if any.</param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <param name="name"></param>
		/// <param name="cols"></param>
		/// <param name="schema"></param>
		public var from(var name, var cols, var schema){

			return null;
		}

		/// <summary>
		/// Gets the Zend_Db_Adapter_Abstract for this particular Zend_Db_Select object.
		/// </summary>
		/// Zend_Db_Adapter_Abstract
		public var getAdapter(){

			return null;
		}

		/// <summary>
		/// Get bind variables
		/// </summary>
		/// array
		public var getBind(){

			return null;
		}

		/// <summary>
		/// Get part of the structured information for the currect query.
		/// </summary>
		/// <param>string $part</param>
		/// <param>mixed</param>
		/// <param name="part"></param>
		public var getPart(var part){

			return null;
		}

		/// <summary>
		/// Adds grouping to the query.
		/// </summary>
		/// <param>array|string $spec The column(s) to group by.</param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <param name="spec"></param>
		public var group(var spec){

			return null;
		}

		/// <summary>
		/// Adds a HAVING condition to the query by AND.  If a value is passed as the
		/// second param, it will be quoted and replaced into the condition wherever a
		/// question-mark appears. See {@link where()} for an example
		///        @param string $cond The HAVING condition.
		///        @param string|Zend_Db_Expr $val The value to quote into the condition.
		///        @return Zend_Db_Select This Zend_Db_Select object.
		/// </summary>
		/// <param name="cond"></param>
		public var having(var cond){

			return null;
		}

		/// <summary>
		/// Adds a JOIN table and columns to the query.  The $name and $cols parameters
		/// follow the same logic as described in the from() method.
		/// </summary>
		/// <param>array|string|Zend_Db_Expr $name The table name.</param>
		/// <param>string $cond Join on this condition.</param>
		/// <param>array|string $cols The columns to select from the joined table.</param>
		/// <param>string $schema The database name to specify, if any.</param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <param name="name"></param>
		/// <param name="cond"></param>
		/// <param name="cols"></param>
		/// <param name="schema"></param>
		public var join(var name, var cond, var cols, var schema){

			return null;
		}

		/// <summary>
		/// Add a CROSS JOIN table and colums to the query. A cross join is a cartesian
		/// product; there is no join condition.  The $name and $cols parameters follow the
		/// same logic as described in the from() method.
		/// </summary>
		/// <param>array|string|Zend_Db_Expr $name The table name.</param>
		/// <param>array|string $cols The columns to select from the joined table.</param>
		/// <param>string $schema The database name to specify, if any.</param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <param name="name"></param>
		/// <param name="cols"></param>
		/// <param name="schema"></param>
		public var joinCross(var name, var cols, var schema){

			return null;
		}

		/// <summary>
		/// Add a FULL OUTER JOIN table and colums to the query. A full outer join is like
		/// combining a left outer join and a right outer join.  All rows from both tables
		/// are included, paired with each other on the same row of the result set if they
		/// satisfy the join condition, and otherwise paired with NULLs in place of columns
		/// from the other table.  The $name and $cols parameters follow the same logic as
		/// described in the from() method.
		/// </summary>
		/// <param>array|string|Zend_Db_Expr $name The table name.</param>
		/// <param>string $cond Join on this condition.</param>
		/// <param>array|string $cols The columns to select from the joined table.</param>
		/// <param>string $schema The database name to specify, if any.</param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <param name="name"></param>
		/// <param name="cond"></param>
		/// <param name="cols"></param>
		/// <param name="schema"></param>
		public var joinFull(var name, var cond, var cols, var schema){

			return null;
		}

		/// <summary>
		/// Add an INNER JOIN table and colums to the query Rows in both tables are matched
		/// according to the expression in the $cond argument.  The result set is comprised
		/// of all cases where rows from the left table match rows from the right table.
		/// The $name and $cols parameters follow the same logic as described in the from()
		/// method.
		/// </summary>
		/// <param>array|string|Zend_Db_Expr $name The table name.</param>
		/// <param>string $cond Join on this condition.</param>
		/// <param>array|string $cols The columns to select from the joined table.</param>
		/// <param>string $schema The database name to specify, if any.</param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <param name="name"></param>
		/// <param name="cond"></param>
		/// <param name="cols"></param>
		/// <param name="schema"></param>
		public var joinInner(var name, var cond, var cols, var schema){

			return null;
		}

		/// <summary>
		/// Add a LEFT OUTER JOIN table and colums to the query All rows from the left
		/// operand table are included, matching rows from the right operand table included,
		/// and the columns from the right operand table are filled with NULLs if no row
		/// exists matching the left table.  The $name and $cols parameters follow the same
		/// logic as described in the from() method.
		/// </summary>
		/// <param>array|string|Zend_Db_Expr $name The table name.</param>
		/// <param>string $cond Join on this condition.</param>
		/// <param>array|string $cols The columns to select from the joined table.</param>
		/// <param>string $schema The database name to specify, if any.</param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <param name="name"></param>
		/// <param name="cond"></param>
		/// <param name="cols"></param>
		/// <param name="schema"></param>
		public var joinLeft(var name, var cond, var cols, var schema){

			return null;
		}

		/// <summary>
		/// Add a NATURAL JOIN table and colums to the query. A natural join assumes an
		/// equi-join across any column(s) that appear with the same name in both tables.
		/// Only natural inner joins are supported by this API, even though SQL permits
		/// natural outer joins as well.  The $name and $cols parameters follow the same
		/// logic as described in the from() method.
		/// </summary>
		/// <param>array|string|Zend_Db_Expr $name The table name.</param>
		/// <param>array|string $cols The columns to select from the joined table.</param>
		/// <param>string $schema The database name to specify, if any.</param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <param name="name"></param>
		/// <param name="cols"></param>
		/// <param name="schema"></param>
		public var joinNatural(var name, var cols, var schema){

			return null;
		}

		/// <summary>
		/// Add a RIGHT OUTER JOIN table and colums to the query. Right outer join is the
		/// complement of left outer join. All rows from the right operand table are
		/// included, matching rows from the left operand table included, and the columns
		/// from the left operand table are filled with NULLs if no row exists matching the
		/// right table.  The $name and $cols parameters follow the same logic as described
		/// in the from() method.
		/// </summary>
		/// <param>array|string|Zend_Db_Expr $name The table name.</param>
		/// <param>string $cond Join on this condition.</param>
		/// <param>array|string $cols The columns to select from the joined table.</param>
		/// <param>string $schema The database name to specify, if any.</param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <param name="name"></param>
		/// <param name="cond"></param>
		/// <param name="cols"></param>
		/// <param name="schema"></param>
		public var joinRight(var name, var cond, var cols, var schema){

			return null;
		}

		/// <summary>
		/// Sets a limit count and offset to the query.
		/// </summary>
		/// <param>int $count OPTIONAL The number of rows to return.</param>
		/// <param>int $offset OPTIONAL Start returning after this many rows.</param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <param name="count"></param>
		/// <param name="offset"></param>
		public var limit(var count, var offset){

			return null;
		}

		/// <summary>
		/// Sets the limit and count by page number.
		/// </summary>
		/// <param>int $page Limit results to this page number.</param>
		/// <param>int $rowCount Use this many rows per page.</param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <param name="page"></param>
		/// <param name="rowCount"></param>
		public var limitPage(var page, var rowCount){

			return null;
		}

		/// <summary>
		/// Adds a row order to the query.
		/// </summary>
		/// <param>mixed $spec The column(s) and direction to order by.</param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <param name="spec"></param>
		public var order(var spec){

			return null;
		}

		/// <summary>
		/// Adds a HAVING condition to the query by OR.  Otherwise identical to orHaving().
		/// 
		/// </summary>
		/// <param>string $cond The HAVING condition.</param>
		/// <param>mixed  $val  The value to quote into the condition.</param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <see>having()</see>
		/// <param name="cond"></param>
		public var orHaving(var cond){

			return null;
		}

		/// <summary>
		/// Adds a WHERE condition to the query by OR.  Otherwise identical to where().
		/// </summary>
		/// <param>string   $cond  The WHERE condition.</param>
		/// <param>mixed    $value OPTIONAL The value to quote into the condition.</param>
		/// <param>constant $type  OPTIONAL The type of the given value</param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <see>where()</see>
		/// <param name="cond"></param>
		/// <param name="value"></param>
		/// <param name="type"></param>
		public var orWhere(var cond, var value, var type){

			return null;
		}

		/// <summary>
		/// Executes the current select object and returns the result
		/// </summary>
		/// <param>integer $fetchMode OPTIONAL</param>
		/// <param>mixed  $bind An array of data to bind to the placeholders.</param>
		/// <param>PDO_Statement|Zend_Db_Statement</param>
		/// <param name="fetchMode"></param>
		/// <param name="bind"></param>
		public var query(var fetchMode, var bind){

			return null;
		}

		/// <summary>
		/// Clear parts of the Select object, or an individual part.
		/// </summary>
		/// <param>string $part OPTIONAL</param>
		/// <param>Zend_Db_Select</param>
		/// <param name="part"></param>
		public var reset(var part){

			return null;
		}

		/// <summary>
		/// Adds a UNION clause to the query.  The first parameter has to be an array of
		/// Zend_Db_Select or sql query strings.
		///        <code> $sql1 = $db->select(); $sql2 = "SELECT ..."; $select = $db-
		/// >select() ->union(array($sql1, $sql2)) ->order("id");
		///        </code>
		/// </summary>
		/// <param>array $select Array of select clauses for the union.</param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <param name="select"></param>
		/// <param name="type"></param>
		public var union(var select, var type){

			return null;
		}

		/// <summary>
		/// Adds a WHERE condition to the query by AND.  If a value is passed as the second
		/// param, it will be quoted and replaced into the condition wherever a question-
		/// mark appears. Array values are quoted and comma-separated.
		///        <code> simplest but non-secure $select->where("id = $id");  secure (ID
		/// is quoted but matched anyway) $select->where('id = ?', $id);  alternatively,
		/// with named binding $select->where('id = :id');
		///        </code>  Note that it is more correct to use named bindings in your
		/// queries for values other than strings. When you use named bindings, don't
		/// forget to pass the values when actually making a query:
		///        <code> $db->fetchAll($select, array('id' => 5));
		///        </code>
		/// </summary>
		/// <param>string   $cond  The WHERE condition.</param>
		/// <param>mixed    $value OPTIONAL The value to quote into the condition.</param>
		/// <param>constant $type  OPTIONAL The type of the given value</param>
		/// <param>Zend_Db_Select This Zend_Db_Select object.</param>
		/// <param name="cond"></param>
		/// <param name="value"></param>
		/// <param name="type"></param>
		public var where(var cond, var value, var type){

			return null;
		}

		public var COLUMNS{
			get{
				return COLUMNS;
			}
			set{
				COLUMNS = value;
			}
		}

		public var CROSS_JOIN{
			get{
				return CROSS_JOIN;
			}
			set{
				CROSS_JOIN = value;
			}
		}

		public var DISTINCT{
			get{
				return DISTINCT;
			}
			set{
				DISTINCT = value;
			}
		}

		public var FOR_UPDATE{
			get{
				return FOR_UPDATE;
			}
			set{
				FOR_UPDATE = value;
			}
		}

		public var FROM{
			get{
				return FROM;
			}
			set{
				FROM = value;
			}
		}

		public var FULL_JOIN{
			get{
				return FULL_JOIN;
			}
			set{
				FULL_JOIN = value;
			}
		}

		public var GROUP{
			get{
				return GROUP;
			}
			set{
				GROUP = value;
			}
		}

		public var HAVING{
			get{
				return HAVING;
			}
			set{
				HAVING = value;
			}
		}

		public var INNER_JOIN{
			get{
				return INNER_JOIN;
			}
			set{
				INNER_JOIN = value;
			}
		}

		public var LEFT_JOIN{
			get{
				return LEFT_JOIN;
			}
			set{
				LEFT_JOIN = value;
			}
		}

		public var LIMIT_COUNT{
			get{
				return LIMIT_COUNT;
			}
			set{
				LIMIT_COUNT = value;
			}
		}

		public var LIMIT_OFFSET{
			get{
				return LIMIT_OFFSET;
			}
			set{
				LIMIT_OFFSET = value;
			}
		}

		public var NATURAL_JOIN{
			get{
				return NATURAL_JOIN;
			}
			set{
				NATURAL_JOIN = value;
			}
		}

		public var ORDER{
			get{
				return ORDER;
			}
			set{
				ORDER = value;
			}
		}

		public var RIGHT_JOIN{
			get{
				return RIGHT_JOIN;
			}
			set{
				RIGHT_JOIN = value;
			}
		}

		public var SQL_AND{
			get{
				return SQL_AND;
			}
			set{
				SQL_AND = value;
			}
		}

		public var SQL_AS{
			get{
				return SQL_AS;
			}
			set{
				SQL_AS = value;
			}
		}

		public var SQL_ASC{
			get{
				return SQL_ASC;
			}
			set{
				SQL_ASC = value;
			}
		}

		public var SQL_DESC{
			get{
				return SQL_DESC;
			}
			set{
				SQL_DESC = value;
			}
		}

		public var SQL_DISTINCT{
			get{
				return SQL_DISTINCT;
			}
			set{
				SQL_DISTINCT = value;
			}
		}

		public var SQL_FOR_UPDATE{
			get{
				return SQL_FOR_UPDATE;
			}
			set{
				SQL_FOR_UPDATE = value;
			}
		}

		public var SQL_FROM{
			get{
				return SQL_FROM;
			}
			set{
				SQL_FROM = value;
			}
		}

		public var SQL_GROUP_BY{
			get{
				return SQL_GROUP_BY;
			}
			set{
				SQL_GROUP_BY = value;
			}
		}

		public var SQL_HAVING{
			get{
				return SQL_HAVING;
			}
			set{
				SQL_HAVING = value;
			}
		}

		public var SQL_ON{
			get{
				return SQL_ON;
			}
			set{
				SQL_ON = value;
			}
		}

		public var SQL_OR{
			get{
				return SQL_OR;
			}
			set{
				SQL_OR = value;
			}
		}

		public var SQL_ORDER_BY{
			get{
				return SQL_ORDER_BY;
			}
			set{
				SQL_ORDER_BY = value;
			}
		}

		public var SQL_SELECT{
			get{
				return SQL_SELECT;
			}
			set{
				SQL_SELECT = value;
			}
		}

		public var SQL_UNION{
			get{
				return SQL_UNION;
			}
			set{
				SQL_UNION = value;
			}
		}

		public var SQL_UNION_ALL{
			get{
				return SQL_UNION_ALL;
			}
			set{
				SQL_UNION_ALL = value;
			}
		}

		public var SQL_WHERE{
			get{
				return SQL_WHERE;
			}
			set{
				SQL_WHERE = value;
			}
		}

		public var SQL_WILDCARD{
			get{
				return SQL_WILDCARD;
			}
			set{
				SQL_WILDCARD = value;
			}
		}

		public var UNION{
			get{
				return UNION;
			}
			set{
				UNION = value;
			}
		}

		public var WHERE{
			get{
				return WHERE;
			}
			set{
				WHERE = value;
			}
		}

	}//end Zend_Db_Select

}//end namespace Db