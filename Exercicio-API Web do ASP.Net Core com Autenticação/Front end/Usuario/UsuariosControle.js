const token = localStorage.getItem('chave')
function get(){
    document.getElementById("tresult").innerHTML = ""
    fetch("https://localhost:7196/api/Users")
    .then(dados => dados.json())
    .then(resposta => {resposta.forEach(element => {document.getElementById("tresult").innerHTML += 
    `<tr><td>${element.id}</td>
    <td>${element.username}</td>
    <td>${element.password}</td>
    <td>${element.role}</td>
    <td><button onclick="deletar(${element.id})">Deletar</button></td>
    <td><button onclick="alt(${element.id})">Editar</button></td>
    </tr>`})
        
    });}


function criar(){
    const obj = {
        username: document.getElementById("Username").value,
        password: document.getElementById("Password").value,
        role: document.getElementById("Role").value
    }
    const options = {
        method: 'POST',
        headers: {
        'Content-Type': 'application/json',
        },
        body: JSON.stringify(obj),
        };
    fetch("https://localhost:7196/api/Users", options)

    .then(() => {
        // Limpar os campos de entrada após clicar em Salvar
        document.getElementById("Username").value = "";
        document.getElementById("Password").value = "";
        document.getElementById("Role").value = "";

        // Redirecionar para a página login.html
        window.location.href = "login.html";
    })
    //Caso dê errado, exibe a mensagem de erro
    .catch(error => console.error('Erro ao criar usuário:', error));
}


function login(){
    const obj = {
        username: document.getElementById("Username").value,
        password: document.getElementById("Password").value,
    }
    const options = {
        method: 'POST',
        headers: {
        'Content-Type': 'application/json',
        },
        body: JSON.stringify(obj),
        };
    fetch("https://localhost:7196/api/Users/Login", options)
    
    .then(dados => dados.json())
    .then(resposta => {
        localStorage.setItem('chave', resposta.token);
        //Armazena o userRole para informar em que nível foi logado
        localStorage.setItem('userRole', resposta.role);
    })

     .then(() => {
        // Limpar os campos de entrada após clicar em Entrar
        document.getElementById("Username").value = "";
        document.getElementById("Password").value = "";        

        // Redirecionar para a página login.html
        window.location.href = "../Categoria/Categoria.html";
    })
    //Caso dê errado, exibe a mensagem de erro
    .catch(error => console.error('Erro ao criar usuário:', error));
}


function alt(id){
    document.getElementById("edit").innerHTML = `
    <input type="text" id="Username" placeholder="Nome de Usuario">
    <input type="text" id="Password" placeholder="Senha">
    <select name="" id="Role">
        <option value=""></option>
        <option value="Empregado">Funcionario</option>
        <option value="Gerente">Gerente</option>
        <option value="Admin">Admin</option>
    </select>
    <button onclick="alterar(${id})">Alterar</button>`
}


function alterar(id){
    const obj = {
        id: id,
        username: document.getElementById("Username").value,
        password: document.getElementById("Password").value, 
        role: document.getElementById("Role").value
        }
    const options = {
        method: "Put",
        headers: { 'content-type': 'application/json',
        'Authorization': 'Bearer ' + token
    },
        body: JSON.stringify(obj)
    }
    fetch(`https://localhost:7196/api/Users/${id}`, options)
}