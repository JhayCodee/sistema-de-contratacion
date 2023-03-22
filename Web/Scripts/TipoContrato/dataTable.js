$(document).ready(function () {

    $('#tablaAreas').DataTable({

        ajax: {
            "url": "/TipoContrato/TipoContratoJson",
            "type": "GET",
        },
        dom: "<'row'<'col-md-12'B>>" + "<'row'<'col-md-6'l><'col-md-6'f>>" + "<'row'<'col-md-12'tr>>" + "<'row'<'col-md-5'i><'col-md-7'p>>",
        lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "TODOS"]],
        pageLength: 10,
        columns: [
            //{ "data": "IdEmpleado" },
            { "data": "NombreTipoContrato" },
            { "data": "AplicaAguinaldo" },
            { "data": "AplicaIndemnizacion" },
            { "data": "Activo" },
            {
                "data": null,
                "render": function (data, type, row) {
                    return '<a href="' + editarUrl + '/' + row.IdTipoContrato + '" class="btn btn-primary mx-1">Editar</a>';
                }
            },
        ],
        language: {
            lengthMenu: "MOSTRAR _MENU_ REGISTROS",
            noData: "No hay información para mostrar.",
            sProcessing: "Procesando...",
            sLengthMenu: "Mostrar _MENU_ registros",
            sZeroRecords: "No se encontraron resultados",
            sEmptyTable: "Ningún dato disponible en esta tabla",
            sInfo: "_START_ al _END_ / total _TOTAL_",
            sInfoEmpty: "0 al 0 de 0 registros",
            sInfoFiltered: "(filtrado de un total de _MAX_ registros)",
            sInfoPostFix: "",
            sSearch: "Buscar:",
            sUrl: "",
            sInfoThousands: ",",
            sLoadingRecords: "Cargando...",
            oPaginate: {
                sFirst: "Primero",
                sLast: "Último",
                sNext: "Siguiente",
                sPrevious: "Anterior"
            },
            oAria: {
                sSortAscending: ": Activar para ordenar la columna de manera ascendente",
                sSortDescending: ": Activar para ordenar la columna de manera descendente"
            },
        },
        buttons: [
            {
                text: 'Agregar',
                titleAttr: "Crear un nuevo registro",
                action: function (e, dt, node, config) {
                    window.location.href = "/TipoContrato/AgregarTipoContrato";
                }
            },
            {
                extend: "excel",
                text: "Excel",
                titleAttr: 'Exportar datos a excel'
            },

        ]

    });


});

