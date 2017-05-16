USE [dbSS]
GO
/****** Object:  Table [dbo].[Actividad]    Script Date: 5/15/2017 11:58:31 PM ******/
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
/****** Object:  Table [dbo].[Carrera]    Script Date: 5/15/2017 11:58:31 PM ******/
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
/****** Object:  Table [dbo].[Categoria]    Script Date: 5/15/2017 11:58:31 PM ******/
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
/****** Object:  Table [dbo].[Estado]    Script Date: 5/15/2017 11:58:31 PM ******/
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
/****** Object:  Table [dbo].[Evento]    Script Date: 5/15/2017 11:58:31 PM ******/
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
/****** Object:  Table [dbo].[Recurso]    Script Date: 5/15/2017 11:58:31 PM ******/
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
/****** Object:  Table [dbo].[Rol]    Script Date: 5/15/2017 11:58:31 PM ******/
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
/****** Object:  Table [dbo].[Solicitud]    Script Date: 5/15/2017 11:58:31 PM ******/
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 5/15/2017 11:58:31 PM ******/
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
/****** Object:  Table [dbo].[Validacion]    Script Date: 5/15/2017 11:58:31 PM ******/
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
SET IDENTITY_INSERT [dbo].[Evento] OFF
SET IDENTITY_INSERT [dbo].[Recurso] ON 

INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (2, 1, 3, 1, 1, 1, N'asd')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (4, 1, 3, 1, 1, 1, N'3')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (7, 1, 3, 1, 1, 1, N'3')
INSERT [dbo].[Recurso] ([Id], [Hospedaje], [Transporte], [Combustible], [Viatico], [Oficio_Comision], [Otro]) VALUES (8, 1, 3, 1, 1, 1, N'3')
SET IDENTITY_INSERT [dbo].[Recurso] OFF
INSERT [dbo].[Rol] ([Id], [Nombre], [Descripcion]) VALUES (1, N'Académico', N'Coordinador')
INSERT [dbo].[Rol] ([Id], [Nombre], [Descripcion]) VALUES (2, N'Académico', N'Posgrado')
INSERT [dbo].[Rol] ([Id], [Nombre], [Descripcion]) VALUES (3, N'Academico', N'Administradora')
INSERT [dbo].[Rol] ([Id], [Nombre], [Descripcion]) VALUES (4, N'Administrador', N'Subdirector')
INSERT [dbo].[Rol] ([Id], [Nombre], [Descripcion]) VALUES (5, N'Administrador', N'Director')
SET IDENTITY_INSERT [dbo].[Solicitud] ON 

INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (2, N'11', N'Eduardo', 0, 6, 5, 2, 2, 3, 2, 1, CAST(0x070000000000000000 AS DateTime2), CAST(0x07C052ADA233D03C0B AS DateTime2), N'URL', N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (3, N'11', N'Eduardo', 0, 5, 6, 4, 4, 5, 4, 1, CAST(0x070000000000000000 AS DateTime2), CAST(0x0710BC460934D03C0B AS DateTime2), NULL, N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (6, N'11', N'Eduardo', 0, 6, 6, 7, 7, 8, 7, 1, CAST(0x070000000000000000 AS DateTime2), CAST(0x07B0B1F95B34D03C0B AS DateTime2), NULL, N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'', 0)
INSERT [dbo].[Solicitud] ([Id], [Folio], [Nombre_Solicitante], [Numero_Empleado], [Id_Categoria], [Id_Carrera], [Id_Evento], [Id_Recurso_Solicitado], [Id_Actividad], [Id_Validacion], [Id_Estado], [Fecha_Creacion], [Fecha_Modificacion], [URL_Reporte], [Correo_Solicitante], [Comentario_Rechazado], [Leido]) VALUES (7, N'11', N'Eduardo', 0, 6, 6, 8, 8, 9, 8, 1, CAST(0x070000000000000000 AS DateTime2), CAST(0x07B0B1F95B34D03C0B AS DateTime2), NULL, N'eduardo.capistran@uabc.edu.mx                                                                                                                                                                                                                             ', N'', 0)
SET IDENTITY_INSERT [dbo].[Solicitud] OFF
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (1, N'odin@uabc.edu.mx', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (2, N'prueba2@uabc.edu.mx', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (3, N'a338694@uabc.edu.mx', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (4, N'prueba@uabc.edu.mx', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (5, N'lopez@uabc.edu.mx', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (6, N'aguilar@uabc.edu.mx', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (7, N'colores@uabc.edu.mx', 1)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (8, N'juracy@uabc.edu.mx', 2)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (9, N'daniel.ballestero@uabc.edu.mx', 3)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (10, N'romero@uabc.edu.mx', 4)
INSERT [dbo].[Usuario] ([Id], [Correo], [Id_Rol]) VALUES (11, N'eduardo.capistran@uabc.edu.mx', 5)
SET IDENTITY_INSERT [dbo].[Validacion] ON 

INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (2, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (4, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (7, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[Validacion] ([Id], [Coordinador], [Subdirector], [Administrador], [Director], [Posgrado], [Unica]) VALUES (8, 0, 0, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Validacion] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Carrera__75E3EFCFACC810FA]    Script Date: 5/15/2017 11:58:31 PM ******/
ALTER TABLE [dbo].[Carrera] ADD  CONSTRAINT [UQ__Carrera__75E3EFCFACC810FA] UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UQ__Carrera__EDD6CF929DD2F4C3]    Script Date: 5/15/2017 11:58:31 PM ******/
ALTER TABLE [dbo].[Carrera] ADD  CONSTRAINT [UQ__Carrera__EDD6CF929DD2F4C3] UNIQUE NONCLUSTERED 
(
	[Id_Usuario_Coordinador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Categori__75E3EFCF78421EC5]    Script Date: 5/15/2017 11:58:31 PM ******/
ALTER TABLE [dbo].[Categoria] ADD  CONSTRAINT [UQ__Categori__75E3EFCF78421EC5] UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Rol__92C53B6C7139F234]    Script Date: 5/15/2017 11:58:31 PM ******/
ALTER TABLE [dbo].[Rol] ADD  CONSTRAINT [UQ__Rol__92C53B6C7139F234] UNIQUE NONCLUSTERED 
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Usuario__60695A19A9C6705E]    Script Date: 5/15/2017 11:58:31 PM ******/
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
