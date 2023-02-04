--create database Sample7
--use Sample7
--go

create table Person(
	ID int primary key identity (1,1),
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	Age int not null,
	Email nvarchar(50) not null
)




