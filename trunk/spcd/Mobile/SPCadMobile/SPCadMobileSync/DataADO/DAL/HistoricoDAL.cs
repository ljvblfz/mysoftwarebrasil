using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SPCadMobileData.Data.DAL;
using System.Data;
using SPCadMobileSync.Data.DAL;
using System.Data.SqlServerCe;

namespace SPCadMobileSync.DataADO.DAL
{
    public class HistoricoDAL
    {
        //insere um unico registro no banco.
        public void Insert(SPCadMobileSync.SPCadServices.HistoricoConsumo obj)
        {
            ConectSPCad sql = new ConectSPCad();
            try
            {
                string sqlScript = @"insert into TB_HISTORICO_CONSUMO(ID_HIST_CONSM, ID_CADAST, MES_REFER,COD_OCORRC1,COD_OCORRC2 ,critr,VOL_MEDDO,NUM_MATRIC,FLG_HISTCONSUMO,VERSAO,USU_MOVIMENTACAO,DT_MOVIMENTACAO,IP_MOVIMENTACAO,STATUS_REG,leitura_fat,dat_leitura_fat)
                                                      VALUES(@idHistConsumo,@idCadastro,@mesReferr,@ocorrencia1,@ocorrencia2,@criterio,@volMedido,@numMatric,@flgHistConsu, @versao,@usuMov,@dataMov,@ipMov,@statusReg, @LeituraApu,@datFat)";

                sql.cmd.CommandText = sqlScript;

                SqlCeParameter idHistConsum = new SqlCeParameter();
                idHistConsum.ParameterName = "@idHistConsumo";
                idHistConsum.Value = obj.Id;
                sql.cmd.Parameters.Add(idHistConsum);

                SqlCeParameter idCadastro = new SqlCeParameter();
                idCadastro.ParameterName = "@idCadastro";                
                if (obj.Cadastro == null)
                {
                    idCadastro.Value = System.DBNull.Value;
                }
                else
                {
                    idCadastro.Value = obj.Cadastro;
                }
                sql.cmd.Parameters.Add(idCadastro);

                SqlCeParameter mesRefer = new SqlCeParameter();
                mesRefer.ParameterName = "@mesReferr";
                if (obj.MesReferencia == null || obj.MesReferencia == DateTime.MinValue)
                {
                    mesRefer.Value = System.DBNull.Value;
                }
                else
                {
                    mesRefer.Value = obj.MesReferencia.MaskAmerican();
                }
                sql.cmd.Parameters.Add(mesRefer);

                SqlCeParameter ocor1 = new SqlCeParameter();
                ocor1.ParameterName = "@ocorrencia1";
                if (obj.Ocorrencia1 == null)
                {
                    ocor1.Value = System.DBNull.Value;
                }
                else
                {
                    ocor1.Value = obj.Ocorrencia1;
                }
                sql.cmd.Parameters.Add(ocor1);

                SqlCeParameter ocor2 = new SqlCeParameter();
                ocor2.ParameterName = "@ocorrencia2";
                if (obj.Ocorrencia2 == null)
                {
                    ocor2.Value = System.DBNull.Value;
                }
                else
                {
                    ocor2.Value = obj.Ocorrencia2;
                }
                sql.cmd.Parameters.Add(ocor2);

                SqlCeParameter criterio = new SqlCeParameter();
                criterio.ParameterName = "@criterio";
                if (obj.Criterio == null)
                {
                    criterio.Value = System.DBNull.Value;
                }
                else
                {
                    criterio.Value = obj.Criterio;
                }
                sql.cmd.Parameters.Add(criterio);


                SqlCeParameter voluMedido = new SqlCeParameter();
                voluMedido.ParameterName = "@volMedido";
                if (obj.VolumeMedido == null)
                {
                    voluMedido.Value = System.DBNull.Value;
                }
                else
                {
                    voluMedido.Value = obj.VolumeMedido;
                }
                sql.cmd.Parameters.Add(voluMedido);

                SqlCeParameter numMatric = new SqlCeParameter();
                numMatric.ParameterName = "@numMatric";
                numMatric.Value = obj.Matricula;
                if (obj.Matricula == null)
                {
                    numMatric.Value = System.DBNull.Value;
                }
                else
                {
                    numMatric.Value = obj.Matricula;
                }
                sql.cmd.Parameters.Add(numMatric);

                SqlCeParameter flgConsHist = new SqlCeParameter();
                flgConsHist.ParameterName = "@flgHistConsu";                
                if (obj.FlgHistconsumo == null)
                {
                    flgConsHist.Value = System.DBNull.Value;
                }
                else
                {
                    flgConsHist.Value = obj.FlgHistconsumo;
                }
                sql.cmd.Parameters.Add(flgConsHist);

                SqlCeParameter versao = new SqlCeParameter();
                versao.ParameterName = "@versao";
                if (obj.Versao == null)
                {
                    versao.Value = System.DBNull.Value;
                }
                else
                {
                    versao.Value = obj.Versao;
                }
                sql.cmd.Parameters.Add(versao);

                SqlCeParameter usuMov = new SqlCeParameter();
                usuMov.ParameterName = "@usuMov";                
                if (obj.UsuMovimentacao == null)
                {
                    usuMov.Value = System.DBNull.Value;
                }
                else
                {
                    usuMov.Value = obj.UsuMovimentacao;
                }
                sql.cmd.Parameters.Add(usuMov);

                SqlCeParameter dataMov = new SqlCeParameter();
                dataMov.ParameterName = "@dataMov";
                if (obj.DtMovimentacao == null || obj.DtMovimentacao == DateTime.MinValue)
                {
                    dataMov.Value = System.DBNull.Value;
                }
                else
                {
                    dataMov.Value = obj.DtMovimentacao.MaskAmerican();
                }
                sql.cmd.Parameters.Add(dataMov);

                SqlCeParameter statusreg = new SqlCeParameter();
                statusreg.ParameterName = "@statusReg";
                statusreg.Value = 1;
                sql.cmd.Parameters.Add(statusreg);

                 SqlCeParameter ipMov = new SqlCeParameter();
                ipMov.ParameterName = "@ipMov";                
                if (obj.IpMovimentacao == null)
                {
                    ipMov.Value = System.DBNull.Value;
                }
                else
                {
                    ipMov.Value = obj.IpMovimentacao;
                }
                sql.cmd.Parameters.Add(ipMov);

                SqlCeParameter leitApu = new SqlCeParameter();
                leitApu.ParameterName = "@LeituraApu";
                if (obj.LeituraApuracao == null)
                {
                    leitApu.Value = System.DBNull.Value;
                }
                else
                {
                    leitApu.Value = obj.LeituraApuracao;
                }
                sql.cmd.Parameters.Add(leitApu);

                SqlCeParameter datFat = new SqlCeParameter();
                datFat.ParameterName = "@datFat";
                if (obj.DatLeituraFat == null)
                {
                    datFat.Value = System.DBNull.Value;
                }
                else
                {
                    datFat.Value = obj.DatLeituraFat.MaskAmerican();
                }
                sql.cmd.Parameters.Add(datFat);

                sql.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sql.CloseConection();
            }
        }

        internal void Delete(SPCadMobileSync.SPCadServices.HistoricoConsumo item)
        {
            ConectSPCad sql = new ConectSPCad();

            try
            {
                sql.cmd.CommandText = string.Format(@"delete from TB_HISTORICO_CONSUMO where ID_HIST_CONSM = {0}", item.Id);
                sql.cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sql.CloseConection();
            }
        }

        //public void Delete(LogSync obj)
        //{
        //    ConectSPCad sql = new ConectSPCad();

        //    try
        //    {
        //        sql.cmd.CommandText = string.Format(@"delete from TBLOGSYNC where MATRICULA = {0}", obj.Matricula);
        //        sql.cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        sql.CloseConection();
        //    }
        //}

        //public void DeleteAll()
        //{
        //    ConectSPCad sql = new ConectSPCad();

        //    try
        //    {
        //        sql.cmd.CommandText = string.Format(@"delete from TBLOGSYNC");
        //        sql.cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        sql.CloseConection();
        //    }
        //}

        //public List<LogSync> Select()
        //{
        //    List<LogSync> lst = new List<LogSync>();
        //    ConectSPCad sql = new ConectSPCad();
        //    IDataReader dReader;             

        //    try
        //    {
        //        sql.cmd.CommandText = string.Format(@"Select * from TBLOGSYNC");
        //        dReader = sql.cmd.ExecuteReader();                

        //        while (dReader.Read())
        //        {
        //            LogSync NovoRegistro = new LogSync();

        //            NovoRegistro.Matricula = long.Parse(dReader["MATRICULA"].ToString());
        //            NovoRegistro.DataSync = (DateTime)dReader["DATASYNC"];
        //            NovoRegistro.TipoSync = dReader["TIPOSYNC"].ToString();                    

        //            // adciona a lista
        //            lst.Add(NovoRegistro);
        //        }

        //        dReader.Close();

        //        return lst;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        sql.CloseConection();
        //    }            


    }
}
