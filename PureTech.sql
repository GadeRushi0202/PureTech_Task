create database PureTech

create table Products(
    Prod_Id int primary key identity(1,1),
    Prod_Name varchar(50) NOT NULL,
    Prod_price decimal(14, 2) NOT NULL,
    Prod_Description varchar(200),
    Prod_imageUrl varchar(255)
)