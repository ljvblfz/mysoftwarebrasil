/**
 * setValueElementAjax
 * 
 * Seta valor ou conteúdo para um elemento.
 *
 * @author Diego Oliveira
 * @param string|object el Id do elemento de destino ou o próprio elemento que sera modificado.
 * @param string valor Valor que será atribuído ao elemento.
 * @return bool true caso tenha conseguido atribuir o valor, false se não.
 */
function setValueElementAjax(el, valor){
    // Verifica se o conteúdo de 'el' é uma string, se for tenta recuperar o elemento. 
    if (Object.isString(el)){
        el = $(el);
    }

    // Verifica se o conteúdo de 'el' é um elemento DOM da pagina, se for tenta alterar o valor, senão retorna false;
    if (Object.isElement(el)){
        // se consegue alterar o valor retorna true, senão retorna false;
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
 * Insere mensagem de validação caso tenha sido retornada de uma requisição Ajax
 * 
 * @author Diego Oliveira
 * @param object objeto Objeto em JSON
 * @return int Retorna a quantidade de mensagens de erros que foram inseridas.
 */
function insereMensagemValidacaoAjax(objeto){
    // Template de validação
    var templateValidacao = new Template("<div class='#{classe}' id='#{id}_validacao'><p><label for='#{id}'>#{nome_label}:</label>#{mensagem}</p></div>");
    var erros = 0;

    // Verifica se foi enviado conteúdo de validação para ser inserido na página.
    if (objeto.validacao) {
        // Verifica se foi passada mensagem de validação.
        if (objeto.mensagem){
            if ($(objeto.id+'_validacao')) {
                $(objeto.id+'_validacao').remove();
            }

            // verifica o tipo de msg que será mostrada: mensagem de alerta ou mensagem de erro, mensagem de erro é a padrão.
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

            // Monta objeto que será usado para exibir a mensagem de validação.
            var show = {id:objeto.id, nome_label:objeto.nome_label, mensagem:objeto.mensagem, classe:css_class};

            // Insere a mensagem de validação acima do elemento que foi validado.
            $(objeto.id).up().insert({top:templateValidacao.evaluate(show)});
        } else {
            if ($(objeto.id+'_validacao')) {
                $(objeto.id+'_validacao').remove();
            }
        }
        erros++;
    } else {
        // Caso já exista uma div de validação para o elemento verificado, esta é removida da página.
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
 * Preenche um formulário html ou modifica conteúdo de elementos de uma página com os dados passados por parametro.
 * 
 * @author Diego Oliveira
 * @param string|array dados String com array contendo no minimo chaves id e valor em formato JSON ou um array com o mesmo fomato.
 * @return bool|string false se os dados passados não estão no formato correto, ou string os dados passados via parametro mais o status da inserção, se FALHOU ou está OK.
 */
function preencheDadosPageAjax(dados){console.log(dados);
    if (Object.isString(dados)){
        //transforma a string em array de objetos objetos.
        var dados = dados.evalJSON();
    }

    // quantidade de erros inseridos
    var erros = 0;
    
    if(Object.isArray(dados)){
        // Interage com cada posição do array 'dados'
        dados.each(function(objeto){
            erros = insereMensagemValidacaoAjax(objeto);

            switch(objeto.type){
                case 'radio':
                    objeto.id = objeto.id+'_'+objeto.value;
                    if (setValueElementAjax(objeto.id, 1)){
                        //se deu tudo certo na atualização do campo.
                        objeto.status = 'OK';
                    } else {
                        //se ocorreu algum erro na atualização do campo ou não existe o elemento passado.
                        objeto.status = 'FALHOU';
                    }
                break;
                default:
                    if (setValueElementAjax(objeto.id,objeto.value)){
                        //se deu tudo certo na atualização do campo.
                        objeto.status = 'OK';
                    } else {
                        //se ocorreu algum erro na atualização do campo ou não existe o elemento passado.
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

        // Se não teve nenhum erro de validação, retorna o objeto em formato JSON.
        if (!erros){
            return Object.toJSON(dados);
        } else {
            return false;
        }

    } else {
        return false;
    }
    
}