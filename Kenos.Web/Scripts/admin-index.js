
var _currentInstance = null;

function attachAdminIndexEvents() {
    var divDetalle = $("#divDetalle");
    
    divDetalle.hide();

    updateListIntancias();

    $('#divDetalle .btn-status').click(function () {
        ping();
    });

    $('#divDetalle .btn-isrunning').click(function () {
        isRunning();
    });

    $('#btnXml').click(function () {
        var url = replaceUrlParam(URLs.verXml, "nombreInstancia", _currentInstance);

        window.open(url);
    });

    $('#divOpciones a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        if (e.target.hash == '#tabXml') {            
        }

        if (e.target.hash == '#tabConfig') {
            leerConfig();
        }
        
        if (e.target.hash == '#tabUpdate') {
            tabUpdate();
        }        
    })

    limpiar();

    var usuario = $.cookie("kenos-usuario");

    if (usuario != null) {
        $('#txtUsuario').val(usuario);
    }
}

function mostrarDetalle() {

    var instancia = _currentInstance;

    limpiar();

    var divDetalle = $("#divDetalle");
    
    $('.nombre-instancia').text(instancia);

    var model = { nombreInstancia: instancia };

    $.kenosAjax(
        URLs.ver,
        model,
        function (result) {
            divDetalle.find('.version').text(result.Data.version);
            divDetalle.find('.assembly').text(result.Data.assemblyName);
            divDetalle.find('.ip').text(result.Data.ip);
            divDetalle.find('.path').text(result.Data.path);
            divDetalle.find('.fecha').text(result.Data.fecha);
            divDetalle.find('.status').text('-');

            divDetalle.show();

            divDetalle.goToElement();

            ping();
        });
}

function tabUpdate() {

    var tab = $("#tabUpdate");

    if (tab.data('iniciado') === '1')
        return;    

    var model = getInstanciaModel();

    if (model == null)
        return;

    tab.kenosLoad(
        URLs.tabUpdate, 
        model, 
        function (response) {
            tab.data('iniciado', '1');

            cargarArchivosDestino();

            $('#ddlRelease').change(function () {
                var ddlVersion = $('#ddlVersion');

                if (ddlVersion.val() != '')
                    cargarArchivos();
            });

            $('#ddlVersion').change(function () {
                cargarArchivos();
            });

            $('#btnActualizar').click(actualizar);

            initInvertirSeleccion();
        },
        function () { },
        {
            blockUI: false

        });
}

function ping() {
    var model = {nombreInstancia:_currentInstance};
    var divDetalle = $("#divDetalle");
    var status = divDetalle.find('.status');
    status.html('consultando...');

    $.kenosAjax(
       URLs.ping,
       model,
       function (result) {
           status.html('');

           var host = $('<span>');
           host.addClass('label')

           host.text(result.Data);

           if (result.Data === 'Prendido') {
               host.addClass('label-success');
           }
           else {
               host.addClass('label-danger');
           }

           status.append(host);

       }, 
       null,
       {
           blockUI:false
       });
}

function isRunning() {
    var model = getInstanciaModel();

    var divDetalle = $("#divDetalle");
    var running = divDetalle.find('.isrunning');
    running.html('consultando...');

    $.kenosAjax(
       URLs.isRunning,
       model,
       function (result) {
           running.html('');

           var span = $('<span>');

           span.addClass('label')
           span.text(result.Data);

           if (result.Data === 'Corriendo') {
               span.addClass('label-danger');
           }
           else {
               span.addClass('label-success');
           }

           running.append(span);

       },
       null,
       {
           blockUI: false
       });
}

function leerConfig() {
    
    var model = getInstanciaModel();
    var url = URLs.leerConfig;

    if (model == null)
        return;

    var tab = $("#tabConfig");

    if (tab.data('iniciado') == '1')
        return;

    var div = $('#appConfig');

    div.text('Cargando...');

    $.kenosAjax(
       url,
       model,
       function (result) {
           div.text(result.Data);

           tab.data('iniciado', '1');
       });
}

function limpiar() {
    $('.isrunning').text('');

    $("#tabConfig").data('iniciado', '0');
    $('#appConfig').html('');

    $('#tabVersionActualSelector').tab('show');

    $("#tabUpdate").data('iniciado', '0');
}

function initInvertirSeleccion() {
    var btn = $('.btn-invertir-archivos');
    
    btn.click(function () {

        var list = $('#listArchivosNuevos');

        list.find('li').each(function (idx, obj) {
            var li = $(obj);
            var chk = li.find('input[type="checkbox"]');
            var lbl = li.find('label');

            if (lbl.text().indexOf('.exe.config') < 0)
                chk.checked(!chk.checked());
        });

    });

    btn.hide();
}

function getInstanciaModel() {

    var model = getCredenciales();
    
    if (model != null)
    {
        model.NombreInstancia = _currentInstance;
    }

    return model;
}

function getCredenciales() {

    var model = {

        Dominio: $.trim($('#txtDominio').val()),
        Usuario: $.trim($('#txtUsuario').val()),
        Password: $.trim($('#txtPassword').val())
    };

    if (model.Dominio === '') {
        messageError('Debe completar el Dominio');
        model = null;
    }
    else if (model.Usuario === '') {
        messageError('Debe completar el Usuario');
        model = null;
    }
    else if (model.Password === '') {
        messageError('Debe completar el Password');
        model = null;
    }

    if (model != null) {
        $.cookie("kenos-usuario", model.Usuario, { expires: 40 });
    }   

    return model;
}

function cargarArchivos() {
    var model = getCredenciales();

    if (model == null)
        return;

    model.Release = $('#ddlRelease').val();
    model.Version = $('#ddlVersion').val();

    var list = $('#listArchivosNuevos');

    list.find('li').remove();

    $.kenosAjax(
        URLs.listarArchivos, 
        model, 
        function (response) {

            for (var i = 0; i < response.Data.length; i++) {

                var item = response.Data[i];
                var checked = 'checked';

                if (item.indexOf('.exe.config')>0) {
                    checked = '';
                }

                var li = $('<li></li>');
                var chkId = "chkFile_" + i;
                var chk = $('<input id="' + chkId + '" type="checkbox" ' + checked + '>');
                var span = $('<label for="' + chkId + '"></label>');

                span.text(item);

                li.append(chk);
                li.append(span);
                list.append(li);
            }

            $('.btn-invertir-archivos').show();
        }, 
        function () { },
        {
            blockUI: false
        });

}

function cargarArchivosDestino() {
    
    var model = getInstanciaModel();

    if (model == null)
        return;

    var list = $('#listArchivosDestino');

    list.find('li').remove();

    var procesando = $('<li>Cargando archivos...</li>');

    list.append(procesando);

    $.kenosAjax(
        URLs.listarArchivosDestino,
        model,
        function (response) {
            if (response.IsSuccess) {

                procesando.remove();

                for (var i = 0; i < response.Data.length; i++) {

                    var item = response.Data[i];
                    var li = $('<li></li>');
                    var span = $('<label></label>');

                    span.text(item);

                    li.append(span);
                    list.append(li);
                }
            }
            else {

                procesando.html(response.Message);
            }
            
        }, 
        function (response) {
            procesando.html(response.Message);
        },
        {
            blockUI : false
        });

}

function actualizar() {
    var model = getInstanciaModel();
    
    if (model == null)
        return;

    model.Release = $('#ddlRelease').val();
    model.Version = $('#ddlVersion').val();
    model.Archivos = [];

    $('#listArchivosNuevos li').each(function (idx, obj) {
        var li = $(obj);
        var chk = li.find('input');
        
        if (chk.checked()) {

            var label = li.find('label');
            model.Archivos.push(label.text());
        }
    });

    $.kenosAjax(
        URLs.actualizar,
        model,
        function (response) {

            cargarArchivosDestino();

            messageSuccess('Actualizacion satisfactoria.');

            updateListIntancias();
        });
}

function updateListIntancias() {
    
    $('#divInstancias').kenosLoad(
        URLs.listInstancias,
        null,
        function (response) {
            initListIntancias();
        },
        function () { },
        {
            blockUI: false

        });
}

function initListIntancias() {
    $("#divInstancias .instancia").click(function () {

        _currentInstance = $(this).text();

        limpiar();

        mostrarDetalle();
    });
}

function replaceUrlParam(url, paramName, value) {
    url = url.replace('%5B' + paramName + '%5D', value);

    return url.replace('[' + paramName + ']', value);
}