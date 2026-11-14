SELECT EmployeeId, EmployeeName, Salary 
FROM Employees 
WHERE Salary > 50000;

SELECT EmployeeId, EmployeeName, HireDate 
FROM Employees 
WHERE YEAR(HireDate) = 2023;

SELECT EmployeeId, EmployeeName 
FROM Employees 
WHERE EmployeeName LIKE N'А%';

SELECT EmployeeId, EmployeeName, DepartmentId 
FROM Employees 
WHERE DepartmentId = 2;

SELECT EmployeeId, EmployeeName, Salary 
FROM Employees 
WHERE Salary BETWEEN 40000 AND 60000;