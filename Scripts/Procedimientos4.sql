use RestoDB
--Procedimientos MESA
SELECT *from Menu
EXEC SP_MenuMostrarClase 'Entrada';
EXEC SP_MesasMesero 3
go
--buscar las meseas del mesero
SP_MesasMesero @ID=7
GO
ALTER PROCEDURE SP_MesasMesero(
@id int
)
as BEGIN
    SELECT M.idmesa,M.Activo,M.Descripcion,TamañoMesa,M.IDMesero,E.Turno,E.Dni,E.Nombre,E.Cargo,E.Apellido FROM Mesa M
LEFT JOIN Empleados E ON E.IDEmpleado = M.IDMesero AND E.Activo = 0
WHERE (M.IDMesero = @id OR M.IDMesero IS NULL) AND M.Activo = 0
END
go
create PROCEDURE SP_MesasUnica(
@id int
)
as BEGIN
    SELECT M.idmesa,M.Activo,M.Descripcion,TamañoMesa,M.IDMesero,E.Turno,E.Dni,E.Nombre,E.Cargo,E.Apellido FROM Mesa M
LEFT JOIN Empleados E ON E.IDEmpleado = M.IDMesero AND E.Activo = 0
WHERE M.IdMesa = @id
END
go
--buscar todas las mesas 
ALTER PROCEDURE SP_MesasAdmin
as BEGIN
    SELECT idmesa,M.Activo,M.Descripcion,TamañoMesa,IDEmpleado,E.Dni,E.Nombre,E.Apellido,E.Cargo,e.Turno,e.Activo,m.Activo 'EN servicio' from Mesa M
    left JOIN Empleados E ON e.IDEmpleado=M.IDMesero
END
GO
--crear mesas
create PROCEDURE SP_MesasNueva(
	@TamañoMesa int,
    @Descripcion VARCHAR(100),
    @IDMesero INT
)
as BEGIN
    INSERT INTO Mesa (TamañoMesa, Descripcion, IDMesero) VALUES
                        (@TamañoMesa, @Descripcion, @IDMesero)
END
go
--suspender mesa 
create PROCEDURE SP_EliminarMesa(
    @id int
)
as BEGIN
    update Mesa set Activo=1 WHERE IdMesa=@id
END
go
--Modificar mesa
alter PROCEDURE SP_ModificarMesa(
    @IdMesa INT,
	@TamañoMesa int,
	@Descripcion	VARCHAR(100),
	@IDMesero	int,
    @activo BIT
)
as BEGIN
    update Mesa set TamañoMesa=@TamañoMesa, Descripcion=@Descripcion,IDMesero=@IDMesero,Activo=@activo WHERE IdMesa=@idmesa
END
GO
--Procedimientos Pedido
--Procedimientos Pedido nuevo
ALTER PROCEDURE SP_PedidoMostar(
    @idmesa int
)
as BEGIN
    SELECT IDPedido,IDMesa,P.IDPlato,IDEmpleado,fecha, M.Clase,M.Descripcion as 'Descripcion Comida',M.Precio AS 'Precio Comida',p.IDBebida,b.TipoBebida,B.Descripcion as'Descripcion Bebidas',B.Precio as 'Precio Bebidas',P.Cuenta, activo from Pedidos P 
    INNER JOIN Bebidas B on b.IDBebida=p.IDBebida
    INNER JOIN Menu M ON M.IDPlato=P.IDPlato
    where Activo=0 AND IDMesa=@idmesa
END
go
--pedido cancelar
create PROCEDURE SP_PedidoCancelar(
    @idpedido INT
)
AS BEGIN
    DELETE from Pedidos WHERE IDPedido=@idpedido
END
go
create PROCEDURE SP_PedidoCancelarTodo(
    @idmesa INT
)
AS BEGIN
    DELETE from Pedidos WHERE IdMesa=@idmesa
END
go
--pedidos pagados
create PROCEDURE SP_PedidoPagado(
    @idmesa INT
)
AS BEGIN
    update Pedidos set Activo=1 WHERE IDMesa=@idmesa AND Activo=0
END
go
--pedidos Modificar
create PROCEDURE SP_PedidoModificar(
    @idpedido INT,
    @IDBebida int,
    @IDPlato INT,
    @cuenta money
)
AS BEGIN
    update Pedidos set IDBebida=@IDBebida,IDPlato=@IDPlato,Cuenta=@cuenta WHERE IDPedido=@idpedido
END
go
--Procedimientos Pedido nuevo
ALTER PROCEDURE SP_PedidoNuevo(
@idmesa int,
@idplato int,
@idbebida int,
@cuenta money,
@idempleado INT
)
as BEGIN
    INSERT INTO Pedidos (IDMesa,IDEmpleado,IDBebida,IDPlato,Cuenta) VALUES
                        (@idmesa,@idempleado,@idbebida, @idplato, @cuenta)
END
go
--Procedimientos BEBIDAS
--mostrar BEBIDAS
create PROCEDURE SP_BebidasMostrar
as BEGIN
    SELECT *FROM Bebidas
END
go
create PROCEDURE SP_BebidaMostrar(
    @id INT
)
as BEGIN
    SELECT *FROM Bebidas WHERE IDBebida=@id
END
go
--crear BEBIDAS
create PROCEDURE SP_BebidasNueva(
	@Precio money,
	@TipoBebida	Decimal,
	@Descripcion	Varchar(150),
    @url VARCHAR(200)
)
as BEGIN
    INSERT INTO Bebidas (Precio, TipoBebida, Descripcion,UrlImagen) VALUES
                        (@Precio, @TipoBebida, @Descripcion,@url)
END
go 
--borrar BEBIDAS
create PROCEDURE SP_EliminarBebida(
    @id int
)
as BEGIN
    delete FROM Bebidas WHERE IDBebida=@id
END
go
--Modificar BEBIDAS
create PROCEDURE SP_BebidasModificar(
    @id INT,
	@Precio money,
	@TipoBebida	Decimal,
	@Descripcion	Varchar(150),
    @url VARCHAR
)
as BEGIN
    update Bebidas set Precio=@Precio, TipoBebida=@TipoBebida, Descripcion=@Descripcion,UrlImagen=@url WHERE IDBebida=@id
END
go

--Procedimientos Reserva
--crear Reserva
create PROCEDURE SP_ReservaNueva(
	@IDMesa int,
	@HoraReserva datetime,
	@CodigoReserva int,
	@Comentario varchar(200),
	@CantidadClientes int
    )
    as BEGIN
insert into Reserva (IDMesa,HoraReserva,CodigoReserva,Comentario,CantidadClientes)
        VALUES(@IDMesa,@HoraReserva, @CodigoReserva,@Comentario,@CantidadClientes)
END
GO
--BORRAR Reserva
create PROCEDURE SP_ReservaCancelar(
    @CodigoReserva INT
)
    as BEGIN
    delete from Reserva WHERE CodigoReserva=@CodigoReserva
END

--MODIFICAR Reserva
GO
ALTER PROCEDURE SP_ReservarModificar(
    @IDMesa int,
	@HoraReserva datetime,
	@CodigoReserva int,
	@Comentario varchar(200),
	@CantidadClientes int
    )
    as BEGIN
update Reserva set IDMesa=@IDMesa,HoraReserva=@HoraReserva,Comentario=@Comentario,CantidadClientes=@CantidadClientes WHERE CodigoReserva=@CodigoReserva
END
GO

--MOSTRAR
create PROCEDURE SP_ReservaMostrar(
    @idmesa INT,
    @hora DATETIME
)
as BEGIN
 select *from [Reserva] WHERE IDMesa=@idmesa AND HoraReserva=@hora
END
GO
create PROCEDURE SP_ReservaMostrarTodo
as BEGIN
 select *from Reserva
END
GO
----Procedimientos Login
create PROCEDURE SP_LoginModificar(
    @id int,
    @user VARCHAR(150),
    @Contraseña VARCHAR(150),
    @NivelAcceso INT
)
as BEGIN
 UPDATE [LOGIN] SET Usuario=@user,Contraseña=@Contraseña,NivelAcceso=@NivelAcceso WHERE IDuser=@id
END
GO
--MOSTRAR
ALTER PROCEDURE SP_LoginMostrar
as BEGIN
 select *from [LOGIN] L
END
GO

----Procedimientos Menu
--CREAR MENU
create PROCEDURE SP_MenuNuevo(
    	@TipoPlato varchar(150) ,
	@Precio money ,
	@UrlImagen varchar(200),
	@Descripcion	varchar(150),
	@Clase varchar(150)
    )
    as BEGIN
    insert into Menu (TipoPlato,Precio,UrlImagen,Descripcion,Clase)
        VALUES(@TipoPlato, @Precio,@UrlImagen,@Descripcion,@Clase)
END
go

--MODIFICAR MENU
create PROCEDURE SP_MenuModificar(
    @id INT,
    @TipoPlato varchar(150) ,
	@Precio money ,
	@UrlImagen varchar(150),
	@Descripcion	varchar(150),
	@Clase varchar(150)
    )
    as BEGIN
    update  Menu set TipoPlato=@TipoPlato,Precio=@Precio,UrlImagen=@UrlImagen,Descripcion=@Descripcion,Clase=@Clase WHERE IDPlato=@id
END
go

--ELIMIANR MENU
create PROCEDURE SP_MenuEliminar(
    @id INT
)
    as BEGIN
    delete  Menu WHERE IDPlato=@id
END
GO
--MOSTRAR TODO
alter PROCEDURE SP_MenuMostrar
as BEGIN
    SELECT *FROM Menu
END
go

create PROCEDURE SP_MenuID(
    @id INT
)
as BEGIN
    SELECT *FROM Menu WHERE IDPlato=@id
END
go
--MOSTRAR POR CLASE DE COMIDA
create PROCEDURE SP_MenuMostrarClase(
    @clase VARCHAR(150)
)
as BEGIN
    SELECT *FROM Menu WHERE Clase=@clase
END
GO

GO
SELECT *FROM Menu WHERE Clase='Entrada'
GO
--PORCEDIMIENTOS DE EMPLEADO
--MOSTRAR EMPLEADO
create PROCEDURE SP_EmpleadosMostrar
as BEGIN
SELECT *from Empleados
END
GO
--
create PROCEDURE SP_EmpleadosMostrarID(
    @ID INT
)
as BEGIN
SELECT *from Empleados WHERE IDEmpleado=@ID
END
GO
--Eliminar EMPLEADO
create PROCEDURE SP_EmpleadosEliminar(
    @id INT
)
as BEGIN
    DELETE from Empleados WHERE IDEmpleado=@id
END
go
--MOSTRAR EMPLEADO
create PROCEDURE SP_EmpleadosModificar(
    @id INT,
    @cargo varchar(150),
    @sueldo money,
    @Turno INT
)
as BEGIN
    update Empleados set  Cargo=@cargo,sueldo=@sueldo,Turno=@Turno WHERE IDEmpleado=@id
END
GO
--NUEVO EMPLEADO
ALTER PROCEDURE SP_EmpleadosNuevo(
    @cargo varchar(150),
    @sueldo money,
    @Turno INT,
    @nombre VARCHAR(150),
    @apellido VARCHAR(150),
    @codigo VARCHAR(150),
    @dni INT
)
as BEGIN
    insert into Empleados (Cargo ,sueldo ,Turno ,Nombre ,Apellido ,Codigo ,Dni)
                VALUES(@cargo ,@sueldo ,@Turno ,@nombre ,@apellido ,@codigo ,@dni )
END
GO
ALTER PROCEDURE SP_EmpleadosMeseros(
    @Turno INT
)
as BEGIN
    IF(@Turno<3)
        BEGIN
            SELECT *FROM Empleados WHERE Cargo='Mesero' AND Turno=@Turno
        END
    ELSE
        BEGIN
            SELECT *FROM Empleados WHERE Cargo='Mesero'
        END
END

Select IDPlato,TipoPlato,Descripcion,Clase,UrlImagen,Precio FROM MENU