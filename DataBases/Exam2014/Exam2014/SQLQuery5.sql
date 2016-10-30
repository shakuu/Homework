USE Company
GO
CREATE PROCEDURE usp_UpdateCachedQuery
	AS
	BEGIN
		DELETE FROM CachedQuery
		INSERT INTO CachedQuery
			SELECT 
	Projects.[Name], 
	Employees.[FirstName] + ' ' + Employees.[LastName], 
	Departments.[Name],
	COUNT(Reports.Id),
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
END
GO