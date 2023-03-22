$('#btneditc').click(function () {
    if ($('#miFormularioCargoE').valid()) {
        Swal.fire({
            title: 'Actualizar',
            text: "Seguro que quieres actualizar este cargo?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sí, actualizar!'
        }).then((result) => {
            if (result.isConfirmed) {
                $('#miFormularioCargoE').submit();
            }
        });
    }
});