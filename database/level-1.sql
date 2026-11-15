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

SELECT TOP 5 EmployeeId, EmployeeName, HireDate
FROM Employees
ORDER BY HireDate ASC;

SELECT EmployeeId, EmployeeName, DepartmentId, Salary
FROM Employees
ORDER BY DepartmentId ASC, Salary DESC;

USE PracticeDB;
GO

SELECT 
    COUNT(*) AS TotalEmployees,
    SUM(Salary) AS TotalSalarySum,
    ROUND(AVG(Salary), 2) AS AverageSalary,
    MIN(Salary) AS MinSalary,
    MAX(Salary) AS MaxSalary,
    SUM(CASE WHEN Salary > 50000 THEN 1 ELSE 0 END) AS HighPaidEmployeesCount
FROM Employees;