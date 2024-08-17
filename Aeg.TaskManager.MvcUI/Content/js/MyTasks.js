$(document).ready(function () {
    loadUserTasks();
});


function loadUserTasks() {
    $.ajax({
        type: "GET",
        url: "/UserTask/GetUserTasks",
        data: null,
        success: function (data) {
            fillUserTasks(data);
        },
        error: function (data) {
            alert("Error");
        }
    });
}
function fillUserTasks(data) {
    $("#divToDo").empty();
    $.each(data, function (index, value) {
        switch (value.UserTaskStatus) {
            case 1:
                insertToDo(value);
                break;
            case 2:
                insertInProgressTask(value);
                break;
            case 3:
                insertDoneTask(value);
                break;
        }
    });
}
function insertToDo(data) {

    var html = '<div data-taskid="' + data.Id + '" id="divTask' + data.Id + '" class="task" draggable="true" ondragstart="drag(event)">' + data.TaskName +
        '<span class="delete-btn" onclick="deleteTask(' + data.Id + ')">' +
        '</span></div>';

    $("#divToDo").append(html);
}

function insertInProgressTask(data) {
    var html = '<div data-taskid="' + data.Id + '" id="divTask' + data.Id + '" class="task" draggable="true" ondragstart="drag(event)">' + data.TaskName +
        '<span class="delete-btn" onclick="deleteTask(' + data.Id + ')">' +
        '</span></div>';

    $("#divInProgress").append(html);
}
function insertDoneTask(data) {
    var html = '<div data-taskid="' + data.Id + '" id="divTask' + data.Id + '" class="task" draggable="true" ondragstart="drag(event)">' + data.TaskName +
        '<span class="delete-btn" onclick="deleteTask(' + data.Id + ')">' +
        '</span></div>';

    $("#divDone").append(html);
}
function allowDrop(ev) {
    ev.preventDefault();
}

function drag(ev) {
    ev.dataTransfer.setData("text", ev.target.id);
}

function drop(ev, id) {
    debugger;
    ev.preventDefault();
    var data = ev.dataTransfer.getData("text");
    ev.target.appendChild(document.getElementById(data));
    var id = $("#" + data).data("taskid");
    var status = ev.target.id == "todo" ? 1 : ev.target.id == "in-progress" ? 2 : 3;
    var model = {
        Id:id,
        status:status
    };
    $.ajax({
        type: "POST",
        url: "/UserTask/UpdateUserTaskStatus",
        data: model,
        success: function (data) {
        },
        error: function (data) {
        }
    });
    //UpdateUserTaskStatus(int Id, UserTaskStatus status)
}
