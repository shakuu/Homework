/* Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
	Insert few records for testing.
	Write a stored procedure that selects the full names of all persons. */
USE TSQL_HW

CREATE TABLE Persons(
	Id int IDENTITY PRIMARY KEY ,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	SSN nvarchar(50)
)
GO

CREATE TABLE Accounts(
	Id int IDENTITY PRIMARY KEY,
	PersonId int,
	Balance money
)

ALTER TABLE Accounts
	ADD CONSTRAINT FK_ACCOUNTS_PERSONS
		FOREIGN KEY(PersonId)
		REFERENCES Persons(Id)

GO

/* Insert few records for testing. */
INSERT INTO Persons 
	VALUES 
	('FirstOne', 'LastOne', '1234567890'),
	('FirstTwo', 'LastTwo', '1234567891'),
	('First3', 'Last3', '1234567892'),
	('First4', 'Last4', '1234567893')
GO

INSERT INTO Accounts
	VALUES
	(1, 2000),
	(2, 4500),
	(3, 7500),
	(4, 10000)
GO

SELECT p.FirstName, p.LastName, a.Balance
FROM Persons p
JOIN Accounts a
	ON a.PersonId = p.Id
GO