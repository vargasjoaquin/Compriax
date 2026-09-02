SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =========================================================================
-- 1. TABLAS MAESTRAS Y CATÁLOGOS BASE (Sin dependencias foráneas)
-- =========================================================================

CREATE TABLE [dbo].[Roles] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NOT NULL,
    [RowVersion] TIMESTAMP     NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Brands] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50)  NOT NULL,
    [RowVersion]    TIMESTAMP      NOT NULL,
    [CreatedAt]     DATETIME2 (7)  NOT NULL,
    [CreatedBy]     NVARCHAR (MAX) NULL,
    [LastUpdatedAt] DATETIME2 (7)  NULL,
    [LastUpdatedBy] NVARCHAR (MAX) NULL,
    [IsDeleted]     BIT            NOT NULL,
    CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Categories] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (50)  NOT NULL,
    [Description]   NVARCHAR (250) NULL,
    [IsActive]      BIT            NOT NULL,
    [RowVersion]    TIMESTAMP      NOT NULL,
    [CreatedAt]     DATETIME2 (7)  NOT NULL,
    [CreatedBy]     NVARCHAR (MAX) NULL,
    [LastUpdatedAt] DATETIME2 (7)  NULL,
    [LastUpdatedBy] NVARCHAR (MAX) NULL,
    [IsDeleted]     BIT            NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[UnitsOfMeasure] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    [Abbreviation] NVARCHAR (10) NOT NULL,
    [RowVersion]   TIMESTAMP     NOT NULL,
    CONSTRAINT [PK_UnitsOfMeasure] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[TaxConditions] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_TaxConditions] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[DocumentTypes] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_DocumentTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[PaymentMethods] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [IsActive] BIT            NOT NULL,
    [Name]     NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_PaymentMethods] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Positions] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Genders] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Genders] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[CivilStatuses] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_CivilStatuses] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Suppliers] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [CUIT]          NVARCHAR (25)  NOT NULL,
    [CompanyName]   NVARCHAR (100) NOT NULL,
    [ContactName]   NVARCHAR (80)  NULL,
    [Email]         NVARCHAR (100) NULL,
    [Phone]         NVARCHAR (30)  NULL,
    [Address]       NVARCHAR (150) NULL,
    [IsActive]      BIT            NOT NULL,
    [RowVersion]    TIMESTAMP      NOT NULL,
    [CreatedAt]     DATETIME2 (7)  NOT NULL,
    [CreatedBy]     NVARCHAR (MAX) NULL,
    [LastUpdatedAt] DATETIME2 (7)  NULL,
    [LastUpdatedBy] NVARCHAR (MAX) NULL,
    [IsDeleted]     BIT            NOT NULL,
    CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[CashRegisters] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Number]        INT            NOT NULL,
    [Name]          NVARCHAR (50)  NOT NULL,
    [Description]   NVARCHAR (150) NULL,
    [IsActive]      BIT            NOT NULL,
    [RowVersion]    TIMESTAMP      NOT NULL,
    [CreatedAt]     DATETIME2 (7)  NOT NULL,
    [CreatedBy]     NVARCHAR (MAX) NULL,
    [LastUpdatedAt] DATETIME2 (7)  NULL,
    [LastUpdatedBy] NVARCHAR (MAX) NULL,
    [IsDeleted]     BIT            NOT NULL,
    CONSTRAINT [PK_CashRegisters] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

-- =========================================================================
-- 2. TABLAS CON DEPENDENCIAS DE PRIMER NIVEL
-- =========================================================================

CREATE TABLE [dbo].[Users] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [Username]      NVARCHAR (50)   NOT NULL,
    [Password]      NVARCHAR (255)  NOT NULL,
    [FirstName]     NVARCHAR (50)   NOT NULL,
    [LastName]      NVARCHAR (50)   NOT NULL,
    [Email]         NVARCHAR (100)  NULL,
    [IsActive]      BIT             NOT NULL,
    [Photo]         VARBINARY (MAX) NULL,
    [RoleId]        INT             NOT NULL,
    [RowVersion]    TIMESTAMP       NOT NULL,
    [CreatedAt]     DATETIME2 (7)   NOT NULL,
    [CreatedBy]     NVARCHAR (MAX)  NULL,
    [LastUpdatedAt] DATETIME2 (7)   NULL,
    [LastUpdatedBy] NVARCHAR (MAX)  NULL,
    [IsDeleted]     BIT             NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id])
);
GO

CREATE TABLE [dbo].[Customers] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [DocumentNumber] NVARCHAR (20)  NOT NULL,
    [Cuil]           NVARCHAR (25)  NULL,
    [FirstName]      NVARCHAR (50)  NOT NULL,
    [LastName]       NVARCHAR (50)  NOT NULL,
    [Email]          NVARCHAR (100) NULL,
    [Phone]          NVARCHAR (30)  NULL,
    [Address]        NVARCHAR (150) NULL,
    [City]           NVARCHAR (80)  NULL,
    [TaxConditionId] INT            NULL,
    [IsActive]       BIT            NOT NULL,
    [RowVersion]     TIMESTAMP      NOT NULL,
    [CreatedAt]      DATETIME2 (7)  NOT NULL,
    [CreatedBy]      NVARCHAR (MAX) NULL,
    [LastUpdatedAt]  DATETIME2 (7)  NULL,
    [LastUpdatedBy]  NVARCHAR (MAX) NULL,
    [IsDeleted]      BIT            NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Customers_TaxConditions_TaxConditionId] FOREIGN KEY ([TaxConditionId]) REFERENCES [dbo].[TaxConditions] ([Id])
);
GO

CREATE TABLE [dbo].[Employees] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [EmployeeCode]   NVARCHAR (20)   NOT NULL,
    [DocumentNumber] NVARCHAR (20)   NOT NULL,
    [FirstName]      NVARCHAR (50)   NOT NULL,
    [LastName]       NVARCHAR (50)   NOT NULL,
    [Email]          NVARCHAR (100)  NULL,
    [Phone]          NVARCHAR (30)   NULL,
    [Cuil]           NVARCHAR (25)   NULL,
    [Address]        NVARCHAR (150)  NULL,
    [ChildrenCount]  INT             NOT NULL,
    [Photo]          VARBINARY (MAX) NULL,
    [IsActive]       BIT             NOT NULL,
    [GenderId]       INT             NULL,
    [CivilStatusId]  INT             NULL,
    [PositionId]     INT             NULL,
    [RowVersion]     TIMESTAMP       NOT NULL,
    [CreatedAt]      DATETIME2 (7)   NOT NULL,
    [CreatedBy]      NVARCHAR (MAX)  NULL,
    [LastUpdatedAt]  DATETIME2 (7)   NULL,
    [LastUpdatedBy]  NVARCHAR (MAX)  NULL,
    [IsDeleted]      BIT             NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Employees_Genders_GenderId] FOREIGN KEY ([GenderId]) REFERENCES [dbo].[Genders] ([Id]),
    CONSTRAINT [FK_Employees_CivilStatuses_CivilStatusId] FOREIGN KEY ([CivilStatusId]) REFERENCES [dbo].[CivilStatuses] ([Id]),
    CONSTRAINT [FK_Employees_Positions_PositionId] FOREIGN KEY ([PositionId]) REFERENCES [dbo].[Positions] ([Id])
);
GO

CREATE TABLE [dbo].[Products] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [Barcode]         NVARCHAR (50)   NOT NULL,
    [Name]            NVARCHAR (100)  NOT NULL,
    [Description]     NVARCHAR (250)  NULL,
    [BuyPrice]        DECIMAL (18, 4) NOT NULL,
    [SellPrice]       DECIMAL (18, 4) NOT NULL,
    [CurrentStock]    INT             NOT NULL,
    [MinimumStock]    INT             NOT NULL,
    [IsActive]        BIT             NOT NULL,
    [Image]           VARBINARY (MAX) NULL,
    [CategoryId]      INT             NOT NULL,
    [BrandId]         INT             NOT NULL,
    [UnitOfMeasureId] INT             NOT NULL,
    [RowVersion]      TIMESTAMP       NOT NULL,
    [CreatedAt]       DATETIME2 (7)   NOT NULL,
    [CreatedBy]       NVARCHAR (MAX)  NULL,
    [LastUpdatedAt]   DATETIME2 (7)   NULL,
    [LastUpdatedBy]   NVARCHAR (MAX)  NULL,
    [IsDeleted]       BIT             NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]),
    CONSTRAINT [FK_Products_Brands_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([Id]),
    CONSTRAINT [FK_Products_UnitsOfMeasure_UnitOfMeasureId] FOREIGN KEY ([UnitOfMeasureId]) REFERENCES [dbo].[UnitsOfMeasure] ([Id])
);
GO

CREATE TABLE [dbo].[StoreSettings] (
    [Id]                  INT             IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (100)  NOT NULL,
    [CUIT]                NVARCHAR (25)   NULL,
    [Address]             NVARCHAR (150)  NULL,
    [Phone]               NVARCHAR (30)   NULL,
    [Email]               NVARCHAR (100)  NULL,
    [Logo]                VARBINARY (MAX) NULL,
    [TicketFormat]        NVARCHAR (20)   NOT NULL,
    [TicketFooterMessage] NVARCHAR (250)  NULL,
    [ShowLogoOnTicket]    BIT             NOT NULL,
    [ShowBarcodeOnTicket] BIT             NOT NULL,
    [AutoPrintTicket]     BIT             NOT NULL,
    [ThermalPrinterName]  NVARCHAR (MAX)  NULL,
    [PointOfSale]         INT             NOT NULL,
    [GrossIncomeNumber]   NVARCHAR (50)   NULL,
    [ActivityStartDate]   DATETIME2 (7)   NULL,
    [TaxConditionId]      INT             NULL,
    [RowVersion]          TIMESTAMP       NOT NULL,
    CONSTRAINT [PK_StoreSettings] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StoreSettings_TaxConditions_TaxConditionId] FOREIGN KEY ([TaxConditionId]) REFERENCES [dbo].[TaxConditions] ([Id])
);
GO

CREATE TABLE [dbo].[Promotions] (
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (100)  NOT NULL,
    [Description]        NVARCHAR (250)  NULL,
    [PromotionType]      INT             NOT NULL,
    [DiscountPercentage] DECIMAL (18, 2) NULL,
    [RequiredQuantity]   INT             NULL,
    [PayQuantity]        INT             NULL,
    [ProductId]          INT             NULL,
    [CategoryId]         INT             NULL,
    [StartDate]          DATETIME2 (7)   NOT NULL,
    [EndDate]            DATETIME2 (7)   NOT NULL,
    [DaysOfWeek]         NVARCHAR (50)   NULL,
    [IsActive]           BIT             NOT NULL,
    [RowVersion]         TIMESTAMP       NOT NULL,
    [CreatedAt]          DATETIME2 (7)   NOT NULL,
    [CreatedBy]          NVARCHAR (MAX)  NULL,
    [LastUpdatedAt]      DATETIME2 (7)   NULL,
    [LastUpdatedBy]      NVARCHAR (MAX)  NULL,
    [IsDeleted]          BIT             NOT NULL,
    CONSTRAINT [PK_Promotions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Promotions_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]),
    CONSTRAINT [FK_Promotions_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id])
);
GO

CREATE TABLE [dbo].[StockMovements] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [ProductId]    INT            NOT NULL,
    [UserId]       INT            NOT NULL,
    [Quantity]     INT            NOT NULL,
    [MovementType] NVARCHAR (30)  NOT NULL,
    [Remarks]      NVARCHAR (250) NOT NULL,
    [CreatedAt]    DATETIME2 (7)  NOT NULL,
    [CreatedBy]    NVARCHAR (50)  NOT NULL,
    [RowVersion]   TIMESTAMP      NOT NULL,
    CONSTRAINT [PK_StockMovements] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StockMovements_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]),
    CONSTRAINT [FK_StockMovements_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);
GO

-- =========================================================================
-- 3. TABLAS DE OPERACIONES, TURNOS, VENTAS Y COMPRAS
-- =========================================================================

CREATE TABLE [dbo].[CashShifts] (
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [UserId]             INT             NOT NULL,
    [CashRegisterId]     INT             NOT NULL,
    [OpeningDate]        DATETIME2 (7)   NOT NULL,
    [ClosingDate]        DATETIME2 (7)   NULL,
    [InitialCash]        DECIMAL (18, 2) NOT NULL,
    [RealCash]           DECIMAL (18, 2) NULL,
    [ExpectedCash]       DECIMAL (18, 2) NULL,
    [Difference]         DECIMAL (18, 2) NULL,
    [TotalCashSales]     DECIMAL (18, 2) NOT NULL,
    [TotalDebitSales]    DECIMAL (18, 2) NOT NULL,
    [TotalCreditSales]   DECIMAL (18, 2) NOT NULL,
    [TotalTransferSales] DECIMAL (18, 2) NOT NULL,
    [TotalQrSales]       DECIMAL (18, 2) NOT NULL,
    [TotalManualCashIn]  DECIMAL (18, 2) NOT NULL,
    [TotalManualCashOut] DECIMAL (18, 2) NOT NULL,
    [Status]             NVARCHAR (20)   NOT NULL,
    [ClosingNotes]       NVARCHAR (250)  NULL,
    [RowVersion]         TIMESTAMP       NOT NULL,
    CONSTRAINT [PK_CashShifts] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CashShifts_CashRegisters_CashRegisterId] FOREIGN KEY ([CashRegisterId]) REFERENCES [dbo].[CashRegisters] ([Id]),
    CONSTRAINT [FK_CashShifts_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);
GO

CREATE TABLE [dbo].[CashMovements] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [CashShiftId]  INT             NOT NULL,
    [UserId]       INT             NOT NULL,
    [MovementType] INT             NOT NULL,
    [Amount]       DECIMAL (18, 2) NOT NULL,
    [Description]  NVARCHAR (200)  NOT NULL,
    [CreatedAt]    DATETIME2 (7)   NOT NULL,
    [RowVersion]   TIMESTAMP       NOT NULL,
    CONSTRAINT [PK_CashMovements] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CashMovements_CashShifts_CashShiftId] FOREIGN KEY ([CashShiftId]) REFERENCES [dbo].[CashShifts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CashMovements_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);
GO

CREATE TABLE [dbo].[Sales] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [UserId]            INT             NOT NULL,
    [CustomerId]        INT             NULL,
    [DocumentNumber]    NVARCHAR (50)   NOT NULL,
    [SubTotal]          DECIMAL (18, 2) NOT NULL,
    [DiscountAmount]    DECIMAL (18, 2) NOT NULL,
    [TotalAmount]       DECIMAL (18, 2) NOT NULL,
    [PaymentReceived]   DECIMAL (18, 2) NOT NULL,
    [PaymentChange]     DECIMAL (18, 2) NOT NULL,
    [PaymentMethodId]   INT             NOT NULL,
    [CashShiftId]       INT             NULL,
    [CashRegisterId]    INT             NULL,
    [PointOfSale]       INT             NOT NULL,
    [Cae]               NVARCHAR (20)   NULL,
    [CaeExpirationDate] DATETIME2 (7)   NULL,
    [AfipQrUrl]         NVARCHAR (500)  NULL,
    [FiscalStatus]      NVARCHAR (50)   NULL,
    [CreatedAt]         DATETIME2 (7)   NOT NULL,
    [DocumentTypeId]    INT             NOT NULL,
    [RowVersion]        TIMESTAMP       NOT NULL,
    CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Sales_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_Sales_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id]),
    CONSTRAINT [FK_Sales_DocumentTypes_DocumentTypeId] FOREIGN KEY ([DocumentTypeId]) REFERENCES [dbo].[DocumentTypes] ([Id]),
    CONSTRAINT [FK_Sales_PaymentMethods_PaymentMethodId] FOREIGN KEY ([PaymentMethodId]) REFERENCES [dbo].[PaymentMethods] ([Id]),
    CONSTRAINT [FK_Sales_CashShifts_CashShiftId] FOREIGN KEY ([CashShiftId]) REFERENCES [dbo].[CashShifts] ([Id]),
    CONSTRAINT [FK_Sales_CashRegisters_CashRegisterId] FOREIGN KEY ([CashRegisterId]) REFERENCES [dbo].[CashRegisters] ([Id])
);
GO

CREATE TABLE [dbo].[SaleItems] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [SaleId]         INT             NOT NULL,
    [ProductId]      INT             NOT NULL,
    [Quantity]       INT             NOT NULL,
    [UnitPrice]      DECIMAL (18, 4) NOT NULL,
    [DiscountAmount] DECIMAL (18, 2) NOT NULL,
    [CostPrice]      DECIMAL (18, 4) NOT NULL,
    [SubTotal]       DECIMAL (18, 2) NOT NULL,
    [RowVersion]     TIMESTAMP       NOT NULL,
    CONSTRAINT [PK_SaleItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SaleItems_Sales_SaleId] FOREIGN KEY ([SaleId]) REFERENCES [dbo].[Sales] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_SaleItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
);
GO

CREATE TABLE [dbo].[Purchases] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [UserId]          INT             NOT NULL,
    [SupplierId]      INT             NOT NULL,
    [DocumentTypeId]  INT             NOT NULL,
    [DocumentNumber]  NVARCHAR (50)   NOT NULL,
    [PaymentMethodId] INT             NOT NULL,
    [SubTotal]        DECIMAL (18, 2) NOT NULL,
    [TaxAmount]       DECIMAL (18, 2) NOT NULL,
    [TotalAmount]     DECIMAL (18, 2) NOT NULL,
    [Status]          NVARCHAR (20)   NOT NULL,
    [Remarks]         NVARCHAR (250)  NULL,
    [CreatedAt]       DATETIME2 (7)   NOT NULL,
    [RowVersion]      TIMESTAMP       NOT NULL,
    CONSTRAINT [PK_Purchases] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Purchases_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [FK_Purchases_Suppliers_SupplierId] FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Suppliers] ([Id]),
    CONSTRAINT [FK_Purchases_DocumentTypes_DocumentTypeId] FOREIGN KEY ([DocumentTypeId]) REFERENCES [dbo].[DocumentTypes] ([Id]),
    CONSTRAINT [FK_Purchases_PaymentMethods_PaymentMethodId] FOREIGN KEY ([PaymentMethodId]) REFERENCES [dbo].[PaymentMethods] ([Id])
);
GO

CREATE TABLE [dbo].[PurchaseItems] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [PurchaseId] INT             NOT NULL,
    [ProductId]  INT             NOT NULL,
    [Quantity]   INT             NOT NULL,
    [BuyPrice]   DECIMAL (18, 4) NOT NULL,
    [SubTotal]   DECIMAL (18, 2) NOT NULL,
    [RowVersion] TIMESTAMP       NOT NULL,
    CONSTRAINT [PK_PurchaseItems] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PurchaseItems_Purchases_PurchaseId] FOREIGN KEY ([PurchaseId]) REFERENCES [dbo].[Purchases] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PurchaseItems_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id])
);
GO