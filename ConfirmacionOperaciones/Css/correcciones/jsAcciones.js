var mydata;
var contadorRegistros = 0;
var pnumeroOperacion, prutCliente, pnombreCliente,pFechaOperacion, pMonto, pFechaFirma, pNdiasPendientes, pEstadoContrato;
var pFolio, pFechaEnvio, pRut, pSecuencia, pRazonSocial, pFechaInicio, pFechaVencimiento, pMtoMonPrinc, pTCcierre,pMtoMonSec,pModalidad,pDias,pTipoMov,pMonedaPrinc,pMonedaSec,pEjecutivo,pFechaEnvio,pFechaConf,pFechaElim,pEstado,pRespuestaConf;
var idsOfSelectedRows;
var pestado;
function obtieneJsonContratos() {
    pproducto = $('#selectProductos').val();
    if (pproducto == 0) {
        //alert("Debe ingresar Producto");
        jAlert("Debe ingresar Producto", "Error");
        return false;
    }
    pfecha = $('#datepicker3').val();
    
    if (pfecha == "") {
        //alert("Debe ingresar Fecha");
        jAlert("Debe ingresar Fecha", "Error");
        return false;
    }
    else {
        document.getElementById('DivPreload').style.display = "block";

        pcliente = $('#txtBuscarClientesContratos').val();
        pnoperacion = $('#txtBuscarNumOperacionContratos').val();

        var parametros = {
            "producto": pproducto,
            "fecha": pfecha,
            "cliente": pcliente,
            "noperacion": pnoperacion
        };

        $.ajax({
            data: parametros,
            type: "POST",
            async: true,
            url: 'GeneraJsonResultado.aspx', success:
                function (resultado) {
                    var jsonStr = resultado.substr(0, resultado.indexOf(']') + 1);
                    srtJson = jsonStr;
                    mydata = $.parseJSON(jsonStr);
                    //alert(document.getElementById('tipoUsuario').value);
                    if (document.getElementById('tipoUsuario').value == "Mantenedor") {
                        cargarGrilla();
                    }
                    else
                    {
                        cargarGrillaConsuta();
                    }
                    $("#export").show();
                    document.getElementById('DivPreload').style.display = "none";
                }
        });
    }
}
function cargarGrilla() {
    $("#list").jqGrid("GridUnload");
    $("#list").jqGrid({
        datatype: "local",
        data: mydata,
        cellEdit: true,	
        autowidth: false,
        shrinkToFit: false,
        colNames: ['Número Operación', 'Rut Cliente', 'Nombre Cliente', 'Fecha Operación', 'Monto', 'Fecha Firma', 'N° días pendientes', 'Estado Contrato'],
        colModel: [
            { name: 'numero_operacion', index: 'numero_operacion', width: 130, align: "center" },
            { name: 'rut_cliente', index: 'rut_cliente', width: 110, align: "center" },
            { name: 'nombre_cliente', index: 'nombre_cliente', width: 210, align: "center" },
            { name: 'fecha_operacion', index: 'fecha_operacion', align: "center", width: 115 },
            { name: 'monto', index: 'monto', align: "center", width: 85 },
            { name: 'fecha_firma', index: 'fecha_firma', align: "center", width: 90 },
            { name: 'dias_pendientes', index: 'dias_pendientes', align: "center", width: 140 },
            { name: 'estado_contrato', index: 'estado_contrato', align: "center", width: 113, editable: true, edittype: "select", formatter: "select", editoptions: { value: ":;1:Ingresado;2:Firmado" } }
           
        ],
        height: 210,
        rowNum: 10,
        //scroll: 1, // set the scroll property to 1 to enable paging with scrollbar - virtual loading of records
        emptyrecords: 'Scroll to bottom to retrieve new page', // the message will be displayed at the bottom 
        pager: "#jqGridPager",
        caption: "Resultado de Búsqueda"

    });
    jQuery("#list").jqGrid('navGrid', '#jqGridPager',
        { edit: false, add: false, del: false },
        {},
        {},
        {},
        { multipleSearch: true, multipleGroup: true }
    );
}


function cargarGrillaConsuta() {
    $("#list").jqGrid("GridUnload");
    $("#list").jqGrid({
        datatype: "local",
        data: mydata,
        cellEdit: true,
        autowidth: false,
        shrinkToFit: false,
        colNames: ['Número Operación', 'Rut Cliente','Nombre Cliente', 'Fecha Operación', 'Monto', 'Fecha Firma', 'N° días pendientes', 'Estado Contrato'],
        colModel: [
            { name: 'numero_operacion', index: 'numero_operacion', width: 130, align: "center" },
            { name: 'rut_cliente', index: 'rut_cliente', width: 110, align: "center" },
            { name: 'nombre_cliente', index: 'nombre_cliente', width: 210, align: "center" },
            { name: 'fecha_operacion', index: 'fecha_operacion', align: "center", width: 115 },
            { name: 'monto', index: 'monto', align: "center", width: 85 },
            { name: 'fecha_firma', index: 'fecha_firma', align: "center", width: 90 },
            { name: 'dias_pendientes', index: 'dias_pendientes', align: "center", width: 140 },
            { name: 'estado_contrato', index: 'estado_contrato', align: "center", width: 113 }

        ],
        height: 210,
        rowNum: 10,
        //scroll: 1, // set the scroll property to 1 to enable paging with scrollbar - virtual loading of records
        emptyrecords: 'Scroll to bottom to retrieve new page', // the message will be displayed at the bottom 
        pager: "#jqGridPager",
        caption: "Resultado de Búsqueda"

    });
    jQuery("#list").jqGrid('navGrid', '#jqGridPager',
        { edit: false, add: false, del: false },
        {},
        {},
        {},
        { multipleSearch: true, multipleGroup: true }
    );
}


function exportar() {
    var allRowsInGrid = $('#list').getGridParam('data');
    contadorRegistros = allRowsInGrid.length;

    if (contadorRegistros > 0) {
        for (i = 0; i < allRowsInGrid.length; i++) {
            pFolio = allRowsInGrid[i].folio;
            pFechaEnvio = allRowsInGrid[i].fecha_envio;
            pRut = allRowsInGrid[i].rut;
            pSecuencia = allRowsInGrid[i].secuencia;
            pRazonSocial = allRowsInGrid[i].razon_social;
            pFechaInicio = allRowsInGrid[i].fecha_inicio;
            pFechaVencimiento = allRowsInGrid[i].fecha_vencimiento;
            pMtoMonPrinc = allRowsInGrid[i].mont_mon_princ; 
            pTCcierre = allRowsInGrid[i].tc_cierre; 
            pMtoMonSec = allRowsInGrid[i].MtoMonSecu; 
            pModalidad = allRowsInGrid[i].modalidad; 
            pDias = allRowsInGrid[i].dias;
            pTipoMov = allRowsInGrid[i].tipoMov; 
            pMonedaPrinc = allRowsInGrid[i].CodMonPrinc;
            pMonedaSec = allRowsInGrid[i].CodMonSecu;
            pEjecutivo = allRowsInGrid[i].Ejecutivo;
            pFechaEnvio = allRowsInGrid[i].fecha_envio;
            pFechaConf = allRowsInGrid[i].fecha_confirmacion;
            pFechaElim = allRowsInGrid[i].fecha_eliminacion;
            pEstado = allRowsInGrid[i].Estado;
            pRespuestaConf = allRowsInGrid[i].Respuesta;
            agregarfilasTabla(pFolio, pFechaEnvio, pRut, pSecuencia, pRazonSocial, pFechaInicio, pFechaVencimiento, pMtoMonPrinc, pTCcierre, pMtoMonSec, pModalidad, pDias, pTipoMov, pMonedaPrinc, pMonedaSec, pEjecutivo, pFechaEnvio, pFechaConf, pFechaElim, pEstado, pRespuestaConf);
        }
        var htmltable = document.getElementById('tablaExp');
        var html = htmltable.outerHTML;
        window.open('data:application/vnd.ms-excel,' + encodeURIComponent(html));
        $('#tablaExp tr:not(:first-child)').remove();
    }
    else {
        jAlert("No hay registros en grilla para exportar a Excel, favor validar", "Error");
    }
}

function agregarfilasTabla(pFolio, pFechaEnvio, pRut, pSecuencia, pRazonSocial, pFechaInicio, pFechaVencimiento, pMtoMonPrinc, pTCcierre, pMtoMonSec, pModalidad, pDias, pTipoMov, pMonedaPrinc, pMonedaSec, pEjecutivo, pFechaEnvio, pFechaConf, pFechaElim, pEstado, pRespuestaConf) {
    var tds = $("#tablaExp tr:first td").length;
    var trs = $("#tabla tr").length;

    var nuevaFila;
  
    nuevaFila = "<tr>";

    nuevaFila += "<td>" + pFolio + "</td>";
    nuevaFila += "<td>" + pRut + "</td>";
    nuevaFila += "<td>" + pSecuencia + "</td>";
    nuevaFila += "<td>" + omitirAcentos(pRazonSocial) + "</td>";
    nuevaFila += "<td>" + pFechaInicio + "</td>";
    nuevaFila += "<td>" + pFechaVencimiento + "</td>";
    nuevaFila += "<td>" + pMtoMonPrinc + "</td>";
    nuevaFila += "<td>" + pTCcierre + "</td>";
    nuevaFila += "<td>" + pMtoMonSec + "</td>";
    nuevaFila += "<td>" + omitirAcentos(pModalidad) + "</td>";
    nuevaFila += "<td>" + pDias + "</td>";
    nuevaFila += "<td>" + pTipoMov + "</td>";
    nuevaFila += "<td>" + pMonedaPrinc + "</td>";
    nuevaFila += "<td>" + pMonedaSec + "</td>";
    nuevaFila += "<td>" + omitirAcentos(pEjecutivo) + "</td>";
    nuevaFila += "<td>" + pFechaEnvio + "</td>";
    nuevaFila += "<td>" + pFechaConf + "</td>";
    nuevaFila += "<td>" + pFechaElim + "</td>";
    nuevaFila += "<td>" + pEstado + "</td>";
    nuevaFila += "<td>" + omitirAcentos(pRespuestaConf) + "</td>";
   
    nuevaFila += "</tr>";
    $("#tablaExp").append(nuevaFila);
}

function omitirAcentos(text) {
    var acentos = "ÃÀÁÄÂÈÉËÊÌÍÏÎÒÓÖÔÙÚÜÛãàáäâèéëêìíïîòóöôùúüûÑñÇç";
    var original = "AAAAAEEEEIIIIOOOOUUUUaaaaaeeeeiiiioooouuuunncc";
    for (var i = 0; i < acentos.length; i++) {
        text = text.replace(new RegExp(acentos.charAt(i), 'g'), original.charAt(i));
    }
    return text;
}

function devuelveEstado(estado) {

    if (estado == 0) {
        return "Creado";
    }
    if (estado == 1) {
        return "Enviado";
    }
    if (estado == 2) {
        return "Eliminado";
    }

}



//funciones de menu principal izquierdo.

function verfuncionalidad(nombre) {
    $('input[type="text"]').val('');
    document.getElementById('LblMensajeBlotter').innerHTML = ".";
    document.getElementById("divGrilla").style.display = "none";
    ocultarBotones();
    $(".contenedorFunc").hide();
    $('#' + nombre ).toggle("slow");
}

//funciones FORWARD
//Operaciones del día.
function obtieneJsonforwardDelDia() {
    $("#BtnReenviarConfirmacion").hide();
    pfecha = $('#datepickerForwardOpDia').val();

    if (pfecha == "") {
        jAlert("Debe ingresar Fecha", "Error");
        return false;
    }
    else {
        idsOfSelectedRows = [];
        document.getElementById('DivPreload').style.display = "block";
        var parametros = {
            "fecha": pfecha
        };
        $.ajax({
            data: parametros,
            type: "POST",
            async: true,
            url: 'Forward/GeneraJsonResultadoForwardDelDia.aspx', success:
                function (resultado) {
                    var jsonStr = resultado.substr(0, resultado.indexOf(']') + 1);
                    srtJson = jsonStr;
                    mydata = $.parseJSON(jsonStr);
                    cargarGrillaForwarddelDia();
                    ocultarBotones();
                    $("#BtnEnviarConfirmacion").show();
                    document.getElementById('idProductoHidden').value = 1;
                    document.getElementById('DivPreload').style.display = "none";
                    document.getElementById("divGrilla").style.display = "block";
                }
        });
    }
}
function cargarGrillaForwarddelDia() {

    $("#list").jqGrid("GridUnload");
    $("#list").jqGrid({
        datatype: "local",
        data: mydata,
        cellEdit: true,
        autowidth: false,
        shrinkToFit: false,
        colNames: ['id', /*'Origen',*/ 'Folio', 'Rut', 'Secuencia', 'Razón Social', 'Fecha Inicio', 'Fecha Vencimiento', 'Monto Moneda principal', 'TC Cierre', 'Monto Moneda secundaria', 'Modalidad', 'Dias', 'Tipo Movimiento', 'Moneda Principal', 'Moneda Secundaria', 'Ejecutivo'],
        colModel: [
            { name: 'id', index: 'id', width: 65, align: 'center', sorttype: 'int', hidden: true },
            //{ name: 'Origen', index: 'Origen', align: "center", width: 100 },
            { name: 'folio', index: 'folio', width: 100, align: "center" },
            { name: 'rut', index: 'rut', align: "center", width: 100 },
            { name: 'secuencia', index: 'secuencia', align: "center", width: 50 },
            { name: 'razon_social', index: 'razon_social', align: "center", width: 200},
            { name: 'fecha_inicio', index: 'fecha_inicio', align: "center", width: 90 },
            { name: 'fecha_vencimiento', index: 'fecha_vencimiento', align: "center", width: 90 },
            { name: 'mont_mon_princ', index: 'mont_mon_princ', align: "center", width: 90},
            { name: 'tc_cierre', index: 'tc_cierre', align: "center", width: 90 },
            { name: 'MtoMonSecu', index: 'MtoMonSecu', align: "center", width: 140 },
            { name: 'modalidad', index: 'modalidad', align: "center", width: 140 },
            { name: 'dias', index: 'dias', align: "center", width: 90 },
            { name: 'tipoMov', index: 'tipoMov', align: "center", width: 140 },
            { name: 'CodMonPrinc', index: 'CodMonPrinc', align: "center", width: 140 },
            { name: 'CodMonSecu', index: 'CodMonSecu', align: "center", width: 140 },
            { name: 'Ejecutivo', index: 'Ejecutivo', align: "center", width: 200 }
            //{ name: 'ejecutivo', index: 'ejecutivo', align: "center", width: 140 },
            //{ name: 'clasificacion', index: 'clasificacion', align: "center", width: 140 },
            //{ name: 'usuario_creador', index: 'usuario_creador', align: "center", width: 140 },
            //{ name: 'codigo_moneda', index: 'codigo_moneda', align: "center", width: 140 },
            //{ name: 'tcTransf', index: 'tcTransf', align: "center", width: 140 },
            //{ name: 'CodSecEco', index: 'CodSecEco', align: "center", width: 140 }
            
           // { name: 'estado_operacion', index: 'estado_operacion', align: "center", width: 113, editable: true, edittype: "select", formatter: "select", editoptions: { value: ":;1:Ingresado;2:Firmado" } }/*,*/
            //{ name: 'enviar', index: 'enviar', align: "center", width: 50, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formattingptions: { disabled: false } }

        ],
        height: 210,
        rowNum: 10,
        //rowList: [5,10,15],
        //scroll: 1, // set the scroll property to 1 to enable paging with scrollbar - virtual loading of records
        emptyrecords: 'Scroll to bottom to retrieve new page', // the message will be displayed at the bottom 
        pager: "#jqGridPager",
        caption: "Resultado de Búsqueda",
        multiselect: true,
        viewrecords: true,
        sortorder: 'desc',
        caption: 'Resultado de Búsqueda Operaciones del día - Forward',
        onSelectRow: updateIdsOfSelectedRows,



        onSelectAll: function (aRowids, isSelected) {
            seleccionartodo(isSelected);
        },
        loadComplete: function () {
            var $this = $(this), i, count;
            for (i = 0, count = idsOfSelectedRows.length; i < count; i++) {
                $this.jqGrid('setSelection', idsOfSelectedRows[i], false);
            }
        }

    });
    jQuery("#list").jqGrid('navGrid', '#jqGridPager',
        { edit: false, add: false, del: false },
        {},
        {},
        {},
        { multipleSearch: true, multipleGroup: true }
    );


}

function obtieneJsonforwardReenvio() {

    pfolio = $('#txtFolioReenvio').val();

    if (pfolio == "") {
        jAlert("Debe ingresar Folio", "Error");
        return false;
    }
    else {
        document.getElementById('DivPreload').style.display = "block";
        var parametros = {
            "folio": pfolio
        };
        $.ajax({
            data: parametros,
            type: "POST",
            async: true,
            url: 'Forward/GeneraJsonResultadoForwardReenvio.aspx', success:
                function (resultado) {
                    var jsonStr = resultado.substr(0, resultado.indexOf(']') + 1);
                    srtJson = jsonStr;
                    mydata = $.parseJSON(jsonStr);
                    cargarGrillaForwardReenvio();
                    ocultarBotones();
                    document.getElementById('idProductoHidden').value = 1;
                    $("#BtnReenviarConfirmacion").show();
                    document.getElementById('DivPreload').style.display = "none";
                    document.getElementById("divGrilla").style.display = "block";
                }
        });
    }
}
function cargarGrillaForwardReenvio() {

    $("#list").jqGrid("GridUnload");
    $("#list").jqGrid({
        datatype: "local",
        data: mydata,
        cellEdit: true,
        autowidth: false,
        shrinkToFit: false,
        colNames: ['id', /*'Origen',*/ 'Folio', 'Rut', 'Secuencia', 'Razón Social', 'Fecha Inicio', 'Fecha Vencimiento', 'Monto Moneda principal', 'TC Cierre', 'Monto Moneda secundaria', 'Modalidad', 'Dias', 'Tipo Movimiento', 'Moneda Principal', 'Moneda Secundaria', 'Ejecutivo'],
        colModel: [
            { name: 'id', index: 'id', width: 65, align: 'center', sorttype: 'int', hidden: true },
            //{ name: 'Origen', index: 'Origen', align: "center", width: 100 },
            { name: 'folio', index: 'folio', width: 100, align: "center" },
            { name: 'rut', index: 'rut', align: "center", width: 100 },
            { name: 'secuencia', index: 'secuencia', align: "center", width: 50 },
            { name: 'razon_social', index: 'razon_social', align: "center", width: 150 },
            { name: 'fecha_inicio', index: 'fecha_inicio', align: "center", width: 90 },
            { name: 'fecha_vencimiento', index: 'fecha_vencimiento', align: "center", width: 90 },
            { name: 'mont_mon_princ', index: 'mont_mon_princ', align: "center", width: 90 },
            { name: 'tc_cierre', index: 'tc_cierre', align: "center", width: 90 },
            { name: 'MtoMonSecu', index: 'MtoMonSecu', align: "center", width: 140 },
            { name: 'modalidad', index: 'modalidad', align: "center", width: 140 },
            { name: 'dias', index: 'dias', align: "center", width: 140 },
            { name: 'tipoMov', index: 'tipoMov', align: "center", width: 140 },
            { name: 'CodMonPrinc', index: 'CodMonPrinc', align: "center", width: 140 },
            { name: 'CodMonSecu', index: 'CodMonSecu', align: "center", width: 140 },
            { name: 'Ejecutivo', index: 'Ejecutivo', align: "center", width: 140 }
            //{ name: 'ejecutivo', index: 'ejecutivo', align: "center", width: 140 },
            //{ name: 'clasificacion', index: 'clasificacion', align: "center", width: 140 },
            //{ name: 'usuario_creador', index: 'usuario_creador', align: "center", width: 140 },
            //{ name: 'codigo_moneda', index: 'codigo_moneda', align: "center", width: 140 },
            //{ name: 'tcTransf', index: 'tcTransf', align: "center", width: 140 },
            //{ name: 'CodSecEco', index: 'CodSecEco', align: "center", width: 140 }

           // { name: 'estado_operacion', index: 'estado_operacion', align: "center", width: 113, editable: true, edittype: "select", formatter: "select", editoptions: { value: ":;1:Ingresado;2:Firmado" } }/*,*/
            //{ name: 'enviar', index: 'enviar', align: "center", width: 50, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formattingptions: { disabled: false } }

        ],
        height: 210,
        rowNum: 10,
        //rowList: [5,10,15],
        //scroll: 1, // set the scroll property to 1 to enable paging with scrollbar - virtual loading of records
        emptyrecords: 'Scroll to bottom to retrieve new page', // the message will be displayed at the bottom 
        pager: "#jqGridPager",
        caption: "Resultado de Búsqueda",
        multiselect: true,
        viewrecords: true,
        sortorder: 'desc',
        caption: 'Resultado de Búsqueda Reenvío Operaciones - Forward',
        onSelectRow: updateIdsOfSelectedRows,



        onSelectAll: function (aRowids, isSelected) {
            seleccionartodo(isSelected);
        },
        loadComplete: function () {
            var $this = $(this), i, count;
            for (i = 0, count = idsOfSelectedRows.length; i < count; i++) {
                $this.jqGrid('setSelection', idsOfSelectedRows[i], false);
            }
        }

    });
    jQuery("#list").jqGrid('navGrid', '#jqGridPager',
        { edit: false, add: false, del: false },
        {},
        {},
        {},
        { multipleSearch: true, multipleGroup: true }
    );


}

//Consultar Operaciones.
function obtieneJsonForwardConsulta() {
    pfecha = $('#datepickerForwardConsulta').val();
    pcliente = $('#txtBuscarClientesForward').val();
    pnumeroOperacion = $('#txtBuscarNumOperacionForward').val();
    pestado = $('select[id=selectEstadoForward]').val();


    //if (pfecha == "") {
    //    //alert("Debe ingresar Fecha");
    //    jAlert("Debe ingresar Fecha", "Error");
    //    return false;
    //}
    //else {
        document.getElementById('DivPreload').style.display = "block";

        var parametros = {
            "fecha": pfecha,
            "cliente": pcliente,
            "nOperacion": pnumeroOperacion,
            "estado": pestado
        };

        $.ajax({
            data: parametros,
            type: "POST",
            async: true,
            url: 'Forward/GeneraJsonResultadoForwardConsulta.aspx', success:
                function (resultado) {
                    var jsonStr = resultado.substr(0, resultado.indexOf(']') + 1);
                    srtJson = jsonStr;
                    mydata = $.parseJSON(jsonStr);
                    cargarGrillaForwardConsulta();
                    ocultarBotones();
                    $("#BtnExport").show();
                    document.getElementById('DivPreload').style.display = "none";
                    document.getElementById("divGrilla").style.display = "block";
                }
        });
    //}
}
function cargarGrillaForwardConsulta() {
    $("#list").jqGrid("GridUnload");
    $("#list").jqGrid({
        datatype: "local",
        data: mydata,
        //multiselect: true,
        cellEdit: true,
        autowidth: false,
        shrinkToFit: false,
        colNames: ['id', /*'Origen',*/ 'Folio', 'Rut', 'Secuencia', 'Razón Social', 'Fecha Inicio', 'Fecha Vencimiento', 'Monto Moneda principal', 'TC Cierre', 'Monto Moneda secundario', 'Modalidad', 'Dias', 'Tipo Movimiento', 'Moneda Principal', 'Moneda Secundaria', 'Ejecutivo','Fecha Envío','Fecha Confirmación','Fecha Eliminación','Estado','Respuesta Conf.'],
        colModel: [
            { name: 'id', index: 'id', width: 65, align: 'center', sorttype: 'int', hidden: true },
            //{ name: 'Origen', index: 'Origen', align: "center", width: 100 },
            { name: 'folio', index: 'folio', width: 100, align: "center" },
            { name: 'rut', index: 'rut', align: "center", width: 100 },
            { name: 'secuencia', index: 'secuencia', align: "center", width: 50 },
            { name: 'razon_social', index: 'razon_social', align: "center", width: 150 },
            { name: 'fecha_inicio', index: 'fecha_inicio', align: "center", width: 90 },
            { name: 'fecha_vencimiento', index: 'fecha_vencimiento', align: "center", width: 90 },
            { name: 'mont_mon_princ', index: 'mont_mon_princ', align: "center", width: 90 },
            { name: 'tc_cierre', index: 'tc_cierre', align: "center", width: 90 },
            { name: 'MtoMonSecu', index: 'MtoMonSecu', align: "center", width: 140 },
            { name: 'modalidad', index: 'modalidad', align: "center", width: 140 },
            { name: 'dias', index: 'dias', align: "center", width: 80 },
            { name: 'tipoMov', index: 'tipoMov', align: "center", width: 80 },
            { name: 'CodMonPrinc', index: 'CodMonPrinc', align: "center", width: 140 },
            { name: 'CodMonSecu', index: 'CodMonSecu', align: "center", width: 140 },
            { name: 'Ejecutivo', index: 'Ejecutivo', align: "center", width: 140 },
            { name: 'fecha_envio', index: 'fecha_envio', align: "center", width: 140 },
            { name: 'fecha_confirmacion', index: 'fecha_confirmacion', align: "center", width: 140 },
            { name: 'fecha_eliminacion', index: 'fecha_eliminacion', align: "center", width: 140 },
            { name: 'Estado', index: 'Estado', align: "center", width: 80 },
            { name: 'Respuesta', index: 'Respuesta', align: "center", width: 140 }
            //{ name: 'ejecutivo', index: 'ejecutivo', align: "center", width: 140 },
            //{ name: 'clasificacion', index: 'clasificacion', align: "center", width: 140 },
            //{ name: 'usuario_creador', index: 'usuario_creador', align: "center", width: 140 },
            //{ name: 'codigo_moneda', index: 'codigo_moneda', align: "center", width: 140 },
            //{ name: 'tcTransf', index: 'tcTransf', align: "center", width: 140 },
            //{ name: 'CodSecEco', index: 'CodSecEco', align: "center", width: 140 }

           // { name: 'estado_operacion', index: 'estado_operacion', align: "center", width: 113, editable: true, edittype: "select", formatter: "select", editoptions: { value: ":;1:Ingresado;2:Firmado" } }/*,*/
            //{ name: 'enviar', index: 'enviar', align: "center", width: 50, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formattingptions: { disabled: false } }

        ],
        height: 210,
        rowNum: 10,
        //scroll: 1, // set the scroll property to 1 to enable paging with scrollbar - virtual loading of records
        emptyrecords: 'Scroll to bottom to retrieve new page', // the message will be displayed at the bottom 
        pager: "#jqGridPager",
        caption: 'Resultado de Búsqueda Consultar Operaciones - Forward',
    });
    jQuery("#list").jqGrid('navGrid', '#jqGridPager',
        { edit: false, add: false, del: false },
        {},
        {},
        {},
        { multipleSearch: true, multipleGroup: true }
    );
}

////////////////////////////////////////consulta aviso vencimiento


function obtieneJsonForwardConsultaVen() {

    pfechaV = $('#datepickerForwardConsultaVencimiento').val();
    if (pfechaV == "") {
        jAlert("Debe ingresar fecha de búsqueda", "Error");
        return false;
    }
    else {
        pestadoV = $('#selectEstadoVencimientoForward').val();

        document.getElementById('DivPreload').style.display = "block";
        var parametros = {
            "fecha": pfechaV,
            "estado": pestadoV
        };

        $.ajax({
            data: parametros,
            type: "POST",
            async: true,
            url: 'Forward/GeneraJsonResultadoForwardConsultaVen.aspx', success:
                function (resultado) {
                    var jsonStr = resultado.substr(0, resultado.indexOf(']') + 1);
                    srtJson = jsonStr;
                    mydata = $.parseJSON(jsonStr);
                    cargarGrillaForwardConsultaVen();
                    ocultarBotones();
                    //$("#BtnExport").show();
                    document.getElementById('DivPreload').style.display = "none";
                    document.getElementById("divGrilla").style.display = "block";
                }
        });
    }
}

function cargarGrillaForwardConsultaVen() {
    $("#list").jqGrid("GridUnload");
    $("#list").jqGrid({
        datatype: "local",
        data: mydata,
        cellEdit: true,
        autowidth: false,
        shrinkToFit: false,
        colNames: ['id', /*'Origen',*/ 'Folio', 'Rut', 'Secuencia', 'Razón Social', 'Fecha Inicio', 'Fecha Vencimiento', 'Monto Moneda principal', 'TC Cierre', 'Monto Moneda secundaria', 'Modalidad', 'Plazo', 'Tipo Movimiento', 'Moneda Principal', 'Moneda Secundaria', 'Paridad Cierre', 'Margen', 'Ejecutivo', 'Clasificacion', 'Usuario Creador', 'Codigo Moneda Principal', 'Codigo Moneda Secundaria', 'TC Transferencia', 'CodSecEco','Estado'],
        colModel: [
            { name: 'id', index: 'id', width: 65, align: 'center', sorttype: 'int', hidden: true },
            //{ name: 'Origen', index: 'Origen', align: "center", width: 100 },
            { name: 'folio', index: 'folio', width: 100, align: "center" },
            { name: 'rut', index: 'rut', align: "center", width: 100 },
            { name: 'secuencia', index: 'secuencia', align: "center", width: 50 },
            { name: 'razon_social', index: 'razon_social', align: "center", width: 150 },
            { name: 'fecha_inicio', index: 'fecha_inicio', align: "center", width: 100 },
            { name: 'fecha_vencimiento', index: 'fecha_vencimiento', align: "center", width: 100 },
            { name: 'mont_mon_princ', index: 'mont_mon_princ', align: "center", width: 100 },
            { name: 'tc_cierre', index: 'tc_cierre', align: "center", width: 70 },
            { name: 'MtoMonSecu', index: 'MtoMonSecu', align: "center", width: 100 },
            { name: 'modalidad', index: 'modalidad', align: "center", width: 100 },
            { name: 'dias', index: 'dias', align: "center", width: 60 },
            { name: 'TipoMov', index: 'TipoMov', align: "center", width: 100 },
            { name: 'CodMonPrinc', index: 'CodMonPrinc', align: "center", width: 100 },
            { name: 'CodMonSecu', index: 'CodMonSecu', align: "center", width: 100 },
            { name: 'ParidadCierre', index: 'ParidadCierre', align: "center", width: 100 },
            { name: 'margen', index: 'margen', align: "center", width: 80 },
            { name: 'ejecutivo', index: 'ejecutivo', align: "center", width: 140 },
            { name: 'clasificacion', index: 'clasificacion', align: "center", width: 100 },
            { name: 'usuarioCreador', index: 'usuarioCreador', align: "center", width: 110 },
            { name: 'codigoMonedaPrinc', index: 'codigoMonedaPrinc', align: "center", width: 140 },
            { name: 'codigoMonedaSecun', index: 'codigoMonedaSecun', align: "center", width: 140 },
            { name: 'tcTransf', index: 'tcTransf', align: "center", width: 140 },
            { name: 'CodSecEco', index: 'CodSecEco', align: "center", width: 140 },
            { name: 'Estado', index: 'Estado', align: "center", width: 140 }

            //{ name: 'estado_operacion', index: 'estado_operacion', align: "center", width: 113, editable: true, edittype: "select", formatter: "select", editoptions: { value: ":;1:Ingresado;2:Firmado" } }/*,*/
            //{ name: 'enviar', index: 'enviar', align: "center", width: 50, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formattingptions: { disabled: false } }

        ],
        height: 210,
        rowNum: 10,
        //rowList: [5,10,15],
        //scroll: 1, // set the scroll property to 1 to enable paging with scrollbar - virtual loading of records
        emptyrecords: 'Scroll to bottom to retrieve new page', // the message will be displayed at the bottom 
        pager: "#jqGridPager",
        caption: "Resultado de Búsqueda",
        //multiselect: true,
        viewrecords: true,
        sortable: true,
        sortorder: 'asc',
        sortcolumn: 'id',
        sortdirection: 'asc',
        caption: 'Resultado de Búsqueda Envio de Vencimientos - Forward',
        onSelectRow: updateIdsOfSelectedRows,



        onSelectAll: function (aRowids, isSelected) {
            seleccionartodo(isSelected);
        },
        loadComplete: function () {
            var $this = $(this), i, count;
            for (i = 0, count = idsOfSelectedRows.length; i < count; i++) {
                $this.jqGrid('setSelection', idsOfSelectedRows[i], false);
            }
        }

    });
    jQuery("#list").jqGrid('navGrid', '#jqGridPager',
        { edit: false, add: false, del: false },
        {},
        {},
        {},
        { multipleSearch: true, multipleGroup: true }
    );

}


////////////////////////////////////////fin consulta aviso vencimiento


//funciones carga blotter
function cargarGrillaForwardBlotter() {
    jsonStr = $('#jSonBlotter').val();
    mydata = $.parseJSON(jsonStr);
    $("#list").jqGrid("GridUnload");
    $("#list").jqGrid({
        datatype: "local",
        data: mydata,
        cellEdit: true,
        autowidth: false,
        shrinkToFit: false,
        colNames: ['id', 'Fecha Inicio', 'Folio', 'Fecha Vencimiento', 'Rut Cliente', 'Secuencia', 'Nombre Cliente', 'Tipo Movimiento', 'Moneda Principal', 'Monto Principal', 'Moneda Secundaria', 'TC Cierre Forward', 'Monto Secundaria', 'Cumplimiento', 'Agente'/*, 'Monto Liquidación', 'Margen', 'Cartera', 'Vehiculo', 'Folio Asociado', 'Comentario','Fixing Date','Fecha Anticipo','Tasa Anticipo'*/],
        colModel: [
            { name: 'id', index: 'id', width: 65, align: 'center', sorttype: 'int', hidden: true },         
            { name: 'fechaInicio', index: 'fechaInicio', width: 80, align: "center" },
            { name: 'folioOperacion', index: 'folioOperacion', align: "center", width: 100 },
            { name: 'fechaVencimiento', index: 'fechaVencimiento', align: "center", width: 80 },
            { name: 'rut', index: 'rut', align: "center", width: 100 },
            { name: 'secuencia', index: 'secuencia', align: "center", width: 90 },
            { name: 'nombreCliente', index: 'nombreCliente', align: "center", width: 200 },
            { name: 'tipoMovimiento', index: 'tipoMovimiento', align: "center", width: 90 },
            { name: 'monedaPrincipal', index: 'monedaPrincipal', align: "center", width: 110 },
            { name: 'montoPrincipal', index: 'montoPrincipal', align: "center", width: 140 },

            { name: 'monedaSecundario', index: 'monedaSecundaria', align: "center", width: 110 },
            { name: 'tcCierreForward', index: 'tcCierre', align: "center", width: 103 },
            { name: 'montoSecundario', index: 'montoSecundario', align: "center", width: 100 },
            { name: 'cumplimiento', index: 'cumplimiento', align: "center", width: 100 },
            { name: 'agente', index: 'agente', align: "center", width: 100 }

            /*{ name: 'modalidad', index: 'modalidad', align: "center", width: 140 }*//*,*/
            //{ name: 'dias', index: 'modalidad', align: "dias", width: 140 },
            //{ name: 'tipo_mov', index: 'tipo_mov', align: "center", width: 140 },
            //{ name: 'margen', index: 'margen', align: "center", width: 140 },
            //{ name: 'ejecutivo', index: 'ejecutivo', align: "center", width: 140 },
            //{ name: 'clasificacion', index: 'clasificacion', align: "center", width: 140 },
            //{ name: 'usuario_creador', index: 'usuario_creador', align: "center", width: 140 },
            //{ name: 'codigo_moneda', index: 'codigo_moneda', align: "center", width: 140 },
            //{ name: 'tcTransf', index: 'tcTransf', align: "center", width: 140 },
            //{ name: 'CodSecEco', index: 'CodSecEco', align: "center", width: 140 }

            // { name: 'estado_operacion', index: 'estado_operacion', align: "center", width: 113, editable: true, edittype: "select", formatter: "select", editoptions: { value: ":;1:Ingresado;2:Firmado" } }/*,*/
            //{ name: 'enviar', index: 'enviar', align: "center", width: 50, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formattingptions: { disabled: false } }

        ],
        height: 210,
        rowNum: 10,
        //rowList: [5,10,15],
        //scroll: 1, // set the scroll property to 1 to enable paging with scrollbar - virtual loading of records
        emptyrecords: 'Scroll to bottom to retrieve new page', // the message will be displayed at the bottom 
        pager: "#jqGridPager",
        caption: "Resultado de Búsqueda",
        multiselect: true,
        viewrecords: true,
        sortorder: 'desc',
        caption: 'Resultado de Carga archivo - Forward',
        onSelectRow: updateIdsOfSelectedRows,
        onSelectAll: function (aRowids, isSelected) {
            seleccionartodo(isSelected);
        },
        loadComplete: function () {
            var $this = $(this), i, count;
            for (i = 0, count = idsOfSelectedRows.length; i < count; i++) {
                $this.jqGrid('setSelection', idsOfSelectedRows[i], false);
            }
        }

    });
    jQuery("#list").jqGrid('navGrid', '#jqGridPager',
        { edit: false, add: false, del: false },
        {},
        {},
        {},
        { multipleSearch: true, multipleGroup: true }
    );


}

//funciones para envio de vencimiento
function cargarGrillaForwardVencimientos() {

    $("#list").jqGrid("GridUnload");
    $("#list").jqGrid({
        datatype: "local",
        data: mydata,
        cellEdit: true,
        autowidth: false,
        shrinkToFit: false,
        colNames: ['id', /*'Origen',*/ 'Folio', 'Rut', 'Secuencia', 'Razón Social', 'Fecha Inicio', 'Fecha Vencimiento', 'Monto Moneda principal', 'TC Cierre', 'Monto Moneda secundaria', 'Modalidad','Plazo', 'Tipo Movimiento','Moneda Principal','Moneda Secundaria','Paridad Cierre', 'Margen', 'Ejecutivo', 'Clasificacion', 'Usuario Creador', 'Codigo Moneda Principal','Codigo Moneda Secundaria','TC Transferencia', 'CodSecEco'],
        colModel: [
            { name: 'id', index: 'id', width: 65, align: 'center', sorttype: 'int', hidden: true },
            //{ name: 'Origen', index: 'Origen', align: "center", width: 100 },
            { name: 'folio', index: 'folio', width: 100, align: "center" },
            { name: 'rut', index: 'rut', align: "center", width: 100 },
            { name: 'secuencia', index: 'secuencia', align: "center", width: 50 },
            { name: 'razon_social', index: 'razon_social', align: "center", width: 150 },
            { name: 'fecha_inicio', index: 'fecha_inicio', align: "center", width: 100 },
            { name: 'fecha_vencimiento', index: 'fecha_vencimiento', align: "center", width: 100 },
            { name: 'mont_mon_princ', index: 'mont_mon_princ', align: "center", width: 100 },
            { name: 'tc_cierre', index: 'tc_cierre', align: "center", width: 70 },
            { name: 'MtoMonSecu', index: 'MtoMonSecu', align: "center", width: 100 },
            { name: 'modalidad', index: 'modalidad', align: "center", width: 100 },
            { name: 'dias', index: 'dias', align: "center", width: 60 },
            { name: 'TipoMov', index: 'TipoMov', align: "center", width: 100 },
            { name: 'CodMonPrinc', index: 'CodMonPrinc', align: "center", width: 100 },
            { name: 'CodMonSecu', index: 'CodMonSecu', align: "center", width: 100 },
            { name: 'ParidadCierre', index: 'ParidadCierre', align: "center", width: 100 },
            { name: 'margen', index: 'margen', align: "center", width: 80 },
            { name: 'ejecutivo', index: 'ejecutivo', align: "center", width: 140 },
            { name: 'clasificacion', index: 'clasificacion', align: "center", width: 100 },
            { name: 'usuarioCreador', index: 'usuarioCreador', align: "center", width: 110 },
            { name: 'codigoMonedaPrinc', index: 'codigoMonedaPrinc', align: "center", width: 140 },
            { name: 'codigoMonedaSecun', index: 'codigoMonedaSecun', align: "center", width: 140 },
            { name: 'tcTransf', index: 'tcTransf', align: "center", width: 140 },
            { name: 'CodSecEco', index: 'CodSecEco', align: "center", width: 140 }

            // { name: 'estado_operacion', index: 'estado_operacion', align: "center", width: 113, editable: true, edittype: "select", formatter: "select", editoptions: { value: ":;1:Ingresado;2:Firmado" } }/*,*/
            //{ name: 'enviar', index: 'enviar', align: "center", width: 50, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formattingptions: { disabled: false } }

        ],
        height: 210,
        rowNum: 10,
        //rowList: [5,10,15],
        //scroll: 1, // set the scroll property to 1 to enable paging with scrollbar - virtual loading of records
        emptyrecords: 'Scroll to bottom to retrieve new page', // the message will be displayed at the bottom 
        pager: "#jqGridPager",
        caption: "Resultado de Búsqueda",
        multiselect: true,
        viewrecords: true,
        sortable: true,
        sortorder: 'asc',
        sortcolumn: 'id',
        sortdirection: 'asc',
        caption: 'Resultado de Búsqueda Vencimientos - Forward',
        onSelectRow: updateIdsOfSelectedRows,



        onSelectAll: function (aRowids, isSelected) {
            seleccionartodo(isSelected);
        },
        loadComplete: function () {
            var $this = $(this), i, count;
            for (i = 0, count = idsOfSelectedRows.length; i < count; i++) {
                $this.jqGrid('setSelection', idsOfSelectedRows[i], false);
            }
        }

    });
    jQuery("#list").jqGrid('navGrid', '#jqGridPager',
        { edit: false, add: false, del: false },
        {},
        {},
        {},
        { multipleSearch: true, multipleGroup: true }
    );


}

var fechaVencimiento;
function cargarVencimientosForward() {
    var seleccion = 0;
    if ($("#radioPorvencer").is(':checked')) {
        seleccion = 1;
        var f = new Date();
        fechaVencimiento = (f.getDate()+1) + "/" + f.getMonth() + "/" + f.getFullYear();
    };

    if ($("#radioEnvencimiento").is(':checked')) {
        seleccion = 2;
        var f = new Date();
        fechaVencimiento = f.getDate() + "/" + f.getMonth() + "/" + f.getFullYear();
    }
    //alert(seleccion);

    idsOfSelectedRows = [];
    document.getElementById('DivPreload').style.display = "block";
    var parametros = {
        "fecha": seleccion
    };
    $.ajax({
        data: parametros,
        type: "POST",
        async: true,
        url: 'Forward/GeneraJsonResultadoForwardVencimiento.aspx', success:
            function (resultado) {
                var jsonStr = resultado.substr(0, resultado.indexOf(']') + 1);
                srtJson = jsonStr;
                mydata = $.parseJSON(jsonStr);
                cargarGrillaForwardVencimientos();
                ocultarBotones();
                $("#BtnEnviarAvisoVencimiento").show();
                document.getElementById('DivPreload').style.display = "none";
                document.getElementById("divGrilla").style.display = "block";
            }
    });


}

//funciones SIMULTANEAS

//Operaciones del día.
function obtieneJsonSimultaneasDelDia() {
    pfecha = $('#datepickerSimultaneasOpDia').val();

    if (pfecha == "") {
        jAlert("Debe ingresar Fecha", "Error");
        return false;
    }
    else {
         idsOfSelectedRows = [];
         document.getElementById('DivPreload').style.display = "block";
         var parametros = {
            "fecha": pfecha
        };
        $.ajax({
            data: parametros,
            type: "POST",
            async: true,
            url: 'Simultaneas/GeneraJsonResultadoSimultaneasDelDia.aspx', success:
                function (resultado) {
                    var jsonStr = resultado.substr(0, resultado.indexOf(']') + 1);
                    srtJson = jsonStr;
                    mydata = $.parseJSON(jsonStr);
                    cargarGrillaSimultaneasdelDia();
                    $("#BtnExport").hide();
                    $("#BtnEnviarConfirmacion").show();
                    document.getElementById('DivPreload').style.display = "none";
                    document.getElementById("divGrilla").style.display = "block"; 
                }
        });
    }
}
function cargarGrillaSimultaneasdelDia() {

    $("#list").jqGrid("GridUnload");
    $("#list").jqGrid({
        datatype: "local",
        data: mydata,
        cellEdit: true,
        autowidth: false,
        shrinkToFit: false,
        colNames: ['id','Número Operación', 'Rut Cliente', 'Nombre Cliente', 'Fecha Operación', 'Monto', 'Fecha Firma', 'N° días pendientes', 'Estado Contrato'/*, 'Enviar'*/],
        colModel: [
            { name: 'id', index: 'id', width: 65, align: 'center', sorttype: 'int', hidden: true },
            { name: 'numero_operacion', index: 'numero_operacion', width: 130, align: "center" },
            { name: 'rut_cliente', index: 'rut_cliente', width: 110, align: "center" },
            { name: 'nombre_cliente', index: 'nombre_cliente', width: 210, align: "center" },
            { name: 'fecha_operacion', index: 'fecha_operacion', align: "center", width: 115 },
            { name: 'monto', index: 'monto', align: "center", width: 85 },
            { name: 'fecha_firma ', index: 'fecha_firma', align: "center", width: 90 },
            { name: 'dias_pendientes', index: 'dias_pendientes', align: "center", width: 140 },
            { name: 'estado_contrato', index: 'estado_contrato', align: "center", width: 113, editable: true, edittype: "select", formatter: "select", editoptions: { value: ":;1:Ingresado;2:Firmado" } }/*,*/
            //{ name: 'enviar', index: 'enviar', align: "center", width: 50, editable: true, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formattingptions: { disabled: false } }

        ],
        height: 210,
        rowNum: 10,
        //rowList: [5,10,15],
        //scroll: 1, // set the scroll property to 1 to enable paging with scrollbar - virtual loading of records
        emptyrecords: 'Scroll to bottom to retrieve new page', // the message will be displayed at the bottom 
        pager: "#jqGridPager",
        caption: "Resultado de Búsqueda",
        multiselect: true,
        viewrecords: true,
        sortorder: 'desc',
        caption: 'Resultado de Búsqueda Operaciones del día - Simultaneas', 
        onSelectRow:updateIdsOfSelectedRows,
            
      

        onSelectAll: function (aRowids, isSelected) {
            seleccionartodo(isSelected);
        },
        loadComplete: function () {
            var $this = $(this), i, count;
            for (i = 0, count = idsOfSelectedRows.length; i < count; i++) {
                $this.jqGrid('setSelection', idsOfSelectedRows[i], false);
            }
        }
      
    });
    jQuery("#list").jqGrid('navGrid', '#jqGridPager',
        { edit: false, add: false, del: false },
        {},
        {},
        {},
        { multipleSearch: true, multipleGroup: true }
    );


}

//Consultar Operaciones.
function obtieneJsonSimultaneasConsulta() {
    pfecha = $('#datepickerSimultaneasConsulta').val();
    pcliente = $('#txtBuscarClientesSimultaneas').val(); 
    pnumeroOperacion = $('#txtBuscarNumOperacionSimultaneas').val(); 

    if (pfecha == "") {
        //alert("Debe ingresar Fecha");
        jAlert("Debe ingresar Fecha", "Error");
        return false;
    }
    else {
        document.getElementById('DivPreload').style.display = "block";

        var parametros = {
            "fecha": pfecha,
            "cliente": pcliente,
            "nOperacion":pnumeroOperacion
        };

        $.ajax({
            data: parametros,
            type: "POST",
            async: true,
            url: 'Simultaneas/GeneraJsonResultadoSimultaneasConsulta.aspx', success:
                function (resultado) {
                    var jsonStr = resultado.substr(0, resultado.indexOf(']') + 1);
                    srtJson = jsonStr;
                    mydata = $.parseJSON(jsonStr);
                    cargarGrillaSimultaneasConsulta();
                    $("#BtnExport").show();
                    $("#BtnEnviarConfirmacion").hide();
                    document.getElementById('DivPreload').style.display = "none";
                    document.getElementById("divGrilla").style.display = "block"; 
                }
        });
    }
}
function cargarGrillaSimultaneasConsulta() {
    $("#list").jqGrid("GridUnload");
    $("#list").jqGrid({
        datatype: "local",
        data: mydata,
        multiselect: true,
        cellEdit: true,
        autowidth: false,
        shrinkToFit: false,
        colNames: ['Número Operación', 'Rut Cliente', 'Nombre Cliente', 'Fecha Operación', 'Monto', 'Fecha Firma', 'N° días pendientes', 'Estado Contrato'/*,'Enviar'*/],
        colModel: [
            { name: 'numero_operacion', index: 'numero_operacion', width: 130, align: "center" },
            { name: 'rut_cliente', index: 'rut_cliente', width: 110, align: "center" },
            { name: 'nombre_cliente', index: 'nombre_cliente', width: 210, align: "center" },
            { name: 'fecha_operacion', index: 'fecha_operacion', align: "center", width: 115 },
            { name: 'monto', index: 'monto', align: "center", width: 85 },
            { name: ' ', index: 'fecha_firma', align: "center", width: 90 },
            { name: 'dias_pendientes', index: 'dias_pendientes', align: "center", width: 140 },
            { name: 'estado_contrato', index: 'estado_contrato', align: "center", width: 113, editable: true, edittype: "select", formatter: "select", editoptions: { value: ":;1:Ingresado;2:Firmado" } }/*,*/
            //{ name: 'enviar', index: 'enviar', align: "center", width: 50, editable: false, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formattingptions: { disabled: true } }
        ],
        height: 210,
        rowNum: 10,
        //scroll: 1, // set the scroll property to 1 to enable paging with scrollbar - virtual loading of records
        emptyrecords: 'Scroll to bottom to retrieve new page', // the message will be displayed at the bottom 
        pager: "#jqGridPager",
        caption: 'Resultado de Búsqueda Consulta Operaciones - Simultaneas',

    });
    jQuery("#list").jqGrid('navGrid', '#jqGridPager',
        { edit: false, add: false, del: false },
        {},
        {},
        {},
        { multipleSearch: true, multipleGroup: true }
    );
}

var $grid = $("#list"), idsOfSelectedRows = [],
    updateIdsOfSelectedRows = function (id, isSelected) {
        //var index = $.inArray(id, idsOfSelectedRows);
        if (!isSelected /*&& index >= 0*/) {
            var index = idsOfSelectedRows.indexOf(parseInt(id));
            idsOfSelectedRows.splice(index, 1); // remove id from the list
        } else /*if (index < 0)*/ {
            idsOfSelectedRows.push(id);
        }
        
    };

function seleccionartodo(isSelected) {
    if (isSelected) {
        idsOfSelectedRows = [];
        var allRowsInGrid = $('#list').getGridParam('data');
        var ids = allRowsInGrid.length
        for (i = 1, count = ids; i <= count; i++) {
            idsOfSelectedRows.push(i);
        }
    }
    else {
        idsOfSelectedRows = [];
    }
}

function enviarConfirmacion() {
    document.getElementById('DivPreload').style.display = "block";
    var idproductoEnviar = document.getElementById('idProductoHidden').value;
    var NumeroOperacionesEnviar;
    var idSelect;
    NumeroOperacionesEnviar = [];
    var registrosSeleccionados = idsOfSelectedRows;
    var allRowsInGrid = $('#list').getGridParam('data');
    contadorRegistros = allRowsInGrid.length;
    if (registrosSeleccionados != "") {
        //alert(registrosSeleccionados);
        idsOfSelectedRows.sort();
        //alert(idsOfSelectedRows);
        for (i = 0, count = idsOfSelectedRows.length; i < count; i++) {
            idSelect = idsOfSelectedRows[i];
            if (contadorRegistros > 0) {
                for (j = 0; j < allRowsInGrid.length; j++) {
                    if (idSelect == allRowsInGrid[j].id) {
                        NumeroOperacionesEnviar.push(allRowsInGrid[j].rut + "|" + allRowsInGrid[j].folio + "|" + "SIGA" + "|" + allRowsInGrid[j].razon_social);
                        break;
                    }
                }
            }
           
        }
        //alert(NumeroOperacionesEnviar.toString());
        var parametros = {
            "idProducto": idproductoEnviar,
            "Operaciones": NumeroOperacionesEnviar.toString(),
            "Reenvio": 'NO'
        };
        $.ajax({
            data: parametros,
            type: "POST",
            async: true,
            url: 'Forward/EnviarConfirmacion.aspx', success:
                function (resultado) {
                    document.getElementById('DivPreload').style.display = "none";                  
                    jAlert("Las operaciones se han enviado correctamente para su confirmación","Ok");
                    
                    $("#btnCargarOp").trigger("onclick");
                }
        });
    }
    else {
        jAlert("No hay registros seleccionados para enviar confirmación, favor validar", "Error");
        document.getElementById('DivPreload').style.display = "none";
    }
  
}

function reenviarConfirmacion() {


    document.getElementById('DivPreload').style.display = "block";
    var idproductoEnviar = document.getElementById('idProductoHidden').value;
    var NumeroOperacionesEnviar;
    var idSelect;
    NumeroOperacionesEnviar = [];
    var registrosSeleccionados = idsOfSelectedRows;
    var allRowsInGrid = $('#list').getGridParam('data');
    contadorRegistros = allRowsInGrid.length;
    if (registrosSeleccionados != "") {
        //alert(registrosSeleccionados);
        idsOfSelectedRows.sort();
        //alert(idsOfSelectedRows);
        for (i = 0, count = idsOfSelectedRows.length; i < count; i++) {
            idSelect = idsOfSelectedRows[i];
            if (contadorRegistros > 0) {
                for (j = 0; j < allRowsInGrid.length; j++) {
                    if (idSelect == allRowsInGrid[j].id) {
                        NumeroOperacionesEnviar.push(allRowsInGrid[j].rut + "|" + allRowsInGrid[j].folio + "|" + "SIGA" + "|" + allRowsInGrid[j].razon_social);
                        break;
                    }
                }
            }

        }
        //alert(NumeroOperacionesEnviar.toString());
        var parametros = {
            "idProducto": idproductoEnviar,
            "Operaciones": NumeroOperacionesEnviar.toString(),
            "Reenvio": 'SI'
        };
        $.ajax({
            data: parametros,
            type: "POST",
            async: true,
            url: 'Forward/EnviarConfirmacion.aspx', success:
                function (resultado) {
                    document.getElementById('DivPreload').style.display = "none";
                    //document.getElementById("divGrilla").style.display = "block";
                    jAlert("La operación se ha reenviado correctamente para su confirmación","Ok");
                    idsOfSelectedRows = [];
                }
        });


    }
    else {
        jAlert("No hay registros seleccionados para reenviar confirmación, favor validar", "Error");
        document.getElementById('DivPreload').style.display = "none";
    }

}
//aqui esta blotter para agregar
function enviarConfirmacionBlotter() {
    document.getElementById('DivPreload').style.display = "block";
    document.getElementById('idProductoHidden').value = "1";
    idproductoEnviar = document.getElementById('idProductoHidden').value;
    var NumeroOperacionesEnviar;
    var idSelect;
    NumeroOperacionesEnviar = [];
    var registrosSeleccionados = idsOfSelectedRows;
    var allRowsInGrid = $('#list').getGridParam('data');
    contadorRegistros = allRowsInGrid.length;
    if (registrosSeleccionados != "") {
        idsOfSelectedRows.sort();
        for (i = 0, count = idsOfSelectedRows.length; i < count; i++) {
            idSelect = idsOfSelectedRows[i];
            if (contadorRegistros > 0) {
                for (j = 0; j < allRowsInGrid.length; j++) {
                    if (idSelect == allRowsInGrid[j].id) {
                        NumeroOperacionesEnviar.push(allRowsInGrid[j].fechaInicio + "|" + allRowsInGrid[j].folioOperacion + "|" + allRowsInGrid[j].fechaVencimiento + "|" + allRowsInGrid[j].rut + "|" + allRowsInGrid[j].secuencia + "|" + allRowsInGrid[j].nombreCliente + "|" + allRowsInGrid[j].tipoMovimiento + "|" + allRowsInGrid[j].monedaPrincipal + "|" + allRowsInGrid[j].montoPrincipal.replace(",", ".") + "|" + allRowsInGrid[j].monedaSecundario + "|" + allRowsInGrid[j].tcCierreForward + "|" + allRowsInGrid[j].montoSecundario + "|" + allRowsInGrid[j].cumplimiento + "|" + allRowsInGrid[j].agente + "|" + allRowsInGrid[j].montoLiquidacion + "|" + allRowsInGrid[j].margen + "|" + allRowsInGrid[j].cartera + "|" + allRowsInGrid[j].vehiculo + "|" + allRowsInGrid[j].folioAsociado + "|" + allRowsInGrid[j].fixingDate + "|" + allRowsInGrid[j].fechaAnticipo + "|" + allRowsInGrid[j].tasaAnticipo + "|" + allRowsInGrid[j].recibimosPagamos + "|" + allRowsInGrid[j].monedaAnticipo);
                        break;
                    }
                }
            }

        }
        var parametros = {
            "idProducto": idproductoEnviar,
            "Operaciones": NumeroOperacionesEnviar.toString(),
            "Reenvio": 'NO'
        };
        $.ajax({
            data: parametros,
            type: "POST",
            async: true,
            url: 'Forward/EnviarConfirmacionBlotter.aspx', success:
                function (resultado) {                
                    document.getElementById('DivPreload').style.display = "none";
                    jAlert("Las operaciones se han enviado correctamente para su confirmación","Finalizado");
                    idsOfSelectedRows = [];
                    var rowIds = $('#list').jqGrid('getDataIDs');
                    for (var i = 0, len = rowIds.length; i < len; i++) {
                        var currRow = rowIds[i];
                        $('#list').jqGrid('delRowData', currRow);
                       
                    }
                    
                }
        });
    }
    else {
        jAlert("No hay registros seleccionados para enviar confirmación, favor validar", "Error");
        document.getElementById('DivPreload').style.display = "none";
    }

}

function enviarAvisoVencimiento() {
    document.getElementById('DivPreload').style.display = "block";
    var idproductoEnviar = document.getElementById('idProductoHidden').value;
    var NumeroOperacionesEnviar;
    var idSelect;
    NumeroOperacionesEnviar = [];
    var registrosSeleccionados = idsOfSelectedRows;
    var allRowsInGrid = $('#list').getGridParam('data');
    contadorRegistros = allRowsInGrid.length;
    if (registrosSeleccionados != "") {
        idsOfSelectedRows.sort(function (a, b) { return a - b; });
        //alert(idsOfSelectedRows);
        for (i = 0, count = idsOfSelectedRows.length; i < count; i++) {
            idSelect = idsOfSelectedRows[i];
            if (contadorRegistros > 0) {
                for (j = 0; j < allRowsInGrid.length; j++) {
                    if (idSelect == allRowsInGrid[j].id) {
                        NumeroOperacionesEnviar.push(allRowsInGrid[j].rut + "|" + allRowsInGrid[j].folio + "|" + allRowsInGrid[j].razon_social + "|" + allRowsInGrid[j].fecha_vencimiento + "|" + allRowsInGrid[j].fecha_inicio + "|" + allRowsInGrid[j].modalidad + "|" + allRowsInGrid[j].TipoMov + "|" + allRowsInGrid[j].mont_mon_princ.replace(",", ".") + "|" + allRowsInGrid[j].tcTransf.replace(",", ".") + "|" + allRowsInGrid[j].CodMonPrinc);
                        break;
                    }
                }
            }

        }
        //alert(NumeroOperacionesEnviar.toString());
        var parametros = {
            "idProducto": idproductoEnviar,
            "Operaciones": NumeroOperacionesEnviar.toString(),
            "fechaVencimiento": fechaVencimiento,
            "Reenvio": 'NO'
        };
        $.ajax({
            data: parametros,
            type: "POST",
            async: true,
            url: 'Forward/EnviarAvisoVencimiento.aspx', success:
                function (resultado) {
                    document.getElementById('DivPreload').style.display = "none";
                    jAlert("Los avisos de vencimiento se han enviado correctamente.","Ok");
                    idsOfSelectedRows = [];
                    var rowIds = $('#list').jqGrid('getDataIDs');
                    for (var i = 0, len = rowIds.length; i < len; i++) {
                        var currRow = rowIds[i];
                        $('#list').jqGrid('delRowData', currRow);
                    }
                }
        });
    }
    else {
        jAlert("No hay registros seleccionados para enviar aviso de vencimiento, favor validar", "Error");
        document.getElementById('DivPreload').style.display = "none";
    }
}


$(document).ready(function () {
    if (document.getElementById('LblMensajeBlotter').innerHTML != ".") {

        if (document.getElementById('LblMensajeBlotter').innerHTML == "Archivo cargado correctamente") {
            document.getElementById('DivPreload').style.display = "block";
            $('#DivForwardBlotter').show();
            cargarGrillaForwardBlotter();
            document.getElementById('DivPreload').style.display = "none";
            document.getElementById("divGrilla").style.display = "block";
            ocultarBotones();
            $("#BtnEnviarConfirmacionBlotter").show();
        }
        else {
            $('#DivForwardBlotter').show();
            document.getElementById('DivPreload').style.display = "none";
        }

    }
});




function ocultarBotones() {
    $("#BtnExport").hide();
    $("#BtnEnviarConfirmacion").hide();
    $("#BtnEnviarConfirmacionBlotter").hide();
    $("#BtnReenviarConfirmacion").hide();
    $("#BtnEnviarAvisoVencimiento").hide();
}



function numFormat(cellvalue, options, rowObject) {
    return cellvalue.replace(",", ".");
}

function numUnformat(cellvalue, options, rowObject) {
    return cellvalue.replace(",", "-");   
   
}

function omitirAcentos(text) {
    var acentos = "ÃÀÁÄÂÈÉËÊÌÍÏÎÒÓÖÔÙÚÜÛãàáäâèéëêìíïîòóöôùúüûÑñÇç";
    var original = "AAAAAEEEEIIIIOOOOUUUUaaaaaeeeeiiiioooouuuunncc";
    for (var i = 0; i < acentos.length; i++) {
        text = text.replace(new RegExp(acentos.charAt(i), 'g'), original.charAt(i));
    }
    return text;
}