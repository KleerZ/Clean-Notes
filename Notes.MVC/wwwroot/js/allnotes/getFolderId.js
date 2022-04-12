$('#folder-form').on('click', function(){
    let folderId = $(this).attr('action').split('/')[3];
    console.log(folderId)
})