/**
* Ajax para retornar as cidades
* @access public
* @return void
**/
function carregaCidade(estado) {
    $('#idCidade.medTxtArea').attr("disabled", "disabled");

    $.ajax({
        type: "POST",
        url: "/default/cidade/getCidades",
        data: "name=" + estado,
        success: function (myOptions) {
            var dados = JSON.parse(myOptions);
            var options = $('#idCidade.medTxtArea').prop('options');
            options[options.length] = new Option('Selecione', '0', true, true);
            $.each(dados, function (val, text) {
                options[options.length] = new Option(text, val, false, false);
            });
        },
        erro: function (msg) {
            $('.right').html(msg);
        }
    });

    $('#idCidade.medTxtArea').attr("disabled", false);
}


/**
* Ajax para submeter dados do formulario
* @access public
* @return void
**/
function submitData(action,form) {

    $.ajax({
            url: action,
            type: 'POST',
            data: $('#' + form).serialize(),
            dataType: 'html',
            beforeSend: function(){
                    $('#loading').show();
            },          
            success: function(html) {
                alert(html);
            },
            erro: function (msg) {
                alert(msg);
            }
        });
}