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

/* Create a stored procedure that accepts a number as a parameter 
	and returns all persons who have more money in their accounts than the supplied number. */
CREATE PROCEDURE usp_PersonsWithBalanceHigherThen(@minimumAmount money = 0)
	AS
		SELECT *
		FROM Persons p
		JOIN Accounts a
			ON a.PersonId = p.Id
		WHERE a.Balance > @minimumAmount
GO

EXEC usp_PersonsWithBalanceHigherThen 5000

GO

/* Create a function that accepts as parameters – sum, yearly interest rate and number of months.
	It should calculate and return the new sum.
	Write a SELECT to test whether the function works as expected. */
USE TSQL_HW
GO
CREATE FUNCTION ufn_CalculateInterest(@amount money, @interestPerYear money, @periodInMonths int)
	RETURNS money
	AS
		BEGIN
			DECLARE @result money, @interest money
			SET @interest = @interestPerYear / 12 * @periodInMonths
			SET @result = (@amount * @interest) + @amount

			RETURN @result
		END
GO

USE TSQL_HW
SELECT dbo.ufn_CalculateInterest(1000, 10, 12)

GO
/* Create a stored procedure that uses the function from the previous example to give an 
	interest to a person's account for one month.
	It should take the AccountId and the interest rate as parameters. */
CREATE PROCEDURE usp_ApplyInterest(@accountId int, @interestRate money)
	AS
		UPDATE Accounts 
		SET Balance = dbo
			.ufn_CalculateInterest(
				(SELECT a.Balance 
					FROM Accounts a 
					WHERE a.Id = @accountId), 
				@interestRate, 
				1)
		WHERE Id = @accountId
GO

EXEC usp_ApplyInterest 1, 10

SELECT *
FROM Accounts a
WHERE a.Id = 1

/* Add two more stored procedures WithdrawMoney(AccountId, money) 
	and DepositMoney(AccountId, money) that operate in transactions. */
GO

CREATE PROCEDURE usp_WithdrawMoney(@accountId int, @amount money)
	AS
	BEGIN TRANSACTION
		UPDATE Accounts
		SET Balance = (-@amount) + (
			SELECT a.Balance
			FROM Accounts a
			WHERE a.Id = @accountId
		)
	COMMIT

GO

EXEC usp_WithdrawMoney 1, 100

SELECT Balance
FROM Accounts a
WHERE a.Id = 1

GO

CREATE PROCEDURE usp_DepositMoney(@accountId int, @amount money)
	AS
	BEGIN TRANSACTION
		UPDATE Accounts
		SET Balance = (@amount) + (
			SELECT a.Balance
			FROM Accounts a
			WHERE a.Id = @accountId
		)
	COMMIT

GO

EXEC usp_DepositMoney 1, 100

SELECT Balance
FROM Accounts a
WHERE a.Id = 1

GO