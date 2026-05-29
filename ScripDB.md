CREATE DATABASE TallerMecanicoDB;
GO

USE TallerMecanicoDB;
GO

CREATE TABLE TipoServicio (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    PrecioBase DECIMAL(18,2) NOT NULL
);
GO

CREATE TABLE Cliente (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Paterno VARCHAR(100) NOT NULL,
    Materno VARCHAR(100) NOT NULL,
    Nombres VARCHAR(100) NOT NULL,
    Correo VARCHAR(100) NULL,
    Telefono VARCHAR(20) NULL
);
GO

CREATE TABLE Vehiculo (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Placa VARCHAR(20) NOT NULL UNIQUE,
    Marca VARCHAR(50) NOT NULL,
    Modelo VARCHAR(50) NOT NULL,
    Anio INT NOT NULL,
    ClienteId INT NOT NULL,
    CONSTRAINT FK_Vehiculo_Cliente FOREIGN KEY (ClienteId) REFERENCES Cliente(Id)
);
GO

CREATE TABLE OrdenServicio (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FechaIngreso DATETIME NOT NULL DEFAULT GETDATE(),
    DescripcionProblema VARCHAR(MAX) NOT NULL,
    CostoEstimado DECIMAL(18,2) NOT NULL,
    Estado VARCHAR(50) NOT NULL,
    VehiculoId INT NOT NULL,
    TipoServicioId INT NOT NULL,
    CONSTRAINT FK_OrdenServicio_Vehiculo FOREIGN KEY (VehiculoId) REFERENCES Vehiculo(Id),
    CONSTRAINT FK_OrdenServicio_TipoServicio FOREIGN KEY (TipoServicioId) REFERENCES TipoServicio(Id)
);
GO
