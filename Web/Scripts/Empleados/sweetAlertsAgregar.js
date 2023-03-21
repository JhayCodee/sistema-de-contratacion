$(document).ready(function () {

    if (message != "") {
        if (alertType == "success") {
            Swal.fire({
                icon: 'success',
                title: 'Éxito',
                text: message
            }).then(function () {
                window.location = "/Empleados/Empleados_VW";
            });
        } else if (alertType == "error") {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: message
            });
        }
    }
});
