# Sistema de Inventario

Este proyecto consiste en el desarrollo de una Base de Datos para la gestión de inventario.

## Contexto Académico:

Este sistema fue desarrollado en el marco de la materia Base de Datos 2 (Año 2026) de la Tecnicatura Universitaria en Programación - UTN FRGP.

### Integrantes del equipo:
  - Valverde, Maycol
  - Reyes, Esteban
  - Hernandez, Melanie

---

## Descripción del Sistema

La aplicación permite a los usuarios:

  - Buscar productos por nombre, categoría o marca.
  - Gestionar el catálogo mediante el alta, baja y modificación de productos, categorías y marcas.
  - Registrar de forma detallada los ingresos y salidas de mercadería, incluyendo la fecha y el usuario responsable.
  - Controlar y actualizar automáticamente el stock disponible tras cada movimiento registrado.
  - Consultar el inventario actual y el historial de movimientos de cada artículo. 

La base de datos respalda la lógica del sistema, gestionando entidades como:

  - Articulo
  - Deposito
  - Usuario
  - Venta
  - Compra
  - Stock
  - Proveedor
  - Movimiento

---

## Componentes Técnicos:

### Triggers

  - trg_InsertStock
  - trg_actualizarTotalCompra
  - trg_ValidarStockAntesDeVender

### Procedimientos almacenados

  - sp_ProcesarStock
  - sp_transferirStockEntreDepositos
  - sp_RegistrarVenta

### Vistas

  - VStockCompleto
  - vista_articulosAReponer
  - Vista_ArticulosMasVendidos

---

## Grupo 35.
