$(document).ready(function () {
    $('#fechaCorte').submit(function (e) {
        e.preventDefault();

        var fecha = $('input[name="corte"]').val();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: { daterange: fecha },
            success: function (data) {

                // Aquí procesas los datos recibidos
                //console.log(data);

                // Inicializar la datatable
                var tabla = $('#tablaPrestaciones').DataTable({
                    destroy: true,
                    dom: "<'row'<'col-md-12'B>>" + "<'row'<'col-md-6'l><'col-md-6'f>>" + "<'row'<'col-md-12'tr>>" + "<'row'<'col-md-5'i><'col-md-7'p>>",
                    lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "TODOS"]],
                    pageLength: 10,
                    data: data.data,
                    columns: [
                        { data: "Codigo" },
                        { data: "NombreCompleto" },
                        {
                            data: "FechaInicio",
                            render: function (data, type, row) {
                                return moment(data).format('YYYY/MM/DD');
                            }
                        },
                        {
                            data: "FechaFin",
                            render: function (data, type, row) {
                                if (data == null) {
                                    return "Indefinido";
                                } else {
                                    return moment(data).format('YYYY/MM/DD');
                                }
                            }
                        },
                        {
                            data: "Salario",
                            render: function (data, type, row) {
                                return parseFloat(data).toFixed(2);
                            }
                        },
                        { data: "DiasAguinaldo" },
                        {
                            data: "MontoAguinaldo",
                            render: function (data, type, row) {
                                return parseFloat(data).toFixed(2);
                            }
                        },
                        { data: "DiasVacaciones" },
                        {
                            data: "MontoVacaciones",
                            render: function (data, type, row) {
                                return parseFloat(data).toFixed(2);
                            }
                        },
                        {
                            data: "diasIndem",
                            render: function (data, type, row) {
                                return parseFloat(data).toFixed(2);
                            }
                        },
                        {
                            data: "MontoIndem",
                            render: function (data, type, row) {
                                return parseFloat(data).toFixed(2);
                            }
                        },
                        {
                            data: "TotalProvision",
                            render: function (data, type, row) {
                                return parseFloat(data).toFixed(2);
                            }
                        },
                    ],
                    responsive: true,
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
                    ordering: true,
                    buttons: [
                        {
                            extend: "excel",
                            text: "Excel",
                            titleAttr: 'Exportar datos a excel'
                        },
                    ]
                });
                delete tabla._buttons;
            },
            error: function (xhr, status, error) {
                // Aquí manejas el error, si lo hay
                console.log(error);
            }
        });
    });
});