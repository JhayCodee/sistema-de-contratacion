
$(document).ready(function () {

    $('#tablaEmpleados').DataTable({
    
        ajax: {
            "url": "/Empleados/EmpleadosJson",
            "type": "GET"
        },
        dom: "<'row'<'col-md-12'B>>" + "<'row'<'col-md-6'l><'col-md-6'f>>" + "<'row'<'col-md-12'tr>>" + "<'row'<'col-md-5'i><'col-md-7'p>>",
        lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "TODOS"]],
        pageLength: 10,
        columns: [
            //{ "data": "IdEmpleado" },
            { "data": "Codigo" },
            { "data": "Nombres" },
            { "data": "Apellidos" },

            {
                "data": "Genero",
                "render": function (data, type, row) {
                    return data == 1 ? "Masculino" : "Femenino";
                }
            },
            { "data": "TelefonoPersonal" },
            {
                "data": "EmailPersonal",
            },
            {
                "data": "FechaInicio",
                "render": function (data, type, row) {
                    return moment(data).format('YYYY/MM/DD');
                }
            },
            {
                "data": "FechaFin",
                "render": function (data, type, row) {
                    if (data == null) {
                        return "Indefinido";
                    } else {
                        return moment(data).format('YYYY/MM/DD');
                    }
                }
            },
            { "data": "NombreArea" },
            { "data": "NombreCargo" },
            { "data": "TipoContrato" },
            { "data": "Salario" },
            {
                "data": "Fotografia",
                "render": function (data, type, row) {
                    if (row.Fotografia) {
                        return '<img src="' + row.Fotografia + '" width="100" alt="Imagen del trabajador"/>';
                    } else {
                        return '<img src="/Content/Images/defaultimg.png" width="100" alt="Imagen por defecto"/>';
                    }
                },
            },
            {
                "data": null,
                "render": function (data, type, row) {
                    return '<a href="' + editarUrl + '/' + row.IdEmpleado + '" class="btn btn-primary mx-1">Editar</a>';
                }
            }
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
                    window.location.href = "/Empleados/AgregarEmpleado";
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

