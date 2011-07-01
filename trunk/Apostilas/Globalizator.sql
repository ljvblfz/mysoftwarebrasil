DECLARE @message varchar(8000)

PRINT '// '
PRINT '//  Copyright (c) 2011, WebAula S/A '
PRINT '//  All rights reserved.'
PRINT '//'
PRINT '//  Authors: '
PRINT '//               '
PRINT '//           * Ivan Paulovich (ivan@100loop.com)'
PRINT '//           Blog: http://www.100loop.com/          '
PRINT '//           Messenger: ivanpaulovich@hotmail.com '
PRINT '//               '
PRINT '//           * Phillipe Duarte Gori (pdgori@100loop.com)'
PRINT '//           Blog: http://www.100loop.com/          '
PRINT '//           Messenger: pdgori@hotmail.com '
PRINT '//'
PRINT ''
PRINT 'using System.Globalization;'
PRINT 'using System.Web;'
PRINT 'using Webaula.Cache;'
PRINT ''
PRINT 'namespace Infrastructure'
PRINT '{'
PRINT '    /// <summary>'
PRINT '    /// Globaliza expressões'
PRINT '    /// </summary>'
PRINT '    public static class Globalizator'
PRINT '    {'
PRINT '        /// <summary>'
PRINT '        /// Localiza um texto para o idioma em execução da aplicação'
PRINT '        /// </summary>'
PRINT '        /// <param name="text">ID da mensagem a ser globalizada</param>'
PRINT '        /// <returns>String com o texto globalizado</returns>'
PRINT '        public static string Localize(string text)'
PRINT '        {'
PRINT '            string cacheKey = string.Format(CultureInfo.InvariantCulture, "expression_for_{0}", text);'
PRINT ''
PRINT '            string expression = "E_" + text;'
PRINT ''
PRINT '            if (!CacheHelper.Exists(cacheKey))'
PRINT '            {'
PRINT '                HttpCookie cookie = HttpContext.Current.Request.Cookies["Ticket"];'
PRINT ''
PRINT '                if (cookie != null)'
PRINT '                {'
PRINT '                    var client = new Management.Globalization.ServiceClient();'
PRINT ''
PRINT '                    if (client.GetString(cookie.Value, text, out expression))'
PRINT '                        CacheHelper.Add(expression, cacheKey);'
PRINT '                }'
PRINT '            }'
PRINT '            else'
PRINT '                CacheHelper.Get(cacheKey, out expression);'
PRINT ''
PRINT '            return expression;'
PRINT '        }'
PRINT ''

DECLARE db_cursor CURSOR FOR  

select 
	case TC.CONSTRAINT_TYPE
		when 'PRIMARY KEY' 
			then ''
		else 
			case
				when IS_NULLABLE = 'YES' AND CHARACTER_MAXIMUM_LENGTH is not null
				then 
				'        public static string ' + ltrim(rtrim(C.TABLE_NAME))+ltrim(rtrim(C.COLUMN_NAME))+'StringLength {' + char(13) +
				'            get' + char(13) +
				'            {' + char(13) +
				'                return Localize("O campo '+ltrim(rtrim(C.COLUMN_NAME))+' aceita no máximo ' + cast(C.CHARACTER_MAXIMUM_LENGTH as varchar(100)) + ' caracteres.");'  + char(13) +
				'            }' + char(13) +
				'        }'
					
				when IS_NULLABLE = 'NO' AND CHARACTER_MAXIMUM_LENGTH is null
				then '        public static string ' + ltrim(rtrim(C.TABLE_NAME))+
					case when substring(ltrim(rtrim(C.COLUMN_NAME)),len(ltrim(rtrim(C.COLUMN_NAME)))-1, len(ltrim(rtrim(C.COLUMN_NAME)))) = 'ID'
					then	
				 substring(ltrim(rtrim(C.COLUMN_NAME)),0,len(ltrim(rtrim(C.COLUMN_NAME))))+'dRequired {' + char(13) +
				'            get'  + char(13) +
				'            {'  + char(13) +
				'                return Localize("' + substring(ltrim(rtrim(C.COLUMN_NAME)),0,len(ltrim(rtrim(C.COLUMN_NAME))))+'d é obrigatório");'+ char(13) +
				'            }'  + char(13) +
				'        }' + char(13) 
						
					else
				 ltrim(rtrim(C.COLUMN_NAME))+'Required {'  + char(13) +
				'            get'  + char(13) +
				'            {'  + char(13) +
				'                return Localize("' + ltrim(rtrim(C.COLUMN_NAME)) + ' é obrigatório");' + char(13) +
				'            }'  + char(13) +
				'        }'  + char(13) 
						
					end
				when IS_NULLABLE = 'NO' AND CHARACTER_MAXIMUM_LENGTH is not null
				then 
				
				'        public static string ' + ltrim(rtrim(C.TABLE_NAME))+ltrim(rtrim(C.COLUMN_NAME))+'StringLength {'  + char(13) +
				'            get'  + char(13) +
				'            {'  + char(13) +
				'                return Localize("O campo '+ltrim(rtrim(C.COLUMN_NAME))+' aceita no máximo ' + cast(C.CHARACTER_MAXIMUM_LENGTH as varchar(100)) + ' caracteres.");'  + char(13) +
				'            }'  + char(13) +
				'        }' + char(13) +
				'' + char(13) +
				'        public static string ' +	ltrim(rtrim(C.TABLE_NAME))+ltrim(rtrim(C.COLUMN_NAME))+'Required {'  + char(13) +
				'            get'  + char(13) +
				'            {'  + char(13) +
				'                return Localize("' + ltrim(rtrim(C.COLUMN_NAME)) + ' é obrigatório");' + char(13) +
				'            }'  + char(13) +
				'        }' + char(13) 
				WHEN IS_NULLABLE = 'YES' AND C.DATA_TYPE = 'INT'
				THEN
					case when substring(ltrim(rtrim(C.COLUMN_NAME)),len(ltrim(rtrim(C.COLUMN_NAME)))-1, len(ltrim(rtrim(C.COLUMN_NAME)))) = 'ID'
					THEN
				'' + char(13) +
				'        public static string ' + ltrim(rtrim(C.TABLE_NAME))+ substring(ltrim(rtrim(C.COLUMN_NAME)),0,len(ltrim(rtrim(C.COLUMN_NAME))))+'dRequired {' + char(13) +
				'            get'  + char(13) +
				'            {'  + char(13) +
				'                return Localize("' + ltrim(rtrim(C.COLUMN_NAME)) + ' é obrigatório");' + char(13) +
				'            }'  + char(13) +
				'        }' + char(13) 
					ELSE
				'' + char(13) +
				'        public static string ' + ltrim(rtrim(C.TABLE_NAME))+ ltrim(rtrim(C.COLUMN_NAME)) + 'Required {'  + char(13) +
				'            get'  + char(13) +
				'            {'  + char(13) +
				'                return Localize("' + ltrim(rtrim(C.COLUMN_NAME)) + ' é obrigatório");' + char(13) +
				'            }'  + char(13) +
				'        }' + char(13) 
					END
				
			end
	 end as CONSTRAINT_TYPE1
from INFORMATION_SCHEMA.COLUMNS C
left join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE CC on CC.TABLE_NAME = C.TABLE_NAME AND CC.COLUMN_NAME = C.COLUMN_NAME
left join INFORMATION_SCHEMA.TABLE_CONSTRAINTS TC on TC.CONSTRAINT_NAME = CC.CONSTRAINT_NAME
left join INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS RC on RC.CONSTRAINT_NAME = CC.CONSTRAINT_NAME
--where TC.CONSTRAINT_TYPE <> 'PRIMARY KEY'
order by c.table_name, c.column_name

OPEN db_cursor   
FETCH NEXT FROM db_cursor INTO @message

WHILE @@FETCH_STATUS = 0  

BEGIN

PRINT replace(@message,'_','')

	FETCH NEXT FROM db_cursor INTO @message	
END 
 
CLOSE db_cursor   
DEALLOCATE db_cursor 

PRINT ''
PRINT '    }'
PRINT '}'
