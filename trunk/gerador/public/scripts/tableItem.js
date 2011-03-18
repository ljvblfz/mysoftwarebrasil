/**
 * Remove uma linha de uma tabela de itens, tabela identificado pelo id passado por parâmetro
 *
 * @name removeField 
 * @access public
 * @return void
 */ 
function removeField(idTabela,campo){
    var linha = campo.parentNode.parentNode;
    var elTable = document.getElementById(idTabela);
    var elTr = elTable.getElementsByTagName('tr');
    var indice = (elTr.length - 1);
    
    if(elTr[indice].id != linha.id && elTr[indice-1].id != linha.id){
        linha.parentNode.removeChild(linha);
    } 
}

/**
 * Copia a última linha da tabela de itens e cria uma nova linha.
 *
 * @name cloneField 
 * @access public
 * @return void
 */ 
function cloneField(idTabela,campo){
    var linha = campo.parentNode.parentNode;
    var elTable = document.getElementById(idTabela);
    var elTr = elTable.getElementsByTagName('tr');
    var indice = (elTr.length - 1);
    
    if(elTr[indice].id == linha.id || elTr[indice-1].id == linha.id){ 
        
        var fieldClone =  elTr[indice].cloneNode(true);    
        var id = fieldClone.id;
        var idAux = id.split('_');
        var indiceUltimo = idAux[1];
        var indiceNovo = Number(indiceUltimo) + Number(1);
        fieldClone.id = idAux[0]+'_'+indiceNovo;
        var td = fieldClone.getElementsByTagName('td');
    
        for(i=0;i<td.length;i++){
            var tdChild = td[i].childNodes;
            for(j=0;j<tdChild.length;j++){
                //Limpa os valores da nova linha
                tdChild[j].value = '';
                
                //substitui o indice dos nomes dos campos
                var nameAux = (tdChild[j].name).replace(indiceUltimo,indiceNovo);
                tdChild[j].name = nameAux;
                
                //substitui o indice dos ids dos campos
                var idAux = (tdChild[j].id).replace(indiceUltimo,indiceNovo);
                tdChild[j].id = idAux;
            }
        }   
       
        var childElTable = elTable.getElementsByTagName('tbody');
        childElTable[0].appendChild(fieldClone);
    }
}