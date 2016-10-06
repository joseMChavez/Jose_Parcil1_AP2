create table Materiales(
		MaterialesId int identity(1,1) primary key,
		Razon varchar(100)
)go
create table MaterialesDetalle(
		MaterialesDetalleId int identity(1,1)
		,MaterialesId int references Materiales
		,Material varchar(30),
		Cantidad int
		  
);