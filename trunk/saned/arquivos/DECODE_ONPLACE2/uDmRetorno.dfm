object dmRetorno: TdmRetorno
  OldCreateOrder = False
  OnCreate = DataModuleCreate
  Height = 387
  Width = 441
  object qryInsere: TQuery
    DatabaseName = 'dbMain'
    Left = 112
    Top = 32
  end
  object qryDesfazer: TQuery
    DatabaseName = 'dbMain'
    Left = 184
    Top = 32
  end
  object qryGeral: TQuery
    DatabaseName = 'dbMain'
    Left = 256
    Top = 32
  end
  object qryAtualiza: TQuery
    DatabaseName = 'dbMain'
    Left = 40
    Top = 32
  end
end
