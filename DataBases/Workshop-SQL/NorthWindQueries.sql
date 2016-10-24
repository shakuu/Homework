USE NORTHWND

CREATE TABLE Cities (
	[Id] INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

GO

/* Insert into Cities all the Cities from Employees, Suppliers, Customers tables (RESULT: 95 row(s) affected) */
INSERT INTO Cities 
SELECT DISTINCT e.City
	FROM Employees e
	WHERE e.City IS NOT NULL
UNION SELECT DISTINCT s.City
	FROM Suppliers s
	WHERE s.City IS NOT NULL
UNION SELECT DISTINCT c.City
	FROM Customers c
	WHERE c.City IS NOT NULL

GO

/* Add CityId into Employees, Suppliers, Customers tables which is Foreign Key to CityId in Cities */
ALTER TABLE Employees 
	ADD CityId INT

GO

ALTER TABLE Employees 
	ADD CONSTRAINT FK_Employees_Cities
		FOREIGN KEY (CityId)
		REFERENCES Cities(Id)

GO

ALTER TABLE Suppliers 
	ADD CityId INT

GO

ALTER TABLE Suppliers 
	ADD CONSTRAINT FK_Suppliers_Cities
		FOREIGN KEY (CityId)
		REFERENCES Cities(Id)

GO

ALTER TABLE Customers 
	ADD CityId INT

GO

ALTER TABLE Customers 
	ADD CONSTRAINT FK_Customers_Cities
		FOREIGN KEY (CityId)
		REFERENCES Cities(Id)

GO

ALTER TABLE Cities
	ADD UNIQUE ([Name])

GO

/* Now after looking at the database again we found there are Cities (ShipCity) 
	in the Orders table as well :D (always read before start coding). 
	Insert those cities please. (RESULT: 1 row(s) affected) */
USE NORTHWND

INSERT INTO Cities ([Name])
	SELECT DISTINCT o.ShipName
	FROM Orders o
	WHERE o.ShipName NOT IN (
		SELECT c.[Name]
		FROM Cities c
	)

SELECT DISTINCT o.ShipName
	FROM Orders o
	WHERE o.ShipName NOT IN (
		SELECT c.[Name]
		FROM Cities c
	)


SELECT c.[Name]
FROM Cities c
UNION SELECT o.ShipCity
FROM Orders o

/* Add CityId column in Orders with Foreign Key to CityId in Cities */
ALTER TABLE Orders 
	ADD CityId INT

GO

ALTER TABLE Orders 
	ADD CONSTRAINT FK_Orders_Cities
		FOREIGN KEY (CityId)
		REFERENCES Cities(Id)

GO

/* Now rename that column to be ShipCityId to be consistent (use stored procedure :) ) */
exec sp_rename 'Orders.CityId','ShipCityId','COLUMN'
GO

/* Update Employees, Suppliers, Customers tables with CityId which is in the Cities table

Employees (RESULT: 9 row(s) affected)

Suppliers (RESULT: 29 row(s) affected)

Customers (RESULT: 91 row(s) affected) */
USE NORTHWND

UPDATE Employees 
	SET CityId = (
		SELECT c.Id
		FROM Cities c
		WHERE Employees.City = c.[Name]
	)
	GO
	
UPDATE Suppliers
	SET CityId = (
		SELECT c.Id
		FROM Cities c
		WHERE Suppliers.City = c.[Name]
	)
GO

UPDATE Customers
	SET CityId = (
		SELECT c.Id
		FROM Cities c
		WHERE Customers.City = c.[Name]
	)
GO

/* Drop column ShipCity from Orders */
ALTER TABLE Orders
DROP COLUMN ShipCity

/* Create table Countries with columns CountryId and Name (Unique)*/
CREATE TABLE Countries(
	Id INT IDENTITY PRIMARY KEY,
	NAME nvarchar(50) UNIQUE
)

exec sp_rename 'Countries.NAME','Name','COLUMN'
GO

ALTER TABLE Countries
	DROP COLUMN CountryId

/* Add CountryId to Cities with Foreign Key to CountryId in Countries */
ALTER TABLE Cities
	ADD CountryId int

/* Insert all the Countries from Employees, Customers, Suppliers and Orders (RESULT: 25 row(s) affected) */
INSERT INTO Countries ([NAME])
	SELECT DISTINCT e.Country 
		FROM Employees e
		WHERE e.Country IS NOT NULL
	UNION SELECT DISTINCT c.Country
		FROM Customers c
		WHERE c.Country IS NOT NULL	
	UNION SELECT DISTINCT s.Country
		FROM Suppliers s
		WHERE s.Country IS NOT NULL
	UNION SELECT DISTINCT o.ShipCountry
		FROM Orders o
		WHERE o.ShipCountry IS NOT NULL

/* Update CountryId in Cities table with values from Countries table */
