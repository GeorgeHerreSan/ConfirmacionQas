﻿var mydata;
var contadorRegistros = 0;
var pnumeroOperacion, prutCliente, pnombreCliente,pFechaOperacion, pMonto, pFechaFirma, pNdiasPendientes, pEstadoContrato;
var pFolio, pFechaEnvio, pRut, pSecuencia, pRazonSocial, pFechaInicio, pFechaVencimiento, pMtoMonPrinc, pTCcierre, pMtoMonSec, pModalidad, pDias, pTipoMov, pMonedaPrinc, pMonedaSec, pEjecutivo, pFechaEnvio, pFechaConf, pFechaElim, pEstado,
    pRespuestaConf;
var ID_OP, FECHA_CREACION,Index,INDEXM, COD_PER, FEC_VCTO_TP, NEMO, RUT_CLI, SEC_RUT_CLI, SEC_MOVTO, RSO_RAZ_SOCIAL, CANTIDAD, CANTIDAD_ACUM_VC, COD_AGENTE,
    COD_CORR_CONTRA, COD_SUC, FEC_LIQ_ANTICIP, FEC_LIQUID, FEC_TRANS, FOLIO_COMP_ADJ, FOLIO_TRANS, IND_TIT_CUS, INTERES_DIA,
    LIN_COMP_ADJ, MONTO, MONTO_ACUM_VC, PRECIO, SPREAD, TASA, TIPO_COMP_ADJ, TIPO_OPERAC, IND_LIQUID, PRECIO_CONTADO,
    IND_SIMUL, SEC_MOVTO_CTDO;//campos ;
var idsOfSelectedRows;
var pestado;
Index = 0;
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
function agregarfilasTabla(pFolio, pFechaEnvio, pRut, pSecuencia, pRazonSocial, pFechaInicio, pFechaVencimiento, pMtoMonPrinc, pTCcierre, pMtoMonSec, pModalidad, pDias, pTipoMov, pMonedaPrinc, pMonedaSec, pEjecutivo, pFechaEnvio, pFechaConf, pFechaElim, pEstado, pRespuestaConf)
{
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
//funciones FORWARD //Operaciones del día.
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

//fuciones Contratos Forward

function obtieneJsonContratoforwardDelDia() {
    pfecha = $('#datepickerContratoForwardOpDia').val();

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
            url: 'Forward/GeneraJsonResultadoContratoForwardDelDia.aspx', success:
                function (resultado) {
                    var jsonStr = resultado.substr(0, resultado.indexOf(']') + 1);
                    srtJson = jsonStr;
                    mydata = $.parseJSON(jsonStr);
                    cargarGrillaContratoForwarddelDia();
                    ocultarBotones();
                    $("#BtnEnviarContratosForward").show();
                    document.getElementById('idProductoHidden').value = 1;
                    document.getElementById('DivPreload').style.display = "none";
                    document.getElementById("divGrilla").style.display = "block";
                }
        });
    }
}
function cargarGrillaContratoForwarddelDia() {

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
            { name: 'razon_social', index: 'razon_social', align: "center", width: 200 },
            { name: 'fecha_inicio', index: 'fecha_inicio', align: "center", width: 90 },
            { name: 'fecha_vencimiento', index: 'fecha_vencimiento', align: "center", width: 90 },
            { name: 'mont_mon_princ', index: 'mont_mon_princ', align: "center", width: 90 },
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

function enviarContratosForward() {
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
            "Operaciones": NumeroOperacionesEnviar.toString()
        };
        $.ajax({
            data: parametros,
            type: "POST",
            async: true,
            url: 'Forward/EnviarContratosForward.aspx', success:
                function (resultado) {
                    document.getElementById('DivPreload').style.display = "none";
                    jAlert("Los contratos se han enviado correctamente para su confirmación", "Correcto");
                    $("#BtnEnviarContratosForwardDelDia").trigger("onclick");
                }
        });
    }
    else {
        jAlert("No hay registros seleccionados para enviar confirmación, favor validar", "Error");
        document.getElementById('DivPreload').style.display = "none";
    }

}

function obtieneJsonForwardConsultaOperacionesPendientes() {

    var pfecha = "";
    var pcliente = "";
    var pnumeroOperacion = "";
    var pestado = "1";
    var pestadoCont = "1";

    document.getElementById('DivPreload').style.display = "block";

    var parametros = {
        "fecha": pfecha,
        "cliente": pcliente,
        "nOperacion": pnumeroOperacion,
        "estado": pestado,
        "estadoCont": pestadoCont
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
                cargarGrillaForwardConsultaContratos();
                ocultarBotones();
                //$("#BtnExport").show();
                document.getElementById('DivPreload').style.display = "none";
                document.getElementById("divGrilla").style.display = "block";
                $("#exportForward").show();
            }
    });
    //}
}

function obtieneJsonForwardConsultaOperaciones() {
    pfecha = $('#datepickerForwardConsultaContratos').val();
    pcliente = $('#txtBuscarClientesForwardContratos').val();
    pnumeroOperacion = $('#txtBuscarNumOperacionForwardContratos').val();
    pestado = $('select[id=selectEstadoForwardConfirmacion]').val();
    pestadoCont = $('select[id=selectEstadoForwardContratos]').val();


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
        "estado": pestado,
        "estadoCont": pestadoCont
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
                cargarGrillaForwardConsultaContratos();
                ocultarBotones();
                $("#exportForward").show();
                document.getElementById('DivPreload').style.display = "none";
                document.getElementById("divGrilla").style.display = "block";
            }
    });
    //}
}
function cargarGrillaForwardConsultaContratos() {
    $("#list").jqGrid("GridUnload");
    $("#list").jqGrid({
        datatype: "local",
        data: mydata,
        //multiselect: true,
        cellEdit: true,
        autowidth: false,
        shrinkToFit: false,
        colNames: ['id', /*'Origen',*/ 'Folio', 'Rut', 'Secuencia', 'Razón Social', 'Fecha Inicio', 'Fecha Vencimiento', 'Días Transcurridos', 'Ver Contrato', 'Envío', 'Cambiar Estado', 'Monto Moneda principal', 'TC Cierre', 'Monto Moneda secundario', 'Modalidad', 'Dias', 'Tipo Movimiento', 'Moneda Principal', 'Moneda Secundaria', 'Ejecutivo', 'Fecha Envío', 'Fecha Confirmación', 'Fecha Eliminación', 'Estado', 'Respuesta Conf.'],
        colModel: [
            { name: 'id', index: 'id', width: 65, align: 'center', sorttype: 'int', hidden: true },
            //{ name: 'Origen', index: 'Origen', align: "center", width: 100 },
            { name: 'folio', index: 'folio', width: 100, align: "center" },
            { name: 'rut', index: 'rut', align: "center", width: 100 },
            { name: 'secuencia', index: 'secuencia', align: "center", width: 50 },
            { name: 'razon_social', index: 'razon_social', align: "center", width: 150 },
            { name: 'fecha_inicio', index: 'fecha_inicio', align: "center", width: 90 },
            { name: 'fecha_vencimiento', index: 'fecha_vencimiento', align: "center", width: 90 },
            { name: 'dias_totales', index: 'dias_totales', align: "center", width: 100 },
            { name: 'urlContrato', index: 'urlContrato', align: "center", width: 100 },
            { name: 'fecha_envio_contrato', index: 'fecha_envio_contrato', align: "center", width: 100 },
            { name: 'estado_contrato', index: 'estado_contrato', align: "center", width: 100 },
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

function CuadroEditarEstadosContratos(idco, clas, val) {
    $('#txtIDContrato').val(idco);
    $('#txtFolioContrato').val(clas);
    if (val == 'Seleccionar') {
        $('#slcCambioEstadoContrato').val('99');
    } else if (val == 'Creado') {
        $('#slcCambioEstadoContrato').val('0');
    } else if (val == 'Enviado') {
        $('#slcCambioEstadoContrato').val('1');
    } else if (val == 'No recepcionado') {
        $('#slcCambioEstadoContrato').val('2');
    } else if (val == 'Recepcionado') {
        $('#slcCambioEstadoContrato').val('3');
    } else if (val == 'Validación Legal') {
        $('#slcCambioEstadoContrato').val('4');
    } else if (val == 'Rechazado') {
        $('#slcCambioEstadoContrato').val('5');
    } else if (val == 'Autorizado') {
        $('#slcCambioEstadoContrato').val('6');
    }else{
        $('#slcCambioEstadoContrato').val('99');
    }
    $("#DivEditarEstado").dialog();
};

function editarEstadoContrato() {
    idContrato = $('#txtIDContrato').val();
    folioContrato = $('#txtFolioContrato').val();
    estadoContrato = $('#slcCambioEstadoContrato').val();

    if (estadoContrato == "99") {
        jAlert("Debe elegir un estado.", "Estado no válido");
    } else {
        document.getElementById('DivPreload').style.display = "block";
        var parametros = {
            "id": idContrato,
            "folio": folioContrato,
            "estado": estadoContrato
        };

        $.ajax({
            data: parametros,
            type: "POST",
            async: true,
            url: 'Forward/EditarEstadoContrato.aspx', success:
                function (resultado) {
                    ocultarBotones();
                    var jsonStr = resultado.substr(0, resultado.indexOf(']') + 1);
                    srtJson = jsonStr;
                    mydata = $.parseJSON(jsonStr);

                    $("#DivEditarEstado").dialog("close");
                    $("#btnBuscarContratosFWD").trigger("onclick");
                    jAlert("Se ha realizado el cambio de estado correctamente", "Resultado");
                }
        });
    }
};
//fin de funciones de contratos

//funciones SIMULTANEAS //Operaciones del día.
function obtieneJsonSimultaneasDelDia() {
    $("#BtnReenviarConfirmacion").hide();
    pfecha = $('#datepickerSimultaneaEnvio').val();
   // var fechax = pfecha.substr(3, 9).toString();
    if (pfecha== "") {
        jAlert("Debe ingresar Fecha", "Error");
        return false;
    }
    else {
        //var fechas = pfecha.remove(0,2);
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
                    $("#BtnEnviarConfirmacionSIM").show();

                    document.getElementById('DivPreload').style.display = "none";
                    document.getElementById("divGrilla").style.display = "block"; 
                }
        });
    }

}
//----------------------------------------------------------------EnviarSIM
function enviarConfirmacionSIM() {
    document.getElementById('DivPreload').style.display = "block";
    var idproductoEnviar = document.getElementById('idProductoHidden').value;
    var NumeroOperacionesEnviar;
    var idSelect;
    var xx;
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
                    idsOfSelectedRows[j]
                     xx = idSelect - 1;
                    if (idSelect == idsOfSelectedRows[j]) {

                        NumeroOperacionesEnviar.push("SIGA" + "|" + allRowsInGrid[xx].RSO_RAZ_SOCIAL + "|" + allRowsInGrid[xx].RUT_CLI + "|" + allRowsInGrid[xx].FOLIO_TRANS + "|" + allRowsInGrid[xx].FEC_TRANS); // + "|" + allRowsInGrid[xx]).id 

                       // NumeroOperacionesEnviar.push("SIGA" + "|" + allRowsInGrid[j].COD_PER + "|" + allRowsInGrid[j].FEC_VCTO_TP + "|" + allRowsInGrid[j].NEMO + "|" + allRowsInGrid[j].RUT_CLI + "|" + allRowsInGrid[j].SEC_RUT_CLI + "|" + allRowsInGrid[j].SEC_MOVTO + "|" + allRowsInGrid[j].RSO_RAZ_SOCIAL + "|" + allRowsInGrid[j].CANTIDAD + "|" + allRowsInGrid[j].CANTIDAD_ACUM_VC + "|" + allRowsInGrid[j].COD_AGENTE + "|" + allRowsInGrid[j].COD_CORR_CONTRA + "|" + allRowsInGrid[j].COD_SUC + "|" + allRowsInGrid[j].FEC_LIQ_ANTICIP + "|" + allRowsInGrid[j].FEC_LIQUID + "|" + allRowsInGrid[j].FEC_TRANS + "|" + allRowsInGrid[j].FOLIO_COMP_ADJ + "|" + allRowsInGrid[j].FOLIO_TRANS + "|" + allRowsInGrid[j].IND_TIT_CUS + "|" + allRowsInGrid[j].INTERES_DIA + "|" + allRowsInGrid[j].LIN_COMP_ADJ + "|" + allRowsInGrid[j].MONTO + "|" + allRowsInGrid[j].MONTO_ACUM_VC + "|" + allRowsInGrid[j].PRECIO + "|" + allRowsInGrid[j].SPREAD + "|" + allRowsInGrid[j].TASA + "|" + allRowsInGrid[j].TIPO_COMP_ADJ + "|" + allRowsInGrid[j].TIPO_OPERAC + "|" + allRowsInGrid[j].IND_LIQUID + "|" + allRowsInGrid[j].PRECIO_CONTADO + "|" + allRowsInGrid[j].IND_SIMUL + "|" + allRowsInGrid[j].SEC_MOVTO_CTDO);
                    break;
                   
                    }
                    
                }
               // var fechaCal = allRowsInGrid[0].COD_PER; //2019-12
                //var fech = fechaCal.split("-");
               // document.getElementById('datepickerSimultaneaEnvio').value = ;
              //  obtieneJsonSimultaneasDelDia();
               
               // obtieneJsonSimultaneasDelDia();
            }

        }
        //alert(NumeroOperacionesEnviar.toString());
        var parametros = {
            "idProducto": 2,
            "Operaciones": NumeroOperacionesEnviar.toString(),
            "Reenvio": 'NO'
        };
        $.ajax({
            data: parametros,
            type: "POST",
            async: true,
            url: 'Simultaneas/EnviarConfirmacion.aspx', success:
                function (resultado) {
                    document.getElementById('DivPreload').style.display = "none";
                    jAlert("Las operaciones se han enviado correctamente para su confirmación", "Ok", doAlert());
                    function doAlert() {
                        var xc = (parametros.Operaciones).length;
                        var valor1 = xc - 10;
                        var x = parametros.Operaciones.substr(valor1, 10);
                        var dd = x.substr(8, 2);
                        var mm = x.substr(5, 2);
                        var yy = x.substr(0, 4);
                        var fechaCarga = (dd + '-' + mm + '-' + yy).toString();
                        document.getElementById('datepickerSimultaneaEnvio').value = fechaCarga;
                        $("#btnCargarSIMd").trigger("onclick");
                        //obtieneJsonSimultaneasDelDia
                    }
                    
                   // $("#btnCargarOp").click(function () { doStuff(); });
                }
        });
      //  document.getElementById('datepickerSimultaneaEnvio').value =  FEC_TRANS;
      //  $("#btnCargarSIMd").trigger("onclick");
      //  $("#btnCargarSIMd")[0].onclick();
       
        //$("#btnCargarSIMd").trigger("onclick");
       // $("#btnCargarSIMd")[0].onclick();
       // obtieneJsonSimultaneasDelDia();
    }
    else {
        jAlert("No hay registros seleccionados para enviar confirmación, favor validar", "Error");
        document.getElementById('DivPreload').style.display = "none";
    }

}

//-----------------------------------------------------------------
function cargarGrillaSimultaneasdelDia() {

    Index++;
    $("#list").jqGrid("GridUnload");
    $("#list").jqGrid({
        datatype: "local",
        data: mydata,
        cellEdit: true,
        autowidth: false,
        shrinkToFit: false,
        colNames: ['Fecha Operación',
            'Fecha Vencimiento Operación', 'Folio Operación', 'Nemo', 'Rut Cliente',
            'Secuencia', 'Nombre Cliente', 'Agente', 'Cantidad Inicial', 'Precio Inicial',
            'Monto Inicial', 'Precio Actual', 'Monto Actual', 'Tipo Operación'//, '______FEC_LIQUID', 'FEC_TRANS', 'FOLIO_COMP_ADJ', 'FOLIO_TRANS', 'IND_TIT_CUS', 'INTERES_DIA',
            //'LIN_COMP_ADJ', 'MONTO', 'MONTO_ACUM_VC','PRECIO', 'SPREAD', 'TASA', 'TIPO_COMP_ADJ', 'TIPO_OPERAC', 'IND_LIQUID', 'PRECIO_CONTADO',
            //'IND_SIMUL', 'SEC_MOVTO_CTDO'
        ],
        colModel: [
            { name: 'FEC_TRANS', index: 'FEC_TRANS', align: "center", width: 113 },
            { name: 'FEC_VCTO_TP', index: 'FEC_VCTO_TP', width: 80, align: "center" },
            { name: 'FOLIO_TRANS', index: 'FOLIO_TRANS', align: "center", width: 113 },
            { name: 'NEMO', index: 'NEMO', width: 110, align: "center" },
            { name: 'RUT_CLI', index: 'RUT_CLI', width: 65, align: "center" },
            { name: 'SEC_RUT_CLI', index: 'SEC_RUT_CLI', align: "center", width: 115 },
            { name: 'RSO_RAZ_SOCIAL', index: 'RSO_RAZ_SOCIAL', align: "center", width: 140 },
            { name: 'COD_AGENTE', index: 'COD_AGENTE', align: "center", width: 140 },
            { name: 'CANTIDAD', index: 'CANTIDAD', align: "center", width: 140 },
            { name: 'PRECIO', index: 'PRECIO', align: "center", width: 113 },
            { name: 'MONTO', index: 'MONTO', align: "center", width: 113 },
            { name: 'PRECIO_CONTADO', index: 'PRECIO_CONTADO', align: "center", width: 113 },
            { name: 'MONTO_ACUM_VC', index: 'MONTO_ACUM_VC', align: "center", width: 113 },
            { name: 'TIPO_OPERAC', index: 'TIPO_OPERAC', align: "center", width: 113 }


           // { name: 'Id', index: 'Indexxs', width: 65, align: 'center', sorttype: 'int', hidden: true},
           // { name: 'COD_PER', index: 'COD_PER', width: 65, align: 'center'},
           // { name: 'SEC_MOVTO', index: 'SEC_MOVTO', align: "center", width: 85 },
           // { name: 'CANTIDAD_ACUM_VC', index: 'CANTIDAD_ACUM_VC', align: "center", width: 140 },
           // { name: 'COD_CORR_CONTRA', index: 'COD_CORR_CONTRA', align: "center", width: 140 },
           // { name: 'COD_SUC', index: 'COD_SUC', align: "center", width: 140 },
           // { name: 'FEC_LIQ_ANTICIP', index: 'FEC_LIQ_ANTICIP', align: "center", width: 140 },
           // { name: 'FEC_LIQUID', index: 'FEC_LIQUID', align: "center", width: 113 },
           //{ name: 'FOLIO_COMP_ADJ', index: 'FOLIO_COMP_ADJ', align: "center", width: 113 },
           // { name: 'IND_TIT_CUS', index: 'IND_TIT_CUS', align: "center", width: 113 },
           // { name: 'INTERES_DIA', index: 'INTERES_DIA', align: "center", width: 113 },
           // { name: 'LIN_COMP_ADJ', index: 'LIN_COMP_ADJ', align: "center", width: 113 },
           //  { name: 'SPREAD', index: 'SPREAD', align: "center", width: 113 },
           // { name: 'TASA', index: 'TASA', align: "center", width: 113 },
           // { name: 'TIPO_COMP_ADJ', index: 'TIPO_COMP_ADJ', align: "center", width: 113 },
           // { name: 'IND_LIQUID', index: 'IND_LIQUID', align: "center", width: 113 },     
           // { name: 'IND_SIMUL', index: 'IND_SIMUL', align: "center", width: 113 },
           // { name: 'SEC_MOVTO_CTDO', index: 'SEC_MOVTO_CTDO', align: "center", width: 113 }
            /*,*/
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
    selectEstadoSimultanea = $('#selectEstadoSimultanea').val();

    /* if ((pfecha == "") && (pcliente == "") && (pnumeroOperacion == "") && (selectEstadoSimultanea==0 )) {
         //alert("Debe ingresar Fecha");
         jAlert("Selecione un metodo de busqueda ", "Error");
         return false;
     }
     else {*/
    document.getElementById('DivPreload').style.display = "block";

    var parametros = {
        "fecha": pfecha,
        "cliente": pcliente,
        "nOperacion": pnumeroOperacion,
        "estado": selectEstadoSimultanea
    };

    $.ajax({
        sorttype: 'int',
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
//}
}
function cargarGrillaSimultaneasConsulta() {
    $("#list").jqGrid("GridUnload");
    $("#list").jqGrid({
        datatype: "local",
        data: mydata,
        multiselect: false,
        cellEdit: true,
        autowidth: false,
        shrinkToFit: false,
        colNames: ['id','Fecha Operación',
            'Fecha Vencimiento Operación', 'Folio Operación', 'Nemo', 'Rut Cliente',
            'Secuencia', 'Nombre Cliente', 'Agente', 'Cantidad Inicial', 'Precio Inicial',
            'Monto Inicial', 'Precio Actual', 'Monto Actual', 'Tipo Operación', 'Estado', 'PDF', 'ID_OP', 'FECHA_CREACION'//, '______FEC_LIQUID', 'FEC_TRANS', 'FOLIO_COMP_ADJ', 'FOLIO_TRANS', 'IND_TIT_CUS', 'INTERES_DIA',
           //'LIN_COMP_ADJ', 'MONTO', 'MONTO_ACUM_VC','PRECIO', 'SPREAD', 'TASA', 'TIPO_COMP_ADJ', 'TIPO_OPERAC', 'IND_LIQUID', 'PRECIO_CONTADO',
            //'IND_SIMUL', 'SEC_MOVTO_CTDO'
        ],
        colModel: [
            { name: 'INDEXM', index: 'INDEXM', align: "center", width: 113, sorttype: 'int',  hidden: true  },
            { name: 'FEC_TRANS', index: 'FEC_TRANS', align: "center", width: 113 },
            { name: 'FEC_VCTO_TP', index: 'FEC_VCTO_TP', width: 80, align: "center" },
            { name: 'FOLIO_TRANS', index: 'FOLIO_TRANS', align: "center", width: 113 },
            { name: 'NEMO', index: 'NEMO', width: 110, align: "center" },
            { name: 'RUT_CLI', index: 'RUT_CLI', width: 65, align: "center" },
            { name: 'SEC_RUT_CLI', index: 'SEC_RUT_CLI', align: "center", width: 115 },
            { name: 'RSO_RAZ_SOCIAL', index: 'RSO_RAZ_SOCIAL', align: "center", width: 140 },
            { name: 'COD_AGENTE', index: 'COD_AGENTE', align: "center", width: 140 },
            { name: 'CANTIDAD', index: 'CANTIDAD', align: "center", width: 140 },
            { name: 'PRECIO', index: 'PRECIO', align: "center", width: 113 },
            { name: 'MONTO', index: 'MONTO', align: "center", width: 113 },
            { name: 'PRECIO_CONTADO', index: 'PRECIO_CONTADO', align: "center", width: 113 },
            { name: 'MONTO_ACUM_VC', index: 'MONTO_ACUM_VC', align: "center", width: 113 },
            { name: 'TIPO_OPERAC', index: 'TIPO_OPERAC', align: "center", width: 113 },
            { name: 'ESTADO', index: 'ESTADO', align: "center", width: 113 },
            { name: 'PDF', index: 'PDF', align: "center", width: 113 },
            { name: 'ID_OP', index: 'ID_OP', align: "center", width: 113, hidden: true },
            { name: 'FECHA_CREACION', index: 'FECHA_CREACION', align: "center", width: 113, hidden: true }
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

//msn carga archivo Blotter
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


//mantenedores
function obtenerGrillaMantenedorCorreos() {
    ocultarBotones();
    mCorreo = $('#txtRutManCorreo').val();
    if (mCorreo == "" || mCorreo == null) {
        jAlert("Debe ingresar un Rut.", "Alerta");
    } else {
        idsOfSelectedRows = [];
        if (VerificaRut(mCorreo)) {
            document.getElementById('DivPreload').style.display = "block";
            var parametros = {
                "correo": mCorreo
            };

            $.ajax({
                data: parametros,
                type: "POST",
                async: true,
                url: 'Mantenedores/GeneraJsonMantenedorCorreos.aspx', success:
                    function (resultado) {
                        var jsonStr = resultado.substr(0, resultado.indexOf(']') + 1);
                        srtJson = jsonStr;
                        mydata = $.parseJSON(jsonStr);
                        ocultarBotones();
                        cargarGrillaMantenedorCorreos();
                        $("#BtnEnviarConfirmacion").hide();
                        document.getElementById('DivPreload').style.display = "none";
                        document.getElementById("divGrilla").style.display = "block";
                    }
            });
        } else {
            jAlert("El Rut ingresado no es válido, favor revisar y vuelver a intentar.", "Rut erroneo")
        }
    }
}
function cargarGrillaMantenedorCorreos() {
    $("#list").jqGrid("GridUnload");
    $("#list").jqGrid({
        datatype: "local",
        data: mydata,
        //cellEdit: true,
        //multiselect: false,
        autowidth: false,
        shrinkToFit: false,
        colNames: ['id', /*'Origen',*/ 'Email', 'Alias', 'Estado', 'Origen', 'Editar'],
        colModel: [
            { name: 'Idinte', index: 'Idinte', width: 65, align: 'center', sorttype: 'int', hidden: true },
            //{ name: 'Origen', index: 'Origen', align: "center", width: 100 },
            { name: 'Email', index: 'Email', width: 210, align: "center" },
            { name: 'Alias', index: 'Alias', align: "center", width: 60 },
            { name: 'Estado', index: 'Estado', align: "center", width: 60 },
            { name: 'Origen', index: 'Origen', align: "center", width: 60 },
            { name: 'Editar', index: 'Editar', align: "center", width: 70 }
            //{ name: 'Eliminar', index: 'Eliminar', width: 93, align: 'center', formatter: 'checkbox', edittype: 'checkbox', editoptions: { value: 'Yes:No', defaultValue: 'Yes' } }
            //{ name: '<input type="button" class="botones2"  value="-"/>', index:'Eliminar', align: "center", width: 50 },
            //{ name: 'Eliminar', index: 'Eliminar', align: "center", width: 70 }
        ],


        height: 210,
        rowNum: 15,
        //rowList: [5,10,15],
        //scroll: 1, // set the scroll property to 1 to enable paging with scrollbar - virtual loading of records
        emptyrecords: 'Scroll to bottom to retrieve new page', // the message will be displayed at the bottom 
        pager: "#jqGridPager",
        caption: "Resultado de Búsqueda",
        viewrecords: true,
        sortorder: 'desc',
        caption: 'Resultado Mantenedor de Correos',
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

    document.getElementById("divGrilla").style.display = "block";

}

function editarCorreo(idco, clas) {

    document.getElementById('DivPreload').style.display = "block";
    var parametros = {
        "idCorreo": idco,
        "idCliente": clas
    };
    $.ajax({
        data: parametros,
        type: "POST",
        async: true,
        url: 'Mantenedores/ObtenerDatosCorreo.aspx', success:
            function (resultado) {
                var jsonStr = resultado.substr(0, resultado.indexOf('|'));
                obj = $.parseJSON(jsonStr);
                var id = obj.info[0].id;
                var Email = obj.info[0].Email;
                var Alias = obj.info[0].Alias;
                var Estado = obj.info[0].Estado;
                $('#txtEmail').val(Email);
                $('#txtAlias').val(Alias);
                $('#selEstado').val(Estado);
                $('#valID').val(idco);
                $('#valCli').val(clas);
                $("#editaCorreos").dialog({
                    width: "500px",
                    maxWidth: "768px"
                });
                
                $("#BtnEnviarConfirmacion").hide();
                document.getElementById('DivPreload').style.display = "none";
            }
    });
};
function editarElCorreo() {
    eEmail = $('#txtEmail').val().trim();
    eAlias = $('#txtAlias').val().trim();
    eEstado = $('#selEstado').val();
    idEditar = $('#valID').val();
    buscaRut = $('#valCli').val();

    if (eEmail == "" || /*eAlias == "" ||*/ eEstado == "" || idEditar == "" || buscaRut == "") {
        jAlert("Revise los campos, no deben estar vacios.", "Datos inválidos");
    } else {
        var revisaEmail;
        revisaEmail = this.validarEmail(eEmail)
        if (revisaEmail == "valido") {

            document.getElementById('DivPreload').style.display = "block";
            var parametros = {
                "Email": eEmail,
                "Alias": eAlias,
                "Estado": eEstado,
                "Id": idEditar,
                "Rut": buscaRut
            };

            $.ajax({
                data: parametros,
                type: "POST",
                async: true,
                url: 'Mantenedores/EditarCorreos.aspx', success:
                    function (resultado) {
                        ocultarBotones();
                        var jsonStr = resultado.substr(0, resultado.indexOf(']') + 1);
                        srtJson = jsonStr;
                        mydata = $.parseJSON(jsonStr);
                        cargarGrillaMantenedorCorreos();
                        $("#BtnEnviarConfirmacion").hide();
                        document.getElementById('DivPreload').style.display = "none";
                        document.getElementById("divGrilla").style.display = "block";
                        $("#editaCorreos").dialog("close");
                        jAlert("Cambios realizados correctamente", "Resultado");
                    }
            });
        } else {
            jAlert("El correo ingresado no tiene un formato válido.","Correo no válido")
        }
    }
};

function eliminarCorreo(idco, clas) {
    eliminaID = idco;
    buscaRut = clas;
    document.getElementById('DivPreload').style.display = "block";
    var parametros = {
        "Id": eliminaID,
        "Rut": buscaRut
    };

    $.ajax({
        data: parametros,
        type: "POST",
        async: true,
        url: 'Mantenedores/EliminarCorreo.aspx', success:
            function (resultado) {
                var jsonStr = resultado.substr(0, resultado.indexOf(']') + 1);
                srtJson = jsonStr;
                mydata = $.parseJSON(jsonStr);
                cargarGrillaMantenedorCorreos();
                ocultarBotones();
                $("#BtnEnviarConfirmacion").hide();
                document.getElementById('DivPreload').style.display = "none";
                document.getElementById("divGrilla").style.display = "block";
            }
    });
    //$("#dialog2").dialog(id);
};

function crearCorreos() {
    $("#crearCorreos").dialog({
        width: "500px",
        maxWidth: "768px"
    });
};
function validarEmail(valor) {
    if (/^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i.test(valor)) {
        return "valido";
    } else {
        return "invalido";
    }
}
function agregarCorreo() {
    aEmail = ($('#txtemail').val()).trim();
    aAlias = ($('#txtalias').val()).trim();
    aRut = ($('#txtrutcc').val()).trim();
    if (aEmail == "" || aAlias == "" || aRut == "") {
        jAlert("Revise los campos, no deben estar vacios.", "Datos inválidos");
    } else {
        if (VerificaRut(aRut)) {
            var revisaEmail;
            revisaEmail = this.validarEmail(aEmail)
            if (revisaEmail == "valido") {
                document.getElementById('DivPreload').style.display = "block";
                var parametros = {
                    "Email": aEmail,
                    "Alias": aAlias,
                    "Rut": aRut
                };

                $.ajax({
                    data: parametros,
                    type: "POST",
                    async: true,
                    url: 'Mantenedores/AgregarCorreo.aspx', success:
                        function (resultado) {
                            document.getElementById('DivPreload').style.display = "none";
                            $("#crearCorreos").dialog("close");
                            //$("#guardado").dialog("close");
                            //$('#respuesta').val();
                            //$("#resultados").dialog();
                            //document.getElementById('idProductoHidden').value = 1;
                            $("#BtnEliminarListaDistribucion").hide();
                            $("#BtnGuardarCambiosListaDistribucion").hide();
                            if (resultado.indexOf("seencontroregistro") > -1) {
                                jAlert("Se encontró ya registrado el correo ingresado, favor usar otro.", "Resultado");
                            } else {
                                jAlert("El correo se registró correctamente.", "Resultado");
                            }
                        }
                });
            } else {
                jAlert("La dirección de email es incorrecta.", "Datos inválidos");
            }
        } else {
            jAlert("El Rut ingresado es incorrecto, revise lo ingresado.", "Rut erroneo")
        }
    }
}

function obtenerListaDistribucion() {
    lRut = ($('#txtRutLista').val()).trim();
    lProLista = ($('#selProductoLista').val()).trim();
    lSecuencia = ($('#txtSecuenciaLista').val()).trim();

    if (lRut == "" || lProLista == "") {
        jAlert("Debe ingresar un rut y una lista.", "Atención");
    } else {
        if (VerificaRut(lRut)) {
            if (lSecuencia == "" || lSecuencia == null) {
                lSecuencia = "-1";
            }
            document.getElementById('DivPreload').style.display = "block";
            var parametros = {
                "Rut": lRut,
                "Lista": lProLista,
                "Secuancia": lSecuencia
            };
            idsOfSelectedRows = [];
                $.ajax({
                    data: parametros,
                    type: "POST",
                    async: true,
                    url: 'Mantenedores/GeneraJsonListaDistribucion.aspx', success:
                        function (resultado) {
                            var jsonStr = resultado.substr(0, resultado.indexOf(']') + 1);
                            srtJson = jsonStr;
                            mydata = $.parseJSON(jsonStr);
                            if (mydata[0].Idlist.trim() == "" || mydata[0].Idlist.trim() == null && mydata[0].Idcli.trim() == "" || mydata[0].Idcli.trim() == null && mydata[0].Email.trim() == "" || mydata[0].Email.trim() == null && mydata[0].Alias.trim() == "" || mydata[0].Alias.trim() == null) {
                                ocultarBotones();
                                document.getElementById('DivPreload').style.display = "none";
                                document.getElementById("divGrilla").style.display = "none";
                                jAlert("El Rut ingresado no posee lista, debe crearle una lista.", "No se encontraron datos");
                            } else {
                            cargarGrillaAdminDistribucion();
                            ocultarBotones();
                            $("#BtnGuardarCambiosListaDistribucion").show();
                            $("#BtnEliminarListaDistribucion").show();
                            document.getElementById('DivPreload').style.display = "none";
                            document.getElementById("divGrilla").style.display = "block";
                            }
                        }
            });
        } else {
            jAlert("El Rut ingresado es incorrecto, revise lo ingresado.", "Rut erroneo")
        }
    }
}

function obtenerListaDistribucionPostCambio() {
    lRut = ($('#txtRutLista').val()).trim();
    lProLista = ($('#selProductoLista').val()).trim();
    lSecuencia = ($('#txtSecuenciaLista').val()).trim();

    if (lRut == "" || lProLista == "") {
        jAlert("Debe ingresar un rut y una lista.", "Atención");
    } else {
        if (VerificaRut(lRut)) {
            if (lSecuencia == "" || lSecuencia == null) {
                lSecuencia = "-1";
            }
            document.getElementById('DivPreload').style.display = "block";
            var parametros = {
                "Rut": lRut,
                "Lista": lProLista,
                "Secuancia": lSecuencia
            };

            $.ajax({
                data: parametros,
                type: "POST",
                async: true,
                url: 'Mantenedores/GeneraJsonListaDistribucion.aspx', success:
                    function (resultado) {
                        var jsonStr = resultado.substr(0, resultado.indexOf(']') + 1);
                        srtJson = jsonStr;
                        mydata = $.parseJSON(jsonStr);
                        var id = mydata[0].Idlist.trim();
                        var idcli = mydata[0].Idcli.trim();
                        var email = mydata[0].Email.trim();
                        var alias = mydata[0].Alias.trim();
                        if (id == "" || id == null && idcli == "" || idcli == null && email == "" || email == null && alias == "" || alias == null) {
                            document.getElementById('DivPreload').style.display = "none";
                            document.getElementById("divGrilla").style.display = "none";
                        } else {
                            cargarGrillaAdminDistribucion();
                            $("#BtnExport").hide();
                            $("#BtnEnviarConfirmacion").hide();
                            $("#BtnGuardarListaDistribucion").hide();
                            $("#btnGuardarCambios").hide();
                            $("#BtnGuardarCambiosListaDistribucion").show();
                            $("#BtnEliminarListaDistribucion").show();
                            document.getElementById('DivPreload').style.display = "none";
                            document.getElementById("divGrilla").style.display = "block";
                        }
                    }
            });
        } else {
            jAlert("El no es válido el Rut, Favor revisar.", "Rut erroneo")
        }
    }
}

function cargarGrillaAdminDistribucion() {
    ocultarBotones();
    $("#btnGuardarCambios").show();

    $("#list").jqGrid("GridUnload");
    $("#list").jqGrid({
        datatype: "local",
        data: mydata,
        //multiselect: true,
        cellEdit: true,
        autowidth: false,
        shrinkToFit: false,
        colNames: ['ID Correo', 'ID cliente', 'Email', 'Alias', 'Apoderado',/* 'Secuencia',*/ 'Incluido', 'Estado'],
        colModel: [
            { name: 'Idlist', index: 'Idlist', width: 30, align: "center", hidden: true },
            { name: 'Idcli', index: 'Idcli', width: 30, align: "center", hidden: true },
            { name: 'Email', index: 'Email', width: 200, align: "center" },
            { name: 'Alias', index: 'Alias', width: 60, align: "center" },
            {
                name: 'Apoderado', index: 'Apoderado',
                width: 60,
                align: "center",
                editoptions: { value: "True:False" },
                editrules: { required: true },
                formatter: "checkbox",
                formatoptions: { disabled: false },
                editable: false
            },
            //{ name: 'Secuencia', index: 'Secuencia', width: 80, align: "center" },
            {
                name: 'Incluido',
                index: 'Incluido',
                width: 60,
                align: "center",
                editoptions: { value: "True:False" },
                editrules: { required: true },
                formatter: "checkbox",
                formatoptions: { disabled: false },
                editable: false
            },
            { name: 'Estado', index: 'Estado', width: 70, align: "center" }
        ],
        beforeSelectRow: function (rowid, e) {
            var $self = $(this),
                iCol = $.jgrid.getCellIndex($(e.target).closest("td")[0]),
                cm = $self.jqGrid("getGridParam", "colModel"),
                localData = $self.jqGrid("getLocalRow", rowid);
            if (cm[iCol].name === "Apoderado" && e.target.tagName.toUpperCase() === "INPUT") {
                // set local grid data
                localData.Apoderado = $(e.target).is(":checked");
                //alert(JSON.stringify(localData));
            } else if (cm[iCol].name === "Incluido" && e.target.tagName.toUpperCase() === "INPUT") {
                // set local grid data
                localData.Incluido = $(e.target).is(":checked");
                //alert(JSON.stringify(localData));
            }
            return true; // allow selection
        },
        height: 210,
        rowNum: 15,
        //scroll: 1, // set the scroll property to 1 to enable paging with scrollbar - virtual loading of records
        emptyrecords: 'Scroll to bottom to retrieve new page', // the message will be displayed at the bottom 
        pager: "#jqGridPager",
        caption: 'Resultado de Lista de distribución',
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
    document.getElementById("divGrilla").style.display = "block";
}

function guardarCambiosListaDistribucion() {
    ldSecuencia = ($('#txtSecuenciaLista').val()).trim();
    ldProdLista = ($('#selProductoLista').val()).trim();
    if (ldProdLista == "" || ldProdLista == null) {
        jAlert("Debe seleccionar un producto", " ");
    } else {
        if (ldSecuencia == "" || ldSecuencia == null) {
            ldSecuencia = "-1";
        }
        document.getElementById('DivPreload').style.display = "block";
        var idproductoEnviar = document.getElementById('idProductoHidden').value;
        var NumCorreosLista;
        var idSelect;
        NumCorreosLista = [];
        var registrosSeleccionados = idsOfSelectedRows;

        var allRowsInGrid = $('#list').getGridParam('data');
        contadorRegistros = allRowsInGrid.length;

        var allRowsInGrid = $('#list').getGridParam('data');
        contadorRegistros = allRowsInGrid.length;

        if (contadorRegistros > 0) {
            for (i = 0; i < allRowsInGrid.length; i++) {
                NumCorreosLista.push(
                    allRowsInGrid[i].Idlist +
                    "|" + allRowsInGrid[i].Idcli +
                    "|" + allRowsInGrid[i].Email +
                    "|" + allRowsInGrid[i].Alias +
                    "|" + allRowsInGrid[i].Apoderado +
                    "|" + allRowsInGrid[i].Secuencia +
                    "|" + allRowsInGrid[i].Incluido);

            }
            var parametros = {
                "ListaDistribucion": NumCorreosLista.toString(),
                "Secuencia": ldSecuencia,
                "Producto": ldProdLista
            };
            $.ajax({
                data: parametros,
                type: "POST",
                async: true,
                url: 'Mantenedores/GuardarCambiosListaDistribucion.aspx', success:
                    function (resultado) {
                        obtenerListaDistribucionPostCambio();
                        document.getElementById('DivPreload').style.display = "none";
                        jAlert("La lista de distribución se ha editado correctamente", "Cambios realizados");
                    }
            });
        }
        else {
            jAlert("No hay registros en grilla, favor validar", "Error");
        }
    }

}

function eliminarListaDistribucion() {
    lRut = ($('#txtRutLista').val()).trim();
    lProLista = ($('#selProductoLista').val()).trim();
    lSecuencia = ($('#txtSecuenciaLista').val()).trim();

    if (lRut == "" || lProLista == "") {
        jAlert("Debe ingresar un rut y una lista.", "Atención");
    } else {
        if (lSecuencia == "" || lSecuencia == null) {
            lSecuencia = "-1";
        }
        document.getElementById('DivPreload').style.display = "block";
        var parametros = {
            "Rut": lRut,
            "Producto": lProLista,
            "Secuancia": lSecuencia
        };

        $.ajax({
            data: parametros,
            type: "POST",
            async: true,
            url: 'Mantenedores/EliminaListaDistribucion.aspx', success:
                function (resultado) {
                    //var jsonStr = resultado.substr(0, resultado.indexOf(']') + 1);
                    //srtJson = jsonStr;
                    //mydata = $.parseJSON(jsonStr);
                    //cargarGrillaAdminDistribucion();
                    $("#BtnExport").hide();
                    $("#BtnEnviarConfirmacion").hide();
                    $("#BtnGuardarListaDistribucion").hide();
                    $("#BtnGuardarCambiosListaDistribucion").hide();
                    $("#BtnEliminarListaDistribucion").hide();
                    $("#btnGuardarCambios").hide();
                    document.getElementById('DivPreload').style.display = "none";
                    document.getElementById("divGrilla").style.display = "none";
                    jAlert("Se ha eliminado la lista de distribución.", "Eliminado");
                }
        });
    }
}

function crearNuevaLista() {
    lRut = ($('#txtRutLista').val()).trim();
    lProLista = ($('#selProductoLista').val()).trim();
    lSecuencia = ($('#txtSecuenciaLista').val()).trim();

    if (lRut == "" || lProLista == "") {
        jAlert("Se necesita un Rut y un producto para crear la lista.", "Faltan datos");
    } else {
        idsOfSelectedRows = [];
        if (lSecuencia == "" || lSecuencia == null) {
            lSecuencia = "-1";
        }
        document.getElementById('DivPreload').style.display = "block";
        var parametros = {
            "Rut": lRut,
            "Lista": lProLista,
            "Secuencia": lSecuencia
        };

        $.ajax({
            data: parametros,
            type: "POST",
            async: true,
            url: 'Mantenedores/GeneraJsonNuevaListaDistribucion.aspx', success:
                function (resultado) {
                    var jsonStr = resultado.substr(0, resultado.indexOf(']') + 1);
                    srtJson = jsonStr;
                    mydata = $.parseJSON(jsonStr);
                    crearGrillaAdminDistribucion();
                    //$("#BtnExport").show();
                    ocultarBotones();
                    $("#BtnGuardarListaDistribucion").show();
                    document.getElementById('DivPreload').style.display = "none";
                    document.getElementById("divGrilla").style.display = "block";
                }
        });
    }
}

function crearGrillaAdminDistribucion() {
    ocultarBotones();
    $("#btnGuardarCambios").show();

    $("#list").jqGrid("GridUnload");
    $("#list").jqGrid({
        datatype: "local",
        data: mydata,
        multiselect: true,
        cellEdit: true,
        autowidth: false,
        shrinkToFit: false,
        colNames: ['ID', 'id correo', 'ID cliente', 'Email', 'Alias', 'Origen', 'Firmante'],
        colModel: [
            { name: 'id', index: 'id', width: 30, align: "center", hidden: true },
            { name: 'Idlist', index: 'Idlist', width: 30, align: "center", hidden: true },
            { name: 'Idcli', index: 'Idcli', width: 30, align: "center", hidden: true },
            { name: 'Email', index: 'Email', width: 200, align: "center" },
            { name: 'Alias', index: 'Alias', width: 60, align: "center" },
            { name: 'Origen', index: 'Origen', width: 80, align: "center" },
            {
                name: 'Firmante',
                index: 'Firmante',
                width: 60,
                align: "center",
                editoptions: { value: "True:False" },
                editrules: { required: true },
                formatter: "checkbox",
                formatoptions: { disabled: false },
                editable: false
            }
            //{ name: 'enviar', index: 'enviar', align: "center", width: 50, editable: false, edittype: 'checkbox', editoptions: { value: "True:False" }, formatter: "checkbox", formattingptions: { disabled: true } }
        ],
        beforeSelectRow: function (rowid, e) {
            var $self = $(this),
                iCol = $.jgrid.getCellIndex($(e.target).closest("td")[0]),
                cm = $self.jqGrid("getGridParam", "colModel"),
                localData = $self.jqGrid("getLocalRow", rowid);
            if (cm[iCol].name === "Firmante" && e.target.tagName.toUpperCase() === "INPUT") {
                // set local grid data
                localData.Firmante = $(e.target).is(":checked");
                //alert(JSON.stringify(localData));
            }
            return true; // allow selection
        },
        height: 210,
        rowNum: 15,
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
        caption: 'Resultado de la búsqueda para lista de Distribución',
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

function crearNuevaListaDistribucion() {
    ldSecuencia = ($('#txtSecuenciaLista').val()).trim();
    ldProdLista = ($('#selProductoLista').val()).trim();
    if (ldProdLista == "" || ldProdLista == null) {
        jAlert("Debe seleccionar un producto", " ");
    } else {
        if (ldSecuencia == "" || ldSecuencia == null) {
            ldSecuencia = "-1";
        }
        document.getElementById('DivPreload').style.display = "block";
        var idproductoEnviar = document.getElementById('idProductoHidden').value;
        var NumCorreosLista;
        var idSelect;
        NumCorreosLista = [];
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
                            NumCorreosLista.push(//allRowsInGrid[j].rut +
                                allRowsInGrid[j].Idlist +
                                //"|" + allRowsInGrid[j].Idlist +
                                "|" + allRowsInGrid[j].Idcli +
                                "|" + allRowsInGrid[j].Email +
                                "|" + allRowsInGrid[j].Alias +
                                "|" + allRowsInGrid[j].Origen +
                                "|" + allRowsInGrid[j].Firmante );
                            break;
                        }
                    }
                }

            }
            //alert(NumeroOperacionesEnviar.toString());
            var parametros = {
                "ListaDistribucion": NumCorreosLista.toString(),
                "Secuencia": ldSecuencia,
                "Producto": ldProdLista
            };
            $.ajax({
                data: parametros,
                type: "POST",
                async: true,
                url: 'Mantenedores/GuardarListaDeDistribucion.aspx', success:
                    function (resultado) {
                        ocultarBotones();
                        document.getElementById('DivPreload').style.display = "none";
                        document.getElementById("divGrilla").style.display = "none";
                        jAlert("La lista de distribución se ha guardado correctamente", "Registro exitoso");
                    }
            });
        }
        else {
            jAlert("No hay registros seleccionados para enviar confirmación, favor validar", "Error");
            document.getElementById('DivPreload').style.display = "none";
        }
    }

}

function guardarLista() {
    jAlert("Se han guardado los cambios exitosamente.", "Cambios realizados");
}
//fin mantenedores


function ocultarBotones() {
    $("#BtnExport").hide();
    $("#BtnEnviarConfirmacionSIM").hide();
    $("#BtnEnviarConfirmacion").hide();
    $("#BtnEnviarConfirmacionBlotter").hide();
    $("#BtnReenviarConfirmacion").hide();
    $("#BtnEnviarAvisoVencimiento").hide();
    $("#btnGuardarCambios").hide();
    $("#BtnEliminarListaDistribucion").hide();
    $("#BtnGuardarCambiosListaDistribucion").hide();
    $("#BtnGuardarListaDistribucion").hide();
    $("#BtnEnviarContratosForward").hide();
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

function CuadroEditarEstadosContratosSIM(id, clas, val) {
    $('#txtIDContratos').val(id);
    $('#txtFolioContratos').val(clas);
    var ValorNada = 99;
    if (val == 'Seleccionar') { $('#slcCambioEstadoContratos').val('99'); }
    if (val == 'Enviado') { $('#slcCambioEstadoContratos').val('1'); }
    if (val == 'Confirmado') { $('#slcCambioEstadoContratos').val('2'); }
    if (val == 'No Confirmado') { $('#slcCambioEstadoContratos').val('3'); }
    if (val == 'Eliminado') { $('#slcCambioEstadoContratos').val('4'); }
    // $('#slcCambioEstadoContratos').val(ValorNada);
    $("#DivEditarEstadoSIM").dialog();
};

function editarEstadoContratoSIM() {
    idContrato = $('#txtIDContratos').val();
    folioContrato = $('#txtFolioContratos').val();
    estadoContrato = $('#slcCambioEstadoContratos').val();

    if (estadoContrato == "99") {
        jAlert("Debe elegir un estado.", "Estado no válido");
    } else {
        document.getElementById('DivPreload').style.display = "block";
        var parametros = {
            "id": idContrato,
            "folio": folioContrato,
            "estado": estadoContrato
        };

        $.ajax({
            data: parametros,
            type: "POST",
            async: true,
            url: 'Simultaneas/EditarEstadoSimultanea.aspx', success:
                function (resultado) {
                    ocultarBotones();
                    var jsonStr = resultado.substr(0, resultado.indexOf(']') + 1);
                    srtJson = jsonStr;
                    mydata = $.parseJSON(jsonStr);

                    $("#DivEditarEstadoSIM").dialog("close");
                    $("#JsonSimultaneasConsulta").trigger("onclick");
                    jAlert("Se ha realizado el cambio de estado correctamente", "Resultado");
                }
        });
    }
}

function formatoRut(rut) {
    // Despejar Puntos
    var valor = rut.value.replace('.', '');
    // Despejar Guión
    valor = valor.replace('-', '');
    // Aislar Cuerpo y Dígito Verificador
    cuerpo = valor.slice(0, -1);
    dv = valor.slice(-1).toUpperCase();
    // Formatear RUN
    rut.value = cuerpo + '-' + dv
}

function VerificaRut(rut) {
    if (rut.toString().trim() != '' && rut.toString().indexOf('-') > 0) {
        var caracteres = new Array();
        var serie = new Array(2, 3, 4, 5, 6, 7);
        var dig = rut.toString().substr(rut.toString().length - 1, 1);
        rut = rut.toString().substr(0, rut.toString().length - 2);

        for (var i = 0; i < rut.length; i++) {
            caracteres[i] = parseInt(rut.charAt((rut.length - (i + 1))));
        }

        var sumatoria = 0;
        var k = 0;
        var resto = 0;

        for (var j = 0; j < caracteres.length; j++) {
            if (k == 6) {
                k = 0;
            }
            sumatoria += parseInt(caracteres[j]) * parseInt(serie[k]);
            k++;
        }

        resto = sumatoria % 11;
        dv = 11 - resto;

        if (dv == 10) {
            dv = "K";
        }
        else if (dv == 11) {
            dv = 0;
        }

        if (dv.toString().trim().toUpperCase() == dig.toString().trim().toUpperCase())
            return true;
        else
            return false;
    }
    else {
        return false;
    }
}
