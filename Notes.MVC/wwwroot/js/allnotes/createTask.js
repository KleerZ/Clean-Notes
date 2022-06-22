$('.add-task-btn').on('click', function(){
    var modal = document.getElementById('create-task-background');
    var text = document.getElementById('task-name-text');

    modal.style.display = "flex";

    setTimeout(function(){
        modal.style.opacity = 1;
        modal.style.visibility = "visible";
    }, 1);

    hideTaskCreate()
});


// function hide(){
//     document.addEventListener('click', function(e) {
//         if (e.target.class != 'add-task-btn' && e.target.id != 'create-task-id' && e.target.id != 'task-create' && e.target.id != 'task-name-text' && e.target.id != 'create-task-title') {
//             var modalWindow = document.querySelector('.create-task-background')
//             var text = document.getElementById('task-name-text');
//
//             modalWindow.style.opacity = "0";
//             modalWindow.style.visibility = "visible";
//
//             document.getElementById('task-name-text').value = "";
//
//             setTimeout(function(){
//                 modalWindow.style.display = "none";
//             }, 200);
//         }
//     });
// }

function hideTaskCreate(){
    var modalWindow = document.querySelector('.create-task-background')
    var modal = document.querySelector('#task-name-text')
    var text = document.getElementById('task-name-text');

    modalWindow.onclick = function(event){
        if(event.target == modalWindow){
            modalWindow.style.opacity = "0";
            modalWindow.style.visibility = "visible";

            setTimeout(function(){
                modalWindow.style.display = "none";
                modalWindow.style.opacity = 0;
                text.value = "";
            }, 200);
        }
    }
}


// $('#create-task-background').onclick = function(event){
//     // if(event.target == modalWindow){
//     //     var modalWindow = document.querySelector('.create-task-background')
//     //     var text = document.getElementById('task-name-text');
//     //
//     //     modalWindow.style.opacity = "0";
//     //     modalWindow.style.visibility = "visible";
//     //
//     //     document.getElementById('task-name-text').value = "";
//     //
//     //     setTimeout(function(){
//     //         modalWindow.style.display = "none";
//     //     }, 200);
//     // }
//     console.log("fghjk")
// }

$('#task-create').on('click', function(){
    if (document.getElementById('task-name-text').value === "") {
        alert("Введите название задачи");
        return false;
    }
    else{
        let text = document.getElementById('task-name-text');
        var taskid = document.getElementById('taskid-hidden').value;

        $.ajax({
            url: "/Tasks/CreateSubTask/",
            type: 'POST',
            data: {
                taskid: taskid,
                text: text.value
            },
            success: function (result) {
                console.log(result)
                $('#edit').html(result)
            }
        })
        
        // setTimeout(function(){
        //     // modalWindow.style.opacity = "0";
        //     // modalWindow.style.visibility = "visible";
        //     // modalWindow.style.display = "none";
        //    
        // }, 200);
    }
});


