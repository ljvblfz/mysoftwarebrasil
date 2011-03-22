using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using GDA;
using SPCadDesktopData.Data.Model.Interface;
using SPCadDesktopData.Data.Model;

namespace SPCadDesktopData.Data.DAL
{
    /// <summary>
    /// Dao Genérica.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Dao<T> : BaseDAO<T>, IAuditoriaSuperDAO where T : AuditoriaSuper, new()
    {

        //Permite acessar na flow, os métodos da classe CurrentPersistenceObject.         
        public readonly PersistenceObject<T> CurrentPersistenceObject = new PersistenceObject<T>(GDA.GDASettings.DefaultProviderConfiguration);

        /// <summary>
        /// Recupera todos os registros ainda não sincronizados
        /// </summary>
        /// <returns>Lista tipada</returns>
        public void SetListNotSync(List<long> listUpdate)
        {
            if (listUpdate.Count == 0) return;
            string strListkey = "";
            string tableName;

            //Recupera valor da chave
            List<Mapper> keys = base.CurrentPersistenceObject.Keys;
            Type type = typeof(T);
            if (keys.Count == 0)
            {
                throw new GDAException("Opera\x00e7\x00e3o ilegal. Objeto do tipo \"" + type.FullName + "\" n\x00e3o possui chaves identificadas, por n\x00e3o \x00e9 poss\x00edvel executar a a\x00e7\x00e3o.");
            }
            else if (keys.Count > 1)
            {
                throw new GDAException("Opera\x00e7\x00e3o ilegal. Objeto do tipo \"" + type.FullName + "\" possui mais de uma chave identificadas.");
            }
            foreach (int item in listUpdate)
            {
                strListkey += item + ",";
            }
            strListkey = strListkey.Substring(0, strListkey.Length - 1);//remove a última virgula.
            tableName = base.CurrentPersistenceObject.TableName;
            string sql = string.Format(@" UPDATE {0} SET status_reg = '1'  
                            WHERE {1} IN ({2})", tableName, keys[0].Name, strListkey);

            base.CurrentPersistenceObject.ExecuteCommand(sql);
        }

        public int DeleteAll()
        {
            string tableName = base.CurrentPersistenceObject.TableName;
            string sql = string.Format(@"DELETE FROM {0}", tableName);

            return base.CurrentPersistenceObject.ExecuteCommand(sql);
        }

        //public void InsertOrUpdateSync(T className)
        //{
        //    try
        //    {
        //        className.StatusReg = "1";
        //        base.InsertOrUpdate(className);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Não foi possível inserir ou atualizar!\n" + ex.Message, (Exception)ex);
        //    }
        //}

        public void DeleteSync(T className)
        {
            try
            {
                base.Delete(className);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }
    }
}
