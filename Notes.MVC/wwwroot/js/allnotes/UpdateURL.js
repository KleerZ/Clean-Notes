function UpdateURL(form){
    // var input = document.querySelector('.count')
    // input.value = $('.note-item').length;

    let formData = $(form).attr('action')


    history.pushState(formData, null, formData)
}