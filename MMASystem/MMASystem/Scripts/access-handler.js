var cargo = document.querySelector(".cargo");

var principalDiv = document.querySelector(".dl-horizontal");

var button = document.createElement("input");
button.setAttribute("type", "submit");
button.setAttribute("value", "Consulta");

var form = document.createElement("form");
form.appendChild(button)

if (cargo.textContent != null) {
    if (cargo.textContent.trim() === "Ministro") {
        form.setAttribute("action", "/Consult/Advanced");
        principalDiv.append(form);
    }
    else if (cargo.textContent.trim() === "Diretor") {
        form.setAttribute("action", "/Consult/Basic");
        principalDiv.append(form);
    }
}