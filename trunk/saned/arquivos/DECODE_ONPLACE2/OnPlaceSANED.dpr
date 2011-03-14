program OnPlaceSANED;

uses
  Forms,
  DBLogDlg in 'DBLogDlg.pas' {LoginDialog},
  DBPWDlg in 'DBPWDlg.pas' {PasswordDialog},
  RpFormPreview in 'RpFormPreview.pas' {RavePreviewForm},
  RpFormSetup in 'RpFormSetup.pas' {RPSetupForm},
  uDMAnalise in 'uDMAnalise.pas' {dmAnalise},
  uDmCarga in 'uDmCarga.pas' {dmCarga},
  uDmMain in 'uDmMain.pas' {dmMain},
  uDmRecepcao in 'uDmRecepcao.pas' {dmRecepcao},
  uDMRedimensionamento in 'uDMRedimensionamento.pas' {DMRedimensionamento},
  uDmRetorno in 'uDmRetorno.pas' {dmRetorno},
  uDmTransmissao in 'uDmTransmissao.pas' {dmTransmissao},
  uFrmAbertura in 'uFrmAbertura.pas' {frmAbertura},
  uFrmAlteraMovimento in 'uFrmAlteraMovimento.pas' {frmAlteraMovimento},
  uFrmAnalise in 'uFrmAnalise.pas' {frmAnalise},
  uFrmBaseClient in 'uFrmBaseClient.pas' {frmBaseClient},
  uFrmBaseClientTabela in 'uFrmBaseClientTabela.pas' {frmBaseClientTabela},
  ufrmCarga in 'ufrmCarga.pas' {frmCarga},
  uFrmCargaOnLine in 'uFrmCargaOnLine.pas' {frmCargaOnLine},
  uFrmColetores in 'uFrmColetores.pas' {frmColetores},
  uFrmConsultaMovimento in 'uFrmConsultaMovimento.pas' {frmConsultaMovimento},
  uFrmDadosCliente in 'uFrmDadosCliente.pas' {frmDadosCliente},
  ufrmDesfazCarga in 'ufrmDesfazCarga.pas' {frmDesfazCarga},
  ufrmDesfazRecepcao in 'ufrmDesfazRecepcao.pas' {frmDesfazRecepcao},
  uFrmDesfazRetorno in 'uFrmDesfazRetorno.pas' {frmDesfazRetorno},
  uFrmDesfazTransmissao in 'uFrmDesfazTransmissao.pas' {FrmDesfazTransmissao},
  uFrmEmiteConta in 'uFrmEmiteConta.pas' {frmEmiteConta},
  uFrmFinalizaRota in 'uFrmFinalizaRota.pas' {frmFinalizaRota},
  uFrmLegenda in 'uFrmLegenda.pas' {frmLegenda},
  uFrmLogin in 'uFrmLogin.pas' {frmLogin},
  uFrmMain in 'uFrmMain.pas' {frmMain},
  uFrmRecepcao in 'uFrmRecepcao.pas' {frmRecepcao},
  uFrmRedimensionamento in 'uFrmRedimensionamento.pas' {frmRedimensionamento},
  uFrmRelatorioApoio in 'uFrmRelatorioApoio.pas' {frmRelatorioApoio},
  uFrmRelatorioMedicao in 'uFrmRelatorioMedicao.pas' {frmRelatorioMedicao},
  uFrmRelatorioOcorrencia in 'uFrmRelatorioOcorrencia.pas' {frmRelatorioOcorrencia},
  uFrmRelatorioPerformance in 'uFrmRelatorioPerformance.pas' {frmRelatorioPerformance},
  uFrmRelatorioResFat in 'uFrmRelatorioResFat.pas' {frmRelatorioResFat},
  uFrmRetorno in 'uFrmRetorno.pas' {frmRetorno},
  uFrmRetornoOnLine in 'uFrmRetornoOnLine.pas' {frmRetornoOnLine},
  uFrmSimulacao in 'uFrmSimulacao.pas' {frmSimulacao},
  uFrmSobre in 'uFrmSobre.pas' {frmSobre},
  uFrmTabAgentes in 'uFrmTabAgentes.pas' {frmTabAgentes},
  uFrmTabCategorias in 'uFrmTabCategorias.pas' {frmTabCategorias},
  uFrmTabChaveAcesso in 'uFrmTabChaveAcesso.pas' {frmTabChaveAcesso},
  uFrmTabMensagens in 'uFrmTabMensagens.pas' {frmTabMensagens},
  uFrmTabOcorrencias in 'uFrmTabOcorrencias.pas' {frmTabOcorrencias},
  uFrmTabQualidadeAgua in 'uFrmTabQualidadeAgua.pas' {frmTabQualidadeAgua},
  uFrmTabRoteiros in 'uFrmTabRoteiros.pas' {frmTabRoteiros},
  uFrmTabSenhaColeta in 'uFrmTabSenhaColeta.pas' {frmTabSenhaColeta},
  uFrmTabTarifas in 'uFrmTabTarifas.pas' {frmTabTarifas},
  uFrmTabUsuarios in 'uFrmTabUsuarios.pas' {frmTabUsuarios},
  uFrmTeste in 'uFrmTeste.pas' {frmTeste},
  uFrmTransmissao in 'uFrmTransmissao.pas' {frmTransmissao},
  uFrmVencimentoGrupo in 'uFrmVencimentoGrupo.pas' {frmVencimentoGrupo};

{$R *.RES}

begin
  Application.Initialize;
  Application.CreateForm(TLoginDialog, LoginDialog);
  Application.CreateForm(TPasswordDialog, PasswordDialog);
  Application.CreateForm(TRavePreviewForm, RavePreviewForm);
  Application.CreateForm(TRPSetupForm, RPSetupForm);
  Application.CreateForm(TdmAnalise, dmAnalise);
  Application.CreateForm(TdmCarga, dmCarga);
  Application.CreateForm(TdmMain, dmMain);
  Application.CreateForm(TdmRecepcao, dmRecepcao);
  Application.CreateForm(TDMRedimensionamento, DMRedimensionamento);
  Application.CreateForm(TdmRetorno, dmRetorno);
  Application.CreateForm(TdmTransmissao, dmTransmissao);
  Application.CreateForm(TfrmAbertura, frmAbertura);
  Application.CreateForm(TfrmAlteraMovimento, frmAlteraMovimento);
  Application.CreateForm(TfrmAnalise, frmAnalise);
  Application.CreateForm(TfrmBaseClient, frmBaseClient);
  Application.CreateForm(TfrmBaseClientTabela, frmBaseClientTabela);
  Application.CreateForm(TfrmCarga, frmCarga);
  Application.CreateForm(TfrmCargaOnLine, frmCargaOnLine);
  Application.CreateForm(TfrmColetores, frmColetores);
  Application.CreateForm(TfrmConsultaMovimento, frmConsultaMovimento);
  Application.CreateForm(TfrmDadosCliente, frmDadosCliente);
  Application.CreateForm(TfrmDesfazCarga, frmDesfazCarga);
  Application.CreateForm(TfrmDesfazRecepcao, frmDesfazRecepcao);
  Application.CreateForm(TfrmDesfazRetorno, frmDesfazRetorno);
  Application.CreateForm(TFrmDesfazTransmissao, FrmDesfazTransmissao);
  Application.CreateForm(TfrmEmiteConta, frmEmiteConta);
  Application.CreateForm(TfrmFinalizaRota, frmFinalizaRota);
  Application.CreateForm(TfrmLegenda, frmLegenda);
  Application.CreateForm(TfrmLogin, frmLogin);
  Application.CreateForm(TfrmMain, frmMain);
  Application.CreateForm(TfrmRecepcao, frmRecepcao);
  Application.CreateForm(TfrmRedimensionamento, frmRedimensionamento);
  Application.CreateForm(TfrmRelatorioApoio, frmRelatorioApoio);
  Application.CreateForm(TfrmRelatorioMedicao, frmRelatorioMedicao);
  Application.CreateForm(TfrmRelatorioOcorrencia, frmRelatorioOcorrencia);
  Application.CreateForm(TfrmRelatorioPerformance, frmRelatorioPerformance);
  Application.CreateForm(TfrmRelatorioResFat, frmRelatorioResFat);
  Application.CreateForm(TfrmRetorno, frmRetorno);
  Application.CreateForm(TfrmRetornoOnLine, frmRetornoOnLine);
  Application.CreateForm(TfrmSimulacao, frmSimulacao);
  Application.CreateForm(TfrmSobre, frmSobre);
  Application.CreateForm(TfrmTabAgentes, frmTabAgentes);
  Application.CreateForm(TfrmTabCategorias, frmTabCategorias);
  Application.CreateForm(TfrmTabChaveAcesso, frmTabChaveAcesso);
  Application.CreateForm(TfrmTabMensagens, frmTabMensagens);
  Application.CreateForm(TfrmTabOcorrencias, frmTabOcorrencias);
  Application.CreateForm(TfrmTabQualidadeAgua, frmTabQualidadeAgua);
  Application.CreateForm(TfrmTabRoteiros, frmTabRoteiros);
  Application.CreateForm(TfrmTabSenhaColeta, frmTabSenhaColeta);
  Application.CreateForm(TfrmTabTarifas, frmTabTarifas);
  Application.CreateForm(TfrmTabUsuarios, frmTabUsuarios);
  Application.CreateForm(TfrmTeste, frmTeste);
  Application.CreateForm(TfrmTransmissao, frmTransmissao);
  Application.CreateForm(TfrmVencimentoGrupo, frmVencimentoGrupo);
  Application.Run;
end.
