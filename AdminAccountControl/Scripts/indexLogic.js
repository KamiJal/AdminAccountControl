var selectedRow = null;


//AJAX HANDLER
function sendQueryToServerAjax(type) {
    var url;
    var title = null;

    var method = "POST";
    var alertClass = "alert-info";

    switch (type) {

        case "add":
            {
                url = "/Home/GetApplianceForm/0";
                title = "Добавить новую позицию";
            } break;

        case "edit":
            {
                url = "/Home/GetApplianceForm/" + selectedRow.attr("id");
                title = "Редактировать позицию";
            } break;

        case "delete":
            {
                url = "/Home/ConfirmDeleteAppliance/" + selectedRow.attr("id");
                title = "Вы действительно хотите удалить эту позицию?";
                alertClass = "alert-danger";
            } break;

    }

    applyAlertClassToModalHeader(alertClass);
    updateModalTitle(title);

    var success = onSuccess;

    var options = { url, success, method };
    $.ajax(options);
}



function consoleLog(xhr, statusCode, option1, option2, option3, option4, option5) {
    console.log(xhr);
    console.log(xhr.statusCode);
    console.log(statusCode);
}

function onSuccess(data) {
    updateModalBody(data);
    toggleModal();
}

function onFailure(xhr) {
    updateModalBody(xhr.responseText);
}








//MODAL WINDOW LOGIC
function toggleModal() {
    $("#modalWindow").modal("toggle");
}

function applyAlertClassToModalHeader(className) {
    $(".modal-header").removeClass("alert-info");
    $(".modal-header").removeClass("alert-danger");
    $(".modal-header").addClass(className);
}

function updateModalTitle(data) {
    $(".modal-title").text(data);
}

function updateModalBody(data) {
    $(".modal-body").html(data);
}


//BODY LOGIC
function bodyClick(event) {

    $(".jsTableRow").removeClass("active");

    if ($(event.target).parents("tr").attr("name") !== "jsTableRow") {
        buttonsDisabledOption(true);
        selectedRow = null;
        return;
    }

    selectedRow = $(event.target).parent().addClass("active");
    buttonsDisabledOption(false);
}

function buttonsDisabledOption(option) {
    $("#btnEdit").prop("disabled", option);
    $("#btnDelete").prop("disabled", option);
}