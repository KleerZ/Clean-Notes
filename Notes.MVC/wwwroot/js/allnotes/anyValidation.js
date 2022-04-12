$(document).ready(function() {
    $('.save-btn').click(function(e) {
        if ($('.n-title').val() == '' || $('.n-text').val() == '') {
            e.preventDefault();
            alert('Заполните все поля');
        }
    });
});