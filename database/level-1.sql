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

SELECT 
    DepartmentId,
    COUNT(*) AS EmployeeCount,
    AVG(Salary) AS AverageSalary,
    SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentId
ORDER BY AverageSalary DESC;

SELECT 
    DepartmentId,
    COUNT(*) AS EmployeeCount,
    AVG(Salary) AS AverageSalary
FROM Employees
GROUP BY DepartmentId
HAVING AVG(Salary) > 50000
ORDER BY AverageSalary ASC;

SELECT TOP 2
    DepartmentId,
    COUNT(*) AS FilteredEmployeeCount,
    MAX(Salary) AS MaxDepartmentSalary
FROM Employees
WHERE Salary >= 45000
GROUP BY DepartmentId
HAVING COUNT(*) > 1
ORDER BY MaxDepartmentSalary DESC;

SELECT 
    e.EmployeeName,
    d.DepartmentName,
    e.Salary
FROM Employees AS e
INNER JOIN Departments AS d 
    ON e.DepartmentId = d.DepartmentId
ORDER BY d.DepartmentName ASC, e.Salary DESC;

SELECT 
    e.EmployeeId,
    e.EmployeeName
FROM Employees AS e
LEFT JOIN EmployeeProjects AS ep 
    ON e.EmployeeId = ep.EmployeeId
WHERE ep.EmployeeId IS NULL;

SELECT 
    e.EmployeeName,
    d.DepartmentName,
    p.ProjectName,
    ep.Hours
FROM Employees AS e
INNER JOIN Departments AS d 
    ON e.DepartmentId = d.DepartmentId
INNER JOIN EmployeeProjects AS ep 
    ON e.EmployeeId = ep.EmployeeId
INNER JOIN Projects AS p 
    ON ep.ProjectId = p.ProjectId
ORDER BY d.DepartmentName ASC, e.EmployeeName ASC, p.ProjectName ASC;