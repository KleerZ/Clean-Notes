

// window.onload = function(){
    myFunction();
// }

function myFunction(){
    let elemzz = document.getElementById("dropdown")
    let style = elemzz.style.visibility;

    let btn = document.getElementById('create-btn')
    if (style == 'hidden'){
        $('.create-btn').on('click', function(){
            btn.style.background = '#483dff'

            elemzz.style.visibility='visible';
            elemzz.style.opacity='1';
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
        elemzz.style.opacity='0';
        elemzz.style.visibility='hidden';
        btn.style.background = '#6c63ff'
    }

    function hide(){
        
        $('.create-btn').on('click', function(){
            if (style == 'visible'){
                let elemzz = document.querySelector('.dropdown');
                let btn = document.getElementById('create-btn')
                anime({
                    targets: '.dropdown',
                    translateY: -15,
                    duration: 700
                });

                elemzz.style.opacity='0';
                elemzz.style.visibility='hidden';
                btn.style.background = '#6c63ff'
            }
        })
        
        
        
        $(document).click('on', function(e){
            var box = $('.drop-div');

            if (!box.is(e.target) && box.has(e.target).length === 0){
                let elemzz = document.querySelector('.dropdown');
                let btn = document.getElementById('create-btn')
                anime({
                    targets: '.dropdown',
                    translateY: -15,
                    duration: 700
                });

                elemzz.style.opacity='0';
                elemzz.style.visibility='hidden';
                btn.style.background = '#6c63ff'
            }
        })
    }
}