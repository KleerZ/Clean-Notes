// window.onload = function(){
    hideWindows();
// }

function hideWindows(){
    let modalWindow = document.querySelector('.create-folder-background')
    let modal = document.querySelector('.create-folder')

    modalWindow.onclick = function(event){
        if(event.target == modalWindow){
            modalWindow.style.opacity = "0";
            modalWindow.style.visibility = "visible";

            modal.querySelector('.folder-input').value = "";

            setTimeout(function(){
                modalWindow.style.display = "none";
            }, 200);
        }
    }
}

hideWindows();

function visibleWindow(){
    let modalWindow = document.querySelector('.create-folder-background')
    let modal = document.querySelector('.create-folder')

    modalWindow.style.display = "flex";

    setTimeout(function(){
        modalWindow.style.opacity = 1;
        modalWindow.style.visibility = "visible";
    }, 1);
}