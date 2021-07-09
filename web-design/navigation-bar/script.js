var scrollPos = window.scrollY
var header = document.getElementById('header')

window.addEventListener('scroll', function(){
    if (window.scrollY > scrollPos){
        header.classList.add('headerUp')
    }
    else {
        header.classList.remove('headerUp')
    }
    scrollPos = window.scrollY
})