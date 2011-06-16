# MySQL-Front 4.2  (Build 2.7)

/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE */;
/*!40101 SET SQL_MODE='' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES */;
/*!40103 SET SQL_NOTES='ON' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS */;
/*!40014 SET FOREIGN_KEY_CHECKS=0 */;


# Host: localhost:7188    Database: sistema
# ------------------------------------------------------
# Server version 5.0.41-community-nt

DROP DATABASE IF EXISTS `sistema`;
CREATE DATABASE `sistema` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `sistema`;

#
# Table structure for table acesso
#

CREATE TABLE `acesso` (
  `cod_acesso` int(11) NOT NULL auto_increment,
  `id_role` varchar(255) default NULL,
  `id_resource` varchar(255) default NULL,
  `desc_privilegio` varchar(255) default NULL,
  `permissao` bigint(20) default NULL,
  `flg_c` varchar(1) default NULL,
  `flg_i` varchar(1) default NULL,
  `flg_e` varchar(1) default NULL,
  `flg_a` varchar(1) default NULL,
  PRIMARY KEY  (`cod_acesso`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

#
# Dumping data for table acesso
#
LOCK TABLES `acesso` WRITE;
/*!40000 ALTER TABLE `acesso` DISABLE KEYS */;

INSERT INTO `acesso` VALUES (1,'1','1',NULL,1,'1','1','1','1');
/*!40000 ALTER TABLE `acesso` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table acesso_menu
#

CREATE TABLE `acesso_menu` (
  `cod_acesso` int(11) NOT NULL auto_increment,
  `id_role` varchar(255) default NULL,
  `id_resource` varchar(255) default NULL,
  `id_menu` bigint(20) default NULL,
  `permissao` bigint(20) default NULL,
  PRIMARY KEY  (`cod_acesso`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

#
# Dumping data for table acesso_menu
#
LOCK TABLES `acesso_menu` WRITE;
/*!40000 ALTER TABLE `acesso_menu` DISABLE KEYS */;

INSERT INTO `acesso_menu` VALUES (1,'1','1',1,NULL);
INSERT INTO `acesso_menu` VALUES (2,'1','1',1,1);
/*!40000 ALTER TABLE `acesso_menu` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table amigos
#

CREATE TABLE `amigos` (
  `amigoId` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`amigoId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table amigos
#
LOCK TABLES `amigos` WRITE;
/*!40000 ALTER TABLE `amigos` DISABLE KEYS */;

/*!40000 ALTER TABLE `amigos` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table anuncio
#

CREATE TABLE `anuncio` (
  `anuncioId` int(11) NOT NULL,
  `anuncioValorHora` float NOT NULL,
  `anucioProficional` bit(1) NOT NULL,
  `anuncioTitulo` varchar(255) NOT NULL,
  `anuncioTexto` text NOT NULL,
  `membroId` int(11) NOT NULL,
  PRIMARY KEY  (`anuncioId`),
  KEY `membroId` (`membroId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table anuncio
#
LOCK TABLES `anuncio` WRITE;
/*!40000 ALTER TABLE `anuncio` DISABLE KEYS */;

/*!40000 ALTER TABLE `anuncio` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table cabelos
#

CREATE TABLE `cabelos` (
  `cabelosId` int(11) NOT NULL auto_increment,
  `cabelosName` varchar(255) default NULL,
  PRIMARY KEY  (`cabelosId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table cabelos
#
LOCK TABLES `cabelos` WRITE;
/*!40000 ALTER TABLE `cabelos` DISABLE KEYS */;

/*!40000 ALTER TABLE `cabelos` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table cidade
#

CREATE TABLE `cidade` (
  `cidadeId` int(11) NOT NULL,
  `cidadeName` varchar(255) NOT NULL,
  `estadoId` int(11) NOT NULL,
  PRIMARY KEY  (`cidadeId`),
  UNIQUE KEY `cidadeName` (`cidadeName`),
  KEY `estadoId` (`estadoId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table cidade
#
LOCK TABLES `cidade` WRITE;
/*!40000 ALTER TABLE `cidade` DISABLE KEYS */;

/*!40000 ALTER TABLE `cidade` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table comunidade
#

CREATE TABLE `comunidade` (
  `comunidadeId` int(11) NOT NULL auto_increment,
  `comunidadeName` varchar(255) NOT NULL,
  `comunidadeDataCreate` date NOT NULL,
  `comunidadeDescricao` text NOT NULL,
  PRIMARY KEY  (`comunidadeId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table comunidade
#
LOCK TABLES `comunidade` WRITE;
/*!40000 ALTER TABLE `comunidade` DISABLE KEYS */;

/*!40000 ALTER TABLE `comunidade` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table comunidademembro
#

CREATE TABLE `comunidademembro` (
  `comunidadeId` int(11) NOT NULL,
  `membroId` int(11) NOT NULL,
  `comunidadeMembromediador` bit(1) NOT NULL,
  PRIMARY KEY  (`comunidadeId`,`membroId`),
  KEY `membroId` (`membroId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table comunidademembro
#
LOCK TABLES `comunidademembro` WRITE;
/*!40000 ALTER TABLE `comunidademembro` DISABLE KEYS */;

/*!40000 ALTER TABLE `comunidademembro` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table encontro
#

CREATE TABLE `encontro` (
  `encontroId` int(11) NOT NULL,
  `enderecoId` int(11) NOT NULL,
  `encontroTitulo` varchar(50) NOT NULL,
  `encontroDescricao` text NOT NULL,
  `encontroQuantPessoas` int(11) default NULL,
  `encontroData` date NOT NULL,
  `encontroValor` float default NULL,
  PRIMARY KEY  (`encontroId`),
  KEY `enderecoId` (`enderecoId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table encontro
#
LOCK TABLES `encontro` WRITE;
/*!40000 ALTER TABLE `encontro` DISABLE KEYS */;

/*!40000 ALTER TABLE `encontro` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table encontromembro
#

CREATE TABLE `encontromembro` (
  `membroId` int(11) NOT NULL,
  `encontroId` int(11) NOT NULL,
  `encontroMembroCriador` bit(1) NOT NULL,
  PRIMARY KEY  (`membroId`,`encontroId`),
  KEY `encontroId` (`encontroId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table encontromembro
#
LOCK TABLES `encontromembro` WRITE;
/*!40000 ALTER TABLE `encontromembro` DISABLE KEYS */;

/*!40000 ALTER TABLE `encontromembro` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table endereco
#

CREATE TABLE `endereco` (
  `enderecoId` int(11) NOT NULL,
  `CEP` varchar(20) default NULL,
  `cidadeId` int(11) NOT NULL,
  PRIMARY KEY  (`enderecoId`),
  KEY `cidadeId` (`cidadeId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table endereco
#
LOCK TABLES `endereco` WRITE;
/*!40000 ALTER TABLE `endereco` DISABLE KEYS */;

/*!40000 ALTER TABLE `endereco` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table estado
#

CREATE TABLE `estado` (
  `estadoId` int(11) NOT NULL,
  `estadoName` varchar(255) NOT NULL,
  `estadoSigla` varchar(2) NOT NULL,
  `paisId` int(11) NOT NULL,
  PRIMARY KEY  (`estadoId`),
  UNIQUE KEY `estadoName` (`estadoName`),
  UNIQUE KEY `estadoSigla` (`estadoSigla`),
  KEY `paisId` (`paisId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table estado
#
LOCK TABLES `estado` WRITE;
/*!40000 ALTER TABLE `estado` DISABLE KEYS */;

/*!40000 ALTER TABLE `estado` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table estadocivil
#

CREATE TABLE `estadocivil` (
  `estadoCivilId` int(11) NOT NULL auto_increment,
  `estadoCivilName` varchar(255) NOT NULL,
  PRIMARY KEY  (`estadoCivilId`),
  UNIQUE KEY `estadoCivilName` (`estadoCivilName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table estadocivil
#
LOCK TABLES `estadocivil` WRITE;
/*!40000 ALTER TABLE `estadocivil` DISABLE KEYS */;

/*!40000 ALTER TABLE `estadocivil` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table etinia
#

CREATE TABLE `etinia` (
  `etiniaId` int(11) NOT NULL auto_increment,
  `etiniaName` varchar(255) NOT NULL,
  PRIMARY KEY  (`etiniaId`),
  UNIQUE KEY `etiniaName` (`etiniaName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table etinia
#
LOCK TABLES `etinia` WRITE;
/*!40000 ALTER TABLE `etinia` DISABLE KEYS */;

/*!40000 ALTER TABLE `etinia` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table favoritos
#

CREATE TABLE `favoritos` (
  `favoritosId` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`favoritosId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table favoritos
#
LOCK TABLES `favoritos` WRITE;
/*!40000 ALTER TABLE `favoritos` DISABLE KEYS */;

/*!40000 ALTER TABLE `favoritos` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table fotos
#

CREATE TABLE `fotos` (
  `membroId` int(11) NOT NULL,
  `fotoId` int(11) NOT NULL,
  `fotoPath` varchar(255) NOT NULL,
  PRIMARY KEY  (`membroId`,`fotoId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table fotos
#
LOCK TABLES `fotos` WRITE;
/*!40000 ALTER TABLE `fotos` DISABLE KEYS */;

/*!40000 ALTER TABLE `fotos` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table inretessepessoa
#

CREATE TABLE `inretessepessoa` (
  `pessoaId` int(11) NOT NULL,
  `interresseId` int(11) NOT NULL,
  PRIMARY KEY  (`pessoaId`,`interresseId`),
  KEY `interresseId` (`interresseId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table inretessepessoa
#
LOCK TABLES `inretessepessoa` WRITE;
/*!40000 ALTER TABLE `inretessepessoa` DISABLE KEYS */;

/*!40000 ALTER TABLE `inretessepessoa` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table interesses
#

CREATE TABLE `interesses` (
  `interresseId` int(11) NOT NULL auto_increment,
  `interresseName` varchar(255) NOT NULL,
  PRIMARY KEY  (`interresseId`),
  UNIQUE KEY `interresseName` (`interresseName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table interesses
#
LOCK TABLES `interesses` WRITE;
/*!40000 ALTER TABLE `interesses` DISABLE KEYS */;

/*!40000 ALTER TABLE `interesses` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table membro
#

CREATE TABLE `membro` (
  `pessoaId` int(11) NOT NULL,
  `membroId` int(11) NOT NULL,
  `membroNickName` varchar(255) NOT NULL,
  `membroUltimoLogin` date NOT NULL,
  `membroSenha` varchar(50) NOT NULL,
  PRIMARY KEY  (`membroId`),
  KEY `pessoaId` (`pessoaId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table membro
#
LOCK TABLES `membro` WRITE;
/*!40000 ALTER TABLE `membro` DISABLE KEYS */;

/*!40000 ALTER TABLE `membro` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table membroamigo
#

CREATE TABLE `membroamigo` (
  `membroId` int(11) NOT NULL,
  `amigoId` int(11) NOT NULL,
  PRIMARY KEY  (`membroId`,`amigoId`),
  KEY `amigoId` (`amigoId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table membroamigo
#
LOCK TABLES `membroamigo` WRITE;
/*!40000 ALTER TABLE `membroamigo` DISABLE KEYS */;

/*!40000 ALTER TABLE `membroamigo` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table membrofavorito
#

CREATE TABLE `membrofavorito` (
  `membroId` int(11) NOT NULL,
  `favoritosId` int(11) NOT NULL,
  PRIMARY KEY  (`membroId`,`favoritosId`),
  KEY `favoritosId` (`favoritosId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table membrofavorito
#
LOCK TABLES `membrofavorito` WRITE;
/*!40000 ALTER TABLE `membrofavorito` DISABLE KEYS */;

/*!40000 ALTER TABLE `membrofavorito` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table menu
#

CREATE TABLE `menu` (
  `id` int(11) NOT NULL auto_increment,
  `id_pai` int(11) default NULL,
  `num_ordem` int(11) default NULL,
  `desc_link` varchar(100) default NULL,
  `desc_comentario` varchar(100) default NULL,
  `nome_menu` varchar(100) default NULL,
  `sgl_sist` int(11) default NULL,
  `imagem` varchar(255) default NULL,
  `TOTAL` varchar(255) default NULL,
  PRIMARY KEY  (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;

#
# Dumping data for table menu
#
LOCK TABLES `menu` WRITE;
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;

INSERT INTO `menu` VALUES (2,0,1,'','','Administrador',NULL,'6',NULL);
INSERT INTO `menu` VALUES (6,2,1,'/menu/','','Menu',NULL,'6',NULL);
INSERT INTO `menu` VALUES (17,2,2,'/role/','cadastro de grupos','Role',0,'','');
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table olhos
#

CREATE TABLE `olhos` (
  `olhosId` int(11) NOT NULL auto_increment,
  `olhosName` varchar(255) NOT NULL,
  PRIMARY KEY  (`olhosId`),
  UNIQUE KEY `olhosName` (`olhosName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table olhos
#
LOCK TABLES `olhos` WRITE;
/*!40000 ALTER TABLE `olhos` DISABLE KEYS */;

/*!40000 ALTER TABLE `olhos` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table pais
#

CREATE TABLE `pais` (
  `paisId` int(11) NOT NULL,
  `paisName` varchar(255) NOT NULL,
  PRIMARY KEY  (`paisId`),
  UNIQUE KEY `paisName` (`paisName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table pais
#
LOCK TABLES `pais` WRITE;
/*!40000 ALTER TABLE `pais` DISABLE KEYS */;

/*!40000 ALTER TABLE `pais` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table perfil
#

CREATE TABLE `perfil` (
  `perfilId` int(11) NOT NULL auto_increment,
  `perfilAltura` int(11) NOT NULL,
  `perfilPeso` int(11) NOT NULL,
  `perfilFumante` bit(1) NOT NULL,
  `perfilBebe` bit(1) NOT NULL,
  `pessoaInteresseConhecer` text,
  `pessoaFantasiasSexuais` text,
  `pessoaOutrosInteresses` text,
  PRIMARY KEY  (`perfilId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table perfil
#
LOCK TABLES `perfil` WRITE;
/*!40000 ALTER TABLE `perfil` DISABLE KEYS */;

/*!40000 ALTER TABLE `perfil` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table pessoa
#

CREATE TABLE `pessoa` (
  `sexoId` int(11) NOT NULL,
  `olhosId` int(11) NOT NULL,
  `cabelosId` int(11) NOT NULL,
  `etiniaId` int(11) NOT NULL,
  `perfilId` int(11) NOT NULL,
  `estadoCivilId` int(11) NOT NULL,
  `enderecoId` int(11) NOT NULL,
  `pessoaId` int(11) NOT NULL,
  `pessoaName` varchar(255) NOT NULL,
  `pessoaNascimento` date NOT NULL,
  `pessoaProfissao` varchar(255) NOT NULL,
  `pessoaEmail` varchar(255) NOT NULL,
  `pessoaMSN` varchar(255) default NULL,
  PRIMARY KEY  (`pessoaId`),
  UNIQUE KEY `pessoaEmail` (`pessoaEmail`),
  UNIQUE KEY `pessoaMSN` (`pessoaMSN`),
  KEY `enderecoId` (`enderecoId`),
  KEY `perfilId` (`perfilId`),
  KEY `sexoId` (`sexoId`),
  KEY `etiniaId` (`etiniaId`),
  KEY `cabelosId` (`cabelosId`),
  KEY `olhosId` (`olhosId`),
  KEY `estadoCivilId` (`estadoCivilId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table pessoa
#
LOCK TABLES `pessoa` WRITE;
/*!40000 ALTER TABLE `pessoa` DISABLE KEYS */;

/*!40000 ALTER TABLE `pessoa` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table post
#

CREATE TABLE `post` (
  `membroId` int(11) NOT NULL,
  `fotoId` int(11) NOT NULL,
  `postId` int(11) NOT NULL auto_increment,
  `postText` text NOT NULL,
  PRIMARY KEY  (`postId`),
  KEY `membroId` (`membroId`,`fotoId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table post
#
LOCK TABLES `post` WRITE;
/*!40000 ALTER TABLE `post` DISABLE KEYS */;

/*!40000 ALTER TABLE `post` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table role
#

CREATE TABLE `role` (
  `id` varchar(100) NOT NULL default '',
  `id_pai` varchar(20) default NULL,
  `cod_usu` varchar(255) default NULL,
  `cod_role` int(11) NOT NULL auto_increment,
  PRIMARY KEY  (`cod_role`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

#
# Dumping data for table role
#
LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;

INSERT INTO `role` VALUES ('administrador','administrador','1',1);
INSERT INTO `role` VALUES ('administrador','administrador',NULL,2);
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

#
# Table structure for table sexo
#

CREATE TABLE `sexo` (
  `sexoId` int(11) NOT NULL,
  `sexoName` varchar(255) NOT NULL,
  PRIMARY KEY  (`sexoId`),
  UNIQUE KEY `sexoName` (`sexoName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Dumping data for table sexo
#
LOCK TABLES `sexo` WRITE;
/*!40000 ALTER TABLE `sexo` DISABLE KEYS */;

/*!40000 ALTER TABLE `sexo` ENABLE KEYS */;
UNLOCK TABLES;

/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
