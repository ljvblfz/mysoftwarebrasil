using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GDA;
using GeraBase.Model;

namespace GeraBase.DAL
{
    public class SegundaViaIDADAO : BaseDAO<SegundaViaIDA>
    {
        public List<SegundaViaIDA> Lista()
        {
            string sql = @"
                            SELECT DISTINCT
                                *
				            FROM IDA_SEGUNDAS_VIAS
                         ";
            return CurrentPersistenceObject.LoadData(sql);
        }

		public void Delete(SegundaViaIDA objSegundaViaIDA)
        {
            GDA.Sql.Query query = new GDA.Sql.Query(" Grupo = '"+ objSegundaViaIDA.Grupo+@"' AND 
 CDC = '"+ objSegundaViaIDA.CDC+@"' AND 
 Referencia = '"+ objSegundaViaIDA.Referencia+@"' AND 
 Data_Vencimento = '"+ objSegundaViaIDA.Data_Vencimento+@"' AND 
 Data_Leitura = '"+ objSegundaViaIDA.Data_Leitura+@"' AND 
 Data_Leitura_Anterior = '"+ objSegundaViaIDA.Data_Leitura_Anterior+@"' AND 
 Leitura_Atual = '"+ objSegundaViaIDA.Leitura_Atual+@"' AND 
 Leitura_Anterior = '"+ objSegundaViaIDA.Leitura_Anterior+@"' AND 
 Dias_Consumo = '"+ objSegundaViaIDA.Dias_Consumo+@"' AND 
 Consumo_Faturado = '"+ objSegundaViaIDA.Consumo_Faturado+@"' AND 
 Media = '"+ objSegundaViaIDA.Media+@"' AND 
 Ref_Cons_1 = '"+ objSegundaViaIDA.Ref_Cons_1+@"' AND 
 Cons_1 = '"+ objSegundaViaIDA.Cons_1+@"' AND 
 Ref_Cons_2 = '"+ objSegundaViaIDA.Ref_Cons_2+@"' AND 
 Cons_2 = '"+ objSegundaViaIDA.Cons_2+@"' AND 
 Ref_Cons_3 = '"+ objSegundaViaIDA.Ref_Cons_3+@"' AND 
 Cons_3 = '"+ objSegundaViaIDA.Cons_3+@"' AND 
 Ref_Cons_4 = '"+ objSegundaViaIDA.Ref_Cons_4+@"' AND 
 Cons_4 = '"+ objSegundaViaIDA.Cons_4+@"' AND 
 Ref_Cons_5 = '"+ objSegundaViaIDA.Ref_Cons_5+@"' AND 
 Cons_5 = '"+ objSegundaViaIDA.Cons_5+@"' AND 
 Ref_Cons_6 = '"+ objSegundaViaIDA.Ref_Cons_6+@"' AND 
 Cons_6 = '"+ objSegundaViaIDA.Cons_6+@"' AND 
 Servico_01 = '"+ objSegundaViaIDA.Servico_01+@"' AND 
 Valor_01 = '"+ objSegundaViaIDA.Valor_01+@"' AND 
 Servico_02 = '"+ objSegundaViaIDA.Servico_02+@"' AND 
 Valor_02 = '"+ objSegundaViaIDA.Valor_02+@"' AND 
 Servico_03 = '"+ objSegundaViaIDA.Servico_03+@"' AND 
 Valor_03 = '"+ objSegundaViaIDA.Valor_03+@"' AND 
 Servico_04 = '"+ objSegundaViaIDA.Servico_04+@"' AND 
 Valor_04 = '"+ objSegundaViaIDA.Valor_04+@"' AND 
 Servico_05 = '"+ objSegundaViaIDA.Servico_05+@"' AND 
 Valor_05 = '"+ objSegundaViaIDA.Valor_05+@"' AND 
 Servico_06 = '"+ objSegundaViaIDA.Servico_06+@"' AND 
 Valor_06 = '"+ objSegundaViaIDA.Valor_06+@"' AND 
 Servico_07 = '"+ objSegundaViaIDA.Servico_07+@"' AND 
 Valor_07 = '"+ objSegundaViaIDA.Valor_07+@"' AND 
 Servico_08 = '"+ objSegundaViaIDA.Servico_08+@"' AND 
 Valor_08 = '"+ objSegundaViaIDA.Valor_08+@"' AND 
 Servico_09 = '"+ objSegundaViaIDA.Servico_09+@"' AND 
 Valor_09 = '"+ objSegundaViaIDA.Valor_09+@"' AND 
 Valor_Total = '"+ objSegundaViaIDA.Valor_Total+@"' AND 
 Codigo_Barras = '"+ objSegundaViaIDA.Codigo_Barras+@"' AND 
 Ocorrencia = '"+ objSegundaViaIDA.Ocorrencia+@"'");
            this.Delete(query);
            return;
        }

        public void Update(SegundaViaIDA objSegundaViaIDA)
        {
            string sql = @"
                            UPDATE IDA_SEGUNDAS_VIAS
                               SET
                                   Grupo = '" + objSegundaViaIDA.Grupo + @"' , 
CDC = '" + objSegundaViaIDA.CDC + @"' , 
Referencia = '" + objSegundaViaIDA.Referencia + @"' , 
Data_Vencimento = '" + objSegundaViaIDA.Data_Vencimento + @"' , 
Data_Leitura = '" + objSegundaViaIDA.Data_Leitura + @"' , 
Data_Leitura_Anterior = '" + objSegundaViaIDA.Data_Leitura_Anterior + @"' , 
Leitura_Atual = '" + objSegundaViaIDA.Leitura_Atual + @"' , 
Leitura_Anterior = '" + objSegundaViaIDA.Leitura_Anterior + @"' , 
Dias_Consumo = '" + objSegundaViaIDA.Dias_Consumo + @"' , 
Consumo_Faturado = '" + objSegundaViaIDA.Consumo_Faturado + @"' , 
Media = '" + objSegundaViaIDA.Media + @"' , 
Ref_Cons_1 = '" + objSegundaViaIDA.Ref_Cons_1 + @"' , 
Cons_1 = '" + objSegundaViaIDA.Cons_1 + @"' , 
Ref_Cons_2 = '" + objSegundaViaIDA.Ref_Cons_2 + @"' , 
Cons_2 = '" + objSegundaViaIDA.Cons_2 + @"' , 
Ref_Cons_3 = '" + objSegundaViaIDA.Ref_Cons_3 + @"' , 
Cons_3 = '" + objSegundaViaIDA.Cons_3 + @"' , 
Ref_Cons_4 = '" + objSegundaViaIDA.Ref_Cons_4 + @"' , 
Cons_4 = '" + objSegundaViaIDA.Cons_4 + @"' , 
Ref_Cons_5 = '" + objSegundaViaIDA.Ref_Cons_5 + @"' , 
Cons_5 = '" + objSegundaViaIDA.Cons_5 + @"' , 
Ref_Cons_6 = '" + objSegundaViaIDA.Ref_Cons_6 + @"' , 
Cons_6 = '" + objSegundaViaIDA.Cons_6 + @"' , 
Servico_01 = '" + objSegundaViaIDA.Servico_01 + @"' , 
Valor_01 = '" + objSegundaViaIDA.Valor_01 + @"' , 
Servico_02 = '" + objSegundaViaIDA.Servico_02 + @"' , 
Valor_02 = '" + objSegundaViaIDA.Valor_02 + @"' , 
Servico_03 = '" + objSegundaViaIDA.Servico_03 + @"' , 
Valor_03 = '" + objSegundaViaIDA.Valor_03 + @"' , 
Servico_04 = '" + objSegundaViaIDA.Servico_04 + @"' , 
Valor_04 = '" + objSegundaViaIDA.Valor_04 + @"' , 
Servico_05 = '" + objSegundaViaIDA.Servico_05 + @"' , 
Valor_05 = '" + objSegundaViaIDA.Valor_05 + @"' , 
Servico_06 = '" + objSegundaViaIDA.Servico_06 + @"' , 
Valor_06 = '" + objSegundaViaIDA.Valor_06 + @"' , 
Servico_07 = '" + objSegundaViaIDA.Servico_07 + @"' , 
Valor_07 = '" + objSegundaViaIDA.Valor_07 + @"' , 
Servico_08 = '" + objSegundaViaIDA.Servico_08 + @"' , 
Valor_08 = '" + objSegundaViaIDA.Valor_08 + @"' , 
Servico_09 = '" + objSegundaViaIDA.Servico_09 + @"' , 
Valor_09 = '" + objSegundaViaIDA.Valor_09 + @"' , 
Valor_Total = '" + objSegundaViaIDA.Valor_Total + @"' , 
Codigo_Barras = '" + objSegundaViaIDA.Codigo_Barras + @"' , 
Ocorrencia = '" + objSegundaViaIDA.Ocorrencia + @"'
                             WHERE ";

            int descontoSaida = CurrentPersistenceObject.ExecuteCommand(sql);
            return;
        }
    }
}