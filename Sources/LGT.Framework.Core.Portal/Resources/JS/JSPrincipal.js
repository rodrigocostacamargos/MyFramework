/*Inicio do Recurso LGT.Framework.Core.Resources.JS.UI.prettyCheckboxes.js*/ 
 /* ------------------------------------------------------------------------
prettyCheckboxes
	
Developped By: Stephane Caron (http://www.no-margin-for-errors.com)
Inspired By: All the non user friendly custom checkboxes solutions ;)
Version: 1.1
	
Copyright: Feel free to redistribute the script/modify it, as
long as you leave my infos at the top.
------------------------------------------------------------------------- */

jQuery.fn.prettyCheckboxes = function (a) { a = jQuery.extend({ checkboxWidth: 17, checkboxHeight: 17, className: "prettyCheckbox", display: "list" }, a); $(this).each(function () { $label = $('label[for="' + $(this).attr("id") + '"]'); $label.prepend("<span class='holderWrap'><span class='holder'></span></span>"); if ($(this).is(":checked")) { $label.addClass("checked") } $label.addClass(a.className).addClass($(this).attr("type")).addClass(a.display); $label.find("span.holderWrap").width(a.checkboxWidth).height(a.checkboxHeight); $label.find("span.holder").width(a.checkboxWidth); $(this).addClass("hiddenCheckbox"); $label.bind("click", function () { $("input#" + $(this).attr("for")).triggerHandler("click"); if ($("input#" + $(this).attr("for")).is(":checkbox")) { $(this).toggleClass("checked"); $("input#" + $(this).attr("for")).checked = true; $(this).find("span.holder").css("top", 0) } else { $toCheck = $("input#" + $(this).attr("for")); $('input[name="' + $toCheck.attr("name") + '"]').each(function () { $('label[for="' + $(this).attr("id") + '"]').removeClass("checked") }); $(this).addClass("checked"); $toCheck.checked = true } }); $("input#" + $label.attr("for")).bind("keypress", function (b) { if (b.keyCode == 32) { if ($.browser.msie) { $('label[for="' + $(this).attr("id") + '"]').toggleClass("checked") } else { $(this).trigger("click") } return false } }) }) }; checkAllPrettyCheckboxes = function (b, a) { if ($(b).is(":checked")) { $(a).find("input[type=checkbox]:not(:checked)").each(function () { $('label[for="' + $(this).attr("id") + '"]').trigger("click"); if ($.browser.msie) { $(this).attr("checked", "checked") } else { $(this).trigger("click") } }) } else { $(a).find("input[type=checkbox]:checked").each(function () { $('label[for="' + $(this).attr("id") + '"]').trigger("click"); if ($.browser.msie) { $(this).attr("checked", "") } else { $(this).trigger("click") } }) } };  
 /*Fim do Recurso LGT.Framework.Core.Resources.JS.UI.prettyCheckboxes.js*/

/*Inicio do Recurso LGT.Framework.Core.Resources.JS.JSPrincipal.js*/ 
 var ERROR_MSG = "Ocorreu um erro no servidor ao tentar recuperar a informa��o, por favor tente novamente se o erro persistir informe o administrador do sistema.";

function IncludeJavaScript(jsFile) {
    document.write('<script type="text/javascript" src="' + jsFile + '"></scr' + 'ipt>');
}

function IncludeCSS(csFile) {
    document.write('<link href="' + csFile + '" rel="stylesheet" type="text/css" media="all" />');
}


$(document).ready(function () {
    //Aplica estilo em todos os bot�es
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
 /*Fim do Recurso LGT.Framework.Core.Resources.JS.JSPrincipal.js*/

