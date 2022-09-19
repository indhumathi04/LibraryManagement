create database Library

use Library

create table booksAvailable(bookId int identity(1,1) primary key,title varchar(50),genre varchar(20),author varchar(30),dateAdded date)

alter table booksAvailable alter column imageUrl varchar(200)

alter table booksAvailable alter column title varchar(100)

alter table booksAvailable alter column bookDescription varchar(max)

create table booksTransaction(transId int identity(1,1) primary key, bookId int ,userId int,issueDate date,dueDate Date,status varchar(15))

create table userDetail(userId int identity(1,1) primary key, userName varchar(30),email varchar(50),password varchar(20))

create table adminDetail(adminId int identity(1,1) primary key, adminName varchar(30),adminEmail varchar(50),adminPassword varchar(20))