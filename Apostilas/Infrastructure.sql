use LMSDotNet
declare @uniqueConstraintName char(500)
declare @contrutor char(500)
declare @primary char(500)
declare @contrutoraux char(8000)
declare @tabela char(100)
declare @tabelaAux char(100)
declare @columnName char(100)
declare @isNullable char(100)
declare @dataType char(100)
declare @characterMaximumLength char(100)
declare @constraintType char(8000)
declare @constraintType1 char(8000)
declare @type char(100)
declare @cont int
declare @arrayDropDownList char(8000)

set @arrayDropDownList = 'ACTIONID, APPOINTMENTID, APPOINTMENTRECURRENCEID, AREAID, AREAMODULEACTIONID, BLOGPOSTCATEGORYID, BLOGPOSTID, CHATSESSIONID, CHATSESSIONINSTANCEID, CHATUSERID, CITYID, COMMUNITYCATEGORYID, COMMUNITYID, COMPONENTID, DAYSOFWEEKID, EDUCATIONLEVELID, EXPRESSIONID, FORUMID, FORUMTOPICID, JOBTITLEID, MARITALSTATUSID, MEDIACATEGORYID, MEDIAID, MEMBERSHIPUSERID, MESSAGEID, MESSAGEFOLDERID, MODULEID, NEWSCATEGORYID, NEWSLETTERID, OCCUPATIONID, PERMISSIONID, PROFILEPROPERTYID, PROPERTYLISTID, PROPERTYLOGID, RECURRENCEID, SECTIONID, SOCIALNETWORKID, STATEID, SURVEYID, SURVEYITEMID, TASKDISPATCHERID, THEMEID, TYPELOGID, UNITID, USERID, USERTYPEMESSAGEID, WIKICATEGORYID, WIKICONTENTID, WIKIID, WIKIVERSIONID, ZONEID'

set @cont = 0
set @contrutor = ''
set @contrutoraux = ''
set @primary = ''

set @tabela = replace('MentoringPlanActivity.cs.cs.cs.cs.cs.cs.cs.cs.cs','.cs','')
set @tabelaAux = REPLACE(@tabela,'_','')
-- CODE --
print'//'
print'//  Copyright (c) 2011, WebAula S/A '
print'//  All rights reserved.'
print'//'
print'//  Authors:' 
print'//           '    
print'//           * Phillipe Duarte Gori (pdgori@100loop.com)'
print'//           Blog: http://www.100loop.com/ '        
print'//           Messenger: pdgori@hotmail.com '
print'//'
print''
print'using System.Collections.Generic;'
print'using System.Linq;'
print'using System.Text;'
print'using System.Runtime.Serialization;'
print'using System.ComponentModel.DataAnnotations;'
print'using Infrastructure;'
print'using System;'
print''
print'namespace Infrastructure.Training'
print'{'
print'    [DataContract]'
print'    public class '+ @tabelaAux
print'    {'
print '        #region properties'
----------

DECLARE db_cursor CURSOR FOR  
select 
	C.COLUMN_NAME 
	,C.IS_NULLABLE
	,		case C.DATA_TYPE
			when 'int' 
			then 				
				case IS_NULLABLE
					when 'YES'
					then 'int?'
					else
						'int'
				end	
			when 'smallint' 
			then  				
				case IS_NULLABLE
					when 'YES'
					then 'int?'
					else
						'int'
				end	
			when 'tinyint' 
			then  				
				case IS_NULLABLE
					when 'YES'
					then 'int?'
					else
						'int'
				end	
			when 'numeric' 
			then  				
				case IS_NULLABLE
					when 'YES'
					then 'int?'
					else
						'int'
				end	
			when 'varchar' 
			then 'string'
			when 'char' 
			then 'string'
			when 'binary'
			then 'string'
			when 'bit' 
			then 'bool'
			when 'decimal' 
			then 
				case IS_NULLABLE
					when 'YES'
					then 'float?'
					else
						'float'
				end	
			when 'datetime' 
			then 
				case IS_NULLABLE
					when 'YES'
					then 'DateTime?'
					else
						'DateTime'
				end
			else
				'tipoNaoDefinido'				
		End  AS DATA_TYPE
	,C.CHARACTER_MAXIMUM_LENGTH
	,case TC.CONSTRAINT_TYPE
		when 'PRIMARY KEY' 
			then '[ScaffoldColumn(false)]'
		else 
			case
				when IS_NULLABLE = 'YES' AND CHARACTER_MAXIMUM_LENGTH is not null
				then '[StringLength('+rtrim(ltrim(Convert(char(4),CHARACTER_MAXIMUM_LENGTH,102)))+', ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "'+ltrim(rtrim(@tabelaAux))+ltrim(rtrim(C.COLUMN_NAME))+'StringLength")]'
				when IS_NULLABLE = 'NO' AND CHARACTER_MAXIMUM_LENGTH is null
				then '[Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "'+ltrim(rtrim(@tabelaAux))+
					case when substring(ltrim(rtrim(C.COLUMN_NAME)),len(ltrim(rtrim(C.COLUMN_NAME)))-1, len(ltrim(rtrim(C.COLUMN_NAME)))) = 'ID'
					then	
						substring(ltrim(rtrim(C.COLUMN_NAME)),0,len(ltrim(rtrim(C.COLUMN_NAME))))+'dRequired")]'
					else
						ltrim(rtrim(C.COLUMN_NAME))+'Required")]'
					end
				when IS_NULLABLE = 'NO' AND CHARACTER_MAXIMUM_LENGTH is not null
				then '[StringLength('+rtrim(ltrim(Convert(char(4),CHARACTER_MAXIMUM_LENGTH,102)))+', ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "'+ltrim(rtrim(@tabelaAux))+ltrim(rtrim(C.COLUMN_NAME))+'StringLength")]'+ char(13) + 
					 '		[Required(ErrorMessageResourceType = typeof(Globalizator), ErrorMessageResourceName = "'+ltrim(rtrim(@tabelaAux))+ltrim(rtrim(C.COLUMN_NAME))+'Required")]'
			end
	 end as CONSTRAINT_TYPE1
	 ,TC.CONSTRAINT_TYPE
	 ,RC.UNIQUE_CONSTRAINT_NAME
from INFORMATION_SCHEMA.COLUMNS C
left join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE CC on CC.TABLE_NAME = C.TABLE_NAME AND CC.COLUMN_NAME = C.COLUMN_NAME
left join INFORMATION_SCHEMA.TABLE_CONSTRAINTS TC on TC.CONSTRAINT_NAME = CC.CONSTRAINT_NAME
left join INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS RC on RC.CONSTRAINT_NAME = CC.CONSTRAINT_NAME

where C.TABLE_NAME = @tabela

OPEN db_cursor   
FETCH NEXT FROM db_cursor INTO @columnName,@isNullable,@dataType,@characterMaximumLength,@constraintType1,@constraintType,@uniqueConstraintName

WHILE @@FETCH_STATUS = 0   
BEGIN
	  
	PRINT ''
	PRINT rtrim(ltrim('		'+@constraintType1))
	PRINT '		[DataMember(Order = '+rtrim(ltrim(convert(char(4),@cont)))+')]'
	IF charIndex(upper(ltrim(rtrim(@columnName+','))), @arrayDropDownList) > 0 and charIndex(upper(ltrim(rtrim(@tabelaAux))),@arrayDropDownList) = 0 
	PRINT '		[UIHint("'+substring(@columnName,0,len(@columnName)-1)+'DropDown")]'
	IF ltrim(rtrim(upper(@columnName))) = 'CREATEDBY' or ltrim(rtrim(upper(@columnName))) = 'CREATEDON'
	print '		[ScaffoldColumn(false)]'
	IF substring(@columnName,len(@columnName)-1, len(@columnName)) = 'ID'
					PRINT '		public '+rtrim(ltrim(@dataType))+ ' ' + substring(@columnName,0,len(@columnName))+'d { get; set; }'
	ELSE
					PRINT '		public '+rtrim(ltrim(@dataType))+' '+rtrim(ltrim(@columnName))+' { get; set; }'
	IF @constraintType = 'FOREIGN KEY'
	BEGIN
	set @cont = @cont + 1
	PRINT ''
	PRINT '		[DataMember(Order = '+rtrim(ltrim(convert(char(4),@cont)))+')]'
		IF substring(@columnName,len(@columnName)-1, len(@columnName)) = 'ID'
			IF substring(@columnName,len(@columnName)-1, len(@columnName)) <> 'ID'
				IF @uniqueConstraintName = 'PK_User' and lower(ltrim(rtrim(@columnName))) != 'userid'
				PRINT ' public User '+ rtrim(ltrim(@columnName)) + 'User { get; set; }'
				ELSE
				PRINT '	public '+substring(@columnName,0,len(@columnName)-1)+' '+ rtrim(ltrim(@columnName)) + ' { get; set; }'
				ELSE
				IF substring(@columnName,len(@columnName)-1, len(@columnName)) = 'ID' and @uniqueConstraintName = 'PK_User' 
				PRINT '		public User '+ltrim(rtrim(substring(@columnName,0,len(@columnName))))+'dUser { get; set; }'
				ELSE
				IF charindex('PARENT',UPPER(@columnName)) > 0
			PRINT '		public '+rtrim(ltrim(@tabelaAux))+' '+substring(@columnName,0,len(@columnName)-1)+' { get; set; }'
			ELSE
			PRINT '		public '+substring(@columnName,0,len(@columnName)-1)+' '+substring(@columnName,0,len(@columnName)-1)+' { get; set; }'
		ELSE
			IF substring(@columnName,len(@columnName)-1, len(@columnName)) <> 'ID'
					IF @uniqueConstraintName = 'PK_User' and lower(ltrim(rtrim(@columnName))) != 'userid'
					PRINT '		public User '+ rtrim(ltrim(@columnName)) + 'User { get; set; }'
					ELSE
					PRINT '		public '+substring(@columnName,0,len(@columnName)-1)+' '+ rtrim(ltrim(@columnName)) + ' { get; set; }'
					ELSE
				PRINT '		public '+substring(@columnName,0,len(@columnName)-1)+' '+substring(@columnName,0,len(@columnName)-1)+' { get; set; }'
	END
	set @cont = @cont + 1
	FETCH NEXT FROM db_cursor INTO @columnName,@isNullable,@dataType,@characterMaximumLength,@constraintType1,@constraintType,@uniqueConstraintName
END   

CLOSE db_cursor   
DEALLOCATE db_cursor 

----------
print ''   
print '        #endregion'
print ''
print '        #region constructors'
print ''
print'		public '+rtrim(ltrim(@tabelaAux))+'()'
print'		{'
print'		}'
print'		'
print'		public '+rtrim(ltrim(@tabelaAux))+'(dynamic entity)'
print'		{'
DECLARE db_cursor2 CURSOR FOR  
select 
	C.COLUMN_NAME
	,C.IS_NULLABLE
	,C.DATA_TYPE
	,C.CHARACTER_MAXIMUM_LENGTH
	,TC.CONSTRAINT_TYPE 
	,RC.UNIQUE_CONSTRAINT_NAME
from INFORMATION_SCHEMA.COLUMNS C
left join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE CC on CC.TABLE_NAME = C.TABLE_NAME AND CC.COLUMN_NAME = C.COLUMN_NAME
left join INFORMATION_SCHEMA.TABLE_CONSTRAINTS TC on TC.CONSTRAINT_NAME = CC.CONSTRAINT_NAME
left join INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS RC on RC.CONSTRAINT_NAME = CC.CONSTRAINT_NAME
where C.TABLE_NAME = @tabela

OPEN db_cursor2   
FETCH NEXT FROM db_cursor2 INTO  @columnName,@isNullable,@dataType,@characterMaximumLength,@constraintType,@uniqueConstraintName

WHILE @@FETCH_STATUS = 0   
BEGIN
	IF @constraintType = 'FOREIGN KEY'  
	BEGIN
	IF substring(@columnName,len(@columnName)-1, len(@columnName)) = 'ID' 
		PRINT '		this.'+substring(@columnName,0,len(@columnName))+'d = entity.'+substring(@columnName,0,len(@columnName))+'d;'
	ELSE
		
		PRINT '		this.'+rtrim(ltrim(@columnName))+' = entity.'+@columnName + ';'
		IF @uniqueConstraintName = 'PK_User' and lower(ltrim(rtrim(@columnName))) != 'userid'
		BEGIN
		IF substring(@columnName,len(@columnName)-1, len(@columnName)) = 'ID' and @uniqueConstraintName = 'PK_User' 
		BEGIN
			PRINT '		if (entity.'+ltrim(rtrim(substring(@columnName,0,len(@columnName))))+'dUser != null)'
			PRINT '			this.'+ltrim(rtrim(substring(@columnName,0,len(@columnName))))+'dUser = new User(entity.'+ltrim(rtrim(substring(@columnName,0,len(@columnName))))+'dUser);'
		END
		ELSE
		BEGIN
			PRINT '		if (entity.'+ltrim(rtrim(@columnName))+'User != null)'
			PRINT '			this.'+ltrim(rtrim(@columnName))+'User = new User(entity.' + ltrim(rtrim(@columnName)) + 'User);'
		END
		END
		ELSE
		BEGIN
		IF charindex('PARENT',UPPER(@columnName)) > 0
		BEGIN
		PRINT '		if (entity.'+substring(@columnName,0,len(@columnName)-1)+' != null)'
		PRINT '			this.'+substring(@columnName,0,len(@columnName)-1)+' = new '+rtrim(ltrim(@tabelaAux))+'(entity.'+substring(@columnName,0,len(@columnName)-1)+');'
		END 
		ELSE
		BEGIN
		PRINT '		if (entity.'+substring(@columnName,0,len(@columnName)-1)+' != null)'
		PRINT '			this.'+substring(@columnName,0,len(@columnName)-1)+' = new '+substring(@columnName,0,len(@columnName)-1)+'(entity.'+substring(@columnName,0,len(@columnName)-1)+');'
		END
		END
	END
	ELSE IF @constraintType = 'PRIMARY KEY'
	BEGIN
		PRINT '		this.'+substring(@columnName,0,len(@columnName))+'d = entity.'+substring(@columnName,0,len(@columnName))+'d;'
	END
	ELSE
	IF substring(@columnName,len(@columnName)-1, len(@columnName)) = 'ID' 
		PRINT '		this.'+substring(@columnName,0,len(@columnName))+'d = entity.'+substring(@columnName,0,len(@columnName))+'d;'
	ELSE
		PRINT '		this.'+ltrim(rtrim(@columnName))+' = entity.'+ltrim(rtrim(@columnName))+';'
	FETCH NEXT FROM db_cursor2 INTO  @columnName,@isNullable,@dataType,@characterMaximumLength,@constraintType,@uniqueConstraintName
END   

CLOSE db_cursor2   
DEALLOCATE db_cursor2 
print'		}'
print'	'
print '		#endregion'
print '	}'
print '}'