/* Create table Cities with (CityId, Name) */
USE NORTHWND

CREATE TABLE Cities (
	[CityId] INT IDENTITY PRIMARY KEY,
	[NAME] NVARCHAR (50) 
)
GO
/* Insert into Cities all the Cities from Employees, Suppliers, Customers tables (RESULT: 95 row(s) affected) */
exec sp_rename 'Citites', 'Cities'
exec sp_rename 'Cities.NAME', 'Name', 'COLUMN'

INSERT INTO Cities
	SELECT e.City
		FROM Employees e
		WHERE e.City IS NOT NULL
	UNION SELECT s.City
		FROM Suppliers s
		WHERE s.City IS NOT NULL
	UNION SELECT c.City
		FROM Customers c
		WHERE c.City IS NOT NULL
GO

/* Add CityId into Employees, Suppliers, Customers tables which is Foreign Key to CityId in Cities */
ALTER TABlE Employees
	ADD CityId INT

ALTER TABlE Suppliers
	ADD CityId INT

ALTER TABlE Customers
	ADD CityId INT
GO

ALTER TABLE Employees
	ADD CONSTRAINT FK_Employees_Cities
		FOREIGN KEY (CityId)
		REFERENCES Cities(CityId)

ALTER TABLE Suppliers
	ADD CONSTRAINT FK_Suppliers_Cities
		FOREIGN KEY (CityId)
		REFERENCES Cities(CityId)

ALTER TABLE Customers
	ADD CONSTRAINT FK_Customers_Cities
		FOREIGN KEY (CityId)
		REFERENCES Cities(CityId)

GO

/* Update Employees, Suppliers, Customers tables with CityId which is in the Cities table
	Employees (RESULT: 9 row(s) affected)
	Suppliers (RESULT: 29 row(s) affected)
	Customers (RESULT: 91 row(s) affected) */

UPDATE Employees
	SET CityId = (
		SElECT Cities.CityId
		FROM Cities
		WHERE Employees.City = Cities.[NAME]
	)

UPDATE Suppliers
	SET CityId = (
		SElECT Cities.CityId
		FROM Cities
		WHERE Suppliers.City = Cities.[NAME]
	)

UPDATE Customers
	SET CityId = (
		SElECT Cities.CityId
		FROM Cities
		WHERE Customers.City = Cities.[NAME]
	)

/* Make the column Name in Cities Unique */
ALTER TABLE Cities
	ADD UNIQUE([Name])

/* Now after looking at the database again we found there are Cities (ShipCity) in the Orders table as well :D
 (always read before start coding). Insert those cities please. (RESULT: 1 row(s) affected) */
 INSERT INTO Cities ([Name])
	SELECT DISTINCT o.ShipCity
	FROM Orders o
	WHERE NOT EXISTS (
		SELECT c.[Name]
		FROM Cities c
		WHERE c.[Name] = o.ShipCity
	)

/* Add CityId column in Orders with Foreign Key to CityId in Cities */
ALTER TABLE Orders
	ADD CityId INT

ALTER TABLE Orders
	ADD CONSTRAINT FK_Orders_Cities
		FOREIGN KEY (CityId)
		REFERENCES Cities(CityId)

/* Now rename that column to be ShipCityId to be consistent (use stored procedure :) ) */
EXEC sp_rename 'Orders.CityId', 'ShipCityId', 'COLUMN'

/* Update ShipCityId in Orders table with values from Cities table (RESULT: 830 row(s) affected) */
UPDATE Orders
	SET ShipCityId = (
		SELECT c.CityId
		FROM Cities c
		WHERE Orders.ShipCity = c.[Name]
	)

/* Drop column ShipCity from Orders */
ALTER TABLE Orders
	DROP COLUMN ShipCity

/* Create table Countries with columns CountryId and Name (Unique) */
CREATE TABLE Countries(
	CountryId INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50) UNIQUE
)

/* Add CountryId to Cities with Foreign Key to CountryId in Countries */
ALTER TABLE Cities
	ADD CountryId INT

ALTER TABLE Cities
	ADD CONSTRAINT FK_Cities_Countries
		FOREIGN KEY (CountryId)
		REFERENCES Countries(CountryId)

/* Insert all the Countries from Employees, Customers, Suppliers and Orders (RESULT: 25 row(s) affected) */
INSERT INTO Countries ([Name])
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
USE NORTHWND

UPDATE Cities	
	SET CountryId = (
		SELECT TOP 1 Countries.CountryId
		FROM Customers, Countries, Suppliers
		WHERE Cities.[Name] = Suppliers.City AND Suppliers.Country = Countries.[Name]
	)

UPDATE Cities	
	SET CountryId = (
		SELECT DISTINCT Countries.CountryId
		FROM Orders, Countries, Suppliers
		WHERE Cities.CityId = Orders.ShipCityId AND Orders.ShipCountry = Countries.[Name]
	)
	
SELECT COUNT(*)
FROM Cities
WHERE Cities.CountryId IS NULL

SELECT COUNT(DISTINCT Customers.CityId)
FROM Orders, Customers
WHERE Customers.CityId = Orders.ShipCityId

SELECT COUNT(DISTINCT Orders.ShipCityId)
FROM Orders

SELECT COUNT(DISTINCT Customers.CityId)
FROM Customers

/* Drop column City and ShipCity from Employees, Suppliers, Customers and Orders tables */
