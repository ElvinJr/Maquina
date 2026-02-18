CREATE DATABASE Maquina;

USE Maquina;

CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,
    Imagen NVARCHAR(MAX) NULL
);

INSERT INTO Productos (Nombre, Precio, Stock, Imagen)
VALUES 
('PapasLaysClásicas', 28.00, 15, 'PapasLaysClásicas.png'),
('Doritos Nachos', 30.00, 15, 'DoritosNachos.png'),
('CheetosCrunchy', 30.00, 15, 'CheetosCrunchy.png'),
('Galletas Oreo', 25.00, 20, 'GalletasOreo.png'),
('Galletas Pepitos', 22.00, 18, 'GalletasPepitos.png'),
('ChokisClásicas', 20.00, 25, 'ChokisClásicas.png'),
('JugodeNaranja', 28.00, 8, 'JugodeNaranja.png'),
('JugodeManzana', 28.00, 8, 'JugodeManzana.png'),
('JugodeUva', 28.00, 8, 'JugodeUva.png'),
('CocaCola', 40.00, 20, 'CocaCola.png'),
('FantaNaranja', 30.00, 12, 'FantaNaranja.png'),
('Sprite', 35.00, 15, 'Sprite.png');


Select * from Productos