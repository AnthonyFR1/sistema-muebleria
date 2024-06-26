USE [bdmuebleria_moanso]
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cliente](
	[idcliente] [int] IDENTITY(1,1) NOT NULL,
	[idpersona] [int] NULL,
	[idsexo] [int] NULL,
	[activo] [bit] NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[detalleproducto]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalleproducto](
	[iddetalleproducto] [int] IDENTITY(1,1) NOT NULL,
	[stockactual] [int] NULL,
	[precio] [decimal](6, 2) NULL,
	[idproducto] [int] NULL,
	[stockminimo] [int] NULL,
 CONSTRAINT [PK_detalleproducto] PRIMARY KEY CLUSTERED 
(
	[iddetalleproducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[lineadeventa]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lineadeventa](
	[idlineadeventa] [int] IDENTITY(1,1) NOT NULL,
	[cantidad] [int] NULL,
	[idventa] [int] NULL,
	[precio] [decimal](18, 0) NULL,
	[iddetalleproducto] [int] NULL,
 CONSTRAINT [PK_lineadeventa] PRIMARY KEY CLUSTERED 
(
	[idlineadeventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[madera]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[madera](
	[idmadera] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](40) NULL,
 CONSTRAINT [PK_madera] PRIMARY KEY CLUSTERED 
(
	[idmadera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[persona]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[persona](
	[idpersona] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](50) NULL,
	[apellidopaterno] [varchar](50) NULL,
	[apellidomaterno] [varchar](50) NULL,
	[edad] [int] NULL,
	[dni] [char](8) NULL,
	[fechanacimiento] [date] NULL,
	[direccion] [varchar](256) NULL,
 CONSTRAINT [PK_persona] PRIMARY KEY CLUSTERED 
(
	[idpersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[presentacion]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[presentacion](
	[idpresentacion] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_presentacion] PRIMARY KEY CLUSTERED 
(
	[idpresentacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[producto]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[producto](
	[idproducto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](40) NULL,
	[descripcion] [varchar](100) NULL,
	[serie] [varchar](15) NULL,
	[idmadera] [int] NULL,
	[activo] [bit] NULL,
	[idpresentacion] [int] NULL,
	[imagen] [image] NULL,
	[codigobarras] [varchar](50) NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[idproducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[rol]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[rol](
	[idrol] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NULL,
 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[idrol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[sexo]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[sexo](
	[idsexo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NULL,
 CONSTRAINT [PK_sexo] PRIMARY KEY CLUSTERED 
(
	[idsexo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[trabajador]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[trabajador](
	[idtrabajador] [int] IDENTITY(1,1) NOT NULL,
	[nombreusuario] [varchar](50) NULL,
	[passwordusuario] [varchar](50) NULL,
	[activo] [bit] NULL,
	[idpersona] [int] NULL,
	[idrol] [int] NULL,
	[idsexo] [int] NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[idtrabajador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[venta]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venta](
	[idventa] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NULL,
	[idtrabajador] [int] NULL,
	[idcliente] [int] NULL,
	[estado] [bit] NULL,
 CONSTRAINT [PK_venta] PRIMARY KEY CLUSTERED 
(
	[idventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_cliente_persona] FOREIGN KEY([idpersona])
REFERENCES [dbo].[persona] ([idpersona])
GO
ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [FK_cliente_persona]
GO
ALTER TABLE [dbo].[cliente]  WITH CHECK ADD  CONSTRAINT [FK_cliente_sexo] FOREIGN KEY([idsexo])
REFERENCES [dbo].[sexo] ([idsexo])
GO
ALTER TABLE [dbo].[cliente] CHECK CONSTRAINT [FK_cliente_sexo]
GO
ALTER TABLE [dbo].[detalleproducto]  WITH CHECK ADD  CONSTRAINT [FK_detalleproducto_producto] FOREIGN KEY([idproducto])
REFERENCES [dbo].[producto] ([idproducto])
GO
ALTER TABLE [dbo].[detalleproducto] CHECK CONSTRAINT [FK_detalleproducto_producto]
GO
ALTER TABLE [dbo].[lineadeventa]  WITH CHECK ADD  CONSTRAINT [FK_lineadeventa_detalleproducto] FOREIGN KEY([iddetalleproducto])
REFERENCES [dbo].[detalleproducto] ([iddetalleproducto])
GO
ALTER TABLE [dbo].[lineadeventa] CHECK CONSTRAINT [FK_lineadeventa_detalleproducto]
GO
ALTER TABLE [dbo].[lineadeventa]  WITH CHECK ADD  CONSTRAINT [FK_lineadeventa_venta] FOREIGN KEY([idventa])
REFERENCES [dbo].[venta] ([idventa])
GO
ALTER TABLE [dbo].[lineadeventa] CHECK CONSTRAINT [FK_lineadeventa_venta]
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_madera] FOREIGN KEY([idmadera])
REFERENCES [dbo].[madera] ([idmadera])
GO
ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [FK_producto_madera]
GO
ALTER TABLE [dbo].[producto]  WITH CHECK ADD  CONSTRAINT [FK_producto_presentacion] FOREIGN KEY([idpresentacion])
REFERENCES [dbo].[presentacion] ([idpresentacion])
GO
ALTER TABLE [dbo].[producto] CHECK CONSTRAINT [FK_producto_presentacion]
GO
ALTER TABLE [dbo].[trabajador]  WITH CHECK ADD  CONSTRAINT [FK_trabajador_sexo] FOREIGN KEY([idsexo])
REFERENCES [dbo].[sexo] ([idsexo])
GO
ALTER TABLE [dbo].[trabajador] CHECK CONSTRAINT [FK_trabajador_sexo]
GO
ALTER TABLE [dbo].[trabajador]  WITH CHECK ADD  CONSTRAINT [FK_usuario_persona] FOREIGN KEY([idpersona])
REFERENCES [dbo].[persona] ([idpersona])
GO
ALTER TABLE [dbo].[trabajador] CHECK CONSTRAINT [FK_usuario_persona]
GO
ALTER TABLE [dbo].[trabajador]  WITH CHECK ADD  CONSTRAINT [FK_usuario_rol] FOREIGN KEY([idrol])
REFERENCES [dbo].[rol] ([idrol])
GO
ALTER TABLE [dbo].[trabajador] CHECK CONSTRAINT [FK_usuario_rol]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_cliente] FOREIGN KEY([idcliente])
REFERENCES [dbo].[cliente] ([idcliente])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_cliente]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_trabajador] FOREIGN KEY([idtrabajador])
REFERENCES [dbo].[trabajador] ([idtrabajador])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_trabajador]
GO
/****** Object:  StoredProcedure [dbo].[spInsertarCliente]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spInsertarCliente]
@parnombres varchar(50),
@parapellidopaterno varchar(50),
@parapellidomaterno varchar(50),
@pardni varchar(11),
@parfechanacimiento date,
@paridsexo int,
@pardireccion varchar(256)
as
begin

	insert into persona(nombres,apellidopaterno,apellidomaterno,dni,fechanacimiento,direccion)
	values(@parnombres,@parapellidopaterno,@parapellidomaterno,@pardni,@parfechanacimiento,@pardireccion)

	insert into cliente(idpersona,idsexo,activo)
	values(@@IDENTITY,@paridsexo,1)

end

GO
/****** Object:  StoredProcedure [dbo].[spInsertarDetalleProducto]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spInsertarDetalleProducto]
@parstockactual int,
@parprecio decimal(8,2),
@paridproducto int
as

	declare @iddetalleproducto int

	insert into detalleproducto(stockactual,precio,idproducto)
	values(@parstockactual,@parprecio,@paridproducto)

	set @iddetalleproducto=@@IDENTITY
	if @@ERROR<>0
	begin
		set @iddetalleproducto=-1
		return @iddetalleproducto

	end
return @iddetalleproducto
GO
/****** Object:  StoredProcedure [dbo].[spInsertarLineaDeVenta]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spInsertarLineaDeVenta]
@parcantidad int,
--@pariddetalleproducto int,
@paridventa int,
@parprecio decimal(18,0)
as
	declare @idlineadeventa int
	insert into lineadeventa(cantidad,idventa,precio)
	values(@parcantidad,@paridventa,@parprecio)

	set @idlineadeventa = @@IDENTITY
	if @@ERROR<>0
	begin
		set @idlineadeventa=-1
		return @idlineadeventa
	end

return @idlineadeventa

GO
/****** Object:  StoredProcedure [dbo].[spInsertarProducto]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spInsertarProducto]
@parcodigobarras varchar(50),
@parnombre varchar(50),
@pardescripcion varchar(100),
@parserie varchar(11),
@paridmadera int,
@paridpresentacion int
as
	declare @idproducto int
	insert into producto(nombre,descripcion,serie,idmadera,activo,idpresentacion,codigobarras)
	values(@parnombre,@pardescripcion,@parserie,@paridmadera,1,@paridpresentacion,@parcodigobarras)

	set @idproducto=@@IDENTITY
	if @@ERROR<>0
	begin
		set @idproducto=-1
		return @idproducto
	end
	return @idproducto

GO
/****** Object:  StoredProcedure [dbo].[spInsertarTrabajador]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spInsertarTrabajador]
@parnombres varchar(50),
@parapellidopaterno varchar(50),
@parapellidomaterno varchar(50),
@pardni varchar(11),
@parnombreusuario varchar(20),
@parpasswordusuario varchar(20),
@paridrol int,
@parfechanacimiento date,
@paridsexo int
as
begin
	insert into persona(nombres,apellidopaterno,apellidomaterno,dni,fechanacimiento)
	values(@parnombres,@parapellidopaterno,@parapellidomaterno,@pardni,@parfechanacimiento)

	insert into trabajador(nombreusuario,passwordusuario,idpersona,activo,idrol,idsexo)
	values(@parnombreusuario,@parpasswordusuario,@@IDENTITY,1,@paridrol,@paridsexo)
end

GO
/****** Object:  StoredProcedure [dbo].[spInsertarVenta]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spInsertarVenta]
@parfecha date,
@paridtrabajador int,
@paridcliente int
as
	declare @idventa int
	insert into venta(fecha,idtrabajador,idcliente,estado)
	values(@parfecha,@paridtrabajador,@paridcliente,1)

	set @idventa = @@IDENTITY
	if @@ERROR<>0
	begin
		set @idventa=-1
		return @idventa
	end

return @idventa
GO
/****** Object:  StoredProcedure [dbo].[spListarClientes]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spListarClientes]
as
begin
	select
		c.idcliente,
		p.nombres as nombres,
		p.apellidopaterno as apellidopaterno,
		p.apellidomaterno as apellidomaterno,
		p.dni,
		p.direccion
	from cliente c 
	inner join persona p on
	(p.idpersona=c.idpersona)


end

GO
/****** Object:  StoredProcedure [dbo].[spListarMaderas]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spListarMaderas]
as
begin
	select 
		m.idmadera,
		m.nombre
	from madera m with(nolock)

end

GO
/****** Object:  StoredProcedure [dbo].[spListarPresentacion]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spListarPresentacion]
as
begin
	select 
		p.idpresentacion,
		p.nombre
	from presentacion p with(nolock)

end

GO
/****** Object:  StoredProcedure [dbo].[spListarProductos]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spListarProductos]
as
begin
	select
		pr.codigobarras,
		pr.nombre,
		pr.descripcion,
		m.nombre as tipomadera,
		p.nombre as presentacion,
		dp.precio,
		dp.stockactual

	from producto pr
	inner join madera m on
	(pr.idmadera=m.idmadera)
	inner join presentacion p on
	(pr.idpresentacion=p.idpresentacion)
	inner join detalleproducto dp on
	(dp.idproducto=pr.idproducto)


end

GO
/****** Object:  StoredProcedure [dbo].[spListarRol]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spListarRol]
as
begin

	select 
		r.idrol,
		r.nombre
	from rol r

end

GO
/****** Object:  StoredProcedure [dbo].[spListarSexos]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spListarSexos]
as
begin
	select
		s.idsexo,
		s.nombre
	from sexo s

end

GO
/****** Object:  StoredProcedure [dbo].[spListarTrabajadores]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spListarTrabajadores]
as
begin

	select top 30
		t.idtrabajador as id,
		p.nombres as nombres,
		p.apellidopaterno as apellidopaterno,
		p.apellidomaterno as apellidomaterno,
		p.dni as dni,
		r.nombre as rol
	from persona p
	inner join trabajador t
	on(p.idpersona=t.idpersona)
	inner join rol r
	on(t.idrol=r.idrol)

end

GO
/****** Object:  StoredProcedure [dbo].[spVerificarAcceso]    Script Date: 10/07/2018 18:59:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spVerificarAcceso]
@parusuario varchar(50),
@parpassword varchar(50)
as
begin
	select
		t.idtrabajador,
		t.nombreusuario,
		t.passwordusuario,
		t.activo,
		p.nombres,
		p.apellidopaterno,
		p.apellidomaterno,
		r.nombre

	from trabajador t 
	inner join persona p
	on(t.idpersona=p.idpersona)
	inner join rol r
	on(t.idrol=r.idrol)
	where t.nombreusuario=@parusuario and t.passwordusuario=@parpassword 


end

GO
