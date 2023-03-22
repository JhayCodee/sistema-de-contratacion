﻿$('#editbtp').click(function () {
    if ($('#miFormularioTPE').valid()) {
        Swal.fire({
            title: 'Actualizar',
            text: "Seguro que quieres actualizar esta area?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sí, actualizar!'
        }).then((result) => {
            if (result.isConfirmed) {
                $('#miFormularioTPE').submit();
            }
        });
    }
});