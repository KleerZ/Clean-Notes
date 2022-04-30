$('.delete-note-trash-btn').on('click', function(){
    var id = localStorage.getItem('id');
    var url = window.location.href;

    // var input = document.querySelector('.count')
    // input.value = $('.note-item').length;

    console.log(id)


    $.ajax({
        url: '/Note/Delete/' + id,
        type: 'POST',
        success: function () {
            // $('#target').html(result);

            //перейти по ссылке
            $('#target').load("/Trash/TrashPage");
            
            
            console.log("fef")

            // document.querySelector('.count').value = $('.note-item').length;
        }
    });

    // document.querySelector('.count').value = $('.note-item').length;
    

});