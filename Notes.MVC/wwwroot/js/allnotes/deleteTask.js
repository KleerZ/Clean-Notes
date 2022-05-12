$('.delete-btn-task').on('click', function(){
    var task = $(this).parent().parent().find('input[name="taskid"]').val();
    $.ajax({
        url: "/Tasks/DeleteSubTask/",
        type: 'POST',
        data: {
            subtaskid: $(this).parent().parent().find('input[name="subtaskid"]').val(),
            taskid: $(this).parent().parent().find('input[name="taskid"]').val()
        },
        success: function(result){
            console.log(result)
            $('#edit').html(result)
        }
    })
});