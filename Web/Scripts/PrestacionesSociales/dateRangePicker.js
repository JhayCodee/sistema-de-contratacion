$(function () {
    $('input[name="corte"]').daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        minYear: 2022,
        maxYear: 2023,
        startDate: moment().year(2023).endOf('year') // establece el inicio del rango como el 1 de enero de 2022
    });
});