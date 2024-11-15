CREATE DATABASE [OdbRepairEngine];
USE [OdbRepairEngine];

Create TABLE [Role] (
	[RoleID] INT IDENTITY(1,1) PRIMARY KEY
	, [Title] VARCHAR(15) NOT NULL
);

CREATE TABLE [User] (
	[UserID] INT IDENTITY(1,1) PRIMARY KEY
	, [Surname] VARCHAR(50) NOT NULL
	, [Name] VARCHAR(50) NOT NULL
	, [MiddleName] VARCHAR(50) NOT NULL
	, [Phone] FLOAT NOT NULL
);

CREATE TABLE [Client] (
	[ClientID] INT IDENTITY(1,1) PRIMARY KEY
	, [UserID] INT
		FOREIGN KEY REFERENCES [User](UserID)
	, [Login] VARCHAR(50) NOT NULL
	, [Password] VARCHAR(50) NOT NULL
	, [RoleID] INT NOT NULL
		FOREIGN KEY REFERENCES [Role](RoleID)
);

CREATE TABLE [Employee] (
	[EmployeeID] INT IDENTITY(1,1) PRIMARY KEY
	, [UserID] INT
		FOREIGN KEY REFERENCES [User](UserID)
	, [Login] VARCHAR(50) NOT NULL
	, [Password] VARCHAR(50) NOT NULL
	, [RoleID] INT NOT NULL
		FOREIGN KEY REFERENCES [Role](RoleID)
);

CREATE TABLE [HomeTech] (
	[HomeTechID] INT IDENTITY(1,1) PRIMARY KEY
	, [Type] VARCHAR(75) NOT NULL
);

CREATE TABLE [TechFactory] (
	[TechFactoryID] INT IDENTITY(1,1) PRIMARY KEY
	, [Title] VARCHAR(75) NOT NULL
);

CREATE TABLE [ModelTechFactory] (
	[ModelTechFactoryID] INT IDENTITY(1,1) PRIMARY KEY
	, [TechFactoryID] INT NOT NULL
		FOREIGN KEY REFERENCES [TechFactory](TechFactoryID)
	, [Title] VARCHAR(50) NOT NULL
);

CREATE TABLE [TechColor] (
	[TechColorID] INT IDENTITY(1,1) PRIMARY KEY
	, [Color] VARCHAR(50) NOT NULL
);

CREATE TABLE [RequestStatus] (
	[RequestStatusID] INT IDENTITY(1,1) PRIMARY KEY
	, [Status] VARCHAR(50) NOT NULL
);

CREATE TABLE [Request] (
	[RequestID] INT IDENTITY(1,1) PRIMARY KEY
	, [StartDate] DATE NOT NULL
	, [HomeTechID] INT NOT NULL
		FOREIGN KEY REFERENCES [HomeTech](HomeTechID)
	, [TechFactoryID] INT NOT NULL
		FOREIGN KEY REFERENCES [TechFactory](TechFactoryID)
	, [ModelTechFactoryID] INT NOT NULL
		FOREIGN KEY REFERENCES [ModelTechFactory](ModelTechFactoryID)
	, [TechColorID] Int NOT NULL
		FOREIGN KEY REFERENCES [TechColor](TechColorID)
	, [ProblemeDescryption] VARCHAR(MAX) NOT NULL
	, [RequestStatusID] INT NOT NULL
		FOREIGN KEY REFERENCES [RequestStatus](RequestStatusID)
	, [CompletionDate] DATE
	, [RepairParts] VARCHAR(MAX) NOT NULL
	, [MasterID] INT
		FOREIGN KEY REFERENCES [Employee](EmployeeID)
	, [ClientID] INT NOT NULL
		FOREIGN KEY REFERENCES [Client](ClientID)
);

CREATE TABLE [Comment] (
	[CommentID] INT IDENTITY(1,1) PRIMARY KEY
	, [Message] VARCHAR(MAX) NOT NULL
	, [MasterID] INT NOT NULL
		FOREIGN KEY REFERENCES [User](UserID)
	, [RequestID] INT NOT NULL
		FOREIGN KEY REFERENCES [Request](RequestID)
);

----
CREATE TABLE [ActionStatus] (
	[ActionStatusID] INT IDENTITY(1,1) PRIMARY KEY
	, [Type] VARCHAR(50) NOT NULL
);

CREATE TABLE [ActionLog] (
	[ActionLogID] INT IDENTITY(1,1) PRIMARY KEY
	, [DateAndTime] DATETIME NOT NULL
	, [UserID] INT NOT NULL
		FOREIGN KEY REFERENCES [User](UserID)
	, [ActionStatusID] INT NOT NULL
		FOREIGN KEY REFERENCES [ActionStatus](ActionStatusID)
	, [Descryption] VARCHAR(MAX) NOT NULL
);

CREATE TABLE [NewMessage] (
	[NewMessageID] INT IDENTITY(1,1) PRIMARY KEY
	, [DateAndTime] DATETIME NOT NULL
	, [RequestID] INT NOT NULL
		FOREIGN KEY REFERENCES [Request](RequestID)
	, [Descryption] VARCHAR(MAX) NOT NULL
	, [RequestStatusID] INT NOT NULL
		FOREIGN KEY REFERENCES [RequestStatus](RequestStatusID)
	, [UserID] INT NOT NULL
		FOREIGN KEY REFERENCES [User](UserID)
)