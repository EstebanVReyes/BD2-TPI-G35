-- =====================================================================

-- =====================================================================
-- 6. INSERTS
-- =====================================================================

INSERT INTO Rubro (Nombre, Descripcion) VALUES
('ABR','Abrigos'),
('RMC','Remeras'),
('JEA','Pantalones'),
('CML','Camisas');

INSERT INTO Marca (Nombre) VALUES ('Bensimon');

INSERT INTO Proveedor (Nombre, Telefono, Direccion)
VALUES ('Proveedor General','123456789','Buenos Aires');

INSERT INTO Deposito (Nombre, Direccion)
VALUES ('Deposito Central','Buenos Aires');

INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Clave)
VALUES ('Juan','Perez','jperez','123456');

INSERT INTO TipoMovimiento (Nombre) VALUES
('Ingreso'),
('Egreso');

INSERT INTO Color (Codigo, Nombre) VALUES
('36','Color 36'),
('07','Color 07'),
('09','Color 09'),
('01','Color 01'),
('08','Color 08');

INSERT INTO Talle (Codigo, Nombre) VALUES
('LA','Large'),
('ME','Medium'),
('SM','Small'),
('XL','Extra Large'),
('UN','Unico'),
('28','Talle 28'),
('30','Talle 30');

-- ARTICULOS
INSERT INTO Articulo (Nombre, Descripcion, idRubro, idMarca, idProveedor, CodigoBase) VALUES
('CHALECO JOAQUIN','CHALECO JOAQUIN - NYLON',1,1,1,'24022'),
('MONTGOMERY CIUDAD','MONTGOMERY CIUDAD',1,1,1,'60095'),
('PARKA ARMY','PARKA ARMY',1,1,1,'60206'),
('REMERA COLORS','REMERA COLORS M/C',2,1,1,'11933'),
('REMERA PIMA PERU','REMERA PIMA PERU M/C',2,1,1,'11957'),
('PANTALON STANDARD BLACK','PANTALON STANDARD BLACK',3,1,1,'47183'),
('PANTALON TAYLOR','PANTALON TAYLOR INVERSO',3,1,1,'47204'),
('CAMISA CHELSEA','CAMISA CHELSEA M/L',4,1,1,'40422'),
('CAMISA CERDENA','CAMISA CERDENA M/L',4,1,1,'41222');

-- DETALLE
INSERT INTO DetalleArticulo (idArticulo, idColor, idTalle, SKU, Precio) VALUES
(1,1,1,'2402236LA',248000),
(1,1,2,'2402236ME',248000),
(1,1,3,'2402236SM',248000),

(2,2,1,'6009507LA',790000),
(2,2,2,'6009507ME',790000),

(3,3,1,'6020609LA',370000),
(3,3,2,'6020609ME',370000),

(4,2,1,'1193307LA',56000),
(4,2,2,'1193307ME',56000),

(5,2,1,'1195707LA',76000),
(5,2,2,'1195707ME',76000),

(6,2,6,'471830728',148000),
(6,2,7,'471830730',148000),

(7,4,6,'472040128',178000),
(7,4,7,'472040130',178000),

(8,5,1,'4042208LA',128000),
(8,5,2,'4042208ME',128000),

-- Variantes añadidas para Camisa Cerdeña (idArticulo = 9)
(9,3,1,'4122209LA',128000), -- idDetalle: 18
(9,3,2,'4122209ME',128000); -- idDetalle: 19

-- STOCK
INSERT INTO Stock (idDetalle, idDeposito, Cantidad) VALUES
(1,1,2),(2,1,2),(3,1,1),
(4,1,2),(5,1,2),
(6,1,4),(7,1,4),
(8,1,5),(9,1,4),
(10,1,6),(11,1,6),
(12,1,2),(13,1,2),
(14,1,3),(15,1,3),
(16,1,2),(17,1,2),
-- Se añade stock para las variantes añadidas de la Camisa Cerdeña
(18,1,2),(19,1,2);
GO

