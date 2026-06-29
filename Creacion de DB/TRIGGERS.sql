
CREATE TRIGGER trg_InsertStock
ON DetalleArticulo
AFTER INSERT
AS
BEGIN
    INSERT INTO Stock (idDetalle, idDeposito, Cantidad)
    SELECT idDetalle, 1, 0
    FROM inserted;
END;
