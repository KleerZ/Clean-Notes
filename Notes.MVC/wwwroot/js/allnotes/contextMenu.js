function contextMenu() {
    let contextMenu = document.querySelectorAll('.item');
    let contextMenuOpen = document.querySelector('.context-menu-open');
    for (let i = 0; i < contextMenu.length; i++) {
        contextMenu[i].addEventListener('contextmenu', function (e) {
            e.preventDefault();
            anime({
                targets: '.context-menu-open',
                translateY: 5,
                delay: 0
            });
            contextMenuOpen.style.left = e.clientX + 'px';
            contextMenuOpen.style.top = e.clientY + 'px';
            contextMenuOpen.style.opacity = 1;
            contextMenuOpen.style.visibility = 'visible';
            contextMenuOpen.style.display = 'flex';

            let element = e.target;
            while (element.className !== 'note-item-form') {
                element = element.parentNode;
            }
            let id = $(element).attr('action').split('/')[3];
            
            localStorage.setItem('id', id);
        });
    }

    window.addEventListener('click', function () {
        anime({
            targets: '.context-menu-open',
            translateY: -5,
            delay: 0
        });
        contextMenuOpen.style.opacity = 0;
        contextMenuOpen.style.visibility = 'hidden';
    });
}