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


//Прятать эту хуйню

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
        }, 200);
    }
});


