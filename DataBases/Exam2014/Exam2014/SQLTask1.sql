-- 1. Get the full name (first name + " " + last name) of every employee and its salary,
-- for each employee with salary between $100 000 and $150 000, inclusive. 
-- Sort the results by salary in ascending order.
USE Company

SELECT *
FROM Employees
WHERE 100000 <= Employees.AnnualSalary AND Employees.AnnualSalary <=150000
ORDER by Employees.AnnualSalary ASC 