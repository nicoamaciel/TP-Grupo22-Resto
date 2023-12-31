use RestoDB
GO
DROP DATABASE RestoDB;
GO
--Url faltantes entradas
GO
Update Menu set UrlImagen = 'https://live.staticflickr.com/3401/3307181757_687fa55f2f_b.jpg' where IDPlato=3
update Menu set UrlImagen = 'https://latablita.com.ar/wp-content/uploads/2020/09/tabla-vegetariana-1.jpg' where IDPlato=4
GO

--url bebidas
ALTER TABLE dbo.Bebidas
ADD UrlImagen VARCHAR(200) NULL;
--nuevos datos mesas
Update Mesa set IdMesero = 3 where IdMesa=1
Update Mesa set idmesero = 3 where IdMesa=2
Update Mesa set IdMesero = 3 where IdMesa=3
Update Mesa set idmesero = 5 where IdMesa=4
Update Mesa set IdMesero = 5 where IdMesa=5
Update Mesa set idmesero = 5 where IdMesa=6
--Agua600
Update Bebidas set UrlImagen = 'https://statics.dinoonline.com.ar/imagenes/full_600x600_ma/3040004_f.jpg' where IDBebida=1
--Soda600
Update Bebidas set UrlImagen = 'https://vixark.b-cdn.net/lp-i-i-g/agua-con-gas-cristal-600ml.jpg' where IDBebida=2
--Gaseosa600
Update Bebidas set UrlImagen = 'https://images.ssstatic.com/coca-cola-600cm3-x-12u-precio-por-pallet-12-16398310.jpg' where IDBebida=3
--AguaSaborizada600
Update Bebidas set UrlImagen = 'https://jrdistribution.com.ar/wp-content/uploads/2018/10/levite-600-justo.jpg' where IDBebida=4
--JaraJugo
Update Bebidas set UrlImagen = 'https://www.rebanando.com/uploads/media/dieta-de-la-limonada-4.jpg?1391967904' where IDBebida=5
--JaraCerveza
Update Bebidas set UrlImagen = 'https://www.beersandtrips.com/wp-content/uploads/2018/08/historia_cerveza.jpg' where IDBebida=6
--JaraVino
Update Bebidas set UrlImagen = 'https://img.freepik.com/fotos-premium/arreglo-copas-jarra-vino-vista-frontal_23-2148401046.jpg' where IDBebida=7


-------------------Urls platos principales
Update Menu set UrlImagen = 'https://www.recetasnatura.com.ar/sites/default/files/styles/receta_cuerpo/public/pastel_de_papa_y_soja.jpg?itok=aEABz-M3' where IDPlato=5
Update Menu set UrlImagen = 'https://hazlovegan.com/wp-content/uploads/2021/01/pizza-napoletana-vegana-3.jpg' where IDPlato = 6
Update Menu set UrlImagen = 'https://cdn0.recetasgratis.net/es/posts/5/0/1/milanesa_napolitana_con_pure_76105_orig.jpg' where IDPlato = 7
Update Menu set UrlImagen = 'https://i.blogs.es/58e525/como-hacer-masa-para-empanadas-fritas-1-/1366_2000.jpg' where IDPlato = 8

------------------Update jarra falta de ortografia
Update Bebidas set Descripcion = 'JarraJugo 1lts' where IDBebida=5
Update Bebidas set Descripcion = 'JarraCerveza 1lts' where IDBebida=6
Update Bebidas set Descripcion = 'JarraVino 1lts' where IDBebida=7
select * from Bebidas

-------------------Urls postre
Update Menu set UrlImagen = 'https://glassandservice.com/media/catalog/product/cache/be7bf90a371cf13c97562dc8f140e142/c/o/copa-helado-primavera.jpg' where IDPlato = 9

Update Menu set UrlImagen = 'https://www.recetasnestle.com.mx/sites/default/files/styles/recipe_detail_desktop/public/srh_recipes/54c6cbcbc6d611e056122d64560cd9c1.jpg?itok=Ekj0Kgv-' where IDPlato = 10

Update Menu set UrlImagen = 'https://img-global.cpcdn.com/recipes/8189667259ba87b9/400x400cq70/photo.jpg' where IDPlato = 11

select * from Menu
go
SELECT *FROM Empleados
go

-- Triggers EMPLEADOS

create TRIGGER TRG_CrearLogin
ON Empleados
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Dni INT, @Cargo VARCHAR(50), @NivelAcceso INT,@id INT

    SELECT @Dni = Dni, @Cargo = Cargo, @id=IDEmpleado
    FROM inserted

    IF @Cargo IN ('Administrador', 'Encargado')
        SET @NivelAcceso = 1
    ELSE IF @Cargo = 'Cocina'
        SET @NivelAcceso = 2
    ELSE IF @Cargo = 'Mesero'
        SET @NivelAcceso = 3
        ELSE 
    INSERT INTO LOGIN (Usuario, Contraseña, NivelAcceso, IDuser)
    VALUES (CAST(@Dni AS VARCHAR(150)), CAST(@Dni AS VARCHAR(50)), @NivelAcceso,@id)
END
go
create TRIGGER TRG_ELIMINAR
ON Empleados
INSTEAD  of DELETE
As
BEGIN 
    DECLARE @IDEmpleado int
    DECLARE @dni VARCHAR(150)
    select @IDEmpleado=IDEmpleado, @dni=Dni FROM deleted
    IF EXISTS(select 1 from Empleados where IDEmpleado=IDEmpleado AND Activo=1)
        BEGIN
            UPDATE Mesa set IDMesero=null WHERE IDMesero=@IDEmpleado
            delete from LOGIN WHERE Usuario=@dni 
            DELETE from Empleados WHERE IDEmpleado=@IDEmpleado
            end
    ELSE
    BEGIN
        update Empleados SET Activo=1 WHERE IDEmpleado=@IDEmpleado 
        END
end
GO
