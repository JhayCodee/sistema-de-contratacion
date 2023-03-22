$("#miFormularioTPE").validate({

    rules: {
        NombreTipoContrato: {
            required: true,
            maxlength: 50,
            minlength: 2
        },
    },
    messages: {
        NombreTipoContrato: {
            required: "Por favor, ingrese una Nombre de contrato.",
            maxlength: "El nombre no puede tener más de {0} caracteres.",
            minlength: "El nombre no puede tener menos de 2 caracteres"
        },
    },
});