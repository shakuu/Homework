-- 2. Get all departments and how many employees there are in each one.
-- Sort the result by the number of employees in descending order.

USE Company

SELECT Departments.[Name], COUNT(*) as [EmployeeCount]
	FROM Employees
JOIN Departments
	ON Departments.Id = Employees.DepartmentId
GROUP BY Employees.DepartmentId, Departments.[Name]
ORDER BY COUNT(*) ASC