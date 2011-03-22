 
 class ALexis
 {
   /*
	* Recupera os dados do formulario
	*
	*/
	function GetFormulario() {

		var url = "{";
		var form = document.getElementsByTagName("form")[0];
		//var obj = new {};
		var separador = "";
		elementosForm = form.getElementsByTagName("input");

		for (i = 0; i < elementosForm.length; i++) {
			//url = url + elementosForm[i].name + "=" + elementosForm[i].value + "&";
			url = url + separador + "\"" + elementosForm[i].name + "\":\"" + elementosForm[i].value + "\"";
			separador = ",";
		}

		elementosFormSelect = form.getElementsByTagName("select");

		for (i = 0; i < elementosFormSelect.length; i++) {
			//url = url + elementosFormSelect[i].name + "=" + elementosFormSelect[i].value + "&";
			url = url + separador + "\"" + elementosFormSelect[i].name + ":\"" + elementosFormSelect[i].value + "\"";
		}

		//Aqui chamamos nossa funcao do ''popup'' e passamos a nossa url montada
		return url+"}";
	}
		
	function confirmaInsert() {
        
            debugger;
            var numeroLinhas = document.getElementsByTagName('tr').length;
            for (var i = 0; i < numeroLinhas; i++) {
            
                if (i > 0) {
                    var linha = document.getElementsByTagName('tr')[i].cells[1].innerHTML;
                    var regex = /<input/;
                    var mach = regex.test(linha);
                    if (mach) {
                        var input = document.getElementsByTagName('tr')[i].cells[1].getElementsByTagName('input')[0];
                        var valor = input.value;
                    }
                }
            }
	}
	
	function marcaTabela() {
		var procurado = document.getElementById('TextLeituraAnterior').value;
		var numeroLinhas = document.getElementsByTagName('table')[3].rows.length;
		for (var i = 0; i < numeroLinhas; i++) {

			if (i > 0) {
				var valor = document.getElementsByTagName('table')[3].rows[i].cells[4].getElementsByTagName('span')[0].innerHTML;
				if (valor == procurado) {
					document.getElementsByTagName('table')[3].rows[i].cells[0].style.backgroundImage = "url('../images/btSequenciar.gif')"
				}
			}
		}
	}
	
	 
	/*
	* Ajax para atualizar os dados de ocorrencia
	*
	* @Param valor da ocorrencia
	*/
	function atualizaOcorrencia(valorOcorrencia) {

		document.getElementById('TextOcorrencia').value = valorOcorrencia;

		// Requsição ajax jquery
		$.ajax({
			type: "POST",
			url: "Critica.aspx/RetornaOcorrencia",
			data: JSON.stringify({ codOcorrencia: valorOcorrencia }),
			contentType: "application/json; charset=utf-8",
			dataType: "json",
			success: function(response) {

				// Convert o retorno para um objeto json
				if (response.d != "") {
					document.getElementById('LabelOcorrencia').innerHTML = response.d;
				}
			}
		});
	}
	
	
	
	/*
	* Recupera os dados do formulario
	*
	*/
	function RetornaObj() {

		exp = /\.|\-|\//g
		var IdContratante = document.getElementById("<%=hdfIdContratante.ClientID%>").value;
		var IdContrato = idContrato;
		var IdFiscEmp = document.getElementById("<%=hdfIdFiscEmp.ClientID%>").value;
		var DsRef = document.getElementById("<%=txtRef.ClientID%>").value;
		var PrExec = document.getElementById("<%=txbPrazo.ClientID%>").value;
		var DtInicio = document.getElementById("<%=txtDtInicio.ClientID%>").value;
		var DtFim = document.getElementById("<%=txtDtFim.ClientID%>").value;
		var DsObj = document.getElementById("<%=txtObj.ClientID%>").value;
		var VlContrato = document.getElementById("<%=txtValorContrato.ClientID%>").value;

		var FlNaoLocaliz = document.getElementById("<%=chkManual.ClientID%>").value;
		var TipoPessoa = document.getElementById("<%=ddlTipoPessoa.ClientID%>").value;
		var DsNome = document.getElementById("<%=txbNomeIns.ClientID%>").value;
		var DsRazao = document.getElementById("<%=txbRazaoIns.ClientID%>").value;
		var NrCpf = document.getElementById("<%=txbCpfIns.ClientID%>").value.toString().replace(exp, "");
		var NrCnpj = document.getElementById("<%=txbCnpjIns.ClientID%>").value.toString().replace(exp, "");
		var RgCrea = document.getElementById("<%=ddlRegiaoCreaIns.ClientID%>").value;
		var TpCrea = document.getElementById("<%=ddlTipoCreaIns.ClientID%>").value;
		var NrCrea = document.getElementById("<%=txbNumCreaEmpIns.ClientID%>").value;
		var StProf = document.getElementById("<%=hdfStProf.ClientID%>").value;
		var StProfFisc = document.getElementById("<%=lblStProf.ClientID%>").value;
		var DtConfProf = document.getElementById("<%=hdfDtConfProf.ClientID%>").value;

		var Local = document.getElementById("<%=txtLocal.ClientID%>").value;
		var StArtFisc = document.getElementById("<%=drpSitFiscArt.ClientID%>").value;
		var ObArtFisc = document.getElementById("<%=txbObs.ClientID%>").value;
		var ObContrato = document.getElementById("<%=txtObsContrato.ClientID%>").value;

		var objJSON = {
							"IdContratante": IdContratante
							, "IdContrato": IdContrato
							, "IdFiscEmp": IdFiscEmp
							, "DsRef": DsRef
							, "PrExec": PrExec
							, "DtInicio": DtInicio
							, "DtFim": DtFim
							, "DsObj": DsObj
							, "VlContrato": VlContrato
							, "FlNaoLocaliz": FlNaoLocaliz
							, "TipoPessoa": TipoPessoa
							, "DsNome": DsNome
							, "DsRazao": DsRazao
							, "NrCpf": NrCpf
							, "NrCnpj": NrCnpj
							, "RgCrea": RgCrea
							, "TpCrea": TpCrea
							, "NrCrea": NrCrea
							, "StProf": StProf
							, "StProfFisc": StProfFisc
							, "DtConfProf": DtConfProf
							, "Local": Local
							, "StArtFisc": StArtFisc
							, "ObArtFisc": ObArtFisc
							, "ObContrato": ObContrato
						};

		return objJSON;
	}

	/*
	* Ajax para para salvar os dados
	*
	* @Param valor do projeto
	*/
	function Salvar() {

		var resposta = confirm("Deseja salvar o registro?");
		var objetoModel = RetornaObj();
		if (resposta) {

			// Requsição ajax jquery
			$.ajax({
				type: "POST",
				url: "CadContratoEdit.aspx/Updater",
				data: JSON.stringify({ objetoModel: objetoModel }),
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function(response) {

					// Convert o retorno para um objeto json
					if (response.d == true) {
						alert("Registro foi atualizado com sucesso.");
					}
					else {
						alert("Registro não foi atualizado.");
					}
				}
			});
		}
	}
	
        
}	
