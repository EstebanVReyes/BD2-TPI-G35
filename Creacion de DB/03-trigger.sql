--Trigger
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