$('.rename-folder').on('click', function(){
    let idDD = localStorage.getItem("id-folder");

    let modal = document.getElementById('rename-folder-background');
    let text = document.getElementById('folder-name-text');

    let hiddenId = document.getElementById('folderId').value = idDD;

    modal.style.display = "flex";

    setTimeout(function(){
        modal.style.opacity = 1;
        modal.style.visibility = "visible";
    }, 1);
});


//Прятать эту хуйню
let modalWindow = document.querySelector('.rename-folder-background')
let text = document.getElementById('folder-name-text');

modalWindow.onclick = function(event){
    if(event.target == modalWindow){
        modalWindow.style.opacity = "0";
        modalWindow.style.visibility = "visible";

        text.value = "";

        setTimeout(function(){
            modalWindow.style.display = "none";
        }, 200);
    }
}

let renameBtn = document.querySelector('.rename-folder-btn');

$(renameBtn).on('click', function(){
    if (text.value == ""){
        alert("Введите название папки");
        return false;
    }
    else{
        modalWindow.style.opacity = "0";
        modalWindow.style.visibility = "visible";

        setTimeout(function(){
            modalWindow.style.display = "none";
            text.value = "";
        }, 200);
    }
});