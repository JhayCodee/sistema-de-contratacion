$(document).ready(function () {
    if (mtp != "") {
        if (alertType == "success") {
            Swal.fire({
                icon: 'success',
                title: 'Éxito',
                text: mtp
            }).then(function () {
                window.location = "/TipoContrato/Index";
            });
        } else if (alertType == "error") {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: mtp
            });
        }
    }
});