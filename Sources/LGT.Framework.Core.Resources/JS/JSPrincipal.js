var ERROR_MSG = "Ocorreu um erro no servidor ao tentar recuperar a informação, por favor tente novamente se o erro persistir informe o administrador do sistema.";

function IncludeJavaScript(jsFile) {
    document.write('<script type="text/javascript" src="' + jsFile + '"></scr' + 'ipt>');
}

function IncludeCSS(csFile) {
    document.write('<link href="' + csFile + '" rel="stylesheet" type="text/css" media="all" />');
}


$(document).ready(function () {
    //Aplica estilo em todos os botões
    $("input:submit").button();
    //aplica estilo nos chec
    $('input[type=checkbox], input[type=radio]').prettyCheckboxes();

});


function ExecuteAjaxCall(url, dataParam, isAssync, callBackSucess, callBackError) {
    $.ajax({
        type: "POST",
        url: url,
        data: dataParam,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        assync: isAssync,
        success: function (msg) {
            callBackSucess(msg);
        },
        error: function (msg) {
            callBackError(ERROR_MSG);
        }
    });
}