USE [master]
GO
/****** Object:  Database [SalesOrderManagement]    Script Date: 3/5/2023 11:35:53 AM ******/
CREATE DATABASE [SalesOrderManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SalesOrderManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER2022\MSSQL\DATA\SalesOrderManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SalesOrderManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER2022\MSSQL\DATA\SalesOrderManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SalesOrderManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SalesOrderManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SalesOrderManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SalesOrderManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SalesOrderManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SalesOrderManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SalesOrderManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [SalesOrderManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SalesOrderManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SalesOrderManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SalesOrderManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SalesOrderManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SalesOrderManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SalesOrderManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SalesOrderManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SalesOrderManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SalesOrderManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SalesOrderManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SalesOrderManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SalesOrderManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SalesOrderManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SalesOrderManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SalesOrderManagement] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [SalesOrderManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SalesOrderManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [SalesOrderManagement] SET  MULTI_USER 
GO
ALTER DATABASE [SalesOrderManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SalesOrderManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SalesOrderManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SalesOrderManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SalesOrderManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SalesOrderManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SalesOrderManagement', N'ON'
GO
ALTER DATABASE [SalesOrderManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [SalesOrderManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SalesOrderManagement]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 3/5/2023 11:35:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Building]    Script Date: 3/5/2023 11:35:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Building](
	[BuildingId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[StateId] [int] NOT NULL,
 CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED 
(
	[BuildingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dimension]    Script Date: 3/5/2023 11:35:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dimension](
	[DimensionId] [int] IDENTITY(1,1) NOT NULL,
	[Width] [nvarchar](100) NOT NULL,
	[Height] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Dimension] PRIMARY KEY CLUSTERED 
(
	[DimensionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 3/5/2023 11:35:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductAttribute]    Script Date: 3/5/2023 11:35:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductAttribute](
	[ProductAttributeId] [int] IDENTITY(1,1) NOT NULL,
	[ProductAttributeType] [nvarchar](max) NOT NULL,
	[DimensionId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_ProductAttribute] PRIMARY KEY CLUSTERED 
(
	[ProductAttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesOrder]    Script Date: 3/5/2023 11:35:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrder](
	[SalesOrderId] [bigint] IDENTITY(1,1) NOT NULL,
	[BuildingsId] [int] NOT NULL,
	[StatesId] [int] NOT NULL,
	[Code] [nvarchar](8) NOT NULL,
 CONSTRAINT [PK_SalesOrder] PRIMARY KEY CLUSTERED 
(
	[SalesOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesOrderDetail]    Script Date: 3/5/2023 11:35:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesOrderDetail](
	[SalesOrderDetailId] [bigint] IDENTITY(1,1) NOT NULL,
	[SalesOrderId] [bigint] NOT NULL,
	[ProductAttributeId] [int] NOT NULL,
	[QuantityOfWindows] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_SalesOrderDetail] PRIMARY KEY CLUSTERED 
(
	[SalesOrderDetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 3/5/2023 11:35:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230228083807_initial', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230304074438_c', N'7.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230304132546_codeColumnAdd', N'7.0.3')
GO
SET IDENTITY_INSERT [dbo].[Building] ON 

INSERT [dbo].[Building] ([BuildingId], [Name], [StateId]) VALUES (1, N'New York Building 1', 1)
INSERT [dbo].[Building] ([BuildingId], [Name], [StateId]) VALUES (2, N'California Hotel AJK', 2)
SET IDENTITY_INSERT [dbo].[Building] OFF
GO
SET IDENTITY_INSERT [dbo].[Dimension] ON 

INSERT [dbo].[Dimension] ([DimensionId], [Width], [Height]) VALUES (1, N'1200', N'1850')
INSERT [dbo].[Dimension] ([DimensionId], [Width], [Height]) VALUES (2, N'800', N'1850')
INSERT [dbo].[Dimension] ([DimensionId], [Width], [Height]) VALUES (3, N'700', N'1850')
INSERT [dbo].[Dimension] ([DimensionId], [Width], [Height]) VALUES (4, N'1500', N'2000')
INSERT [dbo].[Dimension] ([DimensionId], [Width], [Height]) VALUES (5, N'1400', N'2200')
INSERT [dbo].[Dimension] ([DimensionId], [Width], [Height]) VALUES (6, N'600', N'2200')
INSERT [dbo].[Dimension] ([DimensionId], [Width], [Height]) VALUES (7, N'1500', N'2000')
SET IDENTITY_INSERT [dbo].[Dimension] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (1, N'A51')
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (2, N'C Zone 5')
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (3, N'GLB')
INSERT [dbo].[Product] ([ProductId], [ProductName]) VALUES (4, N'OHF')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductAttribute] ON 

INSERT [dbo].[ProductAttribute] ([ProductAttributeId], [ProductAttributeType], [DimensionId], [ProductId]) VALUES (1, N'Doors', 1, 1)
INSERT [dbo].[ProductAttribute] ([ProductAttributeId], [ProductAttributeType], [DimensionId], [ProductId]) VALUES (2, N'Window', 2, 1)
INSERT [dbo].[ProductAttribute] ([ProductAttributeId], [ProductAttributeType], [DimensionId], [ProductId]) VALUES (3, N'Window', 3, 1)
INSERT [dbo].[ProductAttribute] ([ProductAttributeId], [ProductAttributeType], [DimensionId], [ProductId]) VALUES (4, N'Window', 4, 2)
INSERT [dbo].[ProductAttribute] ([ProductAttributeId], [ProductAttributeType], [DimensionId], [ProductId]) VALUES (5, N'Doors', 5, 3)
INSERT [dbo].[ProductAttribute] ([ProductAttributeId], [ProductAttributeType], [DimensionId], [ProductId]) VALUES (6, N'Window', 6, 3)
INSERT [dbo].[ProductAttribute] ([ProductAttributeId], [ProductAttributeType], [DimensionId], [ProductId]) VALUES (7, N'Window', 7, 4)
SET IDENTITY_INSERT [dbo].[ProductAttribute] OFF
GO
SET IDENTITY_INSERT [dbo].[SalesOrder] ON 

INSERT [dbo].[SalesOrder] ([SalesOrderId], [BuildingsId], [StatesId], [Code]) VALUES (1, 1, 1, N'SO-38152')
INSERT [dbo].[SalesOrder] ([SalesOrderId], [BuildingsId], [StatesId], [Code]) VALUES (2, 2, 2, N'SO-38153')
SET IDENTITY_INSERT [dbo].[SalesOrder] OFF
GO
SET IDENTITY_INSERT [dbo].[SalesOrderDetail] ON 

INSERT [dbo].[SalesOrderDetail] ([SalesOrderDetailId], [SalesOrderId], [ProductAttributeId], [QuantityOfWindows]) VALUES (1, 1, 1, CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[SalesOrderDetail] ([SalesOrderDetailId], [SalesOrderId], [ProductAttributeId], [QuantityOfWindows]) VALUES (2, 1, 2, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[SalesOrderDetail] ([SalesOrderDetailId], [SalesOrderId], [ProductAttributeId], [QuantityOfWindows]) VALUES (3, 1, 3, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[SalesOrderDetail] ([SalesOrderDetailId], [SalesOrderId], [ProductAttributeId], [QuantityOfWindows]) VALUES (4, 1, 4, CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[SalesOrderDetail] ([SalesOrderDetailId], [SalesOrderId], [ProductAttributeId], [QuantityOfWindows]) VALUES (5, 2, 5, CAST(1.00 AS Decimal(18, 2)))
INSERT [dbo].[SalesOrderDetail] ([SalesOrderDetailId], [SalesOrderId], [ProductAttributeId], [QuantityOfWindows]) VALUES (6, 2, 6, CAST(2.00 AS Decimal(18, 2)))
INSERT [dbo].[SalesOrderDetail] ([SalesOrderDetailId], [SalesOrderId], [ProductAttributeId], [QuantityOfWindows]) VALUES (7, 2, 7, CAST(10.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[SalesOrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[State] ON 

INSERT [dbo].[State] ([StateId], [Name]) VALUES (1, N'NY')
INSERT [dbo].[State] ([StateId], [Name]) VALUES (2, N'CA')
SET IDENTITY_INSERT [dbo].[State] OFF
GO
/****** Object:  Index [IX_Building_StateId]    Script Date: 3/5/2023 11:35:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_Building_StateId] ON [dbo].[Building]
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductAttribute_DimensionId]    Script Date: 3/5/2023 11:35:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProductAttribute_DimensionId] ON [dbo].[ProductAttribute]
(
	[DimensionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductAttribute_ProductId]    Script Date: 3/5/2023 11:35:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProductAttribute_ProductId] ON [dbo].[ProductAttribute]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SalesOrder_BuildingsId]    Script Date: 3/5/2023 11:35:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_SalesOrder_BuildingsId] ON [dbo].[SalesOrder]
(
	[BuildingsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SalesOrder_StatesId]    Script Date: 3/5/2023 11:35:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_SalesOrder_StatesId] ON [dbo].[SalesOrder]
(
	[StatesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SalesOrderDetail_ProductAttributeId]    Script Date: 3/5/2023 11:35:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_SalesOrderDetail_ProductAttributeId] ON [dbo].[SalesOrderDetail]
(
	[ProductAttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SalesOrderDetail_SalesOrderId]    Script Date: 3/5/2023 11:35:53 AM ******/
CREATE NONCLUSTERED INDEX [IX_SalesOrderDetail_SalesOrderId] ON [dbo].[SalesOrderDetail]
(
	[SalesOrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SalesOrder] ADD  DEFAULT (N'') FOR [Code]
GO
ALTER TABLE [dbo].[Building]  WITH CHECK ADD  CONSTRAINT [FK_Building_State_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([StateId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Building] CHECK CONSTRAINT [FK_Building_State_StateId]
GO
ALTER TABLE [dbo].[ProductAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttribute_Dimension_DimensionId] FOREIGN KEY([DimensionId])
REFERENCES [dbo].[Dimension] ([DimensionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductAttribute] CHECK CONSTRAINT [FK_ProductAttribute_Dimension_DimensionId]
GO
ALTER TABLE [dbo].[ProductAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ProductAttribute_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductAttribute] CHECK CONSTRAINT [FK_ProductAttribute_Product_ProductId]
GO
ALTER TABLE [dbo].[SalesOrder]  WITH CHECK ADD  CONSTRAINT [FK_SalesOrder_Building_BuildingsId] FOREIGN KEY([BuildingsId])
REFERENCES [dbo].[Building] ([BuildingId])
GO
ALTER TABLE [dbo].[SalesOrder] CHECK CONSTRAINT [FK_SalesOrder_Building_BuildingsId]
GO
ALTER TABLE [dbo].[SalesOrder]  WITH CHECK ADD  CONSTRAINT [FK_SalesOrder_State_StatesId] FOREIGN KEY([StatesId])
REFERENCES [dbo].[State] ([StateId])
GO
ALTER TABLE [dbo].[SalesOrder] CHECK CONSTRAINT [FK_SalesOrder_State_StatesId]
GO
ALTER TABLE [dbo].[SalesOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_SalesOrderDetail_ProductAttribute_ProductAttributeId] FOREIGN KEY([ProductAttributeId])
REFERENCES [dbo].[ProductAttribute] ([ProductAttributeId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SalesOrderDetail] CHECK CONSTRAINT [FK_SalesOrderDetail_ProductAttribute_ProductAttributeId]
GO
ALTER TABLE [dbo].[SalesOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_SalesOrderDetail_SalesOrder_SalesOrderId] FOREIGN KEY([SalesOrderId])
REFERENCES [dbo].[SalesOrder] ([SalesOrderId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SalesOrderDetail] CHECK CONSTRAINT [FK_SalesOrderDetail_SalesOrder_SalesOrderId]
GO
USE [master]
GO
ALTER DATABASE [SalesOrderManagement] SET  READ_WRITE 
GO
