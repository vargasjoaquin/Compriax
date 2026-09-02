SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =========================================================================
-- 1. ÍNDICES DE SEGURIDAD Y USUARIOS
-- =========================================================================

CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Username]
ON [dbo].[Users] ([Username] ASC);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UQ_Users_SingleActiveAdmin]
ON [dbo].[Users] ([RoleId] ASC)
WHERE ([RoleId] = (1) AND [IsDeleted] = (0));
GO

-- =========================================================================
-- 2. ÍNDICES DE PRODUCTOS E INVENTARIO
-- =========================================================================

CREATE UNIQUE NONCLUSTERED INDEX [IX_Products_Barcode]
ON [dbo].[Products] ([Barcode] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Products_BrandId]
ON [dbo].[Products] ([BrandId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Products_CategoryId]
ON [dbo].[Products] ([CategoryId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Products_UnitOfMeasureId]
ON [dbo].[Products] ([UnitOfMeasureId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_StockMovements_ProductId]
ON [dbo].[StockMovements] ([ProductId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_StockMovements_UserId]
ON [dbo].[StockMovements] ([UserId] ASC);
GO

-- =========================================================================
-- 3. ÍNDICES DE PERSONAS Y RECURSOS HUMANOS
-- =========================================================================

CREATE NONCLUSTERED INDEX [IX_Customers_TaxConditionId]
ON [dbo].[Customers] ([TaxConditionId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Employees_GenderId]
ON [dbo].[Employees] ([GenderId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Employees_CivilStatusId]
ON [dbo].[Employees] ([CivilStatusId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Employees_PositionId]
ON [dbo].[Employees] ([PositionId] ASC);
GO

-- =========================================================================
-- 4. ÍNDICES DE CAJAS, TURNOS Y MOVIMIENTOS
-- =========================================================================

CREATE UNIQUE NONCLUSTERED INDEX [IX_CashRegisters_Number]
ON [dbo].[CashRegisters] ([Number] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_CashShifts_CashRegisterId]
ON [dbo].[CashShifts] ([CashRegisterId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_CashShifts_UserId]
ON [dbo].[CashShifts] ([UserId] ASC);
GO

CREATE UNIQUE NONCLUSTERED INDEX [UQ_CashShifts_SingleActiveShiftPerRegister]
ON [dbo].[CashShifts] ([CashRegisterId] ASC)
WHERE ([Status] = 'Abierta');
GO

CREATE NONCLUSTERED INDEX [IX_CashMovements_CashShiftId]
ON [dbo].[CashMovements] ([CashShiftId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_CashMovements_UserId]
ON [dbo].[CashMovements] ([UserId] ASC);
GO

-- =========================================================================
-- 5. ÍNDICES DE VENTAS, COMPRAS, PROMOCIONES Y AJUSTES
-- =========================================================================

CREATE NONCLUSTERED INDEX [IX_Sales_UserId]
ON [dbo].[Sales] ([UserId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Sales_CustomerId]
ON [dbo].[Sales] ([CustomerId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Sales_DocumentTypeId]
ON [dbo].[Sales] ([DocumentTypeId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Sales_PaymentMethodId]
ON [dbo].[Sales] ([PaymentMethodId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Sales_CashShiftId]
ON [dbo].[Sales] ([CashShiftId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Sales_CashRegisterId]
ON [dbo].[Sales] ([CashRegisterId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_SaleItems_SaleId]
ON [dbo].[SaleItems] ([SaleId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_SaleItems_ProductId]
ON [dbo].[SaleItems] ([ProductId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Purchases_UserId]
ON [dbo].[Purchases] ([UserId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Purchases_SupplierId]
ON [dbo].[Purchases] ([SupplierId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Purchases_DocumentTypeId]
ON [dbo].[Purchases] ([DocumentTypeId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Purchases_PaymentMethodId]
ON [dbo].[Purchases] ([PaymentMethodId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_PurchaseItems_PurchaseId]
ON [dbo].[PurchaseItems] ([PurchaseId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_PurchaseItems_ProductId]
ON [dbo].[PurchaseItems] ([ProductId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Promotions_ProductId]
ON [dbo].[Promotions] ([ProductId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_Promotions_CategoryId]
ON [dbo].[Promotions] ([CategoryId] ASC);
GO

CREATE NONCLUSTERED INDEX [IX_StoreSettings_TaxConditionId]
ON [dbo].[StoreSettings] ([TaxConditionId] ASC);
GO