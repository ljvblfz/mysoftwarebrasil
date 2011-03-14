/*
* 
*
*/

function confirmaInsert() {
    //debugger;
    var teste = $.msgbox("Deseja Inserir o registro?", {type: "confirm",
                                                            buttons: [
                                                                        { type: "submit", value: "Yes" },
                                                                        { type: "cancel", value: "No" },
                                                                        { type: "cancel", value: "Cancel" }
                                                                      ]
                                            }, function (result) {
                                                return result;
                                            }
                    );
                                           
    var c = 0;
}

function mensagem(mens) {

    $.msgbox(mens);

}

function informacao(mens) {

    $.msgbox(mens, { type: "info" });

}

function erro(mesns) {

    $.msgbox(mesns, { type: "error" });


}

function form() {

    $.msgbox("Insert your name below:", {
        type: "prompt"
    }, function (result) {
        if (result) {
            alert("Hello " + result);
        }
    });

}

function advance() {

    $("#advancedexample1").click(function () {
        $.msgbox("<p>In order to process your request you must provide the following:</p>", {
            type: "prompt",
            inputs: [
      { type: "text", label: "Insert your Name:", value: "George", required: true },
      { type: "password", label: "Insert your Password:", required: true }
    ],
            buttons: [
      { type: "submit", value: "OK" },
      { type: "cancel", value: "Exit" }
    ]
        }, function (name, password) {
            if (name) {
                $.msgbox("Hello <strong>" + name + "</strong>, your password is <strong>" + password + "</strong>.", { type: "info" });
            } else {
                $.msgbox("Bye!", { type: "info" });
            }
        });
    });

}