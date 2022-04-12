console.log($('.note-item').length)

var input = document.querySelector('.count')
input.value = $('.note-item').length;

function UpdateURL(form){
    var input = document.querySelector('.count')
    input.value = $('.note-item').length;

    let formData = $(form).attr('action')


    history.pushState(formData, null, formData)
}
//
// contextMenu();
// contextMenuFolder();

let urlEdit = "https://localhost:44339/Notes/EditPage"

localStorage.setItem('url', urlEdit);

    $('.sort-btn').on('click', function(){
    $('.sort-menu').toggleClass('show');
})
    // contextMenu();
    // contextMenuFolder();