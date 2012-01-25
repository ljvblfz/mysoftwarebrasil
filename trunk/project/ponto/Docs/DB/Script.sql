/*
Created		23/09/2011
Modified		20/12/2011
Project		
Model		
Company		
Author		
Version		
Database		mySQL 5 
*/


drop table IF EXISTS TipoContato;
drop table IF EXISTS Contato;
drop table IF EXISTS TipoInteresse;
drop table IF EXISTS Interesse;
drop table IF EXISTS PermissaoRole;
drop table IF EXISTS Controller;
drop table IF EXISTS Action;
drop table IF EXISTS Permissoes;
drop table IF EXISTS MenuRole;
drop table IF EXISTS Menu;
drop table IF EXISTS Role;
drop table IF EXISTS TipoAssociacao;
drop table IF EXISTS Associacao;
drop table IF EXISTS Associado;
drop table IF EXISTS Membro;
drop table IF EXISTS Pessoa;
drop table IF EXISTS Bairro;
drop table IF EXISTS Perfil;
drop table IF EXISTS Endereco;
drop table IF EXISTS Cidade;
drop table IF EXISTS Estado;
drop table IF EXISTS EstadoCivil;
drop table IF EXISTS Sexo;
drop table IF EXISTS Olho;
drop table IF EXISTS Cabelo;
drop table IF EXISTS Etinia;


Create table Etinia (
	idEtinia Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	nameEtinia Varchar(255) NOT NULL COMMENT 'Nome',
	UNIQUE (nameEtinia),
 Primary Key (idEtinia)) ENGINE = MyISAM;

Create table Cabelo (
	idCabelo Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	nameCabelo Varchar(255) COMMENT 'Nome',
 Primary Key (idCabelo)) ENGINE = MyISAM;

Create table Olho (
	idOlho Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	nameOlho Varchar(255) NOT NULL COMMENT 'Nome',
	UNIQUE (nameOlho),
 Primary Key (idOlho)) ENGINE = MyISAM;

Create table Sexo (
	idSexo Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	nameSexo Varchar(255) NOT NULL COMMENT 'Nome',
	UNIQUE (nameSexo),
 Primary Key (idSexo)) ENGINE = MyISAM;

Create table EstadoCivil (
	idEstadoCivil Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	nameEstadoCivil Varchar(255) NOT NULL COMMENT 'Nome',
	UNIQUE (nameEstadoCivil),
 Primary Key (idEstadoCivil)) ENGINE = MyISAM;

Create table Estado (
	idEstado Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	nameEstado Varchar(255) NOT NULL COMMENT 'Nome',
	SiglaEstado Varchar(2) NOT NULL COMMENT 'Sigla',
	UNIQUE (nameEstado),
	UNIQUE (SiglaEstado),
 Primary Key (idEstado)) ENGINE = MyISAM;

Create table Cidade (
	idCidade Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	nameCidade Varchar(255) NOT NULL COMMENT 'Nome',
	idEstado Int NOT NULL COMMENT 'Estado',
 Primary Key (idCidade)) ENGINE = MyISAM;

Create table Endereco (
	idEndereco Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	CEP Varchar(20) COMMENT 'CEP',
	idCidade Int NOT NULL COMMENT 'Cidade',
	idBairro Int NOT NULL COMMENT 'Bairro',
 Primary Key (idEndereco)) ENGINE = MyISAM;

Create table Perfil (
	idSexo Int NOT NULL COMMENT 'Sexo',
	idOlho Int NOT NULL COMMENT 'Olho',
	idCabelo Int NOT NULL COMMENT 'Cabelo',
	idEtinia Int NOT NULL COMMENT 'Etinia',
	idEstadoCivil Int NOT NULL COMMENT 'Estado civil',
	idEndereco Int NOT NULL COMMENT 'Endereço',
	idPerfil Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
 Primary Key (idPerfil)) ENGINE = MyISAM;

Create table Bairro (
	idBairro Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	nomeBairro Varchar(255) NOT NULL COMMENT 'Nome',
 Primary Key (idBairro)) ENGINE = MyISAM;

Create table Pessoa (
	idPessoa Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	idPerfil Int NOT NULL COMMENT 'Perfil',
	nomePessoa Varchar(255) NOT NULL COMMENT 'Nome',
	e_MailPessoa Varchar(255) NOT NULL COMMENT 'Email',
	nascimentoPessoa Datetime NOT NULL COMMENT 'Data de Nascimento',
 Primary Key (idPessoa)) ENGINE = MyISAM;

Create table Membro (
	idMembro Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	loginMembro Varchar(255) NOT NULL COMMENT 'Login',
	senhaMembro Varchar(50) NOT NULL COMMENT 'Senha',
	idPessoa Int NOT NULL COMMENT 'Pessoa',
	idRole Int NOT NULL COMMENT 'Role',
 Primary Key (idMembro)) ENGINE = MyISAM;

Create table Associado (
	idAssociado Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	idMembro Int NOT NULL COMMENT 'Membro',
	idAssociacao Int NOT NULL COMMENT 'Associado',
 Primary Key (idAssociado)) ENGINE = MyISAM;

Create table Associacao (
	idAssociacao Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	idTipoAssociacao Int NOT NULL COMMENT 'Tipo de associação',
	idMembro Int NOT NULL COMMENT 'Membro',
	idPessoa Int NOT NULL COMMENT 'Pessoa',
 Primary Key (idAssociacao)) ENGINE = MyISAM;

Create table TipoAssociacao (
	idTipoAssociacao Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	nomeTipoAssociacao Varchar(255) NOT NULL COMMENT 'Nome',
 Primary Key (idTipoAssociacao)) ENGINE = MyISAM;

Create table Role (
	idRole Int NOT NULL COMMENT 'Código',
	nameRole Varchar(255) NOT NULL COMMENT 'Nome',
	UNIQUE (nameRole),
 Primary Key (idRole)) ENGINE = MyISAM;

Create table Menu (
	idMenu Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	MenuIdPai Int NOT NULL COMMENT 'Menu pai',
	nameMenu Varchar(255) NOT NULL COMMENT 'Nome',
	ordemMenu Int NOT NULL COMMENT 'Ordem',
	pathMenu Varchar(255) NOT NULL COMMENT 'URL',
	UNIQUE (nameMenu),
 Primary Key (idMenu)) ENGINE = MyISAM;

Create table MenuRole (
	idRole Int NOT NULL COMMENT 'Role',
	idMenu Int NOT NULL COMMENT 'Menu',
	menuRoleId Char(1) NOT NULL COMMENT 'Código',
 Primary Key (idRole,idMenu,menuRoleId)) ENGINE = MyISAM;

Create table Permissoes (
	idPermissao Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	namePermissao Varchar(255) COMMENT 'Nome',
	idAction Int NOT NULL COMMENT 'Action',
	idController Int NOT NULL COMMENT 'Controller',
 Primary Key (idPermissao)) ENGINE = MyISAM;

Create table Action (
	idAction Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	nameAction Varchar(255) COMMENT 'Nome',
 Primary Key (idAction)) ENGINE = MyISAM;

Create table Controller (
	idController Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	nameController Varchar(255) COMMENT 'Nome',
 Primary Key (idController)) ENGINE = MyISAM;

Create table PermissaoRole (
	idRole Int NOT NULL COMMENT 'Role',
	idPermissao Int NOT NULL COMMENT 'Permissão',
 Primary Key (idRole,idPermissao)) ENGINE = MyISAM;

Create table Interesse (
	idInteresse Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	Descricao Varchar(255) NOT NULL COMMENT 'Descrição',
	idTipoInteresse Int NOT NULL COMMENT 'Tipo interesse',
	idPerfil Int NOT NULL COMMENT 'Perfil',
 Primary Key (idInteresse)) ENGINE = MyISAM;

Create table TipoInteresse (
	idTipoInteresse Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	nameTipoInteresse Varchar(255) NOT NULL COMMENT 'Nome',
	UNIQUE (nameTipoInteresse),
 Primary Key (idTipoInteresse)) ENGINE = MyISAM;

Create table Contato (
	idContato Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	valorContato Varchar(255) NOT NULL COMMENT 'Valor',
	idPerfil Int NOT NULL COMMENT 'Perfil',
	idTipoContato Int NOT NULL COMMENT 'Tipo de Contato',
	UNIQUE (valorContato),
 Primary Key (idContato)) ENGINE = MyISAM;

Create table TipoContato (
	idTipoContato Int NOT NULL AUTO_INCREMENT COMMENT 'Código',
	nameTipoContato Varchar(255) NOT NULL COMMENT 'Nome',
	UNIQUE (nameTipoContato),
 Primary Key (idTipoContato)) ENGINE = MyISAM;


Alter table Perfil add Foreign Key (idEtinia) references Etinia (idEtinia) on delete  restrict on update  restrict;
Alter table Perfil add Foreign Key (idCabelo) references Cabelo (idCabelo) on delete  restrict on update  restrict;
Alter table Perfil add Foreign Key (idOlho) references Olho (idOlho) on delete  restrict on update  restrict;
Alter table Perfil add Foreign Key (idSexo) references Sexo (idSexo) on delete  restrict on update  restrict;
Alter table Perfil add Foreign Key (idEstadoCivil) references EstadoCivil (idEstadoCivil) on delete  restrict on update  restrict;
Alter table Cidade add Foreign Key (idEstado) references Estado (idEstado) on delete  restrict on update  restrict;
Alter table Endereco add Foreign Key (idCidade) references Cidade (idCidade) on delete  restrict on update  restrict;
Alter table Perfil add Foreign Key (idEndereco) references Endereco (idEndereco) on delete  restrict on update  restrict;
Alter table Pessoa add Foreign Key (idPerfil) references Perfil (idPerfil) on delete  restrict on update  restrict;
Alter table Contato add Foreign Key (idPerfil) references Perfil (idPerfil) on delete  restrict on update  restrict;
Alter table Interesse add Foreign Key (idPerfil) references Perfil (idPerfil) on delete  restrict on update  restrict;
Alter table Endereco add Foreign Key (idBairro) references Bairro (idBairro) on delete  restrict on update  restrict;
Alter table Membro add Foreign Key (idPessoa) references Pessoa (idPessoa) on delete  restrict on update  restrict;
Alter table Associacao add Foreign Key (idPessoa) references Pessoa (idPessoa) on delete  restrict on update  restrict;
Alter table Associado add Foreign Key (idMembro) references Membro (idMembro) on delete  restrict on update  restrict;
Alter table Associacao add Foreign Key (idMembro) references Membro (idMembro) on delete  restrict on update  restrict;
Alter table Associado add Foreign Key (idAssociacao) references Associacao (idAssociacao) on delete  restrict on update  restrict;
Alter table Associacao add Foreign Key (idTipoAssociacao) references TipoAssociacao (idTipoAssociacao) on delete  restrict on update  restrict;
Alter table MenuRole add Foreign Key (idRole) references Role (idRole) on delete  restrict on update  restrict;
Alter table PermissaoRole add Foreign Key (idRole) references Role (idRole) on delete  restrict on update  restrict;
Alter table Membro add Foreign Key (idRole) references Role (idRole) on delete  restrict on update  restrict;
Alter table MenuRole add Foreign Key (idMenu) references Menu (idMenu) on delete  restrict on update  restrict;
Alter table Menu add Foreign Key (MenuIdPai) references Menu (idMenu) on delete  restrict on update  restrict;
Alter table PermissaoRole add Foreign Key (idPermissao) references Permissoes (idPermissao) on delete  restrict on update  restrict;
Alter table Permissoes add Foreign Key (idAction) references Action (idAction) on delete  restrict on update  restrict;
Alter table Permissoes add Foreign Key (idController) references Controller (idController) on delete  restrict on update  restrict;
Alter table Interesse add Foreign Key (idTipoInteresse) references TipoInteresse (idTipoInteresse) on delete  restrict on update  restrict;
Alter table Contato add Foreign Key (idTipoContato) references TipoContato (idTipoContato) on delete  restrict on update  restrict;


/* Users permissions */


