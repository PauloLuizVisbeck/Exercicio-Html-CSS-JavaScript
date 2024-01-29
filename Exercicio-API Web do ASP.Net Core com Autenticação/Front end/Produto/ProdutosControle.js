const token = localStorage.getItem('chave')
function carregar() {

    document.getElementById("tableprodutos").innerHTML = ""
    fetch("https://localhost:7196/api/produtos", { headers: { 'Authorization': 'Bearer ' + token } })
        .then(dados => dados.json())
        .then(resposta => {
            resposta.forEach(item => {
                document.getElementById("tableprodutos").innerHTML +=
                    `<tr><td>${item.id}</td>
                <td>${item.descricao}</td>
                <td>${item.preco}</td>
                <td>${item.estoque}</td>                                
                <td>${item.categoria.nome}</td>
                <td><button onclick="deletar(${item.id})">Deletar</button></td>
                <td><button onclick="alt(${item.id})">Editar</button></td>
                </tr>`})
        })

}
function criar() {
    const obj = {
        descricao: document.getElementById("descricao").value,
        preco: document.getElementById("preco").value,
        estoque: document.getElementById("estoque").value,
        categoria: {
            id: document.getElementById("categoriaid").value
        }
    }
    const options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token,
        },
        body: JSON.stringify(obj),
    };
    fetch('https://localhost:7196/api/produtos', options)

        .then(() => {
            // Limpar os campos de entrada após clicar em Criar
            document.getElementById("descricao").value = "";
            document.getElementById("preco").value = "";
            document.getElementById("estoque").value = "";
            document.getElementById("categoriaid").value = "";

            //Chamada do método para carregar a página. Como está dentro do then (então), só vai ser
            //executado após realmente o novo produto ter sido criado. Se colocar fora do then, a página
            //pode ser carregada antes mesmo do produto estar criado, deixando ele de fora do carregamento.
            carregar()
        })
        //Caso dê errado, exibe a mensagem de erro
        .catch(error => console.error('Erro ao criar usuário:', error));
}


function deletar(id) {
    fetch(`https://localhost:7196/api/produtos/${id}`, {
        method: "DELETE",
        headers: {
            'Authorization': 'Bearer ' + token
        }
    })
    .then(response => {
        if (!response.ok) {
            throw new Error(`Erro ao deletar o produto: ${response.status} - ${response.statusText}`);
        }
        // Remove o produto deletado da tabela
        document.getElementById(`row-${id}`).remove();

        //Chamada do método carregar para atualizar a tabela na tela sem o produto
        carregar()
    })
    .catch(error => console.error('Erro ao deletar o produto:', error));
    //Chamada do método carregar para atualizar a tabela na tela sem o produto   
    carregar()
}


function alt(id) {
    // Limpar o conteúdo atual do div de edição
    document.getElementById("edit").innerHTML = "";

    // Buscar informações do produto pelo ID
    fetch(`https://localhost:7196/api/produtos/${id}`, { headers: { 'Authorization': 'Bearer ' + token } })
        .then(response => response.json())
        .then(produto => {
            //Ao pressioar o botão alterar de um produto é criado todos os inputs com os campos correspondentes e
            //já preencho os mesmos com as informações do produto em questão. Dessa forma o usuário não precisa
            //preencher todas das demais informações que estão corretas.
            document.getElementById("edit").innerHTML = `
    <input type="text" id="descricao" placeholder="Descrição" value="${produto.descricao}">
                <input type="number" id="preco" placeholder="Preço" value="${produto.preco}">
                <input type="number" id="estoque" placeholder="Estoque" value="${produto.estoque}">
                <input type="number" id="categoriaid" placeholder="Id da Categoria" value="${produto.categoria.id}">
    <button onclick="alterar(${id})">Alterar</button>`
        })
        .catch(error => console.error('Erro ao carregar informações do produto:', error));
}


function alterar(id) {
    const obj = {
        id: id,
        descricao: document.getElementById("descricao").value,
        preco: document.getElementById("preco").value,
        estoque: document.getElementById("estoque").value,
        categoria: {
            id: document.getElementById("categoriaid").value
        }
    }
    const options = {
        method: "Put",
        headers: {
            'content-type': 'application/json',
            'Authorization': 'Bearer ' + token
        },
        body: JSON.stringify(obj)
    }
    fetch(`https://localhost:7196/api/produtos/${id}`, options)

        .then(() => {
            // Limpar os campos de entrada após clicar em Criar
            document.getElementById("descricao").value = "";
            document.getElementById("preco").value = "";
            document.getElementById("estoque").value = "";
            document.getElementById("categoriaid").value = "";

            //Chamada do método para carregar a página. Como está dentro do then (então), só vai ser
            //executado após realmente o novo produto ter sido criado. Se colocar fora do then, a página
            //pode ser carregada antes mesmo do produto estar criado, deixando ele de fora do carregamento.
            carregar()
        })
        //Caso dê errado, exibe a mensagem de erro
        .catch(error => console.error('Erro ao criar usuário:', error));

}

