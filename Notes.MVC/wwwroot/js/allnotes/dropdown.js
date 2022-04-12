let elem = 0;
let style = 0;

window.onload = function(){
    myFunction();
}

function myFunction(){
    elem = document.getElementById("dropdown")
    style = elem.style.visibility;

    let btn = document.getElementById('create-btn')
    if (style == 'hidden'){
        $('.create-btn').on('click', function(){
            btn.style.background = '#483dff'

            elem.style.visibility='visible';
            elem.style.opacity='1';
            anime({
                targets: '.dropdown',
                translateY: 7,
                duration: 700
            });
        })

        hide();
    }
    else{
        anime({
            targets: '.dropdown',
            translateY: -15,
            duration: 700
        });
        elem.style.opacity='0';
        elem.style.visibility='hidden';
        btn.style.background = '#6c63ff'
    }

    function hide(){
        
        $('.create-btn').on('click', function(){
            if (style == 'visible'){
                let elem = document.querySelector('.dropdown');
                let btn = document.getElementById('create-btn')
                anime({
                    targets: '.dropdown',
                    translateY: -15,
                    duration: 700
                });

                elem.style.opacity='0';
                elem.style.visibility='hidden';
                btn.style.background = '#6c63ff'
            }
        })
        
        
        
        $(document).click('on', function(e){
            var box = $('.drop-div');

            if (!box.is(e.target) && box.has(e.target).length === 0){
                let elem = document.querySelector('.dropdown');
                let btn = document.getElementById('create-btn')
                anime({
                    targets: '.dropdown',
                    translateY: -15,
                    duration: 700
                });

                elem.style.opacity='0';
                elem.style.visibility='hidden';
                btn.style.background = '#6c63ff'
            }
        })
    }
}