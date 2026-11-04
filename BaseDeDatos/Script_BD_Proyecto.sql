USE [master]
GO
/****** Objeto: Database [BD_Proyecto] Fecha de script: 01/11/2026 20:37:35 ******/
CREATE DATABASE [BD_Proyecto]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_Proyecto', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL17.MSSQLSERVER\MSSQL\DATA\BD_Proyecto.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BD_Proyecto_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL17.MSSQLSERVER\MSSQL\DATA\BD_Proyecto_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BD_Proyecto] SET COMPATIBILITY_LEVEL = 170
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_Proyecto].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD_Proyecto] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD_Proyecto] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD_Proyecto] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD_Proyecto] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD_Proyecto] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD_Proyecto] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BD_Proyecto] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD_Proyecto] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD_Proyecto] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD_Proyecto] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD_Proyecto] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD_Proyecto] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD_Proyecto] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD_Proyecto] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD_Proyecto] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BD_Proyecto] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD_Proyecto] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD_Proyecto] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD_Proyecto] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD_Proyecto] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD_Proyecto] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD_Proyecto] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD_Proyecto] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BD_Proyecto] SET  MULTI_USER 
GO
ALTER DATABASE [BD_Proyecto] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD_Proyecto] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD_Proyecto] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD_Proyecto] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BD_Proyecto] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BD_Proyecto] SET OPTIMIZED_LOCKING = OFF 
GO
ALTER DATABASE [BD_Proyecto] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BD_Proyecto] SET QUERY_STORE = ON
GO
ALTER DATABASE [BD_Proyecto] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BD_Proyecto]
GO
/****** Objeto: Table [dbo].[Equipos] Fecha de script: 01/11/2026 20:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipos](
	[IdEquipo] [int] IDENTITY(1,1) NOT NULL,
	[NombreEquipo] [varchar](100) NOT NULL,
	[Categoria] [varchar](50) NOT NULL,
	[CantidadJugadores] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Jugadores] Fecha de script: 01/11/2026 20:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadores](
	[IdJugador] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Edad] [int] NOT NULL,
	[Dni] [varchar](8) NOT NULL,
	[IdEquipo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdJugador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Objeto: Table [dbo].[Usuarios] Fecha de script: 01/11/2026 20:37:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[Contrasena] [varchar](100) NOT NULL,
	[Rol] [varchar](20) NOT NULL,
	[PrimerIngreso] [bit] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Dni] [varchar](8) NOT NULL,
	[Telefono] [varchar](10) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Genero] [varchar](20) NOT NULL,
	[FechaNacimiento] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Equipos] ON 

INSERT [dbo].[Equipos] ([IdEquipo], [NombreEquipo], [Categoria], [CantidadJugadores]) VALUES (2, N'boca', N'Sub-17', 5)
INSERT [dbo].[Equipos] ([IdEquipo], [NombreEquipo], [Categoria], [CantidadJugadores]) VALUES (3, N'river', N'Sub-15', 5)
SET IDENTITY_INSERT [dbo].[Equipos] OFF
GO
SET IDENTITY_INSERT [dbo].[Jugadores] ON 

INSERT [dbo].[Jugadores] ([IdJugador], [Nombre], [Apellido], [Edad], [Dni], [IdEquipo]) VALUES (6, N'agus', N'espi', 18, N'11111111', 2)
INSERT [dbo].[Jugadores] ([IdJugador], [Nombre], [Apellido], [Edad], [Dni], [IdEquipo]) VALUES (7, N'zoe', N'avalla', 20, N'22222222', 2)
INSERT [dbo].[Jugadores] ([IdJugador], [Nombre], [Apellido], [Edad], [Dni], [IdEquipo]) VALUES (8, N'luna', N'nose', 21, N'33333333', 2)
INSERT [dbo].[Jugadores] ([IdJugador], [Nombre], [Apellido], [Edad], [Dni], [IdEquipo]) VALUES (9, N'cyn', N'aguero', 25, N'44444444', 2)
INSERT [dbo].[Jugadores] ([IdJugador], [Nombre], [Apellido], [Edad], [Dni], [IdEquipo]) VALUES (10, N'luca', N'nosee', 22, N'55555555', 2)
INSERT [dbo].[Jugadores] ([IdJugador], [Nombre], [Apellido], [Edad], [Dni], [IdEquipo]) VALUES (11, N'Carlos', N'Gómez', 24, N'41234567', 3)
INSERT [dbo].[Jugadores] ([IdJugador], [Nombre], [Apellido], [Edad], [Dni], [IdEquipo]) VALUES (12, N'María', N'Fernández', 30, N'38987654', 3)
INSERT [dbo].[Jugadores] ([IdJugador], [Nombre], [Apellido], [Edad], [Dni], [IdEquipo]) VALUES (13, N'Lucía', N'Martínez', 21, N'43555444', 3)
INSERT [dbo].[Jugadores] ([IdJugador], [Nombre], [Apellido], [Edad], [Dni], [IdEquipo]) VALUES (14, N'Martín', N'Rodríguez', 27, N'39111222', 3)
INSERT [dbo].[Jugadores] ([IdJugador], [Nombre], [Apellido], [Edad], [Dni], [IdEquipo]) VALUES (15, N'Sofía', N'López', 25, N'40888999', 3)
SET IDENTITY_INSERT [dbo].[Jugadores] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [Usuario], [Contrasena], [Rol], [PrimerIngreso], [Nombre], [Apellido], [Dni], [Telefono], [Email], [Genero]) VALUES (1, N'admin001', N'admin123', N'Administrador', 1, N'Ana', N'Administrador', N'11111111', N'1111111111', N'admin@liga.com', N'Femenino')
INSERT [dbo].[Usuarios] ([IdUsuario], [Usuario], [Contrasena], [Rol], [PrimerIngreso], [Nombre], [Apellido], [Dni], [Telefono], [Email], [Genero]) VALUES (2, N'jperez123', N'4211', N'General', 0, N'Juan', N'Perez', N'22222222', N'2222222222', N'jperez@liga.com', N'Masculino')
INSERT [dbo].[Usuarios] ([IdUsuario], [Usuario], [Contrasena], [Rol], [PrimerIngreso], [Nombre], [Apellido], [Dni], [Telefono], [Email], [Genero]) VALUES (4, N'cgomez555', N'messi123', N'General', 0, N'carlos', N'gomez', N'33444555', N'1159102922', N'carlos@test.com', N'Masculino')
INSERT [dbo].[Usuarios] ([IdUsuario], [Usuario], [Contrasena], [Rol], [PrimerIngreso], [Nombre], [Apellido], [Dni], [Telefono], [Email], [Genero]) VALUES (5, N'caguero539', N'4211', N'General', 0, N'cynthia', N'aguero', N'45570539', N'1159102939', N'cynthiaaguero.dev@gmail.com', N'Femenino')
INSERT [dbo].[Usuarios] ([IdUsuario], [Usuario], [Contrasena], [Rol], [PrimerIngreso], [Nombre], [Apellido], [Dni], [Telefono], [Email], [Genero]) VALUES (6, N'ldelgado777', N'5555', N'Administrador', 0, N'Luna', N'Delgado', N'45999777', N'1234576566', N'hola@gmail.com', N'Femenino')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET ANSI_PADDING ON
GO
/****** Objeto: Index [UQ__Equipos__D94BAF2EA8726612] Fecha de script: 01/11/2026 20:37:36 ******/
ALTER TABLE [dbo].[Equipos] ADD UNIQUE NONCLUSTERED 
(
	[NombreEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Objeto: Index [UQ__Usuarios__C0308575DD4D3005] Fecha de script: 01/11/2026 20:37:36 ******/
ALTER TABLE [dbo].[Usuarios] ADD UNIQUE NONCLUSTERED 
(
	[Dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Objeto: Index [UQ__Usuarios__E3237CF71DEF1E3C] Fecha de script: 01/11/2026 20:37:36 ******/
ALTER TABLE [dbo].[Usuarios] ADD UNIQUE NONCLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((1)) FOR [PrimerIngreso]
GO
ALTER TABLE [dbo].[Jugadores]  WITH CHECK ADD  CONSTRAINT [FK_Jugadores_Equipos] FOREIGN KEY([IdEquipo])
REFERENCES [dbo].[Equipos] ([IdEquipo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Jugadores] CHECK CONSTRAINT [FK_Jugadores_Equipos]
GO
USE [master]
GO
ALTER DATABASE [BD_Proyecto] SET  READ_WRITE 
GO
