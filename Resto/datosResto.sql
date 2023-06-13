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

INSERT INTO Persona(Nombre, Apellido, Dni) VALUES
('Miguel','Jefazo' , 16258752),
('Roberto','Galati' , 18028282),
('Lucas','Rodriguez' , 25151562),
('German','Beder' , 98257722),
('Erica','Sanchez' , 56257722);

INSERT INTO Empleados (IDPersona, Codigo, Descripcion,Turno,sueldo,Cargo) VALUES
(1,'A001', 'Administrador', 01, 500000,'Gerente'),
(2,'C001', 'Cocina', 01, 300000,'Cocinero'),
(3,'M001', 'Mesero', 01, 200000,'MesaGral'),
(4,'G001', 'Encargado', 01, 300000,'EncargadoMesa'),
(5,'M002', 'Mesera', 01, 200000,'MesaGral');


INSERT INTO Menu (TipoPlato, Precio, UrlImagen) VALUES
('EntradaFria',2000,''),
('EntradaFria',2500,''),
('EntradaCaliente',3000,''),
('EntradaCaliente',1000,''),
('PlatoCaliente',4000,''),
('PlatoCaliente',3000,''),
('PlatoCaliente',5000,''),
('PlatoCaliente',7000,''),
('Postre',1500,''),
('Postre',1800,''),
('Postre',500,'');

INSERT INTO Mesa(TamañoMesa, Descripcion) VALUES
(2,'Dos personas ventana'),
(2,'Dos personas centro'),
(4,'Cuatro personas'),
(4,'Cuatro personas ventana'),
(6,'Seis personas ventana'),
(8,'Ocho personas centro');

INSERT INTO Entrada(IDPlato,Descripcion) VALUES
(1,'Picada 2 personas'),
(2,'Picada 4 personas'),
(3,'Picada de Mar'),
(4,'Picada vegeterina');

INSERT INTO Principal(IDPlato,Descripcion) VALUES
(5,'Pizza'),
(6,'Milanesa'),
(7,'Empanadas'),
(8,'Pastel de papas');

INSERT INTO Postre(IDPlato,Descripcion) VALUES
(9,'Helado'),
(10,'Flan'),
(11,'Panqueques');


