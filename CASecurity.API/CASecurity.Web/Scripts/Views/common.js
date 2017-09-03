
function ConfirmDialog(ele, msg, okBtnName) {
    debugger;
    if (okBtnName !== undefined && okBtnName.length > 0)
        $("#okBtn").text(okBtnName);

    $("#confirmMessage").text(msg);
    //var $form = $(this).closest('form');
    //e.preventDefault();

    //$("#okBtn").data("url", $(this).data("url"))

    $('#confirm').modal({
        backdrop: 'static',
        keyboard: false
    }).one('click', '#okBtn', function (e) {
        debugger;
        location.href = $(ele).data("url");
        return true;
    });
}