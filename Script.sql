CREATE DATABASE blog_ASP;
GO
USE blog_ASP;
GO

CREATE TABLE usuario(
	id UNIQUEIDENTIFIER,
	nombre VARCHAR(100),
	apellido_paterno VARCHAR(100),
	apellido_materno VARCHAR(100),
	nickname VARCHAR(100),
	password VARCHAR(100),
	correo VARCHAR(100),
	nacimiento DATE,
	PRIMARY KEY(id)
);

CREATE TABLE etiqueta(
	id INT IDENTITY(1,1),
	valor VARCHAR(100),
	PRIMARY KEY(id)
);

CREATE TABLE blog(
	id INT IDENTITY(1,1),
	titulo VARCHAR(100),
	texto VARCHAR(8000),
	usuario UNIQUEIDENTIFIER,
	fecha DATETIME,
	PRIMARY KEY(id),
	FOREIGN KEY(usuario) REFERENCES usuario(id)
);

CREATE TABLE etiqueta_blog(
	id INT IDENTITY(1,1),
	etiqueta INT,
	blog INT,
	PRIMARY KEY(id),
	FOREIGN KEY(etiqueta) REFERENCES etiqueta(id),
	FOREIGN KEY(blog) REFERENCES blog(id)
);

CREATE TABLE favorito(
	id INT IDENTITY(1,1),
	usuario UNIQUEIDENTIFIER,
	favorito UNIQUEIDENTIFIER,
	PRIMARY KEY(id),
	FOREIGN KEY(usuario) REFERENCES usuario(id),
	FOREIGN KEY(favorito) REFERENCES usuario(id)
);

INSERT INTO usuario VALUES(
	NEWID(),
	'Patricio',
	'Pérez',
	'Pinto',
	'prez',
	'111',
	'prez@gmail.com',
	'07-09-1988'
);

INSERT INTO usuario VALUES(
	NEWID(),
	'Fabiola',
	'Muñoz',
	'Ampuero',
	'fabi',
	'222',
	'fabi@gmail.com',
	'25-05-1987'
);

INSERT INTO etiqueta(valor) VALUES('Chile');

SELECT * FROM usuario;
SELECT * FROM etiqueta;
SELECT * FROM blog;
SELECT * FROM etiqueta_blog;
SELECT * FROM favorito;

DELETE FROM usuario;

USE master;
GO
DROP DATABASE blog_ASP;

SELECT getdate() ;

SELECT MAX(id) FROM blog;

SELECT e.id, e.valor
FROM etiqueta e
INNER JOIN etiqueta_blog eb ON e.id = eb.etiqueta
INNER JOIN blog b ON b.id = eb.blog
WHERE b.id = '2';


-- Calculo de edad
SELECT (CAST(DATEDIFF(dd,(
	SELECT nacimiento
	FROM usuario
	WHERE id = ''
),GETDATE()) / 365.25 as int))


-- Búsqueda por #
SELECT b.id, b.titulo, b.texto, b.fecha 
FROM blog b
INNER JOIN etiqueta_blog eb ON eb.blog = b.id
INNER JOIN etiqueta e ON e.id = eb.etiqueta 
WHERE e.valor = 'canal13' 
ORDER BY b.titulo;