--procedimiento almacenado

CREATE PROCEDURE sp_RegistrarVenta
    @IdUsuario INT,
    @IdDetalle INT,
    @Cantidad INT,
    @PrecioUnitario DECIMAL(10,2)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

       
        INSERT INTO Venta (Fecha, IdUsuario, Total)
        VALUES (GETDATE(), @IdUsuario, (@Cantidad * @PrecioUnitario));

       
        DECLARE @IdVenta INT = SCOPE_IDENTITY();

        
        INSERT INTO DetalleVenta (IdVenta, IdDetalle, Cantidad, PrecioUnitario)
        VALUES (@IdVenta, @IdDetalle, @Cantidad, @PrecioUnitario);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        
        ROLLBACK TRANSACTION;
        PRINT 'Error al registrar la venta. Transacción cancelada.'+ ERROR_MESSAGE();
    END CATCH
END;
GO

