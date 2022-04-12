$('.delete-folder-btn-folder').on('click', function(){

    console.log("СУКА БЛЯТЬ")

    let id = localStorage.getItem('id-folder');

    let url = window.location.href;

    let noteId = url.split('/')[5];

    // let input = document.querySelector('.count')
    // input.value = $('.note-item').length;

    console.log(noteId)

    let titleNote = ""
    let textNote = ""
    let editTitleNote = ""
    let editTextNote = ""


    if(url.includes('/Note/AddPage')) {
        titleNote = document.querySelector('.n-title').value;
        textNote = document.querySelector('.n-text').value;
    }
    if (url.includes('/Note/EditPage/')) {
        editTitleNote = document.querySelector('.n-title').value;
        editTextNote = document.querySelector('.n-text').value;
    }
    if (url.includes('/Home/Index/')) {
        editTitleNote = document.querySelector('.n-title').value;
        editTextNote = document.querySelector('.n-text').value;
    }


    $.ajax({
        url: '/Folder/Delete/' + id,
        type: 'POST',
        success: function (result) {
            $('#folder-divv').load("/Folder/GetList");

            if (url.includes('/Note/EditPage')) {
                $('#edit').load("/Note/EditPage/" + noteId, function(){
                    document.querySelector('.n-title').value = editTitleNote;
                    document.querySelector('.n-text').value = editTextNote;
                });
            }
            if (url.includes('/Home/Index')) {
                $('#edit').load("/Note/EditPage/" + noteId, function () {
                    document.querySelector('.n-title').value = editTitleNote;
                    document.querySelector('.n-text').value = editTextNote;
                });
            }
            else if(url.includes('/Note/AddPage')){
                $('#edit').load("/Note/AddPage", function(){
                    document.querySelector('.n-title').value = titleNote;
                    document.querySelector('.n-text').value = textNote;
                });

            }
            input.value = $('.note-item').length;
        }
    });
});

function HELPMEJS(){

}