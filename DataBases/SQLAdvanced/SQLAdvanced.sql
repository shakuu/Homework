/* Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
Use a nested SELECT statement. */
USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName as [FullName], e.Salary
FROM Employees e
WHERE e.Salary = 
	(SELECT MIN(d.Salary)
	FROM Employees d)
	
/* Write a SQL query to find the names and salaries of the employees that have a salary 
   that is up to 10% higher than the minimal salary for the company. */
USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName as [FullName], e.Salary
FROM Employees e
WHERE e.Salary <= 1.1 * 
	(SELECT MIN(d.Salary)
	 FROM Employees d)

/* Write a SQL query to find the full name, salary and department of the employees
   that take the minimal salary in their department.
   Use a nested SELECT statement. */

USE TelerikAcademy

SELECT e.FirstName + ' ' + e.LastName as [FullName], e.Salary, d.Name as [DepartmentName]
FROM Employees e, Departments d
WHERE e.Salary IN
	(SELECT MIN(es.Salary)
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