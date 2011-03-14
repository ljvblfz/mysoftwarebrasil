object dmCarga: TdmCarga
  OldCreateOrder = False
  OnCreate = DataModuleCreate
  Height = 442
  Width = 466
  object qryRegistroT: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select distinct'
      #9'tr_data_inicial, '
      #9'tr_categoria,'
      '('
      #9#39'T'#39' +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(tr_categoria,2) as varchar(2)) +'
      
        #9'cast(DBO.FC_COMPLETA_BRANCOS((select tb_descricao from tabelas ' +
        'where tb_tabela = '#39'carga'#39' and tb_campo = '#39'cg_categorias'#39' and tb_' +
        'valor = tr_categoria)) as varchar(30)) +'
      #9'CASE '
      #9'WHEN tr_data_inicial is null THEN '#39'00000000'#39
      #9'ELSE '
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, tr_data_inicial),4) ' +
        'as varchar(4))+ '
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, tr_data_inicial),2) as' +
        ' varchar(2))+'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(dd, tr_data_inicial),2) as' +
        ' varchar(2))'
      #9'END +'
      #9'/*AGUA*/'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_agua from tarifas' +
        ' T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicial' +
        ' = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_seq' +
        'uencia = 1),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_agua from tarifa' +
        's T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicia' +
        'l = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_se' +
        'quencia = 1),0) - '
      
        #9#9'cast(isnull((select tr_agua from tarifas T2 where T.tr_categor' +
        'ia = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicial ' +
        'and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 1),0) as inte' +
        'ger)) * 1000, 3) as varchar(3)) +'
      ''
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_agua from tarifas' +
        ' T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicial' +
        ' = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_seq' +
        'uencia = 2),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_agua from tarifa' +
        's T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicia' +
        'l = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_se' +
        'quencia = 2),0) - '
      
        #9#9'cast(isnull((select tr_agua from tarifas T2 where T.tr_categor' +
        'ia = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicial ' +
        'and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 2),0) as inte' +
        'ger)) * 1000, 3) as varchar(3)) +'
      ''
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_agua from tarifas' +
        ' T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicial' +
        ' = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_seq' +
        'uencia = 3),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_agua from tarifa' +
        's T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicia' +
        'l = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_se' +
        'quencia = 3),0) - '
      
        #9#9'cast(isnull((select tr_agua from tarifas T2 where T.tr_categor' +
        'ia = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicial ' +
        'and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 3),0) as inte' +
        'ger)) * 1000, 3) as varchar(3)) +'
      ''
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_agua from tarifas' +
        ' T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicial' +
        ' = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_seq' +
        'uencia = 4),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_agua from tarifa' +
        's T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicia' +
        'l = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_se' +
        'quencia = 4),0) -'
      
        #9#9'cast(isnull((select tr_agua from tarifas T2 where T.tr_categor' +
        'ia = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicial ' +
        'and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 4),0) as inte' +
        'ger)) * 1000, 3) as varchar(3)) +'
      ''
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_agua from tarifas' +
        ' T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicial' +
        ' = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_seq' +
        'uencia = 5),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_agua from tarifa' +
        's T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicia' +
        'l = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_se' +
        'quencia = 5),0) - '
      
        #9#9'cast(isnull((select tr_agua from tarifas T2 where T.tr_categor' +
        'ia = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicial ' +
        'and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 5),0) as inte' +
        'ger)) * 1000, 3) as varchar(3)) +'
      ''
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_agua from tarifas' +
        ' T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicial' +
        ' = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_seq' +
        'uencia = 6),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_agua from tarifa' +
        's T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicia' +
        'l = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_se' +
        'quencia = 6),0) - '
      
        #9#9'cast(isnull((select tr_agua from tarifas T2 where T.tr_categor' +
        'ia = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicial ' +
        'and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 6),0) as inte' +
        'ger)) * 1000, 3) as varchar(3)) +'
      ''
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_agua from tarifas' +
        ' T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicial' +
        ' = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_seq' +
        'uencia = 7),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_agua from tarifa' +
        's T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicia' +
        'l = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_se' +
        'quencia = 7),0) - '
      
        #9#9'cast(isnull((select tr_agua from tarifas T2 where T.tr_categor' +
        'ia = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicial ' +
        'and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 7),0) as inte' +
        'ger)) * 1000, 3) as varchar(3)) +'
      ''
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_agua from tarifas' +
        ' T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicial' +
        ' = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_seq' +
        'uencia = 8),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_agua from tarifa' +
        's T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicia' +
        'l = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_se' +
        'quencia = 8),0) - '
      
        #9#9'cast(isnull((select tr_agua from tarifas T2 where T.tr_categor' +
        'ia = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicial ' +
        'and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 8),0) as inte' +
        'ger)) * 1000, 3) as varchar(3)) +'
      ''
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_agua from tarifas' +
        ' T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicial' +
        ' = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_seq' +
        'uencia = 9),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_agua from tarifa' +
        's T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicia' +
        'l = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_se' +
        'quencia = 9),0) - '
      
        #9#9'cast(isnull((select tr_agua from tarifas T2 where T.tr_categor' +
        'ia = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicial ' +
        'and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 9),0) as inte' +
        'ger)) * 1000, 3) as varchar(3)) +'
      ' '#9
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_agua from tarifas ' +
        'T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicial ' +
        '= T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_sequ' +
        'encia = 10),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_agua from tarifa' +
        's T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicia' +
        'l = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_se' +
        'quencia = 10),0) - '
      
        #9#9'cast(isnull((select tr_agua from tarifas T2 where T.tr_categor' +
        'ia = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicial ' +
        'and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 10),0) as int' +
        'eger)) * 1000, 3) as varchar(3)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 1),0), 6) as varchar(6)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 2),0), 6) as varchar(6)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 3),0), 6) as varchar(6)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 4),0), 6) as varchar(6)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 5),0), 6) as varchar(6)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 6),0), 6) as varchar(6)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 7),0), 6) as varchar(6)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 8),0), 6) as varchar(6)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 9),0), 6) as varchar(6)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 10),0), 6) as varchar(6)) +'
      ''
      #9'/*ESGOTO*/'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_esgoto from tarif' +
        'as T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inici' +
        'al = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_s' +
        'equencia = 1),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_esgoto from tari' +
        'fas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inic' +
        'ial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_' +
        'sequencia = 1),0) - '
      
        #9#9'cast(isnull((select tr_esgoto from tarifas T2 where T.tr_categ' +
        'oria = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicia' +
        'l and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 1),0) as in' +
        'teger)) * 1000, 3) as varchar(3)) +'
      ''
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_esgoto from tarif' +
        'as T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inici' +
        'al = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_s' +
        'equencia = 2),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_esgoto from tari' +
        'fas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inic' +
        'ial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_' +
        'sequencia = 2),0) - '
      
        #9#9'cast(isnull((select tr_esgoto from tarifas T2 where T.tr_categ' +
        'oria = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicia' +
        'l and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 2),0) as in' +
        'teger)) * 1000, 3) as varchar(3)) +'
      ''
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_esgoto from tarif' +
        'as T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inici' +
        'al = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_s' +
        'equencia = 3),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_esgoto from tari' +
        'fas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inic' +
        'ial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_' +
        'sequencia = 3),0) - '
      
        #9#9'cast(isnull((select tr_esgoto from tarifas T2 where T.tr_categ' +
        'oria = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicia' +
        'l and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 3),0) as in' +
        'teger)) * 1000, 3) as varchar(3)) +'
      ''
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_esgoto from tarif' +
        'as T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inici' +
        'al = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_s' +
        'equencia = 4),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_esgoto from tari' +
        'fas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inic' +
        'ial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_' +
        'sequencia = 4),0) - '
      
        #9#9'cast(isnull((select tr_esgoto from tarifas T2 where T.tr_categ' +
        'oria = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicia' +
        'l and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 4),0) as in' +
        'teger)) * 1000, 3) as varchar(3)) +'
      ''
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_esgoto from tarif' +
        'as T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inici' +
        'al = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_s' +
        'equencia = 5),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_esgoto from tari' +
        'fas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inic' +
        'ial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_' +
        'sequencia = 5),0) -'
      
        #9#9'cast(isnull((select tr_esgoto from tarifas T2 where T.tr_categ' +
        'oria = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicia' +
        'l and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 5),0) as in' +
        'teger)) * 1000, 3) as varchar(3)) +'
      ''
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_esgoto from tarif' +
        'as T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inici' +
        'al = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_s' +
        'equencia = 6),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_esgoto from tari' +
        'fas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inic' +
        'ial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_' +
        'sequencia = 6),0) - '
      
        #9#9'cast(isnull((select tr_esgoto from tarifas T2 where T.tr_categ' +
        'oria = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicia' +
        'l and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 6),0) as in' +
        'teger)) * 1000, 3) as varchar(3)) +'
      ''
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_esgoto from tarif' +
        'as T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inici' +
        'al = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_s' +
        'equencia = 7),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_esgoto from tari' +
        'fas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inic' +
        'ial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_' +
        'sequencia = 7),0) - '
      
        #9#9'cast(isnull((select tr_esgoto from tarifas T2 where T.tr_categ' +
        'oria = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicia' +
        'l and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 7),0) as in' +
        'teger)) * 1000, 3) as varchar(3)) +'
      ''
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_esgoto from tarif' +
        'as T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inici' +
        'al = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_s' +
        'equencia = 8),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_esgoto from tari' +
        'fas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inic' +
        'ial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_' +
        'sequencia = 8),0) - '
      
        #9#9'cast(isnull((select tr_esgoto from tarifas T2 where T.tr_categ' +
        'oria = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicia' +
        'l and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 8),0) as in' +
        'teger)) * 1000, 3) as varchar(3)) +'
      ''
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_esgoto from tarif' +
        'as T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inici' +
        'al = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_s' +
        'equencia = 9),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_esgoto from tari' +
        'fas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inic' +
        'ial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_' +
        'sequencia = 9),0) - '
      
        #9#9'cast(isnull((select tr_esgoto from tarifas T2 where T.tr_categ' +
        'oria = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicia' +
        'l and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 9),0) as in' +
        'teger)) * 1000, 3) as varchar(3)) +'
      ''
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_esgoto from tarifa' +
        's T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inicia' +
        'l = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_se' +
        'quencia = 10),0), 8) as varchar(8)) +'
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((isnull((select tr_esgoto from tari' +
        'fas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_inic' +
        'ial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2.tr_' +
        'sequencia = 10),0) - '
      
        #9#9'cast(isnull((select tr_esgoto from tarifas T2 where T.tr_categ' +
        'oria = T2.tr_categoria and T.tr_data_inicial = T2.tr_data_inicia' +
        'l and T.tr_grupo = T2.tr_grupo and T2.tr_sequencia = 10),0) as i' +
        'nteger)) * 1000, 3) as varchar(3)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 1),0), 6) as varchar(6)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 2),0), 6) as varchar(6)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 3),0), 6) as varchar(6)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 4),0), 6) as varchar(6)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 5),0), 6) as varchar(6)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 6),0), 6) as varchar(6)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 7),0), 6) as varchar(6)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 8),0), 6) as varchar(6)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 9),0), 6) as varchar(6)) +'
      
        ' '#9'cast(DBO.FC_COMPLETA_ZEROS(isnull((select tr_faixa_final from ' +
        'tarifas T2 where T.tr_categoria = T2.tr_categoria and T.tr_data_' +
        'inicial = T2.tr_data_inicial and T.tr_grupo = T2.tr_grupo and T2' +
        '.tr_sequencia = 10),0), 6) as varchar(6))'
      ') as linha'
      'from'
      #9'tarifas T'
      'where tr_grupo = :grupo'
      'and tr_data_inicial in ('
      ''
      'select distinct TOP 2 tr_data_inicial'
      'from tarifas T2'
      'where T2.tr_referencia = T.tr_referencia'
      'and T2.tr_grupo = T.tr_grupo'
      'order by tr_data_inicial desc'
      ')'
      ''
      'order by tr_data_inicial desc, tr_categoria')
    Left = 32
    Top = 56
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
    object qryRegistroTtr_data_inicial: TDateTimeField
      FieldName = 'tr_data_inicial'
    end
    object qryRegistroTtr_categoria: TIntegerField
      FieldName = 'tr_categoria'
    end
    object qryRegistroTlinha: TMemoField
      FieldName = 'linha'
      BlobType = ftMemo
      Size = 1
    end
  end
  object qryRegistroI: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select distinct'
      '('
      #9#39'I'#39' +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(ip_ir, 3) as varchar(3)) + '
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((ip_ir - cast(ip_ir as integer)) * ' +
        '100, 2) as varchar(2)) +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(ip_csll, 3) as varchar(3)) + '
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((ip_csll - cast(ip_csll as integer)' +
        ') * 100, 2) as varchar(2)) +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(ip_pis, 3) as varchar(3)) + '
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((ip_pis - cast(ip_pis as integer)) ' +
        '* 100, 2) as varchar(2)) +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(ip_cofins, 3) as varchar(3)) + '
      
        #9#9'cast(DBO.FC_COMPLETA_ZEROS((ip_cofins - cast(ip_cofins as inte' +
        'ger)) * 100, 2) as varchar(2)) '
      ') as linha'
      'from impostos'
      'where ip_grupo = :grupo'
      
        #9'and ip_data_inicial = (select MAX(ip_data_inicial) from imposto' +
        's where ip_grupo = :grupo)')
    Left = 32
    Top = 200
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
    object qryRegistroIlinha: TStringField
      FieldName = 'linha'
      Size = 21
    end
  end
  object qryRegistroQ: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select distinct'
      '('
      #9#39'Q'#39' +'
      #9'CASE'
      #9#9'WHEN qa_data is null THEN '#39'00000000'#39
      #9#9'ELSE '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, qa_data),4) as varc' +
        'har(4))+ '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, qa_data),2) as varcha' +
        'r(2))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(dd, qa_data),2) as varcha' +
        'r(2))'
      #9'END +'
      #9'cast(DBO.FC_COMPLETA_BRANCOS(qa_turbidez) as varchar(7)) +'
      #9'cast(DBO.FC_COMPLETA_BRANCOS(qa_cor) as varchar(7)) +'
      #9'cast(DBO.FC_COMPLETA_BRANCOS(qa_cloro) as varchar(7)) +'
      #9'cast(DBO.FC_COMPLETA_BRANCOS(qa_fluoreto) as varchar(7)) +'
      #9'cast(DBO.FC_COMPLETA_BRANCOS(qa_ph) as varchar(7)) +'
      
        #9'cast(DBO.FC_COMPLETA_BRANCOS(qa_coliformes_totais) as varchar(7' +
        ')) +'
      
        #9'cast(DBO.FC_COMPLETA_BRANCOS(qa_coliformes_termotolerantes) as ' +
        'varchar(7)) '
      ''
      ') as linha'
      'from qualidades_agua'
      'where '#9'qa_grupo = :grupo'
      'and'#9'qa_data = '
      #9'(select MAX(qa_data) '
      #9'from qualidades_agua'
      #9'where '#9'qa_grupo = :grupo)')
    Left = 32
    Top = 248
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
    object qryRegistroQlinha: TStringField
      FieldName = 'linha'
      Size = 58
    end
  end
  object qryRegistro2: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'
      '  cg_matricula as matricula,'
      '  cg_referencia as referencia,'
      '  cg_grupo as grupo,'
      '  cg_sequencia as sequencia,'
      '  cg_flag_emite_conta as emite_conta,'
      
        '  case '#9'when (cg_ident_consumidor in (2, 9)) and (cg_matricula  ' +
        '= cg_matricula_pai) then 0'
      
        #9'when (cg_ident_consumidor in (3, 8)) and (cg_matricula <> cg_ma' +
        'tricula_pai) then 0'
      '  else 1'
      '  end as busca_dados,'
      '('
      #9#39'2'#39' +'
      
        '  '#9'cast(DBO.FC_COMPLETA_ZEROS(cg_cod_logradouro, 4) as varchar(4' +
        ')) +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(cg_num_imovel, 5) as varchar(5)) +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(cg_matricula, 7) as varchar(7))+'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(isnull(cg_matricula_pai,0), 7) as va' +
        'rchar(7))+'
      #9'cast(DBO.FC_COMPLETA_BRANCOS(cg_cachorro) as varchar(1))+'
      
        #9'cast(DBO.FC_COMPLETA_BRANCOS(cg_entrega_alternativa) as varchar' +
        '(60))+'
      #9'cast(DBO.FC_COMPLETA_BRANCOS(cg_nome) as varchar(35))+'
      
        #9'cast(DBO.FC_COMPLETA_BRANCOS(isnull(cg_numero_hd,'#39'           '#39')' +
        ') as varchar(11))+'
      
        #9'cast(DBO.FC_COMPLETA_BRANCOS(isnull(cg_capacidade_hidrometro,'#39#39 +
        ')) as varchar(1))+'
      '  CASE'
      '    WHEN cg_virtual = '#39'S'#39' THEN '#39'1'#39
      '    WHEN cg_virtual = '#39'N'#39' THEN '#39'0'#39
      '    ELSE '#39'0'#39
      '  END +'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(isnull(cg_ident_consumidor,0), 2) as' +
        ' varchar(2))+'
      #9'CASE cg_categoria'
      #9#9'WHEN 7 THEN'
      #9#9#9#39'07'#39' +  /*GRANDES CONSUMIDORES*/'
      #9#9#9'CASE cg_natureza_ligacao'
      #9#9#9#9'WHEN 1 THEN /*AGUA*/'
      
        #9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_res + cg_economia_co' +
        'm + cg_economia_ind + cg_economia_pub + cg_economia_soc, 3) as v' +
        'archar(3))'
      #9#9#9#9#9'+ '#39'000'#39
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA2*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA3*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA4*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA5*/'
      #9#9#9#9'WHEN 2 THEN /*AMBOS*/'
      
        #9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_res + cg_economia_co' +
        'm + cg_economia_ind + cg_economia_pub + cg_economia_soc, 3) as v' +
        'archar(3))'
      
        #9#9#9#9#9'+ cast(DBO.FC_COMPLETA_ZEROS(cg_economia_res + cg_economia_' +
        'com + cg_economia_ind + cg_economia_pub + cg_economia_soc, 3) as' +
        ' varchar(3))'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA2*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA3*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA4*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA5*/'
      #9#9#9#9'WHEN 3 THEN  /*ESGOTO*/'
      #9#9#9#9#9#39'000'#39
      
        #9#9#9#9#9'+ cast(DBO.FC_COMPLETA_ZEROS(cg_economia_res + cg_economia_' +
        'com + cg_economia_ind + cg_economia_pub + cg_economia_soc, 3) as' +
        ' varchar(3))'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA2*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA3*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA4*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA5*/'
      
        #9#9#9#9'ELSE '#39'00000000'#39' + '#39'00000000'#39' + '#39'00000000'#39' + '#39'00000000'#39' + '#39'00' +
        '000000'#39
      #9#9#9#9'END'
      #9#9'WHEN 8 THEN'
      #9#9#9#39'08'#39' + /*ENTIDADES ASSISTENCIAIS*/  '
      #9#9#9'CASE cg_natureza_ligacao'
      #9#9#9#9'WHEN 1 THEN /*AGUA*/'
      
        #9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_ea, 3) as varchar(3)' +
        ')'
      #9#9#9#9#9'+ '#39'000'#39
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA2*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA3*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA4*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA5*/'
      #9#9#9#9'WHEN 2 THEN  /*AMBOS*/'
      
        #9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_ea, 3) as varchar(3)' +
        ')'
      
        #9#9#9#9#9'+ cast(DBO.FC_COMPLETA_ZEROS(cg_economia_ea, 3) as varchar(' +
        '3))'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA2*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA3*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA4*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA5*/'
      #9#9#9#9'WHEN 3 THEN /*ESGOTO*/'
      #9#9#9#9#9#39'000'#39
      
        #9#9#9#9#9'+ cast(DBO.FC_COMPLETA_ZEROS(cg_economia_ea, 3) as varchar(' +
        '3))'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA2*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA3*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA4*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA5*/'
      
        #9#9#9#9'ELSE '#39'00000000'#39' + '#39'00000000'#39' + '#39'00000000'#39' + '#39'00000000'#39' + '#39'00' +
        '000000'#39
      #9#9#9#9'END'
      #9#9'ELSE '
      #9#9#9'CASE cg_natureza_ligacao'
      #9#9#9#9'WHEN 1 THEN /*AGUA*/'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_res <> 0 THEN'
      #9#9#9#9#9#9#9#39'01'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_res,3) as varchar(' +
        '3)) +'
      #9#9#9#9#9#9#9#39'000'#39
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_com <> 0 THEN'
      #9#9#9#9#9#9#9#39'02'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_com,3) as varchar(' +
        '3)) +'
      #9#9#9#9#9#9#9#39'000'#39
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_ind <> 0 THEN'
      #9#9#9#9#9#9#9#39'03'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_ind,3) as varchar(' +
        '3)) +'
      #9#9#9#9#9#9#9#39'000'#39
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_pub <> 0 THEN'
      #9#9#9#9#9#9#9#39'04'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_pub,3) as varchar(' +
        '3)) +'
      #9#9#9#9#9#9#9#39'000'#39
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_soc <> 0 THEN'
      #9#9#9#9#9#9#9#39'06'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_soc,3) as varchar(' +
        '3)) +'
      #9#9#9#9#9#9#9#39'000'#39
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END'
      #9#9#9#9'WHEN 2 THEN  /*AMBOS*/'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_res <> 0 THEN'
      #9#9#9#9#9#9#9#39'01'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_res,3) as varchar(' +
        '3)) +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_res,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_com <> 0 THEN'
      #9#9#9#9#9#9#9#39'02'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_com,3) as varchar(' +
        '3)) +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_com,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_ind <> 0 THEN'
      #9#9#9#9#9#9#9#39'03'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_ind,3) as varchar(' +
        '3)) +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_ind,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_pub <> 0 THEN'
      #9#9#9#9#9#9#9#39'04'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_pub,3) as varchar(' +
        '3)) +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_pub,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_soc <> 0 THEN'
      #9#9#9#9#9#9#9#39'06'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_soc,3) as varchar(' +
        '3)) +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_soc,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END'
      #9#9#9#9'WHEN 3 THEN /*ESGOTO*/'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_res <> 0 THEN'
      #9#9#9#9#9#9#9#39'01'#39' + '
      #9#9#9#9#9#9#9#39'000'#39' +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_res,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_com <> 0 THEN'
      #9#9#9#9#9#9#9#39'02'#39' + '
      #9#9#9#9#9#9#9#39'000'#39' +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_com,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_ind <> 0 THEN'
      #9#9#9#9#9#9#9#39'03'#39' + '
      #9#9#9#9#9#9#9#39'000'#39' +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_ind,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_pub <> 0 THEN'
      #9#9#9#9#9#9#9#39'04'#39' + '
      #9#9#9#9#9#9#9#39'000'#39' +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_pub,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_soc <> 0 THEN'
      #9#9#9#9#9#9#9#39'06'#39' + '
      #9#9#9#9#9#9#9#39'000'#39' +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_soc,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END'
      
        #9#9#9#9'ELSE '#39'00000000'#39' + '#39'00000000'#39' + '#39'00000000'#39' + '#39'00000000'#39' + '#39'00' +
        '000000'#39
      #9#9#9#9'END'
      #9'END +'
      #9'CASE cg_ident_calculo'
      #9#9'WHEN '#39'B'#39' THEN '
      #9#9#9'CASE cg_natureza_ligacao'
      #9#9#9#9'WHEN 1 /*AGUA*/ THEN '#39'34'#39
      #9#9#9#9'WHEN 2 /*AMBOS*/ THEN '#39'33'#39
      #9#9#9#9'WHEN 3 /*ESGOTO*/ THEN '#39'43'#39
      #9#9#9#9'ELSE /*ERRO*/ '#39'44'#39
      #9#9#9'END'
      #9#9'ELSE'
      #9#9#9'CASE cg_natureza_ligacao'
      #9#9#9#9'WHEN 1 /*AGUA*/ THEN '#39'14'#39
      #9#9#9#9'WHEN 2 /*AMBOS*/ THEN '#39'11'#39
      #9#9#9#9'WHEN 3 /*ESGOTO*/ THEN '#39'41'#39
      #9#9#9#9'ELSE /*ERRO*/ '#39'44'#39
      #9#9#9'END'
      #9'END +'
      '  cast(DBO.FC_COMPLETA_ZEROS(cg_setor, 3) as varchar(3)) +'
      #9'cast(DBO.FC_COMPLETA_BRANCOS(cg_inscricao) as varchar(16)) +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(cg_sequencia,  8) as varchar(8)) +'
      #9'cast(DBO.FC_COMPLETA_BRANCOS(cg_complemento) as varchar(10)) +'
      #9'CASE'
      
        #9#9'WHEN (cg_flag_emite_conta = '#39'N'#39' and cg_flag_calcula_conta = '#39'N' +
        #39') THEN '#39'7'#39
      
        #9#9'WHEN (cg_flag_emite_conta = '#39'N'#39' and cg_flag_calcula_conta = '#39'S' +
        #39') THEN '#39'6'#39
      #9#9'WHEN cg_flag_calcula_imposto = '#39'S'#39' THEN '#39'4'#39
      
        #9#9'WHEN cg_codigo_banco is not null and cg_entrega_alternativa <>' +
        ' '#39#39' THEN '#39'5'#39
      
        #9#9'WHEN cg_codigo_banco is not null and cg_entrega_alternativa = ' +
        #39#39' THEN '#39'1'#39
      
        #9#9'WHEN cg_codigo_banco is null and cg_entrega_alternativa <> '#39#39' ' +
        'THEN '#39'2'#39
      #9#9'ELSE '#39'0'#39
      #9'END +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(cg_leitura_ant, 7) as varchar(7)) +'
      '  /* hist'#243'rico */'
      #9'isnull(('#9'select '
      #9#9#9'cast(CONVERT(char(6), hc_ref_historico, 112) as varchar(6))'
      
        #9#9#9' + cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_consumo,0), 6)'#9'as var' +
        'char(6))'
      
        #9#9#9' + cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_ocorrencia_leitura,0)' +
        ', 2) as varchar(2))'
      #9#9#9' + '#39'00'#39
      #9#9'from historico_consumo'
      #9#9'where hc_matricula = cg_matricula'
      '    and hc_grupo = cg_grupo'
      #9#9'and hc_sequencia = 1),'#39'0000000000000000'#39')  +'
      #9'isnull(('#9'select'
      #9#9#9'cast(CONVERT(char(6), hc_ref_historico, 112) as varchar(6))'
      
        #9#9#9' + cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_consumo,0), 6)'#9'as var' +
        'char(6))'
      
        #9#9#9' + cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_ocorrencia_leitura,0)' +
        ', 2) as varchar(2))'
      #9#9#9' + '#39'00'#39
      #9#9'from historico_consumo'
      #9#9'where hc_matricula = cg_matricula'
      '    and hc_grupo = cg_grupo'
      #9#9'and hc_sequencia = 2),'#39'0000000000000000'#39') +'
      #9'isnull(('#9'select'
      #9#9#9'cast(CONVERT(char(6), hc_ref_historico, 112) as varchar(6))'
      
        #9#9#9' + cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_consumo,0), 6)'#9'as var' +
        'char(6))'
      
        #9#9#9' + cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_ocorrencia_leitura,0)' +
        ', 2) as varchar(2))'
      #9#9#9' + '#39'00'#39
      #9#9'from historico_consumo'
      #9#9'where hc_matricula = cg_matricula'
      '    and hc_grupo = cg_grupo'
      #9#9'and hc_sequencia = 3),'#39'0000000000000000'#39')  +'
      #9'isnull(('#9'select'
      #9#9#9'cast(CONVERT(char(6), hc_ref_historico, 112) as varchar(6))'
      
        #9#9#9' + cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_consumo,0), 6)'#9'as var' +
        'char(6))'
      
        #9#9#9' + cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_ocorrencia_leitura,0)' +
        ', 2) as varchar(2))'
      #9#9#9' + '#39'00'#39
      #9#9'from historico_consumo'
      #9#9'where hc_matricula = cg_matricula'
      '    and hc_grupo = cg_grupo'
      #9#9'and hc_sequencia = 4),'#39'0000000000000000'#39')  +'
      #9'isnull(('#9'select'
      #9#9#9'cast(CONVERT(char(6), hc_ref_historico, 112) as varchar(6))'
      
        #9#9#9' + cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_consumo,0), 6)'#9'as var' +
        'char(6))'
      
        #9#9#9' + cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_ocorrencia_leitura,0)' +
        ', 2) as varchar(2))'
      #9#9#9' + '#39'00'#39
      #9#9'from historico_consumo'
      #9#9'where hc_matricula = cg_matricula'
      '    and hc_grupo = cg_grupo'
      #9#9'and hc_sequencia = 5),'#39'0000000000000000'#39')  +'
      #9'isnull(('#9'select'
      #9#9#9'cast(CONVERT(char(6), hc_ref_historico, 112) as varchar(6))'
      
        #9#9#9' + cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_consumo,0), 6)'#9'as var' +
        'char(6))'
      
        #9#9#9' + cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_ocorrencia_leitura,0)' +
        ', 2) as varchar(2))'
      #9#9#9' + '#39'00'#39
      #9#9'from historico_consumo'
      #9#9'where hc_matricula = cg_matricula'
      '    and hc_grupo = cg_grupo'
      #9#9'and hc_sequencia = 6),'#39'0000000000000000'#39')  +'
      ''
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(cg_consumo_medio, 6) as varchar(6)) ' +
        '+'
      #9'CASE cg_flag_troca'
      #9#9'WHEN '#39'S'#39' THEN '#39'5'#39
      #9#9'ELSE '#39'0'#39
      #9'END +'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(cg_consumo_anterior, 6) as varchar(6' +
        ')) +'
      #9#39'0'#39' + /*IMPLANTADO*/'
      #9'CASE'
      #9#9'WHEN cg_data_leit_ant is null THEN '#39'00000000'#39
      #9#9'ELSE'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, cg_data_leit_ant),4' +
        ') as varchar(4))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, cg_data_leit_ant),2) ' +
        'as varchar(2))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(dd, cg_data_leit_ant),2) ' +
        'as varchar(2))'
      #9'END +'
      #9#39'01'#39' + /*SITUACAO CONSUMO*/'
      #9'CASE'
      #9#9'WHEN cg_data_vencto is null THEN '#39'00000000'#39
      #9#9'ELSE'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, cg_data_vencto),4) ' +
        'as varchar(4))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, cg_data_vencto),2) as' +
        ' varchar(2))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(dd, cg_data_vencto),2) as' +
        ' varchar(2))'
      #9'END +'
      #9'CASE'
      #9#9'WHEN cg_codigo_banco is null THEN '#39'000'#39
      
        #9#9'ELSE cast(DBO.FC_COMPLETA_ZEROS(cg_codigo_banco,3) as varchar(' +
        '3))'
      #9'END +'
      #9'CASE'
      #9#9'WHEN cg_codigo_banco is null THEN '#39'0000'#39
      #9#9'ELSE cast(DBO.FC_COMPLETA_ZEROS(cg_agencia,4) as varchar(4))'
      #9'END +'
      #9#39'000000000000000'#39' + /*CONTA*/'
      '  '#39'000000'#39' + /*CONSUMO FIXO AGUA*/'
      '  CASE'
      
        '    WHEN (isnull(cg_numero_hd,'#39#39') = '#39#39' and (cg_natureza_ligacao ' +
        '= 2 or cg_natureza_ligacao = 3))  THEN '#39'000010'#39
      '    ELSE '#39'000000'#39
      '  END + /*CONSUMO FIXO ESGOTO*/'
      #9'CASE'
      #9#9'WHEN cg_data_instalacao_hd is null THEN '#39'00000000'#39
      #9#9'ELSE'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, cg_data_instalacao_' +
        'hd),4) as varchar(4))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, cg_data_instalacao_hd' +
        '),2) as varchar(2))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(dd, cg_data_instalacao_hd' +
        '),2) as varchar(2))'
      #9'END +'
      #9#39'1'#39' + /*TIPO RATEIO CONSUMO*/'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(de_limite_inicial,6) as varchar(6)) ' +
        '+'
      #9'cast(DBO.FC_COMPLETA_ZEROS(de_tipo_desconto,1) as varchar(1)) +'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(de_percentual, 3) as varchar(3)) + c' +
        'ast(DBO.FC_COMPLETA_ZEROS((de_percentual - cast(de_percentual as' +
        ' integer)) * 100, 2) as varchar(2)) +'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(de_percentual, 3) as varchar(3)) + c' +
        'ast(DBO.FC_COMPLETA_ZEROS((de_percentual - cast(de_percentual as' +
        ' integer)) * 100, 2) as varchar(2)) +'
      #9'CASE'
      
        #9#9'WHEN cg_mensagem1 <> '#39#39' THEN cast(DBO.FC_COMPLETA_BRANCOS(cg_m' +
        'ensagem1) as varchar(30))'
      #9#9'ELSE '#39'          '#39' + '#39'          '#39' + '#39'          '#39
      #9'END +'
      #9'CASE'
      
        #9#9'WHEN cg_mensagem2 <> '#39#39' THEN cast(DBO.FC_COMPLETA_BRANCOS(cg_m' +
        'ensagem2) as varchar(30))'
      #9#9'ELSE '#39'          '#39' + '#39'          '#39' + '#39'          '#39
      #9'END +'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(cg_qtde_registros_fraude, 2) as varc' +
        'har(2)) +'
      #9'cast(cg_flag_cortar as varchar(1)) +'
      #9'cast(cg_flag_calcula_conta as varchar(1)) +'
      #9'cast(cg_flag_emite_conta as varchar(1)) +'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(cg_dias_bloqueio_tarifa_ant, 3) as v' +
        'archar(3)) +'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(cg_dias_bloqueio_tarifa_atual, 3) as' +
        ' varchar(3)) +'
      #9'CASE'
      #9#9'WHEN cg_data_bloqueio is null THEN '#39'00000000'#39
      #9#9'ELSE'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, cg_data_bloqueio),4' +
        ') as varchar(4))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, cg_data_bloqueio),2) ' +
        'as varchar(2))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(dd, cg_data_bloqueio),2) ' +
        'as varchar(2))'
      #9'END +'
      '  '#39'0000000'#39' +  /*LEITURA BLOQUEIO*/'
      ' '#9'CASE isnull(cg_matricula_pai,0)'
      #9#9'WHEN 0 THEN'
      '   '#9#9'cast(DBO.FC_COMPLETA_ZEROS((select count (*)'
      #9#9#9#9#9#9#9#9#9#9'from carga C2'
      #9#9#9#9#9#9#9#9#9#9'where C2.cg_grupo = C.cg_grupo'
      #9#9#9#9#9#9#9#9#9#9'and C2.cg_rota = C.cg_rota'
      #9#9#9#9#9#9#9#9#9#9'and C2.cg_matricula = C.cg_matricula'
      #9#9#9#9#9#9#9#9#9#9'and C2.cg_virtual = '#39'N'#39
      #9#9#9#9#9#9#9#9#9#9'),3) as varchar(3))'
      #9#9'ELSE'
      '   '#9#9'cast(DBO.FC_COMPLETA_ZEROS((select count (*)'
      #9#9#9#9#9#9#9#9#9#9'from carga C2'
      #9#9#9#9#9#9#9#9#9#9'where C2.cg_grupo = C.cg_grupo'
      #9#9#9#9#9#9#9#9#9#9'and C2.cg_rota = C.cg_rota'
      #9#9#9#9#9#9#9#9#9#9'and C2.cg_matricula_pai = C.cg_matricula_pai'
      #9#9#9#9#9#9#9#9#9#9'and C2.cg_matricula_pai <> 0'
      #9#9#9#9#9#9#9#9#9#9'and C2.cg_virtual = '#39'N'#39
      #9#9#9#9#9#9#9#9#9#9'),3) as varchar(3))'
      #9'END +'
      #9'cast(DBO.FC_COMPLETA_ZEROS((select count (*)'
      #9#9#9#9'    from carga C2'
      #9#9#9'            where C2.cg_grupo = C.cg_grupo'
      ' '#9#9#9#9'    and C2.cg_rota = C.cg_rota'
      '   '#9'   '#9#9#9'    and C2.cg_matricula_pai = C.cg_matricula'
      
        '   '#9#9#9#9'    and C2.cg_matricula <> C2.cg_matricula_pai),3) as var' +
        'char(3)) '
      
        '+ cast(DBO.FC_COMPLETA_ZEROS(C.cg_qtde_debito_ant, 3) as varchar' +
        '(3)) '
      ''
      '+ cg_flag_calcula_imposto ) as linha'
      'from carga C'
      'left outer join descontos'
      'on de_grupo = cg_grupo'
      'and cg_desconto = de_codigo'
      'where'#9'cg_grupo = :grupo'
      #9'and cg_rota = :rota'
      'order by cg_sequencia, cg_matricula')
    Left = 96
    Top = 280
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'rota'
        ParamType = ptUnknown
      end>
    object qryRegistro2matricula: TIntegerField
      FieldName = 'matricula'
    end
    object qryRegistro2referencia: TDateTimeField
      FieldName = 'referencia'
    end
    object qryRegistro2grupo: TIntegerField
      FieldName = 'grupo'
    end
    object qryRegistro2sequencia: TIntegerField
      FieldName = 'sequencia'
    end
    object qryRegistro2emite_conta: TStringField
      FieldName = 'emite_conta'
      FixedChar = True
      Size = 1
    end
    object qryRegistro2busca_dados: TIntegerField
      FieldName = 'busca_dados'
    end
    object qryRegistro2linha: TMemoField
      FieldName = 'linha'
      BlobType = ftMemo
      Size = 1
    end
  end
  object qryRegistro4: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select distinct'
      'sr_matricula as matricula,'
      '('
      #9#39'4'#39' +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(sr_matricula,7) as varchar(7)) +'
      #9'/*servicos*/'
      #9'isnull(cast(DBO.FC_COMPLETA_BRANCOS('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_descricao, '#39#39')'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2 '
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 1)'
      #9#9#9#9#9#9#9#9#9#9') as varchar(20)),'#39'                    '#39') +'
      #9#39'00'#39' + /*PLANO*/'
      #9#39'00'#39' + /*PARCELA*/'
      #9'isnull(DBO.FC_FLOAT_TO_STR('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_valor,0)'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 1)'
      #9#9#9#9#9#9#9#9#9#9',4,2),'#39'000000'#39') +'
      #9'cast('
      #9#9#9'isnull((select isnull(S2.sr_ind_credito, '#39'N'#39')'
      #9#9#9'from servicos S2'
      #9#9#9'where S2.sr_matricula = S.sr_matricula'
      '      and S2.sr_grupo = S.sr_grupo'
      #9#9#9'and S2.sr_sequencia = 1),'#39'N'#39')'
      #9#9#9'as varchar(1)) +'
      #9'/*servicos*/'
      #9'isnull(cast(DBO.FC_COMPLETA_BRANCOS('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_descricao, '#39#39')'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 2)'
      #9#9#9#9#9#9#9#9#9#9') as varchar(20)),'#39'                    '#39') +'
      #9#39'00'#39' + /*PLANO*/'
      #9#39'00'#39' + /*PARCELA*/'
      #9'isnull(DBO.FC_FLOAT_TO_STR('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_valor,0)'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 2)'
      #9#9#9#9#9#9#9#9#9#9',4,2),'#39'000000'#39') +'
      #9'cast('
      #9#9#9'isnull((select isnull(S2.sr_ind_credito, '#39'N'#39')'
      #9#9#9'from servicos S2'
      #9#9#9'where S2.sr_matricula = S.sr_matricula'
      '      and S2.sr_grupo = S.sr_grupo'
      #9#9#9'and S2.sr_sequencia = 2),'#39'N'#39')'
      #9#9#9'as varchar(1)) +'
      #9'/*servicos*/'
      #9'isnull(cast(DBO.FC_COMPLETA_BRANCOS('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_descricao, '#39#39')'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 3)'
      #9#9#9#9#9#9#9#9#9#9') as varchar(20)),'#39'                    '#39') +'
      #9#39'00'#39' + /*PLANO*/'
      #9#39'00'#39' + /*PARCELA*/'
      #9'isnull(DBO.FC_FLOAT_TO_STR('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_valor,0)'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 3)'
      #9#9#9#9#9#9#9#9#9#9',4,2),'#39'000000'#39') +'
      #9'cast('
      #9#9#9'isnull((select isnull(S2.sr_ind_credito, '#39'N'#39')'
      #9#9#9'from servicos S2'
      #9#9#9'where S2.sr_matricula = S.sr_matricula'
      '      and S2.sr_grupo = S.sr_grupo'
      #9#9#9'and S2.sr_sequencia = 3),'#39'N'#39')'
      #9#9#9'as varchar(1)) +'
      #9'/*servicos*/'
      #9'isnull(cast(DBO.FC_COMPLETA_BRANCOS('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_descricao, '#39#39')'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 4)'
      #9#9#9#9#9#9#9#9#9#9') as varchar(20)),'#39'                    '#39') +'
      #9#39'00'#39' + /*PLANO*/'
      #9#39'00'#39' + /*PARCELA*/'
      #9'isnull(DBO.FC_FLOAT_TO_STR('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_valor,0)'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 4)'
      #9#9#9#9#9#9#9#9#9#9',4,2),'#39'000000'#39') +'
      #9'cast('
      #9#9#9'isnull((select isnull(S2.sr_ind_credito, '#39'N'#39')'
      #9#9#9'from servicos S2'
      #9#9#9'where S2.sr_matricula = S.sr_matricula'
      '      and S2.sr_grupo = S.sr_grupo'
      #9#9#9'and S2.sr_sequencia = 4),'#39'N'#39')'
      #9#9#9'as varchar(1)) +'
      #9'/*servicos*/'
      #9'isnull(cast(DBO.FC_COMPLETA_BRANCOS('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_descricao, '#39#39')'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 5)'
      #9#9#9#9#9#9#9#9#9#9') as varchar(20)),'#39'                    '#39') +'
      #9#39'00'#39' + /*PLANO*/'
      #9#39'00'#39' + /*PARCELA*/'
      #9'isnull(DBO.FC_FLOAT_TO_STR('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_valor,0)'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 5)'
      #9#9#9#9#9#9#9#9#9#9',4,2),'#39'000000'#39') +'
      #9'cast('
      #9#9#9'isnull((select isnull(S2.sr_ind_credito, '#39'N'#39')'
      #9#9#9'from servicos S2'
      #9#9#9'where S2.sr_matricula = S.sr_matricula'
      '      and S2.sr_grupo = S.sr_grupo'
      #9#9#9'and S2.sr_sequencia = 5),'#39'N'#39')'
      #9#9#9'as varchar(1)) +'
      #9'/*servicos*/'
      #9'isnull(cast(DBO.FC_COMPLETA_BRANCOS('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_descricao, '#39#39')'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 6)'
      #9#9#9#9#9#9#9#9#9#9') as varchar(20)),'#39'                    '#39') +'
      #9#39'00'#39' + /*PLANO*/'
      #9#39'00'#39' + /*PARCELA*/'
      #9'isnull(DBO.FC_FLOAT_TO_STR('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_valor,0)'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 6)'
      #9#9#9#9#9#9#9#9#9#9',4,2),'#39'000000'#39') +'
      #9'cast('
      #9#9#9'isnull((select isnull(S2.sr_ind_credito, '#39'N'#39')'
      #9#9#9'from servicos S2'
      #9#9#9'where S2.sr_matricula = S.sr_matricula'
      '      and S2.sr_grupo = S.sr_grupo'
      #9#9#9'and S2.sr_sequencia = 6),'#39'N'#39')'
      #9#9#9'as varchar(1)) +'
      #9'/*servicos*/'
      #9'isnull(cast(DBO.FC_COMPLETA_BRANCOS('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_descricao, '#39#39')'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 7)'
      #9#9#9#9#9#9#9#9#9#9') as varchar(20)),'#39'                    '#39') +'
      #9#39'00'#39' + /*PLANO*/'
      #9#39'00'#39' + /*PARCELA*/'
      #9'isnull(DBO.FC_FLOAT_TO_STR('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_valor,0)'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 7)'
      #9#9#9#9#9#9#9#9#9#9',4,2),'#39'000000'#39') +'
      #9'cast('
      #9#9#9'isnull((select isnull(S2.sr_ind_credito, '#39'N'#39')'
      #9#9#9'from servicos S2'
      #9#9#9'where S2.sr_matricula = S.sr_matricula'
      '      and S2.sr_grupo = S.sr_grupo'
      #9#9#9'and S2.sr_sequencia = 7),'#39'N'#39')'
      #9#9#9'as varchar(1)) +'
      #9'/*servicos*/'
      #9'isnull(cast(DBO.FC_COMPLETA_BRANCOS('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_descricao, '#39#39')'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 8)'
      #9#9#9#9#9#9#9#9#9#9') as varchar(20)),'#39'                    '#39') +'
      #9#39'00'#39' + /*PLANO*/'
      #9#39'00'#39' + /*PARCELA*/'
      #9'isnull(DBO.FC_FLOAT_TO_STR('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_valor,0)'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 8)'
      #9#9#9#9#9#9#9#9#9#9',4,2),'#39'000000'#39') +'
      #9'cast('
      #9#9#9'isnull((select isnull(S2.sr_ind_credito, '#39'N'#39')'
      #9#9#9'from servicos S2'
      #9#9#9'where S2.sr_matricula = S.sr_matricula'
      '      and S2.sr_grupo = S.sr_grupo'
      #9#9#9'and S2.sr_sequencia = 8),'#39'N'#39')'
      #9#9#9'as varchar(1)) +'
      #9'/*servicos*/'
      #9'isnull(cast(DBO.FC_COMPLETA_BRANCOS('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_descricao, '#39#39')'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 9)'
      #9#9#9#9#9#9#9#9#9#9') as varchar(20)),'#39'                    '#39') +'
      #9#39'00'#39' + /*PLANO*/'
      #9#39'00'#39' + /*PARCELA*/'
      #9'isnull(DBO.FC_FLOAT_TO_STR('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_valor,0)'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 9)'
      #9#9#9#9#9#9#9#9#9#9',4,2),'#39'000000'#39') +'
      #9'cast('
      #9#9#9'isnull((select isnull(S2.sr_ind_credito, '#39'N'#39')'
      #9#9#9'from servicos S2'
      #9#9#9'where S2.sr_matricula = S.sr_matricula'
      '      and S2.sr_grupo = S.sr_grupo'
      #9#9#9'and S2.sr_sequencia = 9),'#39'N'#39')'
      #9#9#9'as varchar(1)) +'
      #9'/*servicos*/'
      #9'isnull(cast(DBO.FC_COMPLETA_BRANCOS('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_descricao, '#39#39')'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 10)'
      #9#9#9#9#9#9#9#9#9#9') as varchar(20)),'#39'                    '#39') +'
      #9#39'00'#39' + /*PLANO*/'
      #9#39'00'#39' + /*PARCELA*/'
      #9'isnull(DBO.FC_FLOAT_TO_STR('
      #9#9#9#9#9#9#9#9#9#9'(select isnull(S2.sr_valor,0)'
      #9#9#9#9#9#9#9#9#9#9'from servicos S2'
      #9#9#9#9#9#9#9#9#9#9'where S2.sr_matricula = S.sr_matricula'
      '                    and S2.sr_grupo = S.sr_grupo'
      #9#9#9#9#9#9#9#9#9#9'and S2.sr_sequencia = 10)'
      #9#9#9#9#9#9#9#9#9#9',4,2),'#39'000000'#39') +'
      #9'cast('
      #9#9#9'isnull((select isnull(S2.sr_ind_credito, '#39'N'#39')'
      #9#9#9'from servicos S2'
      #9#9#9'where S2.sr_matricula = S.sr_matricula'
      '      and S2.sr_grupo = S.sr_grupo'
      #9#9#9'and S2.sr_sequencia = 10),'#39'N'#39')'
      #9#9#9'as varchar(1))'
      ') as linha'
      'from'
      #9'servicos S'
      'where sr_grupo = :grupo'
      'and sr_rota = :rota')
    Left = 368
    Top = 240
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'rota'
        ParamType = ptUnknown
      end>
    object qryRegistro4matricula: TIntegerField
      FieldName = 'matricula'
    end
    object qryRegistro4linha: TMemoField
      FieldName = 'linha'
      BlobType = ftMemo
      Size = 1
    end
  end
  object qryRegistroD: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'
      'sv_matricula as matricula,'
      '('
      #9#39'D'#39' +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(sv_matricula, 7) as varchar(7))+'
      #9'CASE '
      #9#9'WHEN sv_referencia_seg_via is null THEN '#39'00000000'#39
      #9#9'ELSE '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, sv_referencia_seg_v' +
        'ia),4) as varchar(4))+ '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, sv_referencia_seg_via' +
        '),2) as varchar(2))'
      #9'END +'
      #9'CASE '
      #9#9'WHEN sv_data_leitura is null THEN '#39'00000000'#39
      #9#9'ELSE '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, sv_data_leitura),4)' +
        ' as varchar(4))+ '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, sv_data_leitura),2) a' +
        's varchar(2))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(dd, sv_data_leitura),2) a' +
        's varchar(2))'
      #9'END +'
      #9'CASE '
      #9#9'WHEN sv_data_leitura_anterior is null THEN '#39'00000000'#39
      #9#9'ELSE '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, sv_data_leitura_ant' +
        'erior),4) as varchar(4))+ '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, sv_data_leitura_anter' +
        'ior),2) as varchar(2))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(dd, sv_data_leitura_anter' +
        'ior),2) as varchar(2))'
      #9'END +'
      #9'CASE '
      #9#9'WHEN sv_data_vencimento is null THEN '#39'00000000'#39
      #9#9'ELSE '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, sv_data_vencimento)' +
        ',4) as varchar(4))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, sv_data_vencimento),2' +
        ') as varchar(2))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(dd, sv_data_vencimento),2' +
        ') as varchar(2))'
      #9'END +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(sv_dias_consumo, 3) as varchar(3))+'
      #9'cast(DBO.FC_COMPLETA_ZEROS(sv_leitura_atual, 6) as varchar(6))+'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(sv_leitura_anterior, 6) as varchar(6' +
        '))+'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(sv_consumo_faturado, 6) as varchar(6' +
        '))+'
      #9'cast(DBO.FC_COMPLETA_ZEROS(sv_media, 6) as varchar(6))+'
      ''
      
        #9'cast( DBO.FC_COMPLETA_BRANCOS(isnull(cg_numero_hd,'#39#39')) as varch' +
        'ar(12)) +'
      ''
      #9'/*SERVICO*/'#9
      #9'CASE'
      #9#9'WHEN sv_valor_01 > 0 THEN'
      #9#9#9'cast(DBO.FC_COMPLETA_BRANCOS(sv_servico_01) as varchar(20))+'
      #9#9#9#39'00'#39' + /*PLANO*/'
      #9#9#9#39'00'#39' + /*PARCELA*/'
      #9#9#9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_01,7,2),'#39'000000000'#39') +'#9
      #9#9#9#39'N'#39'   /*CREDITO*/'
      #9#9'ELSE'
      #9#9#9'cast(DBO.FC_COMPLETA_BRANCOS(sv_servico_01) as varchar(20))+'
      #9#9#9#39'00'#39' + /*PLANO*/'
      #9#9#9#39'00'#39' + /*PARCELA*/'
      
        #9#9#9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_01 * (-1),7,2),'#39'000000000' +
        #39') +'#9
      #9#9#9#39'S'#39'   /*DEBITO*/'
      #9'END +'
      #9'/*SERVICO*/'#9
      #9'CASE'
      #9#9'WHEN sv_valor_02 > 0 THEN'
      #9#9#9'cast(DBO.FC_COMPLETA_BRANCOS(sv_servico_02) as varchar(20))+'
      #9#9#9#39'00'#39' + /*PLANO*/'
      #9#9#9#39'00'#39' + /*PARCELA*/'
      #9#9#9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_02,7,2),'#39'000000000'#39') +'#9
      #9#9#9#39'N'#39'   /*CREDITO*/'
      #9#9'ELSE'
      #9#9#9'cast(DBO.FC_COMPLETA_BRANCOS(sv_servico_02) as varchar(20))+'
      #9#9#9#39'00'#39' + /*PLANO*/'
      #9#9#9#39'00'#39' + /*PARCELA*/'
      
        #9#9#9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_02 * (-1),7,2),'#39'000000000' +
        #39') +'#9
      #9#9#9#39'S'#39'   /*DEBITO*/'
      #9'END +'
      ''
      #9'/*SERVICO*/'#9
      #9'CASE'
      #9#9'WHEN sv_valor_03 > 0 THEN'
      #9#9#9'cast(DBO.FC_COMPLETA_BRANCOS(sv_servico_03) as varchar(20))+'
      #9#9#9#39'00'#39' + /*PLANO*/'
      #9#9#9#39'00'#39' + /*PARCELA*/'
      #9#9#9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_03,7,2),'#39'000000000'#39') +'#9
      #9#9#9#39'N'#39'   /*CREDITO*/'
      #9#9'ELSE'
      #9#9#9'cast(DBO.FC_COMPLETA_BRANCOS(sv_servico_03) as varchar(20))+'
      #9#9#9#39'00'#39' + /*PLANO*/'
      #9#9#9#39'00'#39' + /*PARCELA*/'
      
        #9#9#9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_03 * (-1),7,2),'#39'000000000' +
        #39') +'#9
      #9#9#9#39'S'#39'   /*DEBITO*/'
      #9'END +'
      ''
      #9'/*SERVICO*/'#9
      #9'CASE'
      #9#9'WHEN sv_valor_04 > 0 THEN'
      #9#9#9'cast(DBO.FC_COMPLETA_BRANCOS(sv_servico_04) as varchar(20))+'
      #9#9#9#39'00'#39' + /*PLANO*/'
      #9#9#9#39'00'#39' + /*PARCELA*/'
      #9#9#9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_04,7,2),'#39'000000000'#39') +'#9
      #9#9#9#39'N'#39'   /*CREDITO*/'
      #9#9'ELSE'
      #9#9#9'cast(DBO.FC_COMPLETA_BRANCOS(sv_servico_04) as varchar(20))+'
      #9#9#9#39'00'#39' + /*PLANO*/'
      #9#9#9#39'00'#39' + /*PARCELA*/'
      
        #9#9#9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_04 * (-1),7,2),'#39'000000000' +
        #39') +'#9
      #9#9#9#39'S'#39'   /*DEBITO*/'
      #9'END +'
      ''
      #9'/*SERVICO*/'#9
      #9'CASE'
      #9#9'WHEN sv_valor_05 > 0 THEN'
      #9#9#9'cast(DBO.FC_COMPLETA_BRANCOS(sv_servico_05) as varchar(20))+'
      #9#9#9#39'00'#39' + /*PLANO*/'
      #9#9#9#39'00'#39' + /*PARCELA*/'
      #9#9#9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_05,7,2),'#39'000000000'#39') +'#9
      #9#9#9#39'N'#39'   /*CREDITO*/'
      #9#9'ELSE'
      #9#9#9'cast(DBO.FC_COMPLETA_BRANCOS(sv_servico_05) as varchar(20))+'
      #9#9#9#39'00'#39' + /*PLANO*/'
      #9#9#9#39'00'#39' + /*PARCELA*/'
      
        #9#9#9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_05 * (-1),7,2),'#39'000000000' +
        #39') +'#9
      #9#9#9#39'S'#39'   /*DEBITO*/'
      #9'END +'
      ''
      #9'/*SERVICO*/'#9
      #9'CASE'
      #9#9'WHEN sv_valor_06 > 0 THEN'
      #9#9#9'cast(DBO.FC_COMPLETA_BRANCOS(sv_servico_06) as varchar(20))+'
      #9#9#9#39'00'#39' + /*PLANO*/'
      #9#9#9#39'00'#39' + /*PARCELA*/'
      #9#9#9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_06,7,2),'#39'000000000'#39') +'#9
      #9#9#9#39'N'#39'   /*CREDITO*/'
      #9#9'ELSE'
      #9#9#9'cast(DBO.FC_COMPLETA_BRANCOS(sv_servico_06) as varchar(20))+'
      #9#9#9#39'00'#39' + /*PLANO*/'
      #9#9#9#39'00'#39' + /*PARCELA*/'
      
        #9#9#9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_06 * (-1),7,2),'#39'000000000' +
        #39') +'#9
      #9#9#9#39'S'#39'   /*DEBITO*/'
      #9'END +'
      ''
      #9'/*SERVICO*/'#9
      #9'CASE'
      #9#9'WHEN sv_valor_07 > 0 THEN'
      #9#9#9'cast(DBO.FC_COMPLETA_BRANCOS(sv_servico_07) as varchar(20))+'
      #9#9#9#39'00'#39' + /*PLANO*/'
      #9#9#9#39'00'#39' + /*PARCELA*/'
      #9#9#9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_07,7,2),'#39'000000000'#39') +'#9
      #9#9#9#39'N'#39'   /*CREDITO*/'
      #9#9'ELSE'
      #9#9#9'cast(DBO.FC_COMPLETA_BRANCOS(sv_servico_07) as varchar(20))+'
      #9#9#9#39'00'#39' + /*PLANO*/'
      #9#9#9#39'00'#39' + /*PARCELA*/'
      
        #9#9#9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_07 * (-1),7,2),'#39'000000000' +
        #39') +'#9
      #9#9#9#39'S'#39'   /*DEBITO*/'
      #9'END +'
      ''
      #9'/*SERVICO*/'#9
      #9'CASE'
      #9#9'WHEN sv_valor_08 > 0 THEN'
      #9#9#9'cast(DBO.FC_COMPLETA_BRANCOS(sv_servico_08) as varchar(20))+'
      #9#9#9#39'00'#39' + /*PLANO*/'
      #9#9#9#39'00'#39' + /*PARCELA*/'
      #9#9#9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_08,7,2),'#39'000000000'#39') +'#9
      #9#9#9#39'N'#39'   /*CREDITO*/'
      #9#9'ELSE'
      #9#9#9'cast(DBO.FC_COMPLETA_BRANCOS(sv_servico_08) as varchar(20))+'
      #9#9#9#39'00'#39' + /*PLANO*/'
      #9#9#9#39'00'#39' + /*PARCELA*/'
      
        #9#9#9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_08 * (-1),7,2),'#39'000000000' +
        #39') +'#9
      #9#9#9#39'S'#39'   /*DEBITO*/'
      #9'END +'
      ''
      #9'/*SERVICO*/'#9
      #9'CASE'
      #9#9'WHEN sv_valor_09 > 0 THEN'
      #9#9#9'cast(DBO.FC_COMPLETA_BRANCOS(sv_servico_09) as varchar(20))+'
      #9#9#9#39'00'#39' + /*PLANO*/'
      #9#9#9#39'00'#39' + /*PARCELA*/'
      #9#9#9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_09,7,2),'#39'000000000'#39') +'#9
      #9#9#9#39'N'#39'   /*CREDITO*/'
      #9#9'ELSE'
      #9#9#9'cast(DBO.FC_COMPLETA_BRANCOS(sv_servico_09) as varchar(20))+'
      #9#9#9#39'00'#39' + /*PLANO*/'
      #9#9#9#39'00'#39' + /*PARCELA*/'
      
        #9#9#9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_09 * (-1),7,2),'#39'000000000' +
        #39') +'#9
      #9#9#9#39'S'#39'   /*DEBITO*/'
      #9'END +'
      ''
      #9'/*SERVICO*/'#9
      #9#39'                    '#39'+'
      #9#39'00'#39' + /*PLANO*/'
      #9#39'00'#39' + /*PARCELA*/'
      #9#39'000000000'#39' +'#9
      #9#39'N'#39' +  /*CREDITO*/'
      ''
      #9'/*HISTORICO*/'
      #9'CASE '
      #9#9'WHEN sv_ref_cons_1 is null THEN '#39'00000000'#39
      #9#9'ELSE '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, sv_ref_cons_1),4) a' +
        's varchar(4))+ '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, sv_ref_cons_1),2) as ' +
        'varchar(2))'
      #9'END +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(sv_cons_1, 6) as varchar(6))+'
      #9'/*HISTORICO*/'
      #9'CASE '
      #9#9'WHEN sv_ref_cons_2 is null THEN '#39'00000000'#39
      #9#9'ELSE '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, sv_ref_cons_2),4) a' +
        's varchar(4))+ '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, sv_ref_cons_2),2) as ' +
        'varchar(2))'
      #9'END +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(sv_cons_2, 6) as varchar(6))+'
      #9'/*HISTORICO*/'
      #9'CASE '
      #9#9'WHEN sv_ref_cons_3 is null THEN '#39'00000000'#39
      #9#9'ELSE '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, sv_ref_cons_3),4) a' +
        's varchar(4))+ '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, sv_ref_cons_3),2) as ' +
        'varchar(2))'
      #9'END +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(sv_cons_3, 6) as varchar(6))+'
      #9'/*HISTORICO*/'
      #9'CASE '
      #9#9'WHEN sv_ref_cons_1 is null THEN '#39'00000000'#39
      #9#9'ELSE '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, sv_ref_cons_4),4) a' +
        's varchar(4))+ '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, sv_ref_cons_4),2) as ' +
        'varchar(2))'
      #9'END +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(sv_cons_4, 6) as varchar(6))+'
      #9'/*HISTORICO*/'
      #9'CASE '
      #9#9'WHEN sv_ref_cons_1 is null THEN '#39'00000000'#39
      #9#9'ELSE '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, sv_ref_cons_5),4) a' +
        's varchar(4))+ '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, sv_ref_cons_5),2) as ' +
        'varchar(2))'
      #9'END +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(sv_cons_5, 6) as varchar(6))+'
      #9'/*HISTORICO*/'
      #9'CASE '
      #9#9'WHEN sv_ref_cons_1 is null THEN '#39'00000000'#39
      #9#9'ELSE '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, sv_ref_cons_6),4) a' +
        's varchar(4))+ '
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, sv_ref_cons_6),2) as ' +
        'varchar(2))'
      #9'END +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(sv_cons_6, 6) as varchar(6)) +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(sv_ocorrencia, 2) as varchar(2))+'
      #9'cast(DBO.FC_COMPLETA_BRANCOS(sv_codigo_barras) as varchar(44))+'
      
        #9'isnull(DBO.FC_FLOAT_TO_STR(sv_valor_total,11,2),'#39'0000000000000'#39 +
        ')'
      ')'
      'as linha'
      'from'
      #9'segundas_vias, carga'
      'where sv_grupo = :grupo'
      'and sv_rota = :rota'
      'and sv_grupo = cg_grupo'
      'and sv_rota = cg_rota'
      'and sv_matricula = cg_matricula'
      'order by sv_matricula, sv_referencia_seg_via')
    Left = 368
    Top = 344
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
        Size = 4
      end
      item
        DataType = ftInteger
        Name = 'rota'
        ParamType = ptUnknown
      end>
    object qryRegistroDmatricula: TIntegerField
      FieldName = 'matricula'
    end
    object qryRegistroDlinha: TMemoField
      FieldName = 'linha'
      BlobType = ftMemo
      Size = 1
    end
  end
  object qryRegistro5: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'
      'db_matricula as matricula,'
      '('
      #9#39'5'#39' +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(db_matricula, 7) as varchar(7))+'
      #9'/*DATA DE EMISS'#194'O*/'
      #9'convert(char(8), getdate(), 112) +'
      #9'/*DATA DE VENCIMENTO*/'
      #9'convert(char(8), db_data_vencimento, 112) +'
      #9'CASE'
      #9#9'WHEN db_tipo = '#39'A'#39' THEN '#39'1'#39
      #9#9'WHEN db_tipo = '#39'N'#39' THEN '#39'3'#39
      #9#9'ELSE '#39'1'#39
      #9'END +'
      #9'CASE'
      #9#9'WHEN db_codigo_barras = '#39#39' THEN '#39'0'#39
      #9#9'ELSE '#39'1'#39
      #9'END +'
      #9'/*QUANDO HOUVER MAIS QUE 6 DEBITOS*/'
      #9'CASE WHEN db_qtde_debitos > 6  THEN'
      
        #9#9#9'CONVERT(CHAR(37), '#39'TOTALIZANDO '#39' + DBO.FC_COMPLETA_ZEROS(db_q' +
        'tde_debitos, 3) + '#39' D'#201'BITOS'#39' )+'
      
        #9#9#9'isnull('#9'DBO.FC_FLOAT_TO_STR(db_valor_total, 7, 2), '#39'000000000' +
        #39') +'
      #9#9#9'CONVERT(CHAR(37), '#39#39') + '#39'000000000'#39' +'
      #9#9#9'CONVERT(CHAR(37), '#39#39') + '#39'000000000'#39' +'
      #9#9#9'CONVERT(CHAR(37), '#39#39') + '#39'000000000'#39' +'
      #9#9#9'CONVERT(CHAR(37), '#39#39') + '#39'000000000'#39' +'
      #9#9#9'CONVERT(CHAR(37), '#39#39') + '#39'000000000'#39
      ''
      #9'ELSE'
      #9'CASE'
      
        #9#9'WHEN (select di_referencia_debito from debitos_itens where di_' +
        'matricula = db_matricula and di_sequencia = 1 and di_grupo = db_' +
        'grupo) is not null'
      #9#9#9'THEN cast( DBO.FC_COMPLETA_BRANCOS('
      #9#9#9#9#9#9#39'REFERENCIA '#39' +'
      #9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm,'
      
        #9#9#9#9#9#9#9'(select di_referencia_debito from debitos_itens where di_' +
        'matricula = db_matricula and di_sequencia = 1 and di_grupo = db_' +
        'grupo)'
      #9#9#9#9#9#9#9'),2) as varchar(2))+ '#39'/'#39' +'
      #9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy,'
      
        #9#9#9#9#9#9#9'(select di_referencia_debito from debitos_itens where di_' +
        'matricula = db_matricula and di_sequencia = 1 and di_grupo = db_' +
        'grupo)'
      #9#9#9#9#9#9#9'),4) as varchar(4))'
      #9#9#9#9#9' ) as VARCHAR(37)) +'
      #9#9#9#9'isnull('
      #9#9#9#9#9'DBO.FC_FLOAT_TO_STR('
      
        #9#9#9#9#9'(select di_valor from debitos_itens where di_matricula = db' +
        '_matricula and di_sequencia = 1 and di_grupo = db_grupo),'
      #9#9#9#9#9'7,2),'
      #9#9#9#9#9#39'000000000'#39')'
      #9#9'ELSE '
      
        #9#9#9'cast( DBO.FC_COMPLETA_BRANCOS('#39'TOTAL DE '#39' + cast(db_qtde_debi' +
        'tos as VARCHAR(7)) + '#39' DEBITOS EM ABERTO'#39') as VARCHAR(37)) +'
      #9#9#9'DBO.FC_FLOAT_TO_STR(db_valor_total,7,2)'
      #9'END +'
      #9'CASE'
      
        #9#9'WHEN (select di_referencia_debito from debitos_itens where di_' +
        'matricula = db_matricula and di_sequencia = 2 and di_grupo = db_' +
        'grupo) is not null'
      #9#9#9'THEN cast( DBO.FC_COMPLETA_BRANCOS('
      #9#9#9#9#9#9#39'REFERENCIA '#39' +'
      #9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm,'
      
        #9#9#9#9#9#9#9'(select di_referencia_debito from debitos_itens where di_' +
        'matricula = db_matricula and di_sequencia = 2 and di_grupo = db_' +
        'grupo)'
      #9#9#9#9#9#9#9'),2) as varchar(2))+ '#39'/'#39' +'
      #9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy,'
      
        #9#9#9#9#9#9#9'(select di_referencia_debito from debitos_itens where di_' +
        'matricula = db_matricula and di_sequencia = 2 and di_grupo = db_' +
        'grupo)'
      #9#9#9#9#9#9#9'),4) as varchar(4))'
      #9#9#9#9#9' ) as VARCHAR(37))'
      #9#9#9'ELSE '#39'                                     '#39
      #9'END +'
      ''
      #9'isnull('
      #9#9'DBO.FC_FLOAT_TO_STR('
      
        #9#9#9'(select di_valor from debitos_itens where di_matricula = db_m' +
        'atricula and di_sequencia = 2 and di_grupo = db_grupo),'
      #9#9'7,2),'
      #9#39'000000000'#39') +'
      ''
      #9'CASE'
      
        #9#9'WHEN (select di_referencia_debito from debitos_itens where di_' +
        'matricula = db_matricula and di_sequencia = 3 and di_grupo = db_' +
        'grupo) is not null'
      #9#9#9'THEN cast( DBO.FC_COMPLETA_BRANCOS('
      #9#9#9#9#9#9#39'REFERENCIA '#39' +'
      #9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm,'
      
        #9#9#9#9#9#9#9'(select di_referencia_debito from debitos_itens where di_' +
        'matricula = db_matricula and di_sequencia = 3 and di_grupo = db_' +
        'grupo)'
      #9#9#9#9#9#9#9'),2) as varchar(2))+ '#39'/'#39' +'
      #9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy,'
      
        #9#9#9#9#9#9#9'(select di_referencia_debito from debitos_itens where di_' +
        'matricula = db_matricula and di_sequencia = 3 and di_grupo = db_' +
        'grupo)'
      #9#9#9#9#9#9#9'),4) as varchar(4))'
      #9#9#9#9#9' ) as VARCHAR(37))'
      #9#9#9'ELSE '#39'                                     '#39
      #9'END +'
      ''
      #9'isnull('
      #9#9'DBO.FC_FLOAT_TO_STR('
      
        #9#9#9'(select di_valor from debitos_itens where di_matricula = db_m' +
        'atricula and di_sequencia = 3 and di_grupo = db_grupo),'
      #9#9'7,2),'
      #9#39'000000000'#39') +'
      ''
      #9'CASE'
      
        #9#9'WHEN (select di_referencia_debito from debitos_itens where di_' +
        'matricula = db_matricula and di_sequencia = 4 and di_grupo = db_' +
        'grupo) is not null'
      #9#9#9'THEN cast( DBO.FC_COMPLETA_BRANCOS('
      #9#9#9#9#9#9#39'REFERENCIA '#39' +'
      #9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm,'
      
        #9#9#9#9#9#9#9'(select di_referencia_debito from debitos_itens where di_' +
        'matricula = db_matricula and di_sequencia = 4 and di_grupo = db_' +
        'grupo)'
      #9#9#9#9#9#9#9'),2) as varchar(2))+ '#39'/'#39' +'
      #9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy,'
      
        #9#9#9#9#9#9#9'(select di_referencia_debito from debitos_itens where di_' +
        'matricula = db_matricula and di_sequencia = 4 and di_grupo = db_' +
        'grupo)'
      #9#9#9#9#9#9#9'),4) as varchar(4))'
      #9#9#9#9#9' ) as VARCHAR(37))'
      #9#9#9'ELSE '#39'                                     '#39
      #9'END +'
      ''
      #9'isnull('
      #9#9'DBO.FC_FLOAT_TO_STR('
      
        #9#9#9'(select di_valor from debitos_itens where di_matricula = db_m' +
        'atricula and di_sequencia = 4 and di_grupo = db_grupo),'
      #9#9'7,2),'
      #9#39'000000000'#39') +'#9
      ''
      #9'CASE '
      
        #9#9'WHEN (select di_referencia_debito from debitos_itens where di_' +
        'matricula = db_matricula and di_sequencia = 5 and di_grupo = db_' +
        'grupo) is not null'
      #9#9#9'THEN cast( DBO.FC_COMPLETA_BRANCOS('
      #9#9#9#9#9#9#39'REFERENCIA '#39' + '
      #9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm,'
      
        #9#9#9#9#9#9#9'(select di_referencia_debito from debitos_itens where di_' +
        'matricula = db_matricula and di_sequencia = 5 and di_grupo = db_' +
        'grupo)'
      #9#9#9#9#9#9#9'),2) as varchar(2))+ '#39'/'#39' +'
      #9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy,'
      
        #9#9#9#9#9#9#9'(select di_referencia_debito from debitos_itens where di_' +
        'matricula = db_matricula and di_sequencia = 5 and di_grupo = db_' +
        'grupo)'
      #9#9#9#9#9#9#9'),4) as varchar(4)) '
      #9#9#9#9#9' ) as VARCHAR(37))'
      #9#9#9'ELSE '#39'                                     '#39
      #9'END +'
      ''
      #9'isnull('
      #9#9'DBO.FC_FLOAT_TO_STR('
      
        #9#9#9'(select di_valor from debitos_itens where di_matricula = db_m' +
        'atricula and di_sequencia = 5 and di_grupo = db_grupo),'
      #9#9'7,2),'
      #9#39'000000000'#39') +'#9
      ''
      #9'CASE '
      
        #9#9'WHEN (select di_referencia_debito from debitos_itens where di_' +
        'matricula = db_matricula and di_sequencia = 6 and di_grupo = db_' +
        'grupo) is not null'
      #9#9#9'THEN cast( DBO.FC_COMPLETA_BRANCOS('
      #9#9#9#9#9#9#9#39'OUTRAS REFER'#202'NCIAS'#39
      #9#9#9#9#9' ) as VARCHAR(37))'
      #9#9#9'ELSE '#39'                                     '#39
      #9'END +'
      ''
      #9'isnull('
      #9#9'DBO.FC_FLOAT_TO_STR('
      
        #9#9#9'(select di_valor from debitos_itens where di_matricula = db_m' +
        'atricula and di_sequencia = 6 and di_grupo = db_grupo),'
      #9#9'7,2),'
      #9#39'000000000'#39') '
      #9'END+'
      ''
      
        '  cast( DBO.FC_COMPLETA_BRANCOS(db_codigo_barras) as varchar(44)' +
        ')'
      ')'
      'as linha'
      ''
      'FROM'#9'debitos'
      'where db_grupo = :grupo'
      'and db_rota = :rota'
      ''
      '')
    Left = 368
    Top = 288
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'rota'
        ParamType = ptUnknown
      end>
    object qryRegistro5matricula: TIntegerField
      FieldName = 'matricula'
    end
    object qryRegistro5linha: TMemoField
      FieldName = 'linha'
      BlobType = ftMemo
      Size = 1
    end
  end
  object qryRegistro7: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'
      '('
      #9#39'7'#39' +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(oc_codigo, 2) as varchar(2))+'
      #9'cast(DBO.FC_COMPLETA_BRANCOS(oc_descricao) as varchar(30))+'
      #9#39'A'#39' + /*GRUPO ANORMALIDADE*/'
      #9'CASE WHEN oc_calculo = 6 THEN '#39'00'#39' /*real com leitura*/'
      #9'     ELSE'
      #9#9'CASE'
      #9#9#9'WHEN oc_acesso = 1 THEN '#39'4'#39'  /*com ou sem leitura*/'
      #9#9#9'WHEN oc_acesso = 2 THEN '#39'2'#39'  /*sem leitura*/'
      #9#9#9'WHEN oc_acesso = 3 THEN '#39'0'#39'  /*com leitura*/'
      #9#9#9'ELSE '#39'4'#39
      #9#9'END +'
      #9#9'CASE'
      #9#9#9'/*2'#9'Pela M'#233'dia*/'
      #9#9#9'/*7'#9'Pela M'#233'dia, se N'#227'o Houver Leitura*/'
      #9#9#9'/*8'#9'Pelo M'#237'nimo, se N'#227'o Houver Leitura*/'
      #9#9#9'WHEN oc_calculo = 2 THEN '#39'1'#39' /*m'#233'dia*/'
      #9#9#9'WHEN oc_acesso = 1 and oc_calculo = 7 THEN '#39'8'#39
      #9#9#9'WHEN oc_acesso = 1 and oc_calculo = 8 THEN '#39'9'#39
      #9#9#9'WHEN oc_acesso = 2 and oc_calculo = 7 THEN '#39'1'#39
      #9#9#9'WHEN oc_acesso = 2 and oc_calculo = 8 THEN '#39'2'#39
      #9#9#9'WHEN oc_acesso = 3 and oc_calculo = 7 THEN '#39'0'#39
      #9#9#9'WHEN oc_acesso = 3 and oc_calculo = 8 THEN '#39'0'#39
      #9#9#9'ELSE '#39'1'#39
      #9#9'END '
      #9'END +'
      #9'isnull(oc_mensagem,0)'
      ')'
      'as linha'
      ''
      'from'#9'ocorrencias'
      'where '#9'oc_grupo = :grupo'
      'order by'#9'1'
      '')
    Left = 32
    Top = 304
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
    object qryRegistro7linha: TStringField
      FieldName = 'linha'
      Size = 37
    end
  end
  object qryRegistro1: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'
      '  ( select count(*)'
      #9#9#9'from carga'
      #9#9#9'where cg_grupo = rt_grupo'
      #9#9#9'and cg_rota = rt_rota'
      #9') as total,'
      '('
      #9#39'1'#39' +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(rt_grupo, 2) as varchar(2)) +'
      #9'CASE'
      #9#9'WHEN rt_referencia is null THEN '#39'00000000'#39
      #9#9'ELSE'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, rt_referencia),4) a' +
        's varchar(4))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, rt_referencia),2) as ' +
        'varchar(2))'
      #9'END +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(rt_rota, 3) as varchar(3)) +'
      #9'CASE'
      #9#9'WHEN rt_data_recepcao is null THEN '#39'00000000'#39
      #9#9'ELSE'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, rt_data_recepcao),4' +
        ') as varchar(4))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, rt_data_recepcao),2) ' +
        'as varchar(2))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(dd, rt_data_recepcao),2) ' +
        'as varchar(2))'
      #9'END +'
      #9'CASE'
      #9#9'WHEN rt_leitura_prev is null THEN '#39'00000000'#39
      #9#9'ELSE'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, rt_leitura_prev),4)' +
        ' as varchar(4))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, rt_leitura_prev),2) a' +
        's varchar(2))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(dd, rt_leitura_prev),2) a' +
        's varchar(2))'
      #9'END +'
      #9'CASE'
      #9#9'WHEN rt_data_prox_leitura is null THEN '#39'00000000'#39
      #9#9'ELSE'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, rt_data_prox_leitur' +
        'a),4) as varchar(4))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, rt_data_prox_leitura)' +
        ',2) as varchar(2))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(dd, rt_data_prox_leitura)' +
        ',2) as varchar(2))'
      #9'END +'
      #9#39'826'#39' + /*NATUREZA*/'
      #9#39'0122'#39' + /*CODIGO DA EMPRESA*/'
      #9'cast(DBO.FC_COMPLETA_ZEROS('
      #9#9#9#9#9#9'( select count(*)'
      #9#9#9#9#9#9'from carga'
      #9#9#9#9#9#9'where cg_grupo = rt_grupo'
      #9#9#9#9#9#9'and cg_rota = rt_rota'
      #9#9#9#9#9#9')'
      #9#9', 4) as varchar(4)) +'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(0,20) as char(20)) + /*VERSAO APLICA' +
        'TIVO*/'
      #9'cast(:Marca as char(1)) + /*MARCA SEGURAN'#199'A*/'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(:Versao,6) as char(6)) + /*VERSAO MC' +
        'P*/'
      
        #9'cast(dbo.fc_busca_senha_coleta(getdate()) as char(10)) /* SENHA' +
        ' */'
      ') as linha'
      'from '#9'roteiros'
      'where'#9'rt_grupo = :grupo'
      'and '#9'rt_rota = :rota')
    Left = 32
    Top = 8
    ParamData = <
      item
        DataType = ftString
        Name = 'Marca'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'Versao'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'rota'
        ParamType = ptUnknown
      end>
    object qryRegistro1total: TIntegerField
      FieldName = 'total'
    end
    object qryRegistro1linha: TStringField
      FieldName = 'linha'
      Size = 86
    end
  end
  object qryRegistro9: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select TOP 1'
      '('
      #9#39'9'#39' +'
      #9'cast(DBO.FC_COMPLETA_BRANCOS(mg_descricao1) as varchar(60)) +'
      #9'cast(DBO.FC_COMPLETA_BRANCOS(mg_descricao2) as varchar(60)) +'
      #9'cast(DBO.FC_COMPLETA_BRANCOS(mg_descricao3) as varchar(60))'
      ') as linha'
      'from mensagens M'
      'where mg_data_inicial ='
      '    (select MAX(mg_data_inicial)'
      '      from mensagens M2'
      '      where M2.mg_grupo = M.mg_grupo)'
      #9'and mg_grupo = :grupo')
    Left = 32
    Top = 352
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
    object qryRegistro9linha: TStringField
      FieldName = 'linha'
      Size = 181
    end
  end
  object qryGeral: TQuery
    DatabaseName = 'dbMain'
    Left = 176
    Top = 8
  end
  object qryRegistroL: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'
      '('#9#39'L'#39'+'
      #9'cast(DBO.FC_COMPLETA_ZEROS(ag_codigo,3) as varchar(3)) +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(isnull(ag_senha,0),4) as varchar(4))'
      ') as linha'
      'from agentes'
      'where ag_grupo = :grupo'
      'order by 1')
    Left = 32
    Top = 152
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end>
    object qryRegistroLlinha: TStringField
      FieldName = 'linha'
      Size = 8
    end
  end
  object DSRegistro2: TDataSource
    OnDataChange = DSRegistro2DataChange
    Left = 264
    Top = 280
  end
  object qryRegistroR: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select distinct'
      '('#9#39'R'#39'+'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(cg_cod_logradouro, 4) as varchar(4))' +
        ' + '
      #9'cast(DBO.FC_COMPLETA_BRANCOS(cg_endereco) as varchar(48))'
      ') as linha'
      'from '#9'carga'
      'where '#9'cg_grupo = :grupo'
      'and '#9'cg_rota = :rota'
      'order by 1')
    Left = 32
    Top = 104
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'rota'
        ParamType = ptUnknown
      end>
    object qryRegistroRlinha: TStringField
      FieldName = 'linha'
      Size = 53
    end
  end
  object qryRegistro2Ant: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'
      '  cg_matricula as matricula,'
      '  cg_referencia as referencia,'
      '  cg_grupo as grupo,'
      '  cg_sequencia as sequencia,'
      '  cg_flag_emite_conta as emite_conta,'
      
        '  case '#9'when (cg_ident_consumidor in (2, 9)) and (cg_matricula  ' +
        '= cg_matricula_pai) then 0'
      
        #9'when (cg_ident_consumidor in (3, 8)) and (cg_matricula <> cg_ma' +
        'tricula_pai) then 0'
      '  else 1'
      '  end as busca_dados,'
      '('
      #9#39'2'#39' +'
      
        '  '#9'cast(DBO.FC_COMPLETA_ZEROS(cg_cod_logradouro, 4) as varchar(4' +
        ')) +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(cg_num_imovel, 5) as varchar(5)) +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(cg_matricula, 7) as varchar(7))+'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(isnull(cg_matricula_pai,0), 7) as va' +
        'rchar(7))+'
      #9'cast(DBO.FC_COMPLETA_BRANCOS(cg_cachorro) as varchar(1))+'
      
        #9'cast(DBO.FC_COMPLETA_BRANCOS(cg_entrega_alternativa) as varchar' +
        '(60))+'
      #9'cast(DBO.FC_COMPLETA_BRANCOS(cg_nome) as varchar(35))+'
      
        #9'cast(DBO.FC_COMPLETA_BRANCOS(isnull(cg_numero_hd,'#39'           '#39')' +
        ') as varchar(11))+'
      
        #9'cast(DBO.FC_COMPLETA_BRANCOS(isnull(cg_capacidade_hidrometro,'#39#39 +
        ')) as varchar(1))+'
      '  CASE'
      '    WHEN cg_virtual = '#39'S'#39' THEN '#39'1'#39
      '    WHEN cg_virtual = '#39'N'#39' THEN '#39'0'#39
      '    ELSE '#39'0'#39
      '  END +'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(isnull(cg_ident_consumidor,0), 2) as' +
        ' varchar(2))+'
      #9'CASE cg_categoria'
      #9#9'WHEN 7 THEN'
      #9#9#9#39'07'#39' +  /*GRANDES CONSUMIDORES*/'
      #9#9#9'CASE cg_natureza_ligacao'
      #9#9#9#9'WHEN 1 THEN /*AGUA*/'
      
        #9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_res + cg_economia_co' +
        'm + cg_economia_ind + cg_economia_pub + cg_economia_soc, 3) as v' +
        'archar(3))'
      #9#9#9#9#9'+ '#39'000'#39
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA2*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA3*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA4*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA5*/'
      #9#9#9#9'WHEN 2 THEN /*AMBOS*/'
      
        #9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_res + cg_economia_co' +
        'm + cg_economia_ind + cg_economia_pub + cg_economia_soc, 3) as v' +
        'archar(3))'
      
        #9#9#9#9#9'+ cast(DBO.FC_COMPLETA_ZEROS(cg_economia_res + cg_economia_' +
        'com + cg_economia_ind + cg_economia_pub + cg_economia_soc, 3) as' +
        ' varchar(3))'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA2*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA3*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA4*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA5*/'
      #9#9#9#9'WHEN 3 THEN  /*ESGOTO*/'
      #9#9#9#9#9#39'000'#39
      
        #9#9#9#9#9'+ cast(DBO.FC_COMPLETA_ZEROS(cg_economia_res + cg_economia_' +
        'com + cg_economia_ind + cg_economia_pub + cg_economia_soc, 3) as' +
        ' varchar(3))'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA2*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA3*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA4*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA5*/'
      
        #9#9#9#9'ELSE '#39'00000000'#39' + '#39'00000000'#39' + '#39'00000000'#39' + '#39'00000000'#39' + '#39'00' +
        '000000'#39
      #9#9#9#9'END'
      #9#9'WHEN 8 THEN'
      #9#9#9#39'08'#39' + /*ENTIDADES ASSISTENCIAIS*/  '
      #9#9#9'CASE cg_natureza_ligacao'
      #9#9#9#9'WHEN 1 THEN /*AGUA*/'
      
        #9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_ea, 3) as varchar(3)' +
        ')'
      #9#9#9#9#9'+ '#39'000'#39
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA2*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA3*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA4*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA5*/'
      #9#9#9#9'WHEN 2 THEN  /*AMBOS*/'
      
        #9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_ea, 3) as varchar(3)' +
        ')'
      
        #9#9#9#9#9'+ cast(DBO.FC_COMPLETA_ZEROS(cg_economia_ea, 3) as varchar(' +
        '3))'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA2*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA3*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA4*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA5*/'
      #9#9#9#9'WHEN 3 THEN /*ESGOTO*/'
      #9#9#9#9#9#39'000'#39
      
        #9#9#9#9#9'+ cast(DBO.FC_COMPLETA_ZEROS(cg_economia_ea, 3) as varchar(' +
        '3))'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA2*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA3*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA4*/'
      #9#9#9#9#9'+ '#39'00000000'#39' /*CATEGORIA5*/'
      
        #9#9#9#9'ELSE '#39'00000000'#39' + '#39'00000000'#39' + '#39'00000000'#39' + '#39'00000000'#39' + '#39'00' +
        '000000'#39
      #9#9#9#9'END'
      #9#9'ELSE '
      #9#9#9'CASE cg_natureza_ligacao'
      #9#9#9#9'WHEN 1 THEN /*AGUA*/'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_res <> 0 THEN'
      #9#9#9#9#9#9#9#39'01'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_res,3) as varchar(' +
        '3)) +'
      #9#9#9#9#9#9#9#39'000'#39
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_com <> 0 THEN'
      #9#9#9#9#9#9#9#39'02'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_com,3) as varchar(' +
        '3)) +'
      #9#9#9#9#9#9#9#39'000'#39
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_ind <> 0 THEN'
      #9#9#9#9#9#9#9#39'03'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_ind,3) as varchar(' +
        '3)) +'
      #9#9#9#9#9#9#9#39'000'#39
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_pub <> 0 THEN'
      #9#9#9#9#9#9#9#39'04'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_pub,3) as varchar(' +
        '3)) +'
      #9#9#9#9#9#9#9#39'000'#39
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_soc <> 0 THEN'
      #9#9#9#9#9#9#9#39'06'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_soc,3) as varchar(' +
        '3)) +'
      #9#9#9#9#9#9#9#39'000'#39
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END'
      #9#9#9#9'WHEN 2 THEN  /*AMBOS*/'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_res <> 0 THEN'
      #9#9#9#9#9#9#9#39'01'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_res,3) as varchar(' +
        '3)) +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_res,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_com <> 0 THEN'
      #9#9#9#9#9#9#9#39'02'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_com,3) as varchar(' +
        '3)) +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_com,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_ind <> 0 THEN'
      #9#9#9#9#9#9#9#39'03'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_ind,3) as varchar(' +
        '3)) +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_ind,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_pub <> 0 THEN'
      #9#9#9#9#9#9#9#39'04'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_pub,3) as varchar(' +
        '3)) +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_pub,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_soc <> 0 THEN'
      #9#9#9#9#9#9#9#39'06'#39' + '
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_soc,3) as varchar(' +
        '3)) +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_soc,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END'
      #9#9#9#9'WHEN 3 THEN /*ESGOTO*/'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_res <> 0 THEN'
      #9#9#9#9#9#9#9#39'01'#39' + '
      #9#9#9#9#9#9#9#39'000'#39' +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_res,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_com <> 0 THEN'
      #9#9#9#9#9#9#9#39'02'#39' + '
      #9#9#9#9#9#9#9#39'000'#39' +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_com,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_ind <> 0 THEN'
      #9#9#9#9#9#9#9#39'03'#39' + '
      #9#9#9#9#9#9#9#39'000'#39' +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_ind,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_pub <> 0 THEN'
      #9#9#9#9#9#9#9#39'04'#39' + '
      #9#9#9#9#9#9#9#39'000'#39' +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_pub,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END +'
      #9#9#9#9#9'CASE '
      #9#9#9#9#9#9'WHEN cg_economia_soc <> 0 THEN'
      #9#9#9#9#9#9#9#39'06'#39' + '
      #9#9#9#9#9#9#9#39'000'#39' +'
      
        #9#9#9#9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(cg_economia_soc,3) as varchar(' +
        '3))'
      #9#9#9#9#9#9'ELSE'
      #9#9#9#9#9#9#9#39'  000000'#39
      #9#9#9#9#9'END'
      
        #9#9#9#9'ELSE '#39'00000000'#39' + '#39'00000000'#39' + '#39'00000000'#39' + '#39'00000000'#39' + '#39'00' +
        '000000'#39
      #9#9#9#9'END'
      #9'END +'
      #9'CASE cg_ident_calculo'
      #9#9'WHEN '#39'B'#39' THEN '
      #9#9#9'CASE cg_natureza_ligacao'
      #9#9#9#9'WHEN 1 /*AGUA*/ THEN '#39'34'#39
      #9#9#9#9'WHEN 2 /*AMBOS*/ THEN '#39'33'#39
      #9#9#9#9'WHEN 3 /*ESGOTO*/ THEN '#39'43'#39
      #9#9#9#9'ELSE /*ERRO*/ '#39'44'#39
      #9#9#9'END'
      #9#9'ELSE'
      #9#9#9'CASE cg_natureza_ligacao'
      #9#9#9#9'WHEN 1 /*AGUA*/ THEN '#39'14'#39
      #9#9#9#9'WHEN 2 /*AMBOS*/ THEN '#39'11'#39
      #9#9#9#9'WHEN 3 /*ESGOTO*/ THEN '#39'41'#39
      #9#9#9#9'ELSE /*ERRO*/ '#39'44'#39
      #9#9#9'END'
      #9'END +'
      '  cast(DBO.FC_COMPLETA_ZEROS(cg_setor, 3) as varchar(3)) +'
      #9'cast(DBO.FC_COMPLETA_BRANCOS(cg_inscricao) as varchar(16)) +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(cg_sequencia,  8) as varchar(8)) +'
      #9'cast(DBO.FC_COMPLETA_BRANCOS(cg_complemento) as varchar(10)) +'
      #9'CASE'
      
        #9#9'WHEN (cg_flag_emite_conta = '#39'N'#39' and cg_flag_calcula_conta = '#39'N' +
        #39') THEN '#39'7'#39
      
        #9#9'WHEN (cg_flag_emite_conta = '#39'N'#39' and cg_flag_calcula_conta = '#39'S' +
        #39') THEN '#39'6'#39
      #9#9'WHEN cg_flag_calcula_imposto = '#39'S'#39' THEN '#39'4'#39
      
        #9#9'WHEN cg_codigo_banco is not null and cg_entrega_alternativa <>' +
        ' '#39#39' THEN '#39'5'#39
      
        #9#9'WHEN cg_codigo_banco is not null and cg_entrega_alternativa = ' +
        #39#39' THEN '#39'1'#39
      
        #9#9'WHEN cg_codigo_banco is null and cg_entrega_alternativa <> '#39#39' ' +
        'THEN '#39'2'#39
      #9#9'ELSE '#39'0'#39
      #9'END +'
      #9'cast(DBO.FC_COMPLETA_ZEROS(cg_leitura_ant, 7) as varchar(7)) +'
      #9'isnull(('#9'select'
      
        #9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_consumo,0)'#9#9' , 6)'#9'as va' +
        'rchar(6))'
      
        #9#9#9' + cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_ocorrencia_leitura,0)' +
        ', 2) as varchar(2))'
      #9#9#9' + '#39'00'#39
      #9#9'from historico_consumo'
      #9#9'where hc_matricula = cg_matricula'
      '    and hc_grupo = cg_grupo'
      #9#9'and hc_sequencia = 1),'#39'0000000000'#39')  +'
      #9'isnull(('#9'select'
      
        #9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_consumo,0)'#9#9' , 6)'#9'as va' +
        'rchar(6))'
      
        #9#9#9' + cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_ocorrencia_leitura,0)' +
        ', 2) as varchar(2))'
      #9#9#9' + '#39'00'#39
      #9#9'from historico_consumo'
      #9#9'where hc_matricula = cg_matricula'
      '    and hc_grupo = cg_grupo'
      #9#9'and hc_sequencia = 2),'#39'0000000000'#39') +'
      #9'isnull(('#9'select'
      
        #9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_consumo,0)'#9#9' , 6)'#9'as va' +
        'rchar(6))'
      
        #9#9#9' + cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_ocorrencia_leitura,0)' +
        ', 2) as varchar(2))'
      #9#9#9' + '#39'00'#39
      #9#9'from historico_consumo'
      #9#9'where hc_matricula = cg_matricula'
      '    and hc_grupo = cg_grupo'
      #9#9'and hc_sequencia = 3),'#39'0000000000'#39')  +'
      #9'isnull(('#9'select'
      
        #9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_consumo,0)'#9#9' , 6)'#9'as va' +
        'rchar(6))'
      
        #9#9#9' + cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_ocorrencia_leitura,0)' +
        ', 2) as varchar(2))'
      #9#9#9' + '#39'00'#39
      #9#9'from historico_consumo'
      #9#9'where hc_matricula = cg_matricula'
      '    and hc_grupo = cg_grupo'
      #9#9'and hc_sequencia = 4),'#39'0000000000'#39')  +'
      #9'isnull(('#9'select'
      
        #9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_consumo,0)'#9#9' , 6)'#9'as va' +
        'rchar(6))'
      
        #9#9#9' + cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_ocorrencia_leitura,0)' +
        ', 2) as varchar(2))'
      #9#9#9' + '#39'00'#39
      #9#9'from historico_consumo'
      #9#9'where hc_matricula = cg_matricula'
      '    and hc_grupo = cg_grupo'
      #9#9'and hc_sequencia = 5),'#39'0000000000'#39')  +'
      #9'isnull(('#9'select'
      
        #9#9#9#9'cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_consumo,0)'#9#9' , 6)'#9'as va' +
        'rchar(6))'
      
        #9#9#9' + cast(DBO.FC_COMPLETA_ZEROS(isnull(hc_ocorrencia_leitura,0)' +
        ', 2) as varchar(2))'
      #9#9#9' + '#39'00'#39
      #9#9'from historico_consumo'
      #9#9'where hc_matricula = cg_matricula'
      '    and hc_grupo = cg_grupo'
      #9#9'and hc_sequencia = 6),'#39'0000000000'#39')  +'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(cg_consumo_medio, 6) as varchar(6)) ' +
        '+'
      #9'CASE cg_flag_troca'
      #9#9'WHEN '#39'S'#39' THEN '#39'5'#39
      #9#9'ELSE '#39'0'#39
      #9'END +'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(cg_consumo_anterior, 6) as varchar(6' +
        ')) +'
      #9#39'0'#39' + /*IMPLANTADO*/'
      #9'CASE'
      #9#9'WHEN cg_data_leit_ant is null THEN '#39'00000000'#39
      #9#9'ELSE'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, cg_data_leit_ant),4' +
        ') as varchar(4))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, cg_data_leit_ant),2) ' +
        'as varchar(2))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(dd, cg_data_leit_ant),2) ' +
        'as varchar(2))'
      #9'END +'
      #9#39'01'#39' + /*SITUACAO CONSUMO*/'
      #9'CASE'
      #9#9'WHEN cg_data_vencto is null THEN '#39'00000000'#39
      #9#9'ELSE'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, cg_data_vencto),4) ' +
        'as varchar(4))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, cg_data_vencto),2) as' +
        ' varchar(2))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(dd, cg_data_vencto),2) as' +
        ' varchar(2))'
      #9'END +'
      #9'CASE'
      #9#9'WHEN cg_codigo_banco is null THEN '#39'000'#39
      
        #9#9'ELSE cast(DBO.FC_COMPLETA_ZEROS(cg_codigo_banco,3) as varchar(' +
        '3))'
      #9'END +'
      #9'CASE'
      #9#9'WHEN cg_codigo_banco is null THEN '#39'0000'#39
      #9#9'ELSE cast(DBO.FC_COMPLETA_ZEROS(cg_agencia,4) as varchar(4))'
      #9'END +'
      #9#39'000000000000000'#39' + /*CONTA*/'
      '  '#39'000000'#39' + /*CONSUMO FIXO AGUA*/'
      '  CASE'
      
        '    WHEN (isnull(cg_numero_hd,'#39#39') = '#39#39' and (cg_natureza_ligacao ' +
        '= 2 or cg_natureza_ligacao = 3))  THEN '#39'000010'#39
      '    ELSE '#39'000000'#39
      '  END + /*CONSUMO FIXO ESGOTO*/'
      #9'CASE'
      #9#9'WHEN cg_data_instalacao_hd is null THEN '#39'00000000'#39
      #9#9'ELSE'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, cg_data_instalacao_' +
        'hd),4) as varchar(4))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, cg_data_instalacao_hd' +
        '),2) as varchar(2))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(dd, cg_data_instalacao_hd' +
        '),2) as varchar(2))'
      #9'END +'
      #9#39'1'#39' + /*TIPO RATEIO CONSUMO*/'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(de_limite_inicial,6) as varchar(6)) ' +
        '+'
      #9'cast(DBO.FC_COMPLETA_ZEROS(de_tipo_desconto,1) as varchar(1)) +'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(de_percentual, 3) as varchar(3)) + c' +
        'ast(DBO.FC_COMPLETA_ZEROS((de_percentual - cast(de_percentual as' +
        ' integer)) * 100, 2) as varchar(2)) +'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(de_percentual, 3) as varchar(3)) + c' +
        'ast(DBO.FC_COMPLETA_ZEROS((de_percentual - cast(de_percentual as' +
        ' integer)) * 100, 2) as varchar(2)) +'
      #9'CASE'
      
        #9#9'WHEN cg_mensagem1 <> '#39#39' THEN cast(DBO.FC_COMPLETA_BRANCOS(cg_m' +
        'ensagem1) as varchar(30))'
      #9#9'ELSE '#39'          '#39' + '#39'          '#39' + '#39'          '#39
      #9'END +'
      #9'CASE'
      
        #9#9'WHEN cg_mensagem2 <> '#39#39' THEN cast(DBO.FC_COMPLETA_BRANCOS(cg_m' +
        'ensagem2) as varchar(30))'
      #9#9'ELSE '#39'          '#39' + '#39'          '#39' + '#39'          '#39
      #9'END +'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(cg_qtde_registros_fraude, 2) as varc' +
        'har(2)) +'
      #9'cast(cg_flag_cortar as varchar(1)) +'
      #9'cast(cg_flag_calcula_conta as varchar(1)) +'
      #9'cast(cg_flag_emite_conta as varchar(1)) +'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(cg_dias_bloqueio_tarifa_ant, 3) as v' +
        'archar(3)) +'
      
        #9'cast(DBO.FC_COMPLETA_ZEROS(cg_dias_bloqueio_tarifa_atual, 3) as' +
        ' varchar(3)) +'
      #9'CASE'
      #9#9'WHEN cg_data_bloqueio is null THEN '#39'00000000'#39
      #9#9'ELSE'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(yyyy, cg_data_bloqueio),4' +
        ') as varchar(4))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(mm, cg_data_bloqueio),2) ' +
        'as varchar(2))+'
      
        #9#9#9'cast(DBO.FC_COMPLETA_ZEROS(DATEPART(dd, cg_data_bloqueio),2) ' +
        'as varchar(2))'
      #9'END +'
      '  '#39'0000000'#39' +  /*LEITURA BLOQUEIO*/'
      ' '#9'CASE isnull(cg_matricula_pai,0)'
      #9#9'WHEN 0 THEN'
      '   '#9#9'cast(DBO.FC_COMPLETA_ZEROS((select count (*)'
      #9#9#9#9#9#9#9#9#9#9'from carga C2'
      #9#9#9#9#9#9#9#9#9#9'where C2.cg_grupo = C.cg_grupo'
      #9#9#9#9#9#9#9#9#9#9'and C2.cg_rota = C.cg_rota'
      #9#9#9#9#9#9#9#9#9#9'and C2.cg_matricula = C.cg_matricula'
      #9#9#9#9#9#9#9#9#9#9'and C2.cg_virtual = '#39'N'#39
      #9#9#9#9#9#9#9#9#9#9'),3) as varchar(3))'
      #9#9'ELSE'
      '   '#9#9'cast(DBO.FC_COMPLETA_ZEROS((select count (*)'
      #9#9#9#9#9#9#9#9#9#9'from carga C2'
      #9#9#9#9#9#9#9#9#9#9'where C2.cg_grupo = C.cg_grupo'
      #9#9#9#9#9#9#9#9#9#9'and C2.cg_rota = C.cg_rota'
      #9#9#9#9#9#9#9#9#9#9'and C2.cg_matricula_pai = C.cg_matricula_pai'
      #9#9#9#9#9#9#9#9#9#9'and C2.cg_matricula_pai <> 0'
      #9#9#9#9#9#9#9#9#9#9'and C2.cg_virtual = '#39'N'#39
      #9#9#9#9#9#9#9#9#9#9'),3) as varchar(3))'
      #9'END +'
      #9'cast(DBO.FC_COMPLETA_ZEROS((select count (*)'
      #9#9#9#9'    from carga C2'
      #9#9#9'            where C2.cg_grupo = C.cg_grupo'
      ' '#9#9#9#9'    and C2.cg_rota = C.cg_rota'
      '   '#9'   '#9#9#9'    and C2.cg_matricula_pai = C.cg_matricula'
      
        '   '#9#9#9#9'    and C2.cg_matricula <> C2.cg_matricula_pai),3) as var' +
        'char(3)) '
      
        '+ cast(DBO.FC_COMPLETA_ZEROS(C.cg_qtde_debito_ant, 3) as varchar' +
        '(3)) '
      ''
      '+ cg_flag_calcula_imposto ) as linha'
      'from carga C'
      'left outer join descontos'
      'on de_grupo = cg_grupo'
      'and cg_desconto = de_codigo'
      'where'#9'cg_grupo = :grupo'
      #9'and cg_rota = :rota'
      'order by cg_sequencia, cg_matricula')
    Left = 184
    Top = 280
    ParamData = <
      item
        DataType = ftInteger
        Name = 'grupo'
        ParamType = ptUnknown
      end
      item
        DataType = ftInteger
        Name = 'rota'
        ParamType = ptUnknown
      end>
    object qryRegistro2Antmatricula: TIntegerField
      FieldName = 'matricula'
    end
    object qryRegistro2Antreferencia: TDateTimeField
      FieldName = 'referencia'
    end
    object qryRegistro2Antgrupo: TIntegerField
      FieldName = 'grupo'
    end
    object qryRegistro2Antsequencia: TIntegerField
      FieldName = 'sequencia'
    end
    object qryRegistro2Antemite_conta: TStringField
      FieldName = 'emite_conta'
      FixedChar = True
      Size = 1
    end
    object qryRegistro2Antbusca_dados: TIntegerField
      FieldName = 'busca_dados'
    end
    object qryRegistro2Antlinha: TMemoField
      FieldName = 'linha'
      BlobType = ftMemo
      Size = 1
    end
  end
end
