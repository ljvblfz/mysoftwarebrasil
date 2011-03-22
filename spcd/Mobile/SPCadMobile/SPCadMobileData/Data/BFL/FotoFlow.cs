using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileData.Data.Model;
using SPCadMobileData.Data.DAL;
using CommonHelpMobile;
using GDA;

namespace SPCadMobileData.Data.BFL
{
    public class FotoFlow
    {
        private Dao<Foto> _fotoDAO = DaoFactory.getFoto();

        #region CRUD

        public void Insert(Foto foto)
        {
            try
            {
                Foto fotoNew = foto;
                int seq = 0;
                if (!Existe(foto))
                {
                    seq = getNextSequenciafoto(foto);

                    // Define o nome da foto
                    if (fotoNew.codOcorrc.isNullorZero())
                    {
                        fotoNew.nomFoto = foto.idCadast + "_" + foto.numPontoServc + "_" + seq + ".jpg";
                        fotoNew.sequencia = seq;
                    }
                    else
                    {
                        fotoNew.nomFoto = foto.idCadast + "_" + foto.numPontoServc + "_" + foto.codOcorrc + "_" + seq + ".jpg";
                        fotoNew.sequencia = seq;
                    }

                    fotoNew.StatusReg = "3";

                    //remove as aspas no texto.
                    if(!string.IsNullOrEmpty(fotoNew.descFoto))
                    fotoNew.descFoto = TrataString.RemoveAspas(fotoNew.descFoto);

                    _fotoDAO.Insert(fotoNew);
                }
                else
                {
                    fotoNew.Data = DateTime.Today;
                    Update(fotoNew);
                }
            }
            catch (Exception ex)
            {
                throw new GDAException("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Delete(Foto foto)
        {
            try
            {
                string sql = string.Empty;
                //deleta o registro do banco
                if (foto.codOcorrc.isNullorZero())
                {
                    sql = sql = string.Format(@"DELETE FROM TB_FOTO 
                                            WHERE ID_CADAST = {0}
                                            AND NUM_PONTO_SERVC= '{1}'
                                            AND COD_OCORRC is null
                                            AND SEQUENCIA = {2}", foto.idCadast, foto.numPontoServc, foto.sequencia);
                }
                else
                {
                    sql = string.Format(@"DELETE FROM TB_FOTO 
                                            WHERE ID_CADAST = {0}
                                            AND NUM_PONTO_SERVC= '{1}'
                                            AND COD_OCORRC = {2}
                                            AND SEQUENCIA = {3}", foto.idCadast, foto.numPontoServc, foto.codOcorrc, foto.sequencia);
                }
                _fotoDAO.CurrentPersistenceObject.ExecuteCommand(sql);
                //deleta o arquivo de imagem do dispositivo.
                System.IO.File.Delete(InfoFiles.GetPathFoto() + foto.nomFoto);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível deletar!\n" + ex.Message, (Exception)ex);
            }
        }

        public void Update(Foto foto)
        {
            try
            {
                string sql = string.Empty;

                Foto fotoNew = foto;

                //remove as aspas no texto.
                if (!string.IsNullOrEmpty(fotoNew.descFoto))
                fotoNew.descFoto = TrataString.RemoveAspas(fotoNew.descFoto);

                if (foto.codOcorrc.isNullorZero())
                {
                    sql = string.Format(@"UPDATE TB_FOTO 
                                            SET DESC_FOTO = '{3}',
                                                STATUS_REG = '2',
                                                DATA = '{4}'
                                            WHERE ID_CADAST = {0}
                                            AND NUM_PONTO_SERVC= '{1}'
                                            AND COD_OCORRC is null
                                            AND SEQUENCIA = {2}", foto.idCadast, foto.numPontoServc, foto.sequencia, foto.descFoto, foto.Data.ToString("yyyy/MM/dd hh:mm:ss"));
                }
                else
                {
                    sql = string.Format(@"UPDATE TB_FOTO 
                                            SET DESC_FOTO = '{4}',
                                                STATUS_REG = '2',
                                                DATA = '{5}'
                                            WHERE ID_CADAST = {0}
                                            AND NUM_PONTO_SERVC= '{1}'
                                            AND COD_OCORRC = {2}
                                            AND SEQUENCIA = {3}", foto.idCadast, foto.numPontoServc, foto.codOcorrc, foto.sequencia, foto.descFoto, foto.Data.ToString("yyyy/MM/dd hh:mm:ss"));
                }
                _fotoDAO.CurrentPersistenceObject.ExecuteCommand(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar!\n" + ex.Message, (Exception)ex);
            }
        }

        #endregion

        /// <summary>
        /// Retorna uma lista de fotos por ocorrencia.
        /// </summary>
        /// <param name="idCadast">idCadastro</param>
        /// <param name="PonServ">PontodeServiço</param>
        /// <param name="ocorr">Ocorrencia</param>
        /// <returns></returns>
        public List<Foto> getListFotoByParam(long idCadast, string PonServ, int? ocorr)
        {
            string sql = string.Format(@"SELECT * FROM TB_FOTO WHERE ID_CADAST = {0} 
                                        AND NUM_PONTO_SERVC = '{1}'
                                        AND COD_OCORRC = {2}", idCadast, PonServ, ocorr);

            return _fotoDAO.CurrentPersistenceObject.LoadData(sql);
        }

        public List<Foto> getListFotoByParam(long idCadast, string PonServ)
        {
            string sql = string.Format(@"SELECT * FROM TB_FOTO WHERE ID_CADAST = {0} 
                                        AND NUM_PONTO_SERVC = '{1}'
                                        AND COD_OCORRC is null ", idCadast, PonServ);

            return _fotoDAO.CurrentPersistenceObject.LoadData(sql);
        }

        public List<Foto> getListFotoGeralByParam(long idCadast, string PonServ)
        {
            string sql = string.Format(@"SELECT * FROM TB_FOTO WHERE ID_CADAST = {0} 
                                        AND NUM_PONTO_SERVC = '{1}' ", idCadast, PonServ);

            return _fotoDAO.CurrentPersistenceObject.LoadData(sql);
        }

        public bool Existe(Foto foto)
        {
            string sql = string.Empty;

            if (foto.codOcorrc.isNullorZero())
            {
                sql = string.Format(@"select count(*) from tb_foto WHERE ID_CADAST = {0} 
                                        AND NUM_PONTO_SERVC = '{1}'
                                        AND COD_OCORRC is null
                                        AND SEQUENCIA = {2}", foto.idCadast, foto.numPontoServc, foto.sequencia);
            }
            else
            {
                sql = string.Format(@"select count(*) from tb_foto WHERE ID_CADAST = {0} 
                                        AND NUM_PONTO_SERVC = '{1}'
                                        AND COD_OCORRC = {2}
                                        AND SEQUENCIA = {3}", foto.idCadast, foto.numPontoServc, foto.codOcorrc, foto.sequencia);
            }

            return (int.Parse(_fotoDAO.CurrentPersistenceObject.ExecuteScalar(sql).ToString()) > 0);
        }

        public int getNextSequenciafoto(Foto foto)
        {
            int sequence = 1;
            int vlr = 0;
            List<Foto> fotos = new List<Foto>();

            //if (foto.codOcorrc.isNullorZero())
            //{
            //    fotos = getListFotoByParam(foto.idCadast, foto.numPontoServc);
            //}
            //else
            //{
            //    fotos = getListFotoByParam(foto.idCadast, foto.numPontoServc, foto.codOcorrc);
            //}
            fotos = getListFotoGeralByParam(foto.idCadast, foto.numPontoServc);

            foreach (Foto current in fotos)
            {
                if (current.sequencia > vlr)
                {
                    vlr = current.sequencia;
                }
            }

            sequence += vlr;

            return sequence;
        }

        public List<Foto> GetListNotSync()
        {
            string sql = string.Format(@"SELECT *
                                        FROM TB_FOTO 
                                        WHERE status_reg <> 1 ");

            return _fotoDAO.CurrentPersistenceObject.LoadData(sql);
        }

        /// <summary>
        /// Recupera todos os registros ainda não sincronizados
        /// </summary>
        /// <returns>Lista tipada</returns>
        public void SetListNotSync(List<string> listUpdate)
        {
            if (listUpdate.Count == 0) return;
            string strListkey = "";
            string tableName;

            Type type = typeof(Foto);

            foreach (string item in listUpdate)
            {
                strListkey += "'"+item+"'" + ",";
            }

            strListkey = strListkey.Substring(0, strListkey.Length - 1);

            tableName = _fotoDAO.CurrentPersistenceObject.TableName;//remove a última virgula.

            string sql = string.Format(@" UPDATE {0} SET status_reg = '1'  
                            WHERE {1} IN ({2})", tableName, "nom_foto", strListkey);

            _fotoDAO.CurrentPersistenceObject.ExecuteCommand(sql);
        }

        public void DeleteAll()
        {
            List<Foto> lst = _fotoDAO.Select();

            foreach (Foto foto in lst)
            {
                if (System.IO.File.Exists(InfoFiles.GetPathFoto() + foto.nomFoto))
                {
                    System.IO.File.Delete(InfoFiles.GetPathFoto() + foto.nomFoto);
                }
            }

            _fotoDAO.DeleteAll();
        }

        public void InsertOrUpdateSync(Foto foto)
        {
            try
            {
                _fotoDAO.InsertOrUpdateSync(foto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, (Exception)ex);
            } 
        }

        //retorna true se o cadastro relacionado a foto estiver executado e sincronizado.
        public bool StatusFotoCadExec(Rota rota)
        {
            bool status = false;//false para não concluído ou não sincronizado            

            //busca por cadastros não sincronizados e não executados
            string sql = string.Format(@"select count(fo.NOM_FOTO) from TB_FOTO fo
                                        inner join TB_CADASTRO ca on(ca.ID_CADAST = fo.ID_CADAST)
                                        where fo.status_reg <> '1'  and
                                        ca.COD_DISTRT = {0} and 
                                        ca.NUM_SETOR = {1} and
                                        ca.COD_ROTA = {2}
                                        group by ca.COD_DISTRT ,ca.NUM_SETOR ,ca.COD_ROTA", rota.CodigoDistrito, rota.Setor, rota.CodigoRota);

            object qtdFotExec = _fotoDAO.CurrentPersistenceObject.ExecuteScalar(sql);

            //a igualdade nesta operação significa que não foi encontrado cadadastro que não estejam executados e sincronizados.
            if (qtdFotExec == null)
            {
                return true;
            }

            return status;
        }

        //deleta as fotos de uma rota, que foram sincronizadas e estao com o cadastro relacionado executado.
        public void DelFotoExecOrFinal(Rota rota, string tipo)
        {
            string situacao = string.Empty;

            if (tipo == "executado")
            {
                situacao = "fo.status_reg = '1'  and ";
            }
            else if (tipo == "finalizado")
            {
                situacao = string.Empty;
            }

             string sqlFotos= string.Format(@"select * from TB_FOTO
                                        where ID_CADAST in(
                                        select fo.ID_CADAST from TB_FOTO fo
                                        inner join TB_CADASTRO ca on(ca.ID_CADAST = fo.ID_CADAST)
                                        where {3}
                                        ca.COD_DISTRT = {0} and 
                                        ca.NUM_SETOR = {1} and
                                        ca.COD_ROTA = {2}
                                        )", rota.CodigoDistrito, rota.Setor, rota.CodigoRota, situacao);
            List<Foto> lst = _fotoDAO.CurrentPersistenceObject.LoadData(sqlFotos);

            string sql = string.Format(@"delete from TB_FOTO
                                        where ID_CADAST in(
                                        select fo.ID_CADAST from TB_FOTO fo
                                        inner join TB_CADASTRO ca on(ca.ID_CADAST = fo.ID_CADAST)
                                        where {3}
                                        ca.COD_DISTRT = {0} and 
                                        ca.NUM_SETOR = {1} and
                                        ca.COD_ROTA = {2}
                                        )", rota.CodigoDistrito, rota.Setor, rota.CodigoRota, situacao);

            _fotoDAO.CurrentPersistenceObject.ExecuteCommand(sql);
            
            foreach (Foto foto in lst)
            {
                System.IO.File.Delete(InfoFiles.GetPathFoto() + foto.nomFoto);
            }            
        }

        public bool StatusFotoFinal(Rota rota)
        {
            bool status = false;//false = não sincronizado                        

            //busca por cadastros não sincronizados e não executados
            string sql = string.Format(@"select count(fo.NOM_FOTO) from TB_FOTO fo
                                        inner join TB_CADASTRO ca on(ca.ID_CADAST = fo.ID_CADAST)
                                        where fo.status_reg <> '1'  and
                                        ca.COD_DISTRT = {0} and 
                                        ca.NUM_SETOR = {1} and
                                        ca.COD_ROTA = {2}
                                        group by ca.COD_DISTRT ,ca.NUM_SETOR ,ca.COD_ROTA", rota.CodigoDistrito, rota.Setor, rota.CodigoRota);

            object qtdFotExec = _fotoDAO.CurrentPersistenceObject.ExecuteScalar(sql);

            //a igualdade nesta operação significa todas as fotos foram sincronizados.
            if (qtdFotExec == null)
            {
                return true;
            }

            return status;
        }
    }
}
