$(document).ready(function () {
    $('[data-bs-toggle="tooltip"]').tooltip();
});

$(function () {
    $(".datepicker").datepicker({ dateFormat: 'yy-mm-dd' });
    $(".spinner").spinner({ min: 1, max: 50 });
    $('[data-bs-toggle="tooltip"]').tooltip();
});

$(function () {
    $(".datepicker").datepicker({
        dateFormat: "yy-mm-dd",
        minDate: 0
    }).datepicker("setDate", new Date());
});