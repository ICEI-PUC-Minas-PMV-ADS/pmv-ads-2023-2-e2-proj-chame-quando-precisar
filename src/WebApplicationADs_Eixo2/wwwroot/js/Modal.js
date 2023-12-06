var Modal = document.querySelector("#modal");
var ModalAc = document.querySelector("#modalAceitar");
var ModalCancele = document.querySelector("#modalCancele");
var fade = document.querySelector("#fade");
var openButton = document.querySelectorAll("#openModal");
var closeButton = document.querySelectorAll("#closeModal");

function hideToggle(qualModal) {
    console.log(qualModal)
    if (qualModal == "Aceitar") {
        [ModalAc, fade, closeButton].forEach(e => e.classList.toggle("hide"))
    }
    else if (qualModal == "Cancelar") {
        [Modal, fade].forEach(e => e.classList.toggle("hide"))
    }
    else if (qualModal == "Cancele") {
        Modal.classList.add("hide");
        ModalCancele.classList.toggle("hide");
    }
    else if (qualModal == "closeModal") {
        [Modal, ModalAc, ModalCancele, fade].forEach(e => e.classList.add("hide"));
    }
}

openButton.forEach(e => {
    e.addEventListener("click", (event) => {        
        hideToggle(event.target.innerText)                    
    })
    
});

closeButton.forEach(e => {
    e.addEventListener("click", (event) => {
        console.log(event.target.id)
        hideToggle("closeModal")
    })
});