create table student (
	studentNumber char(10) primary key,
	name varchar(100) not null,
	address varchar(250) not null,
	county varchar(100) not null,
	age int not null,
	phone varchar(25) not null,
	email varchar(250) not null,
	gender varchar(10) not null
);

--drop table student;

insert into student values ('S001','Peter Griffin','123 Avenue rhode island','quahog',27,'+353 232 434 231','peter@mail.com','male');
insert into student values ('S002','Meg Griffin','123 Avenue rhode island','quahog',22,'+353 311 211 900','meg@mail.com','female');
insert into student values ('S003','Lois Griffin','123 Avenue rhode island','quahog',30,'+353 232 434 231','peter@mail.com','female');
insert into student values ('S004','Chris Griffin','123 Avenue rhode island','quahog',21,'+353 466 908 908','chris@mail.com','male');
insert into student values ('S005','Stewie Griffin','123 Avenue rhode island','quahog',15,'+353 689 387 964','stewie@mail.com','male');
insert into student values ('S006','Brian Griffin','123 Avenue rhode island','quahog',25,'+353 111 222 333','brian@mail.com','male');
insert into student values ('S007','Homer Simpson','345 street springfield','Oregon',41,'+353 999 888 111','homer@mail.com','male');
insert into student values ('S008','Marge Simpson','345 street springfield','Oregon',39,'+353 444 555 666','marge@mail.com','female');
insert into student values ('S009','Bart Simpson','345 street springfield','Oregon',21,'+353 333 333 666','bart@mail.com','male');
insert into student values ('S010','Lisa Simpson','345 street springfield','Oregon',28,'+353 356 787 897','lisa@mail.com','female');

select * from student;

--drop table lecturer;

create table lecturer(
	lecID int primary key identity(1,1),
	name varchar(100) not null,
	address varchar(250) not null,
	county varchar(100) not null,
	age int not null,
	phone varchar(25) not null,
	email varchar(250) not null,
	gender varchar(10) not null,
	pay decimal not null
);

insert into lecturer values ('Arya Stark','3rd street winterfell','westeros',27,'+353 453 434 231','arya@mail.com','female',300000);
insert into lecturer values ('Eddard Stark','3rd street winterfell','westeros',32,'+353 6768 211 900','eddard@mail.com','male',350000);
insert into lecturer values ('Daario Naharis','3rd street winterfell','westeros',30,'+353 678 434 231','dario@mail.com','female',450000);
insert into lecturer values ('Bran Stark','3rd street winterfell','westeros',31,'+353 808 908 908','Bran@mail.com','male',50000);
insert into lecturer values ('Stannis Baratheon','3rd street winterfell','westeros',45,'+353 657 387 964','stannis@mail.com','male',600000);
insert into lecturer values ('Robb Stark','3rd street winterfell','westeros',25,'+353 689 222 333','rob@mail.com','male',2340000);
insert into lecturer values ('Rickon Stark','3rd street winterfell','westeros',41,'+353 980 888 111','rickon@mail.com','male',90000);
insert into lecturer values ('Cersei Lannister','3rd street winterfell','westeros',49,'+353 656 555 666','marge@mail.com','female',500000);
insert into lecturer values ('Khal Drogo','3rd street winterfell','westeros',35,'+353 578 333 666','khal@mail.com','male',430000);
insert into lecturer values ('Theon Greyjoy','3rd street winterfell','westeros',28,'+353 569 787 897','theon@mail.com','male',350000);

select * from lecturer;