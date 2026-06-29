-- Vistas

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








