object frmMain: TfrmMain
  Left = 329
  Top = 154
  Caption = 'frmMain'
  ClientHeight = 457
  ClientWidth = 617
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  FormStyle = fsMDIForm
  Menu = SMMain
  OldCreateOrder = False
  Position = poDesktopCenter
  OnClose = FormClose
  OnCreate = FormCreate
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object StatusBar1: TStatusBar
    Left = 0
    Top = 438
    Width = 617
    Height = 19
    Panels = <
      item
        Text = 'Selecione Op'#231#227'o'
        Width = 200
      end
      item
        Alignment = taCenter
        Text = 'CAPS'
        Width = 50
      end
      item
        Alignment = taCenter
        Text = 'NUM'
        Width = 50
      end
      item
        Alignment = taCenter
        Text = 'SCROLL'
        Width = 50
      end
      item
        Alignment = taCenter
        Text = 'DATE'
        Width = 50
      end
      item
        Alignment = taCenter
        Text = 'TIME'
        Width = 50
      end
      item
        Alignment = taCenter
        Text = 'Vers'#227'o'
        Width = 50
      end
      item
        Alignment = taCenter
        Text = '13/09/2000'
        Width = 100
      end
      item
        Width = 50
      end>
    ParentShowHint = False
    ShowHint = False
  end
  object SMMain: TSMainMenu
    MenuDataset = CSMenu
  end
  object qryMenu: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select '
      #9'ac_nivel as nivel,'
      #9'ac_caption as caption,'
      #9'ac_name as name,'
      #9'ac_onclick as onclick'
      'from chave, acesso, chave_acesso'
      'where ch_chave = :chave'
      'and ch_chave = ca_chave'
      'and ac_id = ca_id'
      'and ch_status = 1'
      'and ca_status = 1'
      'order by ac_ordem')
    Left = 35
    ParamData = <
      item
        DataType = ftString
        Name = 'chave'
        ParamType = ptUnknown
      end>
  end
  object Timer1: TTimer
    Enabled = False
    Interval = 1
    OnTimer = Timer1Timer
    Top = 72
  end
  object CSMenu: TClientDataSet
    Aggregates = <>
    Params = <>
    Top = 32
  end
  object QrParametros: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'#9'*'
      'from '#9'dbo.parametros')
    Left = 36
    Top = 70
    object QrParametrosNATUREZA: TStringField
      FieldName = 'NATUREZA'
      Origin = 'DBMAIN.parametros.NATUREZA'
      Size = 3
    end
    object QrParametrosEMPRESA: TStringField
      FieldName = 'EMPRESA'
      Origin = 'DBMAIN.parametros.EMPRESA'
      Size = 4
    end
    object QrParametrosDIRETORIO: TStringField
      FieldName = 'DIRETORIO'
      Origin = 'DBMAIN.parametros.DIRETORIO'
      Size = 50
    end
  end
  object QrExecSysConfig: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'CREATE TABLE dbo.sysconfig'
      '(sy_client '#9'varchar2(60) NOT NULL ,'
      'sy_cnpj   varchar2(14) NOT NULL ,'
      'sy_chave  varchar2(25) NOT NULL ,'
      'sy_date   datetime NOT NULL)')
    Left = 104
    Top = 22
  end
  object QrExisteSysConfig: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      'select'#9'count(*) as Existe'
      'from'#9'dbo.sysobjects'
      'where'#9'name like '#39'sysconfig'#39)
    Left = 74
    Top = 22
    object QrExisteSysConfigExiste: TIntegerField
      FieldName = 'Existe'
    end
  end
  object QrDadosSysCoonfig: TQuery
    DatabaseName = 'dbMain'
    SQL.Strings = (
      
        'select'#9'sy_client, sy_cnpj, sy_chave, sy_date, getdate() as DataA' +
        'tual'
      'from '#9'dbo.sysconfig')
    Left = 134
    Top = 22
    object QrDadosSysCoonfigsy_client: TStringField
      FieldName = 'sy_client'
      Origin = 'sysconfig.sy_client'
      Size = 60
    end
    object QrDadosSysCoonfigsy_cnpj: TStringField
      FieldName = 'sy_cnpj'
      Origin = 'sysconfig.sy_cnpj'
      Size = 14
    end
    object QrDadosSysCoonfigsy_chave: TStringField
      FieldName = 'sy_chave'
      Origin = 'sysconfig.sy_chave'
      Size = 25
    end
    object QrDadosSysCoonfigsy_date: TDateTimeField
      FieldName = 'sy_date'
      Origin = 'sysconfig.sy_date'
    end
    object QrDadosSysCoonfigDataAtual: TDateTimeField
      FieldName = 'DataAtual'
    end
  end
end
