function contextMenuTask() {
    var contextMenu = document.querySelectorAll('.item-task');
    var contextMenuOpen = document.querySelector('.context-menu-open'); // 
    for (let i = 0; i < contextMenu.length; i++) {
        contextMenu[i].addEventListener('contextmenu', function (e) {
            e.preventDefault();
            anime({
                targets: '.context-menu-open',
                translateY: 5,
                delay: 0
            });
            contextMenuOpen.style.left = e.clientX + 'px';
            contextMenuOpen.style.top = e.clientY + 'px';
            contextMenuOpen.style.opacity = 1;
            contextMenuOpen.style.visibility = 'visible';
            contextMenuOpen.style.display = 'flex';

            var element = e.target;
            while (element.className !== 'note-item-form') {
                element = element.parentNode;
            }
            var id = $(element).attr('action').split('/')[3];

            localStorage.setItem('id-task', id);

            console.log(id)
        });
    }

    window.addEventListener('click', function () {
        anime({
            targets: '.context-menu-open', //
            translateY: -5,
            delay: 0
        });
        contextMenuOpen.style.opacity = 0;
        contextMenuOpen.style.visibility = 'hidden';
    });
}

$('#del-task').on('click', function(){
    var task = localStorage.getItem("id-task");
    console.log(task)
    $.ajax({
        url: "/Tasks/DeleteTask/",
        type: 'POST',
        data: {
            id: task
        },
        success: function(result){
            console.log(result)
            $('#target').html(result)
        }
    })
});

$('#res-task').on('click', function(){
    var task = localStorage.getItem("id-task");
    console.log(task)
    $.ajax({
        url: "/Tasks/RestoreFromTrash/",
        type: 'POST',
        data: {
            id: task
        },
        success: function(result){
            console.log(result)
            $('#target').html(result)
        }
    })
});



$('#del-task-main').on('click', function(){
    var task = localStorage.getItem("id-task");
    console.log(task)
    $.ajax({
        url: "/Tasks/ToTrash/",
        type: 'POST',
        data: {
            id: task
        },
        success: function(result){
            console.log(result)
            $('#target').html(result)
        }
    })
});