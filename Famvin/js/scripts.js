$(document).ready(function () {
    $('.group-header').click(function () {
        $(this).nextUntil('.group-header').toggle();
    });
});
