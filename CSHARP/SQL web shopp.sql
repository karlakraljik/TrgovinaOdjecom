use master;
go
drop database if exists webshopp;
go
create database webshopp
go

use webshopp;

create table kupci(
sifra int primary key identity (1,1),
ime varchar(50) not null,
prezime varchar(50) not null,
ulica varchar(30) not null,
mjesto varchar(30)not null ,
kontakt varchar(10) not null
);

create table proizvodi(
sifra int not null primary key identity(1,1),
naziv varchar(40) not null,
datumnabave datetime,
cijena decimal(18,2)not null,
aktivan bit
);

create table racuni(
sifra int not null primary key identity(1,1),
datum datetime not null,
kupac int
);

create table stavke(
sifra int primary key identity(1,1),
racun int,
proizvod int,
kolicina int not null,
cijena decimal(18,2)not null
);

alter table stavke add foreign key (proizvod) references proizvodi(sifra);
alter table stavke add foreign key (racun) references racuni(sifra);
alter table racuni add foreign key (kupac) references kupci(sifra);

insert into kupci (ime,prezime,ulica,mjesto,kontakt)
values 
--1
('Marko','Topič','Hrvatske republike','Osijek','0951957485'),
--2
('Ante', 'Kolar','Braće Radića','Našice','0915478525'),
--3
('Marta','Marić','Josipa Kozarca','Našice','0921247859'),
--4
('Anita','Mikić','Lorenza jegera','Osijek','0975425252');

insert into proizvodi(naziv,datumnabave,cijena,aktivan)
values
--1 do 11
('Jakna','2023-5-17',55.67,1),
('Traperice','2023-12-22',20.50,1),
('Hlače','2024-11-1',25.00,1),
('Sportske majice','2024-1-15',10.58,1),
('Džemper','2024-1-15',25.55,1),
('Bluze','2024-1-15',18.35,1),
('Majica','2024-1-15',12.99,1),
('haljine','2024-1-22',35.98,1),
('Košulje','2024-1-22',28.55,1),
('patike','2024-1-22', 65.00,1),
('Torbica','2024-1-22',22.48,1);

insert into racuni (datum,kupac)
values
--1
('2024-1-10',1),
--2
('2024-1-8',2),
--3
('2024-1-20',3),
--4
('2024-1-10',4);

insert into stavke(racun,proizvod,kolicina,cijena)
values
(1,1,3,167.01),
(1,2,1,20.50),
(2,3,2,50),
(3,6,1,18.35),
(4,5,4,102.2);

select a.ime,a.prezime, c.kolicina,d.naziv
from kupci a
inner join racuni b on a.sifra=b.kupac
inner join stavke c on b.sifra=c.racun
inner join proizvodi d on c.proizvod=d.sifra
;
