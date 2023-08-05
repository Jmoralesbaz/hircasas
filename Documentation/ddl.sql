CREATE TABLE Items(
Id integer primary key identity not null,
Item varchar(150) not null unique,
Price decimal(15,5) not null default 0,
Stock decimal(15,3) not null default 0,
Asset bit default 1
);
CREATE TABLE Persons(
Id integer primary key identity not null,
Name varchar(150) not null,
LastName varchar(150) not null ,
Email varchar(150) unique not null ,
Asset bit default 1,
constraint uq_name unique(Name,LastName)
);
CREATE TABLE Users(
Id integer primary key identity not null,
Person integer foreign key references Persons(Id) not null,
UserName varchar(20) unique not null,
Password varchar(max) not null,
Rol varchar(50) check(Rol in ('Customer','Administrator')),
Asset bit default 1
);

CREATE TABLE Inventory(
Id integer primary key identity not null,
Item integer foreign key references Items(Id) not null,
Quantity decimal(15,3) not null default 0,
CheckIn Date
);

CREATE TABLE Sales_Headers(
Id integer primary key identity not null,
Person integer foreign key references Persons(Id) not null,
TotalItems decimal(15,3) not null,
Amount decimal(15,3) not null default 0,
DateSale Date
);

CREATE TABLE Sales_Details(
Sale integer foreign key references Sales_Headers(Id) not null,
Item integer foreign key references Items(Id) not null,
Quantity decimal(15,3) not null default 0,
Price decimal(15,5) not null default 0,
primary key (Sale,Item)
);

CREATE TABLE Invoice(
Folio varchar(150) primary key not null,
Sale integer foreign key references Sales_Headers(Id) not null,
Rfc varchar(13) not null check(LEN(Rfc)=12 OR LEN(Rfc)=13) ,
RazonSocial varchar(150) not null,
CodigoPostal char(5) not null,
RegimenFiscal varchar(150)  not null,
UsoCfdi varchar(150)  not null
);

CREATE TABLE Sessions(
Id integer primary key identity not null,
IdUser integer foreign key references Users(Id) not null,
Token varchar(500) unique not null,
CheckIn Date not null,
CheckOut Date
);