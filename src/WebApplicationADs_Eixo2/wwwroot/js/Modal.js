var Modal = document.querySelector("#modal");
var fade = document.querySelector("#fundo");
var openButton = document.querySelector("#openModal");
var closeButton = document.querySelector("#closeModal");

function hideToggle() {
    [Modal, fade].forEach(e => e.classList.toggle("hide"))
}

[fade, openButton, closeButton].forEach(e => {
    e.addEventListener("click", (event) => hideToggle())
});