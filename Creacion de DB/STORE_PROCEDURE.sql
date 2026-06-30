
USE BD2_TPI_G35;
GO

CREATE OR ALTER PROCEDURE dbo.sp_ProcesarStock
AS
BEGIN
    SET NOCOUNT ON;

    ----------------------------------------
    -- 1. ERRORES (carga los datos que tienen error en esta tabla para corregirlos)
    ----------------------------------------
    INSERT INTO Stock_Error 
        (CodBase, CodColor, CodTalle, Cantidad, Error, Fecha)
    SELECT 
        T.CodBase,
        T.CodColor,
        T.CodTalle,
        T.Cantidad,
        CASE 
            WHEN A.idArticulo IS NULL THEN 'No existe el artículo'
            WHEN C.idColor IS NULL THEN 'No existe el color'
            WHEN TA.idTalle IS NULL THEN 'No existe el talle'
            WHEN D.idDetalle IS NULL THEN 'No existe la combinación'
        END,
        GETDATE()
    FROM Stock_Temp T
    LEFT JOIN Articulo A 
        ON A.CodigoBase = T.CodBase
    LEFT JOIN Color C 
        ON C.Codigo = T.CodColor
    LEFT JOIN Talle TA 
        ON TA.Codigo = T.CodTalle
    LEFT JOIN DetalleArticulo D 
        ON D.idArticulo = A.idArticulo
        AND D.idColor = C.idColor
        AND D.idTalle = TA.idTalle
    WHERE 
        A.idArticulo IS NULL
        OR C.idColor IS NULL
        OR TA.idTalle IS NULL
        OR D.idDetalle IS NULL;

    ----------------------------------------
    -- 2. DATOS VALIDOS (temp  cargamos los datos validos )
    ----------------------------------------
    SELECT 
        D.idDetalle,
        T.Cantidad
    INTO #DatosValidos
    FROM Stock_Temp T
    INNER JOIN Articulo A 
        ON A.CodigoBase = T.CodBase
    INNER JOIN Color C 
        ON C.Codigo = T.CodColor
    INNER JOIN Talle TA 
        ON TA.Codigo = T.CodTalle
    INNER JOIN DetalleArticulo D 
        ON D.idArticulo = A.idArticulo
        AND D.idColor = C.idColor
        AND D.idTalle = TA.idTalle;

    ----------------------------------------
    -- 3. UPDATE STOCK (Actualiza el stock fisico )
    ----------------------------------------
    UPDATE S
    SET S.Cantidad = DV.Cantidad
    FROM Stock S
    INNER JOIN #DatosValidos DV 
        ON S.idDetalle = DV.idDetalle;

    ----------------------------------------
    -- INSERT NUEVOS 
    ----------------------------------------
    INSERT INTO Stock (idDetalle, idDeposito, Cantidad)
    SELECT 
        DV.idDetalle,
        1,
        DV.Cantidad
    FROM #DatosValidos DV
    LEFT JOIN Stock S 
        ON S.idDetalle = DV.idDetalle
    WHERE S.idDetalle IS NULL;

    ----------------------------------------
    -- LIMPIEZA
    ----------------------------------------
    DROP TABLE #DatosValidos;
    TRUNCATE TABLE Stock_Temp;

END
GO


CREATE PROCEDURE sp_transferirStockEntreDepositos
    @idDetalle INT,
    @idDepositoOrigen INT,
    @idDepositoDestino INT,
    @Cantidad INT
AS
BEGIN
    IF @idDepositoOrigen = @idDepositoDestino OR @Cantidad <= 0
    BEGIN
        PRINT 'Parámetros inválidos: depósitos iguales o cantidad no positiva.';
        RETURN;
    END

    IF NOT EXISTS (
        SELECT 1 FROM Stock
        WHERE idDetalle = @idDetalle AND idDeposito = @idDepositoOrigen AND Cantidad >= @Cantidad)
    BEGIN
        PRINT 'Stock insuficiente en el depósito de origen.';
        RETURN;
    END

    BEGIN TRY
        BEGIN TRANSACTION;
        UPDATE Stock SET Cantidad = Cantidad - @Cantidad
        WHERE idDetalle = @idDetalle AND idDeposito = @idDepositoOrigen;

        IF EXISTS (SELECT 1 FROM Stock WHERE idDetalle = @idDetalle AND idDeposito = @idDepositoDestino)
            UPDATE Stock SET Cantidad = Cantidad + @Cantidad
            WHERE idDetalle = @idDetalle AND idDeposito = @idDepositoDestino;
        ELSE
            INSERT INTO Stock (idDetalle, idDeposito, Cantidad) VALUES (@idDetalle, @idDepositoDestino, @Cantidad);

        COMMIT TRANSACTION;
        PRINT 'Transferencia realizada correctamente.';
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT 'Error durante la transferencia: ' + ERROR_MESSAGE();
    END CATCH
END;

SELECT * FROM Stock WHERE idDetalle = 1;

EXEC sp_transferirStockEntreDepositos @idDetalle = 1, @idDepositoOrigen = 1, @idDepositoDestino = 2, @Cantidad = 1;






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
