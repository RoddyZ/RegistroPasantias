create database Pasantias
go
use Pasantias
go

---------CREACION DE LAS TABLAS------
create table tblEmpresa(
idEmpresa int identity(1,1) not null primary key,
nombreEmpresa varchar(50) ,
descripcion varchar(50),
correoElectronico varchar(50) ,
direccion varchar(50) ,
telefono varchar(10) ,
fax varchar(50),
idJefe int
--check (telefono like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
--check (correoElectronico like '%@%')
)
go
create table tblSolicitud(
idSolicitud int identity(1,1) not null primary key,
descripcionSolicitud varchar(100) ,
estadoSolicitud char,
fechaEmision date,
idEmpresa int not null,
idPracticante int not null,
idDecano int not null)
go
create table tblDecano(
idDecano int identity(1,1) not null primary key,
activo bit not null,
idUsuario int not null
)
go

create table tblJefe(
idJefe int identity(1,1) not null primary key,
idUsuario int not null
)
go

create table tblPracticante(
idPracticante int identity(1,1) not null primary key,
fechaNacimiento date ,
creditosAprobados int ,
carrera varchar(50) ,
idUsuario int not null,
idTutor int
)
go


create table tblInformeMitadPeriodo(
idInformeMitadPeriodo int identity(1,1) not null primary key, 
preparacionTecnica varchar(100),
capacidadAprendizaje varchar(100),
trabajoEquipo bit ,
creatividad bit ,
adaptacion bit ,
responsabilidad bit ,
puntualidad bit ,
idSolicitud int,
idTutor int
)
go
create table tblTutor(
idTutor int identity(1,1) not null primary key,
departamento varchar(50),
idUsuario int not null
)
go
create table tblUsuario(
idUsuario int identity(1,1) not null primary key,
nombreUsuario varchar(50),
login varchar(50),
contrasenia varchar(50),
cedula varchar(10),
telefono varchar(10),
correoElectronico varchar(50),
)
--Cree la tabla control de usuario
go
create table tblControlTutor(
idControlTutor int identity(1,1) not null primary key,
fecha Date, 
medio varchar(50),
tema varchar(50),
idInformeMitadPeriodo int not null
)
go

create table tblInformeJefe(
idInformeJefe int identity(1,1) not null primary key,
areaAsignada varchar(50) not null,
actividadesDesarrolladas varchar(200) not null,
horario varchar(50) not null, 
fortalezas varchar(50),
debilidades varchar(50),
evaluacion varchar(50) ,
desempenio varchar(50),
motivacion varchar(50),
contactoTutor bit,
idSolicitud int not null,
idTutor int not null,
idRegistroDeAsistencia int not null,
idJefe int not null)
go

create table tblRegistroDeAsistencia(
idRegistroDeAsistencia int identity(1,1) not null primary key,
horasRealizadas float,
fechaFin date,
fechaInicio date,
periodoAcademico varchar(10),
idSolicitud int
)
go

create table tblActividad(
idActividad int identity(1,1) not null primary key,
fechaInicio datetime,
fechaFin datetime,
numHoras float,
idRegistroDeAsistencia int
)
go


create table tblEncuesta(
idEncuesta int identity(1,1) not null primary key,
comentarios varchar(200),
idSolicitud int
)
go

create table tblRespuesta(
idRespuesta int identity(1,1) not null primary key,
calificacion int,
idEncuesta int,
idPregunta int
)
go

create table tblPregunta(
idpregunta int identity(1,1) not null primary key,
descripcion varchar(50)
)
go


-------------------------RELACIONES ENTRE TABLAS------------------------

--  SOLICITUD -EMPRESA---

alter table tblSolicitud
add constraint fk_Empresa_Solicitud
foreign key (idEmpresa) references tblEmpresa(idEmpresa)
go

-----SOLICITUD-PRACTICANTE---

alter table tblSolicitud
add constraint fk_Practicante_Solicitud
foreign key (idPracticante) references tblPracticante(idPracticante)
go

--SOLICITUD-DECANO------
alter table tblSolicitud
add constraint fk_Solicitud_Decano
foreign key (idDecano) references tblDecano(idDecano)
go
--   EMPRESA - JEFE-------
alter table tblEmpresa
add constraint fk_Empresa_Jefe
foreign key (idJefe) references tblJefe(idJefe)
go

-------DECANO--Usuario-------------
alter table tblDecano
add constraint fk_Decano_Usuario
foreign key (idUsuario) references tblUsuario(idUsuario)
go

-----Jefe - USUARIO---

alter table tblJefe          
add constraint fk_jefe_Usuario
foreign key (idUsuario) references tblUsuario(idUsuario)
go

-----PRACTICANTE - USUARIO---

alter table tblPracticante          
add constraint fk_Practicante_Usuario
foreign key (idUsuario) references tblUsuario(idUsuario)
go

-----TUTOR- USUARIO---
alter table tblTutor         
add constraint fk_Usuario_Tutor
foreign key (idUsuario) references tblUsuario(idUsuario)
go

-----PRACTICANTE - TUTOR---
alter table tblPracticante          
add constraint fk_Practicante_Tutor
foreign key (idTutor) references tblTutor(idTutor)
go


---INFORME MITAD DE PERIODO - SOLICITUD---
alter table tblInformeMitadPeriodo
add constraint fk_informeMitadPeriodo_Solicitud
foreign key (idSolicitud) references tblSolicitud(idSolicitud)
go

---INFORME MITAD DE PERIODO - TUTOR---
alter table tblInformeMitadPeriodo
add constraint fk_informeMitadPeriodo_Tutor
foreign key (idTutor) references tblTutor(idTutor)
go


---INFORME  ControlTutor- MITAD DE PERIODO--
alter table tblControlTutor
add constraint fk_informeMitadPeriodo_ControlTutor
foreign key (idInformeMitadPeriodo) references tblInformeMitadPeriodo(idInformeMitadPeriodo)
on update cascade on delete cascade
go

---------INFORME JEFE - TUTOR-----
alter table tblInformeJefe
add constraint fk_informeJefe_tutor
foreign key (idTutor) references tblTutor(idTutor)
go


---------INFORME JEFE - REGISTRO DE ASISTENCIA-------
alter table tblInformeJefe
add constraint fk_InformeJefe_RegistroDeAsistencia
foreign key (idRegistroDeAsistencia) references tblRegistroDeAsistencia(idRegistroDeAsistencia)
go

---------INFORME JEFE - Solicitud-----
alter table tblInformeJefe
add constraint fk_informeJefe_Solicitud
foreign key (idSolicitud) references tblSolicitud(idSolicitud)
go

---------INFORME JEFE - JEFE-------
alter table tblInformeJefe
add constraint fk_InformeJefe_Jefe
foreign key (idJefe) references tblJefe(idJefe)
go

---------RegistroAsistencia...Solicitud-----------
alter table tblRegistroDeAsistencia
add constraint fk_RegistroDeAsistencia_Solicitud
foreign key (idSolicitud) references tblSolicitud(idSolicitud)
go

----Actvidad...RegistroAsistencia---------------
alter table tblActividad
add constraint fk_Actividad_RegistroDeAsistencia
foreign key (idRegistroDeAsistencia) references tblRegistroDeAsistencia(idRegistroDeAsistencia)
go

-----Encuesta -- Solicitud------
alter table tblEncuesta
add constraint fk_Encuesta_Solicitud
foreign key (idSolicitud) references tblSolicitud(idSolicitud)
go

----Repuesta -- PREGUNTA
alter table tblRespuesta
add constraint fk_Respuesta_Pregunta
foreign key (idPregunta ) references tblPregunta(idPregunta)
go

----RESPUESTA  ENCUESTA
alter table tblRespuesta
add constraint fk_Respuesta_Encuesta
foreign key (idEncuesta) references tblEncuesta(idEncuesta)
go  



-----------------------PROCEDIMIENTOS ALMACENADOS-------------------------------
------KEVIN------
--Para el Informe Mitad de Periodo
create procedure sp_BuscarPracticantesInformeMitad
@idTutor int
as
begin
select idSolicitud,nombreUsuario,carrera,nombreEmpresa,direccion,tblEmpresa.telefono,fax,tblEmpresa.correoElectronico  from tblPracticante inner join tblUsuario on tblPracticante.idUsuario=tblUsuario.idUsuario inner join tblSolicitud on tblPracticante.idPracticante=tblSolicitud.idPracticante inner join tblEmpresa on tblEmpresa.idEmpresa=tblEmpresa.idEmpresa where tblPracticante.idTutor=@idTutor AND tblSolicitud.estadoSolicitud=1
end

--Crear un InformeMitadPeriodo
go
create procedure sp_CrearInformeMitadPeriodo
@preparacionTecnica varchar(100),
@capacidadAprendizaje varchar(100),
@trabajoEquipo bit ,
@creatividad bit,
@adaptacion bit, 
@responsabilidad bit,
@puntualidad bit,
@idSolicitud int,
@idTutor int
as
begin
insert into tblInformeMitadPeriodo values (@preparacionTecnica,@capacidadAprendizaje ,@trabajoEquipo,@creatividad,@adaptacion, @responsabilidad,@puntualidad,@idSolicitud,@idTutor)
SELECT @@IDENTITY AS idInformeMitadPeriodo;  
end

go
create procedure sp_insertarControlTutor
@fecha Date, 
@medio varchar(50),
@tema varchar(50),
@idInformeMitadPeriodo int
as
begin
	insert into tblControlTutor values(@fecha,@medio,@tema,@idInformeMitadPeriodo)
end


go



create procedure sp_ObtenerControlTutoria 
@idInformeMitadPeriodo int
as
begin
	select idControlTutor,fecha,medio,tema from tblControlTutor where idInformeMitadPeriodo=@idInformeMitadPeriodo
end
go



--ObtenerInformes
create procedure sp_BuscarInformesMitadPeriodoTutor
@idTutor int
as
begin
select idInformeMitadPeriodo,preparacionTecnica,capacidadAprendizaje,trabajoEquipo,creatividad,adaptacion,responsabilidad,puntualidad,nombreEmpresa,direccion,tblEmpresa.telefono,fax,tblEmpresa.correoElectronico,nombreUsuario,carrera from tblInformeMitadPeriodo inner join tblSolicitud on tblInformeMitadPeriodo.idSolicitud=tblSolicitud.idSolicitud inner join tblPracticante on tblSolicitud.idPracticante=tblPracticante.idPracticante inner join tblUsuario on tblPracticante.idUsuario=tblUsuario.idUsuario inner join tblEmpresa on tblSolicitud.idEmpresa=tblEmpresa.idEmpresa
where tblInformeMitadPeriodo.idTutor=@idTutor 
end

--exec sp_BuscarInformesMitadPeriodoTutor 1
go


create procedure sp_EliminarInformeMitad
@idInformeMitad int
as
begin
	delete from tblInformeMitadPeriodo where idInformeMitadPeriodo=@idInformeMitad
end 

go



create procedure sp_EditarInformeMitad
@idInformeMitad int,
@preparacionTecnica varchar(100),
@capacidadAprendizaje varchar(100),
@trabajoEquipo bit ,
@creatividad bit,
@adaptacion bit, 
@responsabilidad bit,
@puntualidad bit
as
begin
	update tblInformeMitadPeriodo set preparacionTecnica=@preparacionTecnica,capacidadAprendizaje=@capacidadAprendizaje,trabajoEquipo=@trabajoEquipo,creatividad=@creatividad,adaptacion=@adaptacion,responsabilidad=@responsabilidad,puntualidad=@puntualidad where idInformeMitadPeriodo=@idInformeMitad
end 
go



create procedure sp_VerListaEmpresas
as
begin
	select * from tblEmpresa 
end
go


create procedure sp_ObtenerDecanoActivo
as
begin
select idDecano,nombreUsuario from tblDecano inner join tblUsuario on tblDecano.idUsuario=tblUsuario.idUsuario
where activo=1
end
go



create procedure sp_InsertarSolicitud
	@descripcionSolicitud varchar(100),
	@estadoSolicitud char,
	@fechaEmision date,
	@idEmpresa int,
	@idPracticante int,
	@idDecano int
as
begin
	insert into tblSolicitud values(@descripcionSolicitud,@estadoSolicitud,@fechaEmision,@idEmpresa,@idPracticante,@idDecano);
end

go



create procedure sp_BuscarPracticantesInformeJefe
@idJefe int
as
begin
select idSolicitud,nombreUsuario,carrera,nombreEmpresa,direccion,tblEmpresa.telefono,fax,tblEmpresa.correoElectronico,cedula,tblPracticante.idPracticante  from tblPracticante inner join tblUsuario on tblPracticante.idUsuario=tblUsuario.idUsuario inner join tblSolicitud on tblPracticante.idPracticante=tblSolicitud.idPracticante inner join tblEmpresa on tblEmpresa.idEmpresa=tblEmpresa.idEmpresa 
where tblEmpresa.idJefe=@idJefe AND tblSolicitud.estadoSolicitud=1
end

go

create procedure sp_CrearInformeJefe
@areaAsignada varchar(50),
@actividadesDesarrolladas varchar(100),
@horario varchar(50), 
@fortalezas varchar(50),
@debilidades varchar(50),
@evaluacion varchar(50) ,
@desempenio varchar(50),
@motivacion varchar(50),
@contactoTutor bit,
@idSolicitud int,
@idTutor int ,
@idRegistroDeAsistencia int,
@idJefe int
as
begin
insert into tblInformeJefe values (@areaAsignada,@actividadesDesarrolladas,@horario, @fortalezas,@debilidades,@evaluacion,@desempenio,@motivacion,@contactoTutor,@idSolicitud,
@idTutor,@idRegistroDeAsistencia,@idJefe)
end
go 



create procedure sp_ObtenerRegistroAsistenciaPracticante
@idSolicitud int
as
begin
	select * from tblRegistroDeAsistencia where idSolicitud=@idSolicitud
end
--exec sp_ObtenerRegistroAsistenciaPracticante 7
go



create procedure sp_ObtenerTutorPracticante
@idPracticante int
as
begin
select tblTutor.idTutor,tblUsuario.nombreUsuario from tblPracticante inner join tblTutor on tblPracticante.idTutor=tblTutor.idTutor inner join tblUsuario on tblTutor.idUsuario=tblUsuario.idUsuario
where tblPracticante.idPracticante=@idPracticante
end
exec sp_ObtenerTutorPracticante 3
go

create procedure sp_ObtenerInformesJefe
@idJefe int
as
begin
select idInformeJefe,areaAsignada,actividadesDesarrolladas,horario,fortalezas,debilidades,evaluacion,desempenio,motivacion,contactoTutor,tblInformeJefe.idSolicitud,nombreEmpresa,direccion,tblEmpresa.telefono,fax,tblEmpresa.correoElectronico,tblPracticante.idPracticante,nombreUsuario,carrera,cedula,tblRegistroDeAsistencia.idRegistroDeAsistencia,horasRealizadas,fechaFin,fechaInicio,periodoAcademico from tblInformeJefe inner join tblSolicitud on tblInformeJefe.idSolicitud=tblSolicitud.idSolicitud inner join tblPracticante on tblSolicitud.idPracticante=tblPracticante.idPracticante inner join tblUsuario on tblPracticante.idUsuario=tblUsuario.idUsuario inner join tblEmpresa on tblSolicitud.idEmpresa=tblEmpresa.idEmpresa inner join tblRegistroDeAsistencia on tblInformeJefe.idRegistroDeAsistencia=tblRegistroDeAsistencia.idRegistroDeAsistencia
where tblInformeJefe.idJefe=@idJefe
end
go



create procedure sp_EliminarInformeJefe
@idInformeJefe int
as
begin
	delete from tblInformeJefe where idInformeJefe=@idInformeJefe
end 
go



create procedure sp_EditarInformeJefe
@idInformeJefe int,
@areaAsignada varchar(50),
@actividadesDesarrolladas varchar(100),
@horario varchar(50), 
@fortalezas varchar(50),
@debilidades varchar(50),
@evaluacion varchar(50) ,
@desempenio varchar(50),
@motivacion varchar(50),
@contactoTutor bit
as
begin
	update tblInformeJefe set areaAsignada=@areaAsignada,actividadesDesarrolladas=@actividadesDesarrolladas,horario=@horario, fortalezas=@fortalezas,debilidades=@debilidades,evaluacion=@evaluacion,desempenio=@desempenio,motivacion=@motivacion,contactoTutor=@contactoTutor
		where idInformeJefe=@idInformeJefe
end 

go


--------------------------------------------------------------------------------
----RODDY
create proc sp_Solicitudes
as
begin
select idSolicitud as 'Id Solicitud',nombreUsuario as 'Nombre Practicante', descripcionSolicitud as 'Descripcion', estadoSolicitud as 'Estado', fechaEmision as 'Fecha de emision', nombreEmpresa as 'Nombre de la Empresa', p.idPracticante as 'idPracticante'
from tblPracticante p  
inner join tblUsuario  u on p.idUsuario=u.idUsuario
inner join tblSolicitud s on s.idPracticante=p.idPracticante
inner join tblEmpresa em on em.idEmpresa=s.idEmpresa
end
go


create proc sp_Validar_Solicitud
@idSolicitud int,
@estado int
as
begin
update tblSolicitud  set estadoSolicitud=@estado 
where idSolicitud=@idSolicitud
end
go



--MOSTRAR EMPRESA POR ESTUDIANTE
create procedure sp_Empresa_Por_Estudiante   --solo mostrara las empresas con las solicitudes aprobadas
@idPracticante int
as
begin
select distinct em.idEmpresa, em.nombreEmpresa 
from tblEmpresa em
inner join tblSolicitud s 
on s.idEmpresa=em.idEmpresa
inner join tblPracticante p
on p.idPracticante=s.idPracticante
where p.idPracticante=@idPracticante and s.estadoSolicitud=1
end
go

select * from tblRegistroDeAsistencia
go

--Mostrar las Solicitud Empresa
create procedure sp_Solicitud_Empresa
@idEmpresa int
as 
begin
select Top 1 s.idSolicitud
from tblEmpresa em
inner join tblSolicitud s
on em.idEmpresa=s.idEmpresa
where em.idEmpresa=@idEmpresa
end
go



create proc sp_Crear_Encuesta
@comentario varchar(100),
@idSolicitud int
as 
begin
insert into tblEncuesta values(@comentario,@idSolicitud)
end
go

--ontener idEncuesta que coincidan con la solicitud que creemos en c#
create proc sp_Obtener_idEncuesta
@idSolicitud int
as 
begin 
select en.idEncuesta
from tblEncuesta en
inner join tblSolicitud s
on s.idSolicitud=en.idSolicitud
end
go


--Creamos la respuestas a partir del idDel proceso de arriba y de las respuestas y preguntas que entraran como parametros en c#
create proc sp_Crear_Respuesta
@calificacion int,
@idEncuesta int,
@idPregunta int
as 
begin
insert into tblRespuesta 
values (@calificacion,@idEncuesta,@idPregunta) 
end
go

create proc sp_Asignar_Tutor
@idPracticante int,
@idTutor int
as 
begin
update tblPracticante set idTutor=@idTutor
where idPracticante=@idPracticante
end
go

create proc sp_Crear_Registro
@horasRealizadas float,
@fechaFin DateTime,
@fechaInicio DateTime,
@periodoAcademico varchar(10),
@idSolicitud int
as
begin
insert into tblRegistroDeAsistencia
values (@horasRealizadas , @fechaFin, @fechaInicio ,@periodoAcademico ,@idSolicitud )
end
go

create proc sp_Recuperar_Asistencia
@idPracticante int
as 
begin
select a.fechaInicio as [Fecha Inicio],a.fechaFin as [Fecha Fin],numHoras as [Numero Horas], nombreEmpresa  as [Empresa] from tblPracticante p
--inner join tblUsuario u
--on u.idUsuario=p.idUsuario
inner join tblSolicitud s
on p.idPracticante=s.idPracticante
inner join tblRegistroDeAsistencia r 
on r.idSolicitud =s.idSolicitud
inner join tblActividad a 
on a.idRegistroDeAsistencia = r.idRegistroDeAsistencia
inner join tblEmpresa e
on e.idEmpresa = s.idEmpresa
where p.idPracticante= @idPracticante
end
go
------------------------------------------------------------------------------

-------JOSEPH-------------

--------------CRUD ACTORES------------------
create proc sp_obtener_practicantes
as
begin
	select * from tblUsuario u 
	inner join tblPracticante p 
	on u.idUsuario = p.idUsuario
end
go

create proc sp_obtener_decanos
as
begin
	select * from tblUsuario u 
	inner join tblDecano d 
	on u.idUsuario = d.idUsuario
end
go

create proc sp_obtener_tutores
as
begin
	select * from tblUsuario u 
	inner join tblTutor t 
	on u.idUsuario = t.idUsuario
end
go

create proc sp_obtener_jefes
as
begin
	select * from tblUsuario u 
	inner join tblJefe j 
	on u.idUsuario = j.idUsuario
end
go

--1 CRUD PRACTICANTES
---Ingresar Practicantes------
create procedure sp_insertar_Practicante
@nombreUsuario varchar(50),
@login varchar(50),
@contrasenia varchar(50),
@cedula varchar(50),
@telefono varchar(50), 
@correoElectronico varchar(50),
@fechaNacimiento date,
@creditosAprobados int,
@carrera varchar(50)
as
begin
insert into tblUsuario values (@nombreUsuario,@login, @contrasenia, @cedula, @telefono,@correoElectronico)
insert into tblPracticante values (@fechaNacimiento,@creditosAprobados,@carrera,@@IDENTITY,null)   --@identity devuelve el id del ultimo registro de la consulta anterior
end
go

--Editar praccticantes
create procedure sp_Editar_Practicantes
@nombreUsuario varchar(50),
@login varchar(50),
@contrasenia varchar(50),
@cedula varchar(10),
@telefono varchar(10),
@correoElectronico varchar(50),
@idPracticante int,
@fechaNacimiento date,
@creditosAprobados int,
@carrera varchar(50)
as
begin
	update tblUsuario set nombreUsuario =@nombreUsuario, login=@login,contrasenia=@contrasenia,cedula=@cedula,telefono=@telefono,correoElectronico=@correoElectronico 
	from tblPracticante p
	inner join tblUsuario u on u.idUsuario = p.idUsuario
	where idPracticante=@idPracticante
	update tblPracticante set fechaNacimiento=@fechaNacimiento,creditosAprobados=@creditosAprobados,carrera=@carrera 
	from tblPracticante p
	inner join tblUsuario u on u.idUsuario = p.idUsuario
	where idPracticante=@idPracticante 
end 
go


--Eliminar Practicantes
create procedure sp_Eliminar_Practicantes
@idPracticante int
as
begin
	delete from tblPracticante where idPracticante=@idPracticante
end 
go


--2 CRUD DECANOS
------Ingresar Decano
create procedure sp_insertar_Decano
@nombreUsuario varchar(50),
@login varchar(50),
@contrasenia varchar(50),
@cedula varchar(50),
@telefono varchar(50), 
@correoElectronico varchar(50),
--datos propios
@activo bit
as
begin
insert into tblUsuario values (@nombreUsuario,@login, @contrasenia, @cedula, @telefono,@correoElectronico)
insert into tblDecano values (@activo,@@IDENTITY)
end
go
create procedure sp_Editar_Decanos
@nombreUsuario varchar(50),
@login varchar(50),
@contrasenia varchar(50),
@cedula varchar(10),
@telefono varchar(10),
@correoElectronico varchar(50),
@idDecano int,
@activo bit
as
begin
	update tblUsuario set nombreUsuario =@nombreUsuario, login=@login,contrasenia=@contrasenia,cedula=@cedula,telefono=@telefono,correoElectronico=@correoElectronico 
	from tblDecano d
	inner join tblUsuario u on u.idUsuario = d.idUsuario
	where idDecano=@idDecano
	update tblDecano set activo=@activo 
	from tblDecano d
	inner join tblUsuario u on u.idUsuario = d.idUsuario
	where idDecano=@idDecano 
end 
go



--Eliminar dECANOS
create procedure sp_Eliminar_Decanos
@idDecano int
as
begin
	delete from tblDecano where idDecano=@idDecano
end
go

--------Ingreso de TUTOR-------------
create procedure sp_insertar_Tutor
@nombreUsuario varchar(50),
@login varchar(50),
@contrasenia varchar(50),
@cedula varchar(50),
@telefono varchar(50), 
@correoElectronico varchar(50),
--datos propios
@departamento varchar(50)
as
begin
insert into tblUsuario values (@nombreUsuario,@login, @contrasenia, @cedula, @telefono,@correoElectronico)
insert into tblTutor values (@departamento,@@IDENTITY)
end
go


--Editar tutores
create procedure sp_Editar_Tutores
@idTutor int,
@nombreUsuario varchar(50),
@login varchar(50),
@contrasenia varchar(50),
@cedula varchar(10),
@telefono varchar(10),
@correoElectronico varchar(50),
@departamento varchar(50)
as
begin
	update tblUsuario set nombreUsuario=@nombreUsuario,login=@login,contrasenia=@contrasenia,cedula=@cedula,telefono=@telefono,correoElectronico=@correoElectronico 
	from tblTutor
	inner join tblUsuario on tblUsuario.idUsuario=tblTutor.idUsuario
	update tblTutor set departamento=@departamento
	from tblTutor
	inner join tblUsuario on tblUsuario.idUsuario=tblTutor.idUsuario
	where idTutor=@idTutor
end 
go


--Eliminar Tutor
create procedure sp_Eliminar_Tutor
@idTutor int
as
begin
	delete from tblTutor where idTutor = @idTutor
end
go

--------Ingreso de Jefe-------------
create procedure sp_consultar_jefe
as
begin
select top(1) idJefe from tblJefe j
inner join tblUsuario u
on j.idUsuario = u.idUsuario
order by idjefe desc
end
go

create procedure sp_insertar_Jefe
@nombreUsuario varchar(50),
@login varchar(50),
@contrasenia varchar(50),
@cedula varchar(50),
@telefono varchar(50), 
@correoElectronico varchar(50)
--datos propios
as
begin
insert into tblUsuario values (@nombreUsuario,@login, @contrasenia, @cedula, @telefono,@correoElectronico)
insert into tblJefe values (@@IDENTITY)
end
go

--Editar Jefes
create procedure sp_Editar_Jefes
@idJefe int,
@nombreUsuario varchar(50),
@login varchar(50),
@contrasenia varchar(50),
@cedula varchar(10),
@telefono varchar(10),
@correoElectronico varchar(50)
as
begin
	update tblUsuario set nombreUsuario=@nombreUsuario,login=@login,contrasenia=@contrasenia,cedula=@cedula,telefono=@telefono,correoElectronico=@correoElectronico 
	from tblJefe
	inner join tblUsuario on tblUsuario.idUsuario=tblJefe.idUsuario
	where idJefe=@idJefe
end 
go



--eLIMIAR JEFES
create procedure sp_Eliminar_Jefes
@idJefe int
as
begin
	delete  from tblJefe where idJefe=@idJefe
	end
go


----------DAO empresas-----------

create procedure sp_Obtener_Empresas
as
begin
select idEmpresa, nombreEmpresa, descripcion,correoElectronico,direccion,telefono,fax,e.idJefe,idUsuario from tblEmpresa e
inner join tblJefe j
on e.idJefe = j.idJefe
end
go

create procedure sp_insertar_empresa
@nombreEmpresa varchar(50),
@descripcion varchar(50),
@correoElectronico varchar(50),
@direccion varchar(50),
@telefono varchar(10),
@fax varchar(50),
@idJefe int
as
begin
insert into tblEmpresa values(@nombreEmpresa, @descripcion, @correoElectronico, @direccion, @telefono, @fax,@idJefe)
end
go

--Editar Empresa
create procedure sp_Editar_Empresa
@nombreEmpresa varchar(50),
@descripcion varchar(50),
@correoElectronico varchar(50),
@direccion varchar(50),
@telefono varchar(10),
@fax varchar(50),
@idEmpresa int
as
begin
	update tblEmpresa set nombreEmpresa = @nombreEmpresa,descripcion= @descripcion,correoElectronico= @correoElectronico,direccion= @direccion,telefono= @telefono,fax= @fax 
	where idEmpresa= @idEmpresa
end 
go

create procedure sp_Eliminar_Empresa
@idEmpresa int
as
begin
	delete  from tblEmpresa where idEmpresa = @idEmpresa
	end
go




create proc sp_Recuperar_Asistencia1
@idPracticante int,
@idEmpresa int
as 
begin
select a.idActividad, a.fechaInicio,a.fechaFin,a.numHoras from tblPracticante p
inner join tblSolicitud s
on p.idPracticante=s.idPracticante
inner join tblRegistroDeAsistencia r 
on r.idSolicitud =s.idSolicitud
inner join tblActividad a 
on a.idRegistroDeAsistencia = r.idRegistroDeAsistencia
inner join tblEmpresa e
on e.idEmpresa = s.idEmpresa
where p.idPracticante= @idPracticante and e.idEmpresa = @idEmpresa
end
go


create proc sp_Recuperar_Solicitud
@idPracticante int
as
begin
select idSolicitud as 'Id Solicitud', descripcionSolicitud as 'Descripcion', estadoSolicitud as 'Estado', fechaEmision as 'Fecha de emision', e.idEmpresa as 'id Empresa', nombreEmpresa as 'Nombre de la Empresa'
,descripcion as 'Descripcion', correoElectronico as 'Correo', direccion as 'Direccion', telefono as 'Telefono', fax as Fax, p.idPracticante  
from tblPracticante p
inner join tblSolicitud s
on p.idPracticante = s.idPracticante
inner join tblEmpresa e
on e.idEmpresa = s.idEmpresa
where p.idPracticante = @idPracticante
end
go

create proc sp_Recuperar_IdRegistro
@idPracticante int,
@idEmpresa int
as begin
select r.idRegistroDeAsistencia
from tblSolicitud s
inner join tblRegistroDeAsistencia r
on r.idSolicitud = s.idSolicitud
inner join tblPracticante p 
on p.idPracticante = s.idPracticante
where p.idPracticante = @idPracticante and s.idEmpresa = @idEmpresa
end
go

create proc sp_insertar_actividad
@fechaInicio datetime,
@fechaFin datetime,
@numHoras float,
@idRegistroDeasistencia int
as
begin
insert into tblActividad values (@fechaInicio,@fechaFin,@numHoras,@idRegistroDeasistencia)
end
go

create proc sp_editar_actividad
@idActividad int,
@fechaInicio datetime,
@fechaFin datetime,
@numHoras float
as
begin
update tblActividad set fechaInicio= @fechaInicio, fechaFin= @fechaFin, numHoras = @numHoras
where idActividad = @idActividad
end
go

create proc sp_eliminar_actividad
@idActividad int
as 
begin
	delete from tblActividad
	where idActividad = @idActividad
end
go


create proc sp_actualizar_RegistroAsistencia
@idPracticante int,
@numHoras float,
@fechaInicio datetime,
@fechaFin datetime
as
begin
update tblRegistroDeAsistencia set horasRealizadas = @numHoras, fechaInicio=@fechaInicio,fechaFin=@fechaFin
from tblRegistroDeAsistencia r
inner join tblSolicitud s
on r.idSolicitud = s.idSolicitud
inner join tblPracticante p
on s.idPracticante = p.idPracticante
where p.idPracticante =@idPracticante
end
go



---------------DATOS--------------------------
---------------------------INGRESO DE DATOS----------------------------
----INGRESO DE USUARIOS
insert into tblUsuario values
('jose','jose1','jose1234','0986758948','0985746379','jose@epn.edu.ec')
go
insert into tblUsuario values
('Maria','maria1','1234','7458394758','0987563732','maria@epn.edu.ec')
go
insert into tblUsuario values
('Julio','julio1','1234','2347856478','0974657367','julio@epn.edu.ec')
go
insert into tblUsuario values
('Pato','pato1','1234','5647384958','0943654684','pato@epn.edu.ec')
go
insert into tblUsuario values
('Carlos','carlos1','124','7586745748','093456364','carlos@epn.edu.ec')
go
insert into tblUsuario values
('Manuel','manuel1','1234','756479484','0975647364','manuel@epn.edu.ec')
go
----INGRESO DE  practiante

insert into tblPracticante values
('10-10-1995',45,'redes',1,null),
('10-10-1995',45,'electrica',2,null)
go

--DECANO
insert into tblDecano values
(1,3)
go
--JEFE
insert into tblJefe values
(4)
go
--TUTOR
insert into tblTutor values
('DETRI',5),
('DETRI',6)
go
--EMPRESA
insert into tblEmpresa values
('CNT','Internet','cnt@hotmail.com','Quito','0986211465','9441',1)
go

insert into tblEmpresa values
('Telconet','Internet','Telconet@gnail.com','Guayaquil','0987654321','8766',1)
go
--SOLICITUD
insert into tblSolicitud values
('Pasantia CNT',1,'10-10-2018',1,1,1)    --jose
go

insert into tblSolicitud values
('Pasantia Telconet',1,'10-11-2018',2,2,1)    --Maria
go

--select * from tblPracticante
--go

--REGISTRO ASISTENCIA
insert into tblRegistroDeAsistencia values
(45,'19-01-2019','19-01-2019','2018-B',1)
go

--select * from tblRespuesta go
insert into tblRegistroDeAsistencia values
(66,'','',10,2)
go



--ACTIVIDADES
insert into tblActividad values
('10-10-2000 8:00','10-10-2000 11:00',3,1),
('10-10-2000 12:00','10-10-2000 16:00',4,1)
go

insert into tblActividad values
('10-10-2000 7:00','10-10-2000 11:00',4,2),
('10-10-2000 11:00','10-10-2000 16:00',5,2)
go

--Prguntas
insert into tblPregunta values('Pregunta 1'),
('Pregunta 2'),
('Pregunta 3'),
('Pregunta 4'),
('Pregunta 5'),
('Pregunta 6'),
('Pregunta 7'),
('Pregunta 8'),
('Pregunta 9'),
('Pregunta 10'),
('Pregunta 11')
go
