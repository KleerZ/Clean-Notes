function contextMenuFolder() {
    console.log(3)
    let contextMenu = document.querySelectorAll('.bbb');
    let contextMenuOpen = document.querySelector('.context-menu-open-folder');
    for (let i = 0; i < contextMenu.length; i++) {
        contextMenu[i].addEventListener('contextmenu', function (e) {
            e.preventDefault();
            anime({
                targets: '.context-menu-open-folder',
                translateY: 5,
                delay: 0
            });

            document.getElementById('context-menu-open-folder').style.left = e.clientX + 'px';
            document.getElementById('context-menu-open-folder').style.top = e.clientY + 'px';
            document.getElementById('context-menu-open-folder').style.opacity = 1;
            document.getElementById('context-menu-open-folder').style.visibility = 'visible';
            document.getElementById('context-menu-open-folder').style.display = 'flex';

            let element = e.target;
            while (element.className !== 'folder-form') {
                element = element.parentNode;
            }
            let id = $(element).attr('action').split('/')[3];

            localStorage.setItem('id-folder', id);

            console.log(id);
        });
    }

    window.addEventListener('click', function () {
        anime({
            targets: '.context-menu-open-folder',
            translateY: -5,
            delay: 0
        });
        document.getElementById('context-menu-open-folder').style.opacity = 0;
        document.getElementById('context-menu-open-folder').style.visibility = 'hidden';
    });
}