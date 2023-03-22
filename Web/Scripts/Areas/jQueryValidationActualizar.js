$("#miFormularioAreaE").validate({
    rules: {
        CodigoArea: {
            required: true,
            maxlength: 16,
            minlength: 2,
            remote: {
                url: '/Areas/ValidarCodigoConId',
                type: 'post',
                data: {
                    codigo: function () {
                        return $('#Codigo').val();
                    },
                    id: function () {
                        return $('#id').val();
                    },
                }
            }
        },
        NombreArea: {
            required: true,
            maxlength: 50,
            minlength: 2
        },
    },
    messages: {
        CodigoArea: {
            required: "Por favor, ingrese un codigo.",
            maxlength: "El codigo no puede tener más de {0} caracteres.",
            minlength: "El nombre no puede tener menos de 2 caracteres",
            remote: "El codigo de area ya existe."
        },
        NombreArea: {
            required: "Por favor, ingrese una Nombre de area.",
            maxlength: "El nombre no puede tener más de {0} caracteres.",
            minlength: "El nombre no puede tener menos de 2 caracteres"
        },
    },
});