$('#task-span').on('click', function(){
    console.log('wddddddddddddddddd')
    let modal = document.getElementById('task-bkg-modal');
    let text = document.getElementById('modal-task-text');

    modal.style.display = "flex";

    setTimeout(function(){
        modal.style.opacity = 1;
        modal.style.visibility = "visible";
    }, 1);

    hideTaskCreate()
});

function hideTaskCreate(){
    let modalWindow = document.querySelector('.task-bkg-modal')
    var text = document.getElementById('modal-task-text');

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

$('#modal-task-btn-id').on('click', function(){
    if (document.getElementById('modal-task-text').value === "") {
        alert("Введите название задачи");
        return false;
    }
    else{
        let text = document.getElementById('modal-task-text');

        $.ajax({
            url: "/Tasks/CreateTask/",
            type: 'POST',
            data: {
                taskName: text.value
            },
            success: function (result) {
                hideTaskCreate()
                $('#target').html(result)

                let modalWindow = document.querySelector('.task-bkg-modal')
                var text = document.getElementById('modal-task-text')

                modalWindow.style.opacity = "0";
                modalWindow.style.visibility = "visible";

                setTimeout(function(){
                    modalWindow.style.display = "none";
                    modalWindow.style.opacity = 0;
                    text.value = "";
                }, 200);
            }
        })
    }
});


