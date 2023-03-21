$(function () {
    $('input[name="daterange"]').daterangepicker({
        "startDate": "2023-03-01",
        "endDate": "2023-03-30",
        "locale": {
            "format": "YYYY-MM-DD"
        }
    }, function (start, end, label) {
        console.log("New date range selected: " + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
    });
});