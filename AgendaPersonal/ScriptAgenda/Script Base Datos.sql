Create Database AgendaDb
go
use AgendaDb
go
Create Table Personas(
PersonaId int identity primary key,
Nombres varchar(100),
Direccion varchar(200),
Sexo int,
EstadoCivil int
)
go

Create Table PersonasTelefonos(
Id int identity,
PersonaId int References Personas(PersonaId),
Telefono varchar(12))

select * from Personas

delete from PersonasTelefonos where PersonaId = 7

select MAX(PersonaId) as PersonaId from Personas

select p.Nombres,pt.Telefono from Personas p inner join PersonasTelefonos pt on p.PersonaId = pt.PersonaId where p.PersonaId = 6;

select * from PersonasTelefonos


select  * from Personas where PersonaId = 1
