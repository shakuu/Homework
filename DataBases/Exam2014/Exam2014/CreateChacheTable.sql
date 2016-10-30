USE Company
GO
CREATE PROCEDURE usp_CreateCachedTable
	AS
		CREATE TABLE CachedQuery(
			ProjectName NVARCHAR(50),
			EmployeeFullName NVARCHAR(150),
			DepartmentName NVARCHAR(50),
			ReportsCount INT,
			StartDate DATETIME,
			EndDate DATETIME
		)
GO

EXEC usp_CreateCachedTable

GO
