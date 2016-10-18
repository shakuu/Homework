/* Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
Use a nested SELECT statement. */
USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName as [FullName], e.Salary
FROM Employees e
WHERE e.Salary = (
	SELECT MIN(d.Salary)
	FROM Employees d)
	
/* Write a SQL query to find the names and salaries of the employees that have a salary 
   that is up to 10% higher than the minimal salary for the company. */
USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName as [FullName], e.Salary
FROM Employees e
WHERE e.Salary <= 1.1 * (
	SELECT MIN(d.Salary)
	FROM Employees d)

/* Write a SQL query to find the full name, salary and department of the employees
   that take the minimal salary in their department.
   Use a nested SELECT statement. */

USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName as [FullName], e.Salary, d.Name as [DepartmentName]
FROM Employees e, Departments d
WHERE e.Salary IN (
	SELECT MIN(es.Salary)
	FROM Employees es
	WHERE es.DepartmentID = d.DepartmentID)
ORDER BY d.Name

/* Write a SQL query to find the average salary in the department #1. */
USE TelerikAcademy

SELECT AVG(e.Salary) as [AverageSalary]
FROM Employees e
WHERE e.DepartmentID = 1

/* Write a SQL query to find the average salary in the "Sales" department. */
USE TelerikAcademy

SELECT AVG(e.Salary) as [AverageSalary], d.Name as [DepartmentName]
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID AND d.Name = 'Sales'
GROUP BY d.Name

/* Write a SQL query to find the number of employees in the "Sales" department. */
USE TelerikAcademy

SELECT COUNT(*) as [EmployeesCount], d.Name as [DepartmentName]
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID AND d.Name = 'Sales'
GROUP BY d.Name

/* Write a SQL query to find the number of all employees that have manager. */
USE TelerikAcademy

SELECT COUNT(*) as [EmployeesCount]
FROM Employees e
WHERE e.ManagerID IS NOT NULL

/* Write a SQL query to find the number of all employees that have no manager. */
USE TelerikAcademy

SELECT COUNT(*) as [EmployeesCount]
FROM Employees e
WHERE e.ManagerID IS NULL

/* Write a SQL query to find all departments and the average salary for each of them. */
USE TelerikAcademy

SELECT AVG(e.Salary) as [AverageSalary], d.Name as [DepartmentName]
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID
GROUP BY e.DepartmentID, d.Name

/* Write a SQL query to find the count of all employees in each department and for each town. */
SELECT COUNT(*) as [EmployeesCount], d.Name as [DepartmentName], t.Name as [TownName]
FROM Employees e, Departments d, Addresses a, Towns t
WHERE e.DepartmentID = d.DepartmentID AND e.AddressID = a.AddressID AND a.TownID = t.TownID
GROUP BY d.Name, t.Name

/* Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name. */
USE TelerikAcademy

SELECT m.FirstName + ' ' + m.LastName as [FullName]
FROM Employees m
WHERE m.EmployeeID IN (
	SELECT e.ManagerID
	FROM Employees e
	GROUP BY e.ManagerID
	HAVING COUNT(*) = 5)

/* Write a SQL query to find all employees along with their managers.
   For employees that do not have manager display the value "(no manager)". */
USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName as [EmployeeName],
	   ISNULL(m.FirstName + ' ' + m.LastName, '(no manger)') as [ManagerName]
FROM Employees e
	LEFT OUTER JOIN Employees m
	ON	e.ManagerID = m.EmployeeID

/* Write a SQL query to find the names of all employees whose 
   last name is exactly 5 characters long. Use the built-in LEN(str) function. */
USE TelerikAcademy 

SELECT e.FirstName + ' ' + e.LastName as [FullName]
FROM Employees e
WHERE LEN(e.LastName) = 5

/* Write a SQL query to display the current date and time in the following format 
	"day.month.year hour:minutes:seconds:milliseconds".
	Search in Google to find how to format dates in SQL Server. */
SELECT CONVERT(VARCHAR(50),GETDATE(),3) + ' ' + CONVERT(VARCHAR(50),GETDATE(),14)

/* Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
Define the primary key column as identity to facilitate inserting records.
Define unique constraint to avoid repeating usernames.
Define a check constraint to ensure the password is at least 5 characters long. */
USE TelerikAcademy

CREATE TABLE Users (
	id int NOT NULL IDENTITY PRIMARY KEY,
	username nvarchar(100) UNIQUE NOT NULL,
	passHash nvarchar(160) NOT NULL,
	fullname nvarchar(160), 
	lastlogin datetime)

/* GO executes everything above and starts a new batch of commands 
   it's here to prevent the command below from whining) */
GO 
/* Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
   Test if the view works correctly. */
CREATE VIEW UsersDefaultView AS
	SELECT u.username, u.lastlogin
	FROM TelerikAcademy.dbo.Users u
GO

SELECT * FROM UsersDefaultView

/* Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
   Define primary key and identity column. */
USE TelerikAcademy

CREATE TABLE Groups (
	id int NOT NULL IDENTITY PRIMARY KEY,
	name nvarchar(50) UNIQUE)

/* Write a SQL statement to add a column GroupID to the table Users.
   Fill some data in this new column and as well in the `Groups table.
   Write a SQL statement to add a foreign key constraint between tables Users and Groups tables. */
USE TelerikAcademy

ALTER TABLE Users 
	ADD GroupID int

ALTER TABLE Users	
	ADD CONSTRAINT FK_USERS_GROUPS
		FOREIGN KEY(GroupID)
		REFERENCES Groups(id)

/* Write SQL statements to insert several records in the Users and Groups tables. */
USE TelerikAcademy

INSERT INTO Users (username, passHash, groupid)
	VALUES
	('me', '12345o', 1),
	('myeself', '12345p', 1),
	('and I', '12345q', 1)
		
INSERT INTO Groups (name)
	VALUES 
	('2'),
	('3'),
	('5'),
	('7')