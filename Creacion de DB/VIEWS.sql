SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VStockCompleto] AS
SELECT
    R.Nombre AS Rubro,
    A.CodigoBase,
    C.Nombre AS Color,
    T.Nombre AS Talle,
    A.Descripcion,
    S.Cantidad,
    DA.Precio,
    D.Nombre AS Deposito
FROM Stock S
INNER JOIN DetalleArticulo DA ON S.idDetalle = DA.idDetalle
INNER JOIN Articulo A ON DA.idArticulo = A.idArticulo
INNER JOIN Rubro R ON A.idRubro = R.idRubro
INNER JOIN Color C ON DA.idColor = C.idColor
INNER JOIN Talle T ON DA.idTalle = T.idTalle
INNER JOIN Deposito D ON S.idDeposito = D.idDeposito;
GO


CREATE VIEW vista_articulosAReponer AS
SELECT
    da.idDetalle,
    a.Nombre AS Articulo,
    m.Nombre AS Marca,
    r.Descripcion AS Rubro,
    t.Nombre AS Talle,
    c.Nombre AS Color,
    ISNULL(SUM(s.Cantidad),0) AS StockActual
FROM DetalleArticulo da
INNER JOIN Articulo a ON a.idArticulo = da.idArticulo
INNER JOIN Marca m ON m.idMarca = a.idMarca
INNER JOIN Rubro r ON r.idRubro = a.idRubro
INNER JOIN Talle t ON t.idTalle = da.idTalle
INNER JOIN Color c ON c.idColor = da.idColor
LEFT JOIN Stock s ON s.idDetalle = da.idDetalle
GROUP BY da.idDetalle, a.Nombre, m.Nombre, r.Descripcion, t.Nombre, c.Nombre
HAVING ISNULL(SUM(s.Cantidad),0) <= 5;

SELECT * FROM vista_articulosAReponer;



CREATE VIEW Vista_ArticulosMasVendidos AS
SELECT 
    A.Nombre AS NombreArticulo,
    M.Nombre AS Marca,
    R.Nombre AS Categoria,
    SUM(DV.Cantidad) AS CantidadTotalVendida,
    SUM(DV.Cantidad * DV.PrecioUnitario) AS RecaudacionTotal
FROM Articulo A
JOIN DetalleArticulo DA ON A.idArticulo = DA.idArticulo
JOIN DetalleVenta DV ON DA.idDetalle = DV.idDetalle
JOIN Venta V ON DV.IdVenta = V.IdVenta
JOIN Marca M ON A.IdMarca = M.IdMarca
JOIN Rubro R ON A.IdRubro = R.IdRubro
GROUP BY A.Nombre, M.Nombre, R.Nombre;
GO