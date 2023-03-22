$(document).ready(function () {
    if (mcg != "") {
        if (alertType == "success") {
            Swal.fire({
                icon: 'success',
                title: 'Éxito',
                text: mcg
            }).then(function () {
                window.location = "/Cargos/Index";
            });
        } else if (alertType == "error") {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: mcg
            });
        }
    }
});