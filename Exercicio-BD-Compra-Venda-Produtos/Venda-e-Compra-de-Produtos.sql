create database mercado
default character set utf8mb4
default collate utf8mb4_general_ci;

use mercado;

create table categoria (
id int not null auto_increment,
nome varchar(30) not null,
primary key (id)
)default charset = utf8mb4;

describe categorias;

alter table categorias
modify column nome varchar(15);

create table produtos (
id int not null auto_increment,
nome varchar(50) not null,
marca varchar(50) not null,
fornecedor varchar(50) default '', 
unid_medida varchar(50) not null,
lote varchar(50) default '',
validade date default '2100-12-31',
promocao enum ('S','N'),
comentario text,
categoria_id int,
primary key (id),
foreign key (categoria_id) references categoria (id)
) default charset utf8mb4;

drop table produtos;
/*=======================================================================================================================================*/
/* Criação do BD agenda*/
create database agenda
default character set utf8mb4
default collate utf8mb4_general_ci;

use agenda;

create table contato (
id int not null auto_increment,
nome varchar(50) not null,
email varchar(30) default '',
telefone varchar(20) default '',
primary key (id)
)default charset = utf8mb4;

create table local (
id int not null auto_increment,
nome varchar(50) not null,
rua varchar(50) not null,
numero int,
primary key (id)
)default charset = utf8mb4;

create table compromisso (
id int not null auto_increment,
data date not null,
hora time not null,
descricao varchar(100),
primary key (id),
contato_id int not null,
local_id int not null,
foreign key (contato_id) references contato (id),
foreign key (local_id) references local (id)
)default charset = utf8mb4;

select * from compromisso;
describe local;

/*Formas de inserir na tabela*/
/*Forma 01:*/
insert into contato (nome, email, telefone) values ('Kate', 'kate@gmail.com', '(047) 9 9946-7056'); 
/*Forma 02:*/
insert into contato (id, nome, email, telefone) values (default, 'Karine', 'kaka@hotmail.com', '(047) 9 8488-7529');
/*Forma 03:*/
insert into contato values (default, 'Beatriz', 'bia_86@bol.com', '(047) 9 8998-2543');

insert into local (nome, rua, numero) values ('Pizzaria', 'Rua Dom Geronimo', '820');
insert into local (id, nome, rua, numero) values (default, 'Natação', 'Rua Silveira Barbosa', '28');

/*Local cadastrado errado. Como as tabelas contém chave estrangeira, não é possível usar o comando truncate table*/
/*Além de que o comando truncate table limparia toda a tabela*/
insert into local values (default, 'Rua Margarida Silva', 'Aulas de Inglês', '733');

/*O comando delete permite apagar apenas uma parte da tabela, e mesmo que ela tenha chave estrangeira:*/
delete from local where id > 2;

/*Como o comando delete não apaga o valor que havia no id que a ser apagado, precisamos setar o id com o número correto.*/
/*Senão fizermos isso, o autoincremento irá pular o id que foi apagado. Definindo o id:*/
alter table local auto_increment = 3;

/*Agora podemos cadastrar novamente o local de forma correta:*/
insert into local values (default, 'Aulas de Inglês', 'Rua Margarida Silva', '733');

/*Na proxima inserção de local, o incremento continua de forma correta a partir de onde foi setado:*/
insert into local values (default, 'Aulas de Xadres', 'Rua XV de Novembro', '2010');

insert into compromisso (id, data, hora, descricao, contato_id, local_id) values (default, '2023-11-05', '19:15:00', 'Levar presente da Bia', 2, 1);
insert into compromisso (id, data, hora, descricao, contato_id, local_id) values (default, '2023-10-19', '20:00:00', 'Levar óculos e touca', 1, 2);
/*Compromisso aceita valor nulo no campo descrição. Como o campo foi citado na lista de campos a ser inserido, precisamos*/
/*usar a constraint default no devido campo, e nesee caso o sistema irá adotar nulo como valor*/
insert into compromisso (id, data, hora, descricao, contato_id, local_id) values (default, '2023-10-19', '09:30:00', default, 3, 4);

/*=======================================================================================================================================*/
create database loja
default character set utf8mb4
default collate utf8mb4_general_ci;

use loja;

create table produto (
id int not null auto_increment,
descricao varchar(50) not null,
preco decimal(7,2),
primary key(id)
)default charset = utf8mb4;

create table compra (
id int not null auto_increment,
`data` date not null,
hora time not null,
valor decimal(7,2),
primary key(id)
)default charset = utf8mb4;

create table fornecedor (
id int not null auto_increment,
nome varchar(50) not null,
telefone varchar(20) not null,
email varchar(20) not null,
primary key(id)
)default charset = utf8mb4;

/*Criando a chave estrangeira na tabela compra que aponta para a tabela fornecedor*/
alter table compra
add column fornecedor_id int;

alter table compra
add constraint fk_fornecedor
foreign key (fornecedor_id)
references fornecedor(id);

/*Criação da tabela auxiliar produto_has_compra que faz ligação N:N entre produto e compra*/
create table produto_has_compra (
quantidade int not null,
valor decimal(7,2) not null,
produto_id int not null,
compra_id int not null,
foreign key(produto_id) references produto(id),
foreign key(compra_id) references compra(id)
)default charset = utf8mb4;

create table venda (
id int not null auto_increment,
`data` date not null,
hora time not null,
valor decimal(7,2),
primary key(id)
)default charset = utf8mb4;

create table cliente (
id int not null auto_increment,
nome varchar(50) not null,
telefone varchar(20) not null,
primary key(id)
)default charset = utf8mb4;

create table condicao_pagamento (
id int not null auto_increment,
a_vista varchar(1) not null default 's',
prazo_1x varchar(1) not null default 'n',
prazo_2x varchar(1) not null default 'n',
prazo_3x varchar(1) not null default 'n',
prazo_4x varchar(1) not null default 'n',
prazo_5x varchar(1) not null default 'n',
prazo_10x varchar(1) not null default 'n',
prazo_12x varchar(1) not null default 'n',
primary key(id)
)default charset = utf8mb4;

/*Criando a chave estrangeira na tabela venda que aponta para a tabela cliente*/
alter table venda
add column cliente_id int;

alter table venda
add constraint fk_cliente
foreign key (cliente_id)
references cliente(id);

/*Criando a chave estrangeira na tabela venda que aponta para a tabela condicao_pagamento*/
alter table venda
add column condicao_pagamento_id int;

alter table venda
add constraint fk_condicao_pagamento
foreign key (condicao_pagamento_id)
references condicao_pagamento(id);

create table valor_receber (
id int not null auto_increment,
valor decimal(7,2) not null,
vencimento varchar(10) not null,
parcelas varchar(45) not null,
venda_id int not null,
foreign key(venda_id) references venda(id),
primary key(id)
)default charset = utf8mb4;

create table valor_pagar (
id int not null auto_increment,
valor decimal(7,2) not null,
vencimento varchar(10) not null,
parcelas varchar(45) not null,
compra_id int not null,
foreign key(compra_id) references compra(id),
primary key(id)
)default charset = utf8mb4;

/*Criação da tabela auxiliar venda_has_produto que faz ligação N:N entre venda e produto*/
create table venda_has_produto (
quantidade int not null,
valor decimal(7,2) not null,
produto_id int not null,
venda_id int not null,
foreign key(produto_id) references produto(id),
foreign key(venda_id) references venda(id)
)default charset = utf8mb4;







