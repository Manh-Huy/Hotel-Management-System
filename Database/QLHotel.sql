create database QLHotelDB

use QLHotelDB

CREATE TABLE [dbo].[Log_in] (
    [ID]       NVARCHAR (50) NOT NULL UNIQUE,
	[role]     NVARCHAR(50) NOT NULL,
    [username] NVARCHAR (10),
    [password] NVARCHAR (10),
    [email]    NVARCHAR (50),
	PRIMARY KEY (role, username)
);
Go

CREATE TABLE [dbo].[Temp_Log_in] (
    [ID]       NVARCHAR (50) NOT NULL UNIQUE,
	[role]     NVARCHAR(50) NOT NULL,
    [username] NVARCHAR (10),
    [password] NVARCHAR (10),
    [email]    NVARCHAR (50),
	PRIMARY KEY (role, username)
);
Go
CREATE TABLE [dbo].[Employee] (
	[ID]	  NVARCHAR (50)	NOT NULL PRIMARY KEY,
    [fname]   NVARCHAR (50) NULL,
    [lname]   NVARCHAR (50) NULL,
	[role]	  NVARCHAR (50) NULL,
    [bdate]   DATE          NULL,
    [gender]  NVARCHAR (10) NULL,
    [phone]   NVARCHAR (10) NULL,
	[email]   NVARCHAR (50) NULL,
    [address] NVARCHAR (50) NULL,
	[hometown] NVARCHAR(50) NULL,
	[picture] IMAGE         NULL,
);
Go

CREATE TABLE [dbo].[TimeSheet] (
    [ID]    NVARCHAR (100),
	[fullName]	NVARCHAR (100),
    [day]     NVARCHAR (100),
    [7h-15h]  NVARCHAR (1000),
    [15h-19h] NVARCHAR (1000),
    [19h-3h]  NVARCHAR (1000),
    [3h-7h]   NVARCHAR (1000)
);
Go

CREATE TABLE [dbo].[Salary] (
    [ID]    NVARCHAR (100),
	[fullName]	NVARCHAR (100),
    [day]     NVARCHAR (100),
    [totalWorkTime]  NVARCHAR (1000),
	[totalShortageTime]	NVARCHAR (100),
	[totalSalary]	FLOAT,
	[totalPenalty]	FLOAT
);
Go
-----
CREATE TABLE [dbo].[Foods] (
    [IdFoods]  NVARCHAR (50) NOT NULL,
    [Name]     NVARCHAR (50) NULL,
    [Type]     NVARCHAR (50) NULL,
    [Price]    FLOAT (53)    NULL,
    [Quantity] INT           DEFAULT ((100)) NULL,
    PRIMARY KEY CLUSTERED ([IdFoods] ASC)
);
CREATE TABLE [dbo].[Customer] (
    [roomID]     NCHAR (10)    NOT NULL,
    [Name]       NVARCHAR (50) NULL,
    [Phone]      INT           NULL,
    [Food]       NVARCHAR (50) NULL,
    [Price]      NVARCHAR (50) NULL,
    [Time]       NVARCHAR (50) NULL,
    [RentalDate] DATETIME      NULL
);
CREATE TABLE [dbo].[Room] (
    [IDroom]  NVARCHAR (50)  NOT NULL,
    [status]  NVARCHAR (100) NULL,
    [address] NVARCHAR (100) NULL,
    [picture] IMAGE          NULL,
    PRIMARY KEY CLUSTERED ([IDroom] ASC)
);

------------------------------------------------------------------------------------------------------
CREATE TRIGGER RemoveDuplicateRowsInTimeSheet
ON TimeSheet
AFTER INSERT, UPDATE
AS
BEGIN
    ;WITH CTE AS (
        SELECT *, ROW_NUMBER() OVER (PARTITION BY ID, day, [7h-15h], [15h-19h], [19h-3h], [3h-7h]
            ORDER BY (SELECT NULL)) AS RN
        FROM TimeSheet
    )
    DELETE FROM CTE WHERE RN > 1 OR ([7h-15h] IS NULL AND [15h-19h] IS NULL AND [19h-3h] IS NULL AND [3h-7h] IS NULL)
END

------------------------------------------------------------------------------------------------------
-- Login
insert into Log_in values ('admin', 'Admin', 'admin', 'admin', 'test@gmail.com')
insert into Log_in values ('m01', 'Manager', 'huy', 'huy', 'test@gmail.com')
insert into Log_in values ('r01', 'Receptionist', 'huy', 'huy', 'test@gmail.com')
insert into Log_in values ('l01', 'Labor', 'huy', 'huy', 'test@gmail.com')

-- Admin
INSERT INTO Employee VALUES ('adminn', 'admin', 'admin', 'Admin', '2002-01-01', 'Male', '0912345678', NULL, 'HCM', 'Tien Giang', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\Windows Programming\images.png', SINGLE_BLOB) AS picture))
INSERT INTO Employee(ID, picture) VALUES ('adminnn', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\Windows Programming\images.png', SINGLE_BLOB) AS picture))

INSERT INTO Employee VALUES ('admin', 'admin', 'admin', 'Admin', '2002-01-01', 'Male', '0912345678', 'test@gmail.com', 'HCM', 'Tien Giang', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\Windows Programming\images.png', SINGLE_BLOB) AS picture))
-- Manager
INSERT INTO Employee VALUES ('m01', 'Tran', 'Huy', 'Manager', '2002-01-01', 'Male', '0912345678', 'test@gmail.com', 'HCM', 'Tien Giang', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\Windows Programming\images.png', SINGLE_BLOB) AS picture))
INSERT INTO Employee VALUES ('m02', 'Phan', 'An', 'Manager', '2002-01-01', 'Female', '0912345678', '20142178@student.hcmute.edu.vn', 'Tien Giang', 'Tien Giang', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\Windows Programming\images.png', SINGLE_BLOB) AS picture))
-- Receptionist
INSERT INTO Employee VALUES ('r01', 'Tran', 'Huy', 'Receptionist', '2002-01-01', 'Male', '0912345678', 'test@gmail.com', 'HCM', 'Tien Giang', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\Windows Programming\images.png', SINGLE_BLOB) AS picture))
INSERT INTO Employee VALUES ('r02', 'Nguyen', 'Tin', 'Receptionist', '2002-01-01', 'Male', '0912345678', 'test@gmail.com', 'HCM', 'An Giang', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\Windows Programming\images.png', SINGLE_BLOB) AS picture))
INSERT INTO Employee VALUES ('r03', 'Phan', 'An', 'Receptionist', '2002-01-01', 'Female', '0912345678', 'test@gmail.com', 'HCM', 'Tien Giang', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\Windows Programming\images.png', SINGLE_BLOB) AS picture))
INSERT INTO Employee VALUES ('r04', 'Nguyen', 'Ha', 'Receptionist', '2002-01-01', 'Female', '0912345678', 'test@gmail.com', 'HCM', 'Tien Giang', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\Windows Programming\images.png', SINGLE_BLOB) AS picture))
-- Labor
INSERT INTO Employee VALUES ('l01', 'Tran', 'Huy', 'Labor', '2002-01-01', 'Male', '0912345678', 'test@gmail.com', 'HCM', 'Tien Giang', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\Windows Programming\images.png', SINGLE_BLOB) AS picture))
INSERT INTO Employee VALUES ('l02', 'Nguyen', 'Tin', 'Labor', '2002-01-01', 'Male', '0912345678', 'test@gmail.com', 'HCM', 'An Giang', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\Windows Programming\images.png', SINGLE_BLOB) AS picture))
INSERT INTO Employee VALUES ('l03', 'Phan', 'An', 'Labor', '2002-01-01', 'Female', '0912345678', 'test@gmail.com', 'HCM', 'Tien Giang', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\Windows Programming\images.png', SINGLE_BLOB) AS picture))
INSERT INTO Employee VALUES ('l04', 'Nguyen', 'Ha', 'Labor', '2002-01-01', 'Female', '0912345678', 'test@gmail.com', 'HCM', 'Tien Giang', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\Windows Programming\images.png', SINGLE_BLOB) AS picture))
INSERT INTO Employee VALUES ('l05', 'Phung', 'Hoang', 'Labor', '2002-01-01', 'Male', '0912345678', 'test@gmail.com', 'HCM', 'Ha Noi', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\Windows Programming\images.png', SINGLE_BLOB) AS picture))
INSERT INTO Employee VALUES ('l06', 'Nguyen', 'Han', 'Labor', '2002-01-01', 'Female', '0912345678', 'test@gmail.com', 'HCM', 'Dong Thap', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\Windows Programming\images.png', SINGLE_BLOB) AS picture))

-- Room
Insert into Room Values ('room1', 'empty', 'floor 1, room 100', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\rooma.jpg', SINGLE_BLOB) AS picture) )
Insert into Room Values ('room2', 'empty', 'floor 1, room 101', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\roomb.jpg', SINGLE_BLOB) AS picture) )
Insert into Room Values ('room3', 'empty', 'floor 1, room 102', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\roomc.jpg', SINGLE_BLOB) AS picture) )
Insert into Room Values ('room4', 'empty', 'floor 1, room 103', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\rooma.jpg', SINGLE_BLOB) AS picture) )
Insert into Room Values ('room5', 'empty', 'floor 1, room 104', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\roomb.jpg', SINGLE_BLOB) AS picture) )
Insert into Room Values ('room6', 'empty', 'floor 1, room 105', (SELECT BulkColumn FROM OPENROWSET(BULK N'F:\Desktop\roomc.jpg', SINGLE_BLOB) AS picture) )

--Foods
Insert into Foods values ('F1', N'Cơm Tấm', 'food', 35000, 98)
Insert into Foods values ('F2', N'Bún Chả', 'food', 35000, 78)
Insert into Foods values ('F3', N'Phở Bò', 'food', 35000, 93)
Insert into Foods values ('F4', N'Phở Gà', 'food', 35000, 60)
Insert into Foods values ('W1', N'Sting', 'water', 12000, 60)
Insert into Foods values ('W2', N'Coffee', 'water', 12000, 70)
Insert into Foods values ('W3', N'Coca', 'water', 12000, 81)
Insert into Foods values ('W4', N'Aqua', 'water', 12000, 96)



