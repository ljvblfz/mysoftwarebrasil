// Criação da classe Cookie usando o objeto Class do prototypejs.
var Cookie = Class.create();  
Cookie.prototype = {  
    //construtor padrão  
    initialize: function() {  
           
    },  
    /*  
     * salva cookie no formato {chave}={valor};  
     */  
    setCookie: function(key, value) {  
        var the_cookie = key + "=" + value + "; path=/" ;  
        document.cookie = the_cookie;  
    },  
      
    /*  
     * retorna valor do cookie  
     */  
    getCookie: function (key) {   
        var search = key + "="  
        var returnvalue = "";  
        if (document.cookie.length > 0) {  
            offset = document.cookie.indexOf(search)  
            if (offset != -1) {   
                offset += search.length  
                end = document.cookie.indexOf(";", offset);  
                if (end == -1)  
                    end = document.cookie.length;  
                returnvalue=unescape(document.cookie.substring(offset, end))  
            }  
        }  
        return returnvalue;  
    }  
}



// Criação da classe Cookie usando o objeto Class do prototypejs.
var MenuTree = Class.create();  
MenuTree.prototype = {  
    //construtor da classe
    initialize: function(idMenu) { 
		var obj = this; 
        this.nomeCookie = 'menuTreeAberto';
        this.nomeClassAberto = 'menuNodeAberto';
        this.nomeClassFechado = 'menuNodeFechado';
        this.menu = idMenu;

        // captura todos elementos 'a' com classe '.menuNodeAberto' ou '.menuNodeFechado'
        var els_a = $(this.menu).getElementsBySelector('a.'+this.nomeClassAberto,'a.'+this.nomeClassFechado);

        // para cada elemento 'a' capturado é associado o evento click para alternar a visualização do menu
        els_a.each(function(el){
            $(el).observe('click',function(){
                // captura o elemento 'li' pai.
                var el_li = $(this).up('li');
                // alterna a propriedade display do estilo do elemento 'li' capturado.
                obj.alternaDisplayMenu(el_li);
            });
        });
    },
    
    /**
     * Insere o id do elemento li do menu aberto no cookie
     *
     * @param object el_li elemento 'li' a ser tratado
     * @return void
     */
    insereAberto: function(el_li) {
        var el_li = $(el_li);
        if (!el_li) {
        	return;
        }

        // instancia o objeto cookie
		var cookie = new Cookie();        
        // Captura o valor do cookie gravado;
        var vlr_cookie = cookie.getCookie(this.nomeCookie);

        // remove valor vazio se retornado
        vlr_cookie = vlr_cookie.split(',').without('');
        // insere o id do elemento no array de valor
        vlr_cookie.push(el_li.identify());
		
        // atualiza o cookie com novo valor
        cookie.setCookie(this.nomeCookie, vlr_cookie);  
    },

    /**
     * Remove o id do elemento li do menu fechado no cookie
     *
     * @param object el_li elemento 'li' a ser tratado
     * @return void
     */
    removeAberto: function(el_li) {
        var el_li = $(el_li);
        if (!el_li) {
        	return;
        }

        // instancia o objeto cookie
		var cookie = new Cookie();  
        // Captura o valor do cookie gravado;
        var vlr_cookie = cookie.getCookie(this.nomeCookie);
        // remove valor vazio se retornado
        vlr_cookie = vlr_cookie.split(',').without('');
        // remove o id do elemento no array de valor
        vlr_cookie = vlr_cookie.without(el_li.identify());

        // atualiza o cookie com novo valor
        cookie.setCookie(this.nomeCookie, vlr_cookie);  
    },

    /**
     * Alterna a propriedade display do estilo entre 'none' e 'block' do elemento 'li' passado e modifica a classe do elemento 'ul' filho.
     *
     * @param object el_li Elemento 'li' a ser tratado.
     * @param bool is_load 
     * @return void;
     */
    alternaDisplayMenu: function(el_li,isLoad){
        // captura o elemento 'li' passado passado.
        var el_li = $(el_li);
        
        if (!el_li) {
        	return;
        }

        // captura o elemento 'ul' filho.
        var ul_filho = el_li.down('ul');

        // alterna a propriedade display do estilo entre 'none' e 'block'
        if (ul_filho.getStyle('display') == 'none'){ // status aberto
            ul_filho.setStyle({display:'block'});
			
			if(!isLoad){
	            // insere o id do elemento aberto no cookie
	            this.insereAberto(el_li);
            }
            
            // troca a classe do li para mudar a imagem.
            el_li.removeClassName(this.nomeClassFechado).addClassName(this.nomeClassAberto);

			// captura o elemento 'a' filho de li e altera a classe para mudar a imagem
			el_a_filho = el_li.down('a');
            el_a_filho.removeClassName(this.nomeClassFechado).addClassName(this.nomeClassAberto);
			
        } else { // status fechado
            ul_filho.setStyle({display:'none'});
			
			if(!isLoad){
            	// remove o id do elemento fechado no cookie
            	this.removeAberto(el_li);
			}
			
            // troca a classe do li para mudar a imagem.
            el_li.removeClassName(this.nomeClassAberto).addClassName(this.nomeClassFechado);

			// captura o elemento 'a' filho de li e altera a classe para mudar a imagem
			el_a_filho = el_li.down('a');
            el_a_filho.removeClassName(this.nomeClassAberto).addClassName(this.nomeClassFechado);
        }
    },

    /**
     * Abre o menu no estado como foi deixado pelo usuário
     *
     * @return void
     */
    abrirMenu: function(){
    	var obj = this;

        // instancia o objeto cookie
    	var cookie = new Cookie(); 
        var vlr_cookie = cookie.getCookie(this.nomeCookie);  
        vlr_cookie = vlr_cookie.split(',');
        vlr_cookie = vlr_cookie.without('');
		
        vlr_cookie.each(function(el_li){
            obj.alternaDisplayMenu(el_li,true);
        });
    }
}