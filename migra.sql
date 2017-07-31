--drop table xDatos
select * from xDatos order by item
select * from tCargos
select * from tPersonas
select * from tLugares
select * from tMunicipios
select * from tPersonas
select * from tFuncionarios
select * from tTiempos
select * from tEscalafones

delete from tFuncionarios
delete from tPersonas
delete from tCargos
delete from tLugares
delete from tEscalafones
delete from tMunicipios
delete from tTiempos

DBCC CHECKIDENT ('tFuncionarios', RESEED, 0)
DBCC CHECKIDENT ('tPersonas', RESEED, 0)
DBCC CHECKIDENT ('tCargos', RESEED, 0)
DBCC CHECKIDENT ('tLugares', RESEED, 0)
DBCC CHECKIDENT ('tEscalafones', RESEED, 0)
DBCC CHECKIDENT ('tMunicipios', RESEED, 0)
DBCC CHECKIDENT ('tTiempos', RESEED, 0)


insert into tCargos(cargosigla,cargoDesc,CargoStatus) values('<Cargo no especificado>', '<Cargo no especificado>',1)
insert into tCargos(cargosigla,cargoDesc,CargoStatus) select distinct cargosigla, cargo,1 from xDatos where not cargosigla is null

insert into tLugares(LugarDesc,LugarStatus) values ('<Lugar no especificado>',1)
insert into tLugares(LugarDesc,LugarStatus) select distinct lugar,1 from xDatos where not lugar is null

insert into tMunicipios(MunicipioDesc,Municipiostatus) values('<Municipio no especificado>',1)
insert into tMunicipios(MunicipioDesc,Municipiostatus) select distinct region,1 from xDatos


insert into tPersonas(DocIdentidad, Nombre,Apellidos,PersonaStatus) values('<NN>', '<No identificado>','<No identificado>',1)
insert into tPersonas(DocIdentidad, Nombre,Apellidos,PersonaStatus) select distinct NCI, Nombres, Apellidos,1 from xDatos where nci<>'0' order by nci

insert into tTiempos(TiempoDesc) values('<Tiempo no especificado>')
insert into tTiempos(TiempoDesc) select distinct tiempo from xDatos where not  Tiempo is null order by tiempo

insert into tEscalafones(EscalafonDesc) values('<Escalafon no especificado>')
insert into tEscalafones(EscalafonDesc) select distinct Escalafon from xDatos where not  Escalafon is null and escalafon<>'' order by Escalafon


insert into tFuncionarios(Item,basico,CargoID,PersonaID,TiempoId,EscalafonID,LugarID,MunicipioID)
select a.item, a.basico,
		(select CargoID from tCargos where CargoDesc=a.cargo and CargoSigla=a.CargoSigla),
		isnull((select PersonaID from tPersonas where DocIdentidad=a.NCI and nombre=a.Nombres and Apellidos=a.Apellidos), (select PersonaID from tPersonas where DocIdentidad='<NN>')), 
		isnull((select TiempoID from tTiempos where TiempoDesc=a.Tiempo), (select TiempoID from tTiempos where TiempoDesc='<Tiempo no especificado>')), 
		isnull((select EscalafonID from tEscalafones where EscalafonDesc=a.Escalafon), (select EscalafonID from tEscalafones where EscalafonDesc='<Escalafon no especificado>')), 
		isnull((select LugarID from tLugares where LugarDesc=a.Lugar), (select LugarID from tLugares where LugarDesc='<Lugar no especificado>')), 
		isnull((select MunicipioID from tMunicipios where MunicipioDesc=a.Region), (select MunicipioID from tMunicipios where MunicipioDesc='<Municipio no especificado>')) 
from xDatos a order by a.item

