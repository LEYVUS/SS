USE [dbSS]
GO
/****** Object:  Table [dbo].[Actividad]    Script Date: 5/31/2017 12:15:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actividad](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CACEI] [bit] NULL,
	[Licenciatura] [bit] NULL,
	[Personal] [bit] NULL,
	[ISO] [bit] NULL,
	[Posgrado] [bit] NULL,
	[Otro] [nvarchar](100) NULL,
 CONSTRAINT [PK_Actividad_Asociada] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Carrera]    Script Date: 5/31/2017 12:15:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera](
	[Id] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Id_Usuario_Coordinador] [int] NOT NULL,
 CONSTRAINT [PK_Carrera] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 5/31/2017 12:15:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] NOT NULL,
	[Nombre] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estado]    Script Date: 5/31/2017 12:15:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Evento]    Script Date: 5/31/2017 12:15:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Evento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](150) NOT NULL,
	[Costo] [float] NULL,
	[Lugar] [nvarchar](150) NOT NULL,
	[Fecha_Hora_Salida] [datetime2](7) NOT NULL,
	[Fecha_Hora_Regreso] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Evento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Recurso]    Script Date: 5/31/2017 12:15:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recurso](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Hospedaje] [bit] NULL,
	[Transporte] [int] NULL,
	[Combustible] [bit] NULL,
	[Viatico] [bit] NULL,
	[Oficio_Comision] [bit] NULL,
	[Otro] [nvarchar](250) NULL,
 CONSTRAINT [PK_Recurso] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rol]    Script Date: 5/31/2017 12:15:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[Id] [int] NOT NULL,
	[Nombre] [nvarchar](25) NOT NULL,
	[Descripcion] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Solicitud]    Script Date: 5/31/2017 12:15:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Solicitud](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Folio] [nvarchar](max) NOT NULL,
	[Nombre_Solicitante] [nvarchar](50) NOT NULL,
	[Numero_Empleado] [int] NOT NULL,
	[Id_Categoria] [int] NOT NULL,
	[Id_Carrera] [int] NOT NULL,
	[Id_Evento] [int] NOT NULL,
	[Id_Recurso_Solicitado] [int] NOT NULL,
	[Id_Actividad] [int] NOT NULL,
	[Id_Validacion] [int] NOT NULL,
	[Id_Estado] [int] NOT NULL,
	[Fecha_Creacion] [datetime2](7) NOT NULL,
	[Fecha_Modificacion] [datetime2](7) NOT NULL,
	[URL_Reporte] [nvarchar](50) NULL,
	[Correo_Solicitante] [nchar](250) NOT NULL,
	[Comentario_Rechazado] [nvarchar](max) NOT NULL,
	[Leido] [bit] NOT NULL,
 CONSTRAINT [PK_Solicitud] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 5/31/2017 12:15:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] NOT NULL,
	[Correo] [nvarchar](50) NOT NULL,
	[Id_Rol] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Validacion]    Script Date: 5/31/2017 12:15:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Validacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Coordinador] [bit] NOT NULL,
	[Subdirector] [bit] NOT NULL,
	[Administrador] [bit] NOT NULL,
	[Director] [bit] NOT NULL,
	[Posgrado] [bit] NOT NULL,
	[Unica] [bit] NOT NULL,
 CONSTRAINT [PK_Validaciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Actividad] ON 

INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (3, 1, 1, 1, 1, 1, N'3')
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (5, 1, 1, 1, 1, 1, N'3')
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (8, 1, 1, 1, 1, 1, N'3')
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (9, 1, 1, 1, 1, 1, N'3')
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (10, 1, 0, 0, 0, 0, NULL)
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (11, 1, 1, 1, 1, 1, N'asdasdsdasd')
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (12, 1, 1, 1, 1, 1, N'3')
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (13, 1, 1, 1, 1, 1, N'3')
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (14, 1, 1, 1, 1, 1, N'd')
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (15, 1, 1, 1, 1, 1, N'3')
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (16, 1, 1, 1, 1, 1, N'3')
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (17, 1, 1, 1, 1, 1, N'S')
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (18, 1, 1, 1, 1, 1, N'w')
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (19, 1, 1, 1, 1, 1, N'gbdsfdsfd')
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (20, 1, 1, 1, 1, 1, N'gbdsfdsfd')
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (21, 1, 1, 1, 1, 1, N'qweq')
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (22, 1, 1, 1, 1, 1, N'3')
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (23, 1, 0, 0, 0, 0, NULL)
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (24, 1, 0, 0, 0, 0, NULL)
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (25, 1, 0, 0, 0, 0, NULL)
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (26, 0, 0, 1, 0, 0, NULL)
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (27, 1, 0, 0, 0, 0, NULL)
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (28, 0, 1, 0, 0, 0, NULL)
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (29, 1, 0, 0, 0, 0, NULL)
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (30, 0, 0, 1, 0, 0, NULL)
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (31, 0, 0, 1, 0, 0, NULL)
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (32, 1, 0, 0, 0, 0, NULL)
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (33, 1, 0, 0, 0, 0, NULL)
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (34, 1, 0, 1, 1, 1, N'cola')
INSERT [dbo].[Actividad] ([Id], [CACEI], [Licenciatura], [Personal], [ISO], [Posgrado], [Otro]) VALUES (35, 1, 0, 1, 1, 1, N'cola')
SET IDENTITY_INSERT [dbo].[Actividad] OFF
INSERT [dbo].[Carrera] ([Id], [Nombre], [Id_Usuario_Coordinador]) VALUES (1, N'Bioingeniería', 1)
INSERT [dbo].[Carrera] ([Id], [Nombre], [Id_Usuario_Coordinador]) VALUES (2, N'Ingeniería en Computación', 2)
INSERT [dbo].[Carrera] ([Id], [Nombre], [Id_Usuario_Coordinador]) VALUES (3, N'Ingeniería Civil', 3)
INSERT [dbo].[Carrera] ([Id], [Nombre], [Id_Usuario_Coordinador]) VALUES (4, N'Ingeniería Industrial', 4)
INSERT [dbo].[Carrera] ([Id], [Nombre], [Id_Usuario_Coordinador]) VALUES (5, N'Nanotecnología', 5)
INSERT [dbo].[Carrera] ([Id], [Nombre], [Id_Usuario_Coordinador]) VALUES (6, N'Ingeniería en Electrónica', 6)
INSERT [dbo].[Carrera] ([Id], [Nombre], [Id_Usuario_Coordinador]) VALUES (7, N'Arquitectura', 7)
INSERT [dbo].[Carrera] ([Id], [Nombre], [Id_Usuario_Coordinador]) VALUES (8, N'Tronco Comun', 8)
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (1, N'Asignatura')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (2, N'Tiempo Completo Asociado A')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (3, N'Tiempo Completo Asociado B')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (4, N'Tiempo Completo Asociado C')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (5, N'Tiempo Completo Tecnico Academico')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (6, N'Tiempo Completo Titular A')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (7, N'Tiempo Completo Titular B')
INSERT [dbo].[Categoria] ([Id], [Nombre]) VALUES (8, N'Tiempo Completo Titular C')
SET IDENTITY_INSERT [dbo].[Estado] ON 

INSERT [dbo].[Estado] ([Id], [Tipo]) VALUES (1, N'Procceso')
INSERT [dbo].[Estado] ([Id], [Tipo]) VALUES (2, N'Aceptado')
INSERT [dbo].[Estado] ([Id], [Tipo]) VALUES (3, N'Rechazado')
INSERT [dbo].[Estado] ([Id], [Tipo]) VALUES (4, N'Cancelado')
INSERT [dbo].[Estado] ([Id], [Tipo]) VALUES (5, N'Reporte')
INSERT [dbo].[Estado] ([Id], [Tipo]) VALUES (6, N'Terminado')
SET IDENTITY_INSERT [dbo].[Estado] OFF
SET IDENTITY_INSERT [dbo].[Evento] ON 

INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (2, N'adasd', NULL, N'asdasd', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (4, N'edad', NULL, N'eadas', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (7, N'asdas', NULL, N'dasdasd', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (8, N'asdas', NULL, N'dasdasd', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (9, N'ed', NULL, N'asdasd', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (10, N'caca', NULL, N'caca', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (11, N'prueba', NULL, N'prueba', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (12, N'adasd', NULL, N'asdasd', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (13, N'cvcxv', NULL, N'sdfsdf', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (14, N'asdasd', NULL, N'asdasd', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (15, N'asdas', NULL, N'adasd', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (16, N'sas`', NULL, N'QDQWD`2', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (17, N'asd', NULL, N'adasd', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (18, N'qweqwe', NULL, N'lkds', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (19, N'qweqwe', NULL, N'lkds', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (20, N'qwe', NULL, N'qwe', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (21, N'asdasd', NULL, N'asdasda', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (22, N'hola', 3, N'hola', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (23, N'prueba2', 2, N'prueba2', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (24, N'sadsd', 2, N'2', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (25, N'asd', 222, N'asdasd', CAST(0x0700D85EAC3ADD3C0B AS DateTime2), CAST(0x0700D85EAC3ADE3C0B AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (26, N'asdasd', 333, N'adas', CAST(0x0700D85EAC3ADD3C0B AS DateTime2), CAST(0x0700D85EAC3ADE3C0B AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (27, N'adasd', 3331, N'asdasd', CAST(0x0700D85EAC3ADE3C0B AS DateTime2), CAST(0x0700D85EAC3AE03C0B AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (28, N'prueba1', 45, N'prueba1', CAST(0x0700D85EAC3ADD3C0B AS DateTime2), CAST(0x0700D85EAC3ADE3C0B AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (29, N'asdas', 222, N'asdasd', CAST(0x0700D85EAC3ADF3C0B AS DateTime2), CAST(0x0700D85EAC3AE23C0B AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (30, N'asdasd', 22, N'asdasd', CAST(0x0700D85EAC3AE03C0B AS DateTime2), CAST(0x0700D85EAC3AE23C0B AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (31, N'asdasd', 333, N'asdasd', CAST(0x0700D85EAC3AE23C0B AS DateTime2), CAST(0x0700D85EAC3AED3C0B AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (32, N'dasdasd', NULL, N'asdasd', CAST(0x0700D85EAC3AE03C0B AS DateTime2), CAST(0x0700D85EAC3AE23C0B AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (33, N'cola', 42, N'dasdasd', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
INSERT [dbo].[Evento] ([Id], [Nombre], [Costo], [Lugar], [Fecha_Hora_Salida], [Fecha_Hora_Regreso]) VALUES (34, N'cola', 42, N'dasdasd', CAST(0x070000000000000000 AS DateTime2), CAST(0x070000000000000000 AS DateTime2))
SET IDENTITY_INSERT [dbo].[Evento] OFF
SET IDENTITY_INSERT [dbo].[Recurso] ON 

INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (2, 1, 3, 1, 1, 1, N'asd')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (4, 1, 3, 1, 1, 1, N'3')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (7, 1, 3, 1, 1, 1, N'3')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (8, 1, 3, 1, 1, 1, N'3')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (9, 1, 5, 1, 1, 1, N'asdasd')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (10, 1, 2, 1, 1, 1, N'sssss')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (11, 1, 2, 1, 1, 1, N'2')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (12, 1, 3, 1, 1, 1, N'2')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (13, 1, 3, 1, 1, 1, N'afdsdf')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (14, 1, 2, 1, 1, 1, N'3')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (15, 1, 2, 1, 1, 1, N's')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (16, 1, 2, 1, 1, 1, N'AD')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (17, 1, 2, 1, 1, 1, N'3')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (18, 1, 12, 1, 1, 1, N'rtgegrehg')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (19, 1, 12, 1, 1, 1, N'rtgegrehg')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (20, 1, 2, 1, 1, 1, N'qweqwe')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (21, 1, 3, 1, 1, 1, N'3')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (22, 1, NULL, 0, 0, 0, NULL)
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (23, 1, NULL, 0, 1, 1, NULL)
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (24, 1, NULL, 0, 1, 1, NULL)
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (25, 1, NULL, 0, 0, 0, NULL)
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (26, 1, NULL, 0, 0, 0, NULL)
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (27, 1, NULL, 0, 0, 0, NULL)
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (28, 1, NULL, 0, 0, 0, NULL)
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (29, 0, NULL, 0, 1, 0, NULL)
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (30, 0, NULL, 0, 0, 1, NULL)
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (31, 1, NULL, 0, 0, 0, NULL)
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (32, 1, NULL, 0, 0, 0, NULL)
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (33, 1, 3, 1, 1, 1, N'3')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (34, 1, 3, 1, 1, 1, N'3')
SET IDENTITY_INSERT [dbo].[Recurso] OFF
INSERT [dbo].[Rol] ([Id], [Nombre], [Descripcion]) VALUES (1, N'Académico', N'Coordinador')
INSERT [dbo].[Rol] ([Id], [Nombre], [Descripcion]) VALUES (2, N'Académico', N'Posgrado')
INSERT [dbo].[Rol] ([Id], [Nombre], [Descripcion]) VALUES (3, N'Académico', N'Administradora')
INSERT [dbo].[Rol] ([Id], [Nombre], [Descripcion]) VALUES (4, N'Administrador', N'Subdirector')
INSERT [dbo].[Rol] ([Id], [Nombre], [Descripcion]) VALUES (5, N'Administrador', N'Director')
SET IDENTITY_INSERT [dbo].[Solicitud] ON 

INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (2, N'11', N'Eduardo', 0, 6, 1, 2, 2, 3, 2, 5, CAST(0x070000000000000000 AS DateTime2), CAST(0x07C052ADA233D03C0B AS DateTime2), N'URL', N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (6, N'11', N'Eduardo', 0, 7, 8, 34, 34, 35, 34, 1, CAST(0x070000000000000000 AS DateTime2), CAST(0x074267CB0CA9DD3C0B AS DateTime2), NULL, N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (7, N'11', N'Eduardo', 0, 6, 1, 8, 8, 9, 8, 1, CAST(0x070000000000000000 AS DateTime2), CAST(0x07B0B1F95B34D03C0B AS DateTime2), NULL, N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (8, N'11', N'Eduardo', 0, 5, 1, 9, 9, 10, 9, 1, CAST(0x07508F3F5EBED33C0B AS DateTime2), CAST(0x07508F3F5EBED33C0B AS DateTime2), NULL, N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'asdasdasd', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (9, N'11', N'Eduardo', 0, 2, 1, 10, 10, 11, 10, 1, CAST(0x0740E300AEBED33C0B AS DateTime2), CAST(0x0740E300AEBED33C0B AS DateTime2), NULL, N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (10, N'11', N'Eduardo', 0, 2, 2, 11, 11, 12, 11, 1, CAST(0x07F0BF759319D43C0B AS DateTime2), CAST(0x07F0BF759319D43C0B AS DateTime2), NULL, N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (11, N'11', N'Eduardo', 0, 1, 6, 12, 12, 13, 12, 1, CAST(0x07F0452A121AD43C0B AS DateTime2), CAST(0x07F0452A121AD43C0B AS DateTime2), NULL, N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (12, N'11', N'Eduardo', 0, 2, 2, 13, 13, 14, 13, 1, CAST(0x0740F6C84F1AD43C0B AS DateTime2), CAST(0x0740F6C84F1AD43C0B AS DateTime2), NULL, N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (13, N'11', N'Eduardo', 0, 2, 2, 14, 14, 15, 14, 1, CAST(0x0730217B311BD43C0B AS DateTime2), CAST(0x0730217B311BD43C0B AS DateTime2), NULL, N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (14, N'11', N'Eduardo', 0, 4, 2, 15, 15, 16, 15, 1, CAST(0x0730E5E0751BD43C0B AS DateTime2), CAST(0x0730E5E0751BD43C0B AS DateTime2), NULL, N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (15, N'11', N'Eduardo', 0, 4, 1, 16, 16, 17, 16, 1, CAST(0x07606E56D81BD43C0B AS DateTime2), CAST(0x07606E56D81BD43C0B AS DateTime2), NULL, N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (16, N'11', N'Eduardo', 0, 7, 8, 17, 17, 18, 17, 1, CAST(0x07B05ED1B21CD43C0B AS DateTime2), CAST(0x07B05ED1B21CD43C0B AS DateTime2), NULL, N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (17, N'11', N'Eduardo', 0, 1, 2, 18, 18, 19, 18, 1, CAST(0x0750F5D8731DD43C0B AS DateTime2), CAST(0x0750F5D8731DD43C0B AS DateTime2), NULL, N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (18, N'11', N'Eduardo', 0, 1, 2, 19, 19, 20, 19, 1, CAST(0x0750F5D8731DD43C0B AS DateTime2), CAST(0x0750F5D8731DD43C0B AS DateTime2), NULL, N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (19, N'11', N'Eduardo', 0, 2, 1, 20, 20, 21, 20, 1, CAST(0x07604F15F01DD43C0B AS DateTime2), CAST(0x07604F15F01DD43C0B AS DateTime2), NULL, N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (20, N'11', N'Eduardo', 0, 3, 2, 21, 21, 22, 21, 1, CAST(0x07A0361AC81ED43C0B AS DateTime2), CAST(0x07A0361AC81ED43C0B AS DateTime2), NULL, N'a338694@uabc.edu.mx                                                                                                                                                                                                                                       ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (21, N'11', N'Odin', 0, 1, 2, 22, 22, 23, 22, 1, CAST(0x076088454E0BD63C0B AS DateTime2), CAST(0x076088454E0BD63C0B AS DateTime2), NULL, N'odin@uabc.edu.mx                                                                                                                                                                                                                                          ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (22, N'11', N'Odin', 0, 7, 8, 23, 23, 24, 23, 1, CAST(0x075074A2790BD63C0B AS DateTime2), CAST(0x075074A2790BD63C0B AS DateTime2), NULL, N'odin@uabc.edu.mx                                                                                                                                                                                                                                          ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (23, N'11', N'Odin', 0, 8, 8, 24, 24, 25, 24, 1, CAST(0x07507005B60BD63C0B AS DateTime2), CAST(0x07507005B60BD63C0B AS DateTime2), NULL, N'odin@uabc.edu.mx                                                                                                                                                                                                                                          ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (24, N'11', N'Eduardo', 44, 5, 6, 25, 25, 26, 25, 1, CAST(0x0730A20C458BDC3C0B AS DateTime2), CAST(0x0730A20C458BDC3C0B AS DateTime2), NULL, N'a338694@uabc.edu.mx                                                                                                                                                                                                                                       ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (25, N'11', N'Eduardo', 44, 1, 2, 26, 26, 27, 26, 1, CAST(0x0740E14C8D8BDC3C0B AS DateTime2), CAST(0x0740E14C8D8BDC3C0B AS DateTime2), NULL, N'a338694@uabc.edu.mx                                                                                                                                                                                                                                       ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (26, N'11', N'Eduardo', 44, 2, 1, 27, 27, 28, 27, 1, CAST(0x07B02710C38BDC3C0B AS DateTime2), CAST(0x07B02710C38BDC3C0B AS DateTime2), NULL, N'a338694@uabc.edu.mx                                                                                                                                                                                                                                       ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (27, N'11', N'Eduardo', 44, 4, 1, 28, 28, 29, 28, 1, CAST(0x0770E2E60395DC3C0B AS DateTime2), CAST(0x0770E2E60395DC3C0B AS DateTime2), NULL, N'a338694@uabc.edu.mx                                                                                                                                                                                                                                       ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (28, N'11', N'Eduardo', 44, 4, 8, 29, 29, 30, 29, 1, CAST(0x0790F6B70E9EDC3C0B AS DateTime2), CAST(0x0790F6B70E9EDC3C0B AS DateTime2), NULL, N'a338694@uabc.edu.mx                                                                                                                                                                                                                                       ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (29, N'11', N'Yarithza ', 45, 6, 7, 30, 30, 31, 30, 1, CAST(0x07301B06749EDC3C0B AS DateTime2), CAST(0x07301B06749EDC3C0B AS DateTime2), NULL, N'yarithza.perez@uabc.edu.mx                                                                                                                                                                                                                                ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (30, N'11', N'Yarithza ', 45, 5, 6, 31, 31, 32, 31, 1, CAST(0x07902AB2D09EDC3C0B AS DateTime2), CAST(0x07902AB2D09EDC3C0B AS DateTime2), NULL, N'yarithza.perez@uabc.edu.mx                                                                                                                                                                                                                                ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (31, N'11', N'Yarithza ', 45, 3, 6, 32, 32, 33, 32, 1, CAST(0x074018D1FA9EDC3C0B AS DateTime2), CAST(0x074018D1FA9EDC3C0B AS DateTime2), NULL, N'yarithza.perez@uabc.edu.mx                                                                                                                                                                                                                                ', N'', 0)
SET IDENTITY_INSERT [dbo].[Solicitud] OFF
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (1, N'efren.cabrera@uabc.edu.mx', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (2, N'david.evans@uabc.edu.mx ', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (3, N'jesus.augusto.garcia.caro@uabc.edu.mx ', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (4, N'sancheze82@uabc.edu.mx ', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (5, N'lugardo.diaz@uabc.edu.mx ', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (6, N'asumuano@uabc.edu.mx ', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (7, N'ivan.antillon@uabc.edu.mx ', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (8, N'josue.jimenez@uabc.edu.mx ', 2)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (9, N'yarithza.perez@uabc.edu.mx', 3)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (10, N'a338694@uabc.edu.mx', 4)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (11, N'rlopez1@uabc.edu.mx', 5)
SET IDENTITY_INSERT [dbo].[Validacion] ON 

INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (2, 1, 1, 1, 1, 1, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (4, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (7, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (8, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (9, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (10, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (11, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (12, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (13, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (14, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (15, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (16, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (17, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (18, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (19, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (20, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (21, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (22, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (23, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (24, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (25, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (26, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (27, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (28, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (29, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (30, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (31, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (32, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (33, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (34, 0, 0, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Validacion] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Carrera__75E3EFCFACC810FA]    Script Date: 5/31/2017 12:15:57 AM ******/
ALTER TABLE [dbo].[Carrera] ADD  CONSTRAINT [UQ__Carrera__75E3EFCFACC810FA] UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Carrera__EDD6CF929DD2F4C3]    Script Date: 5/31/2017 12:15:57 AM ******/
ALTER TABLE [dbo].[Carrera] ADD  CONSTRAINT [UQ__Carrera__EDD6CF929DD2F4C3] UNIQUE NONCLUSTERED 
(
	[Id_Usuario_Coordinador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Categori__75E3EFCF78421EC5]    Script Date: 5/31/2017 12:15:57 AM ******/
ALTER TABLE [dbo].[Categoria] ADD  CONSTRAINT [UQ__Categori__75E3EFCF78421EC5] UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Rol__92C53B6C7139F234]    Script Date: 5/31/2017 12:15:57 AM ******/
ALTER TABLE [dbo].[Rol] ADD  CONSTRAINT [UQ__Rol__92C53B6C7139F234] UNIQUE NONCLUSTERED 
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Usuario__60695A19A9C6705E]    Script Date: 5/31/2017 12:15:57 AM ******/
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [UQ__Usuario__60695A19A9C6705E] UNIQUE NONCLUSTERED 
(
	[Correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carrera]  WITH CHECK ADD  CONSTRAINT [FK_Carrera_Usuario] FOREIGN KEY([Id_Usuario_Coordinador])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Carrera] CHECK CONSTRAINT [FK_Carrera_Usuario]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Actividad] FOREIGN KEY([Id_Actividad])
REFERENCES [dbo].[Actividad] ([Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Actividad]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_C] FOREIGN KEY([Id_Categoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_C]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Carrera] FOREIGN KEY([Id_Carrera])
REFERENCES [dbo].[Carrera] ([Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Carrera]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Estado] FOREIGN KEY([Id_Estado])
REFERENCES [dbo].[Estado] ([Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Estado]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Evento] FOREIGN KEY([Id_Evento])
REFERENCES [dbo].[Evento] ([Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Evento]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Recurso] FOREIGN KEY([Id_Recurso_Solicitado])
REFERENCES [dbo].[Recurso] ([Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Recurso]
GO
ALTER TABLE [dbo].[Solicitud]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Validacion] FOREIGN KEY([Id_Validacion])
REFERENCES [dbo].[Validacion] ([Id])
GO
ALTER TABLE [dbo].[Solicitud] CHECK CONSTRAINT [FK_Solicitud_Validacion]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([Id_Rol])
REFERENCES [dbo].[Rol] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Rol]
GO
