create database ShopManagement2023March
go 

use ShopManagement2023March
go

create table Product(
	Id int identity(1,1) primary key,
	ProductName nvarchar(max),
	ProductQuantity int,
	ProductDescription nvarchar(max),
)
insert into Product(ProductName,ProductQuantity,ProductDescription) values(N'Milk',20,'New type of milk')
create table Customer(
	Id int identity(1,1) primary key,
	CustomerName nvarchar(max),
	CustomerAddress nvarchar(max),
	CustomerPhone nvarchar(max),
)
insert into Customer(CustomerName,CustomerAddress,CustomerPhone) values(N'Vinamilk',N'Long Thanh, Dong Nai',2387492374)