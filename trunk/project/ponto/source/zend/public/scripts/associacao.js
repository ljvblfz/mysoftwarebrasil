/**
* Seta o action do form para chamar a func&atilde;o selecionaTodos(), para enviar os dados do select multiplo
*
* @access public
* @return void 
**/
if(($$('form').size())>0){
    $$('form').first().writeAttribute('onsubmit','javascript:selecionaMultipleSelects();')
}
/**
* Associação dos requisitos
*
* @access public
* @return void 
**/
function transfere(origem,destino){
    var selecionado = $(origem).immediateDescendants().reject(function(o){
        if ($F(origem).indexOf(o.value) == -1){
            return true;
        }
    });

    selecionado.each(function(o){
        $(destino).insert(o);
    });
}

/**
* Seleciona todos os options do select multiplo
*
* @access public
* @return void 
**/
function selecionaMultipleSelects(){
    
    $$('.select_associacao').each(function(a){
        a.immediateDescendants().each(function(o){
                o.selected = true;
        });
    })

}