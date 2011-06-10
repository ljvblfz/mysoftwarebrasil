    
-- =============================================
-- Author:		<Alexis Moura>
-- Create date: <30/12/2010>
-- Description:	<Paginação> 
-- =============================================

	declare @page int
    declare @pageIni int
    declare @pageFim int
    declare @maxPage int
    set @maxPage = 10
    set @page = 1
    set @pageIni = (@page*@maxPage)-@maxPage+1
    set @pageFim = @page*@maxPage

    SELECT * FROM (
		SELECT 
			M.MessageID
			,M.Subject
			,M.Body
			,M.IsAlert
			,M.IsReminder
			,M.IsDraft
			,M.SearchArgs
			,M.Attach
			,M.MessageParentID
			,M.MessageFolderID
			,M.SentOn
			,M.CreatedBy
			,M.CreatedOn
			, ROW_NUMBER() OVER (ORDER BY M.MessageID) as row     
		FROM [Message] M
		JOIN UserMessage UM ON UM.MessageID = M.MessageID
		JOIN [User] U ON U.UserID = UM.SentTo 
		WHERE
			U.UserID = 1
	) a 
	WHERE row > @pageIni and row <= @pageFim
	ORDER BY row,a.MessageID

-- =============================================
-- Author:		<Alexis Moura>
-- Create date: <30/12/2010>
-- Description:	<SQL remover coluna> 
-- =============================================

ALTER TABLE Employees 
DROP COLUMN firstaname

-- =============================================
-- Author:		<Alexis Moura>
-- Create date: <30/12/2010>
-- Description:	<SQL retorna as tabelas referenciadas atraves de uma fk> 
-- =============================================

SELECT 
	SUBSTRING(CONSTRAINT_NAME, 15+Len('tbInfrac'), Len(CONSTRAINT_NAME)) AS REFERENCIA 
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE 
WHERE TABLE_NAME = 'tbInfrac'

-- =============================================
-- Author:		<Alexis Moura>
-- Create date: <30/12/2010>
-- Description:	<SQL que retorna a chave primaria> 
-- =============================================

SELECT 
	COLUMN_NAME
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE 
WHERE TABLE_NAME = 'tbInfrac'
      AND CONSTRAINT_NAME = (SELECT 
									CONSTRAINT_NAME 
								FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE 
								WHERE TABLE_NAME = 'tbInfrac' AND CONSTRAINT_NAME LIKE 'PK%'
							 )

-- =============================================
-- Author:		<Alexis Moura>
-- Create date: <12/11/2010>
-- Description:	<SQL que gera um trecho de codigo para retorno do dataRead> 
-- =============================================

SELECT DISTINCT
'if(dReader["'+COLUMN_NAME+'"]!= DBNull.Value)'+UPPER(SUBSTRING(REPLACE(TABLE_NAME,'_',''), 1, 1)) + LOWER(SUBSTRING(REPLACE(TABLE_NAME,'_',''), 2, 50))+'.'+CHAR(13)+CHAR(9)+COLUMN_NAME+'='+
									 CASE
									 WHEN DATA_TYPE = 'bigint' AND IS_NULLABLE = 'NO'
									 THEN 'decimal.Parse'

									 -- TIPO bit
									 WHEN DATA_TYPE = 'bit'
									 THEN 'bool.Parse'

									 -- TIPO decimal
									 WHEN DATA_TYPE = 'decimal'
									 THEN 'decimal.Parse'

									 -- TIPO int
									 WHEN DATA_TYPE = 'int'
									 THEN 'int.Parse'


									 -- TIPO money
									 WHEN DATA_TYPE = 'money'
									 THEN 'double.Parse'


									 -- TIPO numeric
									 WHEN DATA_TYPE = 'numeric' 
									 THEN 'double.Parse'


									 -- TIPO real
									 WHEN DATA_TYPE = 'real' 
									 THEN 'double.Parse'


									 -- TIPO smallint
									 WHEN DATA_TYPE = 'smallint' 
									 THEN 'int.Parse'


									 -- TIPO smallmoney
									 WHEN DATA_TYPE = 'smallmoney' 
									 THEN 'decimal.Parse'


									 -- TIPO tinyint
									 WHEN DATA_TYPE = 'tinyint' 
									 THEN 'int.Parse'


									 -- TIPO float
									 WHEN DATA_TYPE = 'float' 
									 THEN 'float.Parse'
									 
									-- TIPO data
									WHEN DATA_TYPE = 'datetime'
									THEN 'DateTime.Parse'
									
									ELSE ''

END+'(dReader["'+COLUMN_NAME+'"].ToString());'+CHAR(13)
 FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'VOLTA_LOG_ATENDIMENTO' 

-- =============================================
-- Author:		<Alexis Moura>
-- Create date: <06/08/2010>
-- Description:	<Retorna todos os dados da tabela> 
-- =============================================

	SELECT TABLE_NAME,COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'seq_matricula_pai' 


-- =============================================
-- Author:		<Alexis Moura>
-- Create date: <06/08/2010>
-- Description:	<Insert um novo cadastrador no CADEP> 
-- =============================================

	INSERT INTO usuario (cod_usu,nom_usu,cod_regiao)values(47,"Marcos",null)
	COMMIT;


-- =============================================
-- Author:		<Alexis Moura>
-- Create date: <06/08/2010>
-- Description:	<Script que gera uma inportação de dados> 
-- =============================================

		DECLARE @query varchar(8000)
		DECLARE cursTable CURSOR FAST_FORWARD FOR 
		SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
		OPEN cursTable
			
			DECLARE @tableName nvarchar(3000)	
			FETCH NEXT FROM cursTable INTO @tableName
			
			WHILE @@FETCH_STATUS=0
			BEGIN
					
			--Declare a cursor to retrieve column specific information for the specified table
			DECLARE cursCol CURSOR FAST_FORWARD FOR 
			SELECT column_name,data_type FROM information_schema.columns WHERE table_name = @tableName
			OPEN cursCol
			
				--for storing the first half of INSERT statement
				DECLARE @string nvarchar(4000)
				
				--for storing the data (VALUES) related statement 
				DECLARE @stringData nvarchar(4000)
				
				--data types returned for respective columns 
				DECLARE @dataType nvarchar(4000) 
				SET @string='INSERT '+@tableName+'('
				SET @stringData=''

				DECLARE @colName nvarchar(50)

				FETCH NEXT FROM cursCol INTO @colName,@dataType

				IF @@fetch_status<>0
					begin
					print 'Table '+@tableName+' not found, processing skipped.'
					close curscol
					deallocate curscol
					return
				END

				WHILE @@FETCH_STATUS=0
				BEGIN
				IF @dataType in ('varchar','char','nchar','nvarchar')
				BEGIN
					SET @stringData=@stringData+''''+'''+isnull('''''+'''''+'+@colName+'+'''''+''''',''NULL'')+'',''+'
				END
				ELSE
				
				--if the datatype is text or something else 
				if @dataType in ('text','ntext') 
				BEGIN
					SET @stringData=@stringData+'''''''''+isnull(cast('+@colName+' as varchar(2000)),'''')+'''''',''+'
				END
				ELSE
				
				--because money doesn't get converted from varchar implicitly
				IF @dataType = 'money' 
				BEGIN
					SET @stringData=@stringData+'''convert(money,''''''+isnull(cast('+@colName+' as varchar(200)),''0.0000'')+''''''),''+'
				END
				ELSE 
				IF @dataType='datetime'
				BEGIN
					SET @stringData=@stringData+'''convert(datetime,'+'''+isnull('''''+'''''+convert(varchar(200),'+@colName+',121)+'''''+''''',''NULL'')+'',121),''+'
				END
				ELSE 
				IF @dataType='image' 
				BEGIN
					SET @stringData=@stringData+'''''''''+isnull(cast(convert(varbinary,'+@colName+') as varchar(6)),''0'')+'''''',''+'
				END
				
				--presuming the data type is int,bit,numeric,decimal 
				ELSE 
				BEGIN
					SET @stringData=@stringData+''''+'''+isnull('''''+'''''+convert(varchar(200),'+@colName+')+'''''+''''',''NULL'')+'',''+'
				END

				SET @string=@string+@colName+','

				FETCH NEXT FROM cursCol INTO @colName,@dataType
				END
				
				print ' SELECT '''+substring(@string,0,len(@string)) + ') VALUES(''+ ' + substring(@stringData,0,len(@stringData)-2)+'''+'')'' FROM '+@tableName
			
			CLOSE cursCol
			DEALLOCATE cursCol
			SET QUOTED_IDENTIFIER OFF 
			SET ANSI_NULLS ON 
			--exec sp_executesql @query
			FETCH NEXT FROM cursTable INTO @tableName
		END
		CLOSE cursTable
		DEALLOCATE cursTable
		
	
	
	
-- =============================================
-- Author:		<Alexis Moura>
-- Create date: <06/08/2010>
-- Description:	<Procedure que Cria um Script de migração de dados> 
-- =============================================
	
		SET QUOTED_IDENTIFIER OFF 
		GO
		SET ANSI_NULLS ON 
		GO

		drop   PROC InsertGenerator
		go

		CREATE PROC InsertGenerator
		(@tableName varchar(100)) as

		--Declare a cursor to retrieve column specific information for the specified table
		DECLARE cursCol CURSOR FAST_FORWARD FOR 
		SELECT column_name,data_type FROM information_schema.columns WHERE table_name = @tableName
		OPEN cursCol
		DECLARE @string nvarchar(3000) --for storing the first half of INSERT statement
		DECLARE @stringData nvarchar(3000) --for storing the data (VALUES) related statement
		DECLARE @dataType nvarchar(1000) --data types returned for respective columns
		SET @string='INSERT '+@tableName+'('
		SET @stringData=''

		DECLARE @colName nvarchar(50)

		FETCH NEXT FROM cursCol INTO @colName,@dataType

		IF @@fetch_status<>0
			begin
			print 'Table '+@tableName+' not found, processing skipped.'
			close curscol
			deallocate curscol
			return
		END

		WHILE @@FETCH_STATUS=0
		BEGIN
		IF @dataType in ('varchar','char','nchar','nvarchar')
		BEGIN
			--SET @stringData=@stringData+'''''''''+isnull('+@colName+','''')+'''''',''+'
			SET @stringData=@stringData+''''+'''+isnull('''''+'''''+'+@colName+'+'''''+''''',''NULL'')+'',''+'
		END
		ELSE
		if @dataType in ('text','ntext') --if the datatype is text or something else 
		BEGIN
			SET @stringData=@stringData+'''''''''+isnull(cast('+@colName+' as varchar(2000)),'''')+'''''',''+'
		END
		ELSE
		IF @dataType = 'money' --because money doesn't get converted from varchar implicitly
		BEGIN
			SET @stringData=@stringData+'''convert(money,''''''+isnull(cast('+@colName+' as varchar(200)),''0.0000'')+''''''),''+'
		END
		ELSE 
		IF @dataType='datetime'
		BEGIN
			--SET @stringData=@stringData+'''convert(datetime,''''''+isnull(cast('+@colName+' as varchar(200)),''0'')+''''''),''+'
			--SELECT 'INSERT Authorizations(StatusDate) VALUES('+'convert(datetime,'+isnull(''''+convert(varchar(200),StatusDate,121)+'''','NULL')+',121),)' FROM Authorizations
			--SET @stringData=@stringData+'''convert(money,''''''+isnull(cast('+@colName+' as varchar(200)),''0.0000'')+''''''),''+'
			SET @stringData=@stringData+'''convert(datetime,'+'''+isnull('''''+'''''+convert(varchar(200),'+@colName+',121)+'''''+''''',''NULL'')+'',121),''+'
		  --                             'convert(datetime,'+isnull(''''+convert(varchar(200),StatusDate,121)+'''','NULL')+',121),)' FROM Authorizations
		END
		ELSE 
		IF @dataType='image' 
		BEGIN
			SET @stringData=@stringData+'''''''''+isnull(cast(convert(varbinary,'+@colName+') as varchar(6)),''0'')+'''''',''+'
		END
		ELSE --presuming the data type is int,bit,numeric,decimal 
		BEGIN
			--SET @stringData=@stringData+'''''''''+isnull(cast('+@colName+' as varchar(200)),''0'')+'''''',''+'
			--SET @stringData=@stringData+'''convert(datetime,'+'''+isnull('''''+'''''+convert(varchar(200),'+@colName+',121)+'''''+''''',''NULL'')+'',121),''+'
			SET @stringData=@stringData+''''+'''+isnull('''''+'''''+convert(varchar(200),'+@colName+')+'''''+''''',''NULL'')+'',''+'
		END

		SET @string=@string+@colName+','

		FETCH NEXT FROM cursCol INTO @colName,@dataType
		END
		DECLARE @Query nvarchar(4000)

		SET @query ='SELECT '''+substring(@string,0,len(@string)) + ') VALUES(''+ ' + substring(@stringData,0,len(@stringData)-2)+'''+'')'' FROM '+@tableName
		exec sp_executesql @query
		--select @query

		CLOSE cursCol
		DEALLOCATE cursCol


		GO
		SET QUOTED_IDENTIFIER OFF 
		GO
		SET ANSI_NULLS ON 
		GO

		
		
-- =============================================
-- Create date: <01/10/2010>
-- Description:	<SCRIPT QUE GERA UM CREATE DE TODAS AS TABELAS DO BANCO> 
-- =============================================	
		
		select  'create table [' + so.name + '] (' + o.list + ')' + CASE WHEN tc.Constraint_Name IS NULL THEN '' ELSE 'ALTER TABLE ' + so.Name + ' ADD CONSTRAINT ' + tc.Constraint_Name  + ' PRIMARY KEY ' + ' (' + LEFT(j.List, Len(j.List)-1) + ')' END
		from    sysobjects so
		cross apply
			(SELECT 
				'  ['+column_name+'] ' + 
				data_type + case data_type
						when 'sql_variant' then ''
						when 'text' then ''
						when 'decimal' then '(' + cast(numeric_precision_radix as varchar) + ', ' + cast(numeric_scale as varchar) + ')'
						else coalesce('('+case when character_maximum_length = -1 then 'MAX' else cast(character_maximum_length as varchar) end +')','') end + ' ' +
				case when exists ( 
				select id from syscolumns
				where object_name(id)=so.name
				and name=column_name
				and columnproperty(id,name,'IsIdentity') = 1 
				) then
				'IDENTITY(' + 
				cast(ident_seed(so.name) as varchar) + ',' + 
				cast(ident_incr(so.name) as varchar) + ')'
				else ''
				end + ' ' +
				 (case when IS_NULLABLE = 'No' then 'NOT ' else '' end ) + 'NULL ' + 
				  case when information_schema.columns.COLUMN_DEFAULT IS NOT NULL THEN 'DEFAULT '+ information_schema.columns.COLUMN_DEFAULT ELSE '' END + ', ' 

			 from information_schema.columns where table_name = so.name
			 order by ordinal_position
			FOR XML PATH('')) o (list)
		left join
			information_schema.table_constraints tc
		on  tc.Table_name               = so.Name
		AND tc.Constraint_Type  = 'PRIMARY KEY'
		cross apply
			(select '[' + Column_Name + '], '
			 FROM       information_schema.key_column_usage kcu
			 WHERE      kcu.Constraint_Name     = tc.Constraint_Name
			 ORDER BY
				ORDINAL_POSITION
			 FOR XML PATH('')) j (list)
		where   xtype = 'U'
		AND name        NOT IN ('dtproperties')
		

-- =============================================
-- Create date: <12/11/2010>
-- Description:	<SCRIPT QUE Coloca um char em Case/Camel> 
-- =============================================	
		
		
CREATE FUNCTION [dbo].[GetCamelCaseName]
(
	@Name varchar(50)
)
RETURNS VARCHAR(50) WITH SCHEMABINDING
AS
BEGIN
			-- Capitalize the first letter and make the rest lowercase
			SELECT @NameCamelCase =	UPPER(SUBSTRING(@Name, 1, 1)) +	LOWER(SUBSTRING(@Name, 2, 50))

			-- McDavid, McReynolds, etc. --> 1st character Uppercase, 2nd Lower, 3rd Uppercase, the rest lower
			IF (@NameCamelCase LIKE 'mc%')
				SELECT @NameCamelCase =	UPPER(SUBSTRING(@Name, 1, 1)) + LOWER(SUBSTRING(@Name, 2, 1)) + UPPER(SUBSTRING(@Name, 3, 1))  + LOWER(SUBSTRING(@Name, 4, 50))

			-- Hyphenated Names "Anderson-White" --> Capitalize after the hyphen
			IF (@NameCamelCase LIKE '%-%')
				SELECT @NameCamelCase =	SUBSTRING(@NameCamelCase, 1, CHARINDEX('-', @NameCamelCase)) + UPPER(SUBSTRING(@NameCamelCase, CHARINDEX('-', @NameCamelCase) + 1, 1)) + SUBSTRING(@NameCamelCase, CHARINDEX('-', @NameCamelCase) + 2, 50)

			-- O'Reilly, O'Neil, etc. --> 1st and 3rd upper case, the rest lower
			IF (@NameCamelCase LIKE '%''%')
				SELECT @NameCamelCase = SUBSTRING(@NameCamelCase, 1, CHARINDEX('''', @NameCamelCase)) + UPPER(SUBSTRING(@NameCamelCase, CHARINDEX('''', @NameCamelCase) + 1, 1)) + SUBSTRING(@NameCamelCase, CHARINDEX('''', @NameCamelCase) + 2, 50)

			-- I found some compound last names in parentheses in my sample --> capitalize after '('
			IF (@NameCamelCase LIKE '%(%')
				SELECT @NameCamelCase = SUBSTRING(@NameCamelCase, 1, CHARINDEX('(', @NameCamelCase) - 1) + '('  + UPPER(SUBSTRING(@NameCamelCase, CHARINDEX('(', @NameCamelCase) + 1, 1)) + SUBSTRING(@NameCamelCase, CHARINDEX('(', @NameCamelCase) + 2, 50)

			-- Hyphenated Names "De La Hoja" --> Capitalize after each space (do it twice for names with three words)
			--     Change the space to '?' each time (so you actually get to the second space), then replace the '?' with ' '
			IF (@NameCamelCase LIKE '% %')
				SELECT @NameCamelCase =	SUBSTRING(@NameCamelCase, 1, CHARINDEX(' ', @NameCamelCase) - 1) + '?'  + UPPER(SUBSTRING(@NameCamelCase, CHARINDEX(' ', @NameCamelCase) + 1, 1)) + SUBSTRING(@NameCamelCase, CHARINDEX(' ', @NameCamelCase) + 2, 50)
			IF (@NameCamelCase LIKE '% %')
				SELECT @NameCamelCase =	SUBSTRING(@NameCamelCase, 1, CHARINDEX(' ', @NameCamelCase) - 1) + '?'  + UPPER(SUBSTRING(@NameCamelCase, CHARINDEX(' ', @NameCamelCase) + 1, 1)) + SUBSTRING(@NameCamelCase, CHARINDEX(' ', @NameCamelCase) + 2, 50)

			SELECT @NameCamelCase = REPLACE(@NameCamelCase, '?', ' ')

			-- Suffixes and other miscellaneous things
			SELECT @NameCamelCase = REPLACE(@NameCamelCase, ' sr', ' Sr')
			SELECT @NameCamelCase = REPLACE(@NameCamelCase, ' jr', ' Jr')
			SELECT @NameCamelCase = REPLACE(@NameCamelCase, ' ii', ' II')
			SELECT @NameCamelCase = REPLACE(@NameCamelCase, ' iii', ' III')
			SELECT @NameCamelCase = REPLACE(@NameCamelCase, ' DE ', ' de ')
			SELECT @NameCamelCase = REPLACE(@NameCamelCase, 'macdonald', 'MacDonald')

			if (@NameCamelCase LIKE '% iv') -- just do names that end in 'IV' so you don't change "Ivy" to "IVy"
				SELECT @NameCamelCase = REPLACE(@NameCamelCase, ' iv', ' IV')

			if ((@NameCamelCase = 'i') or (@NameCamelCase = 'ii')or (@NameCamelCase = 'iii') or (@NameCamelCase = 'iv'))
				SELECT @NameCamelCase = UPPER(@NameCamelCase)

			-- Return the result of the function
			RETURN ISNULL(@NameCamelCase, '')

		END

	RETURN ISNULL(@NameCamelCase, '')

END
