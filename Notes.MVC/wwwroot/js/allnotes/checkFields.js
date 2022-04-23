
    $(".addform").submit(function (e) {
        if(!title.value){
            alert('Данные не сохранены, поля пустые')
            return false;
        }
        if(!text.value){
            alert('Данные не сохранены, поля пустые')
            return false;
        }
    });
