function validFolder(){
    $('create-folder-form').submit(function(e){
        e.preventDefault();
        let input = document.querySelector('.folder-input');
        let error = document.querySelector('#error-span');

        let result = false;

        //проверка поля на размерность
        if(input.value.length > 30){
            error.value = "ппппппппп"

            result = false;

            console.log(result)
        }
    });

    return result;
}


$(document).ready(function() {
    let modalWindow = document.querySelector('.create-folder-background')
    let modal = document.querySelector('.create-folder')

    $('.create-btn-folder').click(function(e) {
        if ($('.folder-input').val() == '') {
            e.preventDefault();
            alert('Введите название папки');
        }
        else {
            modalWindow.style.opacity = "0";
            modalWindow.style.visibility = "visible";
            setTimeout(function(){
                modalWindow.style.display = "none";
                modal.querySelector('.folder-input').value = "";
            }, 200);
        }
    });
});