
$.validator.addMethod("maxSalarioInicial", function (value, element, params) {
    var salarioInicial = parseFloat(value);
    var salarioFinal = parseFloat($(params).val());
    return salarioInicial <= salarioFinal;
}, "El salario inicial no puede ser mayor que el salario final.");

$("#miFormularioCargoE").validate({

    rules: {
        CodigoCargo: {
            required: true,
            maxlength: 16,
            minlength: 2,
            remote: {
                url: '/Cargos/ValidarCodigoConId',
                type: 'post',
                data: {
                    codigo: function () {
                        return $('#Codigo').val();
                    },
                    id: function () {
                        return $('#id').val();
                    },
                }
            },
        },
        NombreCargo: {
            required: true,
            maxlength: 50,
            minlength: 2
        },
        RangoSalarioInicial: {
            required: true,
            number: true,
            min: 0,
            maxSalarioInicial: "#rf",
        },
        RangoSalarialFinal: {
            required: true,
            number: true,
            min: 0,
        },
    },
    messages: {
        CodigoCargo: {
            required: "Por favor, ingrese un codigo.",
            maxlength: "El codigo no puede tener más de {0} caracteres.",
            minlength: "El nombre no puede tener menos de 2 caracteres",
            remote: "El codigo de area ya existe."
        },
        NombreCargo: {
            required: "Por favor, ingrese una Nombre de CArgo.",
            maxlength: "El nombre no puede tener más de {0} caracteres.",
            minlength: "El nombre no puede tener menos de 2 caracteres"
        },
        RangoSalarioInicial: {
            required: "Por favor ingrese el salario",
            number: "Por favor ingrese un valor numérico",
            min: "El salario no debe ser menor que cero",
            maxSalarioInicial: "El salario inicial no puede ser mayor que el salario final."
        },
        RangoSalarialFinal: {
            required: "Por favor ingrese el salario",
            number: "Por favor ingrese un valor numérico",
            min: "El salario no debe ser menor que cero"
        },
    },
});