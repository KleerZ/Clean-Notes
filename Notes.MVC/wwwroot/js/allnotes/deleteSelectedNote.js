$('.delete-note-btn').on('click', function(){
    var id = localStorage.getItem('id');
    var url = localStorage.getItem('url2');

    // var input = document.querySelector('.count')
    // input.value = $('.note-item').length;
    
    console.log("fef")

    $.ajax({
        url: '/Note/ToTrash/' + id,
        type: 'POST',
        success: function () {
            // $('#target').html(result);
            $('#edit').load("/Note/NoSelected/")


            $('#target').load("/Note/GetList/");
            
            console.log("fef")
        }
    });
    
    $('#target').load("/Note/GetList/");
    console.log(id);
    $('#target').load("/Note/GetList/");
});