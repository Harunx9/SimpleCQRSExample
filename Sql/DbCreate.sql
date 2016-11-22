if DB_ID('cqrsexample') is null
create database cqrsexample

go

create table cqrsexample.dbo.Todos(
	UUID UNIQUEIDENTIFIER not null,
	Version int,
	Title varchar(255),
	Description varchar(max),
	State int,
	CreatedAt datetime,
	UpdatedAt datetime,
);

