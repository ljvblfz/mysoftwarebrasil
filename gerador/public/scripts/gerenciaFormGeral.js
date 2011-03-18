/**
 * Função usada para esconder algum elemento ou varios informando os ids.
 * @param string e ids separados por virgula.
 */
/*
document.onkeypress = checkKeycode;
function checkKeycode(event) {
    var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
    if (keyCode == 13){ 
        //event.keyCode = 9;
        focus(tabIndex);
    }

}
function TABEnter(oEvent) {
    var oEvent = (oEvent) ? oEvent : event;
    var oTarget = (oEvent.target) ? oEvent.target : oEvent.srcElement;
    if (oEvent.keyCode == 13)
        oEvent.keyCode = 9;
        return event.keyCode 
    if (oTarget.type == "text" && oEvent.keyCode == 13)
        oEvent.keyCode = 9;
    if (oTarget.type == "radio" && oEvent.keyCode == 13)
        oEvent.keyCode = 9; 
        
} 
*/






/*document.onkeydown = checkKeycode*/
function checkKeycode(e) {
    var keycode;
    if (window.event) keycode = window.event.keyCode;
    else if (e) keycode = e.which;
    alert(keycode);
    if(keycode == 13){
        return event.keyCode = 9;
        void(0);
    }
}





/*for (i=0;i<document.forms[0].elements.length;i++){
    el = document.forms[0].elements[i];
    el.onkeypress = checkKeycode;
}*/