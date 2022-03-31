let login = document.getElementById('login-error');
let pass = document.getElementById('pass-error');
let conf = document.getElementById('conf-error');

window.onload = function(){
    if (document.getElementById('login-error').innerHTML === ""){
        console.log('пустой')
        login.style.display = 'none';
    }

    if (document.getElementById('pass-error').innerHTML === ""){
        console.log('пустой')
        pass.style.display = 'none';
    }

    if (document.getElementById('conf-error').innerHTML === ""){
        console.log('пустой')
        conf.style.display = 'none';
    }

    if(getComputedStyle(login).display != 'none'){
        console.log('fffff')
        anime({
            targets: '#login-error',
            translateX: 300,
            easing: 'easeInOutExpo'
        });
    }

    if(getComputedStyle(pass).display != 'none'){
        console.log('fffff')
        anime({
            targets: '#pass-error',
            translateX: 300,
            easing: 'easeInOutExpo'
        });
    }

    if(getComputedStyle(conf).display != 'none'){
        console.log('fffff')
        anime({
            targets: '#conf-error',
            translateX: 300,
            easing: 'easeInOutExpo'
        });
    }
}