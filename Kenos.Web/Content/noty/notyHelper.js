function messageClear() {
    $.noty.closeAll();
}

function messageSuccess(text, options) {
    messageHelper(text, 'success', options);
}

function messageInformation(text, options) {
    messageHelper(text, 'information', options);
}

function messageWarning(text, options) {
    messageHelper(text, 'warning', options);
}

function messageErrorResult(errors) {
    var msg = "";
    var i = 0;

    for (i = 0; i < errors.length; i++) {
        msg += "> " + errors[i].ErrorMessage + "<br/>";
    }

    messageError(msg);
}

function messageConfirm(text, okFunction, options) {
    
    var defaultOptions =
    {
        modal: true,
        layout: 'center',
        buttons: 
        [
            {
                addClass: 'btn btn-primary',
                text: 'Aceptar',
                onClick: function ($noty) {
                    $noty.close();

                    okFunction.call(); 
                }
            },
            {
                addClass: 'btn btn-danger',
                text: 'Cancelar',
                onClick: function ($noty) {
                    $noty.close();
                }
            }
        ]
    };


    options = $.extend(defaultOptions, options);

    messageHelper(text, 'alert', options);
}

function messageInput(titulo, text2, onOkFunction, extraOptions) {

    var options = $.extend({ inputText: '' }, extraOptions);

    var html = "<div style=\"margin-top:15px;\" class=\"form\"><label>" + text2 + "</label><textarea id=\"txtNotyInput\" rows=\"15\" class=\"form-control\">" + options.inputText + "</textarea></div>";

    messageConfirm(titulo + html,
        function () {
            var inputText = $("#txtNotyInput").text();

            onOkFunction(inputText);
        },
        {
            layout: 'quimeyInputMessage',

        });
}

function messageError(text, options) {

    messageHelper(text, 'error', options);
}

function messageHelper(text, type, options) {
    messageClear();
    if (options == undefined)
        options = {};
    
    var defaultOptions =
        {
            type: type,
            modal: false,
            timeout: 1000 * 10,
            layout: 'bottomCenter',
            theme: 'kenos'
        };

    options['text'] = text;
    
    options = $.extend({}, defaultOptions, options);

    noty(options);
}