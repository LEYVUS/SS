USE [UsuariosUABC]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 5/31/2017 12:17:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Contraseña] [nvarchar](50) NOT NULL,
	[Numero_Empleado] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Nombre], [Apellido], [Email], [Contraseña], [Numero_Empleado]) VALUES (N'Eduardo', N'Escalona', N'a338694@uabc.edu.mx', N'pruebas123', 44)
INSERT [dbo].[Usuario] ([Nombre], [Apellido], [Email], [Contraseña], [Numero_Empleado]) VALUES (N'Yarithza ', N'Perez', N'yarithza.perez@uabc.edu.mx', N'pruebas123', 45)
INSERT [dbo].[Usuario] ([Nombre], [Apellido], [Email], [Contraseña], [Numero_Empleado]) VALUES (N'Daniel', N'Ballesteros', N'daniel.ballesteros@uabc.edu.mx ', N'pruebas123', 46)
INSERT [dbo].[Usuario] ([Nombre], [Apellido], [Email], [Contraseña], [Numero_Empleado]) VALUES (N'Evans', N'Rey', N'david.evans@uabc.edu.mx ', N'pruebas123', 47)
INSERT [dbo].[Usuario] ([Nombre], [Apellido], [Email], [Contraseña], [Numero_Empleado]) VALUES (N'Edgar ', N'Sanchez', N'sancheze82@uabc.edu.mx ', N'pruebas123', 48)
INSERT [dbo].[Usuario] ([Nombre], [Apellido], [Email], [Contraseña], [Numero_Empleado]) VALUES (N'Angel', N'Lugardo', N'lugardo.diaz@uabc.edu.mx ', N'pruebas123', 49)
INSERT [dbo].[Usuario] ([Nombre], [Apellido], [Email], [Contraseña], [Numero_Empleado]) VALUES (N'Sumuano ', N'Alejandro', N'asumuano@uabc.edu.mx ', N'pruebas123', 50)
INSERT [dbo].[Usuario] ([Nombre], [Apellido], [Email], [Contraseña], [Numero_Empleado]) VALUES (N'Ivan', N'Antillon ', N'ivan.antillon@uabc.edu.mx ', N'pruebas123', 51)
INSERT [dbo].[Usuario] ([Nombre], [Apellido], [Email], [Contraseña], [Numero_Empleado]) VALUES (N'Dogo ', N'Hermosillo', N'josue.jimenez@uabc.edu.mx ', N'pruebas123', 52)
INSERT [dbo].[Usuario] ([Nombre], [Apellido], [Email], [Contraseña], [Numero_Empleado]) VALUES (N'Ramon', N'Lopez', N'rlopez1@uabc.edu.mx ', N'pruebas123', 53)
INSERT [dbo].[Usuario] ([Nombre], [Apellido], [Email], [Contraseña], [Numero_Empleado]) VALUES (N'Efren', N'Cabrera', N'efren.cabrera@uabc.edu.mx ', N'pruebas123', 54)
INSERT [dbo].[Usuario] ([Nombre], [Apellido], [Email], [Contraseña], [Numero_Empleado]) VALUES (N'Jesus', N'Augusto', N'jesus.augusto.garcia.caro@uabc.edu.mx ', N'pruebas123', 55)
INSERT [dbo].[Usuario] ([Nombre], [Apellido], [Email], [Contraseña], [Numero_Empleado]) VALUES (N'Capistran', N'Eduardo', N'eduardo.capistran@uabc.edu.mx ', N'pruebas123', 56)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
