USE [master]
GO
/****** Object:  Database [DBLaMejorCocina]    Script Date: 26/10/2020 9:58:08 ******/
CREATE DATABASE [DBLaMejorCocina]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBLaMejorCocina', FILENAME = N'/var/opt/mssql/data/DBLaMejorCocina.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBLaMejorCocina_log', FILENAME = N'/var/opt/mssql/data/DBLaMejorCocina_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DBLaMejorCocina] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBLaMejorCocina].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBLaMejorCocina] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBLaMejorCocina] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBLaMejorCocina] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBLaMejorCocina] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBLaMejorCocina] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET RECOVERY FULL 
GO
ALTER DATABASE [DBLaMejorCocina] SET  MULTI_USER 
GO
ALTER DATABASE [DBLaMejorCocina] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBLaMejorCocina] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBLaMejorCocina] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBLaMejorCocina] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBLaMejorCocina] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBLaMejorCocina', N'ON'
GO
ALTER DATABASE [DBLaMejorCocina] SET QUERY_STORE = OFF
GO
USE [DBLaMejorCocina]
GO
/****** Object:  Table [dbo].[Camarero]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Camarero](
	[IdCamarero] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](120) NULL,
	[Apellido1] [nvarchar](80) NULL,
	[Apellido2] [nvarchar](80) NULL,
 CONSTRAINT [PK_Camarero] PRIMARY KEY CLUSTERED 
(
	[IdCamarero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](150) NULL,
	[Apellido1] [nvarchar](80) NULL,
	[Apellido2] [nvarchar](80) NULL,
	[Observaciones] [nvarchar](250) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cocinero]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cocinero](
	[IdCocinero] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](120) NULL,
	[Apellido1] [nvarchar](80) NULL,
	[Apellido2] [nvarchar](80) NULL,
 CONSTRAINT [PK_Cocinero] PRIMARY KEY CLUSTERED 
(
	[IdCocinero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleFactura]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleFactura](
	[IdDetalleFactura] [int] IDENTITY(1,1) NOT NULL,
	[IdFactura] [int] NULL,
	[IdCocinero] [int] NULL,
	[Plato] [int] NULL,
	[Importe] [decimal](16, 2) NULL,
 CONSTRAINT [PK_DetalleFactura] PRIMARY KEY CLUSTERED 
(
	[IdDetalleFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[IdFactura] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[IdCamarero] [int] NULL,
	[IdMesa] [int] NULL,
	[FechaFactura] [datetime] NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mesa]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mesa](
	[IdMesa] [int] IDENTITY(1,1) NOT NULL,
	[NumMaxComensa] [int] NOT NULL,
	[Ubicacion] [nvarchar](120) NOT NULL,
 CONSTRAINT [PK_Mesa] PRIMARY KEY CLUSTERED 
(
	[IdMesa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](50) NULL,
	[Clave] [nvarchar](max) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Cocinero] FOREIGN KEY([IdCocinero])
REFERENCES [dbo].[Cocinero] ([IdCocinero])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Cocinero]
GO
ALTER TABLE [dbo].[DetalleFactura]  WITH CHECK ADD  CONSTRAINT [FK_DetalleFactura_Factura] FOREIGN KEY([IdFactura])
REFERENCES [dbo].[Factura] ([IdFactura])
GO
ALTER TABLE [dbo].[DetalleFactura] CHECK CONSTRAINT [FK_DetalleFactura_Factura]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Camarero] FOREIGN KEY([IdCamarero])
REFERENCES [dbo].[Camarero] ([IdCamarero])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Camarero]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Cliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Cliente]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Mesa] FOREIGN KEY([IdMesa])
REFERENCES [dbo].[Mesa] ([IdMesa])
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Mesa]
GO
/****** Object:  StoredProcedure [dbo].[uspCamareroDelete]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspCamareroDelete]
	@IdCamarero INT
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY						
		DELETE FROM [dbo].[Camarero] 
		WHERE IdCamarero = @IdCamarero

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspCamareroInsert]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspCamareroInsert]
	@Nombre NVARCHAR(150)
	,@Apellido1 NVARCHAR(80)
	,@Apellido2 NVARCHAR(80)	
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY						
		INSERT INTO [dbo].[Camarero] (			
			Nombre
			,Apellido1
			,Apellido2
		) VALUES (
			@Nombre
			,@Apellido1
			,@Apellido2
		)		

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspCamareroUpdate]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspCamareroUpdate]
	@IdCamarero INT
	,@Nombre NVARCHAR(150)
	,@Apellido1 NVARCHAR(80)
	,@Apellido2 NVARCHAR(80)
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY						
		UPDATE [dbo].[Camarero] SET
			Nombre = @Nombre
			,Apellido1 = @Apellido1
			,Apellido2 = @Apellido2
		WHERE IdCamarero = @IdCamarero

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspClienteDelete]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspClienteDelete]
	@IdCliente Int
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY

		DELETE FROM [dbo].[Cliente]
		WHERE IdCliente = @IdCliente
		
COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspClienteInsert]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspClienteInsert]
	@Nombre NVARCHAR(150)
	,@Apellido1 NVARCHAR(80)
	,@Apellido2 NVARCHAR(80)
	,@Observaciones NVARCHAR(250)
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY						
		INSERT INTO [dbo].[Cliente] (			
			Nombre
			,Apellido1
			,Apellido2
			,Observaciones
		) VALUES (
			@Nombre
			,@Apellido1
			,@Apellido2
			,@Observaciones
		)		
		

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspClienteUpdate]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspClienteUpdate]
	@IdCliente INT
	,@Nombre NVARCHAR(150)
	,@Apellido1 NVARCHAR(80)
	,@Apellido2 NVARCHAR(80)
	,@Observaciones NVARCHAR(250)
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY						
		UPDATE [dbo].[Cliente] SET Nombre = @Nombre
			,Apellido1 = @Apellido1
			,Apellido2 = @Apellido2
			,Observaciones = @Observaciones
		WHERE IdCliente = @IdCliente

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspCocineroDelete]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspCocineroDelete]
	@IdCocinero INT
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY						
		DELETE FROM [dbo].[Cocinero] 
		WHERE IdCocinero = @IdCocinero

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspCocineroInsert]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspCocineroInsert]
	@Nombre NVARCHAR(150)
	,@Apellido1 NVARCHAR(80)
	,@Apellido2 NVARCHAR(80)	
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY						
		INSERT INTO [dbo].[Cocinero] (			
			Nombre
			,Apellido1
			,Apellido2
		) VALUES (
			@Nombre
			,@Apellido1
			,@Apellido2
		)		

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspCocineroUpdate]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspCocineroUpdate]
	@IdCocinero INT
	,@Nombre NVARCHAR(150)
	,@Apellido1 NVARCHAR(80)
	,@Apellido2 NVARCHAR(80)
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY						
		UPDATE [dbo].[Cocinero] SET
			Nombre = @Nombre
			,Apellido1 = @Apellido1
			,Apellido2 = @Apellido2
		WHERE IdCocinero = @IdCocinero

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspFacturaDelete]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspFacturaDelete]
	@IdFactura INT	
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY		

		DELETE FROM [dbo].[DetalleFactura] WHERE IdFactura = @IdFactura
		DELETE FROM [dbo].[Factura] WHERE IdFactura = @IdFactura


COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspFacturaInsert]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspFacturaInsert]
	@IdCliente INT
	,@IdCamarero INT
	,@IdMesa INT
	,@Detalle NVARCHAR(MAX)
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY				
		
		DECLARE @IdFactura INT

		INSERT INTO [dbo].[Factura] (
			IdCliente
			,IdCamarero
			,IdMesa
			,FechaFactura
		) VALUES (
			@IdCliente
			,@IdCamarero
			,@IdMesa
			,getdate()
		)

		SELECT @IdFactura = IDENT_CURRENT('[dbo].[Factura]');
		
		INSERT INTO [dbo].[DetalleFactura] 
		(
			IdFactura
			,IdCocinero
			,Plato
			,Importe
		)
		SELECT @IdFactura, IdCocinero, Plato, Importe FROM OPENJSON (@Detalle)
		WITH 
		(
			[IdDetalleFactura] int,
			[IdFactura] int,
			[IdCocinero] int,
			[Plato] int,
			[Importe] decimal(16,2)

		)

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspFacturaUpdate]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspFacturaUpdate]
	@IdFactura INT
	,@IdCliente INT
	,@IdCamarero INT
	,@IdMesa INT
	,@Detalle NVARCHAR(MAX)
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY		

		UPDATE [dbo].[Factura] SET
			IdCliente = @IdCliente
			,IdCamarero = @IdCamarero
			,IdMesa = @IdMesa
		WHERE IdFactura = @IdFactura
		
		
		DELETE FROM  [dbo].[DetalleFactura]  WHERE IdFactura = @IdFactura

		INSERT INTO [dbo].[DetalleFactura] 
		(
			IdFactura
			,IdCocinero
			,Plato
			,Importe
		)
		SELECT @IdFactura, IdCocinero, Plato, Importe FROM OPENJSON (@Detalle)
		WITH 
		(
			[IdDetalleFactura] int,
			[IdFactura] int,
			[IdCocinero] int,
			[Plato] int,
			[Importe] decimal(16,2)

		)

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[UspgetCamareroByID]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetCamareroByID]
	@IdCamarero INT
AS
	SELECT TOP (1000) [IdCamarero]
		  ,[Nombre]
		  ,[Apellido1]
		  ,[Apellido2]
	FROM [DBLaMejorCocina].[dbo].[Camarero]
	WHERE IdCamarero = @IdCamarero  
GO
/****** Object:  StoredProcedure [dbo].[UspgetCamareros]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetCamareros]
AS
	SELECT TOP (1000) [IdCamarero]
		  ,[Nombre]
		  ,[Apellido1]
		  ,[Apellido2]
	  FROM [DBLaMejorCocina].[dbo].[Camarero]
GO
/****** Object:  StoredProcedure [dbo].[UspgetClienteByID]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetClienteByID]
	@IdCliente INT
AS
	SELECT [IdCliente]
		  ,[Nombre]
		  ,[Apellido1]
		  ,[Apellido2]
		  ,[Observaciones]
	  FROM [DBLaMejorCocina].[dbo].[Cliente] WHERE IdCliente = @IdCliente
GO
/****** Object:  StoredProcedure [dbo].[UspgetClientes]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetClientes]
AS
	SELECT [IdCliente]
		  ,[Nombre]
		  ,[Apellido1]
		  ,[Apellido2]
		  ,[Observaciones]
	  FROM [DBLaMejorCocina].[dbo].[Cliente]
GO
/****** Object:  StoredProcedure [dbo].[UspGetClientesMayorCompra]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspGetClientesMayorCompra]
AS
	select c.IdCliente, c.Nombre, c.Apellido1, c.Apellido2, c.Observaciones,
	sum(isnull(df.Importe, 0)) as Total
	from dbo.Cliente c
	inner join dbo.Factura f on c.IdCliente = f.IdCliente
	inner join dbo.DetalleFactura df on f.IdFactura = df.IdFactura
	group by c.IdCliente, c.Nombre, c.Apellido1, c.Apellido2, c.Observaciones
	HAVING sum(isnull(df.Importe, 0)) > 100000
GO
/****** Object:  StoredProcedure [dbo].[UspgetCocineroByID]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetCocineroByID]
	@IdCocinero INT
AS
SELECT IdCocinero
,Nombre
,Apellido1
,Apellido2 FROM [dbo].[Cocinero]
WHERE IdCocinero = @IdCocinero
GO
/****** Object:  StoredProcedure [dbo].[UspgetCocineros]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetCocineros]
AS
SELECT IdCocinero
,Nombre
,Apellido1
,Apellido2 FROM [dbo].[Cocinero]
GO
/****** Object:  StoredProcedure [dbo].[UspgetLogin]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetLogin]
	@NombreUsuario NVARCHAR(50),
	@Clave NVARCHAR(MAX)
AS
	SELECT 
	IdUsuario
	,NombreUsuario,
	Clave FROM [dbo].[Usuario] 
	WHERE NombreUsuario = @NombreUsuario AND Clave = @Clave
GO
/****** Object:  StoredProcedure [dbo].[UspgetMesaByID]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetMesaByID]
	@IdMesa INT
AS
	SELECT IdMesa
	,NumMaxComensa
	,Ubicacion FROM [dbo].[Mesa] WHERE IdMesa = @IdMesa
GO
/****** Object:  StoredProcedure [dbo].[UspgetMesas]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetMesas]
AS
	SELECT IdMesa
	,NumMaxComensa
	,Ubicacion FROM [dbo].[Mesa]
GO
/****** Object:  StoredProcedure [dbo].[UspGetTotalesporCamarero]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspGetTotalesporCamarero]
AS
	select ca.IdCamarero, ca.Nombre, ca.Apellido1, ca.Apellido2, 
	isnull(CONVERT(varchar(4),fa.FechaFactura,100), '') Mes,
	sum(isnull(df.Importe, 0)) as Total 
	from dbo.Camarero ca
	left join dbo.Factura fa on ca.IdCamarero = fa.IdCamarero
	left join dbo.DetalleFactura df on fa.IdFactura = df.IdFactura
	group by ca.IdCamarero, ca.Nombre, ca.Apellido1, ca.Apellido2, CONVERT(varchar(4),fa.FechaFactura,100)
	order by sum(isnull(df.Importe, 0)) desc
GO
/****** Object:  StoredProcedure [dbo].[UspgetViewFactura]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetViewFactura]
AS
	SELECT f.IdFactura
		  ,c.Nombre + ' ' + c.Apellido1 + ' ' + c.Apellido2 as Cliente
		  ,cm.Nombre + ' ' + cm.Apellido1 + ' ' + cm.Apellido2 as Camarero
		  ,m.Ubicacion as Mesa
		  ,f.FechaFactura as Fecha
	  FROM Factura f
	  INNER JOIN Cliente c ON f.IdCliente = c.IdCliente
	  INNER JOIN Camarero cm ON f.IdCamarero = cm.IdCamarero
	  INNER JOIN Mesa m ON f.IdMesa = m.IdMesa

GO
/****** Object:  StoredProcedure [dbo].[UspgetViewFacturaByFecha]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UspgetViewFacturaByFecha]
	@FechaInicio Datetime
	,@FechaFin Datetime
AS
	SELECT f.IdFactura
		  ,c.Nombre + ' ' + c.Apellido1 + ' ' + c.Apellido2 as Cliente
		  ,cm.Nombre + ' ' + cm.Apellido1 + ' ' + cm.Apellido2 as Camarero
		  ,m.Ubicacion as Mesa
		  ,f.FechaFactura as Fecha
	  FROM Factura f
	  INNER JOIN Cliente c ON f.IdCliente = c.IdCliente
	  INNER JOIN Camarero cm ON f.IdCamarero = cm.IdCamarero
	  INNER JOIN Mesa m ON f.IdMesa = m.IdMesa
	  WHERE f.FechaFactura between @FechaInicio and @FechaFin

GO
/****** Object:  StoredProcedure [dbo].[uspMesaDelete]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMesaDelete]
	@IdMesa Int
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY

		DELETE FROM [dbo].[Mesa] 
		WHERE IdMesa = @IdMesa
		
COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspMesaInsert]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMesaInsert]
	@NumMaxComensa INT
	,@Ubicacion NVARCHAR(120)
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY

		INSERT INTO [dbo].[Mesa] (
			NumMaxComensa
			,Ubicacion
		) VALUES (
			@NumMaxComensa
			,@Ubicacion
		)		
		

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspMesaUpdate]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspMesaUpdate]
	@IdMesa Int
	,@NumMaxComensa INT
	,@Ubicacion NVARCHAR(120)
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY

		UPDATE [dbo].[Mesa] SET NumMaxComensa = @NumMaxComensa
			,Ubicacion = @Ubicacion
		WHERE IdMesa = @IdMesa
		
COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspUsuarioInsert]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspUsuarioInsert]
	@NombreUsuario NVARCHAR(50)
	,@Clave NVARCHAR(MAX)	
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY	
		declare @UserName nvarchar(150)

		SELECT @UserName = u.NombreUsuario FROM Usuario u WHERE u.NombreUsuario = @NombreUsuario
		IF (ISNULL(@UserName, '') = '')
		BEGIN
			INSERT INTO Usuario (NombreUsuario, Clave)
			VALUES (@NombreUsuario, @Clave)
		END
		ELSE
		BEGIN
			SELECT 'Usuario ya está registrado'
		END

COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
/****** Object:  StoredProcedure [dbo].[uspUsuarioUpdate]    Script Date: 26/10/2020 9:58:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspUsuarioUpdate]
	@IdUsuario Int
	,@NombreUsuario NVARCHAR(50)
	,@Clave NVARCHAR(MAX)
AS
BEGIN
SET NOCOUNT ON;
BEGIN 	
BEGIN TRANSACTION
	BEGIN TRY

		UPDATE [dbo].[Usuario] SET NombreUsuario = @NombreUsuario
			,Clave = @Clave
		WHERE IdUsuario = @IdUsuario
		
COMMIT TRANSACTION
			SELECT 'success'
		END TRY
		BEGIN CATCH
			ROLLBACK TRANSACTION
			SELECT ERROR_MESSAGE();
		END CATCH
	END
END
GO
USE [master]
GO
ALTER DATABASE [DBLaMejorCocina] SET  READ_WRITE 
GO
