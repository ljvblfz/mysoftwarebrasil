declare @table char(50)
set @table = 'Cidade'

print '    public class '+ltrim(rtrim(@table))+'Repository
    {
        private static '+ltrim(rtrim(@table))+' Convert(dynamic oldEntity, int loop)
        {
            '+ltrim(rtrim(@table))+' entity = new '+ltrim(rtrim(@table))+'();
'
SELECT 
	'entity.'+COLUMN_NAME+' = oldEntity.'+COLUMN_NAME+';'
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME =  @table
print'
            return entity;
        }

        private static CorePontoEncontro.Model.'+ltrim(rtrim(@table))+' UnConvert(dynamic oldEntity)
        {
            CorePontoEncontro.Model.'+ltrim(rtrim(@table))+' entity = new CorePontoEncontro.Model.'+ltrim(rtrim(@table))+'();
'
SELECT 
	'entity.'+COLUMN_NAME+' = oldEntity.'+COLUMN_NAME+';'
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME =  @table
print'
            return entity;
        }

        public static IList<'+ltrim(rtrim(@table))+'> ListAll()
        {
            IList<'+ltrim(rtrim(@table))+'> list = new List<'+ltrim(rtrim(@table))+'>();
            CorePontoEncontro.Model.'+ltrim(rtrim(@table))+'[] collection = CorePontoEncontro.Model.'+ltrim(rtrim(@table))+'.FindAll();
            foreach (var item in collection)
            {
                list.Add(Convert(item, 0));
            }
            return list;
        }'
	