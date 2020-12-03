window.onscroll = function () { myFunction() };

let navbar = document.getElementById("navbar");
let sticky = navbar.offsetTop;

function myFunction() {
    if (window.pageYOffset >= sticky) {
        navbar.classList.add("sticky")
    } else {
        navbar.classList.remove("sticky");
    }
}

function openNav() {
    document.getElementById("overlay-nav").style.height = "100%";
}

function closeNav() {
    document.getElementById("overlay-nav").style.height = "0%";
}