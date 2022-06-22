$('#task-span').on('click', function(){
    var modal = document.getElementById('task-bkg-modal');
    var text = document.getElementById('modal-task-text');

    modal.style.display = "flex";

    setTimeout(function(){
        modal.style.opacity = 1;
        modal.style.visibility = "visible";
    }, 1);
});

$('#task-bkg-modal').on('click', function(event){
    if(event.target == this){
        var modalWindow = document.querySelector('#task-bkg-modal')
        var text = document.getElementById('modal-task-text');

        modalWindow.style.opacity = "0";    
        modalWindow.style.visibility = "visible";

        setTimeout(function(){
            modalWindow.style.display = "none";
            modalWindow.style.opacity = 0;
            text.value = "";
        }, 200);
    }
})

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
                var modalWindow = document.querySelector('.task-bkg-modal')
                var text = document.getElementById('modal-task-text')

                modalWindow.style.opacity = "0";
                modalWindow.style.visibility = "visible";

                setTimeout(function(){
                    modalWindow.style.display = "none";
                    modalWindow.style.opacity = 0;
                    text.value = "";
                }, 200);
                
                $('#target').html(result)
            }
        })
    }
});


