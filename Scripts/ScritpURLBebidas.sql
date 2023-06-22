--Url faltantes entradas
GO
Update Menu set UrlImagen = 'https://live.staticflickr.com/3401/3307181757_687fa55f2f_b.jpg' where IDPlato=3
update Menu set UrlImagen = 'https://latablita.com.ar/wp-content/uploads/2020/09/tabla-vegetariana-1.jpg' where IDPlato=4
GO

--url bebidas

ALTER TABLE dbo.Bebidas
ADD Urlbebida VARCHAR(200) NULL;

select * from Bebidas

--Agua600
Update Bebidas set Urlbebida = 'https://statics.dinoonline.com.ar/imagenes/full_600x600_ma/3040004_f.jpg' where IDBebida=1
--Soda600
Update Bebidas set Urlbebida = 'https://vixark.b-cdn.net/lp-i-i-g/agua-con-gas-cristal-600ml.jpg' where IDBebida=2
--Gaseosa600
Update Bebidas set Urlbebida = 'https://images.ssstatic.com/coca-cola-600cm3-x-12u-precio-por-pallet-12-16398310.jpg' where IDBebida=3
--AguaSaborizada600
Update Bebidas set Urlbebida = 'https://jrdistribution.com.ar/wp-content/uploads/2018/10/levite-600-justo.jpg' where IDBebida=4
--JaraJugo
Update Bebidas set Urlbebida = 'https://www.rebanando.com/uploads/media/dieta-de-la-limonada-4.jpg?1391967904' where IDBebida=5
--JaraCerveza
Update Bebidas set Urlbebida = 'https://www.beersandtrips.com/wp-content/uploads/2018/08/historia_cerveza.jpg' where IDBebida=6
--JaraVino
Update Bebidas set Urlbebida = 'https://img.freepik.com/fotos-premium/arreglo-copas-jarra-vino-vista-frontal_23-2148401046.jpg' where IDBebida=7

