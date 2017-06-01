USE [UsuariosFIAD]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 5/31/2017 12:16:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Numero_Empleado] [int] NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
INSERT [dbo].[Usuario] ([Numero_Empleado], [Nombre], [Email]) VALUES (1, N'Eduardo', N'a338694@uabc.edu.mx')
INSERT [dbo].[Usuario] ([Numero_Empleado], [Nombre], [Email]) VALUES (2, N'Yarithza', N'yarithza.perez@uabc.edu.mx')
INSERT [dbo].[Usuario] ([Numero_Empleado], [Nombre], [Email]) VALUES (3, N'Daniel', N'daniel.ballesteros@uabc.edu.mx ')
INSERT [dbo].[Usuario] ([Numero_Empleado], [Nombre], [Email]) VALUES (4, N'Evans', N'david.evans@uabc.edu.mx ')
INSERT [dbo].[Usuario] ([Numero_Empleado], [Nombre], [Email]) VALUES (5, N'Edgar', N'sancheze82@uabc.edu.mx ')
INSERT [dbo].[Usuario] ([Numero_Empleado], [Nombre], [Email]) VALUES (6, N'Angel', N'lugardo.diaz@uabc.edu.mx ')
INSERT [dbo].[Usuario] ([Numero_Empleado], [Nombre], [Email]) VALUES (7, N'Sumuano', N'asumuano@uabc.edu.mx ')
INSERT [dbo].[Usuario] ([Numero_Empleado], [Nombre], [Email]) VALUES (8, N'Ivan', N'ivan.antillon@uabc.edu.mx ')
INSERT [dbo].[Usuario] ([Numero_Empleado], [Nombre], [Email]) VALUES (9, N'Dogo', N'josue.jimenez@uabc.edu.mx ')
INSERT [dbo].[Usuario] ([Numero_Empleado], [Nombre], [Email]) VALUES (10, N'Ramon', N'rlopez1@uabc.edu.mx ')
INSERT [dbo].[Usuario] ([Numero_Empleado], [Nombre], [Email]) VALUES (11, N'Efren', N'efren.cabrera@uabc.edu.mx ')
INSERT [dbo].[Usuario] ([Numero_Empleado], [Nombre], [Email]) VALUES (12, N'Jesus', N'jesus.augusto.garcia.caro@uabc.edu.mx ')
INSERT [dbo].[Usuario] ([Numero_Empleado], [Nombre], [Email]) VALUES (13, N'Capistran', N'eduardo.capistran@uabc.edu.mx ')
