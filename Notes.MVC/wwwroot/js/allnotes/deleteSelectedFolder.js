// $('.delete-folder-btn-folder').on('click', function(){
//    
//
//     let id = localStorage.getItem('id-folder');
//
//     let url = window.location.href;
//
//     let noteId = url.split('/')[5];
//
//     // let input = document.querySelector('.count')
//     // input.value = $('.note-item').length;
//    
//
//     let titleNote = ""
//     let textNote = ""
//     let editTitleNote = ""
//     let editTextNote = ""
//
//     if(url.includes('/Note/AddPage')) {
//         titleNote = document.querySelector('.n-title').value;
//         textNote = document.querySelector('.n-text').value;
//     }
//     if (url.includes('/Note/EditPage/')) {
//         editTitleNote = document.querySelector('.n-title').value;
//         editTextNote = document.querySelector('.n-text').value;
//     }
//     if (url.includes('/Home/Index/')) {
//         editTitleNote = document.querySelector('.n-title').value;
//         editTextNote = document.querySelector('.n-text').value;
//     }
//
//    
//
//
//     $.ajax({
//         url: '/Folder/Delete/' + id,
//         type: 'POST',
//         success: function (result) {
//             $('#folder-divv').load("/Folder/GetList");
//
//             if (url.includes('/Note/EditPage')) {
//                 $('#edit').load("/Note/EditPage/" + noteId, function(){
//                     document.querySelector('.n-title').value = editTitleNote;
//                     document.querySelector('.n-text').value = editTextNote;
//                 });
//             }
//             if (url.includes('/Home/Index')) {
//                 $('#edit').load("/Note/EditPage/" + noteId, function () {
//                     document.querySelector('.n-title').value = editTitleNote;
//                     document.querySelector('.n-text').value = editTextNote;
//                 });
//             }
//             else if(url.includes('/Note/AddPage')){
//                 $('#edit').load("/Note/AddPage", function(){
//                     document.querySelector('.n-title').value = titleNote;
//                     document.querySelector('.n-text').value = textNote;
//                 });
//
//             }
//             // input.value = $('.note-item').length;
//         }
//     });
// });


$('.delete-folder-btn-folder').on('click', function (){
    var idDD = localStorage.getItem("id-folder");

    var modal = document.getElementById('modal-delete-folder-bkg');

    var hiddenId = document.getElementById('folderId').value = idDD;

    modal.style.display = "flex";

    setTimeout(function(){
        modal.style.opacity = 1;
        modal.style.visibility = "visible";
    }, 1);
})

function hideModal(){
    document.addEventListener('click', function(e) {
        if (e.target.id != 'rename-ul-id' && e.target.class != 'delete-folder-btn-folder' && e.target.class != 'modal-delete-folder' && e.target.id != 'delete-folder-span' && e.target.class != "delete-folder-btn") {
            var modalWindow = document.querySelector('.modal-delete-folder-bkg')

            modalWindow.style.opacity = "0";
            modalWindow.style.visibility = "visible";

            setTimeout(function(){
                modalWindow.style.display = "none";
            }, 200);
        }
    });
}


$('.modal-delete-folder-bkg').on('click', function(event){
    if(event.target.id == "modal-delete-folder-bkg"){
        var modalWindow = document.querySelector('.modal-delete-folder-bkg')

        modalWindow.style.opacity = "0";
        modalWindow.style.visibility = "visible";

        document.getElementById('folder-name-text').value = "";

        setTimeout(function(){
            modalWindow.style.display = "none";
        }, 200);
    }
})

$('#delete-all-in-folder').on('click', function(){
    var id = localStorage.getItem('id');
    var url = window.location.href;
    
    $.ajax({
        url: '/Folder/DeleteAll/' + id,
        type: 'POST',
        // dataType: JSON,
        // data: id,
        success: function () {
            $('#target').load("/Trash/TrashPage");
        }
    });
});