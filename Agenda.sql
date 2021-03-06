CREATE DATABASE [AGENDA]
USE [AGENDA]
GO
/****** Object:  Table [dbo].[contactos]    Script Date: 7/4/2020 6:00:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[contactos](
	[ID_contacto] [int] IDENTITY(1,1) NOT NULL,
	[ID_usuario] [int] NULL,
	[Nombre] [varchar](20) NULL,
	[Apellido] [varchar](20) NULL,
	[direccion] [varchar](20) NULL,
	[Numero_personal] [varchar](12) NULL,
	[Numero_trabajo] [varchar](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_contacto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 7/4/2020 6:00:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[ID_usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](20) NULL,
	[Apellido] [varchar](20) NULL,
	[Nombre_usuario] [varchar](20) NULL,
	[Contraseña] [varchar](20) NULL,
	[Confirmar_contraseña] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[contactos]  WITH CHECK ADD FOREIGN KEY([ID_usuario])
REFERENCES [dbo].[usuario] ([ID_usuario])
GO
/****** Object:  StoredProcedure [dbo].[Editar]    Script Date: 7/4/2020 6:00:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Editar] 
  @Nom nvarchar (20),
  @Apel nvarchar (20),
  @Dire nvarchar(20),
  @Nump nvarchar(12)  ,
  @Numt nvarchar(12),
  @ID int ,
  @idUser int
  as 
  update contactos set ID_usuario=@idUser,Nombre=@Nom, Apellido=@Apel, direccion=@Dire, Numero_personal=@Nump, Numero_trabajo=@Numt
  where ID_contacto=@ID
GO
/****** Object:  StoredProcedure [dbo].[Eliminar]    Script Date: 7/4/2020 6:00:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Eliminar] 
@IDc int 
as 
delete from contactos where ID_contacto=@IDc
GO
USE [master]
GO
ALTER DATABASE [AGENDA] SET  READ_WRITE 
GO
