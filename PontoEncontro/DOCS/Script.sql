/*
Created		24/05/2011
Modified		19/06/2011
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/


Drop table [MenuRole] 
go
Drop table [Menu] 
go
Drop table [RoleMembro] 
go
Drop table [Role] 
go
Drop table [ComunidadeMembro] 
go
Drop table [Comunidade] 
go
Drop table [Anuncio] 
go
Drop table [MembroAmigo] 
go
Drop table [MembroFavorito] 
go
Drop table [Favoritos] 
go
Drop table [inretessePessoa] 
go
Drop table [Interesses] 
go
Drop table [EstadoCivil] 
go
Drop table [Olhos] 
go
Drop table [Cabelos] 
go
Drop table [Etinia] 
go
Drop table [Sexo] 
go
Drop table [Post] 
go
Drop table [Perfil] 
go
Drop table [Fotos] 
go
Drop table [EncontroMembro] 
go
Drop table [Encontro] 
go
Drop table [Amigos] 
go
Drop table [Membro] 
go
Drop table [Cidade] 
go
Drop table [Estado] 
go
Drop table [Pais] 
go
Drop table [Endereco] 
go
Drop table [Pessoa] 
go


Create table [Pessoa]
(
	[sexoId] Integer NOT NULL,
	[olhosId] Integer NOT NULL,
	[cabelosId] Integer NOT NULL,
	[etiniaId] Integer NOT NULL,
	[perfilId] Integer NOT NULL,
	[estadoCivilId] Integer NOT NULL,
	[enderecoId] Integer NOT NULL,
	[pessoaId] Integer NOT NULL,
	[pessoaName] Varchar(255) NOT NULL,
	[pessoaNascimento] Datetime NOT NULL,
	[pessoaProfissao] Varchar(255) NOT NULL,
	[pessoaEmail] Varchar(255) NOT NULL, UNIQUE ([pessoaEmail]),
	[pessoaMSN] Varchar(255) NULL, UNIQUE ([pessoaMSN]),
Primary Key ([pessoaId])
) 
go

Create table [Endereco]
(
	[enderecoId] Integer NOT NULL,
	[CEP] Varchar(20) NULL,
	[cidadeId] Integer NOT NULL,
Primary Key ([enderecoId])
) 
go

Create table [Pais]
(
	[paisId] Integer NOT NULL,
	[paisName] Varchar(255) NOT NULL, UNIQUE ([paisName]),
Primary Key ([paisId])
) 
go

Create table [Estado]
(
	[estadoId] Integer NOT NULL,
	[estadoName] Varchar(255) NOT NULL, UNIQUE ([estadoName]),
	[estadoSigla] Varchar(2) NOT NULL, UNIQUE ([estadoSigla]),
	[paisId] Integer NOT NULL,
Primary Key ([estadoId])
) 
go

Create table [Cidade]
(
	[cidadeId] Integer NOT NULL,
	[cidadeName] Varchar(255) NOT NULL, UNIQUE ([cidadeName]),
	[estadoId] Integer NOT NULL,
Primary Key ([cidadeId])
) 
go

Create table [Membro]
(
	[pessoaId] Integer NOT NULL,
	[membroId] Integer NOT NULL,
	[membroNickName] Varchar(255) NOT NULL,
	[membroUltimoLogin] Datetime NOT NULL,
	[membroSenha] Varchar(50) NOT NULL,
Primary Key ([membroId])
) 
go

Create table [Amigos]
(
	[amigoId] Integer NOT NULL,
Primary Key ([amigoId])
) 
go

Create table [Encontro]
(
	[encontroId] Integer NOT NULL,
	[enderecoId] Integer NOT NULL,
	[encontroTitulo] Varchar(50) NOT NULL,
	[encontroDescricao] Text NOT NULL,
	[encontroQuantPessoas] Integer NULL,
	[encontroData] Datetime NOT NULL,
	[encontroValor] Float NULL,
Primary Key ([encontroId])
) 
go

Create table [EncontroMembro]
(
	[membroId] Integer NOT NULL,
	[encontroId] Integer NOT NULL,
	[encontroMembroId] Integer Identity NOT NULL,
Primary Key ([membroId],[encontroId],[encontroMembroId])
) 
go

Create table [Fotos]
(
	[membroId] Integer NOT NULL,
	[fotoId] Integer NOT NULL,
	[fotoPath] Varchar(255) NOT NULL,
Primary Key ([membroId],[fotoId])
) 
go

Create table [Perfil]
(
	[perfilId] Integer NOT NULL,
	[perfilAltura] Integer NOT NULL,
	[perfilPeso] Integer NOT NULL,
	[perfilFumante] Bit NOT NULL,
	[perfilBebe] Bit NOT NULL,
	[pessoaInteresseConhecer] Text NULL,
	[pessoaFantasiasSexuais] Text NULL,
	[pessoaOutrosInteresses] Text NULL,
Primary Key ([perfilId])
) 
go

Create table [Post]
(
	[membroId] Integer NOT NULL,
	[fotoId] Integer NOT NULL,
	[postId] Integer NOT NULL,
	[postText] Text NOT NULL,
Primary Key ([postId])
) 
go

Create table [Sexo]
(
	[sexoId] Integer NOT NULL,
	[sexoName] Varchar(255) NOT NULL, UNIQUE ([sexoName]),
Primary Key ([sexoId])
) 
go

Create table [Etinia]
(
	[etiniaId] Integer NOT NULL,
	[etiniaName] Varchar(255) NOT NULL, UNIQUE ([etiniaName]),
Primary Key ([etiniaId])
) 
go

Create table [Cabelos]
(
	[cabelosId] Integer NOT NULL,
	[cabelosName] Varchar(255) NULL,
Primary Key ([cabelosId])
) 
go

Create table [Olhos]
(
	[olhosId] Integer NOT NULL,
	[olhosName] Varchar(255) NOT NULL, UNIQUE ([olhosName]),
Primary Key ([olhosId])
) 
go

Create table [EstadoCivil]
(
	[estadoCivilId] Integer NOT NULL,
	[estadoCivilName] Varchar(255) NOT NULL, UNIQUE ([estadoCivilName]),
Primary Key ([estadoCivilId])
) 
go

Create table [Interesses]
(
	[interresseId] Integer NOT NULL,
	[interresseName] Varchar(255) NOT NULL, UNIQUE ([interresseName]),
Primary Key ([interresseId])
) 
go

Create table [inretessePessoa]
(
	[pessoaId] Integer NOT NULL,
	[interresseId] Integer NOT NULL,
	[inretessePessoaId] Integer Identity NOT NULL,
Primary Key ([pessoaId],[interresseId],[inretessePessoaId])
) 
go

Create table [Favoritos]
(
	[favoritosId] Integer NOT NULL,
Primary Key ([favoritosId])
) 
go

Create table [MembroFavorito]
(
	[membroId] Integer NOT NULL,
	[favoritosId] Integer NOT NULL,
	[membroFavoritoId] Integer Identity NOT NULL,
Primary Key ([membroId],[favoritosId],[membroFavoritoId])
) 
go

Create table [MembroAmigo]
(
	[membroId] Integer NOT NULL,
	[amigoId] Integer NOT NULL,
	[membroAmigoId] Integer Identity NOT NULL,
Primary Key ([membroId],[amigoId],[membroAmigoId])
) 
go

Create table [Anuncio]
(
	[anuncioId] Integer NOT NULL,
	[anuncioValorHora] Float NOT NULL,
	[anucioProficional] Bit NOT NULL,
	[anuncioTitulo] Varchar(255) NOT NULL,
	[anuncioTexto] Text NOT NULL,
	[membroId] Integer NOT NULL,
Primary Key ([anuncioId])
) 
go

Create table [Comunidade]
(
	[comunidadeId] Integer NOT NULL,
	[comunidadeName] Varchar(255) NOT NULL,
	[comunidadeDataCreate] Datetime NOT NULL,
	[comunidadeDescricao] Text NOT NULL,
Primary Key ([comunidadeId])
) 
go

Create table [ComunidadeMembro]
(
	[comunidadeId] Integer NOT NULL,
	[membroId] Integer NOT NULL,
	[comunidadeMembroId] Integer NOT NULL,
Primary Key ([comunidadeId],[membroId],[comunidadeMembroId])
) 
go

Create table [Role]
(
	[RoleId] Integer NOT NULL,
	[RoleName] Varchar(255) NOT NULL, UNIQUE ([RoleName]),
Primary Key ([RoleId])
) 
go

Create table [RoleMembro]
(
	[RoleId] Integer NOT NULL,
	[membroId] Integer NOT NULL,
	[roleMembroId] Integer Identity NOT NULL,
Primary Key ([RoleId],[membroId],[roleMembroId])
) 
go

Create table [Menu]
(
	[MenuId] Integer NOT NULL,
	[MenuIdPai] Integer NOT NULL,
	[MenuName] Varchar(255) NOT NULL, UNIQUE ([MenuName]),
	[MenuOrdem] Integer NOT NULL,
	[MenuPath] Varchar(255) NOT NULL,
Primary Key ([MenuId])
) 
go

Create table [MenuRole]
(
	[RoleId] Integer NOT NULL,
	[MenuId] Integer NOT NULL,
	[menuRoleId] Char(1) Identity NOT NULL,
Primary Key ([RoleId],[MenuId],[menuRoleId])
) 
go


Alter table [inretessePessoa] add  foreign key([pessoaId]) references [Pessoa] ([pessoaId])  on update no action on delete no action 
go
Alter table [Membro] add  foreign key([pessoaId]) references [Pessoa] ([pessoaId])  on update no action on delete no action 
go
Alter table [Pessoa] add  foreign key([enderecoId]) references [Endereco] ([enderecoId])  on update no action on delete no action 
go
Alter table [Encontro] add  foreign key([enderecoId]) references [Endereco] ([enderecoId])  on update no action on delete no action 
go
Alter table [Estado] add  foreign key([paisId]) references [Pais] ([paisId])  on update no action on delete no action 
go
Alter table [Cidade] add  foreign key([estadoId]) references [Estado] ([estadoId])  on update no action on delete no action 
go
Alter table [Endereco] add  foreign key([cidadeId]) references [Cidade] ([cidadeId])  on update no action on delete no action 
go
Alter table [EncontroMembro] add  foreign key([membroId]) references [Membro] ([membroId])  on update no action on delete no action 
go
Alter table [Fotos] add  foreign key([membroId]) references [Membro] ([membroId])  on update no action on delete no action 
go
Alter table [MembroFavorito] add  foreign key([membroId]) references [Membro] ([membroId])  on update no action on delete no action 
go
Alter table [MembroAmigo] add  foreign key([membroId]) references [Membro] ([membroId])  on update no action on delete no action 
go
Alter table [Anuncio] add  foreign key([membroId]) references [Membro] ([membroId])  on update no action on delete no action 
go
Alter table [ComunidadeMembro] add  foreign key([membroId]) references [Membro] ([membroId])  on update no action on delete no action 
go
Alter table [RoleMembro] add  foreign key([membroId]) references [Membro] ([membroId])  on update no action on delete no action 
go
Alter table [MembroAmigo] add  foreign key([amigoId]) references [Amigos] ([amigoId])  on update no action on delete no action 
go
Alter table [EncontroMembro] add  foreign key([encontroId]) references [Encontro] ([encontroId])  on update no action on delete no action 
go
Alter table [Post] add  foreign key([membroId],[fotoId]) references [Fotos] ([membroId],[fotoId])  on update no action on delete no action 
go
Alter table [Pessoa] add  foreign key([perfilId]) references [Perfil] ([perfilId])  on update no action on delete no action 
go
Alter table [Pessoa] add  foreign key([sexoId]) references [Sexo] ([sexoId])  on update no action on delete no action 
go
Alter table [Pessoa] add  foreign key([etiniaId]) references [Etinia] ([etiniaId])  on update no action on delete no action 
go
Alter table [Pessoa] add  foreign key([cabelosId]) references [Cabelos] ([cabelosId])  on update no action on delete no action 
go
Alter table [Pessoa] add  foreign key([olhosId]) references [Olhos] ([olhosId])  on update no action on delete no action 
go
Alter table [Pessoa] add  foreign key([estadoCivilId]) references [EstadoCivil] ([estadoCivilId])  on update no action on delete no action 
go
Alter table [inretessePessoa] add  foreign key([interresseId]) references [Interesses] ([interresseId])  on update no action on delete no action 
go
Alter table [MembroFavorito] add  foreign key([favoritosId]) references [Favoritos] ([favoritosId])  on update no action on delete no action 
go
Alter table [ComunidadeMembro] add  foreign key([comunidadeId]) references [Comunidade] ([comunidadeId])  on update no action on delete no action 
go
Alter table [RoleMembro] add  foreign key([RoleId]) references [Role] ([RoleId])  on update no action on delete no action 
go
Alter table [MenuRole] add  foreign key([RoleId]) references [Role] ([RoleId])  on update no action on delete no action 
go
Alter table [MenuRole] add  foreign key([MenuId]) references [Menu] ([MenuId])  on update no action on delete no action 
go
Alter table [Menu] add  foreign key([MenuIdPai]) references [Menu] ([MenuId])  on update no action on delete no action 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


/* Roles permissions */


/* Users permissions */


