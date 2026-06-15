-- =====================================================================
-- 1. CREAR BASE DE DATOS
-- =====================================================================

IF DB_ID(' BD2_TPI_G35') IS NOT NULL
    DROP DATABASE BD2_TPI_G35;
GO

CREATE DATABASE  BD2_TPI_G35;
GO

USE  BD2_TPI_G35;
GO

-- =====================================================================
-- 2. TABLAS MAESTRAS
-- =====================================================================

CREATE TABLE Rubro (
    idRubro INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50),
    Descripcion VARCHAR(60)
);

CREATE TABLE Marca (
    idMarca INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50)
);

CREATE TABLE Proveedor (
    idProveedor INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(60),
    Telefono VARCHAR(50),
    Direccion VARCHAR(100)
);

CREATE TABLE Color (
    idColor INT PRIMARY KEY IDENTITY(1,1),
    Codigo VARCHAR(5) UNIQUE,
    Nombre VARCHAR(60)
);

CREATE TABLE Talle (
    idTalle INT PRIMARY KEY IDENTITY(1,1),
    Codigo VARCHAR(5) UNIQUE,
    Nombre VARCHAR(50)
);

CREATE TABLE Deposito (
    idDeposito INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(60),
    Direccion VARCHAR(100)
);

CREATE TABLE Usuario (
    idUsuario INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
    NombreUsuario VARCHAR(50) UNIQUE,
    Clave VARCHAR(100)
);

-- =====================================================================
-- 3. PRODUCTOS
-- =====================================================================

CREATE TABLE Articulo (
    idArticulo INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(60),
    Descripcion VARCHAR(100),
    idRubro INT,
    idMarca INT,
    idProveedor INT,
    CodigoBase VARCHAR(20) UNIQUE,
    FOREIGN KEY (idRubro) REFERENCES Rubro(idRubro),
    FOREIGN KEY (idMarca) REFERENCES Marca(idMarca),
    FOREIGN KEY (idProveedor) REFERENCES Proveedor(idProveedor)
);

CREATE TABLE DetalleArticulo (
    idDetalle INT PRIMARY KEY IDENTITY(1,1),
    idArticulo INT,
    idColor INT,
    idTalle INT,
    SKU VARCHAR(50) UNIQUE,
    Precio DECIMAL(10,2),
    FOREIGN KEY (idArticulo) REFERENCES Articulo(idArticulo),
    FOREIGN KEY (idColor) REFERENCES Color(idColor),
    FOREIGN KEY (idTalle) REFERENCES Talle(idTalle)
);

CREATE TABLE Stock (
    idStock INT PRIMARY KEY IDENTITY(1,1),
    idDetalle INT,
    idDeposito INT,
    Cantidad INT,
    FOREIGN KEY (idDetalle) REFERENCES DetalleArticulo(idDetalle),
    FOREIGN KEY (idDeposito) REFERENCES Deposito(idDeposito),
    CONSTRAINT UQ_Stock UNIQUE (idDetalle, idDeposito)
);

-- =====================================================================
-- 4. TRANSACCIONES
-- =====================================================================

CREATE TABLE Venta (
    idVenta INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME DEFAULT GETDATE(),
    idUsuario INT,
    Total DECIMAL(10,2),
    FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario)
);

CREATE TABLE DetalleVenta (
    idDetalleVenta INT PRIMARY KEY IDENTITY(1,1),
    idVenta INT,
    idDetalle INT,
    Cantidad INT,
    PrecioUnitario DECIMAL(10,2),
    FOREIGN KEY (idVenta) REFERENCES Venta(idVenta),
    FOREIGN KEY (idDetalle) REFERENCES DetalleArticulo(idDetalle)
);

CREATE TABLE Compra (
    idCompra INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME DEFAULT GETDATE(),
    idProveedor INT,
    Total DECIMAL(10,2),
    FOREIGN KEY (idProveedor) REFERENCES Proveedor(idProveedor)
);

CREATE TABLE DetalleCompra (
    idDetalleCompra INT PRIMARY KEY IDENTITY(1,1),
    idCompra INT,
    idDetalle INT,
    Cantidad INT,
    PrecioUnitario DECIMAL(10,2),
    FOREIGN KEY (idCompra) REFERENCES Compra(idCompra),
    FOREIGN KEY (idDetalle) REFERENCES DetalleArticulo(idDetalle)
);

-- =====================================================================
-- 5. MOVIMIENTOS
-- =====================================================================

CREATE TABLE TipoMovimiento (
    idTipoMovimiento INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50)
);

CREATE TABLE Movimiento (
    idMovimiento INT PRIMARY KEY IDENTITY(1,1),
    idDetalle INT,
    idTipoMovimiento INT,
    idDeposito INT,
    Cantidad INT,
    Fecha DATETIME DEFAULT GETDATE(),
    idUsuario INT,
    FOREIGN KEY (idDetalle) REFERENCES DetalleArticulo(idDetalle),
    FOREIGN KEY (idTipoMovimiento) REFERENCES TipoMovimiento(idTipoMovimiento),
    FOREIGN KEY (idDeposito) REFERENCES Deposito(idDeposito),
    FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario)
);

CREATE TABLE LogMovimiento (
    idLog INT PRIMARY KEY IDENTITY(1,1),
    idMovimiento INT,
    Accion VARCHAR(50),
    Fecha DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (idMovimiento) REFERENCES Movimiento(idMovimiento)
);
GO

