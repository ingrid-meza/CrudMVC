CREATE DATABASE DBCRUD;

USE DBCRUD;

CREATE TABLE Usuarios(
	IdUsuario int primary key identity,
	Nombre varchar(50),
	Apellido varchar(50),
	Correo varchar(50),
	FechaRegistro datetime default getdate()
);

SELECT * FROM Usuarios;