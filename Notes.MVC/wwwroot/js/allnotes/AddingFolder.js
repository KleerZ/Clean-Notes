function AddingFolder(){
    let url = window.location.href;

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

    let noteId = url.split('/')[5];

    if (url.includes('/Note/EditPage/')) {
        $('#edit').load("/Note/EditPage/" + noteId, function(){
            document.querySelector('.n-title').value = editTitleNote;
            document.querySelector('.n-text').value = editTextNote;
        });
    }
    if (url.includes('/Home/Index/')) {
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
}