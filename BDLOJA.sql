--USE master;
--GO

--DROP DATABASE BDLOJA;

CREATE DATABASE BDLOJA;
GO

USE BDLOJA;
GO

CREATE SCHEMA LOJA;
GO

CREATE TABLE LOJA.USUARIO(
IDUSUARIO INT IDENTITY NOT NULL PRIMARY KEY,
NOME VARCHAR(50) NOT NULL,
USUARIO VARCHAR(15) NOT NULL,
SENHA VARCHAR(12) NOT NULL,
EMAIL VARCHAR(50) NOT NULL,
TIPO BIT NOT NULL
);
GO

CREATE TABLE LOJA.CAIXA(
IDCAIXA INT IDENTITY NOT NULL PRIMARY KEY,
IDUSUARIO INT NOT NULL,
DATA DATETIME NOT NULL,
VALOR DECIMAL(6,2) NOT NULL
FOREIGN KEY (IDUSUARIO)
REFERENCES LOJA.USUARIO(IDUSUARIO)
);
GO

CREATE TABLE LOJA.FUNCIONARIO(
IDFUNCIONARIO INT IDENTITY NOT NULL PRIMARY KEY,
NOME VARCHAR(50) NOT NULL,
RG VARCHAR(15) NOT NULL,
CPF CHAR(14) NOT NULL,
TELEFONE VARCHAR(13) NOT NULL,
ENDERECO VARCHAR(50) NOT NULL,
CARGO VARCHAR(20) NOT NULL,
SALARIO DECIMAL(6,2) NOT NULL
);
GO

CREATE TABLE LOJA.CLIENTE(
IDCLIENTE INT IDENTITY NOT NULL PRIMARY KEY,
NOME VARCHAR(50) NOT NULL,
RG VARCHAR(15) NOT NULL,
CPF CHAR(14) NOT NULL,
TELEFONE VARCHAR(13) NOT NULL,
ENDERECO VARCHAR(50) NOT NULL
);
GO

CREATE TABLE LOJA.CATEGORIA(
IDCATEGORIA INT IDENTITY NOT NULL PRIMARY KEY,
CATEGORIA VARCHAR(20) NOT NULL
);
GO

CREATE TABLE LOJA.ROUPA(
IDROUPA INT IDENTITY NOT NULL PRIMARY KEY,
DESCRICAO VARCHAR(30) NOT NULL,
IDCATEGORIA INT NOT NULL,
QUANTIDADE INT NOT NULL,
PRECOBRUTO DECIMAL(6,2) NOT NULL,
PRECOVENDA DECIMAL(6,2) NOT NULL,
OBSERVACOES VARCHAR(40) NULL
FOREIGN KEY (IDCATEGORIA)
REFERENCES LOJA.CATEGORIA(IDCATEGORIA)
);
GO

CREATE TABLE LOJA.VENDA(
IDVENDA INT IDENTITY NOT NULL PRIMARY KEY,
DATAVENDA DATETIME NOT NULL,
IDCLIENTE INT NOT NULL,
PRECOTOTAL DECIMAL(6,2) NOT NULL,
PAGAMENTO VARCHAR(15) NOT NULL
FOREIGN KEY (IDCLIENTE)
REFERENCES LOJA.CLIENTE(IDCLIENTE)
);
GO

CREATE TABLE LOJA.ITEN(
IDITEN INT IDENTITY NOT NULL PRIMARY KEY,
IDVENDA INT NOT NULL,
IDROUPA INT NOT NULL,
PRECOUNITARIO DECIMAL(6,2) NOT NULL,
QUANTPEDIDO INT NOT NULL
FOREIGN KEY (IDVENDA)
REFERENCES LOJA.VENDA(IDVENDA),
FOREIGN KEY (IDROUPA)
REFERENCES LOJA.ROUPA(IDROUPA)
);
GO

