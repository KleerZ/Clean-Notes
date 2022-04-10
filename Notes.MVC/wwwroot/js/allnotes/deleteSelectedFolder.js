$('.delete-folder-btn-folder').on('click', function(){
    let id = localStorage.getItem('id-folder');
    let url = localStorage.getItem('url');

    let input = document.querySelector('.count')
    input.value = $('.note-item').length;

    console.log("folder")

    $.ajax({
        url: '/Folder/Delete/' + id,
        type: 'POST',
        success: function (result) {
            $('#folder-divv').load("/Folder/GetList");
            $('#edit').load("/Note/EditPage/");

            input.value = $('.note-item').length;
        }
    });

    console.log(id);
});