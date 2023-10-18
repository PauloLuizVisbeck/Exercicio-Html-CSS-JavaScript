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

select * from contato;

insert into local (nome, rua, numero) values ('Pizzaria', 'Rua Dom Geronimo', '820');
insert into local (id, nome, rua, numero) values (default, 'Natação', 'Rua Silveira Barbosa', '28');

select * from local;

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

select * from local;

/*Na proxima inserção de local, o incremento continua de forma correta a partir de onde foi setado:*/
insert into local values (default, 'Aulas de Xadres', 'Rua XV de Novembro', '2010');

insert into compromisso (id, data, hora, descricao, contato_id, local_id) values (default, '2023-11-05', '19:15:00', 'Levar presente da Bia', 2, 1);
insert into compromisso (id, data, hora, descricao, contato_id, local_id) values (default, '2023-10-19', '20:00:00', 'Levar óculos e touca', 1, 2);
/*Compromisso aceita valor nulo no campo descrição. Como o campo foi citado na lista de campos a ser inserido, precisamos*/
/*usar a constraint default no devido campo, e nesee caso o sistema irá adotar nulo como valor*/
insert into compromisso (id, data, hora, descricao, contato_id, local_id) values (default, '2023-10-19', '09:30:00', default, 3, 4);

select * from compromisso;

/*Incluindo a informmação de descrição na tabaela compromisso, cujo id = 3 estava nulo*/
update compromisso set descricao = 'pagar a mensalidade' where id = 3;

/*Fazendo select de mais de um campo da mesma tabela*/
select descricao, data, hora from compromisso;

/*Fazendo select de mais de um campo e de tabelas diferentes*/
/*Esse comando trará repetição de pessoas. Para isso podemos filtrar através do where*/
select descricao, data, hora, nome from compromisso, contato;

select * from compromisso, contato, local
where compromisso.contato_id = contato.id and compromisso.local_id = local.id;

select compromisso.id, descricao, data, hora, nome
from compromisso, contato
where compromisso.contato_id = contato.id;

/*Quando duas tabelas tem colunas com o mesmo nome e queremos buscar ambas as colunas num mesmo select, isso pode gerar um*/
/*erro dizendo que há ambiguidade. Para resolver isso podemos colocar o nomeDaTabela.NomeDaColuna conforme abaixo:*/
select data, hora, descricao, local.nome, contato.nome from compromisso, contato, local
where compromisso.contato_id = contato.id and compromisso.local_id = local.id;

/*Neste exemplo abaixo é dado um apelido para o nome da tabela compromisso  (chamando de comp apenas) e logo após utilizado esse apelido:*/
select data, hora, descricao, local.nome, contato.nome from compromisso comp, contato, local
where comp.contato_id = contato.id and comp.local_id = local.id;

/*Neste exemplo abaixo foi dado um apelido para a coluna descricao = (Descrição) e nome = (Contato). Esses apelidos servem apenas para
que apareçam no cabeçalho das colunas quando forem apresentados no select. Também foi dados um apelido para a tabela compromisso,
chamando ela apenas de comp.*/
select comp.id, descricao as Descrição, data, hora, nome as Contato
from compromisso comp
inner join contato tc on comp.contato_id = tc.id
where comp.contato_id = 2;

/*============================================================================================================================================================*/
create database agenda2
default character set utf8mb4
default collate utf8mb4_general_ci;

use agenda2;

create table contato (
id int not null auto_increment,
nome varchar(50) not null,
email varchar(30) default '',
celular varchar(20) default '',
primary key (id)
)default charset = utf8mb4;

create table compromisso_has_contato (
contato_id int not null,
compromisso_id int not null,
foreign key (contato_id) references contato (id),
foreign key (compromisso_id) references compromisso (id)
)default charset = utf8mb4;

create table compromisso (
id int not null auto_increment,
descricao varchar(100),
data date not null,
hora time not null,
primary key (id)
)default charset = utf8mb4;

insert into contato (nome, email, celular)
values ('carla', 'carlinha@gmail.com', '(047) 9 9937-7376');

update contato set nome = 'Carla' where id = 1;

insert into contato (nome, email, celular)
values 
('Sabrina', 'sabrina@gmail.com', '(047) 9 9488-7856'),
('Amanda', 'Amanda@gmail.com', '(047) 9 8875-2256');

select * from compromisso_has_contato;

insert into compromisso (descricao, data, hora)
values 
('Ir ao shopping', '2023-10-22', '20:15:00'),
('Ir ao parque', '2023-10-25', '20:15:00');

describe compromisso;







