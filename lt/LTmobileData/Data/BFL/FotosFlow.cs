using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using LTmobileData.Data.Model;
using LTmobileData.Data.DAL;
using GDA.Sql;

namespace LTmobileData.Data.BFL
{
     public class FotosFlow
    {
         public static void Insert(Fotos fotos)
         {
             try
             {
                 new FotosDAO().Insert(fotos);
             }
             catch (Exception ex)
             {
                 throw new Exception("Não foi possíve inserir foto: " + ex);
             }
         }

         public static void AlteraStatusFoto(string Condicao)
         {
             new FotosDAO().AlteraStatusFoto(Condicao);
         }

         public static List<Fotos> getFotosNotSync()
         {
             return new FotosDAO().getFotosNotSync();
         }

         public static void InsertOrUpdate(Fotos fotos)
         {
             try
             {
                 new FotosDAO().InsertOrUpdate(fotos);
                // LeituraFlow.setQtdLeituraRealizada();
             }
             catch (Exception ex)
             {
                 throw new Exception("Não foi possíve atualizar foto: " + ex);
             }
         }

         public static void Update(Fotos fotos)
         {
             try
             {
                 new FotosDAO().Update(fotos);
                 LeituraFlow.setQtdLeituraRealizada();
             }
             catch(Exception ex)
             {
                 throw new Exception("Não foi possível altera informaões da foto: " + ex);  
             }

         }

         public static void DeleteTodos()
         {
             new FotosDAO().DeleteTodos();
         }

         public static void Delete(Fotos fotos)
         {
             try
             {
                 new FotosDAO().Delete(fotos);
             }
             catch (Exception ex)
             {
                 throw new Exception("Não foi possível deletar a foto: " + ex);
             }
         }

         public static void DeletarFoto(int NUM_UC, int MES_ANO_FATUR, int COD_LOCAL, string TIPO_MEDIC, int NUM_SEQ_FOTO)
        {
            try
            {
                new FotosDAO().deletarFoto(NUM_UC, MES_ANO_FATUR, COD_LOCAL, TIPO_MEDIC, NUM_SEQ_FOTO);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar a foto: " + ex);
            }
        }

        public static uint GetLastId(int Uc, int Mes_Ano_Fatur, string TIPO_MEDIC)
         {
             return new FotosDAO().GetLastId(Uc, Mes_Ano_Fatur, TIPO_MEDIC);
         }

         public static int GetIdFoto()
         {
             return new FotosDAO().getIdFoto();
         }

         public static List<Fotos> getFotos(int NUM_UC, string TIPO_MEDIC)
         {
             return new FotosDAO().getFotos(NUM_UC, TIPO_MEDIC);
         }

         public static int ExisteFoto(int NUM_UC, int MES_ANO_FATUR, string TIPO_MEDIC)
         {
             return new FotosDAO().ExisteFoto(NUM_UC, MES_ANO_FATUR, TIPO_MEDIC);
                 
         }

         public static int getIdFotoUc(int MES_ANO_FATUR, string TIPO_MEDIC, int COD_LOCAL, int NUM_UC, int COD_EMPRT, int NUM_RAZAO, int NUM_SEQ_FOTO)
         { 
            return new FotosDAO().getIdFotoUc(MES_ANO_FATUR, TIPO_MEDIC, COD_LOCAL, NUM_UC, COD_EMPRT, NUM_RAZAO, NUM_SEQ_FOTO);
         }
    }
}
