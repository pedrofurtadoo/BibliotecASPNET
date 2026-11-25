const campoSenha = document.getElementById("senha");
const botaoMostrarSenha = document.getElementById("mostrar-senha");

// Alterna entre mostrar e ocultar a senha.
botaoMostrarSenha.addEventListener("click", () => {

    if (campoSenha.type === "password") {
        campoSenha.type = "text";
    } else {
        campoSenha.type = "password";
    }

});