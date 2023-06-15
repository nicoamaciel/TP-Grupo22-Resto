Use Master
Use RestoDB

Set DateFormat 'YMD'

INSERT INTO Bebidas (Precio, TipoBebida, Descripcion) VALUES
(300, 600, 'Agua 600cm3'),
(400, 600, 'Soda 600cm3'),
(700, 600, 'Gaseosa 600cm3'),
(600, 600, 'Saborizada 600cm3'),
(1400, 1000, 'Jara jugo 1lts'),
(1500, 1000, 'Jara Cerveza 1lts'),
(2000, 1000, 'Vino 1lts');

INSERT INTO Empleados ( Codigo, Descripcion,Turno,sueldo,Cargo,Nombre, Apellido, Dni) VALUES
('A001', 'Administrador', 01, 500000,'Gerente','Miguel','Jefazo' , 16258752),
('C001', 'Cocina', 01, 300000,'Cocinero','Roberto','Galati' , 18028282),
('M001', 'Mesero', 01, 200000,'MesaGral','Lucas','Rodriguez' , 25151562),
('G001', 'Encargado', 01, 300000,'EncargadoMesa','German','Beder' , 98257722),
('M002', 'Mesera', 01, 200000,'MesaGral','Erica','Sanchez' , 56257722);


INSERT INTO Menu (TipoPlato, Precio, UrlImagen,Descripcion,Clase) VALUES
('EntradaFria',2000,'https://www.baenegocios.com/__export/1669410756753/sites/cronica/img/2022/11/25/picada_1.jpg_966076397.jpg','Picada 2 personas','Entrada'),
('EntradaFria',2500,'https://images-ext-2.discordapp.net/external/vfm-u0JrLoZbVlwLS_dm_KlxByo6aiWDeuNHBIjY_iI/https/vitto.com.ar/wp-content/uploads/2022/08/DSC02310-copia-900x900.jpg?width=469&height=469 ','Picada 4 personas','Entrada'),
('EntradaCaliente',3000,' ','Picada de Mar','Entrada'),
('EntradaCaliente',1000,' ','Picada vegeterina','Entrada'),
('PlatoCaliente',4000,' ','Pastel de papas','Principal'),
('PlatoCaliente',3000,'','Pizza','Principal'),
('PlatoCaliente',5000,'','Milanesa','Principal'),
('PlatoCaliente',7000,'','Empanadas','Principal'),
('Postre',1500,'','Helado','Postre'),
('Postre',1800,'','Flan','Postre'),
('Postre',500,'','Panqueques','Postre');

INSERT INTO Mesa(TamañoMesa, Descripcion) VALUES
(2,'Dos personas ventana'),
(2,'Dos personas centro'),
(4,'Cuatro personas'),
(4,'Cuatro personas ventana'),
(6,'Seis personas ventana'),
(8,'Ocho personas centro');


