function OnSuccess() {
    if (localStorage.getItem('folderurl').split('/')[5] != null) {
        $('#target').load('@Url.Action("GetNotesInFolder", "Folder")' + '/' + localStorage.getItem('folderurl').split('/')[5]);
    } else {
        $('#target').load('@Url.Action("GetList", "Note")');
    }
}


$('.checkbox').on('click', function () {
    var subtaskid = $(this).parent().parent().find('input[name="subtaskid"]').val()

    if ($(this).is(':checked')) {
        $.ajax({
            url: "/Tasks/CheckSubtask/",
            type: 'POST',
            data: {
                subtaskid: $(this).parent().parent().find('input[name="subtaskid"]').val(),
                taskid: $(this).parent().parent().find('input[name="taskid"]').val()
            },
            success: function (result) {
                console.log(result)
                $('#edit').html(result)
            }
        })
    } else {
        $.ajax({
            url: "/Tasks/CheckSubtask/",
            type: 'POST',
            data: {
                subtaskid: $(this).parent().parent().find('input[name="subtaskid"]').val(),
                taskid: $(this).parent().parent().find('input[name="taskid"]').val()
            },
            success: function (result) {
                console.log(result)
                $('#edit').html(result)
            }
        })
    }
});


$(document).ready(function () {
    $('.task').each(function () {
        if ($(this).find('input[name="ischecked"]').val() == 'True') {
            $(this).find('.checkbox').prop('checked', true)
            $(this).addClass('checkbox-checked')
        } else {
            $(this).find('.checkbox').prop('checked', false)
            $(this).removeClass('checkbox-checked')
        }
    })
});


$('.update-btn-task').on('click', function () {
    var subtaskid = $(this).parent().parent().find('input[name="subtaskid"]').val()

    $.ajax({
        url: "/Tasks/EditSubTask/",
        type: 'POST',
        data: {
            subtaskid: $(this).parent().parent().find('input[name="subtaskid"]').val(),
            taskid: $(this).parent().parent().find('input[name="taskid"]').val(),
            text: $(this).parent().parent().find('input[name="subtasktext"]').val()
        },
        success: function (result) {
            console.log(result)
            $('#edit').html(result)
        }
    })
});
