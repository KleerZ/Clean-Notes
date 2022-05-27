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

            let element = e.target;
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

$('.delete-note-btn').on('click', function(){
    var id = localStorage.getItem('id-task');
    var url = localStorage.getItem('url2');

    var input = document.querySelector('.count')
    input.value = $('.note-item').length;

    console.log("fef")

    $.ajax({
        url: '/Tasks/DeleteTask/' + id,
        type: 'POST',
        success: function (result) {
            $('#target').html(result);
            $('#edit').load("/Note/NoSelected/")
            
            // var url = window.location.href;
            //
            // var folderId = url.split('/')[5];

            // if (url.includes('Home/Index')) {
            //     $('#target').load("/Note/GetList/");
            // }



            console.log("fef")

            document.querySelector('.count').value = $('.note-item').length;
        }
    });

    // $('#target').load("/Note/GetList/");
    console.log(id);
    document.querySelector('.count').value = $('.note-item').length;
    // $('#target').load("/Note/GetList/");
});