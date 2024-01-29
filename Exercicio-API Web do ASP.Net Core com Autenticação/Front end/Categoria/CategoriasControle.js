const token = localStorage.getItem('chave')
function carregar(){
    document.getElementById("table").innerHTML = ""
    fetch("https://localhost:7196/api/categorias", 
    {
        headers : {
            'Authorization': 'Bearer ' + token
        }
    })
    .then(dados => dados.json())
    .then(resposta => resposta.forEach(item => {
        document.getElementById("table").innerHTML +=
         `<tr><td>${item.id}</td><td>${item.nome}</td>
         <td><button onclick="deletar(${item.id})">Deletar</button>
         </td><td><button onclick="alterar(${item.id})">Editar</button></td>
         <tr>`}))
    }


function criar(){
    const update = {
        nome : document.getElementById("Nome").value
        };
        
        const options = {
        method: 'POST',
        headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
        },
        body: JSON.stringify(update),
        };
        fetch('https://localhost:7196/api/categorias', options)

        .then(() => {
            // Limpar os campos de entrada após clicar em Criar
            document.getElementById("Nome").value = "";
            
            //Chamada do método para carregar a página. Como está dentro do then (então), só vai ser
            //executado após realmente o novo produto ter sido criado. Se colocar fora do then, a página
            //pode ser carregada antes mesmo do produto estar criado, deixando ele de fora do carregamento.
            carregar()
        })
        //Caso dê errado, exibe a mensagem de erro
        .catch(error => console.error('Erro ao criar usuário:', error));
    }


    function deletar(id){
        fetch(`https://localhost:7196/api/categorias/${id}`, {
        method: 'DELETE',
        headers: {
            'Authorization': 'Bearer ' + token
        }
    })
    .then(response => {
        if (!response.ok) {
            throw new Error(`Erro ao deletar a categoria: ${response.status} - ${response.statusText}`);
        }
        // Adicione esta parte para remover a linha da tabela após a deleção
        document.getElementById(`row-${id}`).remove();
    })
    .catch(error => console.error('Erro ao deletar a categoria:', error));
    carregar()
    }


    function alterar(id) {
    // Limpar o conteúdo atual do div de edição
    document.getElementById("edit").innerHTML = "";

    // Buscar informações da categoria pelo ID
    fetch(`https://localhost:7196/api/categorias/${id}`, { headers: { 'Authorization': 'Bearer ' + token } })
        .then(response => response.json())
        .then(categoria => {
            // Preencher o campo de edição com as informações da categoria
            document.getElementById("edit").innerHTML = `
                <input type="text" id="nomeCategoria" placeholder="Nome" value="${categoria.nome}">
                <button onclick="alt(${id})">Alterar</button>`;
        })
        .catch(error => console.error('Erro ao carregar informações da categoria:', error));
}


    function alt(id){
        obj = {
            id: id,
            nome: document.getElementById("nomeCategoria").value
        }
        const options = {
            method: 'PUT',
            headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
            },
            body: JSON.stringify(obj),
            };
        fetch(`https://localhost:7196/api/categorias/${id}`, options)

        .then(() => {
            // Limpar os campos de entrada após clicar em Criar
            document.getElementById("nomeCategoria").value = "";
            
            //Chamada do método para carregar a página. Como está dentro do then (então), só vai ser
            //executado após realmente o novo produto ter sido criado. Se colocar fora do then, a página
            //pode ser carregada antes mesmo do produto estar criado, deixando ele de fora do carregamento.
            carregar()
        })
        //Caso dê errado, exibe a mensagem de erro
        .catch(error => console.error('Erro ao criar usuário:', error));
    }

