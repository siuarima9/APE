CREATE DATABASE apeapi;

\connect apeapi

-- DROP SCHEMA "Cliente";
CREATE SCHEMA "Cliente" AUTHORIZATION postgres;

CREATE TABLE "Cliente".genero (
    cd_genero int NOT NULL,
    ds_descricao varchar(15) NOT NULL,

    CONSTRAINT genero_pk PRIMARY KEY (cd_genero)
);

-- Create the table in the specified schema
CREATE TABLE "Cliente".cliente (
	cd_cliente uuid NOT NULL,
    cd_genero int not null,
	nm_nome varchar(50) NOT NULL,
	nm_sobrenome varchar(50) NOT NULL,
	nu_cpf varchar(11) NOT NULL,

	CONSTRAINT cliente_pk PRIMARY KEY (cd_cliente),
    FOREIGN KEY (cd_genero) REFERENCES "Cliente".genero (cd_genero)
);

CREATE TABLE "Cliente".Contato (
	cd_contato uuid NOT NULL,
	cd_cliente uuid NOT NULL,
	nu_ddd varchar(2) NOT NULL,
	nu_numero varchar(11) NOT NULL,
	nm_email varchar(50) NOT null,

	CONSTRAINT contato_pk PRIMARY KEY (CD_contato),
    UNIQUE (cd_cliente),
	FOREIGN KEY (CD_Cliente) REFERENCES "Cliente".Cliente (CD_Cliente)
);


INSERT INTO "Cliente".genero
    (cd_genero, ds_descricao)
VALUES
    (1, 'FEMINIMO'),
    (2, 'MASCULINO'),
    (3, 'OUTRO');

