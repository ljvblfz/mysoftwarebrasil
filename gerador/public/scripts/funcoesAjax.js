/**
 * setValueElementAjax
 * 
 * Seta valor ou conte�do para um elemento.
 *
 * @author Diego Oliveira
 * @param string|object el Id do elemento de destino ou o pr�prio elemento que sera modificado.
 * @param string valor Valor que ser� atribu�do ao elemento.
 * @return bool true caso tenha conseguido atribuir o valor, false se n�o.
 */
function setValueElementAjax(el, valor){
    // Verifica se o conte�do de 'el' � uma string, se for tenta recuperar o elemento. 
    if (Object.isString(el)){
        el = $(el);
    }

    // Verifica se o conte�do de 'el' � um elemento DOM da pagina, se for tenta alterar o valor, sen�o retorna false;
    if (Object.isElement(el)){
        // se consegue alterar o valor retorna true, sen�o retorna false;
        if (el.setValue) {
            el.setValue(valor);
            return true;
        } else if(el.update) {
            el.update(valor);
            return true
        } else {
            return false;
        }
    } else {
        return false;
    }
}


/**
 * insereMensagemValidacaoAjax
 * 
 * Insere mensagem de valida��o caso tenha sido retornada de uma requisi��o Ajax
 * 
 * @author Diego Oliveira
 * @param object objeto Objeto em JSON
 * @return int Retorna a quantidade de mensagens de erros que foram inseridas.
 */
function insereMensagemValidacaoAjax(objeto){
    // Template de valida��o
    var templateValidacao = new Template("<div class='#{classe}' id='#{id}_validacao'><p><label for='#{id}'>#{nome_label}:</label>#{mensagem}</p></div>");
    var erros = 0;

    // Verifica se foi enviado conte�do de valida��o para ser inserido na p�gina.
    if (objeto.validacao) {
        // Verifica se foi passada mensagem de valida��o.
        if (objeto.mensagem){
            if ($(objeto.id+'_validacao')) {
                $(objeto.id+'_validacao').remove();
            }

            // verifica o tipo de msg que ser� mostrada: mensagem de alerta ou mensagem de erro, mensagem de erro � a padr�o.
            switch(objeto.tipo){
                case 'alerta':
                    var css_class = 'validacao alert';
                break;
                case 'erro':
                    var css_class = 'validacao';
                break;
                default:
                    var css_class = 'validacao';
                break;
            }

            // Monta objeto que ser� usado para exibir a mensagem de valida��o.
            var show = {id:objeto.id, nome_label:objeto.nome_label, mensagem:objeto.mensagem, classe:css_class};

            // Insere a mensagem de valida��o acima do elemento que foi validado.
            $(objeto.id).up().insert({top:templateValidacao.evaluate(show)});
        } else {
            if ($(objeto.id+'_validacao')) {
                $(objeto.id+'_validacao').remove();
            }
        }
        erros++;
    } else {
        // Caso j� exista uma div de valida��o para o elemento verificado, esta � removida da p�gina.
        if ($(objeto.id+'_validacao')) {
            $(objeto.id+'_validacao').remove();
        }
    }

    // quantidade de erros inseridos
    return erros;
}

/**
 * preencheDadosPageAjax
 * 
 * Preenche um formul�rio html ou modifica conte�do de elementos de uma p�gina com os dados passados por parametro.
 * 
 * @author Diego Oliveira
 * @param string|array dados String com array contendo no minimo chaves id e valor em formato JSON ou um array com o mesmo fomato.
 * @return bool|string false se os dados passados n�o est�o no formato correto, ou string os dados passados via parametro mais o status da inser��o, se FALHOU ou est� OK.
 */
function preencheDadosPageAjax(dados){console.log(dados);
    if (Object.isString(dados)){
        //transforma a string em array de objetos objetos.
        var dados = dados.evalJSON();
    }

    // quantidade de erros inseridos
    var erros = 0;
    
    if(Object.isArray(dados)){
        // Interage com cada posi��o do array 'dados'
        dados.each(function(objeto){
            erros = insereMensagemValidacaoAjax(objeto);

            switch(objeto.type){
                case 'radio':
                    objeto.id = objeto.id+'_'+objeto.value;
                    if (setValueElementAjax(objeto.id, 1)){
                        //se deu tudo certo na atualiza��o do campo.
                        objeto.status = 'OK';
                    } else {
                        //se ocorreu algum erro na atualiza��o do campo ou n�o existe o elemento passado.
                        objeto.status = 'FALHOU';
                    }
                break;
                default:
                    if (setValueElementAjax(objeto.id,objeto.value)){
                        //se deu tudo certo na atualiza��o do campo.
                        objeto.status = 'OK';
                    } else {
                        //se ocorreu algum erro na atualiza��o do campo ou n�o existe o elemento passado.
                        objeto.status = 'FALHOU';
                    }
                break;
            }

            // Verifica se o elemento foi encontrado e o valor foi setado
            if (objeto.status == 'OK'){
                if (objeto.classe){
                    $(objeto.id).className = objeto.classe;
                }

                if (objeto.disabled){
                    $(objeto.id).disable();
                }
            }

        });

        // Se n�o teve nenhum erro de valida��o, retorna o objeto em formato JSON.
        if (!erros){
            return Object.toJSON(dados);
        } else {
            return false;
        }

    } else {
        return false;
    }
    
}