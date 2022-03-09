--UC-1 
create database Employee_Payroll_Database

--UC-2
create table PayRollTable(
id int  identity(1,1) primary key,
Name varchar(200) not null,
salary float,
StartDate Date)
--UC-3
insert into PayRollTable values ('Santosh',12000,'2018-08-15')
insert into PayRollTable values ('Ramesh',15000,'2020-05-18')
insert into PayRollTable values ('Yogesh',18000,'2021-03-14')
insert into PayRollTable values ('Harshal',22000,'2020-02-25')
insert into PayRollTable values ('Jay',32000,'2017-12-20')
--UC-4
select * from PayRollTable
--UC-5
SELECT salary FROM PayRollTable where name='Santosh'
SELECT salary FROM PayRollTable where startDate between CAST('2021-01-01' as date) and GETDATE()
--UC-6
ALTER TABLE PayRollTable ADD gender varchar(10)
UPDATE PayRollTable set gender ='Male' where name='Santosh' or name='Ramesh' or Name='Jay'
UPDATE PayRollTable set gender ='Female' where name='Yogesh' or name='Harshal'
--UC-7
select sum(salary) as totalsalary,gender from PayRollTable group by gender
select avg(salary) as averagesalary,gender from PayRollTable group by gender
select min(salary) as minsalary,gender from PayRollTable group by gender
select max(salary) as maxsalary,gender from PayRollTable group by gender
--UC-8
ALTER TABLE PayRollTable ADD phonenumber bigint
ALTER TABLE PayRollTable ADD address varchar(200) DEFAULT('INDIA')
ALTER TABLE PayRollTable ADD department varchar(20) not null DEFAULT('Engineering')
update PayRollTable
set phonenumber = 9623500474 , address='Jalgaon', department='Engineering'
where name='Santosh'
update PayRollTable 
set phonenumber = 8664725647 , address='Pune', department='Intelligence'
where name='Ramesh'
update PayRollTable 
set phonenumber = 9327646727 , address='Nandurbar', department='Intelligence'
where name='Yogesh'
update PayRollTable 
set phonenumber = 8365736265 , address='Dhule', department='Engineering'
where name='Harshal'
update PayRollTable 
set phonenumber = 8364536265 , address='Nashik', department='Engineering'
where name='Jay'
--UC-9
ALTER TABLE PayRollTable drop column salary
ALTER TABLE PayRollTable Add BasicPay int, Deduction float, TaxablePay float, Tax float,NetPay float
update  PayRollTable set NetPay= (Basicpay - Deduction) 

select * from PayRollTable
--UC-10
Insert into PayRollTable(name,startDate,gender,phoneNumber,address,department,BasicPay,Deduction,TaxablePay,tax) 
values('Terissa','2021-07-06','Female',9537847533,'Dhule','Marketting and sale',20000,2000,1000,200)
select * from PayRollTable where name='Terissa'
--UC-11-Use ER-Diagram
create table Employee 
(
 emp_Id int identity(1,1) primary key,
 emp_name varchar(200),
 company_id int,
 dept_id int,
 phoneNumber bigint,
 address varchar(300),
 city varchar(100),
 state varchar(100),
 startDate date
)

create table Company
(
  company_id int primary key,
  company_name varchar(200)
)
create table Department
(
  Dept_id int primary key,
  Dept_name varchar(200)
)
create table PayRoll
(
  Emp_id int,
  BasicPay int, 
  Deduction float, 
  TaxablePay float, 
  Tax float,
  NetPay float
)
create table Employee_Department
(
  Emp_id int,
  Dept_id int
)
insert into Department values(1,'Engineering')
insert into Department values(2,'HR')
insert into Department values(3,'Sales')
insert into Department values(4,'Marketing')
insert into Department values(5,'Intelligence')

select * from Department

Alter table Employee_Department ADD FOREIGN KEY (Emp_id) REFERENCES Employee(Emp_id)

select * from Employee

Alter table PayRoll add foreign key(Emp_id) references Employee(Emp_id)

insert into Company values(1,'Infosys')
insert into Company values(2,'Intellect')
insert into Company values(3,'TCS')
Alter table Employee drop column dept_id


insert into Employee values('raj',5,454646644,'kknager','Pune','MH','2019-06-15')
insert into Employee values('Arun',4,737337795,'shivaji nagar','Dhule','MH','2018-06-15')
insert into Employee values('jay',6,737337795,'t nagar','Jalgaoan','MH','2020-06-15')
insert into Employee values('terissa',1,737337795,'pudhur','Nandurbar','MH','2018-06-15')
insert into Employee values('Jessi',3,2564635458,'Shv Colony','Nashik','MH','2016-07-29')

update Employee set phoneNumber=9684523654 where emp_name='Jay'
update Employee set phoneNumber=8564215015 where emp_name='terissa'
update Employee set phoneNumber=8694235665 where emp_name='Arun'

update Employee set startDate='2019-01-29' where emp_id=3
update Employee set startDate='2021-07-27' where emp_Id=4

alter table Employee add gender varchar(1)
update Employee set gender='M' where emp_name='Arun' or emp_name='raj'
update Employee set gender='F' where emp_name='jay' or emp_name='Jessi' or emp_name='terissa'

insert into Employee_Department values(1,3)
insert into Employee_Department values(2,2)
insert into Employee_Department values(3,1)
insert into Employee_Department values(4,4)
insert into Employee_Department values(5,5)

select * from Employee_Department

insert into PayRoll(Emp_id,BasicPay,Deduction,TaxablePay,Tax)
 values((select emp_id from Employee where emp_name='raj'),20000,2000,1500,500)

insert into PayRoll(Emp_id,BasicPay,Deduction,TaxablePay,Tax) 
values(2,50000,10000,500,200),(3,35000,4500,300,245),(4,29000,5640,789,409),(5,45000,789,3456,300)

update PayRoll set NetPay=(BasicPay-Deduction)
select * from PayRoll
select * from PayRoll where Emp_id in (select Emp_id from Employee_Department where Dept_id=4)

