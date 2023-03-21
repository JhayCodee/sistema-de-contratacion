$('#btn-editar').click(function () {
    if ($('#miFormularioE').valid()) {
        Swal.fire({
            title: 'Actualizar',
            text: "Seguro que quieres actualizar este empleado?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sí, actualizar!'
        }).then((result) => {
            if (result.isConfirmed) {
                $('#miFormularioE').submit();
                }
        });
    }
});