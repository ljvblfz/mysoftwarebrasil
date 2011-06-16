/*
Created		24/05/2011
Modified		09/06/2011
Project		
Model		
Company		
Author		
Version		
Database		mySQL 5 
*/


drop table IF EXISTS ComunidadeMembro;
drop table IF EXISTS Comunidade;
drop table IF EXISTS Anuncio;
drop table IF EXISTS MembroAmigo;
drop table IF EXISTS MembroFavorito;
drop table IF EXISTS Favoritos;
drop table IF EXISTS inretessePessoa;
drop table IF EXISTS Interesses;
drop table IF EXISTS EstadoCivil;
drop table IF EXISTS Olhos;
drop table IF EXISTS Cabelos;
drop table IF EXISTS Etinia;
drop table IF EXISTS Sexo;
drop table IF EXISTS Post;
drop table IF EXISTS Perfil;
drop table IF EXISTS Fotos;
drop table IF EXISTS EncontroMembro;
drop table IF EXISTS Encontro;
drop table IF EXISTS Amigos;
drop table IF EXISTS Membro;
drop table IF EXISTS Cidade;
drop table IF EXISTS Estado;
drop table IF EXISTS Pais;
drop table IF EXISTS Endereco;
drop table IF EXISTS Pessoa;


Create table Pessoa (
	sexoId Int NOT NULL,
	olhosId Int NOT NULL,
	cabelosId Int NOT NULL,
	etiniaId Int NOT NULL,
	perfilId Int NOT NULL,
	estadoCivilId Int NOT NULL,
	enderecoId Int NOT NULL,
	pessoaId Int NOT NULL,
	pessoaName Varchar(255) NOT NULL,
	pessoaNascimento Date NOT NULL,
	pessoaProfissao Varchar(255) NOT NULL,
	pessoaEmail Varchar(255) NOT NULL,
	pessoaMSN Varchar(255),
	UNIQUE (pessoaEmail),
	UNIQUE (pessoaMSN),
 Primary Key (pessoaId)) ENGINE = InnoDB;

Create table Endereco (
	enderecoId Int NOT NULL,
	CEP Varchar(20),
	cidadeId Int NOT NULL,
 Primary Key (enderecoId)) ENGINE = InnoDB;

Create table Pais (
	paisId Int NOT NULL,
	paisName Varchar(255) NOT NULL,
	UNIQUE (paisName),
 Primary Key (paisId)) ENGINE = InnoDB;

Create table Estado (
	estadoId Int NOT NULL,
	estadoName Varchar(255) NOT NULL,
	estadoSigla Varchar(2) NOT NULL,
	paisId Int NOT NULL,
	UNIQUE (estadoName),
	UNIQUE (estadoSigla),
 Primary Key (estadoId)) ENGINE = InnoDB;

Create table Cidade (
	cidadeId Int NOT NULL,
	cidadeName Varchar(255) NOT NULL,
	estadoId Int NOT NULL,
	UNIQUE (cidadeName),
 Primary Key (cidadeId)) ENGINE = InnoDB;

Create table Membro (
	pessoaId Int NOT NULL,
	membroId Int NOT NULL,
	membroNickName Varchar(255) NOT NULL,
	membroUltimoLogin Date NOT NULL,
	membroSenha Varchar(50) NOT NULL,
 Primary Key (membroId)) ENGINE = InnoDB;

Create table Amigos (
	amigoId Int NOT NULL AUTO_INCREMENT,
 Primary Key (amigoId)) ENGINE = InnoDB;

Create table Encontro (
	encontroId Int NOT NULL,
	enderecoId Int NOT NULL,
	encontroTitulo Varchar(50) NOT NULL,
	encontroDescricao Text NOT NULL,
	encontroQuantPessoas Int,
	encontroData Date NOT NULL,
	encontroValor Float,
 Primary Key (encontroId)) ENGINE = InnoDB;

Create table EncontroMembro (
	membroId Int NOT NULL,
	encontroId Int NOT NULL,
	encontroMembroCriador Bit(1) NOT NULL,
 Primary Key (membroId,encontroId)) ENGINE = InnoDB;

Create table Fotos (
	membroId Int NOT NULL,
	fotoId Int NOT NULL,
	fotoPath Varchar(255) NOT NULL,
 Primary Key (membroId,fotoId)) ENGINE = InnoDB;

Create table Perfil (
	perfilId Int NOT NULL AUTO_INCREMENT,
	perfilAltura Int NOT NULL,
	perfilPeso Int NOT NULL,
	perfilFumante Bit(1) NOT NULL,
	perfilBebe Bit(1) NOT NULL,
	pessoaInteresseConhecer Text,
	pessoaFantasiasSexuais Text,
	pessoaOutrosInteresses Text,
 Primary Key (perfilId)) ENGINE = InnoDB;

Create table Post (
	membroId Int NOT NULL,
	fotoId Int NOT NULL,
	postId Int NOT NULL AUTO_INCREMENT,
	postText Text NOT NULL,
 Primary Key (postId)) ENGINE = InnoDB;

Create table Sexo (
	sexoId Int NOT NULL,
	sexoName Varchar(255) NOT NULL,
	UNIQUE (sexoName),
 Primary Key (sexoId)) ENGINE = InnoDB;

Create table Etinia (
	etiniaId Int NOT NULL AUTO_INCREMENT,
	etiniaName Varchar(255) NOT NULL,
	UNIQUE (etiniaName),
 Primary Key (etiniaId)) ENGINE = InnoDB;

Create table Cabelos (
	cabelosId Int NOT NULL AUTO_INCREMENT,
	cabelosName Varchar(255),
 Primary Key (cabelosId)) ENGINE = InnoDB;

Create table Olhos (
	olhosId Int NOT NULL AUTO_INCREMENT,
	olhosName Varchar(255) NOT NULL,
	UNIQUE (olhosName),
 Primary Key (olhosId)) ENGINE = InnoDB;

Create table EstadoCivil (
	estadoCivilId Int NOT NULL AUTO_INCREMENT,
	estadoCivilName Varchar(255) NOT NULL,
	UNIQUE (estadoCivilName),
 Primary Key (estadoCivilId)) ENGINE = InnoDB;

Create table Interesses (
	interresseId Int NOT NULL AUTO_INCREMENT,
	interresseName Varchar(255) NOT NULL,
	UNIQUE (interresseName),
 Primary Key (interresseId)) ENGINE = InnoDB;

Create table inretessePessoa (
	pessoaId Int NOT NULL,
	interresseId Int NOT NULL,
 Primary Key (pessoaId,interresseId)) ENGINE = InnoDB;

Create table Favoritos (
	favoritosId Int NOT NULL AUTO_INCREMENT,
 Primary Key (favoritosId)) ENGINE = InnoDB;

Create table MembroFavorito (
	membroId Int NOT NULL,
	favoritosId Int NOT NULL,
 Primary Key (membroId,favoritosId)) ENGINE = InnoDB;

Create table MembroAmigo (
	membroId Int NOT NULL,
	amigoId Int NOT NULL,
 Primary Key (membroId,amigoId)) ENGINE = InnoDB;

Create table Anuncio (
	anuncioId Int NOT NULL,
	anuncioValorHora Float NOT NULL,
	anucioProficional Bit(1) NOT NULL,
	anuncioTitulo Varchar(255) NOT NULL,
	anuncioTexto Text NOT NULL,
	membroId Int NOT NULL,
 Primary Key (anuncioId)) ENGINE = InnoDB;

Create table Comunidade (
	comunidadeId Int NOT NULL AUTO_INCREMENT,
	comunidadeName Varchar(255) NOT NULL,
	comunidadeDataCreate Date NOT NULL,
	comunidadeDescricao Text NOT NULL,
 Primary Key (comunidadeId)) ENGINE = InnoDB;

Create table ComunidadeMembro (
	comunidadeId Int NOT NULL,
	membroId Int NOT NULL,
	comunidadeMembromediador Bit(1) NOT NULL,
 Primary Key (comunidadeId,membroId)) ENGINE = InnoDB;


Alter table inretessePessoa add Foreign Key (pessoaId) references Pessoa (pessoaId) on delete  restrict on update  restrict;
Alter table Membro add Foreign Key (pessoaId) references Pessoa (pessoaId) on delete  restrict on update  restrict;
Alter table Pessoa add Foreign Key (enderecoId) references Endereco (enderecoId) on delete  restrict on update  restrict;
Alter table Encontro add Foreign Key (enderecoId) references Endereco (enderecoId) on delete  restrict on update  restrict;
Alter table Estado add Foreign Key (paisId) references Pais (paisId) on delete  restrict on update  restrict;
Alter table Cidade add Foreign Key (estadoId) references Estado (estadoId) on delete  restrict on update  restrict;
Alter table Endereco add Foreign Key (cidadeId) references Cidade (cidadeId) on delete  restrict on update  restrict;
Alter table EncontroMembro add Foreign Key (membroId) references Membro (membroId) on delete  restrict on update  restrict;
Alter table Fotos add Foreign Key (membroId) references Membro (membroId) on delete  restrict on update  restrict;
Alter table MembroFavorito add Foreign Key (membroId) references Membro (membroId) on delete  restrict on update  restrict;
Alter table MembroAmigo add Foreign Key (membroId) references Membro (membroId) on delete  restrict on update  restrict;
Alter table Anuncio add Foreign Key (membroId) references Membro (membroId) on delete  restrict on update  restrict;
Alter table ComunidadeMembro add Foreign Key (membroId) references Membro (membroId) on delete  restrict on update  restrict;
Alter table MembroAmigo add Foreign Key (amigoId) references Amigos (amigoId) on delete  restrict on update  restrict;
Alter table EncontroMembro add Foreign Key (encontroId) references Encontro (encontroId) on delete  restrict on update  restrict;
Alter table Post add Foreign Key (membroId,fotoId) references Fotos (membroId,fotoId) on delete  restrict on update  restrict;
Alter table Pessoa add Foreign Key (perfilId) references Perfil (perfilId) on delete  restrict on update  restrict;
Alter table Pessoa add Foreign Key (sexoId) references Sexo (sexoId) on delete  restrict on update  restrict;
Alter table Pessoa add Foreign Key (etiniaId) references Etinia (etiniaId) on delete  restrict on update  restrict;
Alter table Pessoa add Foreign Key (cabelosId) references Cabelos (cabelosId) on delete  restrict on update  restrict;
Alter table Pessoa add Foreign Key (olhosId) references Olhos (olhosId) on delete  restrict on update  restrict;
Alter table Pessoa add Foreign Key (estadoCivilId) references EstadoCivil (estadoCivilId) on delete  restrict on update  restrict;
Alter table inretessePessoa add Foreign Key (interresseId) references Interesses (interresseId) on delete  restrict on update  restrict;
Alter table MembroFavorito add Foreign Key (favoritosId) references Favoritos (favoritosId) on delete  restrict on update  restrict;
Alter table ComunidadeMembro add Foreign Key (comunidadeId) references Comunidade (comunidadeId) on delete  restrict on update  restrict;


/* Users permissions */


