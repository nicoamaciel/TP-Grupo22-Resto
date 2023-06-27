use RestoDB
--Procedimientos MESA
EXEC SPMesasMesero @Dni='25151562';
go
--buscar las meseas del mesero
create PROCEDURE SP_MesasMesero(
@id int
)
as BEGIN
    SELECT M.idmesa,M.Activo,M.Descripcion,TamañoMesa,E.Dni,E.Nombre,E.Cargo,E.Apellido FROM Mesa M
LEFT JOIN Empleados E ON E.IDEmpleado = M.IDMesero AND E.Activo = 0
WHERE (M.IDMesero = @id OR M.IDMesero IS NULL) AND M.Activo = 0
END
go
--buscar todas las mesas 
create PROCEDURE SP_MesasAdmin
as BEGIN
    SELECT idmesa,M.Activo,M.Descripcion,TamañoMesa,E.Dni,E.Nombre,E.Apellido,E.Cargo,e.Activo 'EN servicio' from Mesa M
    INNER JOIN Empleados E ON e.IDEmpleado=M.IDMesero
END
GO
--crear mesas
CREATE PROCEDURE SP_MesasNueva(
	@TamañoMesa int,
    @Descripcion VARCHAR,
    @IDMesero INT
)
as BEGIN
    INSERT INTO Mesa (TamañoMesa, Descripcion, IDMesero) VALUES
                        (@TamañoMesa, @Descripcion, @IDMesero)
END
go
--suspender mesa 
CREATE PROCEDURE SP_EliminarMesa(
    @id int
)
as BEGIN
    update Mesa set Activo=1 WHERE IdMesa=@id
END
go
--Modificar mesa
CREATE PROCEDURE SP_ModificarMesa(
    @id INT,
	@TamañoMesa VARCHAR,
	@Descripcion	Decimal,
	@IDMesero	Varchar,
    @activo BIT
)
as BEGIN
    update Mesa set TamañoMesa=@TamañoMesa, Descripcion=@Descripcion,IDMesero=@IDMesero,Activo=@activo WHERE IdMesa=@id
END
go

--Procedimientos Pedido
--Procedimientos Pedido nuevo
CREATE PROCEDURE SP_PedidoMostar(
@idmesa int
)
as BEGIN
    SELECT IDPedido,IDMesa,IDPlato,IDBebida,Cuenta, activo from Pedidos P 
    where Activo=0 AND IDMesa=@idmesa
END
go
--pedido cancelar
CREATE PROCEDURE SP_PedidoCancelar(
    @idpedido INT
)
AS BEGIN
    DELETE from Pedidos WHERE IDPedido=@idpedido
END
go
--pedidos pagados
CREATE PROCEDURE SP_PedidoPagado(
    @idmesa INT
)
AS BEGIN
    update Pedidos set Activo=1 WHERE IDMesa=@idmesa AND Activo=0
END
go
--Procedimientos Pedido nuevo
create PROCEDURE SP_PedidoNuevo(
@idmesa int,
@idplato int,
@idbebida int,
@cuenta money
)
as BEGIN
    INSERT INTO Pedidos (IDMesa,IDBebida,IDPlato,Cuenta) VALUES
                        (@idmesa,@idbebida, @idplato, @cuenta)
END
go
--Procedimientos BEBIDAS
--mostrar BEBIDAS
CREATE PROCEDURE SP_BebidasMostrar
as BEGIN
    SELECT *FROM Bebidas
END
go
--crear BEBIDAS
CREATE PROCEDURE SP_BebidasNueva(
	@Precio money,
	@TipoBebida	Decimal,
	@Descripcion	Varchar,
    @url VARCHAR
)
as BEGIN
    INSERT INTO Bebidas (Precio, TipoBebida, Descripcion,UrlImagen) VALUES
                        (@Precio, @TipoBebida, @Descripcion,@url)
END
go 
--borrar BEBIDAS
CREATE PROCEDURE SP_EliminarBebida(
    @id int
)
as BEGIN
    delete FROM Bebidas WHERE IDBebida=@id
END
go
--Modificar BEBIDAS
CREATE PROCEDURE SP_BebidasModificar(
    @id INT,
	@Precio money,
	@TipoBebida	Decimal,
	@Descripcion	Varchar,
    @url VARCHAR
)
as BEGIN
    update Bebidas set Precio=@Precio, TipoBebida=@TipoBebida, Descripcion=@Descripcion,UrlImagen=@url WHERE IDBebida=@id
END
go

--Procedimientos Reserva
--crear Reserva
CREATE PROCEDURE SP_ReservaNueva(
	@IDMesa int,
	@HoraReserva datetime,
	@CodigoReserva int,
	@Comentario varchar,
	@CantidadClientes int
    )
    as BEGIN
insert into Reserva (IDMesa,HoraReserva,CodigoReserva,Comentario,CantidadClientes)
        VALUES(@IDMesa,@HoraReserva, @CodigoReserva,@Comentario,@CantidadClientes)
END
GO
--BORRAR Reserva
CREATE PROCEDURE SP_ReservaCancelar(
    @CodigoReserva INT
)
    as BEGIN
    delete from Reserva WHERE CodigoReserva=@CodigoReserva
END
--MODIFICAR Reserva
GO
CREATE PROCEDURE SP_ReservarModificar(
    @IDMesa int,
	@HoraReserva datetime,
	@CodigoReserva int,
	@Comentario varchar,
	@CantidadClientes int
    )
    as BEGIN
update Reserva set IDMesa=@IDMesa,HoraReserva=@HoraReserva,Comentario=@Comentario,CantidadClientes=@CantidadClientes WHERE CodigoReserva=@CodigoReserva
END
GO
--MOSTRAR
CREATE PROCEDURE SP_ReservaMostrar(
    @idmesa INT,
    @hora DATETIME
)
as BEGIN
 select *from [Reserva] WHERE IDMesa=@idmesa AND HoraReserva=@hora
END
GO

----Procedimientos Login
CREATE PROCEDURE SP_LoginModificar(
    @id int,
    @user VARCHAR,
    @Contraseña VARCHAR,
    @NivelAcceso INT
)
as BEGIN
 UPDATE [LOGIN] SET Usuario=@user,Contraseña=@Contraseña,NivelAcceso=@NivelAcceso WHERE IDuser=@id
END
GO
--MOSTRAR
CREATE PROCEDURE SP_LoginMostrar(
    @user VARCHAR,
    @Contraseña VARCHAR
)
as BEGIN
 select *from [LOGIN] L
 INNER JOIN Empleados E on E.IDEmpleado=L.IDuser
 WHERE L.Usuario=@user AND L.Contraseña=@Contraseña
END
GO

----Procedimientos Menu
--CREAR MENU
CREATE PROCEDURE SP_MenuNuevo(
    	@TipoPlato varchar ,
	@Precio money ,
	@UrlImagen varchar,
	@Descripcion	varchar,
	@Clase varchar
    )
    as BEGIN
    insert into Menu (TipoPlato,Precio,UrlImagen,Descripcion,Clase)
        VALUES(@TipoPlato, @Precio,@UrlImagen,@Descripcion,@Clase)
END
go
--MODIFICAR MENU
CREATE PROCEDURE SP_MenuModificar(
    @id INT,
    @TipoPlato varchar ,
	@Precio money ,
	@UrlImagen varchar,
	@Descripcion	varchar,
	@Clase varchar
    )
    as BEGIN
    update  Menu set TipoPlato=@TipoPlato,Precio=@Precio,UrlImagen=@UrlImagen,Descripcion=@Descripcion,Clase=@Clase WHERE IDPlato=@id
END
go
--ELIMIANR MENU
CREATE PROCEDURE SP_MenuEliminar(
    @id INT
)
    as BEGIN
    delete  Menu WHERE IDPlato=@id
END
GO
--MOSTRAR TODO
CREATE PROCEDURE SP_MenuMostrar
as BEGIN
    SELECT *FROM Menu
END
go
--MOSTRAR POR CLASE DE COMIDA
CREATE PROCEDURE SP_MenuMostrarClase(
    @clase VARCHAR
)
as BEGIN
    SELECT *FROM Menu WHERE Clase=@clase
END
GO
--PORCEDIMIENTOS DE EMPLEADO
--MOSTRAR EMPLEADO
CREATE PROCEDURE SP_EmpleadosMostrar
as BEGIN
SELECT *from Empleados
END
GO
--
CREATE PROCEDURE SP_EmpleadosMostrarID(
    @ID INT
)
as BEGIN
SELECT *from Empleados WHERE IDEmpleado=@ID
END
GO
--Eliminar EMPLEADO
CREATE PROCEDURE SP_EmpleadosEliminar(
    @id INT
)
as BEGIN
    DELETE from Empleados WHERE IDEmpleado=@id
END
go
--MOSTRAR EMPLEADO
CREATE PROCEDURE SP_EmpleadosModificar(
    @id INT,
    @cargo varchar,
    @sueldo money,
    @Turno INT
)
as BEGIN
    update Empleados set  Cargo=@cargo,sueldo=@sueldo,Turno=@Turno WHERE IDEmpleado=@id
END
GO
--NUEVO EMPLEADO
CREATE PROCEDURE SP_EmpleadosNuevo(
    @id INT,
    @cargo varchar,
    @sueldo money,
    @Turno INT,
    @nombre VARCHAR,
    @apellido VARCHAR,
    @codigo VARCHAR,
    @dni INT
)
as BEGIN
    insert into Empleados (Cargo ,sueldo ,Turno ,Nombre ,Apellido ,Codigo ,Dni)
                VALUES(@cargo ,@sueldo ,@Turno ,@nombre ,@apellido ,@codigo ,@dni )
END