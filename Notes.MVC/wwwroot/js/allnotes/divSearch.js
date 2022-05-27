function search() 
{
    var input;
    var filter; 
    var ul;
    var li;
    var a;
    var b;
    var c;
    var i;
    var txtValue;
    var textValue;
    var dateValue;
    
    input = document.getElementsByClassName("input-search")[0];
    filter = input.value.toUpperCase();
    ul = document.getElementById("notes");
    li = ul.getElementsByTagName("form");
    
    for (i = 0; i < li.length; i++)
    {
        a = li[i].getElementsByClassName("title-text")[0];
        b = li[i].getElementsByClassName("text")[0];
        c = li[i].getElementsByClassName("date")[0];
        
        txtValue = a.textContent || a.innerText;
        textValue = b.textContent || b.innerText;
        dateValue = c.textContent || c.innerText;
        
        if (txtValue.toUpperCase().indexOf(filter) > -1 || 
            textValue.toUpperCase().indexOf(filter) > -1 || 
            dateValue.toUpperCase().indexOf(filter) > -1) 
        {
            li[i].style.display = "";
            li[i].style.opacity = 1;
            li[i].style.visibility = "visible";
        } 
        else
        {
            li[i].style.display = "none";
            li[i].style.opacity = 0;
            li[i].style.visibility = "hidden";
        }
    }
}   