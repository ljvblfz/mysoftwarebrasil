select grupo, referencia
from DIADEMA_IV.dbo.IDA_GRUPOS
where
data_processamento is not null
and data_retorno is null
order by
referencia, grupo


select * from DIADEMA_IV.dbo.IDA_GRUPOS where grupo = 18

select count(*) as total
from roteiros where rt_grupo  = 18
and rt_referencia = (
                      select referencia 
                      from DIADEMA_IV.dbo.IDA_GRUPOS 
                      where data_processamento is null 
                      and grupo = 18
                     )
                     
                



-- Libera recepção
update DIADEMA_IV.dbo.IDA_GRUPOS set data_Processamento = null where grupo = 18

