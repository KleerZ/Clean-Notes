window.onpopstate = function(event){
    let path = event.state;
    
    if(path !== null){
        $('#edit').load(path);
    }
    else{
        $('#target').load('@Url.Action("Index", "Home")');
    }
}