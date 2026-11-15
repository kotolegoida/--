SELECT 
    e.EmployeeName AS EmployeeName,
    m.EmployeeName AS ManagerName
FROM Employees AS e
LEFT JOIN Employees AS m 
    ON e.ManagerId = m.EmployeeId;
    
    SELECT 
    EmployeeId,
    EmployeeName,
    Salary
FROM Employees
WHERE Salary > (SELECT AVG(Salary) FROM Employees);
SELECT 
    EmployeeId,
    EmployeeName,
    Salary
FROM Employees
WHERE Salary = (SELECT MAX(Salary) FROM Employees);