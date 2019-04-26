
/************************/
/*  Ajax                */
/************************/

var _ajaxLoadingStatus = false;

//AJAX global setup
$.ajaxSetup({
    cache: false
});

$(document).ajaxStart(function () {
    console.log('ajaxStart');
    if (_ajaxLoadingStatus)
        return;

    _ajaxLoadingStatus = true;

    setTimeout(function () {
        console.log('ajaxStart.blockui');
        if (_ajaxLoadingStatus) {
            $.kenosBlockUI();
        }
        _ajaxLoadingStatus = false;
    }, 1000);

});

$(document).ajaxStop(function () {

    console.log('ajaxStop');
    $.kenosUnblockUI();
    _ajaxLoadingStatus = false;
});

$(document).ajaxError(function (event, jqxhr, settings, exception) {
    $.kenosUnblockUI();

    if (jqxhr.status == 401) {
        messageError("No tiene autorización para realizar esta operación");
    }
    else {
        messageError(
            jqxhr.statusText + "(" + jqxhr.status + ")",
            jqxhr.responseText);
    }
});


/************************/
/*  checked             */
/************************/
(function ($) {
    $.fn.checked = function (value) {
        if (value != undefined)
            this.prop("checked", value);

        return this.is(":checked");
    };
})(jQuery);


(function ($) {
    $.fn.goToElement = function () {
        this[0].scrollIntoView(true);
    }
})(jQuery);

/************************/
/*  kenosLoad          */
/************************/
(function ($) {
    $.fn.kenosLoad = function (url, params, onsuccess, extraOptions) {

        if (params == '')
            params = null;

        var options = $.extend({
            blockUI: true
        }, extraOptions);


        if (!options.blockUI)
            _ajaxLoadingStatus = true;

        $(this).load(
			url,
			params,
			onsuccess);
    };
})(jQuery);

/************************/
/*  kenosBlockUI       */
/************************/
(function ($) {
    $.kenosBlockUI = function () {

        $.blockUI({
            message: "<h2>Procesando...</h2>",
            css: {
                border: 'none',
                padding: '15px',
                backgroundColor: '#585858',
                '-webkit-border-radius': '10px',
                '-moz-border-radius': '10px',
                'border-radius': '10px',
                opacity: 1,
                color: '#fff',
                width: '30%',
                minWidth: '250px',
                _Width: '250px'
            },
            overlayCSS: { backgroundColor: '#CBCBCB' }
        });

    };


    $.kenosUnblockUI = function () {

        $.unblockUI();
    }

})(jQuery);

/************************/
/*  kenosAjax          */
/************************/
(function ($) {
    // Data post function
    $.kenosAjax = function (url, param, onSuccess, onError, extraOptions) {

        var options = $.extend({
            async: true,
            isHtmlResponse: false,
            blockUI: true
        }, extraOptions);


        if (!options.blockUI)
            _ajaxLoadingStatus = true;
       
        messageClear();


        // Post data using AJAX
        $.ajax({
            type: "POST",
            async: options.async,
            url: url,
            traditional: true,
            data: JSON.stringify(param),
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (options.isHtmlResponse || data.IsSuccess) {
                    if (onSuccess != null) onSuccess(data);

                    if (data.Redirect != undefined && data.Redirect != "")
                        $.kenosRedirect(data.Redirect);
                }
                else {
                    messageError(data.Message);

                    if (onError != null) onError(data);

                    if (data.Redirect != undefined && data.Redirect != "")
                        $.kenosRedirect(data.Redirect);
                }
            }
        });
    }
})(jQuery);

/************************/
/*  kenosRedirect      */
/************************/
(function ($) {
    $.kenosRedirect = function (url) {

        var isInIframe = (window.location != window.parent.location) ? true : false;
        var win = window;

        if (isInIframe)
            win = parent.window;

        win.location.replace(url);
    }

})(jQuery);


