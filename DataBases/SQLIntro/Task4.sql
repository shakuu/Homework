/* Write a SQL query to find all information about all departments (use "TelerikAcademy" database) */

USE TelerikAcademy

SELECT * FROM Departments 

/* Write a SQL query to find all department names. */
USE TelerikAcademy

SELECT Name
FROM Departments

/*Write a SQL query to find the salary of each employee.*/
USE TelerikAcademy

SELECT Salary 
FROM Employees 

/* Write a SQL to find the full name of each employee. */
USE TelerikAcademy

SELECT FirstName + ' ' + LastName as [Full Name]
FROM Employees 

/* Write a SQL query to find the email addresses of each employee (by his first and last name).
 Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". 
 The produced column should be named "Full Email Addresses". */
 USE TelerikAcademy

 SELECT FirstName + '.' + LastName + '@telerik.com' as [Full Email Addresses]
 FROM Employees 

 /* Write a SQL query to find all different employee salaries. */
 USE TelerikAcademy

 SELECT DISTINCT Salary
 FROM Employees 

 /* Write a SQL query to find all information about the employees whose job title is “Sales Representative“. */
 USE TelerikAcademy
 
 SELECT *
 FROM Employees 
 WHERE JobTitle = 'Sales Representative'

 /* Write a SQL query to find the names of all employees whose first name starts with "SA". */
 USE TelerikAcademy

 SELECT *
 FROM Employees 
 WHERE FirstName LIKE 'SA%'

 /* Write a SQL query to find the names of all employees whose last name contains "ei". */
 USE TelerikAcademy

 SELECT *
 FROM Employees 
 WHERE LastName LIKE '%ei%'

 /* Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000]. */
 USE TelerikAcademy

 SELECT Salary
 FROM Employees 
 WHERE Salary BETWEEN 20000 AND 30000

 /* Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600. */
 USE TelerikAcademy

 SELECT Salary
 FROM Employees
 WHERE Salary IN(25000, 14000, 12500, 23600)

 /* Write a SQL query to find all employees that do not have manager. */
 USE TelerikAcademy

 SELECT FirstName + ' ' + LastName as [FullName]
 FROM Employees
 WHERE ManagerID IS NULL

 /* Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary. */
 USE TelerikAcademy

 SELECT FirstName + ' ' + LastName as [FullName]
 FROM Employees
 WHERE Salary > 50000
 ORDER BY Salary DESC

 /* Write a SQL query to find the top 5 best paid employees. */
 USE TelerikAcademy

 SELECT TOP(5) FirstName + ' ' + LastName as [FullName], Salary
 FROM Employees
 ORDER BY Salary DESC

 /* Write a SQL query to find all employees along with their address. Use inner join with ON clause. */
 USE TelerikAcademy

 SELECT e.FirstName + ' ' + e.LastName as [FullName], a.AddressText
 FROM Employees e
	INNER JOIN Addresses a
		ON e.AddressID = a.AddressID

/* Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause). */
USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName as [FullName], a.AddressText
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID

/* Write a SQL query to find all employees along with their manager. */
USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName as [Employee], 
	   m.FirstName + ' ' + m.LastName as [Manager]
FROM Employees e
	JOIN Employees m
		ON e.ManagerID = m.EmployeeID

/* Write a SQL query to find all employees, along with their manager and their address.
 Join the 3 tables: Employees e, Employees m and Addresses a. */
 USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName as [Employee], 
	   ea.AddressText as [EmployeeAddress],
	   m.FirstName + ' ' + m.LastName as [Manager],
	   em.AddressText as [ManagerAddress]
FROM Employees e
	JOIN Employees m
		ON e.ManagerID = m.EmployeeID
	JOIN Addresses ea
		ON e.AddressID = ea.AddressID
	JOIN Addresses em
		ON e.ManagerID = m.EmployeeID AND m.AddressID = em.AddressID

