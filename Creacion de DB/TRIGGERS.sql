
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

SELECT Total FROM Compra WHERE idCompra = 1; 
UPDATE DetalleCompra SET Cantidad = 10 WHERE idCompra = 1 AND idDetalle = 2;



CREATE TRIGGER TR_ValidarStockAntesDeVender
ON DetalleVenta
INSTEAD OF INSERT
AS
BEGIN

    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN STOCK s ON i.IdDetalle = s.IdDetalle
        WHERE i.Cantidad > s.Cantidad
    )
    BEGIN
        RAISERROR ('Error: La venta no puede realizarse porque no hay stock suficiente para uno de los productos seleccionados.', 16, 1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
       
        INSERT INTO DetalleVenta (IdVenta, IdDetalle, Cantidad, PrecioUnitario)
        SELECT IdVenta, IdDetalle, Cantidad, PrecioUnitario FROM inserted;
    END
END

--ejemplos 



INSERT INTO DetalleVenta (IdVenta, IdDetalle, Cantidad, PrecioUnitario)
VALUES (1, 1, 999, 1000);


SELECT * FROM Venta

