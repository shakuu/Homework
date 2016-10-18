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
 Consider that the mail domain is telerik.com. Emails should look like �John.Doe@telerik.com". 
 The produced column should be named "Full Email Addresses". */
 USE TelerikAcademy

 SELECT FirstName + '.' + LastName + '@telerik.com' as [Full Email Addresses]
 FROM Employees 

 /* Write a SQL query to find all different employee salaries. */
 USE TelerikAcademy

 SELECT DISTINCT Salary
 FROM Employees 

 /* Write a SQL query to find all information about the employees whose job title is �Sales Representative�. */
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

 /* Write a SQL query to find the salary of all employees whose salary is in the range [20000�30000]. */
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