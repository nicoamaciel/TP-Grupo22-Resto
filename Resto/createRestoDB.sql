Create Database RestoDB
GO
Use RestoDB
GO

Create Table Empleados(
	IDEmpleado int not null primary key identity(1,1), 
	Codigo varchar (50) not null,
	Descripcion	varchar (50) null,
	Turno int not null,
	sueldo money not null,
	Cargo varchar(150) not null,
	Nombre varchar (50) not null,
	Apellido varchar (50) not null,
	Dni int not null,
	Activo BIT not null default (0)
)

GO
Create Table Reserva(
	IDReserva int not null primary key identity(1,1), 
	IDMesa int not null,
	HoraReserva datetime not null,
	CodigoReserva int not null,
	Comentario varchar (100) null,
	CantidadClientes int not null
)
GO

Create Table Mesa(
	IdMesa int not null primary key identity(1,1), 
	TamañoMesa int not null,
	Descripcion	varchar (100) null
)

GO
Create Table Menu(
	IDPlato int not null primary key identity(1,1),
	TipoPlato varchar (100),
	Precio money not null,
	UrlImagen varchar (200) null,
	Descripcion	varchar (100) null,
	Clase varchar(100) not null
)

GO
Create Table Bebidas(
	IDBebida int not null primary key identity(1,1),
	Precio money not null,
	TipoBebida	Decimal not null,
	Descripcion	Varchar (150) null
)

GO
Create Table Pedidos(
	IDPedido int not null primary key identity(1,1),
	IDMesa int not null,
	IDPlato int NULL,
	IDBebida int null,
	Cuenta money null,
)

-- Restricciones Resto - Empleados

Go

Alter Table Empleados
Add Constraint CHK_Sueldo_Positivo Check(sueldo > 0)
go

Alter Table Empleados
Add Constraint UQ_Codigo Unique(Codigo)
go

-- Restricciones Resto - Reserva

Alter Table Reserva
Add Constraint FK_Mesa_Reserva Foreign Key (IDMesa) References Mesa(IDMesa)
Go

Alter Table Reserva
Add Constraint CHK_Cantidad_Positivo Check(CantidadClientes > 0)
go

-- Restricciones Resto - Mesa

Alter Table Mesa
Add Constraint CHK_Tamaño_Positivo Check(TamañoMesa > 0)
go

-- Restricciones Resto - Menu

Alter Table Menu
Add Constraint CHK_Precio_Positivo Check(Precio > 0)
go

-- Restricciones Resto - Bebidas

Alter Table Bebidas
Add Constraint CHK_PrecioBebida_Positivo Check(Precio > 0)
go

Alter Table Bebidas
Add Constraint CHK_TipoBebida_Positivo Check(TipoBebida > 0)
go

-- Restricciones Resto - Pedidos

Alter Table Pedidos
Add Constraint FK_Mesa_Pedidos Foreign Key (IDMesa) References Mesa(IDMesa)
Go


Alter Table Pedidos
Add Constraint FK_Bebidas_Pedidos Foreign Key (IDBebida) References Bebidas(IDBebida)
Go

Alter Table Pedidos
Add Constraint CHK_Cuenta_Positiva Check(Cuenta > 0)
go

