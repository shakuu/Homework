USE Company

ALTER TABLE Employees
	ADD CHECK (LEN(FirstName) >= 5)

ALTER TABLE Employees
	ADD CHECK (LEN(LastName) >= 5)