var gridStyles = getComputedStyle(document.querySelector('.grid', null));
var rowHeight = parseInt(gridStyles.getPropertyValue('--grid-row-height'));
var gap = parseInt(gridStyles.getPropertyValue('--grid-gutter'));

var makeGrid = function () {
    let items = document.querySelectorAll('.grid-item');
    for (let i = 0, item; item = items[i]; i++) {
        item.classList.remove('grid-item-ready');
        let height = item.offsetHeight;
        let rowSpan = Math.ceil((height + gap) / (rowHeight + gap));
        item.style.gridRowEnd = 'span ' + rowSpan;
        item.classList.add('grid-item-ready');
    }
}

window.onload(makeGrid());
window.onload(() => {
    clearTimeout(makeGrid().resizeTimer);
    makeGrid().resizeTimer = setTimeout(makeGrid(), 200)
})