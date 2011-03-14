
/*
 * Permite apenas numeros
 */
function OnlyNumber(evt) {
    evt = (evt) ? evt : window.event
    var charCode = (evt.which) ? evt.which : evt.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode != 44) {
        status = "This field accepts numbers only."
        return false
    }
    status = ""
    return true
}

/*
* Permite apenas letras
*/
function OnlyAlpha(valor) {
    var expressao;
    expressao = /[a-zA-Z]/;
    var string = valor; //String.fromCharCode(e.keyCode);
    
    //if (expressao.test(String.fromCharCode(e.keyCode))) {
    if (expressao.test(string)) {
        return valor;
    }
    else {
        return "";
    }
}

/**
* completaZeros
*
* Recebe um valor de número e o coloca divisões de milhar e o retorna
*
* @param String num_original String com o valor a ser modificado
* @param Int quant Quantidade de zeros a ser completados
* @return String valor formatado
*/
function completaZeros(num_original, quant) {
    var num_ideal = num_original.replace(/\./gi, ''); // retira pontos
    var num_part = num_ideal.split(','); // divide o número
    var parte_inteira = num_part[0];
    var parte_decimal = '';
    for (var i = num_part.length - 1; i > 0; i--) { // verifica se o número contem parte decimal
        parte_decimal = num_part[i] + parte_decimal;
    }
    if (parte_decimal != '' || parte_inteira.charAt(parte_inteira.length - 1) != ',') {
        if (parte_decimal.length <= quant) { // tem que acrescentar zeros
            var tamanho_exc = quant - parte_decimal.length;
            for (var j = tamanho_exc; j > 0; j--) {
                parte_decimal = parte_decimal + '0';
            }
        } else {
            parte_decimal = parte_decimal.substr(0, quant);
        }
        parte_inteira = num_original.split(',')[0];
        if (parte_inteira != '') {
            var num_ideal = parte_inteira + ',' + parte_decimal;
        }
    }
    return num_ideal;
}

/**
* formataMilhar
*
* Recebe um valor de número e o coloca divisões de milhar e o retorna
*
* @param String num_original  String com o valor a ser formatado
* @return String valor formatado
*/
function formataMilhar(num_original, casas_decimais) {
    num_original = num_original.replace(/[^0123456789\,]/g, '');
    if (casas_decimais) {
        num_original = completaZeros(num_original, casas_decimais);
    }
    var num_ideal = num_original.replace(/\./g, ''); // retira pontos

    if (num_ideal.charAt(num_ideal.length - 1) != ',') {
        num_ideal = num_ideal.replace(/\,/g, '.'); // troca virgula por ponto
    }

    var num_part = num_ideal.split('.'); // divide o número
    var parte_inteira = num_part[0];
    var parte_decimal = '';
    for (var i = num_part.length - 1; i > 0; i--) { // verifica se o número contem parte decimal
        parte_decimal = num_part[i] + parte_decimal;
    }
    var num_aux_1 = ''; // o numero final será armazenado nessa variável
    var num_aux_2 = '';

    var comp = '';
    if (parte_inteira) {
        if (parte_inteira.charAt(parte_inteira.length - 1) == ',') {
            parte_inteira = parte_inteira.substr(0, parte_inteira.length - 1);
            comp = ',';
        }

        for (var i = (parte_inteira.length - 1); i > -1; i--) {
            num_aux_1 = parte_inteira.charAt(i) + num_aux_1; //número parcial sem ponto
            num_aux_2 = parte_inteira.charAt(i) + num_aux_2; //número parcial já com ponto
            if ((Number(num_aux_2.length) % 3) == 0) { // verifica se está na posição de onde coloca ponto
                if (i > 0) { // verifica se não é o ultimo número
                    num_aux_1 = '.' + num_aux_1; // adiciona ponto no número
                }
            }
        }
    }
    num_aux_1 = num_aux_1 + comp;
    if (parte_decimal != '') { // verifica se existe parte decimal

        num_aux_1 = num_aux_1 + ',' + parte_decimal; // adiciona vírgula na separação decimal do número.
    }
    return num_aux_1;
}

// formata valor
function formataValor(objeto, evento, casasDecimais) {
    if (!casasDecimais) {
        var casasDecimais = 2;
    }

    mascaraNumero = '###.###.###.###,';
    for (i = 0; i < casasDecimais; i++) {
        mascaraNumero = mascaraNumero + '#';
    }
    return mascara(objeto, evento, mascaraNumero, true);
}
/**  
* Função para aplicar máscara em campos de texto
* Copyright (c) 2008, Dirceu Bimonti Ivo - http://www.bimonti.net 
* All rights reserved. 
* @constructor  
*/
/* Version 0.27 */
/**  
* Função Principal 
* @param w - O elemento que será aplicado (normalmente this).
* @param e - O evento para capturar a tecla e cancelar o backspace.
* @param m - A máscara a ser aplicada.
* @param r - Se a máscara deve ser aplicada da direita para a esquerda. Veja Exemplos.
* @param a - 
* @returns null  
*/
function mascara(w, e, m, r, a) {

    // Cancela se o evento for Backspace
    if (!e) var e = window.event
    if (e.keyCode) code = e.keyCode;
    else if (e.which) code = e.which;

    // Variáveis da função
    var txt = (!r) ? w.value.replace(/[^\d]+/gi, '') : w.value.replace(/[^\d]+/gi, '').reverse();
    var mask = (!r) ? m : m.reverse();
    var pre = (a) ? a.pre : "";
    var pos = (a) ? a.pos : "";
    var ret = "";

    if (code == 9 || code == 8 || txt.length == mask.replace(/[^#]+/g, '').length) return false;

    // Loop na máscara para aplicar os caracteres
    for (var x = 0, y = 0, z = mask.length; x < z && y < txt.length; ) {
        if (mask.charAt(x) != '#') {
            ret += mask.charAt(x); x++;
        } else {
            ret += txt.charAt(y); y++; x++;
        }
    }

    // Retorno da função
    ret = (!r) ? ret : ret.reverse()
    w.value = pre + ret + pos;
}

// Novo método para o objeto 'String'
String.prototype.reverse = function() {
    return this.split('').reverse().join('');
};

// Formata o campo valor
function mascaraMonetaria(event, objeto) {
    var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
    if (keyCode >= 48 && keyCode <= 57) {
        with (objeto) {
            value = value.replace(/[^0123456789]/g, '');
            tam = value.length;
            //alert(value);
            if (tam > 1) {
                value = value.substr(0, tam - 1) + ',' + value.substr(tam - 1, tam);
            }
        }
    } else if ((keyCode == 8) || (keyCode == 13) || (keyCode >= 35 && keyCode <= 39) || (keyCode == 46)) {
        return true;
    }
    else {
        keyCode = 0;
        return false;
    }
}

// limpa todos os caracteres especiais do campo solicitado
function filtraCampo(campo) {
    var s = "";
    var cp = "";
    vr = campo.value;
    tam = vr.length;
    for (i = 0; i < tam; i++) {
        if (vr.substring(i, i + 1) != "/" && vr.substring(i, i + 1) != "-" && vr.substring(i, i + 1) != "." && vr.substring(i, i + 1) != ",") {
            s = s + vr.substring(i, i + 1);
        }
    }
    campo.value = s;
    return cp = campo.value
}

// Formata data no padrão DDMMAAAA
function formataData(campo) {
    //campo.value = filtraCampo(campo);
    vr = campo.value;
    vr = vr.replace(/[^0123456789]/g, '');
    tam = vr.length;

    if (tam > 2 && tam < 5) {
        campo.value = vr.substr(0, tam - 2) + '/' + vr.substr(tam - 2, tam);
    }
    if (tam >= 5 && tam <= 10) {
        campo.value = vr.substr(0, 2) + '/' + vr.substr(2, 2) + '/' + vr.substr(4, 4);
    }
}

// Formata data no padrão DDMMAAAA e a hora no padrão HHMM
function formataDataHora(campo) {
    vr = campo.value;
    vr = vr.replace(/[^0123456789]/g, '');
    tam = vr.length;

    if (tam > 2 && tam < 5) {
        campo.value = vr.substr(0, tam - 2) + '/' + vr.substr(tam - 2, tam);
    }

    if (tam >= 5 && tam <= 10) {
        campo.value = vr.substr(0, 2) + '/' + vr.substr(2, 2) + '/' + vr.substr(4, 4);
    }

    if (tam >= 9 && tam <= 15) {
        campo.value = vr.substr(0, 2) + '/' + vr.substr(2, 2) + '/' + vr.substr(4, 4) + ' ' + vr.substr(8, 2) + ':' + vr.substr(10, 2);
    }
}

function seleciona(objeto, inicio, fim) {
    var tamanho = objeto.value.length;
    objeto.selectionStart = (inicio != null ? inicio : tamanho);
    objeto.selectionEnd = (fim != null ? fim : tamanho);
}

//VALIDAÇÃO DA DATA

function VerificaData(digData) {
    var bissexto = 0;
    var data = digData;
    var tam = data.length;
    if (tam == 10) {
        var dia = data.substr(0, 2)
        var mes = data.substr(3, 2)
        var ano = data.substr(6, 4)
        if ((ano > 1900) || (ano < 2100)) {
            switch (mes) {
                case '01':
                case '03':
                case '05':
                case '07':
                case '08':
                case '10':
                case '12':
                    if (dia <= 31) {
                        return true;
                    }
                    break

                case '04':
                case '06':
                case '09':
                case '11':
                    if (dia <= 30) {
                        return true;
                    }
                    break
                case '02':
                    /* Validando ano Bissexto / fevereiro / dia */
                    if ((ano % 4 == 0) || (ano % 100 == 0) || (ano % 400 == 0)) {
                        bissexto = 1;
                    }
                    if ((bissexto == 1) && (dia <= 29)) {
                        return true;
                    }
                    if ((bissexto != 1) && (dia <= 28)) {
                        return true;
                    }
                    break
            }
        }
    }
    alert("A Data " + data + " é inválida!");
    return false;
}