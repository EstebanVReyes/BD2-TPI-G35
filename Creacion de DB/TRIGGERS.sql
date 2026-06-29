
CREATE TRIGGER trg_InsertStock
ON DetalleArticulo
AFTER INSERT
AS
BEGIN
    INSERT INTO Stock (idDetalle, idDeposito, Cantidad)
    SELECT idDetalle, 1, 0
    FROM inserted;
END;


CREATE TRIGGER trg_actualizarTotalCompra
ON DetalleCompra
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE c
    SET c.Total = ISNULL((
        SELECT SUM(dc.Cantidad * dc.PrecioUnitario)
        FROM DetalleCompra dc
        WHERE dc.idCompra = c.idCompra),0)
     FROM Compra c
     WHERE c.idCompra IN (SELECT idCompra FROM inserted UNION SELECT idCompra FROM deleted);
END;


