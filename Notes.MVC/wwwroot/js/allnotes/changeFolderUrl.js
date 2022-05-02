$(document).on('click', '#folder-form', function(){
    let url = $(this).attr('action').split('/')[3];
    
    localStorage.setItem('folderUrl', url);
    
    let formData = "/Folder/GetNotesInFolder/" + url;
    history.pushState(formData, null, formData)
})