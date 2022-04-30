$('.delete-note-btn').on('click', function(){
    var id = localStorage.getItem('id');
    var url = localStorage.getItem('url2');

    var input = document.querySelector('.count')
    input.value = $('.note-item').length;
    
    console.log("fef")

    $.ajax({
        url: '/Note/ToTrash/' + id,
        type: 'POST',
        success: function () {
            // $('#target').html(result);
            
            //перейти по ссылке
            $('#target').load("/Note/GetList/");
            console.log("fef")

            document.querySelector('.count').value = $('.note-item').length;
        }
    });
    
    // $('#target').load("/Note/GetList/");
    console.log(id);
    document.querySelector('.count').value = $('.note-item').length;
    $('#target').load("/Note/GetList/");
});