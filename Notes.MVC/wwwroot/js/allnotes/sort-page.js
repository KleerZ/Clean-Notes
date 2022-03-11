$('.sort-bkg').fadeOut(0);
$('.sort-btn').click(function () {
    $('.sort-window').fadeIn(200)
    $('.notes-div').css({
        "overflow-y": "hidden",
        "position": "fixed",
        "top": "16vh"
    })
    $('.header').css({
        "z-index": "0"
    })
    $('.window').css({
        "z-index": "999999999"
    })
});

$('.w-exit-btn').click(function () {
    $('.sort-bkg').fadeOut(200)
    $('.notes-div').css({
        "overflow-y": "auto",
        "position": "",
    })
    $('.header').css({
        "z-index": "999"
    })
});