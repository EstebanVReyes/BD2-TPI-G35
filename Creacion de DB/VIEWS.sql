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
