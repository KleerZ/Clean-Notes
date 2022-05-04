$('.rename-folder').on('click', function(){
    let idDD = localStorage.getItem("id-folder");

    let modal = document.getElementById('rename-folder-background');
    let text = document.getElementById('folder-name-text');

    let hiddenId = document.getElementById('folderId').value = idDD;

    modal.style.display = "flex";

    setTimeout(function(){
        modal.style.opacity = 1;
        modal.style.visibility = "visible";
        hide()
    }, 1);
});


function hide(){
    document.addEventListener('click', function(e) {
        if (e.target.id != 'rename-window-id' && e.target.id != 'rename-btn-id' && e.target.class != "rename-folder" && e.target.id != 'rename-ul-id' && e.target.id != 'rename-folder-id' && e.target.id != 'folder-name-text' && e.target.id != 'folder-window-title') {
            var modalWindow = document.querySelector('.rename-folder-background')
            var text = document.getElementById('folder-name-text');

            modalWindow.style.opacity = "0";
            modalWindow.style.visibility = "visible";

            document.getElementById('folder-name-text').value = "";

            setTimeout(function(){
                modalWindow.style.display = "none";
            }, 200);
        }
    });
}


$('.rename-folder-background').onclick = function(event){
    if(event.target == modalWindow){
        var modalWindow = document.querySelector('.rename-folder-background')
        var text = document.getElementById('folder-name-text');
        
        modalWindow.style.opacity = "0";
        modalWindow.style.visibility = "visible";

        document.getElementById('folder-name-text').value = "";

        setTimeout(function(){
            modalWindow.style.display = "none";
        }, 200);
    }
}

$('.rename-folder-btn').on('click', function(){
    var url = window.location.href;
    
    var titleNote = ""
    var textNote = ""
    var editTitleNote = ""
    var editTextNote = ""

    var noteId = url.split('/')[5];
    
    
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
    
    var text = document.getElementById('folder-name-text');
    
    if (text.value == ""){
        alert("Введите название папки");
        return false;
    }
    else{
        let modalWindow = document.querySelector('.rename-folder-background')
        let text = document.getElementById('folder-name-text');
        
        modalWindow.style.opacity = "0";
        modalWindow.style.visibility = "visible";

        setTimeout(function(){
            modalWindow.style.display = "none";
            text.value = "";

            if (url.includes('/Note/EditPage/')) {
                $('#edit').load("/Note/EditPage/" + noteId, function(){
                    document.querySelector('.n-title').value = editTitleNote;
                    document.querySelector('.n-text').value = editTextNote;
                });
            }
            if (url.includes('Home/Index')) {
                location.reload()
            }
            else if(url.includes('/Note/AddPage')){
                $('#edit').load("/Note/AddPage", function(){
                    document.querySelector('.n-title').value = titleNote;
                    document.querySelector('.n-text').value = textNote;
                });
            }
        }, 200);
    }
});


