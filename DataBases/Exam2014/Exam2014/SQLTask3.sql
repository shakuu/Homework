-- 3. Get each employee’s full name (first name + " " + last name),
-- project’s name, department’s name, 
-- starting and ending date for each employee in project. 
-- Additionally get the number of all reports, which time of reporting is between the start and end date. 
-- Sort the results first by the employee id, then by the project id. (This query is slow, be patient!)

USE Company

SELECT 
	Projects.[Name] as [ProjectName], 
	Employees.[FirstName] + ' ' + Employees.[LastName] as [EmployeeFullName], 
	Departments.[Name] as [Department],
	COUNT(Reports.Id) as [ReportsCount],
	Employees_Projects.StartDate,
	Employees_Projects.EndDate

FROM Projects
JOIN Employees_Projects
	ON Projects.Id = Employees_Projects.ProjectId
JOIN Employees
	ON Employees.Id = Employees_Projects.EmployeeId
JOIN Departments
	ON Departments.Id = Employees.DepartmentId
JOIN Reports
	ON Reports.EmployeeId = Employees.Id
WHERE Reports.TimeSent >= Employees_Projects.StartDate AND Reports.TimeSent <= Employees_Projects.EndDate
GROUP BY Projects.[Name], Employees.[FirstName], Employees.[LastName], Departments.[Name], Employees_Projects.StartDate, Employees_Projects.EndDate
ORDER BY Projects.[Name], Employees_Projects.StartDate, Employees_Projects.EndDate