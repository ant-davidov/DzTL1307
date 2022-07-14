use PC

create table Configuration(
	Id int identity(1,1) constraint PK_Configuration primary key,
	Picker nvarchar(100),
	[Description] nvarchar(1000),
	[Type] nvarchar(50)
)

create table �omponents(
	Id int identity(1,1) constraint PK_�omponents primary key,
	Price money,
	Model nvarchar(300),
	[Type] nvarchar(300),
	IdConfiguration int constraint FK_�omponents_Configuration references Configuration(Id)
)

create table Computer(
	Id int identity(1,1) constraint PK_Computer primary key,
	Owner nvarchar(100),
	TotalPrice money,
	IdConfiguration int constraint FK_Computer_Configuration references Configuration(Id)
)

-- INSERT
 
 insert into Configuration 
		(Picker,[Description],[Type])
values
		('����','�������� �������� ����������','�������'),
		('���������','�������� �������� ����������','�������'),
		('����','�������� ���������� ��� ����','��� ����'),
		('����','�������� ���������� ��� ����','��� ����')


insert into �omponents
		(Price,Model,[Type],IdConfiguration)
values
		(10000,'Intel i5','CPU',1),
		(3000,'DDR4 3200','RAM',1),
		(4000,'SSD 1TB','SSD',1),
		(6000,'Asus Z590','Motherboard',1),
		(7000,'Intel i3','CPU',2),
		(3000,'DDR4 2666','RAM',2),
		(2000,'SSD 512 GB','SSD',2),
		(4000,'Asus b660','Motherboard',2),
		(5000,'Amd R3','CPU',3),
		(2500,'DDR4 2400','RAM',3),
		(1500,'SSD 256 GB','SSD',3),
		(3500,'Asus b450','Motherboard',3)


insert into Computer
		([Owner],TotalPrice,IdConfiguration)
values
      ('���������� 1',25000,1),
	  ('���������� 2',25000,1),
	  ('���������� 3',24500.56,1),
	  ('���������� 4',22000,2),
	  ('���������� 5',20000,3),
	  ('���������� 6',195000,4)
		
