///////////////////////////////////////////////////////////
//  Zend_Db_Statement_Pdo_Ibm.cs
//  Implementation of the Class Zend_Db_Statement_Pdo_Ibm
//  Generated by Enterprise Architect
//  Created on:      08-jun-2011 22:13:31
//  Original author: alexis
///////////////////////////////////////////////////////////




using Zend.Db.Statement;
namespace Zend.Db.Statement.Pdo {
	/// <summary>
	/// Proxy class to wrap a PDOStatement object for IBM Databases. Matches the
	/// interface of PDOStatement.  All methods simply proxy to the matching method in
	/// PDOStatement.  PDOExceptions thrown by PDOStatement are re-thrown as
	/// Zend_Db_Statement_Exception.
	///          @category   Zend
	///          @package    Zend_Db
	///          @subpackage Statement
	///          @copyright  Copyright (c) 2005-2010 Zend Technologies USA Inc. (http:
	/// //www.zend.com)
	///          @license    http://framework.zend.com/license/new-bsd     New BSD
	/// License
	/// </summary>
	public class Zend_Db_Statement_Pdo_Ibm : Zend_Db_Statement_Pdo {

		public Zend_Db_Statement_Pdo_Ibm(){

		}

		~Zend_Db_Statement_Pdo_Ibm(){

		}

		public override void Dispose(){

		}

		/// <summary>
		/// Binds a parameter to the specified variable name.
		/// </summary>
		/// <param>mixed $parameter Name the parameter, either integer or string.</param>
		/// <param>mixed $variable  Reference to PHP variable containing the value.
		/// </param>
		/// <param>mixed $type      OPTIONAL Datatype of SQL parameter.</param>
		/// <param>mixed $length    OPTIONAL Length of SQL parameter.</param>
		/// <param>mixed $options   OPTIONAL Other options.</param>
		/// <param>bool</param>
		/// <param name="parameter"></param>
		/// <param name="variable"></param>
		/// <param name="type"></param>
		/// <param name="length"></param>
		/// <param name="options"></param>
		public var _bindParam(var parameter, ref var variable, var type, var length, var options){

			return null;
		}

		/// <summary>
		/// Returns an array containing all of the result set rows.  Behaves like parent,
		/// but if limit() is used, the final result removes the extra column
		/// 'zend_db_rownum'
		/// </summary>
		/// <param>int $style OPTIONAL Fetch mode.</param>
		/// <param>int $col   OPTIONAL Column number, if fetch mode is by column.</param>
		/// <param>array Collection of rows, each in a format by the fetch mode.</param>
		/// <param name="style"></param>
		/// <param name="col"></param>
		public var fetchAll(var style, var col){

			return null;
		}

	}//end Zend_Db_Statement_Pdo_Ibm

}//end namespace Pdo