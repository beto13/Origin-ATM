USE [master]
GO
/****** Object:  Database [OriginATM]    Script Date: 23/06/2020 11:40:43 ******/
CREATE DATABASE [OriginATM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OriginATM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\OriginATM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OriginATM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\OriginATM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [OriginATM] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OriginATM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OriginATM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OriginATM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OriginATM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OriginATM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OriginATM] SET ARITHABORT OFF 
GO
ALTER DATABASE [OriginATM] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [OriginATM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OriginATM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OriginATM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OriginATM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OriginATM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OriginATM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OriginATM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OriginATM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OriginATM] SET  ENABLE_BROKER 
GO
ALTER DATABASE [OriginATM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OriginATM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OriginATM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OriginATM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OriginATM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OriginATM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OriginATM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OriginATM] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OriginATM] SET  MULTI_USER 
GO
ALTER DATABASE [OriginATM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OriginATM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OriginATM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OriginATM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OriginATM] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OriginATM] SET QUERY_STORE = OFF
GO
USE [OriginATM]
GO
/****** Object:  Table [dbo].[Operacion]    Script Date: 23/06/2020 11:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Operacion](
	[IdOperacion] [int] IDENTITY(1,1) NOT NULL,
	[IdTarjeta] [int] NOT NULL,
	[TipoOperacion] [varchar](20) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[Fecha] [datetime] NOT NULL,
	[Monto] [decimal](12, 2) NOT NULL,
 CONSTRAINT [PK_Operacion] PRIMARY KEY CLUSTERED 
(
	[IdOperacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjeta]    Script Date: 23/06/2020 11:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjeta](
	[IdTarjeta] [int] IDENTITY(1,1) NOT NULL,
	[NumeroTarjeta] [varchar](20) NOT NULL,
	[Pin] [varchar](5) NOT NULL,
	[Intentos] [int] NOT NULL,
	[Bloquedo] [bit] NOT NULL,
	[FechaVencimiento] [date] NOT NULL,
	[Saldo] [decimal](12, 2) NULL,
 CONSTRAINT [PK_Tarjeta] PRIMARY KEY CLUSTERED 
(
	[IdTarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Operacion] ON 

INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [TipoOperacion], [Descripcion], [Fecha], [Monto]) VALUES (1, 1, N'Balance', NULL, CAST(N'2020-06-22T12:42:52.673' AS DateTime), CAST(20000.00 AS Decimal(12, 2)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [TipoOperacion], [Descripcion], [Fecha], [Monto]) VALUES (2, 1, N'Retiro', NULL, CAST(N'2020-06-22T12:43:13.520' AS DateTime), CAST(500.00 AS Decimal(12, 2)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [TipoOperacion], [Descripcion], [Fecha], [Monto]) VALUES (3, 1, N'Balance', NULL, CAST(N'2020-06-22T12:43:44.493' AS DateTime), CAST(19500.00 AS Decimal(12, 2)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [TipoOperacion], [Descripcion], [Fecha], [Monto]) VALUES (4, 2, N'Balance', NULL, CAST(N'2020-06-22T12:44:16.083' AS DateTime), CAST(35000.00 AS Decimal(12, 2)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [TipoOperacion], [Descripcion], [Fecha], [Monto]) VALUES (5, 2, N'Retiro', NULL, CAST(N'2020-06-22T12:45:02.613' AS DateTime), CAST(20000.00 AS Decimal(12, 2)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [TipoOperacion], [Descripcion], [Fecha], [Monto]) VALUES (6, 2, N'Balance', NULL, CAST(N'2020-06-22T12:45:43.737' AS DateTime), CAST(15000.00 AS Decimal(12, 2)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [TipoOperacion], [Descripcion], [Fecha], [Monto]) VALUES (7, 2, N'Balance', NULL, CAST(N'2020-06-22T12:50:11.840' AS DateTime), CAST(15000.00 AS Decimal(12, 2)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [TipoOperacion], [Descripcion], [Fecha], [Monto]) VALUES (8, 1, N'Balance', NULL, CAST(N'2020-06-22T21:20:05.620' AS DateTime), CAST(19500.00 AS Decimal(12, 2)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [TipoOperacion], [Descripcion], [Fecha], [Monto]) VALUES (9, 1, N'Retiro', NULL, CAST(N'2020-06-22T21:20:38.080' AS DateTime), CAST(2000.00 AS Decimal(12, 2)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [TipoOperacion], [Descripcion], [Fecha], [Monto]) VALUES (10, 2, N'Balance', NULL, CAST(N'2020-06-23T09:34:07.190' AS DateTime), CAST(15000.00 AS Decimal(12, 2)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [TipoOperacion], [Descripcion], [Fecha], [Monto]) VALUES (11, 2, N'Retiro', NULL, CAST(N'2020-06-23T09:38:41.107' AS DateTime), CAST(1000.00 AS Decimal(12, 2)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [TipoOperacion], [Descripcion], [Fecha], [Monto]) VALUES (12, 2, N'Balance', NULL, CAST(N'2020-06-23T09:44:58.687' AS DateTime), CAST(14000.00 AS Decimal(12, 2)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [TipoOperacion], [Descripcion], [Fecha], [Monto]) VALUES (13, 2, N'Retiro', NULL, CAST(N'2020-06-23T09:45:22.303' AS DateTime), CAST(500.00 AS Decimal(12, 2)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [TipoOperacion], [Descripcion], [Fecha], [Monto]) VALUES (14, 2, N'Balance', NULL, CAST(N'2020-06-23T09:50:05.127' AS DateTime), CAST(13500.00 AS Decimal(12, 2)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [TipoOperacion], [Descripcion], [Fecha], [Monto]) VALUES (15, 2, N'Retiro', NULL, CAST(N'2020-06-23T09:50:27.650' AS DateTime), CAST(5000.00 AS Decimal(12, 2)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [TipoOperacion], [Descripcion], [Fecha], [Monto]) VALUES (16, 1, N'Balance', NULL, CAST(N'2020-06-23T10:49:48.157' AS DateTime), CAST(17500.00 AS Decimal(12, 2)))
INSERT [dbo].[Operacion] ([IdOperacion], [IdTarjeta], [TipoOperacion], [Descripcion], [Fecha], [Monto]) VALUES (17, 1, N'Retiro', NULL, CAST(N'2020-06-23T10:50:37.527' AS DateTime), CAST(2000.00 AS Decimal(12, 2)))
SET IDENTITY_INSERT [dbo].[Operacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Tarjeta] ON 

INSERT [dbo].[Tarjeta] ([IdTarjeta], [NumeroTarjeta], [Pin], [Intentos], [Bloquedo], [FechaVencimiento], [Saldo]) VALUES (1, N'1111111111111111', N'1234', 0, 0, CAST(N'2025-12-31' AS Date), CAST(15500.00 AS Decimal(12, 2)))
INSERT [dbo].[Tarjeta] ([IdTarjeta], [NumeroTarjeta], [Pin], [Intentos], [Bloquedo], [FechaVencimiento], [Saldo]) VALUES (2, N'2222222222222222', N'6789', 1, 0, CAST(N'2024-01-01' AS Date), CAST(8500.00 AS Decimal(12, 2)))
INSERT [dbo].[Tarjeta] ([IdTarjeta], [NumeroTarjeta], [Pin], [Intentos], [Bloquedo], [FechaVencimiento], [Saldo]) VALUES (3, N'3333333333333333', N'0000', 0, 0, CAST(N'2025-06-06' AS Date), CAST(15000.00 AS Decimal(12, 2)))
SET IDENTITY_INSERT [dbo].[Tarjeta] OFF
GO
ALTER TABLE [dbo].[Tarjeta] ADD  CONSTRAINT [DF_Tarjeta_Intentos]  DEFAULT ((0)) FOR [Intentos]
GO
ALTER TABLE [dbo].[Tarjeta] ADD  CONSTRAINT [DF_Tarjeta_Bloquedo]  DEFAULT ((0)) FOR [Bloquedo]
GO
ALTER TABLE [dbo].[Operacion]  WITH CHECK ADD  CONSTRAINT [FK_Operacion_Tarjeta] FOREIGN KEY([IdTarjeta])
REFERENCES [dbo].[Tarjeta] ([IdTarjeta])
GO
ALTER TABLE [dbo].[Operacion] CHECK CONSTRAINT [FK_Operacion_Tarjeta]
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarOperacion]    Script Date: 23/06/2020 11:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpConsultarOperacion]
@idOperacion AS INT
AS
BEGIN
	SELECT [IdOperacion]
		  ,[IdTarjeta]
		  ,[TipoOperacion]
		  ,[Descripcion]
		  ,[Fecha]
		  ,[Monto]
	  FROM [dbo].[Operacion]
	  WHERE [IdOperacion]=@idOperacion
END


GO
/****** Object:  StoredProcedure [dbo].[SpOperacionRegistrar]    Script Date: 23/06/2020 11:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpOperacionRegistrar]
@IdTarjeta INT,
@TipoOperacion VARCHAR(20),
@Fecha DATETIME,
@Monto DECIMAL(12,2)
AS		
BEGIN
INSERT INTO [dbo].[Operacion]
           ([IdTarjeta]
           ,[TipoOperacion]
           ,[Fecha]
           ,[Monto])
     VALUES (
		@IdTarjeta,
		@TipoOperacion,
		@Fecha,
		@Monto)

	SELECT @@IDENTITY
     
END


GO
/****** Object:  StoredProcedure [dbo].[SpTarjetaBuscar]    Script Date: 23/06/2020 11:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpTarjetaBuscar]
@idTarjeta INT
AS
BEGIN
	SELECT [IdTarjeta]
      ,[NumeroTarjeta]
      ,[Pin]
      ,[Intentos]
      ,[Bloquedo]
      ,[FechaVencimiento]
      ,[Saldo]
  FROM [dbo].[Tarjeta]
  WHERE [IdTarjeta]=@idTarjeta
END
GO
/****** Object:  StoredProcedure [dbo].[SpTarjetaEditar]    Script Date: 23/06/2020 11:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SpTarjetaEditar]
@operacion VARCHAR (20),
@parametro VARCHAR (20),
@IdTarjeta INT
AS
BEGIN
	IF @operacion='INTENTOS'   
		UPDATE	[Tarjeta]
		SET		[Intentos]=[Intentos] + CAST(@parametro AS INT)
		FROM	[dbo].[Tarjeta]
		WHERE	[IdTarjeta]=@IdTarjeta

	IF @operacion='BLOQUEAR'   
		UPDATE	[Tarjeta]
		SET		[Bloquedo]= 1,
				[Intentos]=[Intentos] + CAST(@parametro AS INT)
		FROM	[dbo].[Tarjeta]
		WHERE	[IdTarjeta]=@IdTarjeta
END



GO
/****** Object:  StoredProcedure [dbo].[SpTarjetaRetirar]    Script Date: 23/06/2020 11:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpTarjetaRetirar]
@IdTarjeta INT,
@monto DECIMAL(12,2)
AS
BEGIN
	UPDATE	[Tarjeta]
	SET		[Saldo]=[Saldo]-@monto
	FROM	[dbo].[Tarjeta]
	WHERE	[IdTarjeta]=@IdTarjeta
END
GO
/****** Object:  StoredProcedure [dbo].[SpTarjetaValidar]    Script Date: 23/06/2020 11:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpTarjetaValidar]
@numeroTarjeta VARCHAR(20)
AS
BEGIN
	SELECT [IdTarjeta]
      ,[NumeroTarjeta]
      ,[Pin]
      ,[Intentos]
      ,[Bloquedo]
      ,[FechaVencimiento]
      ,[Saldo]
  FROM [dbo].[Tarjeta]
  WHERE [NumeroTarjeta]=@NumeroTarjeta
  AND [Bloquedo]=0
END
GO
/****** Object:  StoredProcedure [dbo].[SpValidarPin]    Script Date: 23/06/2020 11:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpValidarPin]
@numeroTarjeta VARCHAR(20),
@pin VARCHAR(4)

AS
BEGIN

	SELECT	 [IdTarjeta]
			,[NumeroTarjeta]
			,[Pin]
			,[Intentos]
			,[Bloquedo]
			,[FechaVencimiento]
			,[Saldo]
	FROM	[dbo].[Tarjeta]
	WHERE	[NumeroTarjeta]=@numeroTarjeta
			AND [Pin]=@pin
			AND [Bloquedo]=0
END

GO
USE [master]
GO
ALTER DATABASE [OriginATM] SET  READ_WRITE 
GO
