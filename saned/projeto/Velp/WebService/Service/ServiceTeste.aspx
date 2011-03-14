<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceTeste.aspx.cs" Inherits="SANEDWebService.ServiceTeste" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Teste Web Service</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="LabelVersao" runat="server" Text="Versão"></asp:Label>
        <asp:TextBox ID="TextBoxVersao" runat="server" Enabled="false" ></asp:TextBox><br /><br />
        <asp:Label ID="LabelAmbiente" runat="server" Text="Tempo de sincronização"></asp:Label>
        <asp:TextBox ID="TextBoxAmbiente" runat="server" Enabled="false" Width="683px" ></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    </div>
    <br /><br />
    <div>
        <asp:Label ID="LabelMovimento" runat="server" Text="Dados de Movimento"></asp:Label><br />
        <asp:Button ID="Button2" runat="server" Text="Button" onclick="Button2_Click" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" >
            <Columns>
                <asp:BoundField DataField="val_impressoes" HeaderText="val_impressoes" 
                    SortExpression="val_impressoes" />
                <asp:BoundField DataField="ind_fatura_emitida" HeaderText="ind_fatura_emitida" 
                    SortExpression="ind_fatura_emitida" />
                <asp:BoundField DataField="ind_leitura_divergente" 
                    HeaderText="ind_leitura_divergente" SortExpression="ind_leitura_divergente" />
                <asp:BoundField DataField="seq_matricula" HeaderText="seq_matricula" 
                    SortExpression="seq_matricula" />
                <asp:BoundField DataField="ind_situacao_movimento" 
                    HeaderText="ind_situacao_movimento" SortExpression="ind_situacao_movimento" />
                <asp:BoundField DataField="seq_roteiro" HeaderText="seq_roteiro" 
                    SortExpression="seq_roteiro" />
                <asp:BoundField DataField="cod_referencia" HeaderText="cod_referencia" 
                    SortExpression="cod_referencia" />
                <asp:BoundField DataField="cod_agente" HeaderText="cod_agente" 
                    SortExpression="cod_agente" />
                <asp:BoundField DataField="cod_hidrometro" HeaderText="cod_hidrometro" 
                    SortExpression="cod_hidrometro" />
                <asp:BoundField DataField="val_numero_leituras" 
                    HeaderText="val_numero_leituras" SortExpression="val_numero_leituras" />
                <asp:BoundField DataField="dat_vencimento" HeaderText="dat_vencimento" 
                    SortExpression="dat_vencimento" />
                <asp:BoundField DataField="val_consumo_medio" HeaderText="val_consumo_medio" 
                    SortExpression="val_consumo_medio" />
                <asp:BoundField DataField="des_banco_debito" HeaderText="des_banco_debito" 
                    SortExpression="des_banco_debito" />
                <asp:BoundField DataField="des_banco_agencia_debito" 
                    HeaderText="des_banco_agencia_debito" 
                    SortExpression="des_banco_agencia_debito" />
                <asp:BoundField DataField="ind_entrega_especial" 
                    HeaderText="ind_entrega_especial" SortExpression="ind_entrega_especial" />
                <asp:BoundField DataField="dat_leitura_anterior" 
                    HeaderText="dat_leitura_anterior" SortExpression="dat_leitura_anterior" />
                <asp:BoundField DataField="dat_proxima_leitura" 
                    HeaderText="dat_proxima_leitura" SortExpression="dat_proxima_leitura" />
                <asp:BoundField DataField="val_leitura_anterior" 
                    HeaderText="val_leitura_anterior" SortExpression="val_leitura_anterior" />
                <asp:BoundField DataField="dat_troca" HeaderText="dat_troca" 
                    SortExpression="dat_troca" />
                <asp:BoundField DataField="val_consumo_troca" HeaderText="val_consumo_troca" 
                    SortExpression="val_consumo_troca" />
                <asp:BoundField DataField="val_quantidade_pendente" 
                    HeaderText="val_quantidade_pendente" SortExpression="val_quantidade_pendente" />
            </Columns>
        </asp:GridView>       
    </div>
    </form>
</body>
</html>
