Create Database AccountMngDB;

USE AccountMngDB;


create table Persona(PersonaID INT PRIMARY KEY IDENTITY ,
     Nombre VARCHAR(100) NOT NULL,
     Genero VARCHAR(10) NOT NULL,
     Edad INT NOT NULL,
     Identificacion VARCHAR(20) NOT NULL,
     Direccion VARCHAR(200) NOT NULL,
     Telefono VARCHAR(15) NOT NULL)


CREATE TABLE  Cliente (
      ClienteID INT PRIMARY KEY,
      PersonaID INT UNIQUE,
      Contrasena VARCHAR(50) NOT NULL,
      Estado VARCHAR(20) NOT NULL,
      FOREIGN KEY (PersonaID) REFERENCES Persona(PersonaID)
);

CREATE TABLE Cuenta (
NumeroCuenta INT PRIMARY KEY,
TipoCuenta VARCHAR(50) NOT NULL,
SaldoInicial DECIMAL(10, 2) NOT NULL,
Estado VARCHAR(20) NOT NULL
);

-- Tabla para Movimientos
CREATE TABLE Movimientos (
     MovimientoID INT PRIMARY KEY IDENTITY ,
     NumeroCuenta INT,
     Fecha DATETIME NOT NULL,
     TipoMovimiento VARCHAR(50) NOT NULL,
     Valor DECIMAL(10, 2) NOT NULL,
     Saldo DECIMAL(10, 2) NOT NULL,
     FOREIGN KEY (NumeroCuenta) REFERENCES Cuenta(NumeroCuenta)
);