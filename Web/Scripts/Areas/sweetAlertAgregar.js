$(document).ready(function () {
    if (ma != "") {
        if (alertType == "success") {
            Swal.fire({
                icon: 'success',
                title: 'Éxito',
                text: ma
            }).then(function () {
                window.location = "/Areas/Index";
            });
        } else if (alertType == "error") {
            Swal.fire({
                icon: 'error',
                title: 'Error',
                text: ma
            });
        }
    }
});