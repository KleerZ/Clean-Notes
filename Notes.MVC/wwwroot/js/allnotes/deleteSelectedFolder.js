$('.delete-folder-btn-folder').on('click', function(){
    let id = localStorage.getItem('id-folder');
    
    let url = window.location.href;
    
    let noteId = url.split('/')[5];

    let input = document.querySelector('.count')
    input.value = $('.note-item').length;

    console.log(noteId)

    $.ajax({
        url: '/Folder/Delete/' + id,
        type: 'POST',
        success: function (result) {
            $('#folder-divv').load("/Folder/GetList");
            
            if (url.includes('/Note/EditPage/')) {
                $('#edit').load("/Note/EditPage/" + noteId);
            }
            if (url.includes('/Home/Index/')) {
                $('#edit').load("/Note/EditPage/" + noteId);
            }
            else if(url.includes('/Note/AddPage')){
                $('#edit').load("/Note/AddPage");
            }

            

            input.value = $('.note-item').length;
        }
    });

    console.log(id);
});