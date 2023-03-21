
$(document).ready(function () {

    // Validación personalizada
    $.validator.addMethod('fechasValidas', function (value, element) {
        // Obtener valores de FechaInicio y FechaFin
        var fechaInicio = moment($('input[name="FechaInicio"]').val(), 'YYYY-MM-DD');
        var fechaFin = moment($('input[name="FechaFin"]').val(), 'YYYY-MM-DD');

        // Si no hay fecha de inicio o fecha de fin, permitir la validación
        if (!fechaInicio.isValid() || !fechaFin.isValid()) {
            return true;
        }

        // Validar que la fecha de fin sea mayor o igual que la fecha de inicio
        return fechaFin.isSameOrAfter(fechaInicio);
    }, 'La fecha de fin debe ser mayor o igual que la fecha de inicio.');


    $("#miFormularioE").validate({
        ignore: ".ignorar",
        rules: {
            Nombres: {
                required: true,
                maxlength: 50,
                minlength: 2
            },
            Apellidos: {
                required: true,
                maxlength: 50,
                minlength: 2
            },
            EmailPersonal: {
                required: true,
                email: true,
                remote: {
                    url: '/Empleados/ValidarCorreoConId',
                    type: 'post',
                    data: {
                        EmailPersonal: function () {
                            return $('#EmailPersonal').val();
                        },
                        id: window.location.href.split('/').pop()
                    }
                }
            },
            TelefonoPersonal: {
                required: true
            },
            Codigo: {
                required: true,
                maxlength: 6,
                remote: {
                    url: '/Empleados/ValidarCodigoEmpleadoConID',
                    type: 'post',
                    data: {
                        codigo: function () {
                            return $('#Codigo').val();
                        },
                        id: window.location.href.split('/').pop()
                    }
                }
            },
            Genero: {
                required: true
            },
            TipoSangre: {
                required: true
            },
            fotografia: {
                required: true,
            },
            FechaFin: {
                fechasValidas: true
            },
            IdArea: {
                required: true,
            },
            IdArea: {
                required: true,
            },
            IdCargo: {
                required: true,
            },
            TipoContrato: {
                required: true,
            },
            Salario: {
                required: true,
                number: true,
                min: 1,
            },
        },
        messages: {
            Nombres: {
                required: "Por favor, ingrese su nombre.",
                maxlength: "El nombre no puede tener más de {0} caracteres.",
                minlength: "El nombre no puede tener menos de 2 caracteres"
            },
            Apellidos: {
                required: "Por favor, ingrese sus apellidos.",
                maxlength: "El nombre no puede tener más de {0} caracteres.",
                minlength: "El nombre no puede tener menos de 2 caracteres"
            },
            EmailPersonal: {
                required: "Por favor, ingrese su correo electrónico.",
                remote: "El correo de empleado ya existe.",
                email: "Por favor, ingrese una dirección de correo electrónico válida.",
            },
            TelefonoPersonal: {
                required: "Por favor, ingrese su número de teléfono."
            },
            Codigo: {
                required: "Por favor, ingrese un código.",
                remote: "El código de empleado ya existe.",
                maxlength: "El codigo debe tener 6 caracteres",
            },
            CodigoNuevo: {
                required: "Por favor, ingrese un código.",
                maxlength: "El codigo debe tener 6 caracteres",
            },
            Genero: {
                required: "Por favor, seleccione su género."
            },
            TipoSangre: {
                required: "Por favor, seleccione su tipo de sangre."
            },
            fotografia: {
                required: "Por favor, seleccione una foto.",
                extension: "Por favor, seleccione un archivo de imagen válido."
            },
            FechaInicio: {
                required: 'La fecha de inicio es obligatoria',
                fechasValidas: 'La fecha de fin debe ser mayor o igual que la fecha de inicio'
            },
            FechaFin: {
                fechasValidas: 'La fecha de fin debe ser mayor o igual que la fecha de inicio'
            },
            IdArea: {
                required: "Por favor, seleccione una Area."
            },
            IdCargo: {
                required: "Por favor, seleccione su Cargo."
            },
            TipoContrato: {
                required: "Por favor, seleccione el tipo de Contrato."
            },
            Salario: {
                required: "Por favor ingrese el salario",
                number: "Por favor ingrese un valor numérico",
                min: "El salario debe ser mayor que 1"
            },
            //img: {
            //    required: "Por favor, seleccione una foto."
            //}
        },
    });
});