using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CommonHelpDesktop;
using GDA;
using SPCadDesktopData.Data.DAL;
using SPCadDesktopData.Data.Model;

namespace SPCadDesktopData.Data.BFL
{
    public class FotoFlow
    {
        private Dao<Foto> _fotoDAO = DaoFactory.getFoto();

        #region CRUD

        public void Insert(Foto foto)
        {
            try
            {
                if (!Existe(foto))
                {
                    _fotoDAO.Insert(foto);
                }
                else
                {
                    Update(foto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível inserir!\n" + ex.Message, (Exception)ex);
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
                                                STATUS_REG = '2'
                                            WHERE ID_CADAST = {0}
                                            AND NUM_PONTO_SERVC= '{1}'
                                            AND COD_OCORRC is null
                                            AND SEQUENCIA = {2}", foto.idCadast, foto.numPontoServc, foto.sequencia, foto.descFoto);
                }
                else
                {
                    sql = string.Format(@"UPDATE TB_FOTO 
                                            SET DESC_FOTO = '{4}',
                                                STATUS_REG = '2'
                                            WHERE ID_CADAST = {0}
                                            AND NUM_PONTO_SERVC= '{1}'
                                            AND COD_OCORRC = {2}
                                            AND SEQUENCIA = {3}", foto.idCadast, foto.numPontoServc, foto.codOcorrc, foto.sequencia, foto.descFoto);
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

        public List<Foto> getListFotoByPS(long idCadast, string PonServ)
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

            if (foto.codOcorrc.isNullorZero())
            {
                fotos = getListFotoByParam(foto.idCadast, foto.numPontoServc);
            }
            else
            {
                fotos = getListFotoByParam(foto.idCadast, foto.numPontoServc, foto.codOcorrc);
            }

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
